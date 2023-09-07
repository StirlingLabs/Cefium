namespace Cefaloid;

/// <summary>
/// Supported menu item types.
/// <c>cef_menu_item_type_t</c>
/// </summary>
[PublicAPI]
public enum CefMenuItemType {

  /// <summary>
  /// <c>MENUITEMTYPE_NONE</c>
  /// </summary>
  None,

  /// <summary>
  /// <c>MENUITEMTYPE_COMMAND</c>
  /// </summary>
  Command,

  /// <summary>
  /// <c>MENUITEMTYPE_CHECK</c>
  /// </summary>
  Check,

  /// <summary>
  /// <c>MENUITEMTYPE_RADIO</c>
  /// </summary>
  Radio,

  /// <summary>
  /// <c>MENUITEMTYPE_SEPARATOR</c>
  /// </summary>
  Separator,

  /// <summary>
  /// <c>MENUITEMTYPE_SUBMENU</c>
  /// </summary>
  Submenu,

}
