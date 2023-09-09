namespace Cefaloid;

/// <summary>
/// Supported context menu edit state bit flags. These constants match their
/// equivalents in Chromium's ContextMenuDataEditFlags and should not be
/// renumbered.
/// <c>cef_context_menu_edit_state_flags_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefContextMenuEditStateFlags {

  /// <summary>
  /// <c>CM_EDITFLAG_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_UNDO</c>
  /// </summary>
  CanUndo = 1 << 0,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_REDO</c>
  /// </summary>
  CanRedo = 1 << 1,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_CUT</c>
  /// </summary>
  CanCut = 1 << 2,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_COPY</c>
  /// </summary>
  CanCopy = 1 << 3,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_PASTE</c>
  /// </summary>
  CanPaste = 1 << 4,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_DELETE</c>
  /// </summary>
  CanDelete = 1 << 5,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_SELECT_ALL</c>
  /// </summary>
  CanSelectAll = 1 << 6,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_TRANSLATE</c>
  /// </summary>
  CanTranslate = 1 << 7,

  /// <summary>
  /// <c>CM_EDITFLAG_CAN_EDIT_RICHLY</c>
  /// </summary>
  CanEditRichly = 1 << 8,

}
