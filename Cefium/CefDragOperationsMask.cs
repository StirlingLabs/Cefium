namespace Cefium;

/// <summary>
/// "Verb" of a drag-and-drop operation as negotiated between the source and
/// destination. These constants match their equivalents in WebCore's
/// DragActions.h and should not be renumbered.
/// <c>cef_drag_operations_mask_t</c>
/// </summary>
public enum CefDragOperationsMask : uint {

  /// <summary>
  /// <c>DRAG_OPERATION_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// <c>DRAG_OPERATION_COPY</c>
  /// </summary>
  Copy = 1,

  /// <summary>
  /// <c>DRAG_OPERATION_LINK</c>
  /// </summary>
  Link = 2,

  /// <summary>
  /// <c>DRAG_OPERATION_GENERIC</c>
  /// </summary>
  Generic = 4,

  /// <summary>
  /// <c>DRAG_OPERATION_PRIVATE</c>
  /// </summary>
  Private = 8,

  /// <summary>
  /// <c>DRAG_OPERATION_MOVE</c>
  /// </summary>
  Move = 16,

  /// <summary>
  /// <c>DRAG_OPERATION_DELETE</c>
  /// </summary>
  Delete = 32,

  /// <summary>
  /// <c>DRAG_OPERATION_EVERY</c>
  /// </summary>
  Every = uint.MaxValue

}
