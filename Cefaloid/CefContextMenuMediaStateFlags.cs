namespace Cefaloid;

/// <summary>
/// Supported context menu media state bit flags. These constants match their
/// equivalents in Chromium's ContextMenuData::MediaFlags and should not be
/// renumbered.
/// <c>cef_context_menu_media_state_flags_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefContextMenuMediaStateFlags {

  /// <summary>
  /// <c>CM_MEDIAFLAG_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// <c>CM_MEDIAFLAG_IN_ERROR</c>
  /// </summary>
  InError = 1 << 0,

  /// <summary>
  /// <c>CM_MEDIAFLAG_PAUSED</c>
  /// </summary>
  Paused = 1 << 1,

  /// <summary>
  /// <c>CM_MEDIAFLAG_MUTED</c>
  /// </summary>
  Muted = 1 << 2,

  /// <summary>
  /// <c>CM_MEDIAFLAG_LOOP</c>
  /// </summary>
  Loop = 1 << 3,

  /// <summary>
  /// <c>CM_MEDIAFLAG_CAN_SAVE</c>
  /// </summary>
  CanSave = 1 << 4,

  /// <summary>
  /// <c>CM_MEDIAFLAG_HAS_AUDIO</c>
  /// </summary>
  HasAudio = 1 << 5,

  /// <summary>
  /// <c>CM_MEDIAFLAG_CAN_TOGGLE_CONTROLS</c>
  /// </summary>
  CanToggleControls = 1 << 6,

  /// <summary>
  /// <c>CM_MEDIAFLAG_CONTROLS</c>
  /// </summary>
  Controls = 1 << 7,

  /// <summary>
  /// <c>CM_MEDIAFLAG_CAN_PRINT</c>
  /// </summary>
  CanPrint = 1 << 8,

  /// <summary>
  /// <c>CM_MEDIAFLAG_CAN_ROTATE</c>
  /// </summary>
  CanRotate = 1 << 9,

  /// <summary>
  /// <c>CM_MEDIAFLAG_CAN_PICTURE_IN_PICTURE</c>
  /// </summary>
  CanPictureInPicture = 1 << 10,

  /// <summary>
  /// <c>CM_MEDIAFLAG_PICTURE_IN_PICTURE</c>
  /// </summary>
  PictureInPicture = 1 << 11,

  /// <summary>
  /// <c>CM_MEDIAFLAG_CAN_LOOP</c>
  /// </summary>
  CanLoop = 1 << 12,

}
