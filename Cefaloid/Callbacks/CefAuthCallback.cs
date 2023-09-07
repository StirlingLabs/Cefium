namespace Cefaloid;

/// <summary>
/// Callback structure used for asynchronous continuation of authentication
/// requests.
/// <c>cef_auth_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefAuthCallback : ICefRefCountedBase<CefAuthCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefAuthCallback() {}

  /// <summary>
  /// Base structure.
  /// </summary>H
  public CefRefCountedBase Base;

  /// <summary>
  /// Continue the authentication request.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_auth_callback_t* self, const cef_string_t* username, const cef_string_t* password)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAuthCallback*, CefString*, CefString*, void> _Continue;

  /// <summary>
  /// Cancel the authentication request.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_auth_callback_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAuthCallback*, void> _Cancel;

}
