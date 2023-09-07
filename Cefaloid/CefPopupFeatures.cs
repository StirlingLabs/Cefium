namespace Cefaloid;

/// <summary>
/// Popup window features.
/// <c>cef_popup_features_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPopupFeatures {

  public int X;

  public int _XSet;

  public bool XSet {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _XSet != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _XSet = value ? 1 : 0;
  }

  public int Y;

  public int _YSet;

  public bool YSet {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _YSet != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _YSet = value ? 1 : 0;
  }

  public int Width;

  public int _WidthSet;

  public bool WidthSet {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _WidthSet != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _WidthSet = value ? 1 : 0;
  }

  public int Height;

  public int _HeightSet;

  public bool HeightSet {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _HeightSet != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _HeightSet = value ? 1 : 0;
  }

  /// <summary>
  /// True (1) if browser interface elements should be hidden.
  /// </summary>
  public int _IsPopup;

  /// <inheritdoc cref="_IsPopup"/>
  public bool IsPopup {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _IsPopup != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _IsPopup = value ? 1 : 0;
  }

}
