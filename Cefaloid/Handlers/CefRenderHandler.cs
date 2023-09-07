namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events when window rendering is disabled.
/// The functions of this structure will be called on the UI thread.
/// <c>cef_render_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRenderHandler : ICefRefCountedBase<CefRenderHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefRenderHandler() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Return the handler for accessibility notifications. If no handler is
  /// provided the default implementation will be used.
  /// <c>struct _cef_accessibility_handler_t*(CEF_CALLBACK* get_accessibility_handler)(struct _cef_render_handler_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefAccessibilityHandler*> _GetAccessibilityHandler;

  /// <summary>
  /// Called to retrieve the root window rectangle in screen DIP coordinates.
  /// Return true (1) if the rectangle was provided. If this function returns
  /// false (0) the rectangle from GetViewRect will be used.
  /// <c>int(CEF_CALLBACK* get_root_screen_rect)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, cef_rect_t* rect)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefRect*, int> _GetRootScreenRect;

  /// <summary>
  /// Called to retrieve the view rectangle in screen DIP coordinates. This
  /// function must always provide a non-NULL rectangle.
  /// <c>void(CEF_CALLBACK* get_view_rect)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, cef_rect_t* rect)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefRect*, void> _GetViewRect;

  /// <summary>
  /// Called to retrieve the translation from view DIP coordinates to screen
  /// coordinates. Windows/Linux should provide screen device (pixel)
  /// coordinates and MacOS should provide screen DIP coordinates. Return true
  /// (1) if the requested coordinates were provided.
  /// <c>int(CEF_CALLBACK* get_screen_point)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, int viewX, int viewY, int* screenX, int* screenY)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, int, int, int*, int*, int> _GetScreenPoint;

  /// <summary>
  /// Called to allow the client to fill in the CefScreenInfo object with
  /// appropriate values. Return true (1) if the |screen_info| structure has
  /// been modified.
  ///
  /// If the screen info rectangle is left NULL the rectangle from GetViewRect
  /// will be used. If the rectangle is still NULL or invalid popups may not be
  /// drawn correctly.
  /// <c>int(CEF_CALLBACK* get_screen_info)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, cef_screen_info_t* screen_info)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefScreenInfo*, int> _GetScreenInfo;

  /// <summary>
  /// Called when the browser wants to show or hide the popup widget. The popup
  /// should be shown if |show| is true (1) and hidden if |show| is false (0).
  /// <c>void(CEF_CALLBACK* on_popup_show)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, int show)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, int, void> _OnPopupShow;

  /// <summary>
  /// Called when the browser wants to move or resize the popup widget. |rect|
  /// contains the new location and size in view coordinates.
  /// <c>void(CEF_CALLBACK* on_popup_size)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, const cef_rect_t* rect)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefRect*, void> _OnPopupSize;

  /// <summary>
  /// Called when an element should be painted. Pixel values passed to this
  /// function are scaled relative to view coordinates based on the value of
  /// CefScreenInfo.device_scale_factor returned from GetScreenInfo. |type|
  /// indicates whether the element is the view or the popup widget. |buffer|
  /// contains the pixel data for the whole image. |dirtyRects| contains the set
  /// of rectangles in pixel coordinates that need to be repainted. |buffer|
  /// will be |width|*|height|*4 bytes in size and represents a BGRA image with
  /// an upper-left origin. This function is only called when
  /// cef_window_tInfo::shared_texture_enabled is set to false (0).
  /// <c>void(CEF_CALLBACK* on_paint)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, cef_paint_element_type_t type, size_t dirtyRectsCount, cef_rect_t const* dirtyRects, const void* buffer, int width, int height)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefPaintElementType, nuint, CefRect*, void*, int, int, void> _OnPaint;

  /// <summary>
  /// Called when an element has been rendered to the shared texture handle.
  /// |type| indicates whether the element is the view or the popup widget.
  /// |dirtyRects| contains the set of rectangles in pixel coordinates that need
  /// to be repainted. |shared_handle| is the handle for a D3D11 Texture2D that
  /// can be accessed via ID3D11Device using the OpenSharedResource function.
  /// This function is only called when cef_window_tInfo::shared_texture_enabled
  /// is set to true (1), and is currently only supported on Windows.
  /// <c>void(CEF_CALLBACK* on_accelerated_paint)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, cef_paint_element_type_t type, size_t dirtyRectsCount, cef_rect_t const* dirtyRects, void* shared_handle)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefPaintElementType, nuint, CefRect*, void*, void> _OnAcceleratedPaint;

  /// <summary>
  /// Called to retrieve the size of the touch handle for the specified
  /// |orientation|.
  /// <c>void(CEF_CALLBACK* get_touch_handle_size)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, cef_horizontal_alignment_t orientation, cef_size_t* size)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefHorizontalAlignment, CefSize*, void> _GetTouchHandleSize;

  /// <summary>
  /// Called when touch handle state is updated. The client is responsible for
  /// rendering the touch handles.
  /// <c>void(CEF_CALLBACK* on_touch_handle_state_changed)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, const cef_touch_handle_state_t* state)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefTouchHandleState*, void> _OnTouchHandleStateChanged;

  /// <summary>
  /// Called when the user starts dragging content in the web view. Contextual
  /// information about the dragged content is supplied by |drag_data|. (|x|, /// |y|) is the drag start location in screen coordinates. OS APIs that run a
  /// system message loop may be used within the StartDragging call.
  ///
  /// Return false (0) to abort the drag operation. Don't call any of
  /// cef_browser_host_t::DragSource*Ended* functions after returning false (0).
  ///
  /// Return true (1) to handle the drag operation. Call
  /// cef_browser_host_t::DragSourceEndedAt and DragSourceSystemDragEnded either
  /// synchronously or asynchronously to inform the web view that the drag
  /// operation has ended.
  /// <c>int(CEF_CALLBACK* start_dragging)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, struct _cef_drag_data_t* drag_data, cef_drag_operations_mask_t allowed_ops, int x, int y)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefDragData*, CefDragOperationsMask, int, int, int> _StartDragging;

  /// <summary>
  /// Called when the web view wants to update the mouse cursor during a drag &
  /// drop operation. |operation| describes the allowed operation (none, move, /// copy, link).
  /// <c>void(CEF_CALLBACK* update_drag_cursor)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, cef_drag_operations_mask_t operation)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefDragOperationsMask, void> _UpdateDragCursor;

  /// <summary>
  /// Called when the scroll offset has changed.
  /// <c>void(CEF_CALLBACK* on_scroll_offset_changed)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, double x, double y)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, double, double, void> _OnScrollOffsetChanged;

  /// <summary>
  /// Called when the IME composition range has changed. |selected_range| is the
  /// range of characters that have been selected. |character_bounds| is the
  /// bounds of each character in view coordinates.
  /// <c>void(CEF_CALLBACK* on_ime_composition_range_changed)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, const cef_range_t* selected_range, size_t character_boundsCount, cef_rect_t const* character_bounds)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefRange*, nuint, CefRect*, void> _OnImeCompositionRangeChanged;

  /// <summary>
  /// Called when text selection has changed for the specified |browser|.
  /// |selected_text| is the currently selected text and |selected_range| is the
  /// character range.
  /// <c>void(CEF_CALLBACK* on_text_selection_changed)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* selected_text, const cef_range_t* selected_range)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefString*, CefRange*, void> _OnTextSelectionChanged;

  /// <summary>
  /// Called when an on-screen keyboard should be shown or hidden for the
  /// specified |browser|. |input_mode| specifies what kind of keyboard should
  /// be opened. If |input_mode| is CEF_TEXT_INPUT_MODE_NONE, any existing
  /// keyboard for this browser should be hidden.
  /// <c>void(CEF_CALLBACK* on_virtual_keyboard_requested)(struct _cef_render_handler_t* self, struct _cef_browser_t* browser, cef_text_input_mode_t input_mode)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderHandler*, CefBrowser*, CefTextInputMode, void> _OnVirtualKeyboardRequested;

}
