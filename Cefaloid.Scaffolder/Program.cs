using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using Cefaloid.Scaffolder;
using Dia2Lib;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using Microsoft.DiaSymReader;
using CallingConvention = Cefaloid.Scaffolder.CallingConvention;
using ImageFileMachine = Cefaloid.Scaffolder.ImageFileMachine;

const string CefVersion = "116.0.21";
const string CefVersionMetadata = "g9c7dc32";
const string ChromiumVersion = "116.0.5845.181";

string localAppDataPathBase = Environment.GetEnvironmentVariable("CEFALOID_LOCALAPPDATA")
  ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create), "Cefaloid");

string localAppDataPath = Path.Combine(localAppDataPathBase, CefVersion);

var pdbUrl = $"https://cef-builds.spotifycdn.com/cef_binary_{CefVersion}%2B{CefVersionMetadata}%2Bchromium-{ChromiumVersion}_windows64_release_symbols.tar.bz2";

var dllFilePath = Path.Combine(localAppDataPath, "libcef.dll");

if (!File.Exists(dllFilePath)) {
  Console.Error.WriteLine("libcef.dll is missing, are you sure Cefaloid was installed?");
  return 1;
}

var pdbFileName = "libcef.dll.pdb";
var pdbFilePath = Path.Combine(localAppDataPath, pdbFileName);

if (!File.Exists(pdbFilePath)) {
  Console.Error.WriteLine("libcef.dll.pdb is missing, downloading...");
  using var http = new HttpClient {
    DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower,
    DefaultRequestVersion = new(3, 0)
  };
  var response = await http.GetAsync(pdbUrl, HttpCompletionOption.ResponseHeadersRead);

  /*
  var contentLength = -1L;
  if (response.Headers.TryGetValues("Content-Length", out var contentLengthValues))
    contentLength = long.Parse(contentLengthValues.First());
  */ // it is a compressed tar, technically we don't need to know?

  var downloadStream = await response.Content.ReadAsStreamAsync();

  // prepare the decompression stream
  await using var decompressionStream = new BZip2InputStream(downloadStream);
  // extract tar archive
  await using var archive = new TarInputStream(decompressionStream, new UTF8Encoding(false, false));
  // extract the files
  while (await archive.GetNextEntryAsync(default) is { } item) {
    if (item.IsDirectory)
      continue;

    var itemName = item.Name;

    if (itemName != pdbFileName) continue;

    var fso = new FileStreamOptions {
      Access = FileAccess.Write,
      Mode = FileMode.Create,
      Share = FileShare.Read | FileShare.Delete,
      BufferSize = 4096,
      Options = FileOptions.SequentialScan,
      PreallocationSize = item.Size
    };

    if (!OperatingSystem.IsWindows())
      fso.UnixCreateMode = (UnixFileMode) item.TarHeader.Mode;

    await using var targetStream = new FileStream(pdbFilePath, fso);
    await archive.CopyEntryContentsAsync(targetStream, default);

    break;
  }
}

var exportNames = new HashSet<string>();

unsafe void ResolveExportNames() {
  using var dllStream = new ReadOnlyFileMemoryMappingComStream(dllFilePath);

  ref var imageBase = ref Unsafe.AsRef<ImageDosHeader>(dllStream.BasePointer);

  if (imageBase.Magic != 0x5A4D) {
    Console.Error.WriteLine("libcef.dll is not a valid PE file.");
    return;
  }

  ref var newHeaders = ref imageBase.GetImageNtHeaders64();

  if (newHeaders.Signature != 0x4550) {
    Console.Error.WriteLine("libcef.dll is not a valid PE file.");
    return;
  }

  if (newHeaders.FileHeader.Machine != ImageFileMachine.AMD64) {
    Console.Error.WriteLine("libcef.dll is not a valid 64-bit PE file.");
    return;
  }

  if ((ushort) newHeaders.FileHeader.Characteristics != 0x2022)
    throw new NotImplementedException();

  if ((ushort) newHeaders.FileHeader.Characteristics != 0x2022)
    throw new NotImplementedException();

  if (newHeaders.OptionalHeader.Magic != 0x20B) {
    Console.Error.WriteLine("libcef.dll is not a valid PE file.");
    return;
  }

  ref var exportTable = ref newHeaders.OptionalHeader.GetExportTable(imageBase);

  var nameCount = exportTable.NumberOfNames;
  var rvaNameRvas = exportTable.AddressOfNames;
  var pNameRvas = (uint*) newHeaders.ResolveRva(rvaNameRvas, imageBase);
  var nameRvasSpan = new ReadOnlySpan<uint>(pNameRvas, (int) nameCount);
  for (var i = 0; i < nameCount; ++i) {
    var nameRva = nameRvasSpan[i];
    var pName = (byte*) newHeaders.ResolveRva(nameRva, imageBase);
    var nameSpan = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pName);
    var name = Encoding.UTF8.GetString(nameSpan);
    exportNames.Add(name);
  }
}

ResolveExportNames();

using var pdbStream = new ReadOnlyFileMemoryMappingComStream(pdbFilePath);

var diaSource = new DiaSourceClass();

diaSource.loadDataFromIStream(pdbStream);

diaSource.openSession(out var session);

session.getEnumTables(out var enumTables);

Dictionary<string, IDiaTable> tables = new();
foreach (IDiaTable table in enumTables) {
  tables[table.name] = table;
  Console.WriteLine($"// TABLE {table.name}");
}

/* empty
session.getExports(out var exports);
foreach (IDiaSymbol sym in exports)
  Console.WriteLine($"// EXPORT {(SymTagEnum) sym.symTag} {sym.name}");
*/

var syms = tables["Symbols"];

var typedefs = new Dictionary<string, IDiaSymbol>();
var reverseTypedef = new Dictionary<uint, string>();
var structsOrEnums = new Dictionary<string, (IDiaSymbol, Dictionary<string, IDiaSymbol>)>();

var extraEnums = new Dictionary<string, (IDiaSymbol, Dictionary<string, IDiaSymbol>)>();

var exports = new Dictionary<string, IDiaSymbol>();

foreach (IDiaSymbol sym in syms) {
  if (sym is null) break;

  switch ((SymTagEnum) sym.symTag) {
    case SymTagEnum.SymTagTypedef: {
      var symName = sym.name;
      if (symName is null) continue; // skip unnamed for now?

      if (!symName.StartsWith("cef")) continue; // skip non-cef typedefs
      if (symName.Contains("::")) continue; // skip namespaced typedefs

      typedefs[symName] = sym;
      AddStructOrEnum(sym.type as IDiaSymbol, symName);
      break;
    }
    case SymTagEnum.SymTagEnum:
    case SymTagEnum.SymTagUDT: {
      var symName = sym.name;
      if (symName is null) continue; // skip unnamed for now?

      if (!symName.StartsWith("cef")) continue; // skip non-cef typedefs
      if (symName.Contains("::")) continue; // skip namespaced typedefs

      AddStructOrEnum(sym.type as IDiaSymbol, null);
      break;
    }
    case SymTagEnum.SymTagData: {
      var symName = sym.name;
      if (symName is null) continue; // skip unnamed for now?

      if (!symName.StartsWith("cef")) continue; // skip non-cef typedefs
      if (symName.Contains("::")) continue; // skip namespaced typedefs

      var dataKind = (DataKind) sym.dataKind;
      throw new NotImplementedException();

      break;
    }
    case SymTagEnum.SymTagPublicSymbol: {
      var symName = sym.name;
      if (symName is null) continue; // skip unnamed for now?

      if (!symName.StartsWith("cef")) continue; // skip non-cef typedefs
      if (symName.Contains("::")) continue; // skip namespaced typedefs

      var isFunc = sym.function != 0;
      var loc = (LocationType) sym.locationType;
      if (loc is LocationType.IsConstant) {
        var value = sym.value;
        Console.WriteLine($"// TODO: CONST {sym.name} = {value}");
      }
      else if (isFunc) {
        var name = sym.name;
        if (exportNames.Contains(name))
          exports[name] = sym;
      }
      else {
        Console.WriteLine($"// TODO: {sym.name} {loc}");
      }

      break;
    }
    case SymTagEnum.SymTagExe:
    case SymTagEnum.SymTagCompiland:
      break;

#if DEBUG
    default: {
      var symName = sym.name;
      if (symName is null) continue; // skip unnamed for now?

      if (!symName.StartsWith("cef")) continue; // skip non-cef typedefs
      if (symName.Contains("::")) continue; // skip namespaced typedefs

      throw new NotImplementedException();

      break;
    }
#endif
  }
}

void AddStructOrEnum(IDiaSymbol? sym, string? typedefName) {
  if (sym is null) return;

  if (typedefName is not null)
    reverseTypedef[sym.symIndexId] = typedefName;

  var symName = sym.name;

  if ((SymTagEnum) sym.symTag is SymTagEnum.SymTagTypedef) {
    typedefs[symName] = sym;
    AddStructOrEnum(sym.type as IDiaSymbol, typedefName);
  }

  if (symName is null) return; // skip unnamed for now?

  sym.findChildren(SymTagEnum.SymTagNull, null, 0, out var children);
  var fields = new Dictionary<string, IDiaSymbol>();
  foreach (IDiaSymbol child in children) {
    if ((SymTagEnum) child.symTag is SymTagEnum.SymTagData) {
      var childName = child.name;
      if (childName == null) continue; // skip unnamed for now?

      fields.Add(childName, child);
    }
  }

  structsOrEnums[symName] = (sym, fields);
}

[return: NotNullIfNotNull(nameof(source))]
string? ConvertToPascalCase(string? source, bool stripUnderscoreT) {
  StringBuilder sb;
  if (stripUnderscoreT && (source?.EndsWith("_t") ?? false)) {
    var length = source.Length - 2;
    sb = new(source, 0, length, length);
  }
  else
    sb = new(source);

  var prevChar = '\0';
  for (var i = 0; i < sb.Length; ++i) {
    switch (sb[i]) {
      case >= 'a' and <= 'z':
        prevChar = prevChar is >= 'a' and <= 'z' or >= 'A' and <= 'Z'
          ? sb[i]
          : sb[i] = char.ToUpperInvariant(sb[i]);
        continue;

      case >= 'A' and <= 'Z':
        var temp = sb[i]; // for continued uppercase runs
        if (prevChar is >= 'A' and <= 'Z')
          sb[i] = char.ToLowerInvariant(sb[i]);
        prevChar = temp;
        continue;

      case '_':
        sb.Remove(i, 1);
        var c = sb[i];
        prevChar = c is >= 'a' and <= 'z'
          ? sb[i] = char.ToUpperInvariant(c)
          : sb[i];
        continue;

      default:
        prevChar = sb[i];
        continue;
    }
  }

  return sb.ToString();
}

Dictionary<string, string> manualTypeNameReplacements = new() {
  {"CefDomdocument", "CefDomDocument"},
  {"CefBaseRefCounted", "CefRefCountedBase"},
  {"CefStringUtf16", "CefString"},
  {"CefMainArgs", "CefMainArgsForWindows"},
  {"CefWindowInfo", "CefWindowInfoForWindows"},
  {"CefUrlrequestClient", "CefUrlRequestClient"},
  {"Topleft", "TopLeft"},
  {"Topright", "TopRight"},
  {"Bottomcenter", "BottomCenter"},
};

Dictionary<string, string> manualFieldNameReplacements = new() {
};

List<(string Match, string Replacement)> manualTextReplacements = new() {
  ("Byindex", "ByIndex"),
  ("Byname", "ByName"),
  ("Bykey", "ByKey"),
};

static string GetBasicTypeName(uint basicType) {
  switch ((BasicType) basicType) {
    case BasicType.NoType:
      throw new NotImplementedException();
    case BasicType.Void:
      return "void";
    case BasicType.Char8:
      return "byte";
    case BasicType.Sbyte:
      return "sbyte";
    case BasicType.Char16:
    case BasicType.Char:
      return "char";
    case BasicType.Short:
      return "short";
    case BasicType.UShort:
      return "ushort";
    case BasicType.Int:
      return "int";
    case BasicType.Char32:
    case BasicType.UInt:
      return "uint";
    case BasicType.Float:
      return "float";
    case BasicType.Bcd:
      throw new NotImplementedException();
    case BasicType.Bool:
      return "bool";
    case BasicType.Unk11:
      throw new NotImplementedException(); // byte?
    case BasicType.Unk12:
      throw new NotImplementedException(); // double?
    case BasicType.Long:
      return "long";
    case BasicType.ULong:
      return "ulong";
    case BasicType.Currency:
      throw new NotImplementedException(); // decimal?
    case BasicType.Date:
      throw new NotImplementedException(); // DateTime?
    case BasicType.Variant:
      throw new NotImplementedException(); // VARIANT
    case BasicType.Complex:
      throw new NotImplementedException(); // ???
    case BasicType.Bit:
      throw new NotImplementedException(); // ???
    case BasicType.BStr:
      throw new NotImplementedException(); // BSTR
    case BasicType.Hresult:
      throw new NotImplementedException(); // HRESULT
    default:
      throw new NotImplementedException(); // $"unk{basicType}";
  }
}

static Type GetBasicClrType(uint basicType) {
  switch ((BasicType) basicType) {
    case BasicType.NoType:
      throw new NotImplementedException();
    case BasicType.Void:
      return typeof(void);
    case BasicType.Char8:
      return typeof(byte);
    case BasicType.Sbyte:
      return typeof(sbyte);
    case BasicType.Char16:
    case BasicType.Char:
      return typeof(char);
    case BasicType.Short:
      return typeof(short);
    case BasicType.UShort:
      return typeof(ushort);
    case BasicType.Int:
      return typeof(int);
    case BasicType.Char32:
    case BasicType.UInt:
      return typeof(uint);
    case BasicType.Float:
      return typeof(float);
    case BasicType.Bcd:
      throw new NotImplementedException();
    case BasicType.Bool:
      return typeof(bool);
    case BasicType.Unk11:
      throw new NotImplementedException(); // byte?
    case BasicType.Unk12:
      throw new NotImplementedException(); // double?
    case BasicType.Long:
      return typeof(long);
    case BasicType.ULong:
      return typeof(ulong);
    case BasicType.Currency:
      throw new NotImplementedException(); // decimal?
    case BasicType.Date:
      throw new NotImplementedException(); // DateTime?
    case BasicType.Variant:
      throw new NotImplementedException(); // VARIANT
    case BasicType.Complex:
      throw new NotImplementedException(); // ???
    case BasicType.Bit:
      throw new NotImplementedException(); // ???
    case BasicType.BStr:
      throw new NotImplementedException(); // BSTR
    case BasicType.Hresult:
      throw new NotImplementedException(); // HRESULT
    default:
      throw new NotImplementedException(); // $"unk{basicType}";
  }
}

unsafe string ResolveFunctionType(IDiaSymbol func, int pointerDepth, string? trimPrefix = null) {
  var sb = new StringBuilder();
  if ((SymTagEnum) func.symTag == SymTagEnum.SymTagPublicSymbol) {
    if (func.function == 0)
      throw new NotImplementedException();

    session.findSymbolByRVA(func.relativeVirtualAddress, SymTagEnum.SymTagFunction, out func);

  }
  if ((SymTagEnum) func.symTag == SymTagEnum.SymTagFunction) {
    if (pointerDepth != 0)
      throw new NotImplementedException();
    var name = func.name;
    var funcType = func.type;
    var paramCount = funcType.count;
    var retType = (IDiaSymbol) funcType.type;
    var cc = (CallingConvention) func.callingConvention;
    sb.Append("  [DllImport(\"cef\", EntryPoint = \"");
    sb.Append(name);
    sb.Append("\", CallingConvention = CallingConvention.");
    sb.Append(cc switch {
      CallingConvention.NearC => "Cdecl",
      //CallingConvention.NearFast => "Fastcall",
      CallingConvention.NearStd => "Stdcall",
      _ => throw new NotImplementedException()
    });
    sb.Append(")]\n  public static unsafe extern ");
    sb.Append(ResolveTypeName(retType));
    sb.Append(' ');
    var convertedName = ConvertToPascalCase(name, true);
    foreach (var (match, replacement) in manualTextReplacements)
      convertedName = convertedName.Replace(match, replacement);
    if (trimPrefix is not null && convertedName.StartsWith(trimPrefix))
      convertedName = convertedName[trimPrefix.Length..];
    sb.Append(convertedName);
    sb.Append('(');
    funcType.findChildren(SymTagEnum.SymTagNull, null, 0, out var args);
    var argTypes = new List<string>((int) paramCount);
    foreach (IDiaSymbol arg in args) {
      var argType = arg.type;
      var argTypeName = ResolveTypeName(argType);
      if (argTypeName is null)
        throw new NotImplementedException();

      argTypes.Add(argTypeName);
    }

    sb.AppendJoin(',', argTypes);
    sb.Append(");\n");

    return sb.ToString();
  }
  else {
    if (pointerDepth == 0)
      throw new NotImplementedException();
    var paramCount = func.count;
    var retType = (IDiaSymbol) func.type;
    var cc = (CallingConvention) func.callingConvention;
    sb.Append(cc switch {
      CallingConvention.NearC => "unsafe delegate * unmanaged[Cdecl]",
      //CallingConvention.NearFast => "unsafe delegate * unmanaged[Fastcall]",
      CallingConvention.NearStd => "unsafe delegate * unmanaged[Stdcall]",
      //CallingConvention.ThisCall => "unsafe delegate * unmanaged[Thiscall]",
      //CallingConvention.ClrCall => "unsafe delegate * managed",
      _ => throw new NotImplementedException()
    });
    sb.Append('<');
    func.findChildren(SymTagEnum.SymTagNull, null, 0, out var args);
    var argTypes = new List<string>((int) (paramCount + 1));
    foreach (IDiaSymbol arg in args) {
      var argType = (IDiaSymbol) arg.type;
      var argTypeName = ResolveTypeName(argType);
      if (argTypeName is null)
        throw new NotImplementedException();

      argTypes.Add(argTypeName);
    }

    argTypes.Add(ResolveTypeName(retType)!);

    //argTypes.RemoveAll(x => x is null);

    //if (argTypes.Count > 0)

    sb.AppendJoin(',', argTypes);

    sb.Append('>');
    //while (pointerDepth-- > 0)
    while (--pointerDepth > 0)
      sb.Append('*');
    return sb.ToString();
  }
}

string? ResolveTypeName2(IDiaSymbol type, out bool isFuncPtr) {
  isFuncPtr = false;
  var pointerDepth = 0;
  while ((SymTagEnum) type.symTag is SymTagEnum.SymTagPointerType) {
    type = (IDiaSymbol) type.type;
    ++pointerDepth;
  }

  //if (type.constType != 0) throw new NotImplementedException();
  if (type.isStatic != 0) throw new NotImplementedException();

  var typeName = type.name;
  if (typeName is null) {
    switch ((SymTagEnum) type.symTag) {
      case SymTagEnum.SymTagBaseType:
        typeName = GetBasicTypeName(type.baseType);
        break;
      case SymTagEnum.SymTagFunctionType: {
        typeName = ResolveFunctionType(type, pointerDepth);
        pointerDepth = 0;
        isFuncPtr = true;
        break;
      }
      default:
        throw new NotImplementedException();
    }
  }
  else {
    var isEnum = (SymTagEnum) type.symTag is SymTagEnum.SymTagEnum;

    if (reverseTypedef.TryGetValue(type.symIndexId, out var resolved))
      typeName = resolved;

    if (isEnum && !structsOrEnums.ContainsKey(typeName)) {
      type.findChildren(SymTagEnum.SymTagNull, null, 0, out var enumChildren);
      var extraEnumChildren = new Dictionary<string, IDiaSymbol>();
      foreach (IDiaSymbol child in enumChildren) {
        var childName = child.name;
        if (childName == null) continue; // skip unnamed for now?

        extraEnumChildren.Add(childName, child);
      }

      extraEnums[typeName] = (type, extraEnumChildren);
    }

    typeName = ConvertToPascalCase(typeName, true);
    if (manualTypeNameReplacements.TryGetValue(typeName, out var replacement))
      typeName = replacement;
  }

  if (pointerDepth > 0)
    typeName += new string('*', pointerDepth);

  return typeName;
}

string? ResolveTypeName(IDiaSymbol type)
  => ResolveTypeName2(type, out _);

var genericSizeOfMethod = typeof(Unsafe)
  .GetMethod("SizeOf", BindingFlags.Public | BindingFlags.Static)!;

int GetSizeOf(Type type) {
  if (type.IsEnum)
    type = type.GetEnumUnderlyingType();

  if (type.IsPointer || type.IsByRef)
    return nint.Size;

  return (int) genericSizeOfMethod.MakeGenericMethod(type)
    .Invoke(null, null)!;
  //return Marshal.SizeOf(type); // screws up char
}

/*
unsafe int OffsetRetrievalTemplate<T>() where T: unmanaged {
  ref var nullRef = ref Unsafe.NullRef<T>();
  ref var offset = ref nullRef.Field;
  return (int)(nint)Unsafe.AsPointer(ref offset);
}
*/

Dictionary<FieldInfo, int> FieldOffsetCache = new();
var dynAsmName = new AssemblyName("Cefaloid.Dynamic");
var dynAsm = AssemblyBuilder.DefineDynamicAssembly(dynAsmName, AssemblyBuilderAccess.RunAndCollect,
  new CustomAttributeBuilder[] {
    new(typeof(IgnoresAccessChecksToAttribute)
        .GetConstructor(new[] {typeof(string)})!,
      new object?[] {
        "Cefaloid"
      })
  });
var dynMod = dynAsm.DefineDynamicModule("Cefaloid.Dynamic");

unsafe int GetOffsetOf(FieldInfo f) {
  if (FieldOffsetCache.TryGetValue(f, out var offset))
    return offset;

  var t = f.DeclaringType!;
  var dt = dynMod.DefineType($"OffsetOf_{t.FullName}_{f.Name}");
  var dm = dt.DefineMethod("Get",
    MethodAttributes.Public | MethodAttributes.Static,
    typeof(int), Type.EmptyTypes);

  var il = dm.GetILGenerator();
  dm.InitLocals = false;
  {
    il.DeclareLocal(t);
    // load the address of the local
    il.Emit(OpCodes.Ldloca_S, 0);
    // load the address of the field
    il.Emit(OpCodes.Ldflda, f);
    // convert the address of the field to an nint
    il.Emit(OpCodes.Conv_I);
    // load the address of the local again
    il.Emit(OpCodes.Ldloca_S, 0);
    // convert the address of the local to an nint
    il.Emit(OpCodes.Conv_I);
    // subtract the address of the local from the address of the field
    il.Emit(OpCodes.Sub);
    // convert the result to an int
    il.Emit(OpCodes.Conv_I4);
    // return the result
    il.Emit(OpCodes.Ret);
  }

  dt.CreateType();
  var m = dt.GetMethod("Get", BindingFlags.Public | BindingFlags.Static)!;
  //offset = (int) m.Invoke(null, null)!;
  // compile it dammit
  var fp = (delegate * managed<int>) m.MethodHandle.GetFunctionPointer();
  offset = fp();
  FieldOffsetCache[f] = offset;
  return offset;
}

Dictionary<(Type, Type), Delegate> CasterCache = new();

[return: NotNullIfNotNull(nameof(o))]
object? CastToType(object? o, Type destType) {
  if (o is null) return null;

  var srcType = o.GetType();

  if (CasterCache.TryGetValue((srcType, destType), out var caster))
    return caster?.DynamicInvoke(o)!;

  var srcParam = Expression.Parameter(srcType);
  var lambda = Expression.Lambda
    (Expression.Convert(srcParam, destType), srcParam);

  caster = lambda.Compile(false);

  return caster?.DynamicInvoke(o)!;
}

var asmLoadCtx = AssemblyLoadContext.Default;
using var reflectionScope = asmLoadCtx.EnterContextualReflection();

var cefaloidPath = Path.Combine(Environment.CurrentDirectory, "Cefaloid.dll");
Assembly? cefaloidAsm = null;
if (File.Exists(cefaloidPath)) {
  cefaloidAsm = asmLoadCtx.LoadFromAssemblyPath(cefaloidPath);
  Console.WriteLine("// validating against a build of Cefaloid");
}

Console.WriteLine("namespace Cefaloid;");

// TODO: during validation, check for static DllImport methods, validate
HashSet<string> imported = new(); // throw them in here and don't generate stubs for them at the end

void GenerateDefinition(string s, IDiaSymbol diaSymbol, Dictionary<string, IDiaSymbol> diaSymbols) {
  var name = s;

  if (reverseTypedef.TryGetValue(diaSymbol.symIndexId, out var resolved))
    name = resolved;

  if (diaSymbol.constType != 0) throw new NotImplementedException();
  if (diaSymbol.isStatic != 0) throw new NotImplementedException();

  var isEnum = (SymTagEnum) diaSymbol.symTag is SymTagEnum.SymTagEnum;
  var convertedName = ConvertToPascalCase(name, true);
  if (manualTypeNameReplacements.TryGetValue(convertedName, out var replacementName))
    convertedName = replacementName;
  string? maybeUnderlyingType = null;
  Type? maybeClrType = null;
  if (isEnum) {
    var underlyingType = diaSymbol.baseType;
    maybeUnderlyingType = $" : {GetBasicTypeName(underlyingType)}";
    maybeClrType = GetBasicClrType(underlyingType);
  }

  var cefaloidType = cefaloidAsm?.GetType($"Cefaloid.{convertedName}", false, true);

  var cefaloidTypeSize = 0;
  var cefaloidTypeIsEnum = false;
  if (cefaloidType is not null) {
    cefaloidTypeIsEnum = cefaloidType.IsEnum;
    cefaloidTypeSize = GetSizeOf(cefaloidType);
    if (isEnum != cefaloidTypeIsEnum)
      Console.WriteLine("/* already defined !! WRONG TYPE");
    else {
      if (cefaloidTypeSize != (int) diaSymbol.length)
        Console.WriteLine($"/* already defined !! WRONG SIZE {cefaloidTypeSize}, should be {diaSymbol.length}");
      else
        Console.WriteLine("/* already defined");
    }
  }

  if (!isEnum)
    Console.WriteLine($"[PublicAPI, StructLayout(LayoutKind.Sequential, Size={diaSymbol.length})]");
  if (cefaloidType is not null)
    Console.WriteLine($"{(isEnum ? "public enum" : "pubic struct")} {cefaloidType.Name}{maybeUnderlyingType} {{ // {name}");
  else
    Console.WriteLine($"{(isEnum ? "public enum" : "pubic struct")} {convertedName}{maybeUnderlyingType} {{ // {name}");

  Dictionary<string, object?>? cefaloidEnum = null;
  if (cefaloidTypeIsEnum && isEnum) {
    cefaloidEnum = new();
    foreach (var cefaloidEnumValue in Enum.GetValues(cefaloidType!)) {
      var cefaloidEnumName = Enum.GetName(cefaloidType!, cefaloidEnumValue);
      cefaloidEnum[cefaloidEnumName!] = cefaloidEnumValue;
    }
  }

  foreach (var (fieldName, fieldSym) in diaSymbols) {
    var fieldType = (IDiaSymbol) fieldSym.type;

    var fieldTypeName = ResolveTypeName2(fieldType, out var isFuncPtr);

    var convertedFieldName = fieldName;
    if (isEnum && fieldName.StartsWith(name) && fieldName[name.Length] == '_')
      convertedFieldName = fieldName[(name.Length + 1)..];
    convertedFieldName = ConvertToPascalCase(convertedFieldName, false);
    foreach (var (match, replacement) in manualTextReplacements)
      convertedName = convertedName.Replace(match, replacement);

    if (isEnum) {
      object? managedValue = null;
      cefaloidEnum?.TryGetValue(convertedFieldName, out managedValue);
      var fieldValue = fieldSym.value;
      var fieldValueType = fieldValue.GetType();
      var cefaloidEnumUnderlyingValue = cefaloidTypeIsEnum
        ? cefaloidType!.GetEnumUnderlyingType()
        : null;
      var valueStr = cefaloidTypeIsEnum
        ? fieldValueType == cefaloidEnumUnderlyingValue
          ? fieldValue.ToString()
          : CastToType(fieldValue, cefaloidEnumUnderlyingValue).ToString()
        : fieldValueType == maybeClrType
          ? fieldValue.ToString()
          : CastToType(fieldValue, maybeClrType).ToString();
      var managedValueStr = managedValue?.ToString();
      var isMissing = cefaloidType is not null && managedValue is null;
      if (isMissing) {
        // search for field by value
        var cefaloidValues = Enum.GetValuesAsUnderlyingType(cefaloidType!);
        var cefaloidEnumValues = cefaloidValues.Cast<object>()
          .Select(v => (Name: Enum.GetName(cefaloidType!, v), Value: v));
        foreach (var (enumName, enumValue) in cefaloidEnumValues) {
          var enumValueStr = ((IConvertible) enumValue).ToType(cefaloidEnumUnderlyingValue, null).ToString();
          if (enumValueStr == valueStr) {
            convertedFieldName = enumName;
            managedValue = enumValue;
            managedValueStr = enumValueStr;
            break;
          }
        }
      }

      if (managedValueStr is null) {
        if (isMissing)
          Console.WriteLine($"  {convertedFieldName} = {valueStr}, // {fieldName} !! MISSING");
        else
          Console.WriteLine($"  {convertedFieldName} = {valueStr}, // {fieldName}");
      }
      else {
        if (valueStr != managedValueStr)
          Console.WriteLine($"  {convertedFieldName} = {managedValueStr}, // {fieldName} !! EXPECTED {valueStr}");
        else
          Console.WriteLine($"  {convertedFieldName} = {managedValueStr}, // {fieldName}");
      }
    }
    else {
      if (isFuncPtr) convertedFieldName = $"_{convertedFieldName}";
      var cefaloidField = cefaloidType?.GetField(convertedFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
      if (cefaloidType is not null && cefaloidField is null) {
        if (!cefaloidTypeIsEnum) {
          // search for field by offset
          var cefaloidFields = cefaloidType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
          foreach (var checkCefaloidField in cefaloidFields) {
            if ((int) GetOffsetOf(checkCefaloidField) == fieldSym.offset) {
              cefaloidField = checkCefaloidField;
              break;
            }
          }
        }
        // else wrong type
      }

      var managedOffset = cefaloidField is not null ? (int) GetOffsetOf(cefaloidField) : -1;
      var managedSize = cefaloidField is not null
        ? GetSizeOf(cefaloidField.FieldType)
        : -1;
      var access = isFuncPtr ? "internal" : "public";
      if (cefaloidType is null)
        Console.WriteLine($"  {access} {fieldTypeName} {convertedFieldName}; // {fieldName} @ {fieldSym.offset}, {fieldType.length} bytes");
      else if (cefaloidField is null) {
        Console.WriteLine($"  {access} {fieldTypeName} {convertedFieldName}; // {fieldName} @ {fieldSym.offset}, {fieldType.length} bytes !! MISSING");
      }
      else {
        if (managedOffset == -1)
          Console.WriteLine($"  {access} {cefaloidField.FieldType.Name} {cefaloidField.Name}; // {fieldName} @ {fieldSym.offset}, {fieldType.length} bytes !! UNKNOWN FIELD LOCATION");
        else {
          if (fieldSym.offset == managedOffset && fieldType.length == (ulong) managedSize)
            Console.WriteLine($"  {access} {cefaloidField.FieldType.Name} {cefaloidField.Name}; // {fieldName} @ {managedOffset}, {managedSize} bytes");
          else
            Console.WriteLine($"  {access} {cefaloidField.FieldType.Name} {cefaloidField.Name}; // {fieldName} @ {managedOffset}, {managedSize} bytes !! EXPECTED @ {fieldSym.offset}, {fieldType.length}");
        }
      }
    }
  }

  Console.WriteLine('}');
  if (cefaloidType is not null)
    Console.WriteLine("*/");
  Console.WriteLine();
}

foreach (var (structName, (structSym, fields)) in structsOrEnums)
  GenerateDefinition(structName, structSym, fields);

foreach (var (structName, (structSym, fields)) in extraEnums)
  GenerateDefinition(structName, structSym, fields);

Console.WriteLine("public static unsafe partial class Cef {");
foreach (var (name, sym) in exports.OrderBy(kv => kv.Key)) {
  Console.WriteLine(ResolveFunctionType(sym, 0, "Cef"));
}

Console.WriteLine("}");

return 0; // success
