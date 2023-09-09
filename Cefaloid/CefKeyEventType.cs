namespace Cefaloid;

/// <summary>
/// Key event types.
/// <c>cef_key_event_type_t</c>
/// </summary>
[PublicAPI]
public enum CefKeyEventType {

  /// <summary>
  /// Notification that a key transitioned from "up" to "down".
  /// <c>KEYEVENT_RAWKEYDOWN</c>
  /// </summary>
  RawKeyDown = 0,

  /// <summary>
  /// Notification that a key was pressed. This does not necessarily correspond
  /// to a character depending on the key and language. Use KEYEVENT_CHAR for
  /// character input.
  /// <c>KEYEVENT_KEYDOWN</c>
  /// </summary>
  KeyDown,

  /// <summary>
  /// Notification that a key was released.
  /// <c>KEYEVENT_KEYUP</c>
  /// </summary>
  KeyUp,

  /// <summary>
  /// Notification that a character was typed. Use this for text input. Key
  /// down events may generate 0, 1, or more than one character event depending
  /// on the key, locale, and operating system.
  /// <c>KEYEVENT_CHAR</c>
  /// </summary>
  Char

}
