namespace Cefaloid;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=144)]
public struct CefMenuButtonDelegate { // cef_menu_button_delegate_t
  public CefButtonDelegate Base; // base @ 0, 136 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefMenuButtonDelegate*,CefMenuButton*,CefPoint*,CefMenuButtonPressedLock*,void> _OnMenuButtonPressed; // on_menu_button_pressed @ 136, 8 bytes
}