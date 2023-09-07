namespace Cefaloid;

/// <summary>
/// CEF string maps are a set of key/value string pairs.
/// </summary>
/// <seealso cref="CefString"/>
/// <seealso cref="CefStringListExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefStringList {

  /// <summary>
  /// Allocate a new string map.
  /// <c>CEF_EXPORT cef_string_list_t cef_string_list_alloc(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_list_alloc", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefStringList* Alloc();

  /// <summary>
  /// Return the number of elements in the string list.
  /// <c>CEF_EXPORT size_t cef_string_list_size(cef_string_list_t list);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_list_size", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe nuint _Size(CefStringList* self);

  /// <summary>
  /// Retrieve the value at the specified zero-based string list index. Returns
  /// true (1) if the value was successfully retrieved.
  /// <c>CEF_EXPORT int cef_string_list_value(cef_string_list_t list, size_t index, cef_string_t* value);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_list_value", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefString* _Value(CefStringList* self, nuint index);

  /// <summary>
  /// Append a new value at the end of the string list.
  /// <c>CEF_EXPORT void cef_string_list_append(cef_string_list_t list, const cef_string_t* value);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_list_append", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe void _Append(CefStringList* self, CefString* value);

  /// <summary>
  /// Clear the string list.
  /// <c>CEF_EXPORT void cef_string_list_clear(cef_string_list_t list);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_list_clear", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe void _Clear(CefStringList* self);

  /// <summary>
  /// Free the string list.
  /// <c>CEF_EXPORT void cef_string_list_free(cef_string_list_t list);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_list_free", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe void _Free(CefStringList* self);

  /// <summary>
  /// Creates a copy of an existing string list.
  /// <c>CEF_EXPORT cef_string_list_t cef_string_list_copy(cef_string_list_t list);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_list_copy", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefStringList* _Copy(CefStringList* self);

}
