namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 120)]
public struct CefViewDelegate : ICefRefCountedBase<CefViewDelegate> {

  // cef_view_delegate_t
  public CefRefCountedBase Base; // base @ 0, 40 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, CefSize> _GetPreferredSize; // get_preferred_size @ 40, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, CefSize> _GetMinimumSize; // get_minimum_size @ 48, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, CefSize> _GetMaximumSize; // get_maximum_size @ 56, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, int, int> _GetHeightForWidth; // get_height_for_width @ 64, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, int, CefView*, void> _OnParentViewChanged; // on_parent_view_changed @ 72, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, int, CefView*, void> _OnChildViewChanged; // on_child_view_changed @ 80, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, int, void> _OnWindowChanged; // on_window_changed @ 88, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, CefRect*, void> _OnLayoutChanged; // on_layout_changed @ 96, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, void> _OnFocus; // on_focus @ 104, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefViewDelegate*, CefView*, void> _OnBlur; // on_blur @ 112, 8 bytes

}
