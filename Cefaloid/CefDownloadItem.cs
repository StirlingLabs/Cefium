namespace Cefaloid;

/// <summary>
/// Structure used to represent a download item.
/// <c>cef_download_item_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDownloadItem : ICefRefCountedBase<CefDownloadItem> {

  /// <inheritdoc cref="CefDownloadItem"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDownloadItem() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns true (1) if this object is valid. Do not call any other functions
  /// if this function returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, int> _IsValid;

  /// <summary>
  /// Returns true (1) if the download is in progress.
  /// <c>int(CEF_CALLBACK* is_in_progress)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, int> _IsInProgress;

  /// <summary>
  /// Returns true (1) if the download is complete.
  /// <c>int(CEF_CALLBACK* is_complete)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, int> _IsComplete;

  /// <summary>
  /// Returns true (1) if the download has been canceled or interrupted.
  /// <c>int(CEF_CALLBACK* is_canceled)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, int> _IsCanceled;

  /// <summary>
  /// Returns a simple speed estimate in bytes/s.
  /// <c>int64(CEF_CALLBACK* get_current_speed)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, long> _GetCurrentSpeed;

  /// <summary>
  /// Returns the rough percent complete or -1 if the receive total size is
  /// unknown.
  /// <c>int(CEF_CALLBACK* get_percent_complete)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, int> _GetPercentComplete;

  /// <summary>
  /// Returns the total number of bytes.
  /// <c>int64(CEF_CALLBACK* get_total_bytes)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, long> _GetTotalBytes;

  /// <summary>
  /// Returns the number of received bytes.
  /// <c>int64(CEF_CALLBACK* get_received_bytes)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, long> _GetReceivedBytes;

  /// <summary>
  /// Returns the time that the download started.
  /// <c>cef_basetime_t(CEF_CALLBACK* get_start_time)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, CefBaseTime> _GetStartTime;

  /// <summary>
  /// Returns the time that the download ended.
  /// <c>cef_basetime_t(CEF_CALLBACK* get_end_time)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, CefBaseTime> _GetEndTime;

  /// <summary>
  /// Returns the full path to the downloaded or downloading file.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_full_path)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, CefStringUserFree*> _GetFullPath;

  /// <summary>
  /// Returns the unique identifier for this download.
  /// <c>uint32(CEF_CALLBACK* get_id)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, uint> _GetId;

  /// <summary>
  /// Returns the URL.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_url)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, CefStringUserFree*> _GetUrl;

  /// <summary>
  /// Returns the original URL before any redirections.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_original_url)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, CefStringUserFree*> _GetOriginalUrl;

  /// <summary>
  /// Returns the suggested file name.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_suggested_file_name)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, CefStringUserFree*> _GetSuggestedFileName;

  /// <summary>
  /// Returns the content disposition.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_content_disposition)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, CefStringUserFree*> _GetContentDisposition;

  /// <summary>
  /// Returns the mime type.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_mime_type)(struct _cef_download_item_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDownloadItem*, CefStringUserFree*> _GetMimeType;

}
