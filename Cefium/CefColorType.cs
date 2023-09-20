namespace Cefium;

/// <summary>
/// Describes how to interpret the components of a pixel.
/// <c>cef_color_type_t</c>
/// </summary>
[PublicAPI]
public enum CefColorType {

  /// <summary>
  /// RGBA with 8 bits per pixel (32bits total).
  /// <c>CEF_COLOR_TYPE_RGBA_8888</c>
  /// </summary>
  Rgba8888 = 0,

  /// <summary>
  /// BGRA with 8 bits per pixel (32bits total).
  /// <c>CEF_COLOR_TYPE_BGRA_8888</c>
  /// </summary>
  Bgra8888 = 1,

}
