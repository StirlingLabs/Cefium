namespace Cefaloid;

/// <summary>
/// Structure representing IME composition underline information. This is a thin
/// wrapper around Blink's WebCompositionUnderline class and should be kept in
/// sync with that.
/// <c>cef_composition_underline_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCompositionUnderline {

  /// <summary>
  /// Underline character range.
  /// </summary>
  public CefRange Range;

  /// <summary>
  /// Text color.
  /// </summary>
  public CefColor Color;

  /// <summary>
  /// Background color.
  /// </summary>
  public CefColor BackgroundColor;

  /// <summary>
  /// Set to true (1) for thick underline.
  /// </summary>
  private int _thick;

  /// <inheritdoc cref="_thick"/>
  public bool Thick {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _thick != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _thick = value ? 1 : 0;
  }

  /// <summary>
  /// Style.
  /// </summary>
  public CefCompositionUnderlineStyle Style;

}
