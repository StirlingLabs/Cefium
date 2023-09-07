namespace Cefaloid;

/// <summary>
/// Supported color types for menu items.
/// <c>cef_menu_color_type_t</c>
/// </summary>
[PublicAPI]
public enum CefMenuColorType {

  /// <summary>
  /// <c>CEF_MENU_COLOR_TEXT</c>
  /// </summary>
  Text,

  /// <summary>
  /// <c>CEF_MENU_COLOR_TEXT_HOVERED</c>
  /// </summary>
  TextHovered,

  /// <summary>
  /// <c>CEF_MENU_COLOR_TEXT_ACCELERATOR</c>
  /// </summary>
  TextAccelerator,

  /// <summary>
  /// <c>CEF_MENU_COLOR_TEXT_ACCELERATOR_HOVERED</c>
  /// </summary>
  TextAcceleratorHovered,

  /// <summary>
  /// <c>CEF_MENU_COLOR_BACKGROUND</c>
  /// </summary>
  Background,

  /// <summary>
  /// <c>CEF_MENU_COLOR_BACKGROUND_HOVERED</c>
  /// </summary>
  BackgroundHovered,

  /// <summary>
  /// <c>CEF_MENU_COLOR_COUNT</c>
  /// </summary>
  Count,

}
