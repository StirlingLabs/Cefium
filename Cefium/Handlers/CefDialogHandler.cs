namespace Cefium;

/// <summary>
/// Implement this structure to handle dialog events. The functions of this
/// structure will be called on the browser process UI thread.
/// <c>cef_dialog_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDialogHandler : ICefRefCountedBase<CefDialogHandler> {

  /// <inheritdoc cref="CefDialogHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDialogHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called to run a file chooser dialog. |mode| represents the type of dialog
  /// to display. |title| to the title to be used for the dialog and may be NULL
  /// to show the default title ("Open" or "Save" depending on the mode).
  /// |default_file_path| is the path with optional directory and/or file name
  /// component that should be initially selected in the dialog.
  /// |accept_filters| are used to restrict the selectable file types and may
  /// any combination of (a) valid lower-cased MIME types (e.g. "text/*" or
  /// "image/*"), (b) individual file extensions (e.g. ".txt" or ".png"), or (c)
  /// combined description and file extension delimited using "|" and ";" (e.g.
  /// "Image Types|.png;.gif;.jpg"). To display a custom dialog return true (1)
  /// and execute |callback| either inline or at a later time. To display the
  /// default dialog return false (0).
  /// <c>int(CEF_CALLBACK* on_file_dialog)(struct _cef_dialog_handler_t* self, struct _cef_browser_t* browser, cef_file_dialog_mode_t mode, const cef_string_t* title, const cef_string_t* default_file_path, cef_string_list_t accept_filters, struct _cef_file_dialog_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDialogHandler*, CefBrowser*, CefFileDialogMode, char*, char*, CefStringList*, CefFileDialogCallback*, int> _OnFileDialog;

}
