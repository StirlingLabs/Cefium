namespace Cefaloid;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=592)]
public struct CefMenuButton { // cef_menu_button_t

  [DllImport("cef", EntryPoint = "cef_menu_button_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefMenuButton* _Create(CefMenuButtonDelegate* arg0,CefString* arg1);

  public CefLabelButton Base; // base @ 0, 576 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefMenuButton*,CefMenuModel*,CefPoint*,CefMenuAnchorPosition,void> _ShowMenu; // show_menu @ 576, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefMenuButton*,void> _TriggerMenu; // trigger_menu @ 584, 8 bytes
}
