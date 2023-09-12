namespace Cefaloid;

/// <summary>
/// Structure representing cursor information. |buffer| will be
/// |size.width|*|size.height|*4 bytes in size and represents a BGRA image with
/// an upper-left origin.
/// <c>cef_cursor_info_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCursorInfo {

  /// <summary>
  /// The hotspot coordinates relative to the upper-left corner of the image.
  /// </summary>
  /// <remarks>
  /// Hotspot is a relative spot on the cursor image at which the "click" occurs.
  /// </remarks>
  public CefPoint Hotspot;

  /// <summary>
  /// The image scale factor.
  /// </summary>
  public float ImageScaleFactor;

  /// <summary>
  /// The image buffer.
  /// </summary>
  public unsafe void* Buffer;

  /// <summary>
  /// The size of the image.
  /// </summary>
  public CefSize Size;

}
