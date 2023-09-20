namespace Cefium;

/// <summary>
/// Supported event bit flags.
/// <c>cef_event_flags_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefEventFlags : uint {

  /// <summary>
  /// <c>EVENTFLAG_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// <c>EVENTFLAG_CAPS_LOCK_ON</c>
  /// </summary>
  CapsLockOn = 1 << 0,

  /// <summary>
  /// <c>EVENTFLAG_SHIFT_DOWN</c>
  /// </summary>
  ShiftDown = 1 << 1,

  /// <summary>
  /// <c>EVENTFLAG_CONTROL_DOWN</c>
  /// </summary>
  ControlDown = 1 << 2,

  /// <summary>
  /// <c>EVENTFLAG_ALT_DOWN</c>
  /// </summary>
  AltDown = 1 << 3,

  /// <summary>
  /// <c>EVENTFLAG_LEFT_MOUSE_BUTTON</c>
  /// </summary>
  LeftMouseButton = 1 << 4,

  /// <summary>
  /// <c>EVENTFLAG_MIDDLE_MOUSE_BUTTON</c>
  /// </summary>
  MiddleMouseButton = 1 << 5,

  /// <summary>
  /// <c>EVENTFLAG_RIGHT_MOUSE_BUTTON</c>
  /// </summary>
  RightMouseButton = 1 << 6,

  /// <summary>
  /// Mac OS-X command key.
  /// <c>EVENTFLAG_COMMAND_DOWN</c>
  /// </summary>
  CommandDown = 1 << 7,

  /// <summary>
  /// <c>EVENTFLAG_NUM_LOCK_ON</c>
  /// </summary>
  NumLockOn = 1 << 8,

  /// <summary>
  /// <c>EVENTFLAG_IS_KEY_PAD</c>
  /// </summary>
  IsKeyPad = 1 << 9,

  /// <summary>
  /// <c>EVENTFLAG_IS_LEFT</c>
  /// </summary>
  IsLeft = 1 << 10,

  /// <summary>
  /// <c>EVENTFLAG_IS_RIGHT</c>
  /// </summary>
  IsRight = 1 << 11,

  /// <summary>
  /// <c>EVENTFLAG_ALTGR_DOWN</c>
  /// </summary>
  AltgrDown = 1 << 12,

  /// <summary>
  /// <c>EVENTFLAG_IS_REPEAT</c>
  /// </summary>
  IsRepeat = 1 << 13,

}
