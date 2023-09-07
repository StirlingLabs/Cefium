namespace Cefaloid;

/// <summary>
/// Structure to implement to be notified of asynchronous completion via
/// cef_cookie_manager_t::set_cookie().
/// <c>cef_set_cookie_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSetCookieCallback : ICefRefCountedBase<CefSetCookieCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefSetCookieCallback() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be called upon completion. |success| will be true (1) if
  /// the cookie was set successfully.
  /// <c>void(CEF_CALLBACK* on_complete)(struct _cef_set_cookie_callback_t* self, int success);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSetCookieCallback*, int, void> _OnComplete;

}
