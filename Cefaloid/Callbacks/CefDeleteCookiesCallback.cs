namespace Cefaloid;

/// <summary>
/// Structure to implement to be notified of asynchronous completion via
/// cef_cookie_manager_t::delete_cookies().
/// <c>cef_delete_cookies_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDeleteCookiesCallback : ICefRefCountedBase<CefDeleteCookiesCallback> {

  /// <see cref="CefDeleteCookiesCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDeleteCookiesCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be called upon completion. |num_deleted| will be the
  /// number of cookies that were deleted.
  /// <c>void(CEF_CALLBACK* on_complete)(struct _cef_delete_cookies_callback_t* self, int num_deleted);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDeleteCookiesCallback*, int, void> _OnComplete;

}
