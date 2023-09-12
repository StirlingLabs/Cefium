namespace Cefaloid;

/// <summary>
/// Chrome toolbar button types. Should be kept in sync with CEF's internal
/// ToolbarButtonType type.
/// <c>cef_chrome_toolbar_button_type_t</c>
/// </summary>
[PublicAPI]
public enum CefChromeToolbarButtonType {

  Cast = 0,

  Download,

  SendTabToSelf,

  SidePanel,

  MaxValue = SidePanel,

}