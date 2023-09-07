namespace Cefaloid;

/// <summary>
/// Implement this structure to filter cookies that may be sent or received from
/// resource requests. The functions of this structure will be called on the IO
/// thread unless otherwise indicated.
/// <c>cef_cookie_access_filter_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCookieAccessFilter : ICefRefCountedBase<CefCookieAccessFilter> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefCookieAccessFilter() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called on the IO thread before a resource request is sent. The |browser|
  /// and |frame| values represent the source of the request, and may be NULL
  /// for requests originating from service workers or cef_urlrequest_t.
  /// |request| cannot be modified in this callback. Return true (1) if the
  /// specified cookie can be sent with the request or false (0) otherwise.
  /// <c>int(CEF_CALLBACK* can_send_cookie)(struct _cef_cookie_access_filter_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_request_t* request, const struct _cef_cookie_t* cookie)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCookieAccessFilter*, CefBrowser*, CefFrame*, CefRequest*, CefCookie*, int> _CanSendCookie;

  /// <summary>
  /// Called on the IO thread after a resource response is received. The
  /// |browser| and |frame| values represent the source of the request, and may
  /// be NULL for requests originating from service workers or cef_urlrequest_t.
  /// |request| cannot be modified in this callback. Return true (1) if the
  /// specified cookie returned with the response can be saved or false (0)
  /// otherwise.
  /// <c>int(CEF_CALLBACK* can_save_cookie)(struct _cef_cookie_access_filter_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_request_t* request, struct _cef_response_t* response, const struct _cef_cookie_t* cookie)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCookieAccessFilter*, CefBrowser*, CefFrame*, CefRequest*, CefResponse*, CefCookie*, int> _CanSaveCookie;

}
