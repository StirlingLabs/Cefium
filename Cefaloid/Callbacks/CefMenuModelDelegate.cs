namespace Cefaloid;

/// <summary>
/// Implement this structure to handle menu model events. The functions of this
/// structure will be called on the browser process UI thread unless otherwise
/// indicated.
/// <c>cef_menu_model_delegate_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMenuModelDelegate : ICefRefCountedBase<CefMenuModelDelegate> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefMenuModelDelegate() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Perform the action associated with the specified |command_id| and optional
  /// |event_flags|.
  /// <c>void(CEF_CALLBACK* execute_command)(struct _cef_menu_model_delegate_t* self, struct _cef_menu_model_t* menu_model, int command_id, cef_event_flags_t event_flags);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModelDelegate*, CefMenuModel*, int, CefEventFlags> _ExecuteCommand;

  /// <summary>
  /// Called when the user moves the mouse outside the menu and over the owning
  /// window.
  /// <c>void(CEF_CALLBACK* mouse_outside_menu)(struct _cef_menu_model_delegate_t* self, struct _cef_menu_model_t* menu_model, const cef_point_t* screen_point);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModelDelegate*, CefMenuModel*, CefPoint*, void> _MouseOutsideMenu;

  /// <summary>
  /// Called on unhandled open submenu keyboard commands. |is_rtl| will be true
  /// (1) if the menu is displaying a right-to-left language.
  /// <c>void(CEF_CALLBACK* unhandled_open_submenu)(struct _cef_menu_model_delegate_t* self, struct _cef_menu_model_t* menu_model, int is_rtl);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModelDelegate*, CefMenuModel*, int, void> _UnhandledOpenSubmenu;

  /// <summary>
  /// Called on unhandled close submenu keyboard commands. |is_rtl| will be true
  /// (1) if the menu is displaying a right-to-left language.
  /// <c>void(CEF_CALLBACK* unhandled_close_submenu)(struct _cef_menu_model_delegate_t* self, struct _cef_menu_model_t* menu_model, int is_rtl);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModelDelegate*, CefMenuModel*, int, void> _UnhandledCloseSubmenu;

  /// <summary>
  /// The menu is about to show.
  /// <c>void(CEF_CALLBACK* menu_will_show)(struct _cef_menu_model_delegate_t* self, struct _cef_menu_model_t* menu_model);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModelDelegate*, CefMenuModel*, void> _MenuWillShow;

  /// <summary>
  /// The menu has closed.
  /// <c>void(CEF_CALLBACK* menu_closed)(struct _cef_menu_model_delegate_t* self, struct _cef_menu_model_t* menu_model);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModelDelegate*, CefMenuModel*, void> _MenuClosed;

  /// <summary>
  /// Optionally modify a menu item label. Return true (1) if |label| was
  /// modified.
  /// <c>int(CEF_CALLBACK* format_label)(struct _cef_menu_model_delegate_t* self, struct _cef_menu_model_t* menu_model, cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModelDelegate*, CefMenuModel*, CefString*, int> _FormatLabel;

}
