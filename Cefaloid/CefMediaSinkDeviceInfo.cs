namespace Cefaloid;

/// <summary>
/// Device information for a MediaSink object.
/// <c>cef_media_sink_device_info_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaSinkDeviceInfo {

  public CefString IpAddress;

  public int Port;

  public CefString ModelName;

}
