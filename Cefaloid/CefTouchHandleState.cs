namespace Cefaloid;

/// <summary>
/// Values indicating what state of the touch handle is set.
/// <c>cef_touch_handle_state_t</c>
/// </summary>
[PublicAPI]
public enum CefTouchHandleState {

  /// <summary>
  /// <c>CEF_THS_FLAG_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// <c>CEF_THS_FLAG_ENABLED</c>
  /// </summary>
  Enabled = 1 << 0,

  /// <summary>
  /// <c>CEF_THS_FLAG_ORIENTATION</c>
  /// </summary>
  Orientation = 1 << 1,

  /// <summary>
  /// <c>CEF_THS_FLAG_ORIGIN</c>
  /// </summary>
  Origin = 1 << 2,

  /// <summary>
  /// <c>CEF_THS_FLAG_ALPHA</c>
  /// </summary>
  Alpha = 1 << 3,

}