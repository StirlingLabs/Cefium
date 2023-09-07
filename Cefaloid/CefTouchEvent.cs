namespace Cefaloid;

/// <summary>
/// Structure representing touch event information.
/// <c>cef_touch_event_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefTouchEvent {

  /// <summary>
  /// Id of a touch point. Must be unique per touch, can be any number except
  /// -1. Note that a maximum of 16 concurrent touches will be tracked; touches
  /// beyond that will be ignored.
  /// </summary>
  public int Id;

  /// <summary>
  /// Coordinates relative to the top left side of the view.
  /// </summary>
  public CefFractionalPoint Point;

  /// <summary>
  /// X coordinate relative to the left side of the view.
  /// </summary>
  public float X {
    get => Point.X;
    set => Point.X = value;
  }

  /// <summary>
  /// Y coordinate relative to the top side of the view.
  /// </summary>
  public float Y {
    get => Point.Y;
    set => Point.Y = value;
  }

  /// <summary>
  /// Radius in pixels. Set to 0x0 if not applicable.
  /// </summary>
  public CefFractionalSize Radius;

  /// <summary>
  /// X radius in pixels. Set to 0 if not applicable.
  /// </summary>
  public float RadiusX {
    get => Radius.Width;
    set => Radius.Width = value;
  }

  /// <summary>
  /// Y radius in pixels. Set to 0 if not applicable.
  /// </summary>
  public float RadiusY {
    get => Radius.Height;
    set => Radius.Height = value;
  }

  /// <summary>
  /// Rotation angle in radians. Set to 0 if not applicable.
  /// </summary>
  public float RotationAngle;

  /// <summary>
  /// The normalized pressure of the pointer input in the range of [0,1].
  /// Set to 0 if not applicable.
  /// </summary>
  public float Pressure;

  /// <summary>
  /// The state of the touch point. Touches begin with one CEF_TET_PRESSED event
  /// followed by zero or more CEF_TET_MOVED events and finally one
  /// CEF_TET_RELEASED or CEF_TET_CANCELLED event. Events not respecting this
  /// order will be ignored.
  /// </summary>
  public CefTouchEventType Type;

  /// <summary>
  /// Bit flags describing any pressed modifier keys. See
  /// cef_event_flags_t for values.
  /// </summary>
  public CefEventFlags Modifiers;

  /// <summary>
  /// The device type that caused the event.
  /// </summary>
  public CefPointerType PointerType;

}
