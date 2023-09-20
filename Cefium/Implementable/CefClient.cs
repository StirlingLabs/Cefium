namespace Cefium;

/// <summary>
/// Implement this structure to provide handler implementations.
/// <c>cef_client_t</c>
/// </summary>
/// <seealso cref="CefClientExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefClient : ICefRefCountedBase<CefClient> {

  /// <inheritdoc cref="CefClient"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefClient() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Return the handler for audio rendering events.
  /// <c>struct _cef_audio_handler_t*(CEF_CALLBACK* get_audio_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefAudioHandler*> _GetAudioHandler;

  /// <summary>
  /// Return the handler for commands. If no handler is provided the default
  /// implementation will be used.
  /// <c>struct _cef_command_handler_t*(CEF_CALLBACK* get_command_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefCommandHandler*> _GetCommandHandler;

  /// <summary>
  /// Return the handler for context menus. If no handler is provided the
  /// default implementation will be used.
  /// <c>struct _cef_context_menu_handler_t*(CEF_CALLBACK* get_context_menu_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefContextMenuHandler*> _GetContextMenuHandler;

  /// <summary>
  /// Return the handler for dialogs. If no handler is provided the default
  /// implementation will be used.
  /// <c>struct _cef_dialog_handler_t*(CEF_CALLBACK* get_dialog_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefDialogHandler*> _GetDialogHandler;

  /// <summary>
  /// Return the handler for browser display state events.
  /// <c>struct _cef_display_handler_t*(CEF_CALLBACK* get_display_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefDisplayHandler*> _GetDisplayHandler;

  /// <summary>
  /// Return the handler for download events. If no handler is returned
  /// downloads will not be allowed.
  /// <c>struct _cef_download_handler_t*(CEF_CALLBACK* get_download_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefDownloadHandler*> _GetDownloadHandler;

  /// <summary>
  /// Return the handler for drag events.
  /// <c>struct _cef_drag_handler_t*(CEF_CALLBACK* get_drag_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefDragHandler*> _GetDragHandler;

  /// <summary>
  /// Return the handler for find result events.
  /// <c>struct _cef_find_handler_t*(CEF_CALLBACK* get_find_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefFindHandler*> _GetFindHandler;

  /// <summary>
  /// Return the handler for focus events.
  /// <c>struct _cef_focus_handler_t*(CEF_CALLBACK* get_focus_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefFocusHandler*> _GetFocusHandler;

  /// <summary>
  /// Return the handler for events related to cef_frame_t lifespan. This
  /// function will be called once during cef_browser_t creation and the result
  /// will be cached for performance reasons.
  /// <c>struct _cef_frame_handler_t*(CEF_CALLBACK* get_frame_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefFrameHandler*> _GetFrameHandler;

  /// <summary>
  /// Return the handler for permission requests.
  /// <c>struct _cef_permission_handler_t*(CEF_CALLBACK* get_permission_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefPermissionHandler*> _GetPermissionHandler;

  /// <summary>
  /// Return the handler for JavaScript dialogs. If no handler is provided the
  /// default implementation will be used.
  /// <c>struct _cef_jsdialog_handler_t*(CEF_CALLBACK* get_jsdialog_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefJsDialogHandler*> _GetJsDialogHandler;

  /// <summary>
  /// Return the handler for keyboard events.
  /// <c>struct _cef_keyboard_handler_t*(CEF_CALLBACK* get_keyboard_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefKeyboardHandler*> _GetKeyboardHandler;

  /// <summary>
  /// Return the handler for browser life span events.
  /// <c>struct _cef_life_span_handler_t*(CEF_CALLBACK* get_life_span_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefLifeSpanHandler*> _GetLifeSpanHandler;

  /// <summary>
  /// Return the handler for browser load status events.
  /// <c>struct _cef_load_handler_t*(CEF_CALLBACK* get_load_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefLoadHandler*> _GetLoadHandler;

  /// <summary>
  /// Return the handler for printing on Linux. If a print handler is not
  /// provided then printing will not be supported on the Linux platform.
  /// <c>struct _cef_print_handler_t*(CEF_CALLBACK* get_print_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefPrintHandler*> _GetPrintHandler;

  /// <summary>
  /// Return the handler for off-screen rendering events.
  /// <c>struct _cef_render_handler_t*(CEF_CALLBACK* get_render_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefRenderHandler*> _GetRenderHandler;

  /// <summary>
  /// Return the handler for browser request events.
  /// <c>struct _cef_request_handler_t*(CEF_CALLBACK* get_request_handler)(struct _cef_client_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefRequestHandler*> _GetRequestHandler;

  /// <summary>
  /// Called when a new message is received from a different process. Return
  /// true (1) if the message was handled or false (0) otherwise.  It is safe to
  /// keep a reference to |message| outside of this callback.
  /// <c>int(CEF_CALLBACK* on_process_message_received)(struct _cef_client_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, cef_process_id_t source_process, struct _cef_process_message_t* message);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefClient*, CefBrowser*, CefFrame*, CefProcessId, CefProcessMessage*, int> _OnProcessMessageReceived;

}
