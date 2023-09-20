namespace Cefium;

/// <summary>
/// Supported context menu media types. These constants match their equivalents
/// in Chromium's ContextMenuDataMediaType and should not be renumbered.
/// <c>cef_context_menu_media_type_t</c>
///</summary>
[PublicAPI]
public enum CefContextMenuMediaType {

  /// <summary>
  /// No special node is in context.
  /// <c>CM_MEDIATYPE_NONE</c>
  /// </summary>
  None,

  /// <summary>
  /// An image node is selected.
  /// <c>CM_MEDIATYPE_IMAGE</c>
  /// </summary>
  Image,

  /// <summary>
  /// A video node is selected.
  /// <c>CM_MEDIATYPE_VIDEO</c>
  /// </summary>
  Video,

  /// <summary>
  /// An audio node is selected.
  /// <c>CM_MEDIATYPE_AUDIO</c>
  /// </summary>
  Audio,

  /// <summary>
  /// An canvas node is selected.
  /// <c>CM_MEDIATYPE_CANVAS</c>
  /// </summary>
  Canvas,

  /// <summary>
  /// A file node is selected.
  /// <c>CM_MEDIATYPE_FILE</c>
  /// </summary>
  File,

  /// <summary>
  /// A plugin node is selected.
  /// <c>CM_MEDIATYPE_PLUGIN</c>
  /// </summary>
  Plugin,

}
