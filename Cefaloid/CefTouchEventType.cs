namespace Cefaloid;

/// <summary>
/// Touch points states types.
/// <c>cef_touch_event_type_t</c>
/// </summary>
[PublicAPI]
public enum CefTouchEventType {

  /// <summary>
  /// <c>CEF_TET_RELEASED</c>
  /// </summary>
  Released = 0,

  /// <summary>
  /// <c>CEF_TET_PRESSED</c>
  /// </summary>
  Pressed,

  /// <summary>
  /// <c>CEF_TET_MOVED</c>
  /// </summary>
  Moved,

  /// <summary>
  /// <c>CEF_TET_CANCELLED</c>
  /// </summary>
  Cancelled

}