namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=136)]
public struct CefTextfieldDelegate { // cef_textfield_delegate_t
  public CefViewDelegate Base; // base @ 0, 120 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextfieldDelegate*,CefTextField*,CefKeyEvent*,int> _OnKeyEvent; // on_key_event @ 120, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextfieldDelegate*,CefTextField*,void> _OnAfterUserAction; // on_after_user_action @ 128, 8 bytes
}
