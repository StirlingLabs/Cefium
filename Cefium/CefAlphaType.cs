namespace Cefium;

/// <summary>
/// Describes how to interpret the alpha component of a pixel.
/// <c>cef_alpha_type_t</c>
/// </summary>
[PublicAPI]
public enum CefAlphaType {

  /// <summary>
  /// No transparency. The alpha component is ignored.
  /// <c>CEF_ALPHA_TYPE_OPAQUE</c>
  /// </summary>
  Opaque,

  /// <summary>
  /// Transparency with pre-multiplied alpha component.
  /// <c>CEF_ALPHA_TYPE_PREMULTIPLIED</c>
  /// </summary>
  PreMultiplied,

  /// <summary>
  /// Transparency with post-multiplied alpha component.
  /// <c>CEF_ALPHA_TYPE_POSTMULTIPLIED</c>
  /// </summary>
  PostMultiplied,

}
