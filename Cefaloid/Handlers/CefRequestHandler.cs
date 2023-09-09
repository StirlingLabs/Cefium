namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events related to browser requests. The
/// functions of this structure will be called on the thread indicated.
/// <c>cef_request_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRequestHandler : ICefRefCountedBase<CefRequestHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefRequestHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called on the UI thread before browser navigation. Return true (1) to
  /// cancel the navigation or false (0) to allow the navigation to proceed. The
  /// |request| object cannot be modified in this callback.
  /// cef_load_handler_t::OnLoadingStateChange will be called twice in all
  /// cases. If the navigation is allowed cef_load_handler_t::OnLoadStart and
  /// cef_load_handler_t::OnLoadEnd will be called. If the navigation is
  /// canceled cef_load_handler_t::OnLoadError will be called with an
  /// |errorCode| value of ERR_ABORTED. The |user_gesture| value will be true
  /// (1) if the browser navigated via explicit user gesture (e.g. clicking a
  /// link) or false (0) if it navigated automatically (e.g. via the
  /// DomContentLoaded event).
  /// <c>int(CEF_CALLBACK* on_before_browse)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_request_t* request, int user_gesture, int is_redirect)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, CefFrame*, CefRequest*, int, int, int> _OnBeforeBrowse;

  /// <summary>
  /// Called on the UI thread before OnBeforeBrowse in certain limited cases
  /// where navigating a new or different browser might be desirable. This
  /// includes user-initiated navigation that might open in a special way (e.g.
  /// links clicked via middle-click or ctrl + left-click) and certain types of
  /// cross-origin navigation initiated from the renderer process (e.g.
  /// navigating the top-level frame to/from a file URL). The |browser| and
  /// |frame| values represent the source of the navigation. The
  /// |target_disposition| value indicates where the user intended to navigate
  /// the browser based on standard Chromium behaviors (e.g. current tab, new
  /// tab, etc). The |user_gesture| value will be true (1) if the browser
  /// navigated via explicit user gesture (e.g. clicking a link) or false (0) if
  /// it navigated automatically (e.g. via the DomContentLoaded event). Return
  /// true (1) to cancel the navigation or false (0) to allow the navigation to
  /// proceed in the source browser's top-level frame.
  /// <c>int(CEF_CALLBACK* on_open_urlfrom_tab)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, const cef_string_t* target_url, cef_window_open_disposition_t target_disposition, int user_gesture)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, CefFrame*, CefString*, CefWindowOpenDisposition, int, int> _OnOpenUrlFromTab;

  /// <summary>
  /// Called on the browser process IO thread before a resource request is
  /// initiated. The |browser| and |frame| values represent the source of the
  /// request. |request| represents the request contents and cannot be modified
  /// in this callback. |is_navigation| will be true (1) if the resource request
  /// is a navigation. |is_download| will be true (1) if the resource request is
  /// a download. |request_initiator| is the origin (scheme + domain) of the
  /// page that initiated the request. Set |disable_default_handling| to true
  /// (1) to disable default handling of the request, in which case it will need
  /// to be handled via cef_resource_request_handler_t::GetResourceHandler or it
  /// will be canceled. To allow the resource load to proceed with default
  /// handling return NULL. To specify a handler for the resource return a
  /// cef_resource_request_handler_t object. If this callback returns NULL the
  /// same function will be called on the associated
  /// cef_request_context_handler_t, if any.
  /// <c>struct _cef_resource_request_handler_t*(CEF_CALLBACK* get_resource_request_handler)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_request_t* request, int is_navigation, int is_download, const cef_string_t* request_initiator, int* disable_default_handling)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, CefFrame*, CefRequest*, int, int, CefString*, int*, CefResourceRequestHandler*> _GetResourceRequestHandler;

  /// <summary>
  /// Called on the IO thread when the browser needs credentials from the user.
  /// |origin_url| is the origin making this authentication request. |isProxy|
  /// indicates whether the host is a proxy server. |host| contains the hostname
  /// and |port| contains the port number. |realm| is the realm of the challenge
  /// and may be NULL. |scheme| is the authentication scheme used, such as
  /// "basic" or "digest", and will be NULL if the source of the request is an
  /// FTP server. Return true (1) to continue the request and call
  /// cef_auth_callback_t::cont() either in this function or at a later time
  /// when the authentication information is available. Return false (0) to
  /// cancel the request immediately.
  /// <c>int(CEF_CALLBACK* get_auth_credentials)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* origin_url, int isProxy, const cef_string_t* host, int port, const cef_string_t* realm, const cef_string_t* scheme, struct _cef_auth_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, CefString*, int, CefString*, int, CefString*, CefString*, CefAuthCallback*, int> _GetAuthCredentials;

  /// <summary>
  /// Called on the UI thread to handle requests for URLs with an invalid SSL
  /// certificate. Return true (1) and call cef_callback_t functions either in
  /// this function or at a later time to continue or cancel the request. Return
  /// false (0) to cancel the request immediately. If
  /// cef_settings_t.ignore_certificate_errors is set all invalid certificates
  /// will be accepted without calling this function.
  /// <c>int(CEF_CALLBACK* on_certificate_error)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser, cef_errorcode_t cert_error, const cef_string_t* request_url, struct _cef_sslinfo_t* ssl_info, struct _cef_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, CefErrorCode, CefString*, CefSslInfo*, CefCallback*, int> _OnCertificateError;

  /// <summary>
  /// Called on the UI thread when a client certificate is being requested for
  /// authentication. Return false (0) to use the default behavior and
  /// automatically select the first certificate available. Return true (1) and
  /// call cef_select_client_certificate_callback_t::Select either in this
  /// function or at a later time to select a certificate. Do not call Select or
  /// call it with NULL to continue without using any certificate. |isProxy|
  /// indicates whether the host is an HTTPS proxy or the origin server. |host|
  /// and |port| contains the hostname and port of the SSL server.
  /// /// |certificates| is the list of certificates to choose from this list has
  /// already been pruned by Chromium so that it only contains certificates from
  /// issuers that the server trusts.
  /// <c>int(CEF_CALLBACK* on_select_client_certificate)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser, int isProxy, const cef_string_t* host, int port, size_t certificatesCount, struct _cef_x509certificate_t* const* certificates, struct _cef_select_client_certificate_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, int, CefString*, int, nuint, nint*, CefSelectClientCertificateCallback*, int> _OnSelectClientCertificate;

  /// <summary>
  /// Called on the browser process UI thread when the render view associated
  /// with |browser| is ready to receive/handle IPC messages in the render
  /// process.
  /// <c>void(CEF_CALLBACK* on_render_view_ready)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, void> _OnRenderViewReady;

  /// <summary>
  /// Called on the browser process UI thread when the render process terminates
  /// unexpectedly. |status| indicates how the process terminated.
  /// <c>void(CEF_CALLBACK* on_render_process_terminated)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser, cef_termination_status_t status)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, CefTerminationStatus, void> _OnRenderProcessTerminated;

  /// <summary>
  /// Called on the browser process UI thread when the window.document object of
  /// the main frame has been created.
  /// <c>void(CEF_CALLBACK* on_document_available_in_main_frame)(struct _cef_request_handler_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestHandler*, CefBrowser*, void> _OnDocumentAvailableInMainFrame;

}
