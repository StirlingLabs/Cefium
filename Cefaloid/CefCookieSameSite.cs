namespace Cefaloid;

/// <summary>
/// Cookie same site values.
/// <c>cef_cookie_same_site_t</c>
/// </summary>
[PublicAPI]
public enum CefCookieSameSite {

  /// <summary>
  /// <c>CEF_COOKIE_SAME_SITE_UNSPECIFIED</c>
  /// </summary>
  Unspecified,

  /// <summary>
  /// <c>CEF_COOKIE_SAME_SITE_NO_RESTRICTION</c>
  /// </summary>
  NoRestriction,

  /// <summary>
  /// <c>CEF_COOKIE_SAME_SITE_LAX_MODE</c>
  /// </summary>
  LaxMode,

  /// <summary>
  /// <c>CEF_COOKIE_SAME_SITE_STRICT_MODE</c>
  /// </summary>
  StrictMode,

}
