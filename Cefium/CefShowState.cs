namespace Cefium;

public enum CefShowState : int { // cef_show_state_t
  CefShowStateNormal = 1, // CEF_SHOW_STATE_NORMAL
  CefShowStateMinimized = 2, // CEF_SHOW_STATE_MINIMIZED
  CefShowStateMaximized = 3, // CEF_SHOW_STATE_MAXIMIZED
  CefShowStateFullscreen = 4, // CEF_SHOW_STATE_FULLSCREEN
}
