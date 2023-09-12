namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events related to browser display state.
/// The functions of this structure will be called on the UI thread.
/// <c>cef_display_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDisplayHandler : ICefRefCountedBase<CefDisplayHandler> {

  /// <inheritdoc cref="CefDisplayHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDisplayHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called when a frame's address has changed.
  /// <c>void(CEF_CALLBACK* on_address_change)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, const cef_string_t* url)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, CefFrame*, CefString*, void> _OnAddressChange;

  /// <summary>
  /// Called when the page title changes.
  /// <c>void(CEF_CALLBACK* on_title_change)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* title)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, CefString*, void> _OnTitleChange;

  /// <summary>
  /// Called when the page icon changes.
  /// <c>void(CEF_CALLBACK* on_favicon_urlchange)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, cef_string_list_t icon_urls)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, CefStringList*, void> _OnFaviconUrlChange;

  /// <summary>
  /// Called when web content in the page has toggled fullscreen mode. If
  /// |fullscreen| is true (1) the content will automatically be sized to fill
  /// the browser content area. If |fullscreen| is false (0) the content will
  /// automatically return to its original size and position. The client is
  /// responsible for resizing the browser if desired.
  /// <c>void(CEF_CALLBACK* on_fullscreen_mode_change)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, int fullscreen)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, int, void> _OnFullscreenModeChange;

  /// <summary>
  /// Called when the browser is about to display a tooltip. |text| contains the
  /// text that will be displayed in the tooltip. To handle the display of the
  /// tooltip yourself return true (1). Otherwise, you can optionally modify
  /// |text| and then return false (0) to allow the browser to display the
  /// tooltip. When window rendering is disabled the application is responsible
  /// for drawing tooltips and the return value is ignored.
  /// <c>int(CEF_CALLBACK* on_tooltip)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, cef_string_t* text)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, CefString*, int> _OnTooltip;

  /// <summary>
  /// Called when the browser receives a status message. |value| contains the
  /// text that will be displayed in the status message.
  /// <c>void(CEF_CALLBACK* on_status_message)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* value)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, CefString*, void> _OnStatusMessage;

  /// <summary>
  /// Called to display a console message. Return true (1) to stop the message
  /// from being output to the console.
  /// <c>int(CEF_CALLBACK* on_console_message)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, cef_log_severity_t level, const cef_string_t* message, const cef_string_t* source, int line)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, CefLogSeverity, CefString*, CefString*, int, int> _OnConsoleMessage;

  /// <summary>
  /// Called when auto-resize is enabled via
  /// cef_browser_host_t::SetAutoResizeEnabled and the contents have auto-
  /// resized. |new_size| will be the desired size in view coordinates. Return
  /// true (1) if the resize was handled or false (0) for default handling.
  /// <c>int(CEF_CALLBACK* on_auto_resize)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, const cef_size_t* new_size)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, CefSize*, int> _OnAutoResize;

  /// <summary>
  /// Called when the overall page loading progress has changed. |progress|
  /// ranges from 0.0 to 1.0.
  /// <c>void(CEF_CALLBACK* on_loading_progress_change)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, double progress)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, double, void> _OnLoadingProgressChange;

  /// <summary>
  /// Called when the browser's cursor has changed. If |type| is CT_CUSTOM then
  /// |custom_cursor_info| will be populated with the custom cursor information.
  /// Return true (1) if the cursor change was handled or false (0) for default
  /// handling.
  /// <c>int(CEF_CALLBACK* on_cursor_change)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, cef_cursor_handle_t cursor, cef_cursor_type_t type, const cef_cursor_info_t* custom_cursor_info)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, nint, CefCursorType, CefCursorInfo*, int> _OnCursorChange;

  /// <summary>
  /// Called when the browser's access to an audio and/or video source has
  /// changed.
  /// <c>void(CEF_CALLBACK* on_media_access_change)(struct _cef_display_handler_t* self, struct _cef_browser_t* browser, int has_video_access, int has_audio_access)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplayHandler*, CefBrowser*, int, int, void> _OnMediaAccessChange;

}
