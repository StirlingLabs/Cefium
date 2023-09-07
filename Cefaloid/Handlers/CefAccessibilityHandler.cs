namespace Cefaloid;

/// <summary>
/// Implement this structure to receive accessibility notification when
/// accessibility events have been registered. The functions of this structure
/// will be called on the UI thread.
/// <c>cef_accessibility_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefAccessibilityHandler : ICefRefCountedBase<CefAccessibilityHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefAccessibilityHandler() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called after renderer process sends accessibility tree changes to the
  /// browser process.
  /// <c>void(CEF_CALLBACK* on_accessibility_tree_change)(struct _cef_accessibility_handler_t* self, struct _cef_value_t* value);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAccessibilityHandler*, CefValue*, void> _OnAccessibilityTreeChange;

  /// <summary>
  /// Called after renderer process sends accessibility location changes to the
  /// browser process.
  /// <c>void(CEF_CALLBACK* on_accessibility_location_change)(struct _cef_accessibility_handler_t* self, struct _cef_value_t* value);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAccessibilityHandler*, CefValue*, void> _OnAccessibilityLocationChange;

}
