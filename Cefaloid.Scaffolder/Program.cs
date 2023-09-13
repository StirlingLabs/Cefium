using System.Diagnostics.CodeAnalysis;
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
using Cefaloid.Scaffolder;
using Dia2Lib;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using Microsoft.DiaSymReader;

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

using var pdbStream = new ReadOnlyFileMemoryMappingComStream(pdbFilePath);

var diaSource = new DiaSourceClass();

diaSource.loadDataFromIStream(pdbStream);

diaSource.openSession(out var session);

session.getEnumTables(out var enumTables);

Dictionary<string, IDiaTable> tables = new();
foreach (IDiaTable table in enumTables) {
  tables[table.name] = table;
}

var syms = tables["Symbols"];

var typedefs = new Dictionary<string, IDiaSymbol11>();
var reverseTypedef = new Dictionary<uint, string>();
var structsOrEnums = new Dictionary<string, (IDiaSymbol11, Dictionary<string, IDiaSymbol11>)>();

foreach (IDiaSymbol11 sym in syms) {
  if (sym is null) break;

  switch ((SymTagEnum) sym.symTag) {
    case SymTagEnum.SymTagTypedef: {
      var symName = sym.name;
      if (symName is null) continue; // skip unnamed for now?

      if (!symName.StartsWith("cef")) continue; // skip non-cef typedefs
      if (symName.Contains("::")) continue; // skip namespaced typedefs

      typedefs[symName] = sym;
      AddStructOrEnum(sym.type as IDiaSymbol11, symName);
      break;
    }
    case SymTagEnum.SymTagEnum:
    case SymTagEnum.SymTagUDT: {
      var symName = sym.name;
      if (symName is null) continue; // skip unnamed for now?

      if (!symName.StartsWith("cef")) continue; // skip non-cef typedefs
      if (symName.Contains("::")) continue; // skip namespaced typedefs

      AddStructOrEnum(sym.type as IDiaSymbol11, null);
      break;
    }
  }
}

void AddStructOrEnum(IDiaSymbol11? sym, string? typedefName) {
  if (sym is null) return;

  if (typedefName is not null)
    reverseTypedef[sym.symIndexId] = typedefName;

  var symName = sym.name;

  if ((SymTagEnum) sym.symTag is SymTagEnum.SymTagTypedef) {
    typedefs[symName] = sym;
    AddStructOrEnum(sym.type as IDiaSymbol11, typedefName);
  }

  if (symName is null) return; // skip unnamed for now?

  sym.findChildren(SymTagEnum.SymTagNull, null, 0, out var children);
  var fields = new Dictionary<string, IDiaSymbol11>();
  foreach (IDiaSymbol11 child in children) {
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
        prevChar = prevChar is >= 'A' and <= 'Z'
          ? sb[i] = char.ToLowerInvariant(sb[i])
          : sb[i];
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
  {"CefBaseRefCounted", "CefRefCountedBase"},
  {"CefStringUtf16", "CefString"},
  {"CefMainArgs", "CefMainArgsForWindows"},
  {"CefWindowInfo", "CefWindowInfoForWindows"},
  {"CefUrlrequestClient", "CefUrlRequestClient"}
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
      return "bcd";
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

string ResolveFunctionType(IDiaSymbol11 func, int pointerDepth) {
  var sb = new StringBuilder();
  var paramCount = func.count;
  var retType = (IDiaSymbol11) func.type;
  var cc = (CV_call_e) func.callingConvention;
  sb.Append(cc switch {
    CV_call_e.NEAR_C => "unsafe delegate * unmanaged[Cdecl]",
    CV_call_e.NEAR_FAST => "unsafe delegate * unmanaged[Fastcall]",
    CV_call_e.NEAR_STD => "unsafe delegate * unmanaged[Stdcall]",
    CV_call_e.THISCALL => "unsafe delegate * unmanaged[Thiscall]",
    CV_call_e.CLRCALL => "unsafe delegate * managed",
    _ => throw new NotImplementedException()
  });
  sb.Append('<');
  func.findChildren(SymTagEnum.SymTagNull, null, 0, out var args);
  var argTypes = new List<string>((int) (paramCount + 1));
  foreach (IDiaSymbol11 arg in args) {
    var argType = (IDiaSymbol11) arg.type;
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

string? ResolveTypeName2(IDiaSymbol11 type, out bool isFuncPtr) {
  isFuncPtr = false;
  var pointerDepth = 0;
  while ((SymTagEnum) type.symTag is SymTagEnum.SymTagPointerType) {
    type = (IDiaSymbol11) type.type;
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
    if (reverseTypedef.TryGetValue(type.symIndexId, out var resolved))
      typeName = resolved;
    typeName = ConvertToPascalCase(typeName, true);
    if (manualTypeNameReplacements.TryGetValue(typeName, out var replacement))
      typeName = replacement;
  }

  if (pointerDepth > 0)
    typeName += new string('*', pointerDepth);

  return typeName;
}

string? ResolveTypeName(IDiaSymbol11 type)
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

var asmLoadCtx = AssemblyLoadContext.Default;
using var reflectionScope = asmLoadCtx.EnterContextualReflection();

var cefaloidPath = Path.Combine(Environment.CurrentDirectory, "Cefaloid.dll");
Assembly? cefaloidAsm = null;
if (File.Exists(cefaloidPath)) {
  cefaloidAsm = asmLoadCtx.LoadFromAssemblyPath(cefaloidPath);
  Console.WriteLine("// validating against a build of Cefaloid");
}

Console.WriteLine("namespace Cefaloid;");

foreach (var (structName, (structSym, fields)) in structsOrEnums) {
  var name = structName;

  if (reverseTypedef.TryGetValue(structSym.symIndexId, out var resolved))
    name = resolved;

  if (structSym.constType != 0) throw new NotImplementedException();
  if (structSym.isStatic != 0) throw new NotImplementedException();

  var isEnum = (SymTagEnum) structSym.symTag is SymTagEnum.SymTagEnum;
  var convertedName = ConvertToPascalCase(name, true);
  if (manualTypeNameReplacements.TryGetValue(convertedName, out var replacementName))
    convertedName = replacementName;
  string? maybeUnderlyingType = null;
  if (isEnum) {
    var underlyingType = structSym.baseType;
    maybeUnderlyingType = $" : {GetBasicTypeName(underlyingType)}";
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
      if (cefaloidTypeSize != (int) structSym.length)
        Console.WriteLine($"/* already defined !! WRONG SIZE {cefaloidTypeSize}, should be {structSym.length}");
      else
        Console.WriteLine("/* already defined");
    }
  }

  if (!isEnum)
    Console.WriteLine($"[PublicAPI, StructLayout(LayoutKind.Sequential, Size={structSym.length})]");
  Console.WriteLine($"{(isEnum ? "public enum" : "pubic struct")} {convertedName}{maybeUnderlyingType} {{ // {name}");

  Dictionary<string, object?>? cefaloidEnum = null;
  if (cefaloidTypeIsEnum && isEnum) {
    cefaloidEnum = new();
    foreach (var cefaloidEnumValue in Enum.GetValues(cefaloidType!)) {
      var cefaloidEnumName = Enum.GetName(cefaloidType!, cefaloidEnumValue);
      cefaloidEnum[cefaloidEnumName!] = cefaloidEnumValue;
    }
  }

  foreach (var (fieldName, fieldSym) in fields) {
    var fieldType = (IDiaSymbol11) fieldSym.type;

    var fieldTypeName = ResolveTypeName2(fieldType, out var isFuncPtr);

    var convertedFieldName = ConvertToPascalCase(fieldName, false);
    foreach (var (match, replacement) in manualTextReplacements)
      convertedName = convertedName.Replace(match, replacement);

    if (isEnum) {
      object? managedValue = null;
      cefaloidEnum?.TryGetValue(convertedFieldName, out managedValue);
      var valueStr = fieldSym.value.ToString();
      var managedValueStr = managedValue?.ToString();
      var isMissing = cefaloidType is not null && managedValue is null;
      if (isMissing) {
        // search for field by value
        var cefaloidValues = Enum.GetValuesAsUnderlyingType(cefaloidType!);
        var cefaloidEnumValues = cefaloidValues.Cast<object>()
          .Select(v => (Name: Enum.GetName(cefaloidType!, v), Value: v));
        foreach (var (enumName, enumValue) in cefaloidEnumValues) {
          var enumValueStr = enumValue.ToString();
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
          Console.WriteLine($"  {access} {fieldTypeName} {convertedFieldName}; // {fieldName} @ {fieldSym.offset}, {fieldType.length} bytes !! UNKNOWN FIELD LOCATION");
        else {
          if (fieldSym.offset == managedOffset && fieldType.length == (ulong) managedSize)
            Console.WriteLine($"  {access} {fieldTypeName} {convertedFieldName}; // {fieldName} @ {managedOffset}, {managedSize} bytes");
          else
            Console.WriteLine($"  {access} {fieldTypeName} {convertedFieldName}; // {fieldName} @ {managedOffset}, {managedSize} bytes !! EXPECTED @ {fieldSym.offset}, {fieldType.length}");
        }
      }
    }
  }

  Console.WriteLine('}');
  if (cefaloidType is not null)
    Console.WriteLine("*/");
  Console.WriteLine();
}

// TODO: use reflection to load the dll and get the types
// compare against the pdb

return 0; // success
