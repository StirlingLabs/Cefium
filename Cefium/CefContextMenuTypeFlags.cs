namespace Cefium;

/// <summary>
/// Supported context menu type flags.
/// <c>cef_context_menu_type_flags_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefContextMenuTypeFlags {

  /// <summary>
  /// No node is selected.
  /// <c>CM_TYPEFLAG_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// The top page is selected.
  /// <c>CM_TYPEFLAG_PAGE</c>
  /// </summary>
  Page = 1 << 0,

  /// <summary>
  /// A subframe page is selected.
  /// <c>CM_TYPEFLAG_FRAME</c>
  /// </summary>
  Frame = 1 << 1,

  /// <summary>
  /// A link is selected.
  /// <c>CM_TYPEFLAG_LINK</c>
  /// </summary>
  Link = 1 << 2,

  /// <summary>
  /// A media node is selected.
  /// <c>CM_TYPEFLAG_MEDIA</c>
  /// </summary>
  Media = 1 << 3,

  /// <summary>
  /// There is a textual or mixed selection that is selected.
  /// <c>CM_TYPEFLAG_SELECTION</c>
  /// </summary>
  Selection = 1 << 4,

  /// <summary>
  /// An editable element is selected.
  /// <c>CM_TYPEFLAG_EDITABLE</c>
  /// </summary>
  Editable = 1 << 5,

}
