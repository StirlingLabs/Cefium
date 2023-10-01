namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 496)]
public struct CefScrollView : ICefRefCountedBase<CefScrollView> {

  // cef_scroll_view_t
  [DllImport("cef", EntryPoint = "cef_scroll_view_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefScrollView* _Create(CefViewDelegate* arg0);

  public CefView Base; // base @ 0, 440 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefScrollView*, CefView*, void> _SetContentView; // set_content_view @ 440, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefScrollView*, CefView*> _GetContentView; // get_content_view @ 448, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefScrollView*, CefRect> _GetVisibleContentRect; // get_visible_content_rect @ 456, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefScrollView*, int> _HasHorizontalScrollbar; // has_horizontal_scrollbar @ 464, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefScrollView*, int> _GetHorizontalScrollbarHeight; // get_horizontal_scrollbar_height @ 472, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefScrollView*, int> _HasVerticalScrollbar; // has_vertical_scrollbar @ 480, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefScrollView*, int> _GetVerticalScrollbarWidth; // get_vertical_scrollbar_width @ 488, 8 bytes

}
