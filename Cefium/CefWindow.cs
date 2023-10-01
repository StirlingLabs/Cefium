namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 840)]
public struct CefWindow : ICefRefCountedBase<CefWindow> {

  // cef_window_t
  [DllImport("cef", EntryPoint = "cef_window_create_top_level", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefWindow* _CreateTopLevel(CefWindowDelegate* @delegate);

  public static unsafe CefWindow* CreateTopLevel(CefWindowDelegate* @delegate)
    => _CreateTopLevel(@delegate);

  public CefPanel Base; // base @ 0, 536 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _Show; // show @ 536, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefBrowserView*, void> _ShowAsBrowserModalDialog; // show_as_browser_modal_dialog @ 544, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _Hide; // hide @ 552, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefSize*, void> _CenterWindow; // center_window @ 560, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _Close; // close @ 568, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int> _IsClosed; // is_closed @ 576, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _Activate; // activate @ 584, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _Deactivate; // deactivate @ 592, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int> _IsActive; // is_active @ 600, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _BringToTop; // bring_to_top @ 608, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int, void> _SetAlwaysOnTop; // set_always_on_top @ 616, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int> _IsAlwaysOnTop; // is_always_on_top @ 624, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _Maximize; // maximize @ 632, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _Minimize; // minimize @ 640, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _Restore; // restore @ 648, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int, void> _SetFullscreen; // set_fullscreen @ 656, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int> _IsMaximized; // is_maximized @ 664, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int> _IsMinimized; // is_minimized @ 672, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int> _IsFullscreen; // is_fullscreen @ 680, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefString*, void> _SetTitle; // set_title @ 688, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefString*> _GetTitle; // get_title @ 696, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefImage*, void> _SetWindowIcon; // set_window_icon @ 704, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefImage*> _GetWindowIcon; // get_window_icon @ 712, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefImage*, void> _SetWindowAppIcon; // set_window_app_icon @ 720, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefImage*> _GetWindowAppIcon; // get_window_app_icon @ 728, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefView*, CefDockingMode, CefOverlayController*> _AddOverlayView; // add_overlay_view @ 736, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefMenuModel*, CefPoint*, CefMenuAnchorPosition, void> _ShowMenu; // show_menu @ 744, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _CancelMenu; // cancel_menu @ 752, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefDisplay*> _GetDisplay; // get_display @ 760, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefRect> _GetClientAreaBoundsInScreen; // get_client_area_bounds_in_screen @ 768, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, uint, CefDraggableRegion*, void> _SetDraggableRegions; // set_draggable_regions @ 776, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void*> _GetWindowHandle; // get_window_handle @ 784, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int, uint, void> _SendKeyPress; // send_key_press @ 792, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int, int, void> _SendMouseMove; // send_mouse_move @ 800, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, CefMouseButtonType, int, int, void> _SendMouseEvents; // send_mouse_events @ 808, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int, int, int, int, int, void> _SetAccelerator; // set_accelerator @ 816, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, int, void> _RemoveAccelerator; // remove_accelerator @ 824, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefWindow*, void> _RemoveAllAccelerators; // remove_all_accelerators @ 832, 8 bytes

}
