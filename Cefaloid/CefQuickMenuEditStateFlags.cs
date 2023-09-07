namespace Cefaloid;

/// <summary>
/// <c>cef_quick_menu_edit_state_flags_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefQuickMenuEditStateFlags {

  /// <summary>
  /// <c>QM_EDITFLAG_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// <c>QM_EDITFLAG_CAN_ELLIPSIS</c>
  /// </summary>
  CanEllipsis = 1 << 0,

  /// <summary>
  /// <c>QM_EDITFLAG_CAN_CUT</c>
  /// </summary>
  CanCut = 1 << 1,

  /// <summary>
  /// <c>QM_EDITFLAG_CAN_COPY</c>
  /// </summary>
  CanCopy = 1 << 2,

  /// <summary>
  /// <c>QM_EDITFLAG_CAN_PASTE</c>
  /// </summary>
  CanPaste = 1 << 3,

}
