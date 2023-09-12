namespace Cefaloid;

/// <summary>
/// Callback structure used to asynchronously continue a download.
/// <c>cef_before_download_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefBeforeDownloadCallback : ICefRefCountedBase<CefBeforeDownloadCallback> {

  /// <see cref="CefBeforeDownloadCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefBeforeDownloadCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Call to continue the download. Set |download_path| to the full file path
  /// for the download including the file name or leave blank to use the
  /// suggested name and the default temp directory. Set |show_dialog| to true
  /// (1) if you do wish to show the default "Save As" dialog.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_before_download_callback_t* self, const cef_string_t* download_path, int show_dialog)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBeforeDownloadCallback*, CefString*, int, void> _Continue;

}
