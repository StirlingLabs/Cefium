namespace Cefaloid;

/// <summary>
/// Supported UI scale factors for the platform. SCALE_FACTOR_NONE is used for
/// density independent resources such as string, html/js files or an image that
/// can be used for any scale factors (such as wallpapers).
/// <c>cef_scale_factor_t</c>
/// </summary>
[PublicAPI]
public enum CefScaleFactor {
  /// <summary>
  /// <c>SCALE_FACTOR_NONE</c>
  /// </summary>
  None = 0,
  /// <summary>
  /// <c>SCALE_FACTOR_100P</c>
  /// </summary>
  _100p,
  /// <summary>
  /// <c>SCALE_FACTOR_125P</c>
  /// </summary>
  _125p,
  /// <summary>
  /// <c>SCALE_FACTOR_133P</c>
  /// </summary>
  _133p,
  /// <summary>
  /// <c>SCALE_FACTOR_140P</c>
  /// </summary>
  _140p,
  /// <summary>
  /// <c>SCALE_FACTOR_150P</c>
  /// </summary>
  _150p,
  /// <summary>
  /// <c>SCALE_FACTOR_180P</c>
  /// </summary>
  _180p,
  /// <summary>
  /// <c>SCALE_FACTOR_200P</c>
  /// </summary>
  _200p,
  /// <summary>
  /// <c>SCALE_FACTOR_250P</c>
  /// </summary>
  _250p,
  /// <summary>
  /// <c>SCALE_FACTOR_300P</c>
  /// </summary>
  _300p,
}
