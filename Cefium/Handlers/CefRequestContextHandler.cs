namespace Cefium;

/// <summary>
/// Implement this structure to provide handler implementations. The handler
/// instance will not be released until all objects related to the context have
/// been destroyed.
/// <c>cef_request_context_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRequestContextHandler : ICefRefCountedBase<CefRequestContextHandler> {

  /// <inheritdoc cref="CefRequestContextHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefRequestContextHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called on the browser process UI thread immediately after the request
  /// context has been initialized.
  /// <c>void(CEF_CALLBACK* on_request_context_initialized)(struct _cef_request_context_handler_t* self, struct _cef_request_context_t* request_context);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContextHandler*, CefRequestContext*, void> _OnRequestContextInitialized;

  /// <summary>
  /// Called on the browser process IO thread before a resource request is
  /// initiated. The |browser| and |frame| values represent the source of the
  /// request, and may be NULL for requests originating from service workers or
  /// cef_urlrequest_t. |request| represents the request contents and cannot be
  /// modified in this callback. |is_navigation| will be true (1) if the
  /// resource request is a navigation. |is_download| will be true (1) if the
  /// resource request is a download. |request_initiator| is the origin (scheme
  /// + domain) of the page that initiated the request. Set
  /// |disable_default_handling| to true (1) to disable default handling of the
  /// request, in which case it will need to be handled via
  /// cef_resource_request_handler_t::GetResourceHandler or it will be canceled.
  /// To allow the resource load to proceed with default handling return NULL.
  /// To specify a handler for the resource return a
  /// cef_resource_request_handler_t object. This function will not be called if
  /// the client associated with |browser| returns a non-NULL value from
  /// cef_request_handler_t::GetResourceRequestHandler for the same request
  /// (identified by cef_request_t::GetIdentifier).
  /// <c>struct _cef_resource_request_handler_t*(CEF_CALLBACK* get_resource_request_handler)(struct _cef_request_context_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_request_t* request, int is_navigation, int is_download, const cef_string_t* request_initiator, int* disable_default_handling);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContextHandler*, CefBrowser*, CefFrame*, CefRequest*, int, int, CefString*, int*, CefResourceRequestHandler*> _GetResourceRequestHandler;

}
