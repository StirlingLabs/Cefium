namespace Cefaloid;

/// <summary>
/// Screen information used when window rendering is disabled. This structure is
/// passed as a parameter to CefRenderHandler::GetScreenInfo and should be
/// filled in by the client.
/// <c>cef_screen_info_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefScreenInfo {

  /// <summary>
  /// Device scale factor. Specifies the ratio between physical and logical
  /// pixels.
  /// </summary>
  public float DeviceScaleFactor;

  /// <summary>
  /// The screen depth in bits per pixel.
  /// </summary>
  public int Depth;

  /// <summary>
  /// The bits per color component. This assumes that the colors are balanced
  /// equally.
  /// </summary>
  public int DepthPerComponent;

  /// <summary>
  /// This can be true for black and white printers.
  /// </summary>
  public int IsMonochrome;

  /// <summary>
  /// This is set from the rcMonitor member of MONITORINFOEX, to whit:
  ///   "A RECT structure that specifies the display monitor rectangle,
  ///   expressed in virtual-screen coordinates. Note that if the monitor
  ///   is not the primary display monitor, some of the rectangle's
  ///   coordinates may be negative values."
  ///
  /// The |rect| and |available_rect| properties are used to determine the
  /// available surface for rendering popup views.
  /// </summary>
  public CefRect Rect;

  /// <summary>
  /// This is set from the rcWork member of MONITORINFOEX, to whit:
  ///   "A RECT structure that specifies the work area rectangle of the
  ///   display monitor that can be used by applications, expressed in
  ///   virtual-screen coordinates. Windows uses this rectangle to
  ///   maximize an application on the monitor. The rest of the area in
  ///   rcMonitor contains system windows such as the task bar and side
  ///   bars. Note that if the monitor is not the primary display monitor,
  ///   some of the rectangle's coordinates may be negative values".
  ///
  /// The |rect| and |available_rect| properties are used to determine the
  /// available surface for rendering popup views.
  /// </summary>
  public CefRect AvailableRect;

}
