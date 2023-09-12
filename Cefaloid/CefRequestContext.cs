namespace Cefaloid;

/// <summary>
/// A request context provides request handling for a set of related browser or
/// URL request objects. A request context can be specified when creating a new
/// browser via the cef_browser_host_t static factory functions or when creating
/// a new URL request via the cef_urlrequest_t static factory functions. Browser
/// objects with different request contexts will never be hosted in the same
/// render process. Browser objects with the same request context may or may not
/// be hosted in the same render process depending on the process model. Browser
/// objects created indirectly via the JavaScript window.open function or
/// targeted links will share the same render process and the same request
/// context as the source browser. When running in single-process mode there is
/// only a single render process (the main process) and so all browsers created
/// in single-process mode will share the same request context. This will be the
/// first request context passed into a cef_browser_host_t static factory
/// function and all other request context objects will be ignored.
/// <c>cef_request_context_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRequestContext : ICefRefCountedBase<CefRequestContext> {

  /// <inheritdoc cref="CefRequestContext"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefRequestContext() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefPreferenceManager Base;

  /// <summary>
  /// Returns the global context object.
  /// <c>CEF_EXPORT cef_request_context_t* cef_request_context_get_global_context(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_request_context_get_global_context", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefRequestContext* GetGlobalContext();

  /// <summary>
  /// Creates a new context object with the specified |settings| and optional
  /// |handler|.
  /// <c>CEF_EXPORT cef_request_context_t* cef_request_context_create_context(const struct _cef_request_context_settings_t* settings, struct _cef_request_context_handler_t* handler);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_request_context_create_context", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefRequestContext* CreateContext(CefRequestContextSettings* settings, CefRequestContextHandler* handler);

  /// <summary>
  /// Creates a new context object that shares storage with |other| and uses an
  /// optional |handler|.
  /// <c>CEF_EXPORT cef_request_context_t* cef_create_context_shared(cef_request_context_t* other, struct _cef_request_context_handler_t* handler);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_create_context_shared", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefRequestContext* CreateContextShared(CefRequestContext* other, CefRequestContextHandler* handler);

  /// <summary>
  /// Returns true (1) if this object is pointing to the same context as |that|
  /// object.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_request_context_t* self, struct _cef_request_context_t* other);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefRequestContext*, int> _IsSame;

  /// <summary>
  /// Returns true (1) if this object is sharing the same storage as |that|
  /// object.
  /// <c>int(CEF_CALLBACK* is_sharing_with)(struct _cef_request_context_t* self, struct _cef_request_context_t* other);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefRequestContext*, int> _IsSharingWith;

  /// <summary>
  /// Returns true (1) if this object is the global context. The global context
  /// is used by default when creating a browser or URL request with a NULL
  /// context argument.
  /// <c>int(CEF_CALLBACK* is_global)(struct _cef_request_context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, int> _IsGlobal;

  /// <summary>
  /// Returns the handler for this context if any.
  /// <c>struct _cef_request_context_handler_t*(CEF_CALLBACK* get_handler)(struct _cef_request_context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefRequestContextHandler*> _GetHandler;

  /// <summary>
  /// Returns the cache path for this object. If NULL an "incognito mode" in-
  /// memory cache is being used.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_cache_path)(struct _cef_request_context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefStringUserFree*> _GetCachePath;

  /// <summary>
  /// Returns the cookie manager for this object. If |callback| is non-NULL it
  /// will be executed asnychronously on the UI thread after the manager's
  /// storage has been initialized.
  /// <c>struct _cef_cookie_manager_t*(CEF_CALLBACK* get_cookie_manager)(struct _cef_request_context_t* self, struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefCompletionCallback*, CefCookieManager*> _GetCookieManager;

  /// <summary>
  /// Register a scheme handler factory for the specified |scheme_name| and
  /// optional |domain_name|. An NULL |domain_name| value for a standard scheme
  /// will cause the factory to match all domain names. The |domain_name| value
  /// will be ignored for non-standard schemes. If |scheme_name| is a built-in
  /// scheme and no handler is returned by |factory| then the built-in scheme
  /// handler factory will be called. If |scheme_name| is a custom scheme then
  /// you must also implement the cef_app_t::on_register_custom_schemes()
  /// function in all processes. This function may be called multiple times to
  /// change or remove the factory that matches the specified |scheme_name| and
  /// optional |domain_name|. Returns false (0) if an error occurs. This
  /// function may be called on any thread in the browser process.
  /// <c>int(CEF_CALLBACK* register_scheme_handler_factory)(struct _cef_request_context_t* self, const cef_string_t* scheme_name, const cef_string_t* domain_name, struct _cef_scheme_handler_factory_t* factory);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefString*, CefString*, CefSchemeHandlerFactory*, int> _RegisterSchemeHandlerFactory;

  /// <summary>
  /// Clear all registered scheme handler factories. Returns false (0) on error.
  /// This function may be called on any thread in the browser process.
  /// <c>int(CEF_CALLBACK* clear_scheme_handler_factories)(struct _cef_request_context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, int> _ClearSchemeHandlerFactories;

  /// <summary>
  /// Clears all certificate exceptions that were added as part of handling
  /// cef_request_handler_t::on_certificate_error(). If you call this it is
  /// recommended that you also call close_all_connections() or you risk not
  /// being prompted again for server certificates if you reconnect quickly. If
  /// |callback| is non-NULL it will be executed on the UI thread after
  /// completion.
  /// <c>void(CEF_CALLBACK* clear_certificate_exceptions)(struct _cef_request_context_t* self, struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefCompletionCallback*, void> _ClearCertificateExceptions;

  /// <summary>
  /// Clears all HTTP authentication credentials that were added as part of
  /// handling GetAuthCredentials. If |callback| is non-NULL it will be executed
  /// on the UI thread after completion.
  /// <c>void(CEF_CALLBACK* clear_http_auth_credentials)(struct _cef_request_context_t* self, struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefCompletionCallback*, void> _ClearHttpAuthCredentials;

  /// <summary>
  /// Clears all active and idle connections that Chromium currently has. This
  /// is only recommended if you have released all other CEF objects but don't
  /// yet want to call cef_shutdown(). If |callback| is non-NULL it will be
  /// executed on the UI thread after completion.
  /// <c>void(CEF_CALLBACK* close_all_connections)(struct _cef_request_context_t* self, struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefCompletionCallback*, void> _CloseAllConnections;

  /// <summary>
  /// Attempts to resolve |origin| to a list of associated IP addresses.
  /// |callback| will be executed on the UI thread after completion.
  /// <c>void(CEF_CALLBACK* resolve_host)(struct _cef_request_context_t* self, const cef_string_t* origin, struct _cef_resolve_callback_t* callback);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefString*, CefResolveCallback*, void> _ResolveHost;

  /// <summary>
  /// Load an extension.
  ///
  /// If extension resources will be read from disk using the default load
  /// implementation then |root_directory| should be the absolute path to the
  /// extension resources directory and |manifest| should be NULL. If extension
  /// resources will be provided by the client (e.g. via cef_request_handler_t
  /// and/or cef_extension_handler_t) then |root_directory| should be a path
  /// component unique to the extension (if not absolute this will be internally
  /// prefixed with the PK_DIR_RESOURCES path) and |manifest| should contain the
  /// contents that would otherwise be read from the "manifest.json" file on
  /// disk.
  ///
  /// The loaded extension will be accessible in all contexts sharing the same
  /// storage (HasExtension returns true (1)). However, only the context on
  /// which this function was called is considered the loader (DidLoadExtension
  /// returns true (1)) and only the loader will receive
  /// cef_request_context_handler_t callbacks for the extension.
  ///
  /// cef_extension_handler_t::OnExtensionLoaded will be called on load success
  /// or cef_extension_handler_t::OnExtensionLoadFailed will be called on load
  /// failure.
  ///
  /// If the extension specifies a background script via the "background"
  /// manifest key then cef_extension_handler_t::OnBeforeBackgroundBrowser will
  /// be called to create the background browser. See that function for
  /// additional information about background scripts.
  ///
  /// For visible extension views the client application should evaluate the
  /// manifest to determine the correct extension URL to load and then pass that
  /// URL to the cef_browser_host_t::CreateBrowser* function after the extension
  /// has loaded. For example, the client can look for the "browser_action"
  /// manifest key as documented at
  /// https://developer.chrome.com/extensions/browserAction. Extension URLs take
  /// the form "chrome-extension://&lt;extension_id>/&lt;path>".
  ///
  /// Browsers that host extensions differ from normal browsers as follows:
  ///  - Can access chrome.* JavaScript APIs if allowed by the manifest. Visit
  ///    chrome://extensions-support for the list of extension APIs currently
  ///    supported by CEF.
  ///  - Main frame navigation to non-extension content is blocked.
  ///  - Pinch-zooming is disabled.
  ///  - CefBrowserHost::GetExtension returns the hosted extension.
  ///  - CefBrowserHost::IsBackgroundHost returns true for background hosts.
  ///
  /// See https://developer.chrome.com/extensions for extension implementation
  /// and usage documentation.
  /// <c>void(CEF_CALLBACK* load_extension)(struct _cef_request_context_t* self, const cef_string_t* root_directory, struct _cef_dictionary_value_t* manifest, struct _cef_extension_handler_t* handler);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefString*, CefDictionaryValue*, CefExtensionHandler*, void> _LoadExtension;

  /// <summary>
  /// Returns true (1) if this context was used to load the extension identified
  /// by |extension_id|. Other contexts sharing the same storage will also have
  /// access to the extension (see HasExtension). This function must be called
  /// on the browser process UI thread.
  /// <c>int(CEF_CALLBACK* did_load_extension)(struct _cef_request_context_t* self, const cef_string_t* extension_id);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefString*, int> _DidLoadExtension;

  /// <summary>
  /// Returns true (1) if this context has access to the extension identified by
  /// |extension_id|. This may not be the context that was used to load the
  /// extension (see DidLoadExtension). This function must be called on the
  /// browser process UI thread.
  /// <c>int(CEF_CALLBACK* has_extension)(struct _cef_request_context_t* self, const cef_string_t* extension_id);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefString*, int> _HasExtension;

  /// <summary>
  /// Retrieve the list of all extensions that this context has access to (see
  /// HasExtension). |extension_ids| will be populated with the list of
  /// extension ID values. Returns true (1) on success. This function must be
  /// called on the browser process UI thread.
  /// <c>int(CEF_CALLBACK* get_extensions)(struct _cef_request_context_t* self, cef_string_list_t extension_ids);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefStringList*, int> _GetExtensions;

  /// <summary>
  /// Returns the extension matching |extension_id| or NULL if no matching
  /// extension is accessible in this context (see HasExtension). This function
  /// must be called on the browser process UI thread.
  /// <c>struct _cef_extension_t*(CEF_CALLBACK* get_extension)(struct _cef_request_context_t* self, const cef_string_t* extension_id);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefString*, CefExtension*> _GetExtension;

  /// <summary>
  /// Returns the MediaRouter object associated with this context.  If
  /// |callback| is non-NULL it will be executed asnychronously on the UI thread
  /// after the manager's context has been initialized.
  /// <c>struct _cef_media_router_t*(CEF_CALLBACK* get_media_router)(struct _cef_request_context_t* self, struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequestContext*, CefCompletionCallback*, CefMediaRouter*> _GetMediaRouter;

  /// <summary>
  /// Returns the current value for |content_type| that applies for the
  /// specified URLs. If both URLs are NULL the default value will be returned.
  /// Returns nullptr if no value is configured. Must be called on the browser
  /// process UI thread.
  /// <c>struct _cef_value_t*(CEF_CALLBACK* get_website_setting)(struct _cef_request_context_t* self, const cef_string_t* requesting_url, const cef_string_t* top_level_url, cef_content_setting_types_t content_type);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Cdecl]<CefRequestContext*, CefString*, CefString*, CefContentSettingTypes, CefValue*> _GetWebsiteSetting;

  /// <summary>
  /// Sets the current value for |content_type| for the specified URLs in the
  /// default scope. If both URLs are NULL, and the context is not incognito,
  /// the default value will be set. Pass nullptr for |value| to remove the
  /// default value for this content type.
  ///
  /// WARNING: Incorrect usage of this function may cause instability or
  /// security issues in Chromium. Make sure that you first understand the
  /// potential impact of any changes to |content_type| by reviewing the related
  /// source code in Chromium. For example, if you plan to modify
  /// CEF_CONTENT_SETTING_TYPE_POPUPS, first review and understand the usage of
  /// ContentSettingsType::POPUPS in Chromium:
  /// https://source.chromium.org/search?q=ContentSettingsType::POPUPS
  /// <c>void(CEF_CALLBACK* set_website_setting)(struct _cef_request_context_t* self, const cef_string_t* requesting_url, const cef_string_t* top_level_url, cef_content_setting_types_t content_type, struct _cef_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Cdecl]<CefRequestContext*, CefString*, CefString*, CefContentSettingTypes, CefValue*, void> _SetWebsiteSetting;

  /// <summary>
  /// Returns the current value for |content_type| that applies for the
  /// specified URLs. If both URLs are NULL the default value will be returned.
  /// Returns CEF_CONTENT_SETTING_VALUE_DEFAULT if no value is configured. Must
  /// be called on the browser process UI thread.
  /// <c>cef_content_setting_values_t(CEF_CALLBACK* get_content_setting)(struct _cef_request_context_t* self, const cef_string_t* requesting_url, const cef_string_t* top_level_url, cef_content_setting_types_t content_type);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Cdecl]<CefRequestContext*, CefString*, CefString*, CefContentSettingTypes, CefContentSettingValues> _GetContentSetting;

  /// <summary>
  /// Sets the current value for |content_type| for the specified URLs in the
  /// default scope. If both URLs are NULL, and the context is not incognito,
  /// the default value will be set. Pass CEF_CONTENT_SETTING_VALUE_DEFAULT for
  /// |value| to use the default value for this content type.
  ///
  /// WARNING: Incorrect usage of this function may cause instability or
  /// security issues in Chromium. Make sure that you first understand the
  /// potential impact of any changes to |content_type| by reviewing the related
  /// source code in Chromium. For example, if you plan to modify
  /// CEF_CONTENT_SETTING_TYPE_POPUPS, first review and understand the usage of
  /// ContentSettingsType::POPUPS in Chromium:
  /// https://source.chromium.org/search?q=ContentSettingsType::POPUPS
  /// <c>void(CEF_CALLBACK* set_content_setting)(struct _cef_request_context_t* self, const cef_string_t* requesting_url, const cef_string_t* top_level_url, cef_content_setting_types_t content_type, cef_content_setting_values_t value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Cdecl]<CefRequestContext*, CefString*, CefString*, CefContentSettingTypes, CefContentSettingValues, void> _SetContentSetting;

}
