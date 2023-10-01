namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 136)]
public struct CefButtonDelegate : ICefRefCountedBase<CefButtonDelegate> {

  // cef_button_delegate_t
  public CefViewDelegate Base; // base @ 0, 120 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefButtonDelegate*, CefButton*, void> _OnButtonPressed; // on_button_pressed @ 120, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefButtonDelegate*, CefButton*, void> _OnButtonStateChanged; // on_button_state_changed @ 128, 8 bytes

}
