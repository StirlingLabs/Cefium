namespace Cefium;

/// <summary>
/// <c>cef_keyboard_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefKeyboardHandler : ICefRefCountedBase<CefKeyboardHandler> {

  /// <inheritdoc cref="CefKeyboardHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefKeyboardHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called before a keyboard event is sent to the renderer. |event| contains
  /// information about the keyboard event. |os_event| is the operating system
  /// event message, if any. Return true (1) if the event was handled or false
  /// (0) otherwise. If the event will be handled in on_key_event() as a
  /// keyboard shortcut set |is_keyboard_shortcut| to true (1) and return false
  /// (0).
  /// <c>int(CEF_CALLBACK* on_pre_key_event)(struct _cef_keyboard_handler_t* self, struct _cef_browser_t* browser, const cef_key_event_t* event, cef_event_handle_t os_event, int* is_keyboard_shortcut)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefKeyboardHandler*, CefBrowser*, CefKeyEvent*, nint, int*, int> _OnPreKeyEvent;

  /// <summary>
  /// Called after the renderer and JavaScript in the page has had a chance to
  /// handle the event. |event| contains information about the keyboard event.
  /// |os_event| is the operating system event message, if any. Return true (1)
  /// if the keyboard event was handled or false (0) otherwise.
  /// <c>int(CEF_CALLBACK* on_key_event)(struct _cef_keyboard_handler_t* self, struct _cef_browser_t* browser, const cef_key_event_t* event, cef_event_handle_t os_event)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefKeyboardHandler*, CefBrowser*, CefKeyEvent*, nint, int> _OnKeyEvent;

}
