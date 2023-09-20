namespace Cefium;

/// <summary>
/// Cursor type values.
/// <c>cef_cursor_type_t</c>
/// </summary>
[PublicAPI]
public enum CefCursorType {

  /// <summary>
  /// <c>CT_POINTER</c>
  /// </summary>
  Pointer = 0,

  /// <summary>
  /// <c>CT_CROSS</c>
  /// </summary>
  Cross,

  /// <summary>
  /// <c>CT_HAND</c>
  /// </summary>
  Hand,

  /// <summary>
  /// <c>CT_IBEAM</c>
  /// </summary>
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  IBeam,

  /// <summary>
  /// <c>CT_WAIT</c>
  /// </summary>
  Wait,

  /// <summary>
  /// <c>CT_HELP</c>
  /// </summary>
  Help,

  /// <summary>
  /// <c>CT_EASTRESIZE</c>
  /// </summary>
  EastResize,

  /// <summary>
  /// <c>CT_NORTHRESIZE</c>
  /// </summary>
  NorthResize,

  /// <summary>
  /// <c>CT_NORTHEASTRESIZE</c>
  /// </summary>
  NorthEastResize,

  /// <summary>
  /// <c>CT_NORTHWESTRESIZE</c>
  /// </summary>
  NorthWestResize,

  /// <summary>
  /// <c>CT_SOUTHRESIZE</c>
  /// </summary>
  SouthResize,

  /// <summary>
  /// <c>CT_SOUTHEASTRESIZE</c>
  /// </summary>
  SouthEastResize,

  /// <summary>
  /// <c>CT_SOUTHWESTRESIZE</c>
  /// </summary>
  SouthWestResize,

  /// <summary>
  /// <c>CT_WESTRESIZE</c>
  /// </summary>
  WestResize,

  /// <summary>
  /// <c>CT_NORTHSOUTHRESIZE</c>
  /// </summary>
  NorthSouthResize,

  /// <summary>
  /// <c>CT_EASTWESTRESIZE</c>
  /// </summary>
  EastWestResize,

  /// <summary>
  /// <c>CT_NORTHEASTSOUTHWESTRESIZE</c>
  /// </summary>
  NorthEastSouthWestResize,

  /// <summary>
  /// <c>CT_NORTHWESTSOUTHEASTRESIZE</c>
  /// </summary>
  NorthWestSouthEastResize,

  /// <summary>
  /// <c>CT_COLUMNRESIZE</c>
  /// </summary>
  ColumnResize,

  /// <summary>
  /// <c>CT_ROWRESIZE</c>
  /// </summary>
  RowResize,

  /// <summary>
  /// <c>CT_MIDDLEPANNING</c>
  /// </summary>
  MiddlePanning,

  /// <summary>
  /// <c>CT_EASTPANNING</c>
  /// </summary>
  EastPanning,

  /// <summary>
  /// <c>CT_NORTHPANNING</c>
  /// </summary>
  NorthPanning,

  /// <summary>
  /// <c>CT_NORTHEASTPANNING</c>
  /// </summary>
  NorthEastPanning,

  /// <summary>
  /// <c>CT_NORTHWESTPANNING</c>
  /// </summary>
  NorthWestPanning,

  /// <summary>
  /// <c>CT_SOUTHPANNING</c>
  /// </summary>
  SouthPanning,

  /// <summary>
  /// <c>CT_SOUTHEASTPANNING</c>
  /// </summary>
  SouthEastPanning,

  /// <summary>
  /// <c>CT_SOUTHWESTPANNING</c>
  /// </summary>
  SouthWestPanning,

  /// <summary>
  /// <c>CT_WESTPANNING</c>
  /// </summary>
  WestPanning,

  /// <summary>
  /// <c>CT_MOVE</c>
  /// </summary>
  Move,

  /// <summary>
  /// <c>CT_VERTICALTEXT</c>
  /// </summary>
  VerticalText,

  /// <summary>
  /// <c>CT_CELL</c>
  /// </summary>
  Cell,

  /// <summary>
  /// <c>CT_CONTEXTMENU</c>
  /// </summary>
  ContextMenu,

  /// <summary>
  /// <c>CT_ALIAS</c>
  /// </summary>
  Alias,

  /// <summary>
  /// <c>CT_PROGRESS</c>
  /// </summary>
  Progress,

  /// <summary>
  /// <c>CT_NODROP</c>
  /// </summary>
  NoDrop,

  /// <summary>
  /// <c>CT_COPY</c>
  /// </summary>
  Copy,

  /// <summary>
  /// <c>CT_NONE</c>
  /// </summary>
  None,

  /// <summary>
  /// <c>CT_NOTALLOWED</c>
  /// </summary>
  NotAllowed,

  /// <summary>
  /// <c>CT_ZOOMIN</c>
  /// </summary>
  ZoomIn,

  /// <summary>
  /// <c>CT_ZOOMOUT</c>
  /// </summary>
  ZoomOut,

  /// <summary>
  /// <c>CT_GRAB</c>
  /// </summary>
  Grab,

  /// <summary>
  /// <c>CT_GRABBING</c>
  /// </summary>
  Grabbing,

  /// <summary>
  /// <c>CT_MIDDLE_PANNING_VERTICAL</c>
  /// </summary>
  MiddlePanningVertical,

  /// <summary>
  /// <c>CT_MIDDLE_PANNING_HORIZONTAL</c>
  /// </summary>
  MiddlePanningHorizontal,

  /// <summary>
  /// <c>CT_CUSTOM</c>
  /// </summary>
  Custom,

  /// <summary>
  /// <c>CT_DND_NONE</c>
  /// </summary>
  DndNone,

  /// <summary>
  /// <c>CT_DND_MOVE</c>
  /// </summary>
  DndMove,

  /// <summary>
  /// <c>CT_DND_COPY</c>
  /// </summary>
  DndCopy,

  /// <summary>
  /// <c>CT_DND_LINK</c>
  /// </summary>
  DndLink,

}
