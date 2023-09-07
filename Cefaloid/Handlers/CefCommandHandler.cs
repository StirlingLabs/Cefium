namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events related to commands. The functions
/// of this structure will be called on the UI thread.
/// <c>cef_command_handler_t</c>
/// </summary>
/// <seealso cref="CefCommandHandlerExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCommandHandler : ICefRefCountedBase<CefCommandHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefCommandHandler() {}

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

}
