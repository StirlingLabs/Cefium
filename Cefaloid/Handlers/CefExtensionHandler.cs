namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events related to browser extensions. The
/// functions of this structure will be called on the UI thread. See
/// cef_request_context_t::LoadExtension for information about extension
/// loading.
/// <c>cef_extension_handler_t</c>
/// </summary>
/// <seealso cref="CefExtensionHandlerExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefExtensionHandler : ICefRefCountedBase<CefExtensionHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefExtensionHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called if the cef_request_context_t::LoadExtension request fails. |result|
  /// will be the error code.
  /// <c>void(CEF_CALLBACK* on_extension_load_failed)(struct _cef_extension_handler_t* self, cef_errorcode_t result);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtensionHandler*, CefErrorCode, void> _OnExtensionLoadFailed;

  /// <summary>
  /// Called if the cef_request_context_t::LoadExtension request succeeds.
  /// |extension| is the loaded extension.
  /// <c>void(CEF_CALLBACK* on_extension_loaded)(struct _cef_extension_handler_t* self, struct _cef_extension_t* extension);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtensionHandler*, CefExtension*, void> _OnExtensionLoaded;

  /// <summary>
  /// Called after the cef_extension_t::Unload request has completed.
  /// <c>void(CEF_CALLBACK* on_extension_unloaded)(struct _cef_extension_handler_t* self, struct _cef_extension_t* extension);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtensionHandler*, CefExtension*, void> _OnExtensionUnloaded;

  /// <summary>
  /// Called when an extension needs a browser to host a background script
  /// specified via the "background" manifest key. The browser will have no
  /// visible window and cannot be displayed. |extension| is the extension that
  /// is loading the background script. |url| is an internally generated
  /// reference to an HTML page that will be used to load the background script
  /// via a "&lt;script&gt;" src attribute. To allow creation of the browser
  /// optionally modify |client| and |settings| and return false (0). To cancel
  /// creation of the browser (and consequently cancel load of the background
  /// script) return true (1). Successful creation will be indicated by a call
  /// to cef_life_span_handler_t::OnAfterCreated, and
  /// cef_browser_host_t::IsBackgroundHost will return true (1) for the
  /// resulting browser. See https://developer.chrome.com/extensions/event_pages
  /// for more information about extension background script usage.
  /// <c>int(CEF_CALLBACK* on_before_background_browser)(struct _cef_extension_handler_t* self, struct _cef_extension_t* extension, const cef_string_t* url, struct _cef_client_t** client, struct _cef_browser_settings_t* settings);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtensionHandler*, CefExtension*, CefString*, CefClient**, CefBrowserSettings*, int> _OnBeforeBackgroundBrowser;

  /// <summary>
  /// Called when an extension API (e.g. chrome.tabs.create) requests creation
  /// of a new browser. |extension| and |browser| are the source of the API
  /// call. |active_browser| may optionally be specified via the windowId
  /// property or returned via the get_active_browser() callback and provides
  /// the default |client| and |settings| values for the new browser. |index| is
  /// the position value optionally specified via the index property. |url| is
  /// the URL that will be loaded in the browser. |active| is true (1) if the
  /// new browser should be active when opened.  To allow creation of the
  /// browser optionally modify |windowInfo|, |client| and |settings| and return
  /// false (0). To cancel creation of the browser return true (1). Successful
  /// creation will be indicated by a call to
  /// cef_life_span_handler_t::OnAfterCreated. Any modifications to |windowInfo|
  /// will be ignored if |active_browser| is wrapped in a cef_browser_view_t.
  /// <c>int(CEF_CALLBACK* on_before_browser)(struct _cef_extension_handler_t* self, struct _cef_extension_t* extension, struct _cef_browser_t* browser, struct _cef_browser_t* active_browser, int index, const cef_string_t* url, int active, struct _cef_window_info_t* windowInfo, struct _cef_client_t** client, struct _cef_browser_settings_t* settings);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtensionHandler*, CefExtension*, CefBrowser*, CefBrowser*, int, CefString*, int, CefWindowInfo*, CefClient**, CefBrowserSettings*, int>
    _OnBeforeBrowser;

  /// <summary>
  /// Called when no tabId is specified to an extension API call that accepts a
  /// tabId parameter (e.g. chrome.tabs.*). |extension| and |browser| are the
  /// source of the API call. Return the browser that will be acted on by the
  /// API call or return NULL to act on |browser|. The returned browser must
  /// share the same cef_request_context_t as |browser|. Incognito browsers
  /// should not be considered unless the source extension has incognito access
  /// enabled, in which case |include_incognito| will be true (1).
  /// <c>struct _cef_browser_t*(CEF_CALLBACK* get_active_browser)(struct _cef_extension_handler_t* self, struct _cef_extension_t* extension, struct _cef_browser_t* browser, int include_incognito);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtensionHandler*, CefExtension*, CefBrowser*, int, CefBrowser*> _GetActiveBrowser;

  /// <summary>
  /// Called when the tabId associated with |target_browser| is specified to an
  /// extension API call that accepts a tabId parameter (e.g. chrome.tabs.*).
  /// |extension| and |browser| are the source of the API call. Return true (1)
  /// to allow access of false (0) to deny access. Access to incognito browsers
  /// should not be allowed unless the source extension has incognito access
  /// enabled, in which case |include_incognito| will be true (1).
  /// <c>int(CEF_CALLBACK* can_access_browser)(struct _cef_extension_handler_t* self, struct _cef_extension_t* extension, struct _cef_browser_t* browser, int include_incognito, struct _cef_browser_t* target_browser);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtensionHandler*, CefExtension*, CefBrowser*, int, CefBrowser*, int> _CanAccessBrowser;

  /// <summary>
  /// Called to retrieve an extension resource that would normally be loaded
  /// from disk (e.g. if a file parameter is specified to
  /// chrome.tabs.executeScript). |extension| and |browser| are the source of
  /// the resource request. |file| is the requested relative file path. To
  /// handle the resource request return true (1) and execute |callback| either
  /// synchronously or asynchronously. For the default behavior which reads the
  /// resource from the extension directory on disk return false (0).
  /// Localization substitutions will not be applied to resources handled via
  /// this function.
  /// <c>int(CEF_CALLBACK* get_extension_resource)(struct _cef_extension_handler_t* self, struct _cef_extension_t* extension, struct _cef_browser_t* browser, const cef_string_t* file, struct _cef_get_extension_resource_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtensionHandler*, CefExtension*, CefBrowser*, CefString*, CefGetExtensionResourceCallback*, int> _GetExtensionResource;

}
