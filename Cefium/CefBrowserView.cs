namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 464)]
public struct CefBrowserView : ICefRefCountedBase<CefBrowserView> {

  // cef_browser_view_t

  /// <summary>
  /// Create a new BrowserView. The underlying cef_browser_t will not be created
  /// until this view is added to the views hierarchy. The optional |extra_info|
  /// parameter provides an opportunity to specify extra information specific to
  /// the created browser that will be passed to
  /// cef_render_process_handler_t::on_browser_created() in the render process.
  /// <c>CEF_EXPORT cef_browser_view_t* cef_browser_view_create(struct _cef_client_t* client, const cef_string_t* url, const struct _cef_browser_settings_t* settings, struct _cef_dictionary_value_t* extra_info, struct _cef_request_context_t* request_context, struct _cef_browser_view_delegate_t* delegate);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_browser_view_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefBrowserView* _Create(CefClient* client, CefString* url, CefBrowserSettings* settings, CefDictionaryValue* extraInfo, CefRequestContext* requestContext, CefBrowserViewDelegate* @delegate);

  public static unsafe CefBrowserView* Create(CefClient* client, ref CefString url, ref CefBrowserSettings settings, CefDictionaryValue* extraInfo, CefRequestContext* requestContext = null, CefBrowserViewDelegate* @delegate = null)
    => _Create(client, url.AsPointer(), settings.AsPointer(), extraInfo, requestContext, @delegate);

  /// <summary>
  /// Returns the BrowserView associated with |browser|.
  /// <c>CEF_EXPORT cef_browser_view_t* cef_browser_view_get_for_browser(struct _cef_browser_t* browser);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_browser_view_get_for_browser", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefBrowserView* _GetForBrowser(CefBrowser* browser);

  public static unsafe ref CefBrowserView GetForBrowser(ref CefBrowser browser)
    => ref Unsafe.AsRef<CefBrowserView>(_GetForBrowser(browser.AsPointer()));

  public CefView Base; // base @ 0, 440 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefBrowserView*, CefBrowser*> _GetBrowser; // get_browser @ 440, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefBrowserView*, CefView*> _GetChromeToolbar; // get_chrome_toolbar @ 448, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefBrowserView*, int, void> _SetPreferAccelerators; // set_prefer_accelerators @ 456, 8 bytes

}
