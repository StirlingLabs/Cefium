namespace Cefium;

/// <summary>
/// Structure representing mouse event information.
/// <c>cef_mouse_event_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMouseEvent {

  ///
  /// X coordinate relative to the left side of the view.
  ///
  public int X;

  ///
  /// Y coordinate relative to the top side of the view.
  ///
  public int Y;

  ///
  /// Bit flags describing any pressed modifier keys. See
  /// cef_event_flags_t for values.
  ///
  public CefEventFlags Modifiers;

}
