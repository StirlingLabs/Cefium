namespace Cefaloid;

public enum CefButtonState : int { // cef_button_state_t
  CefButtonStateNormal = 0, // CEF_BUTTON_STATE_NORMAL
  CefButtonStateHovered = 1, // CEF_BUTTON_STATE_HOVERED
  CefButtonStatePressed = 2, // CEF_BUTTON_STATE_PRESSED
  CefButtonStateDisabled = 3, // CEF_BUTTON_STATE_DISABLED
}