namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events related to dragging. The functions
/// of this structure will be called on the UI thread.
/// <c>cef_drag_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDragHandler : ICefRefCountedBase<CefDragHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefDragHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called when an external drag event enters the browser window. |dragData|
  /// contains the drag event data and |mask| represents the type of drag
  /// operation. Return false (0) for default drag handling behavior or true (1)
  /// to cancel the drag event.
  /// <c>int(CEF_CALLBACK* on_drag_enter)(struct _cef_drag_handler_t* self, struct _cef_browser_t* browser, struct _cef_drag_data_t* dragData, cef_drag_operations_mask_t mask)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragHandler*, CefBrowser*, CefDragData*, CefDragOperationsMask, int> _OnDragEnter;

  /// <summary>
  /// Called whenever draggable regions for the browser window change. These can
  /// be specified using the '-webkit-app-region: drag/no-drag' CSS-property. If
  /// draggable regions are never defined in a document this function will also
  /// never be called. If the last draggable region is removed from a document
  /// this function will be called with an NULL vector.
  /// <c>void(CEF_CALLBACK* on_draggable_regions_changed)(struct _cef_drag_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, size_t regionsCount, cef_draggable_region_t const* regions)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragHandler*, CefBrowser*, CefFrame*, nuint, CefDraggableRegion*, void> _OnDraggableRegionsChanged;

}
