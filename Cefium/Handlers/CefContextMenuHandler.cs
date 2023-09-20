namespace Cefium;

/// <summary>
/// Implement this structure to handle context menu events. The functions of
/// this structure will be called on the UI thread.
/// <c>cef_context_menu_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefContextMenuHandler : ICefRefCountedBase<CefContextMenuHandler> {

  /// <inheritdoc cref="CefContextMenuHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefContextMenuHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called before a context menu is displayed. |params| provides information
  /// about the context menu state. |model| initially contains the default
  /// context menu. The |model| can be cleared to show no context menu or
  /// modified to show a custom menu. Do not keep references to |params| or
  /// |model| outside of this callback.
  /// <c>void(CEF_CALLBACK* on_before_context_menu)(struct _cef_context_menu_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_context_menu_params_t* params, struct _cef_menu_model_t* model);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuHandler*, CefBrowser*, CefFrame*, CefContextMenuParams*, CefMenuModel*, void> _OnBeforeContextMenu;

  /// <summary>
  /// Called to allow custom display of the context menu. |params| provides
  /// information about the context menu state. |model| contains the context
  /// menu model resulting from OnBeforeContextMenu. For custom display return
  /// true (1) and execute |callback| either synchronously or asynchronously
  /// with the selected command ID. For default display return false (0). Do not
  /// keep references to |params| or |model| outside of this callback.
  /// <c>int(CEF_CALLBACK* run_context_menu)(struct _cef_context_menu_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_context_menu_params_t* params, struct _cef_menu_model_t* model, struct _cef_run_context_menu_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuHandler*, CefBrowser*, CefFrame*, CefContextMenuParams*, CefMenuModel*, CefRunContextMenuCallback*, int> _RunContextMenu;

  /// <summary>
  /// Called to execute a command selected from the context menu. Return true
  /// (1) if the command was handled or false (0) for the default
  /// implementation. See cef_menu_id_t for the command ids that have default
  /// implementations. All user-defined command ids should be between
  /// MENU_ID_USER_FIRST and MENU_ID_USER_LAST. |params| will have the same
  /// values as what was passed to on_before_context_menu(). Do not keep a
  /// reference to |params| outside of this callback.
  /// <c>int(CEF_CALLBACK* on_context_menu_command)(struct _cef_context_menu_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_context_menu_params_t* params, int command_id, cef_event_flags_t event_flags);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuHandler*, CefBrowser*, CefFrame*, CefContextMenuParams*, int, CefEventFlags, int> _OnContextMenuCommand;

  /// <summary>
  /// Called when the context menu is dismissed irregardless of whether the menu
  /// was canceled or a command was selected.
  /// <c>void(CEF_CALLBACK* on_context_menu_dismissed)(struct _cef_context_menu_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuHandler*, CefBrowser*, CefFrame*, void> _OnContextMenuDismissed;

  /// <summary>
  /// Called to allow custom display of the quick menu for a windowless browser.
  /// |location| is the top left corner of the selected region. |size| is the
  /// size of the selected region. |edit_state_flags| is a combination of flags
  /// that represent the state of the quick menu. Return true (1) if the menu
  /// will be handled and execute |callback| either synchronously or
  /// asynchronously with the selected command ID. Return false (0) to cancel
  /// the menu.
  /// <c>int(CEF_CALLBACK* run_quick_menu)(struct _cef_context_menu_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, const cef_point_t* location, const cef_size_t* size, cef_quick_menu_edit_state_flags_t edit_state_flags, struct _cef_run_quick_menu_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuHandler*, CefBrowser*, CefFrame*, CefPoint*, CefSize*, CefQuickMenuEditStateFlags, CefRunQuickMenuCallback*, int> _RunQuickMenu;

  /// <summary>
  /// Called to execute a command selected from the quick menu for a windowless
  /// browser. Return true (1) if the command was handled or false (0) for the
  /// default implementation. See cef_menu_id_t for command IDs that have
  /// default implementations.
  /// <c>int(CEF_CALLBACK* on_quick_menu_command)(struct _cef_context_menu_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, int command_id, cef_event_flags_t event_flags);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuHandler*, CefBrowser*, CefFrame*, int, CefEventFlags, int> _OnQuickMenuCommand;

  /// <summary>
  /// Called when the quick menu for a windowless browser is dismissed
  /// irregardless of whether the menu was canceled or a command was selected.
  /// <c>void(CEF_CALLBACK* on_quick_menu_dismissed)(struct _cef_context_menu_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame);</c>
  ///</summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuHandler*, CefBrowser*, CefFrame*, void> _OnQuickMenuDismissed;

}
