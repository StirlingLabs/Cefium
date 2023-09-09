namespace Cefaloid;

/// <summary>
/// Cookie priority values.
/// <c>cef_cookie_priority_t</c>
/// </summary>
[PublicAPI]
public enum CefCookiePriority {

  /// <summary>
  /// <c>CEF_COOKIE_PRIORITY_LOW</c>
  /// </summary>
  Low = -1,

  /// <summary>
  /// <c>CEF_COOKIE_PRIORITY_MEDIUM</c>
  /// </summary>
  Medium = 0,

  /// <summary>
  /// <c>CEF_COOKIE_PRIORITY_HIGH</c>
  /// </summary>
  High = 1,

}
