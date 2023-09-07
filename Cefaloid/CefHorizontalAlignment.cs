namespace Cefaloid;

/// <summary>
/// Specifies the horizontal text alignment mode.
/// <c>cef_horizontal_alignment_t</c>
/// </summary>
[PublicAPI]
public enum CefHorizontalAlignment {

  /// <summary>
  /// Align the text's left edge with that of its display area.
  /// <c>CEF_HORIZONTAL_ALIGNMENT_LEFT</c>
  /// </summary>
  Left,

  /// <summary>
  /// Align the text's center with that of its display area.
  /// <c>CEF_HORIZONTAL_ALIGNMENT_CENTER</c>
  /// </summary>
  Center,

  /// <summary>
  /// Align the text's right edge with that of its display area.
  /// <c>CEF_HORIZONTAL_ALIGNMENT_RIGHT</c>
  /// </summary>
  Right,

}