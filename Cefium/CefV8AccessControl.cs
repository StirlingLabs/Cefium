namespace Cefium;

/// <summary>
/// V8 access control values.
/// <c>cef_v8_accesscontrol_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefV8AccessControl {

  /// <summary>
  /// <c>V8_ACCESS_CONTROL_DEFAULT</c>
  /// </summary>
  Default = 0,

  /// <summary>
  /// <c>V8_ACCESS_CONTROL_ALL_CAN_READ</c>
  /// </summary>
  Read = 1,

  /// <summary>
  /// <c>V8_ACCESS_CONTROL_ALL_CAN_WRITE</c>
  /// </summary>
  Write = 1 << 1,

  /// <summary>
  /// <c>V8_ACCESS_CONTROL_PROHIBITS_OVERWRITING</c>
  /// </summary>
  Overwriting = 1 << 2

}
