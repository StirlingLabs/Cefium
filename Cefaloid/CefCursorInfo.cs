namespace Cefaloid;

/// <summary>
/// Structure representing cursor information. |buffer| will be
/// |size.width|*|size.height|*4 bytes in size and represents a BGRA image with
/// an upper-left origin.
/// <c>cef_cursor_info_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCursorInfo {

  public CefPoint Hotspot;

  public float ImageScaleFactor;

  public unsafe void* Buffer;

  public CefSize Size;

}
