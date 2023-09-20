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

  public static unsafe ref CefBrowserView Create(ref CefClient client, ref CefString url, ref CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref CefRequestContext requestContext, ref CefBrowserViewDelegate @delegate)
    => ref Unsafe.AsRef<CefBrowserView>(_Create(client.AsPointer(), url.AsPointer(), settings.AsPointer(), extraInfo.AsPointer(), requestContext.AsPointer(), @delegate.AsPointer()));

  /// <summary>
  /// Returns the BrowserView associated with |browser|.
  /// <c>CEF_EXPORT cef_browser_view_t* cef_browser_view_get_for_browser(struct _cef_browser_t* browser);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_browser_view_get_for_browser", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefBrowserView* _GetForBrowser(CefBrowser* browser);

  public static unsafe ref CefBrowserView GetForBrowser(ref CefBrowser browser)
    => ref Unsafe.AsRef<CefBrowserView>(_GetForBrowser(browser.AsPointer()));

  public CefView Base; // base @ 0, 440 bytes

  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserView*, CefBrowser*> _GetBrowser; // get_browser @ 440, 8 bytes

  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserView*, CefView*> _GetChromeToolbar; // get_chrome_toolbar @ 448, 8 bytes

  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserView*, int, void> _SetPreferAccelerators; // set_prefer_accelerators @ 456, 8 bytes

}

[PublicAPI]
public static class CefBrowserViewExtensions {

  /// <inheritdoc cref="CefBrowserView._Create"/>
  public static unsafe CefBrowser* GetBrowser(ref this CefBrowserView self)
    => self._GetBrowser(self.AsPointer());

  /// <inheritdoc cref="CefBrowserView._GetChromeToolbar"/>
  public static unsafe CefView* GetChromeToolbar(ref this CefBrowserView self)
    => self._GetChromeToolbar(self.AsPointer());

  /// <inheritdoc cref="CefBrowserView._SetPreferAccelerators"/>
  public static unsafe void SetPreferAccelerators(ref this CefBrowserView self, int preferAccelerators)
    => self._SetPreferAccelerators(self.AsPointer(), preferAccelerators);

}
