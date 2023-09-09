namespace Cefaloid;

/// <summary>
/// Structure used to make a URL request. URL requests are not associated with a
/// browser instance so no cef_client_t callbacks will be executed. URL requests
/// can be created on any valid CEF thread in either the browser or render
/// process. Once created the functions of the URL request object must be
/// accessed on the same thread that created it.
/// <c>cef_urlrequest_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefUrlRequest : ICefRefCountedBase<CefUrlRequest> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefUrlRequest() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new URL request that is not associated with a specific browser or
  /// frame. Use cef_frame_t::CreateURLRequest instead if you want the request to
  /// have this association, in which case it may be handled differently (see
  /// documentation on that function). A request created with this function may
  /// only originate from the browser process, and will behave as follows:
  ///   - It may be intercepted by the client via CefResourceRequestHandler or
  ///     CefSchemeHandlerFactory.
  ///   - POST data may only contain only a single element of type PDE_TYPE_FILE
  ///     or PDE_TYPE_BYTES.
  ///   - If |request_context| is empty the global request context will be used.
  ///
  /// The |request| object will be marked as read-only after calling this
  /// function.
  /// <c>CEF_EXPORT cef_urlrequest_t* cef_urlrequest_create(struct _cef_request_t* request, struct _cef_urlrequest_client_t* client, struct _cef_request_context_t* request_context)</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_urlrequest_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefUrlRequest* Create(CefRequest* request, CefUrlRequestClient* client, CefRequestContext* cefRequestContext);

  /// <summary>
  /// Returns the request object used to create this URL request. The returned
  /// object is read-only and should not be modified.
  /// <c>struct _cef_request_t*(CEF_CALLBACK* get_request)(struct _cef_urlrequest_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequest*, CefRequest*> _GetRequest;

  /// <summary>
  /// Returns the client.
  /// <c>struct _cef_urlrequest_client_t*(CEF_CALLBACK* get_client)(struct _cef_urlrequest_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequest*, CefUrlRequestClient*> _GetClient;

  /// <summary>
  /// Returns the request status.
  /// <c>cef_urlrequest_status_t(CEF_CALLBACK* get_request_status)(struct _cef_urlrequest_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequest*, CefUrlRequestStatus> _GetRequestStatus;

  /// <summary>
  /// Returns the request error if status is UR_CANCELED or UR_FAILED, or 0
  /// otherwise.
  /// <c>cef_errorcode_t(CEF_CALLBACK* get_request_error)(struct _cef_urlrequest_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequest*, CefErrorCode> _GetRequestError;

  /// <summary>
  /// Returns the response, or NULL if no response information is available.
  /// Response information will only be available after the upload has
  /// completed. The returned object is read-only and should not be modified.
  /// <c>struct _cef_response_t*(CEF_CALLBACK* get_response)(struct _cef_urlrequest_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequest*, CefResponse*> _GetResponse;

  /// <summary>
  /// Returns true (1) if the response body was served from the cache. This
  /// includes responses for which revalidation was required.
  /// <c>int(CEF_CALLBACK* response_was_cached)(struct _cef_urlrequest_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequest*, int> _ResponseWasCached;

  /// <summary>
  /// Cancel the request.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_urlrequest_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefUrlRequest*, void> _Cancel;

}
