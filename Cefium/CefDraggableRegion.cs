namespace Cefium;

/// <summary>
/// Structure representing a draggable region.
/// <c>cef_draggable_region_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public unsafe struct CefDraggableRegion {

  /// <summary>
  /// Bounds of the region.
  /// <c>cef_rect_t bounds</c>
  /// </summary>
  public CefRect Bounds;

  /// <summary>
  /// True (1) if the region is draggable.
  /// <c>int draggable</c>
  /// </summary>
  private int _draggable;

  /// <inheritdoc cref="_draggable"/>
  public bool Draggable {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _draggable != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _draggable = value ? 1 : 0;
  }

}
