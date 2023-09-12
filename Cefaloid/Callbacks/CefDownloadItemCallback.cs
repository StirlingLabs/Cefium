namespace Cefaloid;

/// <summary>
/// Callback structure used to asynchronously cancel a download.
/// <c>cef_download_item_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDownloadItemCallback : ICefRefCountedBase<CefDownloadItemCallback> {

  /// <see cref="CefDownloadItemCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDownloadItemCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Call to cancel the download.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_download_item_callback_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItemCallback*, void> _Cancel;

  /// <summary>
  /// Call to pause the download.
  /// <c>void(CEF_CALLBACK* pause)(struct _cef_download_item_callback_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItemCallback*, void> _Pause;

  /// <summary>
  /// Call to resume the download.
  /// <c>void(CEF_CALLBACK* resume)(struct _cef_download_item_callback_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItemCallback*, void> _Resume;

}
