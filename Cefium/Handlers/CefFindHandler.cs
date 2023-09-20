namespace Cefium;

/// <summary>
/// Implement this structure to handle events related to find results. The
/// functions of this structure will be called on the UI thread.
/// <c>cef_find_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefFindHandler : ICefRefCountedBase<CefFindHandler> {

  /// <inheritdoc cref="CefFindHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefFindHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called to report find results returned by cef_browser_host_t::find().
  /// |identifer| is a unique incremental identifier for the currently active
  /// search, |count| is the number of matches currently identified,
  /// |selectionRect| is the location of where the match was found (in window
  /// coordinates), |activeMatchOrdinal| is the current position in the search
  /// results, and |finalUpdate| is true (1) if this is the last find
  /// notification.
  /// <c>void(CEF_CALLBACK* on_find_result)(struct _cef_find_handler_t* self, struct _cef_browser_t* browser, int identifier, int count, const cef_rect_t* selectionRect, int activeMatchOrdinal, int finalUpdate);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFindHandler*, CefBrowser*, int, int, CefRect*, int, int, void> _OnFindResult;

}
