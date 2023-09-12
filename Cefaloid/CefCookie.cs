namespace Cefaloid;

/// <summary>
/// Cookie information.
/// <c>cef_cookie_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCookie {

  /// <summary>
  /// The cookie name.
  /// </summary>
  public CefString Name;

  /// <summary>
  /// The cookie value.
  /// </summary>
  public CefString Value;

  /// <summary>
  /// If |domain| is empty a host cookie will be created instead of a domain
  /// cookie. Domain cookies are stored with a leading "." and are visible to
  /// sub-domains whereas host cookies are not.
  /// </summary>
  public CefString Domain;

  /// <summary>
  /// If |path| is non-empty only URLs at or below the path will get the cookie
  /// value.
  /// </summary>
  public CefString Path;

  /// <summary>
  /// If |secure| is true the cookie will only be sent for HTTPS requests.
  /// </summary>
  private int _Secure;

  /// <inheritdoc cref="_Secure"/>
  public bool Secure {
    get => _Secure != 0;
    set => _Secure = value ? 1 : 0;
  }

  /// <summary>
  /// If |httponly| is true the cookie will only be sent for HTTP requests.
  /// </summary>
  private int _HttpOnly;

  /// <inheritdoc cref="_HttpOnly"/>
  public bool HttpOnly {
    get => _HttpOnly != 0;
    set => _HttpOnly = value ? 1 : 0;
  }

  /// <summary>
  /// The cookie creation date. This is automatically populated by the system on
  /// cookie creation.
  /// </summary>
  public CefBaseTime Creation;

  /// <summary>
  /// The cookie last access date. This is automatically populated by the system
  /// on access.
  /// </summary>
  public CefBaseTime LastAccess;

  /// <summary>
  /// The cookie expiration date is only valid if |has_expires| is true.
  /// </summary>
  private int _HasExpires;

  /// <inheritdoc cref="_HasExpires"/>
  public bool HasExpires {
    get => _HasExpires != 0;
    set => _HasExpires = value ? 1 : 0;
  }

  /// <summary>
  /// The cookie expiration date. This is only valid if |has_expires| is true.
  /// </summary>
  public CefBaseTime Expires;

  /// <summary>
  /// Same site.
  /// </summary>
  public CefCookieSameSite SameSite;

  /// <summary>
  /// Priority.
  /// </summary>
  public CefCookiePriority Priority;

}
