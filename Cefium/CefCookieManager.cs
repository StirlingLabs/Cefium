namespace Cefium;

/// <summary>
/// Structure used for managing cookies. The functions of this structure may be
/// called on any thread unless otherwise indicated.
/// <c>cef_cookie_manager_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCookieManager : ICefRefCountedBase<CefCookieManager> {

  /// <inheritdoc cref="CefCookieManager"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefCookieManager() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the global cookie manager. By default data will be stored at
  /// cef_settings_t.cache_path if specified or in memory otherwise. If |callback|
  /// is non-NULL it will be executed asynchronously on the UI thread after the
  /// manager's storage has been initialized. Using this function is equivalent to
  /// calling cef_request_context_t::cef_request_context_get_global_context()->Get
  /// DefaultCookieManager().
  /// <c>CEF_EXPORT cef_cookie_manager_t* cef_cookie_manager_get_global_manager(struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_cookie_manager_get_global_manager", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefCookieManager* GetGlobalManager(CefCompletionCallback* callback);

  /// <summary>
  /// Visit all cookies on the UI thread. The returned cookies are ordered by
  /// longest path, then by earliest creation date. Returns false (0) if cookies
  /// cannot be accessed.
  /// <c>int(CEF_CALLBACK* visit_all_cookies)(struct _cef_cookie_manager_t* self, struct _cef_cookie_visitor_t* visitor);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCookieManager*, CefCookieVisitor*, int> _VisitAllCookies;

  /// <summary>
  /// Visit a subset of cookies on the UI thread. The results are filtered by
  /// the given url scheme, host, domain and path. If |includeHttpOnly| is true
  /// (1) HTTP-only cookies will also be included in the results. The returned
  /// cookies are ordered by longest path, then by earliest creation date.
  /// Returns false (0) if cookies cannot be accessed.
  /// <c>int(CEF_CALLBACK* visit_url_cookies)(struct _cef_cookie_manager_t* self, const cef_string_t* url, int includeHttpOnly, struct _cef_cookie_visitor_t* visitor);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCookieManager*, CefString*, int, CefCookieVisitor*, int> _VisitUrlCookies;

  /// <summary>
  /// Sets a cookie given a valid URL and explicit user-provided cookie
  /// attributes. This function expects each attribute to be well-formed. It
  /// will check for disallowed characters (e.g. the ';' character is disallowed
  /// within the cookie value attribute) and fail without setting the cookie if
  /// such characters are found. If |callback| is non-NULL it will be executed
  /// asnychronously on the UI thread after the cookie has been set. Returns
  /// false (0) if an invalid URL is specified or if cookies cannot be accessed.
  /// <c>int(CEF_CALLBACK* set_cookie)(struct _cef_cookie_manager_t* self, const cef_string_t* url, const struct _cef_cookie_t* cookie, struct _cef_set_cookie_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCookieManager*, CefString*, CefCookie*, CefSetCookieCallback*, int> _SetCookie;

  /// <summary>
  /// Delete all cookies that match the specified parameters. If both |url| and
  /// |cookie_name| values are specified all host and domain cookies matching
  /// both will be deleted. If only |url| is specified all host cookies (but not
  /// domain cookies) irrespective of path will be deleted. If |url| is NULL all
  /// cookies for all hosts and domains will be deleted. If |callback| is non-
  /// NULL it will be executed asnychronously on the UI thread after the cookies
  /// have been deleted. Returns false (0) if a non-NULL invalid URL is
  /// specified or if cookies cannot be accessed. Cookies can alternately be
  /// deleted using the Visit*Cookies() functions.
  /// <c>int(CEF_CALLBACK* delete_cookies)(struct _cef_cookie_manager_t* self, const cef_string_t* url, const cef_string_t* cookie_name, struct _cef_delete_cookies_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCookieManager*, CefString*, CefString*, CefDeleteCookiesCallback*, int> _DeleteCookies;

  /// <summary>
  /// Flush the backing store (if any) to disk. If |callback| is non-NULL it
  /// will be executed asnychronously on the UI thread after the flush is
  /// complete. Returns false (0) if cookies cannot be accessed.
  /// <c>int(CEF_CALLBACK* flush_store)(struct _cef_cookie_manager_t* self, struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCookieManager*, CefCompletionCallback*, int> _FlushStore;

}
