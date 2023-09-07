namespace Cefaloid;

/// <summary>
/// CEF string maps are a set of key/value string pairs.
/// <c>cef_string_map_t</c>
/// </summary>
/// <seealso cref="CefString"/>
/// <seealso cref="CefStringMapExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefStringMap {

  /// <summary>
  /// Allocate a new string map.
  /// <c>CEF_EXPORT cef_string_map_t cef_string_map_alloc(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_map_alloc", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefStringMap* Alloc();

  /// <summary>
  /// Return the number of elements in the string map.
  /// <c>CEF_EXPORT size_t cef_string_map_size(cef_string_map_t map);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_map_size", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _Size(CefStringMap* map);

  /// <summary>
  /// Return the value assigned to the specified key.
  /// <c>CEF_EXPORT int cef_string_map_find(cef_string_map_t map, const cef_string_t* key, cef_string_t* value);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_map_find", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _Find(CefStringMap* map, CefString* key, CefString* value);

  /// <summary>
  /// Return the key at the specified zero-based string map index.
  /// <c>CEF_EXPORT int cef_string_map_key(cef_string_map_t map, size_t index, cef_string_t* key);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_map_key", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _Key(CefStringMap* map, int index, CefString* key);

  /// <summary>
  /// Return the value at the specified zero-based string map index.
  /// <c>CEF_EXPORT int cef_string_map_value(cef_string_map_t map, size_t index, cef_string_t* value);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_map_value", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _Value(CefStringMap* map, int index, CefString* value);

  /// <summary>
  /// Append a new key/value pair at the end of the string map.
  /// <c>CEF_EXPORT int cef_string_map_append(cef_string_map_t map, const cef_string_t* key, const cef_string_t* value);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_map_append", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _Append(CefStringMap* map, CefString* key, CefString* value);

  /// <summary>
  /// Clear the string map.
  /// <c>CEF_EXPORT void cef_string_map_clear(cef_string_map_t map);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_map_clear", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe void _Clear(CefStringMap* map);

  /// <summary>
  /// Free the string map.
  /// <c>CEF_EXPORT void cef_string_map_free(cef_string_map_t map);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_map_free", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe void _Free(CefStringMap* map);

}
