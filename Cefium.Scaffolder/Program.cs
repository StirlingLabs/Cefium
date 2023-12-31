﻿using System.Buffers;
using System.Collections.Concurrent;
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
using Cefium.Shared;
using Dia2Lib;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using Microsoft.DiaSymReader;
using CallingConvention = Cefium.Shared.CallingConvention;
using ImageFileMachine = Cefium.Shared.ImageFileMachine;

const string CefVersion = "116.0.21";
const string CefVersionMetadata = "g9c7dc32";
const string ChromiumVersion = "116.0.5845.181";

string localAppDataPathBase = Environment.GetEnvironmentVariable("CEFALOID_LOCALAPPDATA")
  ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create), "Cefium");

string localAppDataPath = Path.Combine(localAppDataPathBase, CefVersion);

var pdbUrl = $"https://cef-builds.spotifycdn.com/cef_binary_{CefVersion}%2B{CefVersionMetadata}%2Bchromium-{ChromiumVersion}_windows64_release_symbols.tar.bz2";

var dllFilePath = Path.Combine(localAppDataPath, "libcef.dll");

if (!File.Exists(dllFilePath)) {
  Console.Error.WriteLine("libcef.dll is missing, are you sure Cefium was installed?");
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
//IDiaEnumInjectedSources injectedSrcs = null;
foreach (object maybeTable in enumTables) {
  /*if (maybeTable is IDiaEnumInjectedSources srcs)
    injectedSrcs = srcs;
  else*/
  if (maybeTable is IDiaTable table) {
    tables[table.name] = table;
    Console.WriteLine($"// TABLE {table.name}");
  }
}

/* empty
session.getExports(out var exports);
foreach (IDiaSymbol sym in exports)
  Console.WriteLine($"// EXPORT {(SymTagEnum) sym.symTag} {sym.name}");
*/
/*if (injectedSrcs is not null) {
  void DumpInjectedSources() {
    foreach (var srcInjX in injectedSrcs) {
      var srcInj = (Cefium.Scaffolder.Dia2.IDiaInjectedSource) srcInjX;
      if (srcInj is null) break;

      var srcName = srcInj.fileName;
      var srcVirtName = srcInj.virtualFilename;

      var size = srcInj.length;
      var buffer = ArrayPool<byte>.Shared.Rent(checked((int) size));
      srcInj.get_source(checked((uint) size), out var wrote, ref buffer[0]);
      var srcContent = new ReadOnlySpan<byte>(buffer, 0, (int) wrote);
      var srcContentStr = Encoding.UTF8.GetString(srcContent);
    }
  }

  DumpInjectedSources();
}
*/

var syms = tables["Symbols"];

var typedefs = new Dictionary<string, IDiaSymbol>();
var reverseTypedef = new Dictionary<uint, string>();

// using concurrent dictionary here only so the enumerator will continue
// even while the collection is modified
var structsOrEnums = new ConcurrentDictionary<string, (IDiaSymbol, Dictionary<string, IDiaSymbol>)>(1, 0);
var generationQueue = new ConcurrentQueue<string>();

//var extraEnums = new Dictionary<string, (IDiaSymbol, Dictionary<string, IDiaSymbol>)>();
//var extraStructs = new Dictionary<string, (IDiaSymbol, Dictionary<string, IDiaSymbol>)>();

var exports = new Dictionary<string, IDiaSymbol>();
var exportSignatures = new Dictionary<string, string>();

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

  if (structsOrEnums.ContainsKey(symName)) return; // already added

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
  generationQueue.Enqueue(symName);
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
  {"CefBasetime", "CefBaseTime"},
  {"CefUrlparts", "CefUrlParts"}
};

Dictionary<string, string> manualFieldNameReplacements = new() {
};

List<(string Match, string Replacement)> manualTextReplacements = new() {
  ("Byindex", "ByIndex"),
  ("Byname", "ByName"),
  ("Bykey", "ByKey"),
  ("Textfield", "TextField"),
  ("Osmodal", "OsModal"),
  ("Doublet", "Double"),
  ("Timet", "Time"),
  ("Userfree", "UserFree"),
  ("Jsonand", "JsonAnd"),
  ("Crlsets", "CrlSets"),
  ("Vlog", "VLog"),
  ("Basetime", "BaseTime"),
  ("Urlparts", "UrlParts"),
  ("Uridecode", "UriDecode"),
  ("Uriencode", "UriEncode"),
};


// TODO: add MethodInfo parameter and validate while resolving
// TODO: when on .NET8, add Type parameter for function pointer types and validate while resolving
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
    var argStrs = new List<string>((int) paramCount);
    var argIndex = 0;
    foreach (IDiaSymbol arg in args) {
      var argType = arg.type;
      var argStr = ResolveTypeName(argType);
      if (argStr is null)
        throw new NotImplementedException();

      // TODO: look up parameter names, fix casing
      argStr += $" arg{argIndex++}";
      argStrs.Add(argStr);
    }

    sb.AppendJoin(',', argStrs);
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
      CallingConvention.NearC => "delegate * unmanaged[Cdecl]",
      //CallingConvention.NearFast => "delegate * unmanaged[Fastcall]",
      CallingConvention.NearStd => "delegate * unmanaged[Stdcall]",
      //CallingConvention.ThisCall => "delegate * unmanaged[Thiscall]",
      //CallingConvention.ClrCall => "delegate * managed",
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
    //var isEnum = (SymTagEnum) type.symTag is SymTagEnum.SymTagEnum;

    if (reverseTypedef.TryGetValue(type.symIndexId, out var resolved))
      typeName = resolved;

    if (!structsOrEnums.ContainsKey(typeName)) {
      type.findChildren(SymTagEnum.SymTagNull, null, 0, out var enumChildren);
      var children = new Dictionary<string, IDiaSymbol>();
      foreach (IDiaSymbol child in enumChildren) {
        var childName = child.name;
        if (childName == null) continue; // skip unnamed for now?

        children.Add(childName, child);
      }

      structsOrEnums[typeName] = (type, children);
      generationQueue.Enqueue(typeName);
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

foreach (var (name, sym) in exports.OrderBy(kv => kv.Key))
  exportSignatures[name] = ResolveFunctionType(sym, 0, "Cef");

var asmLoadCtx = AssemblyLoadContext.Default;
using var reflectionScope = asmLoadCtx.EnterContextualReflection();

var cefaloidPath = Path.Combine(Environment.CurrentDirectory, "Cefium.dll");
Assembly? cefaloidAsm = null;
if (File.Exists(cefaloidPath)) {
  cefaloidAsm = asmLoadCtx.LoadFromAssemblyPath(cefaloidPath);
  Console.WriteLine("// validating against a build of Cefium");
}

Console.WriteLine("using System;");
Console.WriteLine("using System.Runtime.CompilerServices;");
Console.WriteLine("using System.Runtime.InteropServices;");
Console.WriteLine("using JetBrains.Annotations;");
Console.WriteLine();
Console.WriteLine("namespace Cefium;");
Console.WriteLine();

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
  foreach (var (match, replacement) in manualTextReplacements)
    convertedName = convertedName.Replace(match, replacement);

  string? maybeUnderlyingType = null;
  Type? maybeClrType = null;
  if (isEnum) {
    var underlyingType = diaSymbol.baseType;
    maybeUnderlyingType = $" : {GetBasicTypeName(underlyingType)}";
    maybeClrType = GetBasicClrType(underlyingType);
  }

  var cefaloidType = cefaloidAsm?.GetType($"Cefium.{convertedName}", false, true);

  var cefaloidTypeSize = 0;
  var cefaloidTypeIsEnum = false;
  if (cefaloidType is not null) {
    cefaloidTypeIsEnum = cefaloidType.IsEnum;
    cefaloidTypeSize = cefaloidType.SizeOf();
    if (isEnum != cefaloidTypeIsEnum)
      Console.WriteLine("/* already defined !! WRONG TYPE");
    else {
      if (cefaloidTypeSize != (int) diaSymbol.length)
        Console.WriteLine($"/* already defined !! WRONG SIZE {cefaloidTypeSize}, should be {diaSymbol.length}");
      else
        Console.WriteLine("/* already defined");
    }
  }

  // TODO: instead of emitting '{' immediately, check if we need to do inheritance
  // e.g. if there's a 'base' field of cef_base_ref_counted_t, apply ICefRefCountedBase<T>

  // TODO: handle emitting a special case default ctor
  // e.g. [Obsolete(DoNotConstructDirectly, true)] public T() {}

  // TODO: doc comments
  if (!isEnum)
    Console.WriteLine($"[PublicAPI, StructLayout(LayoutKind.Sequential, Size={diaSymbol.length})]");
  if (cefaloidType is not null)
    Console.WriteLine($"{(isEnum ? "public enum" : "public struct")} {cefaloidType.Name}{maybeUnderlyingType} {{ // {name}");
  else
    Console.WriteLine($"{(isEnum ? "public enum" : "public struct")} {convertedName}{maybeUnderlyingType} {{ // {name}");

  Dictionary<string, object?>? cefaloidEnum = null;
  if (cefaloidTypeIsEnum && isEnum) {
    cefaloidEnum = new();
    var underlyingType = cefaloidType!.GetEnumUnderlyingType();
    foreach (var cefaloidEnumValue in Enum.GetValues(cefaloidType)) {
      var cefaloidEnumName = Enum.GetName(cefaloidType!, cefaloidEnumValue);
      cefaloidEnum[cefaloidEnumName!] = CastToType(cefaloidEnumValue, underlyingType);
    }
  }

  if (cefaloidType is not null && !cefaloidTypeIsEnum) {
    var publicStaticMethods = cefaloidType
      .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

    foreach (var method in publicStaticMethods) {
      /*// ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
      var isExtern = (method.MethodImplementationFlags
        & MethodImplAttributes.InternalCall) != 0;

      if (!isExtern) continue;
      */

      var dllImport = method.GetCustomAttribute<DllImportAttribute>();

      if (dllImport is null) continue;

      var entryPoint = dllImport.EntryPoint;

      if (entryPoint is null) continue;

      imported.Add(entryPoint);

      // TODO: write and validate imported function signature
      Console.WriteLine($"// TODO: imports {entryPoint} as {method.Name}");
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
          foreach (var checkCefiumField in cefaloidFields) {
            if ((int) checkCefiumField.FieldOffset() == fieldSym.offset) {
              cefaloidField = checkCefiumField;
              break;
            }
          }
        }
        // else wrong type
      }

      var managedOffset = cefaloidField is not null ? (int) cefaloidField.FieldOffset() : -1;
      var managedSize = cefaloidField is not null
        ? cefaloidField.FieldType.SizeOf()
        : -1;
      var access = isFuncPtr ? "internal" : "public";

      if (fieldTypeName!.Contains('*'))
        fieldTypeName = "unsafe " + fieldTypeName;

      if (cefaloidType is null)
        Console.WriteLine($"  {access} {fieldTypeName} {convertedFieldName}; // {fieldName} @ {fieldSym.offset}, {fieldType.length} bytes");
      else if (cefaloidField is null) {
        Console.WriteLine($"  {access} {fieldTypeName} {convertedFieldName}; // {fieldName} @ {fieldSym.offset}, {fieldType.length} bytes !! MISSING");
      }
      else {
#if NET8_0_OR_GREATER
        if (managedOffset == -1)
          Console.WriteLine($"  {access} {cefaloidField.FieldType.Name} {cefaloidField.Name}; // {fieldName} @ {fieldSym.offset}, {fieldType.length} bytes !! UNKNOWN FIELD LOCATION");
        else {
          if (fieldSym.offset == managedOffset && fieldType.length == (ulong) managedSize)
            Console.WriteLine($"  {access} {cefaloidField.FieldType.Name} {cefaloidField.Name}; // {fieldName} @ {managedOffset}, {managedSize} bytes");
          else
            Console.WriteLine($"  {access} {cefaloidField.FieldType.Name} {cefaloidField.Name}; // {fieldName} @ {managedOffset}, {managedSize} bytes !! EXPECTED @ {fieldSym.offset}, {fieldType.length}");
        }
#else
        var cefaloidFieldTypeName = cefaloidField.FieldType.Name;

        if (cefaloidFieldTypeName.Contains('*'))
          cefaloidFieldTypeName = "unsafe " + cefaloidFieldTypeName;

        if (managedOffset == -1)
          Console.WriteLine($"  {access} {(isFuncPtr ? fieldTypeName : cefaloidFieldTypeName)} {cefaloidField.Name}; // {fieldName} @ {fieldSym.offset}, {fieldType.length} bytes !! UNKNOWN FIELD LOCATION");
        else {
          if (fieldSym.offset == managedOffset && fieldType.length == (ulong) managedSize)
            Console.WriteLine($"  {access} {(isFuncPtr ? fieldTypeName : cefaloidFieldTypeName)} {cefaloidField.Name}; // {fieldName} @ {managedOffset}, {managedSize} bytes");
          else
            Console.WriteLine($"  {access} {(isFuncPtr ? fieldTypeName : cefaloidFieldTypeName)} {cefaloidField.Name}; // {fieldName} @ {managedOffset}, {managedSize} bytes !! EXPECTED @ {fieldSym.offset}, {fieldType.length}");
        }
#endif
      }
    }
  }

  Console.WriteLine('}');
  if (cefaloidType is not null)
    Console.WriteLine("*/");
  Console.WriteLine();
}

var generated = new HashSet<string>();
while (generationQueue.TryDequeue(out var name)) {
  if (!structsOrEnums.TryGetValue(name, out var structOrEnum))
    throw new NotImplementedException();

  var uniqueName = name;
  if (reverseTypedef.TryGetValue(structOrEnum.Item1.symIndexId, out var typedefName))
    uniqueName = typedefName;
  if (!generated.Add(uniqueName)) continue;

  var (sym, fields) = structOrEnum;
  GenerateDefinition(name, sym, fields);
}

Console.WriteLine("public static unsafe partial class Cef {");

foreach (var (name, signature) in exportSignatures.OrderBy(kv => kv.Key)) {
  if (imported.Contains(name)) continue;

  Console.WriteLine(signature);
}

Console.WriteLine("}");

return 0; // success
