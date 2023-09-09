namespace Cefaloid;

/// <summary>
/// Focus sources.
/// <c>cef_focus_source_t</c>
/// </summary>
[PublicAPI]
public enum CefFocusSource : uint {

  /// <summary>
  /// The source is explicit navigation via the API (LoadURL(), etc).
  /// <c>FOCUS_SOURCE_NAVIGATION</c>
  /// </summary>
  Navigation = 0,

  /// <summary>
  /// The source is a system-generated focus event.
  /// <c>FOCUS_SOURCE_SYSTEM</c>
  /// </summary>
  System = 1

}
