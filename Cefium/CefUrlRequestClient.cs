namespace Cefium;

/// <summary>
/// Structure that should be implemented by the cef_urlrequest_t client. The
/// functions of this structure will be called on the same thread that created
/// the request unless otherwise documented.
/// <c>cef_urlrequest_client_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefUrlRequestClient : ICefRefCountedBase<CefUrlRequestClient> {

  /// <inheritdoc cref="CefUrlRequestClient"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefUrlRequestClient() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Notifies the client that the request has completed. Use the
  /// cef_urlrequest_t::GetRequestStatus function to determine if the request
  /// was successful or not.
  /// <c>void(CEF_CALLBACK* on_request_complete)(struct _cef_urlrequest_client_t* self, struct _cef_urlrequest_t* request)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequestClient*, CefUrlRequest*, void> _OnRequestComplete;

  /// <summary>
  /// Notifies the client of upload progress. |current| denotes the number of
  /// bytes sent so far and |total| is the total size of uploading data (or -1
  /// if chunked upload is enabled). This function will only be called if the
  /// UR_FLAG_REPORT_UPLOAD_PROGRESS flag is set on the request.
  /// <c>void(CEF_CALLBACK* on_upload_progress)(struct _cef_urlrequest_client_t* self, struct _cef_urlrequest_t* request, int64 current, int64 total)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequestClient*, CefUrlRequest*, long, long, void> _OnUploadProgress;

  /// <summary>
  /// Notifies the client of download progress. |current| denotes the number of
  /// bytes received up to the call and |total| is the expected total size of
  /// the response (or -1 if not determined).
  /// <c>void(CEF_CALLBACK* on_download_progress)(struct _cef_urlrequest_client_t* self, struct _cef_urlrequest_t* request, int64 current, int64 total)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequestClient*, CefUrlRequest*, long, long, void> _OnDownloadProgress;

  /// <summary>
  /// Called when some part of the response is read. |data| contains the current
  /// bytes received since the last call. This function will not be called if
  /// the UR_FLAG_NO_DOWNLOAD_DATA flag is set on the request.
  /// <c>void(CEF_CALLBACK* on_download_data)(struct _cef_urlrequest_client_t* self, struct _cef_urlrequest_t* request, const void* data, size_t data_length)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequestClient*, CefUrlRequest*, void*, nuint, void> _OnDownloadData;

  /// <summary>
  /// Called on the IO thread when the browser needs credentials from the user.
  /// |isProxy| indicates whether the host is a proxy server. |host| contains
  /// the hostname and |port| contains the port number. Return true (1) to
  /// continue the request and call cef_auth_callback_t::cont() when the
  /// authentication information is available. If the request has an associated
  /// browser/frame then returning false (0) will result in a call to
  /// GetAuthCredentials on the cef_request_handler_t associated with that
  /// browser, if any. Otherwise, returning false (0) will cancel the request
  /// immediately. This function will only be called for requests initiated from
  /// the browser process.
  /// <c>int(CEF_CALLBACK* get_auth_credentials)(struct _cef_urlrequest_client_t* self, int isProxy, const cef_string_t* host, int port, const cef_string_t* realm, const cef_string_t* scheme, struct _cef_auth_callback_t* callback)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequestClient*, int, CefString*, int, CefString*, CefString*, CefAuthCallback*, int> _GetAuthCredentials;

}
