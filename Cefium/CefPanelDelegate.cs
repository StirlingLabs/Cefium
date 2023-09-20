namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=120)]
public struct CefPanelDelegate { // cef_panel_delegate_t
  public CefViewDelegate Base; // base @ 0, 120 bytes
}
