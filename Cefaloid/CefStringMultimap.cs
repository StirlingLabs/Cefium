namespace Cefaloid;

/// <summary>
/// CEF string multimaps are a set of key/value string pairs.
/// More than one value can be assigned to a single key.
/// <c>cef_string_multimap_t</c>
/// </summary>
/// <remarks>
/// NOTE: Do not attempt to copy or sizeof this structure,
/// it is opaque and should only be passed by reference or pointer.
/// </remarks>
/// <seealso cref="CefString"/>
/// <seealso cref="CefStringMultimapExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefStringMultimap {

  /// <summary>
  /// Allocate a new string multimap.
  /// <c>CEF_EXPORT cef_string_multimap_t cef_string_multimap_alloc(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_alloc", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefStringMultimap* Alloc();

  /// <summary>
  /// Allocate a new string multimap.
  /// <c>CEF_EXPORT size_t cef_string_multimap_size(cef_string_multimap_t map);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_size", CallingConvention = CallingConvention.Cdecl)]
  internal static extern nuint _Size(ref CefStringMultimap self);

  /// <summary>
  /// Return the number of values with the specified key.
  /// <c>CEF_EXPORT size_t cef_string_multimap_find_count(cef_string_multimap_t map, const cef_string_t* key);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_find_count", CallingConvention = CallingConvention.Cdecl)]
  internal static extern nuint _FindCount(ref CefStringMultimap self, ref CefString key);

  /// <summary>
  /// Return the value_index-th value with the specified key.
  /// <c>CEF_EXPORT int cef_string_multimap_enumerate(cef_string_multimap_t map, const cef_string_t* key, size_t value_index, cef_string_t* value);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_enumerate", CallingConvention = CallingConvention.Cdecl)]
  internal static extern int _Enumerate(ref CefStringMultimap self, ref CefString key, nuint valueIndex, ref CefString value);

  /// <summary>
  /// Return the key at the specified zero-based string multimap index.
  /// <c>CEF_EXPORT int cef_string_multimap_key(cef_string_multimap_t map, size_t index, cef_string_t* key);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_key", CallingConvention = CallingConvention.Cdecl)]
  internal static extern int _Key(ref CefStringMultimap self, nuint index, ref CefString key);

  /// <summary>
  /// Return the value at the specified zero-based string multimap index.
  /// <c>CEF_EXPORT int cef_string_multimap_value(cef_string_multimap_t map, size_t index, cef_string_t* value);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_value", CallingConvention = CallingConvention.Cdecl)]
  internal static extern int _Value(ref CefStringMultimap self, nuint index, ref CefString value);

  /// <summary>
  /// Append a new key/value pair at the end of the string multimap.
  /// <c>CEF_EXPORT int cef_string_multimap_append(cef_string_multimap_t map, const cef_string_t* key, const cef_string_t* value);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_append", CallingConvention = CallingConvention.Cdecl)]
  internal static extern void _Append(ref CefStringMultimap self, ref CefString key, ref CefString value);

  /// <summary>
  /// Clear the string multimap.
  /// <c>CEF_EXPORT void cef_string_multimap_clear(cef_string_multimap_t map);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_clear", CallingConvention = CallingConvention.Cdecl)]
  internal static extern void _Clear(ref CefStringMultimap self);

  /// <summary>
  /// Free the string multimap.
  /// <c>CEF_EXPORT void cef_string_multimap_free(cef_string_multimap_t map);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_multimap_free", CallingConvention = CallingConvention.Cdecl)]
  internal static extern void _Free(ref CefStringMultimap self);

}
