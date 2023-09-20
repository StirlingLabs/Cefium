namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=168)]
public struct CefBrowserViewDelegate { // cef_browser_view_delegate_t
  public CefViewDelegate Base; // base @ 0, 120 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserViewDelegate*,CefBrowserView*,CefBrowser*,void> _OnBrowserCreated; // on_browser_created @ 120, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserViewDelegate*,CefBrowserView*,CefBrowser*,void> _OnBrowserDestroyed; // on_browser_destroyed @ 128, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserViewDelegate*,CefBrowserView*,CefBrowserSettings*,CefClient*,int,CefBrowserViewDelegate*> _GetDelegateForPopupBrowserView; // get_delegate_for_popup_browser_view @ 136, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserViewDelegate*,CefBrowserView*,CefBrowserView*,int,int> _OnPopupBrowserViewCreated; // on_popup_browser_view_created @ 144, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserViewDelegate*,CefChromeToolbarType> _GetChromeToolbarType; // get_chrome_toolbar_type @ 152, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefBrowserViewDelegate*,CefBrowserView*,CefGestureCommand,int> _OnGestureCommand; // on_gesture_command @ 160, 8 bytes
}
