namespace Cefium;

/// <summary>
/// Implement this structure to handle events related to commands. The functions
/// of this structure will be called on the UI thread.
/// <c>cef_command_handler_t</c>
/// </summary>
/// <seealso cref="CefCommandHandlerExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCommandHandler : ICefRefCountedBase<CefCommandHandler> {

  /// <inheritdoc cref="CefCommandHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefCommandHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called to execute a Chrome command triggered via menu selection or
  /// keyboard shortcut. Values for |command_id| can be found in the
  /// cef_command_ids.h file. |disposition| provides information about the
  /// intended command target. Return true (1) if the command was handled or
  /// false (0) for the default implementation. For context menu commands this
  /// will be called after cef_context_menu_handler_t::OnContextMenuCommand.
  /// Only used with the Chrome runtime.
  /// <c>int(CEF_CALLBACK* on_chrome_command)(struct _cef_command_handler_t* self, struct _cef_browser_t* browser, int command_id, cef_window_open_disposition_t disposition);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandHandler*, CefBrowser*, int, CefWindowOpenDisposition, int> _OnChromeCommand;

  /// <summary>
  /// Called to check if a Chrome app menu item should be visible. Values for
  /// |command_id| can be found in the cef_command_ids.h file. Only called for
  /// menu items that would be visible by default. Only used with the Chrome
  /// runtime.
  /// <c>int(CEF_CALLBACK* is_chrome_app_menu_item_visible)(struct _cef_command_handler_t* self, struct _cef_browser_t* browser, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Cdecl]<CefCommandHandler*, CefBrowser*, int, int> _IsChromeAppMenuItemVisible; // is_chrome_app_menu_item_visible @ 48, 8 bytes !! MISSING !!

  /// <summary>
  /// Called to check if a Chrome app menu item should be enabled. Values for
  /// |command_id| can be found in the cef_command_ids.h file. Only called for
  /// menu items that would be enabled by default. Only used with the Chrome
  /// runtime.
  /// <c>int(CEF_CALLBACK* is_chrome_app_menu_item_enabled)(struct _cef_command_handler_t* self, struct _cef_browser_t* browser, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Cdecl]<CefCommandHandler*, CefBrowser*, int, int> _IsChromeAppMenuItemEnabled; // is_chrome_app_menu_item_enabled @ 56, 8 bytes !! MISSING !!

  /// <summary>
  /// Called during browser creation to check if a Chrome page action icon
  /// should be visible. Only called for icons that would be visible by default.
  /// Only used with the Chrome runtime.
  /// <c>int(CEF_CALLBACK* is_chrome_page_action_icon_visible)(struct _cef_command_handler_t* self, cef_chrome_page_action_icon_type_t icon_type);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Cdecl]<CefCommandHandler*, CefChromePageActionIconType, int> _IsChromePageActionIconVisible; // is_chrome_page_action_icon_visible @ 64, 8 bytes !! MISSING !!

  /// <summary>
  /// Called during browser creation to check if a Chrome toolbar button should
  /// be visible. Only called for buttons that would be visible by default. Only
  /// used with the Chrome runtime.
  /// <c>int(CEF_CALLBACK* is_chrome_toolbar_button_visible)(struct _cef_command_handler_t* self, cef_chrome_toolbar_button_type_t button_type);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Cdecl]<CefCommandHandler*, CefChromeToolbarButtonType, int> _IsChromeToolbarButtonVisible; // is_chrome_toolbar_button_visible @ 72, 8 bytes !! MISSING !!

}
