namespace Cefaloid;

/// <summary>
/// <c>cef_color_model_t</c>
/// </summary>
[PublicAPI]
public enum CefColorModel {

  /// <summary>
  /// <c>COLOR_MODEL_UNKNOWN</c>
  /// </summary>
  Unknown,

  /// <summary>
  /// <c>COLOR_MODEL_GRAY</c>
  /// </summary>
  Gray,

  /// <summary>
  /// <c>COLOR_MODEL_COLOR</c>
  /// </summary>
  Color,

  /// <summary>
  /// <c>COLOR_MODEL_CMYK</c>
  /// </summary>
  Cmyk,

  /// <summary>
  /// <c>COLOR_MODEL_CMY</c>
  /// </summary>
  Cmy,

  /// <summary>
  /// <c>COLOR_MODEL_KCMY</c>
  /// </summary>
  [SuppressMessage("ReSharper", "IdentifierTypo")]
  Kcmy,

  /// <summary>
  /// <c>COLOR_MODEL_CMY_K</c>
  /// </summary>
  CmyK, // CMY_K represents CMY+K.

  /// <summary>
  /// <c>COLOR_MODEL_BLACK</c>
  /// </summary>
  Black,

  /// <summary>
  /// <c>COLOR_MODEL_GRAYSCALE</c>
  /// </summary>
  Grayscale,

  /// <summary>
  /// <c>COLOR_MODEL_RGB</c>
  /// </summary>
  Rgb,

  /// <summary>
  /// <c>COLOR_MODEL_RGB16</c>
  /// </summary>
  Rgb16,

  /// <summary>
  /// <c>COLOR_MODEL_RGBA</c>
  /// </summary>
  Rgba,

  /// <summary>
  /// Used in samsung printer ppds.
  /// <c>COLOR_MODEL_COLORMODE_COLOR</c>
  /// </summary>
  ColorModeColor,

  /// <summary>
  /// Used in samsung printer ppds.
  /// <c>COLOR_MODEL_COLORMODE_MONOCHROME</c>
  /// </summary>
  ColorModeMonochrome,

  /// <summary>
  /// Used in HP color printer ppds.
  /// <c>COLOR_MODEL_HP_COLOR_COLOR</c>
  /// </summary>
  HpColorColor,

  /// <summary>
  /// Used in HP color printer ppds.
  /// <c>COLOR_MODEL_HP_COLOR_BLACK</c>
  /// </summary>
  HpColorBlack,

  /// <summary>
  /// Used in foomatic ppds.
  /// <c>COLOR_MODEL_PRINTOUTMODE_NORMAL</c>
  /// </summary>
  PrintOutModeNormal,

  /// <summary>
  /// Used in foomatic ppds.
  /// <c>COLOR_MODEL_PRINTOUTMODE_NORMAL_GRAY</c>
  /// </summary>
  PrintOutModeNormalGray,

  /// <summary>
  /// Used in canon printer ppds.
  /// <c>COLOR_MODEL_PROCESSCOLORMODEL_CMYK</c>
  /// </summary>
  ProcessColorModelCmyk,

  /// <summary>
  /// Used in canon printer ppds.
  /// <c>COLOR_MODEL_PROCESSCOLORMODEL_GREYSCALE</c>
  /// </summary>
  ProcessColorModelGreyscale,

  /// <summary>
  /// Used in canon printer ppds
  /// <c>COLOR_MODEL_PROCESSCOLORMODEL_RGB</c>
  /// </summary>
  ProcessColorModelRgb,

}