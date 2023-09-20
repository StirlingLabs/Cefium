namespace Cefium;

/// <summary>
/// Callback structure for cef_browser_host_t::DownloadImage. The functions of
/// this structure will be called on the browser process UI thread.
/// <c>cef_download_image_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDownloadImageCallback : ICefRefCountedBase<CefDownloadImageCallback> {

  /// <see cref="CefDownloadImageCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDownloadImageCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be executed when the image download has completed.
  /// |image_url| is the URL that was downloaded and |http_status_code| is the
  /// resulting HTTP status code. |image| is the resulting image, possibly at
  /// multiple scale factors, or NULL if the download failed.
  /// <c>void(CEF_CALLBACK* on_download_image_finished)(struct _cef_download_image_callback_t* self, const cef_string_t* image_url, int http_status_code, struct _cef_image_t* image)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadImageCallback*, CefString*, int, CefImage*, void> _OnDownloadImageFinished;

}
