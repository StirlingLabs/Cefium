namespace Cefaloid;

/// <summary>
/// Structure that creates cef_resource_handler_t instances for handling scheme
/// requests. The functions of this structure will always be called on the IO
/// thread.
/// <c>cef_scheme_handler_factory_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSchemeHandlerFactory : ICefRefCountedBase<CefSchemeHandlerFactory> {

  /// <inheritdoc cref="CefSchemeHandlerFactory"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefSchemeHandlerFactory() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Register a scheme handler factory with the global request context. An NULL
  /// |domain_name| value for a standard scheme will cause the factory to match
  /// all domain names. The |domain_name| value will be ignored for non-standard
  /// schemes. If |scheme_name| is a built-in scheme and no handler is returned by
  /// |factory| then the built-in scheme handler factory will be called. If
  /// |scheme_name| is a custom scheme then you must also implement the
  /// cef_app_t::on_register_custom_schemes() function in all processes. This
  /// function may be called multiple times to change or remove the factory that
  /// matches the specified |scheme_name| and optional |domain_name|. Returns
  /// false (0) if an error occurs. This function may be called on any thread in
  /// the browser process. Using this function is equivalent to calling cef_reques
  /// t_context_t::cef_request_context_get_global_context()->register_scheme_handl
  /// er_factory().
  /// <c>CEF_EXPORT int cef_register_scheme_handler_factory(const cef_string_t* scheme_name, const cef_string_t* domain_name, cef_scheme_handler_factory_t* factory);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_register_scheme_handler_factory", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe int _RegisterSchemeHandlerFactory(CefString* schemeName, CefString* domainName, CefSchemeHandlerFactory* factory);

  /// <inheritdoc cref="_RegisterSchemeHandlerFactory"/>
  public static unsafe bool RegisterSchemeHandlerFactory(ref CefString schemeName, ref CefString domainName, ref CefSchemeHandlerFactory factory)
    => _RegisterSchemeHandlerFactory(schemeName.AsPointer(), domainName.AsPointer(), factory.AsPointer()) != 0;

  /// <summary>
  /// Clear all scheme handler factories registered with the global request
  /// context. Returns false (0) on error. This function may be called on any
  /// thread in the browser process. Using this function is equivalent to calling
  /// cef_request_context_t::cef_request_context_get_global_context()->clear_schem
  /// e_handler_factories().
  /// <c>CEF_EXPORT int cef_clear_scheme_handler_factories(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_clear_scheme_handler_factories", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe int _ClearSchemeHandlerFactories();

  /// <inheritdoc cref="_ClearSchemeHandlerFactories"/>
  public static bool ClearSchemeHandlerFactories()
    => _ClearSchemeHandlerFactories() != 0;

  /// <summary>
  /// Return a new resource handler instance to handle the request or an NULL
  /// reference to allow default handling of the request. |browser| and |frame|
  /// will be the browser window and frame respectively that originated the
  /// request or NULL if the request did not originate from a browser window
  /// (for example, if the request came from cef_urlrequest_t). The |request|
  /// object passed to this function cannot be modified.
  /// <c>struct _cef_resource_handler_t*(CEF_CALLBACK* create)(struct _cef_scheme_handler_factory_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, const cef_string_t* scheme_name, struct _cef_request_t* request);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSchemeHandlerFactory*, CefBrowser*, CefFrame*, CefString*, CefRequest*, CefResourceHandler*> _Create;

}
