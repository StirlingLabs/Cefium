namespace Cefaloid;

/// <summary>
/// The device type that caused the event.
/// <c>cef_pointer_type_t</c>
/// </summary>
[PublicAPI]
public enum CefPointerType {

  /// <summary>
  /// <c>CEF_POINTER_TYPE_TOUCH</c>
  /// </summary>
  Touch = 0,

  /// <summary>
  /// <c>CEF_POINTER_TYPE_MOUSE</c>
  /// </summary>
  Mouse,

  /// <summary>
  /// <c>CEF_POINTER_TYPE_PEN</c>
  /// </summary>
  Pen,

  /// <summary>
  /// <c>CEF_POINTER_TYPE_ERASER</c>
  /// </summary>
  Eraser,

  /// <summary>
  /// <c>CEF_POINTER_TYPE_UNKNOWN</c>
  /// </summary>
  Unknown

}
