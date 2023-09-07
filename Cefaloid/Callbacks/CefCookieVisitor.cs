namespace Cefaloid;

/// <summary>
/// Structure to implement for visiting cookie values. The functions of this
/// structure will always be called on the UI thread.
/// <c>cef_cookie_visitor_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCookieVisitor : ICefRefCountedBase<CefCookieVisitor> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefCookieVisitor() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be called once for each cookie. |count| is the 0-based
  /// index for the current cookie. |total| is the total number of cookies. Set
  /// |deleteCookie| to true (1) to delete the cookie currently being visited.
  /// Return false (0) to stop visiting cookies. This function may never be
  /// called if no cookies are found.
  /// <c>int(CEF_CALLBACK* visit)(struct _cef_cookie_visitor_t* self, const struct _cef_cookie_t* cookie, int count, int total, int* deleteCookie);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCookieVisitor*, CefCookie*, int, int, int*, int> _Visit;

}
