namespace Cefaloid;

/// <summary>
/// Callback structure for asynchronous continuation of file dialog requests.
/// <c>cef_file_dialog_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefFileDialogCallback : ICefRefCountedBase<CefFileDialogCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefFileDialogCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Continue the file selection. |file_paths| should be a single value or a
  /// list of values depending on the dialog mode. An NULL |file_paths| value is
  /// treated the same as calling cancel().
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_file_dialog_callback_t* self, cef_string_list_t file_paths)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFileDialogCallback*, CefStringList*, void> _Continue;

  /// <summary>
  /// Cancel the file selection.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_file_dialog_callback_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFileDialogCallback*, void> _Cancel;

}
