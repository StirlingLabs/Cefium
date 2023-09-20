namespace Cefium;

/// <summary>
/// Structure used to implement render process callbacks. The functions of this
/// structure will be called on the render process main thread (TID_RENDERER)
/// unless otherwise indicated.
/// <c>cef_browser_process_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRenderProcessHandler : ICefRefCountedBase<CefRenderProcessHandler> {

  /// <inheritdoc cref="CefRenderProcessHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefRenderProcessHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called after WebKit has been initialized.
  /// <c>void(CEF_CALLBACK* on_web_kit_initialized)(struct _cef_render_process_handler_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, void> _OnWebKitInitialized;

  /// <summary>
  /// Called after a browser has been created. When browsing cross-origin a new
  /// browser will be created before the old browser with the same identifier is
  /// destroyed. |extra_info| is an optional read-only value originating from
  /// cef_browser_host_t::cef_browser_host_create_browser(),
  /// cef_browser_host_t::cef_browser_host_create_browser_sync(),
  /// cef_life_span_handler_t::on_before_popup() or
  /// cef_browser_view_t::cef_browser_view_create().
  /// <c>void(CEF_CALLBACK* on_browser_created)(struct _cef_render_process_handler_t* self, struct _cef_browser_t* browser, struct _cef_dictionary_value_t* extra_info);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, CefBrowser*, CefDictionaryValue*, void> _OnBrowserCreated;

  /// <summary>
  /// Called before a browser is destroyed.
  /// <c>void(CEF_CALLBACK* on_browser_destroyed)(struct _cef_render_process_handler_t* self, struct _cef_browser_t* browser);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, CefBrowser*, void> _OnBrowserDestroyed;

  /// <summary>
  /// Return the handler for browser load status events.
  /// <c>struct _cef_load_handler_t*(CEF_CALLBACK* get_load_handler)(struct _cef_render_process_handler_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, CefLoadHandler*> _GetLoadHandler;

  /// <summary>
  /// Called immediately after the V8 context for a frame has been created. To
  /// retrieve the JavaScript 'window' object use the
  /// cef_v8context_t::get_global() function. V8 handles can only be accessed
  /// from the thread on which they are created. A task runner for posting tasks
  /// on the associated thread can be retrieved via the
  /// cef_v8context_t::get_task_runner() function.
  /// <c>void(CEF_CALLBACK* on_context_created)(struct _cef_render_process_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_v8context_t* context);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, CefBrowser*, CefFrame*, CefV8Context*, void> _OnContextCreated;

  /// <summary>
  /// Called immediately before the V8 context for a frame is released. No
  /// references to the context should be kept after this function is called.
  /// <c>void(CEF_CALLBACK* on_context_released)(struct _cef_render_process_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_v8context_t* context);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, CefBrowser*, CefFrame*, CefV8Context*, void> _OnContextReleased;

  /// <summary>
  /// Called for global uncaught exceptions in a frame. Execution of this
  /// callback is disabled by default. To enable set
  /// cef_settings_t.uncaught_exception_stack_size > 0.
  /// <c>void(CEF_CALLBACK* on_uncaught_exception)(struct _cef_render_process_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_v8context_t* context, struct _cef_v8exception_t* exception, struct _cef_v8stack_trace_t* stackTrace);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, CefBrowser*, CefFrame*, CefV8Context*, CefV8Exception*, CefV8StackTrace*, void> _OnUncaughtException;

  /// <summary>
  /// Called when a new node in the the browser gets focus. The |node| value may
  /// be NULL if no specific node has gained focus. The node object passed to
  /// this function represents a snapshot of the DOM at the time this function
  /// is executed. DOM objects are only valid for the scope of this function. Do
  /// not keep references to or attempt to access any DOM objects outside the
  /// scope of this function.
  /// <c>void(CEF_CALLBACK* on_focused_node_changed)(struct _cef_render_process_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, struct _cef_domnode_t* node);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, CefBrowser*, CefFrame*, CefDomNode*, void> _OnFocusedNodeChanged;

  /// <summary>
  /// Called when a new message is received from a different process. Return
  /// true (1) if the message was handled or false (0) otherwise. It is safe to
  /// keep a reference to |message| outside of this callback.
  /// <c>int(CEF_CALLBACK* on_process_message_received)(struct _cef_render_process_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, cef_process_id_t source_process, struct _cef_process_message_t* message);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRenderProcessHandler*, CefBrowser*, CefFrame*, CefProcessId, CefProcessMessage*, int> _OnProcessMessageReceived;

}
