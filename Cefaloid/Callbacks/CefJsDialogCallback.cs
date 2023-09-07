namespace Cefaloid;

/// <summary>
/// Callback structure used for asynchronous continuation of JavaScript dialog
/// requests.
/// <c>cef_jsdialog_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefJsDialogCallback : ICefRefCountedBase<CefJsDialogCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefJsDialogCallback() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Continue the JS dialog request. Set |success| to true (1) if the OK button
  /// was pressed. The |user_input| value should be specified for prompt
  /// dialogs.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_jsdialog_callback_t* self, int success, const cef_string_t* user_input)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefJsDialogCallback*, int, CefString*, void> _Continue;

}
