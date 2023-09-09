namespace Cefaloid;

/// <summary>
/// <c>cef_frame_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefFrameHandler : ICefRefCountedBase<CefFrameHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefFrameHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called when a new frame is created. This will be the first notification
  /// that references |frame|. Any commands that require transport to the
  /// associated renderer process (LoadRequest, SendProcessMessage, GetSource, /// etc.) will be queued until OnFrameAttached is called for |frame|.
  /// <c>void(CEF_CALLBACK* on_frame_created)(struct _cef_frame_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrameHandler*, CefBrowser*, CefFrame*, void> _OnFrameCreated;

  /// <summary>
  /// Called when a frame can begin routing commands to/from the associated
  /// renderer process. |reattached| will be true (1) if the frame was re-
  /// attached after exiting the BackForwardCache. Any commands that were queued
  /// have now been dispatched.
  /// <c>void(CEF_CALLBACK* on_frame_attached)(struct _cef_frame_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, int reattached)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrameHandler*, CefBrowser*, CefFrame*, int, void> _OnFrameAttached;

  /// <summary>
  /// Called when a frame loses its connection to the renderer process and will
  /// be destroyed. Any pending or future commands will be discarded and
  /// cef_frame_t::is_valid() will now return false (0) for |frame|. If called
  /// after cef_life_span_handler_t::on_before_close() during browser
  /// destruction then cef_browser_t::is_valid() will return false (0) for
  /// |browser|.
  /// <c>void(CEF_CALLBACK* on_frame_detached)(struct _cef_frame_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrameHandler*, CefBrowser*, CefFrame*, void> _OnFrameDetached;

  /// <summary>
  /// Called when the main frame changes due to (a) initial browser creation, /// (b) final browser destruction, (c) cross-origin navigation or (d) re-
  /// navigation after renderer process termination (due to crashes, etc).
  /// |old_frame| will be NULL and |new_frame| will be non-NULL when a main
  /// frame is assigned to |browser| for the first time. |old_frame| will be
  /// non-NULL and |new_frame| will be NULL and  when a main frame is removed
  /// from |browser| for the last time. Both |old_frame| and |new_frame| will be
  /// non-NULL for cross-origin navigations or re-navigation after renderer
  /// process termination. This function will be called after on_frame_created()
  /// for |new_frame| and/or after on_frame_detached() for |old_frame|. If
  /// called after cef_life_span_handler_t::on_before_close() during browser
  /// destruction then cef_browser_t::is_valid() will return false (0) for
  /// |browser|.
  /// <c>void(CEF_CALLBACK* on_main_frame_changed)(struct _cef_frame_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* old_frame, struct _cef_frame_t* new_frame)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrameHandler*, CefBrowser*, CefFrame*, CefFrame*, void> _OnMainFrameChanged;

}
