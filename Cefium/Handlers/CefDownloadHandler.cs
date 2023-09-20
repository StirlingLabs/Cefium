namespace Cefium;

/// <summary>
/// Structure used to handle file downloads. The functions of this structure
/// will called on the browser process UI thread.
/// <c>cef_download_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDownloadHandler : ICefRefCountedBase<CefDownloadHandler> {

  /// <inheritdoc cref="CefDownloadHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDownloadHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called before a download begins in response to a user-initiated action
  /// (e.g. alt + link click or link click that returns a `Content-Disposition:
  /// attachment` response from the server). |url| is the target download URL
  /// and |request_function| is the target function (GET, POST, etc). Return
  /// true (1) to proceed with the download or false (0) to cancel the download.
  /// <c>int(CEF_CALLBACK* can_download)(struct _cef_download_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* url, const cef_string_t* request_method)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadHandler*, CefBrowser*, CefString*, CefString*, int> _CanDownload;

  /// <summary>
  /// Called before a download begins. |suggested_name| is the suggested name
  /// for the download file. By default the download will be canceled. Execute
  /// |callback| either asynchronously or in this function to continue the
  /// download if desired. Do not keep a reference to |download_item| outside of
  /// this function.
  /// <c>void(CEF_CALLBACK* on_before_download)(struct _cef_download_handler_t* self, struct _cef_browser_t* browser, struct _cef_download_item_t* download_item, const cef_string_t* suggested_name, struct _cef_before_download_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadHandler*, CefBrowser*, CefDownloadItem*, CefString*, CefBeforeDownloadCallback*, void> _OnBeforeDownload;

  /// <summary>
  /// Called when a download's status or progress information has been updated.
  /// This may be called multiple times before and after on_before_download().
  /// Execute |callback| either asynchronously or in this function to cancel the
  /// download if desired. Do not keep a reference to |download_item| outside of
  /// this function.
  /// <c>void(CEF_CALLBACK* on_download_updated)(struct _cef_download_handler_t* self, struct _cef_browser_t* browser, struct _cef_download_item_t* download_item, struct _cef_download_item_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadHandler*, CefBrowser*, CefDownloadItem*, CefDownloadItemCallback*, void> _OnDownloadUpdated;

}
