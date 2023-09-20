namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=192)]
public struct CefOverlayController : ICefRefCountedBase<CefOverlayController> { // cef_overlay_controller_t
  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,int> _IsValid; // is_valid @ 40, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefOverlayController*,int> _IsSame; // is_same @ 48, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefView*> _GetContentsView; // get_contents_view @ 56, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefWindow*> _GetWindow; // get_window @ 64, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefDockingMode> _GetDockingMode; // get_docking_mode @ 72, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,void> _Destroy; // destroy @ 80, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefRect*,void> _SetBounds; // set_bounds @ 88, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefRect> _GetBounds; // get_bounds @ 96, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefRect> _GetBoundsInScreen; // get_bounds_in_screen @ 104, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefSize*,void> _SetSize; // set_size @ 112, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefSize> _GetSize; // get_size @ 120, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefPoint*,void> _SetPosition; // set_position @ 128, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefPoint> _GetPosition; // get_position @ 136, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefInsets*,void> _SetInsets; // set_insets @ 144, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,CefInsets> _GetInsets; // get_insets @ 152, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,void> _SizeToPreferredSize; // size_to_preferred_size @ 160, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,int,void> _SetVisible; // set_visible @ 168, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,int> _IsVisible; // is_visible @ 176, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefOverlayController*,int> _IsDrawn; // is_drawn @ 184, 8 bytes
}
