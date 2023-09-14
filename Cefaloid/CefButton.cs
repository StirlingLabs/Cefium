namespace Cefaloid;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=488)]
public struct CefButton { // cef_button_t
  public CefView Base; // base @ 0, 440 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefButton*,CefLabelButton*> _AsLabelButton; // as_label_button @ 440, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefButton*,CefButtonState,void> _SetState; // set_state @ 448, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefButton*,CefButtonState> _GetState; // get_state @ 456, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefButton*,int,void> _SetInkDropEnabled; // set_ink_drop_enabled @ 464, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefButton*,CefString*,void> _SetTooltipText; // set_tooltip_text @ 472, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefButton*,CefString*,void> _SetAccessibleName; // set_accessible_name @ 480, 8 bytes
}