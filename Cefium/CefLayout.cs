namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=64)]
public struct CefLayout : ICefRefCountedBase<CefLayout> { // cef_layout_t
  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefLayout*,CefBoxLayout*> _AsBoxLayout; // as_box_layout @ 40, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefLayout*,CefFillLayout*> _AsFillLayout; // as_fill_layout @ 48, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefLayout*,int> _IsValid; // is_valid @ 56, 8 bytes
}
