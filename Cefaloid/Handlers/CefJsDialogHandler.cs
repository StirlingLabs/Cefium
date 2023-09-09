namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events related to JavaScript dialogs. The
/// functions of this structure will be called on the UI thread.
/// <c>cef_jsdialog_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefJsDialogHandler : ICefRefCountedBase<CefJsDialogHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefJsDialogHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called to run a JavaScript dialog. If |origin_url| is non-NULL it can be
  /// passed to the CefFormatUrlForSecurityDisplay function to retrieve a secure
  /// and user-friendly display string. The |default_prompt_text| value will be
  /// specified for prompt dialogs only. Set |suppress_message| to true (1) and
  /// return false (0) to suppress the message (suppressing messages is
  /// preferable to immediately executing the callback as this is used to detect
  /// presumably malicious behavior like spamming alert messages in
  /// onbeforeunload). Set |suppress_message| to false (0) and return false (0)
  /// to use the default implementation (the default implementation will show
  /// one modal dialog at a time and suppress any additional dialog requests
  /// until the displayed dialog is dismissed). Return true (1) if the
  /// application will use a custom dialog or if the callback has been executed
  /// immediately. Custom dialogs may be either modal or modeless. If a custom
  /// dialog is used the application must execute |callback| once the custom
  /// dialog is dismissed.
  /// <c>int(CEF_CALLBACK* on_jsdialog)(struct _cef_jsdialog_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* origin_url, cef_jsdialog_type_t dialog_type, const cef_string_t* message_text, const cef_string_t* default_prompt_text, struct _cef_jsdialog_callback_t* callback, int* suppress_message)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefJsDialogHandler*, CefBrowser*, CefString*, CefJsDialogType, CefString*, CefString*, CefJsDialogCallback*, int*, int> _OnJsDialog;

  /// <summary>
  /// Called to run a dialog asking the user if they want to leave a page.
  /// Return false (0) to use the default dialog implementation. Return true (1)
  /// if the application will use a custom dialog or if the callback has been
  /// executed immediately. Custom dialogs may be either modal or modeless. If a
  /// custom dialog is used the application must execute |callback| once the
  /// custom dialog is dismissed.
  /// <c>int(CEF_CALLBACK* on_before_unload_dialog)(struct _cef_jsdialog_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* message_text, int is_reload, struct _cef_jsdialog_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefJsDialogHandler*, CefBrowser*, CefString*, int, CefJsDialogCallback*, int> _OnBeforeUnloadDialog;

  /// <summary>
  /// Called to cancel any pending dialogs and reset any saved dialog state.
  /// Will be called due to events like page navigation irregardless of whether
  /// any dialogs are currently pending.
  /// <c>void(CEF_CALLBACK* on_reset_dialog_state)(struct _cef_jsdialog_handler_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefJsDialogHandler*, CefBrowser*, void> _OnResetDialogState;

  /// <summary>
  /// Called when the dialog is closed.
  /// <c>void(CEF_CALLBACK* on_dialog_closed)(struct _cef_jsdialog_handler_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefJsDialogHandler*, CefBrowser*, void> _OnDialogClosed;

}
