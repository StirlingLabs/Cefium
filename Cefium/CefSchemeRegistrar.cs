namespace Cefium;

/// <summary>
/// Structure that manages custom scheme registrations.
/// <c>cef_scheme_registrar_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSchemeRegistrar {

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefScopedBase Base;

  /// <summary>
  /// Register a custom scheme. This function should not be called for the
  /// built-in HTTP, HTTPS, FILE, FTP, ABOUT and DATA schemes.
  ///
  /// See cef_scheme_options_t for possible values for |options|.
  ///
  /// This function may be called on any thread. It should only be called once
  /// per unique |scheme_name| value. If |scheme_name| is already registered or
  /// if an error occurs this function will return false (0).
  /// <c>int(CEF_CALLBACK* add_custom_scheme)(struct _cef_scheme_registrar_t* self, const cef_string_t* scheme_name, int options);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSchemeRegistrar*, CefString*, CefSchemeOptions, int> _AddCustomScheme;

}
