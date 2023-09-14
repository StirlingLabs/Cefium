namespace Cefaloid;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=80)]
public struct CefBoxLayout { // cef_box_layout_t
  public CefLayout Base; // base @ 0, 64 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefBoxLayout*,CefView*,int,void> _SetFlexForView; // set_flex_for_view @ 64, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefBoxLayout*,CefView*,void> _ClearFlexForView; // clear_flex_for_view @ 72, 8 bytes
}