namespace Cefaloid;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=272)]
public struct CefWindowDelegate { // cef_window_delegate_t
  public CefPanelDelegate Base; // base @ 0, 120 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,void> _OnWindowCreated; // on_window_created @ 120, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,void> _OnWindowClosing; // on_window_closing @ 128, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,void> _OnWindowDestroyed; // on_window_destroyed @ 136, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int,void> _OnWindowActivationChanged; // on_window_activation_changed @ 144, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,CefRect*,void> _OnWindowBoundsChanged; // on_window_bounds_changed @ 152, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int*,int*,CefWindow*> _GetParentWindow; // get_parent_window @ 160, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int> _IsWindowModalDialog; // is_window_modal_dialog @ 168, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,CefRect> _GetInitialBounds; // get_initial_bounds @ 176, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,CefShowState> _GetInitialShowState; // get_initial_show_state @ 184, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int> _IsFrameless; // is_frameless @ 192, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int> _WithStandardWindowButtons; // with_standard_window_buttons @ 200, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,float*,int> _GetTitlebarHeight; // get_titlebar_height @ 208, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int> _CanResize; // can_resize @ 216, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int> _CanMaximize; // can_maximize @ 224, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int> _CanMinimize; // can_minimize @ 232, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int> _CanClose; // can_close @ 240, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int,int> _OnAccelerator; // on_accelerator @ 248, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,CefKeyEvent*,int> _OnKeyEvent; // on_key_event @ 256, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWindowDelegate*,CefWindow*,int,void> _OnWindowFullscreenTransition; // on_window_fullscreen_transition @ 264, 8 bytes
}