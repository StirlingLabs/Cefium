namespace Cefaloid;

/// <summary>
/// Callback structure for cef_browser_host_t::RunFileDialog. The functions of
/// this structure will be called on the browser process UI thread.
/// <c>cef_run_file_dialog_callback_t</c>
/// </summary>
/// <seealso cref="CefRunFileDialogCallbackExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRunFileDialogCallback : ICefRefCountedBase<CefRunFileDialogCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefRunFileDialogCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called asynchronously after the file dialog is dismissed. |file_paths|
  /// will be a single value or a list of values depending on the dialog mode.
  /// If the selection was cancelled |file_paths| will be NULL.
  /// <c>void(CEF_CALLBACK* on_file_dialog_dismissed)(struct _cef_run_file_dialog_callback_t* self, cef_string_list_t file_paths);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRunFileDialogCallback*, CefStringList*, void> _OnFileDialogDismissed;

}
