namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events related to focus. The functions of
/// this structure will be called on the UI thread.
/// <c>cef_focus_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefFocusHandler : ICefRefCountedBase<CefFocusHandler> {

  /// <inheritdoc cref="CefFocusHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefFocusHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called when the browser component is about to loose focus. For instance, /// if focus was on the last HTML element and the user pressed the TAB key.
  /// |next| will be true (1) if the browser is giving focus to the next
  /// component and false (0) if the browser is giving focus to the previous
  /// component.
  /// <c>void(CEF_CALLBACK* on_take_focus)(struct _cef_focus_handler_t* self, struct _cef_browser_t* browser, int next)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFocusHandler*, CefBrowser*, int, void> _OnTakeFocus;

  /// <summary>
  /// Called when the browser component is requesting focus. |source| indicates
  /// where the focus request is originating from. Return false (0) to allow the
  /// focus to be set or true (1) to cancel setting the focus.
  /// <c>int(CEF_CALLBACK* on_set_focus)(struct _cef_focus_handler_t* self, struct _cef_browser_t* browser, cef_focus_source_t source)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFocusHandler*, CefBrowser*, CefFocusSource, int> _OnSetFocus;

  /// <summary>
  /// Called when the browser component has received focus.
  /// <c>void(CEF_CALLBACK* on_got_focus)(struct _cef_focus_handler_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFocusHandler*, CefBrowser*, void> _OnGotFocus;

}
