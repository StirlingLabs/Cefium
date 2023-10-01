namespace Cefium;

/// <summary>
/// Structure used to represent the browser process aspects of a browser. The
/// functions of this structure can only be called in the browser process. They
/// may be called on any thread in that process unless otherwise indicated in
/// the comments.
/// <c>cef_browser_host_t</c>
/// </summary>
/// <seealso cref="CefBrowserHostExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefBrowserHost : ICefRefCountedBase<CefBrowserHost> {

  /// <inheritdoc cref="CefBrowserHost"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefBrowserHost() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new browser using the window parameters specified by |windowInfo|.
  /// All values will be copied internally and the actual window (if any) will be
  /// created on the UI thread. If |request_context| is NULL the global request
  /// context will be used. This function can be called on any browser process
  /// thread and will not block. The optional |extra_info| parameter provides an
  /// opportunity to specify extra information specific to the created browser
  /// that will be passed to cef_render_process_handler_t::on_browser_created() in
  /// the render process.
  /// <c>CEF_EXPORT int cef_browser_host_create_browser(const cef_window_info_t* windowInfo, struct _cef_client_t* client, const cef_string_t* url, const struct _cef_browser_settings_t* settings, struct _cef_dictionary_value_t* extra_info, struct _cef_request_context_t* request_context);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_browser_host_create_browser", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe int _CreateBrowser(CefWindowInfo* windowInfo, CefClient* client, CefString* url, CefBrowserSettings* settings, CefDictionaryValue* extraInfo, CefRequestContext* requestContext = null);

  /// <inheritdoc cref="_CreateBrowser"/>
  public static unsafe bool CreateBrowser(ref CefWindowInfo windowInfo, CefClient* client, ref CefString url, ref CefBrowserSettings settings, CefDictionaryValue* extraInfo, CefRequestContext* requestContext = null)
    => _CreateBrowser(windowInfo.AsPointer(), client, url.AsPointer(), settings.AsPointer(), extraInfo, requestContext) != 0;

  /// <summary>
  /// Create a new browser using the window parameters specified by |windowInfo|.
  /// If |request_context| is NULL the global request context will be used. This
  /// function can only be called on the browser process UI thread. The optional
  /// |extra_info| parameter provides an opportunity to specify extra information
  /// specific to the created browser that will be passed to
  /// cef_render_process_handler_t::on_browser_created() in the render process.
  /// <c>CEF_EXPORT cef_browser_t* cef_browser_host_create_browser_sync(const cef_window_info_t* windowInfo, struct _cef_client_t* client, const cef_string_t* url, const struct _cef_browser_settings_t* settings, struct _cef_dictionary_value_t* extra_info, struct _cef_request_context_t* request_context);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_browser_host_create_browser_sync", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe CefBrowser* _CreateBrowserSync(CefWindowInfo* windowInfo, CefClient* client, CefString* url, CefBrowserSettings* settings, CefDictionaryValue* extraInfo, CefRequestContext* requestContext = null);

  /// <inheritdoc cref="_CreateBrowserSync"/>
  public static unsafe CefBrowser* CreateBrowserSync(ref CefWindowInfo windowInfo, CefClient* client, ref CefString url, ref CefBrowserSettings settings, CefDictionaryValue* extraInfo, CefRequestContext* requestContext = null)
    => _CreateBrowserSync(windowInfo.AsPointer(), client, url.AsPointer(), settings.AsPointer(), extraInfo, requestContext);

  /// <summary>
  /// Returns the hosted browser object.
  /// <c>struct _cef_browser_t*(CEF_CALLBACK* get_browser)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefBrowser*> _GetBrowser;

  /// <summary>
  /// Request that the browser close. The JavaScript 'onbeforeunload' event will
  /// be fired. If |force_close| is false (0) the event handler, if any, will be
  /// allowed to prompt the user and the user can optionally cancel the close. If
  /// |force_close| is true (1) the prompt will not be displayed and the close
  /// will proceed. Results in a call to cef_life_span_handler_t::do_close() if
  /// the event handler allows the close or if |force_close| is true (1). See
  /// cef_life_span_handler_t::do_close() documentation for additional usage
  /// information.
  /// <c>void(CEF_CALLBACK* close_browser)(struct _cef_browser_host_t* self, int force_close);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, void> _CloseBrowser;

  /// <summary>
  /// Helper for closing a browser. Call this function from the top-level window
  /// close handler (if any). Internally this calls CloseBrowser(false (0)) if
  /// the close has not yet been initiated. This function returns false (0)
  /// while the close is pending and true (1) after the close has completed. See
  /// close_browser() and cef_life_span_handler_t::do_close() documentation for
  /// additional usage information. This function must be called on the browser
  /// process UI thread.
  /// <c>int(CEF_CALLBACK* try_close_browser)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int> _TryCloseBrowser;

  /// <summary>
  /// Set whether the browser is focused.
  /// <c>void(CEF_CALLBACK* set_focus)(struct _cef_browser_host_t* self, int focus);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, void> _SetFocus;

  /// <summary>
  /// Retrieve the window handle (if any) for this browser. If this browser is
  /// wrapped in a cef_browser_view_t this function should be called on the
  /// browser process UI thread and it will return the handle for the top-level
  /// native window.
  /// <c>cef_window_handle_t(CEF_CALLBACK* get_window_handle)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, nint> _GetWindowHandle;

  /// <summary>
  /// Retrieve the window handle (if any) of the browser that opened this
  /// browser. Will return NULL for non-popup browsers or if this browser is
  /// wrapped in a cef_browser_view_t. This function can be used in combination
  /// with custom handling of modal windows.
  /// <c>cef_window_handle_t(CEF_CALLBACK* get_opener_window_handle)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, nint> _GetOpenerWindowHandle;

  /// <summary>
  /// Returns true (1) if this browser is wrapped in a cef_browser_view_t.
  /// <c>int(CEF_CALLBACK* has_view)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int> _HasView;

  /// <summary>
  /// Returns the client for this browser.
  /// <c>struct _cef_client_t*(CEF_CALLBACK* get_client)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefClient*> _GetClient;

  /// <summary>
  /// Returns the request context for this browser.
  /// <c>struct _cef_request_context_t*(CEF_CALLBACK* get_request_context)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefRequestContext*> _GetRequestContext;

  /// <summary>
  /// Get the current zoom level. The default zoom level is 0.0. This function
  /// can only be called on the UI thread.
  /// <c>double(CEF_CALLBACK* get_zoom_level)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, double> _GetZoomLevel;

  /// <summary>
  /// Change the zoom level to the specified value. Specify 0.0 to reset the
  /// zoom level. If called on the UI thread the change will be applied
  /// immediately. Otherwise, the change will be applied asynchronously on the
  /// UI thread.
  /// <c>void(CEF_CALLBACK* set_zoom_level)(struct _cef_browser_host_t* self, double zoomLevel);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, double, void> _SetZoomLevel;

  /// <summary>
  /// Call to run a file chooser dialog. Only a single file chooser dialog may
  /// be pending at any given time. |mode| represents the type of dialog to
  /// display. |title| to the title to be used for the dialog and may be NULL to
  /// show the default title ("Open" or "Save" depending on the mode).
  /// |default_file_path| is the path with optional directory and/or file name
  /// component that will be initially selected in the dialog. |accept_filters|
  /// are used to restrict the selectable file types and may any combination of
  /// (a) valid lower-cased MIME types (e.g. "text/*" or "image/*"), (b)
  /// individual file extensions (e.g. ".txt" or ".png"), or (c) combined
  /// description and file extension delimited using "|" and ";" (e.g. "Image
  /// Types|.png;.gif;.jpg"). |callback| will be executed after the dialog is
  /// dismissed or immediately if another dialog is already pending. The dialog
  /// will be initiated asynchronously on the UI thread.
  /// <c>void(CEF_CALLBACK* run_file_dialog)(struct _cef_browser_host_t* self, cef_file_dialog_mode_t mode, const cef_string_t* title, const cef_string_t* default_file_path, cef_string_list_t accept_filters, struct _cef_run_file_dialog_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefFileDialogMode, CefString*, CefString*, CefStringList*, CefRunFileDialogCallback*, void> _RunFileDialog;

  /// <summary>
  /// Download the file at |url| using cef_download_handler_t.
  /// <c>void(CEF_CALLBACK* start_download)(struct _cef_browser_host_t* self, const cef_string_t* url);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefString*, void> _StartDownload;

  /// <summary>
  /// Download |image_url| and execute |callback| on completion with the images
  /// received from the renderer. If |is_favicon| is true (1) then cookies are
  /// not sent and not accepted during download. Images with density independent
  /// pixel (DIP) sizes larger than |max_image_size| are filtered out from the
  /// image results. Versions of the image at different scale factors may be
  /// downloaded up to the maximum scale factor supported by the system. If
  /// there are no image results &lt;= |max_image_size| then the smallest image is
  /// resized to |max_image_size| and is the only result. A |max_image_size| of
  /// 0 means unlimited. If |bypass_cache| is true (1) then |image_url| is
  /// requested from the server even if it is present in the browser cache.
  /// <c>void(CEF_CALLBACK* download_image)(struct _cef_browser_host_t* self, const cef_string_t* image_url, int is_favicon, uint32 max_image_size, int bypass_cache, struct _cef_download_image_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefString*, int, uint, int, CefDownloadImageCallback*, void> _DownloadImage;

  /// <summary>
  /// Print the current browser contents.
  /// <c>void(CEF_CALLBACK* print)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _Print;

  /// <summary>
  /// Print the current browser contents to the PDF file specified by |path| and
  /// execute |callback| on completion. The caller is responsible for deleting
  /// |path| when done. For PDF printing to work on Linux you must implement the
  /// cef_print_handler_t::GetPdfPaperSize function.
  /// <c>void(CEF_CALLBACK* print_to_pdf)(struct _cef_browser_host_t* self, const cef_string_t* path, const struct _cef_pdf_print_settings_t* settings, struct _cef_pdf_print_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefString*, CefPdfPrintSettings*, CefPdfPrintCallback*, void> _PrintToPdf;

  /// <summary>
  /// Search for |searchText|. |forward| indicates whether to search forward or
  /// backward within the page. |matchCase| indicates whether the search should
  /// be case-sensitive. |findNext| indicates whether this is the first request
  /// or a follow-up. The search will be restarted if |searchText| or
  /// |matchCase| change. The search will be stopped if |searchText| is NULL.
  /// The cef_find_handler_t instance, if any, returned via
  /// cef_client_t::GetFindHandler will be called to report find results.
  /// <c>void(CEF_CALLBACK* find)(struct _cef_browser_host_t* self, const cef_string_t* searchText, int forward, int matchCase, int findNext);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefString*, int, int, int, void> _Find;

  /// <summary>
  /// Cancel all searches that are currently going on.
  /// <c>void(CEF_CALLBACK* stop_finding)(struct _cef_browser_host_t* self, int clearSelection);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, void> _StopFinding;

  /// <summary>
  /// Open developer tools (DevTools) in its own browser. The DevTools browser
  /// will remain associated with this browser. If the DevTools browser is
  /// already open then it will be focused, in which case the |windowInfo|,
  /// |client| and |settings| parameters will be ignored. If
  /// |inspect_element_at| is non-NULL then the element at the specified (x,y)
  /// location will be inspected. The |windowInfo| parameter will be ignored if
  /// this browser is wrapped in a cef_browser_view_t.
  /// <c>void(CEF_CALLBACK* show_dev_tools)(struct _cef_browser_host_t* self, const struct _cef_window_info_t* windowInfo, struct _cef_client_t* client, const struct _cef_browser_settings_t* settings, const cef_point_t* inspect_element_at);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefWindowInfo*, CefClient*, CefBrowserSettings*, CefPoint*, void> _ShowDevTools;

  /// <summary>
  /// Explicitly close the associated DevTools browser, if any.
  /// <c>void(CEF_CALLBACK* close_dev_tools)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _CloseDevTools;

  /// <summary>
  /// Returns true (1) if this browser currently has an associated DevTools
  /// browser. Must be called on the browser process UI thread.
  /// <c>int(CEF_CALLBACK* has_dev_tools)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int> _HasDevTools;

  /// <summary>
  /// Send a function call message over the DevTools protocol. |message| must be
  /// a UTF8-encoded JSON dictionary that contains "id" (int), "function"
  /// (string) and "params" (dictionary, optional) values. See the DevTools
  /// protocol documentation at https://chromedevtools.github.io/devtools-
  /// protocol/ for details of supported functions and the expected "params"
  /// dictionary contents. |message| will be copied if necessary. This function
  /// will return true (1) if called on the UI thread and the message was
  /// successfully submitted for validation, otherwise false (0). Validation
  /// will be applied asynchronously and any messages that fail due to
  /// formatting errors or missing parameters may be discarded without
  /// notification. Prefer ExecuteDevToolsMethod if a more structured approach
  /// to message formatting is desired.
  ///
  /// Every valid function call will result in an asynchronous function result
  /// or error message that references the sent message "id". Event messages are
  /// received while notifications are enabled (for example, between function
  /// calls for "Page.enable" and "Page.disable"). All received messages will be
  /// delivered to the observer(s) registered with AddDevToolsMessageObserver.
  /// See cef_dev_tools_message_observer_t::OnDevToolsMessage documentation for
  /// details of received message contents.
  ///
  /// Usage of the SendDevToolsMessage, ExecuteDevToolsMethod and
  /// AddDevToolsMessageObserver functions does not require an active DevTools
  /// front-end or remote-debugging session. Other active DevTools sessions will
  /// continue to function independently. However, any modification of global
  /// browser state by one session may not be reflected in the UI of other
  /// sessions.
  ///
  /// Communication with the DevTools front-end (when displayed) can be logged
  /// for development purposes by passing the `--devtools-protocol-log-
  /// file=&lt;path&gt;` command-line flag.
  /// <c>int(CEF_CALLBACK* send_dev_tools_message)(struct _cef_browser_host_t* self, const void* message, size_t message_size);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void*, nuint, int> _SendDevToolsMessage;

  /// <summary>
  /// Execute a function call over the DevTools protocol. This is a more
  /// structured version of SendDevToolsMessage. |message_id| is an incremental
  /// number that uniquely identifies the message (pass 0 to have the next
  /// number assigned automatically based on previous values). |function| is the
  /// function name. |params| are the function parameters, which may be NULL.
  /// See the DevTools protocol documentation (linked above) for details of
  /// supported functions and the expected |params| dictionary contents. This
  /// function will return the assigned message ID if called on the UI thread
  /// and the message was successfully submitted for validation, otherwise 0.
  /// See the SendDevToolsMessage documentation for additional usage
  /// information.
  /// <c>int(CEF_CALLBACK* execute_dev_tools_method)(struct _cef_browser_host_t* self, int message_id, const cef_string_t* method, struct _cef_dictionary_value_t* params);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, CefString*, CefDictionaryValue*, int> _ExecuteDevToolsMethod;

  /// <summary>
  /// Add an observer for DevTools protocol messages (function results and
  /// events). The observer will remain registered until the returned
  /// Registration object is destroyed. See the SendDevToolsMessage
  /// documentation for additional usage information.
  /// <c>struct _cef_registration_t*(CEF_CALLBACK* add_dev_tools_message_observer)(struct _cef_browser_host_t* self, struct _cef_dev_tools_message_observer_t* observer);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefDevToolsMessageObserver*, CefRegistration*> _AddDevToolsMessageObserver;

  /// <summary>
  /// Retrieve a snapshot of current navigation entries as values sent to the
  /// specified visitor. If |current_only| is true (1) only the current
  /// navigation entry will be sent, otherwise all navigation entries will be
  /// sent.
  /// <c>void(CEF_CALLBACK* get_navigation_entries)(struct _cef_browser_host_t* self, struct _cef_navigation_entry_visitor_t* visitor, int current_only);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefNavigationEntryVisitor*, int, void> _GetNavigationEntries;

  /// <summary>
  /// If a misspelled word is currently selected in an editable node calling
  /// this function will replace it with the specified |word|.
  /// <c>void(CEF_CALLBACK* replace_misspelling)(struct _cef_browser_host_t* self, const cef_string_t* word);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefString*, void> _ReplaceMisspelling;

  /// <summary>
  /// Add the specified |word| to the spelling dictionary.
  /// <c>void(CEF_CALLBACK* add_word_to_dictionary)(struct _cef_browser_host_t* self, const cef_string_t* word);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefString*, void> _AddWordToDictionary;

  /// <summary>
  /// Returns true (1) if window rendering is disabled.
  /// <c>int(CEF_CALLBACK* is_window_rendering_disabled)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int> _IsWindowRenderingDisabled;

  /// <summary>
  /// Notify the browser that the widget has been resized. The browser will
  /// first call cef_render_handler_t::GetViewRect to get the new size and then
  /// call cef_render_handler_t::OnPaint asynchronously with the updated
  /// regions. This function is only used when window rendering is disabled.
  /// <c>void(CEF_CALLBACK* was_resized)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _WasResized;

  /// <summary>
  /// Notify the browser that it has been hidden or shown. Layouting and
  /// cef_render_handler_t::OnPaint notification will stop when the browser is
  /// hidden. This function is only used when window rendering is disabled.
  /// <c>void(CEF_CALLBACK* was_hidden)(struct _cef_browser_host_t* self, int hidden);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, void> _WasHidden;

  /// <summary>
  /// Send a notification to the browser that the screen info has changed. The
  /// browser will then call cef_render_handler_t::GetScreenInfo to update the
  /// screen information with the new values. This simulates moving the webview
  /// window from one display to another, or changing the properties of the
  /// current display. This function is only used when window rendering is
  /// disabled.
  /// <c>void(CEF_CALLBACK* notify_screen_info_changed)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _NotifyScreenInfoChanged;

  /// <summary>
  /// Invalidate the view. The browser will call cef_render_handler_t::OnPaint
  /// asynchronously. This function is only used when window rendering is
  /// disabled.
  /// <c>void(CEF_CALLBACK* invalidate)(struct _cef_browser_host_t* self, cef_paint_element_type_t type);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefPaintElementType, void> _Invalidate;

  /// <summary>
  /// Issue a BeginFrame request to Chromium.  Only valid when
  /// cef_window_tInfo::external_begin_frame_enabled is set to true (1).
  /// <c>void(CEF_CALLBACK* send_external_begin_frame)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _SendExternalBeginFrame;

  /// <summary>
  /// Send a key event to the browser.
  /// <c>void(CEF_CALLBACK* send_key_event)(struct _cef_browser_host_t* self, const cef_key_event_t* event);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefKeyEvent*, void> _SendKeyEvent;

  /// <summary>
  /// Send a mouse click event to the browser. The |x| and |y| coordinates are
  /// relative to the upper-left corner of the view.
  /// <c>void(CEF_CALLBACK* send_mouse_click_event)(struct _cef_browser_host_t* self, const cef_mouse_event_t* event, cef_mouse_button_type_t type, int mouseUp, int clickCount);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefMouseEvent*, CefMouseButton, int, int, void> _SendMouseClickEvent;

  /// <summary>
  /// Send a mouse move event to the browser. The |x| and |y| coordinates are
  /// relative to the upper-left corner of the view.
  /// <c>void(CEF_CALLBACK* send_mouse_move_event)(struct _cef_browser_host_t* self, const cef_mouse_event_t* event, int mouseLeave);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefMouseEvent*, int, void> _SendMouseMoveEvent;

  /// <summary>
  /// Send a mouse wheel event to the browser. The |x| and |y| coordinates are
  /// relative to the upper-left corner of the view. The |deltaX| and |deltaY|
  /// values represent the movement delta in the X and Y directions
  /// respectively. In order to scroll inside select popups with window
  /// rendering disabled cef_render_handler_t::GetScreenPoint should be
  /// implemented properly.
  /// <c>void(CEF_CALLBACK* send_mouse_wheel_event)(struct _cef_browser_host_t* self, const cef_mouse_event_t* event, int deltaX, int deltaY);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefMouseEvent*, int, int, void> _SendMouseWheelEvent;

  /// <summary>
  /// Send a touch event to the browser for a windowless browser.
  /// <c>void(CEF_CALLBACK* send_touch_event)(struct _cef_browser_host_t* self, const cef_touch_event_t* event);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefTouchEvent*, void> _SendTouchEvent;

  /// <summary>
  /// Send a capture lost event to the browser.
  /// <c>void(CEF_CALLBACK* send_capture_lost_event)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _SendCaptureLostEvent;

  /// <summary>
  /// Notify the browser that the window hosting it is about to be moved or
  /// resized. This function is only used on Windows and Linux.
  /// <c>void(CEF_CALLBACK* notify_move_or_resize_started)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _NotifyMoveOrResizeStarted;

  /// <summary>
  /// Returns the maximum rate in frames per second (fps) that
  /// cef_render_handler_t::OnPaint will be called for a windowless browser. The
  /// actual fps may be lower if the browser cannot generate frames at the
  /// requested rate. The minimum value is 1 and the maximum value is 60
  /// (default 30). This function can only be called on the UI thread.
  /// <c>int(CEF_CALLBACK* get_windowless_frame_rate)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int> _GetWindowlessFrameRate;

  /// <summary>
  /// Set the maximum rate in frames per second (fps) that
  /// cef_render_handler_t:: OnPaint will be called for a windowless browser.
  /// The actual fps may be lower if the browser cannot generate frames at the
  /// requested rate. The minimum value is 1 and the maximum value is 60
  /// (default 30). Can also be set at browser creation via
  /// cef_browser_tSettings.windowless_frame_rate.
  /// <c>void(CEF_CALLBACK* set_windowless_frame_rate)(struct _cef_browser_host_t* self, int frame_rate);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, void> _SetWindowlessFrameRate;

  /// <summary>
  /// Begins a new composition or updates the existing composition. Blink has a
  /// special node (a composition node) that allows the input function to change
  /// text without affecting other DOM nodes. |text| is the optional text that
  /// will be inserted into the composition node. |underlines| is an optional
  /// set of ranges that will be underlined in the resulting text.
  /// |replacement_range| is an optional range of the existing text that will be
  /// replaced. |selection_range| is an optional range of the resulting text
  /// that will be selected after insertion or replacement. The
  /// |replacement_range| value is only used on OS X.
  ///
  /// This function may be called multiple times as the composition changes.
  /// When the client is done making changes the composition should either be
  /// canceled or completed. To cancel the composition call
  /// ImeCancelComposition. To complete the composition call either
  /// ImeCommitText or ImeFinishComposingText. Completion is usually signaled
  /// when:
  ///
  /// 1. The client receives a WM_IME_COMPOSITION message with a GCS_RESULTSTR
  ///    flag (on Windows), or;
  /// 2. The client receives a "commit" signal of GtkIMContext (on Linux), or;
  /// 3. insertText of NSTextInput is called (on Mac).
  ///
  /// This function is only used when window rendering is disabled.
  /// <c>void(CEF_CALLBACK* ime_set_composition)(struct _cef_browser_host_t* self, const cef_string_t* text, size_t underlinesCount, cef_composition_underline_t const* underlines, const cef_range_t* replacement_range, const cef_range_t* selection_range);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefString*, nuint, CefCompositionUnderline*, CefRange*, CefRange*, void> _ImeSetComposition;

  /// <summary>
  /// Completes the existing composition by optionally inserting the specified
  /// |text| into the composition node. |replacement_range| is an optional range
  /// of the existing text that will be replaced. |relative_cursor_pos| is where
  /// the cursor will be positioned relative to the current cursor position. See
  /// comments on ImeSetComposition for usage. The |replacement_range| and
  /// |relative_cursor_pos| values are only used on OS X. This function is only
  /// used when window rendering is disabled.
  /// <c>void(CEF_CALLBACK* ime_commit_text)(struct _cef_browser_host_t* self, const cef_string_t* text, const cef_range_t* replacement_range, int relative_cursor_pos);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefString*, CefRange*, int, void> _ImeCommitText;

  /// <summary>
  /// Completes the existing composition by applying the current composition
  /// node contents. If |keep_selection| is false (0) the current selection, if
  /// any, will be discarded. See comments on ImeSetComposition for usage. This
  /// function is only used when window rendering is disabled.
  /// <c>void(CEF_CALLBACK* ime_finish_composing_text)(struct _cef_browser_host_t* self, int keep_selection);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, void> _ImeFinishComposingText;

  /// <summary>
  /// Cancels the existing composition and discards the composition node
  /// contents without applying them. See comments on ImeSetComposition for
  /// usage. This function is only used when window rendering is disabled.
  /// <c>void(CEF_CALLBACK* ime_cancel_composition)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _ImeCancelComposition;

  /// <summary>
  /// Call this function when the user drags the mouse into the web view (before
  /// calling DragTargetDragOver/DragTargetLeave/DragTargetDrop). |drag_data|
  /// should not contain file contents as this type of data is not allowed to be
  /// dragged into the web view. File contents can be removed using
  /// cef_drag_data_t::ResetFileContents (for example, if |drag_data| comes from
  /// cef_render_handler_t::StartDragging). This function is only used when
  /// window rendering is disabled.
  /// <c>void(CEF_CALLBACK* drag_target_drag_enter)(struct _cef_browser_host_t* self, struct _cef_drag_data_t* drag_data, const cef_mouse_event_t* event, cef_drag_operations_mask_t allowed_ops);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefDragData*, CefMouseEvent*, CefDragOperationsMask, void> _DragTargetDragEnter;

  /// <summary>
  /// Call this function each time the mouse is moved across the web view during
  /// a drag operation (after calling DragTargetDragEnter and before calling
  /// DragTargetDragLeave/DragTargetDrop). This function is only used when
  /// window rendering is disabled.
  /// <c>void(CEF_CALLBACK* drag_target_drag_over)(struct _cef_browser_host_t* self, const cef_mouse_event_t* event, cef_drag_operations_mask_t allowed_ops);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefMouseEvent*, CefDragOperationsMask, void> _DragTargetDragOver;

  /// <summary>
  /// Call this function when the user drags the mouse out of the web view
  /// (after calling DragTargetDragEnter). This function is only used when
  /// window rendering is disabled.
  /// <c>void(CEF_CALLBACK* drag_target_drag_leave)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _DragTargetDragLeave;

  /// <summary>
  /// Call this function when the user completes the drag operation by dropping
  /// the object onto the web view (after calling DragTargetDragEnter). The
  /// object being dropped is |drag_data|, given as an argument to the previous
  /// DragTargetDragEnter call. This function is only used when window rendering
  /// is disabled.
  /// <c>void(CEF_CALLBACK* drag_target_drop)(struct _cef_browser_host_t* self, const cef_mouse_event_t* event);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefMouseEvent*, void> _DragTargetDrop;

  /// <summary>
  /// Call this function when the drag operation started by a
  /// cef_render_handler_t::StartDragging call has ended either in a drop or by
  /// being cancelled. |x| and |y| are mouse coordinates relative to the upper-
  /// left corner of the view. If the web view is both the drag source and the
  /// drag target then all DragTarget* functions should be called before
  /// DragSource* mthods. This function is only used when window rendering is
  /// disabled.
  /// <c>void(CEF_CALLBACK* drag_source_ended_at)(struct _cef_browser_host_t* self, int x, int y, cef_drag_operations_mask_t op);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, int, CefDragOperationsMask, void> _DragSourceEndedAt;

  /// <summary>
  /// Call this function when the drag operation started by a
  /// cef_render_handler_t::StartDragging call has completed. This function may
  /// be called immediately without first calling DragSourceEndedAt to cancel a
  /// drag operation. If the web view is both the drag source and the drag
  /// target then all DragTarget* functions should be called before DragSource*
  /// mthods. This function is only used when window rendering is disabled.
  /// <c>void(CEF_CALLBACK* drag_source_system_drag_ended)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, void> _DragSourceSystemDragEnded;

  /// <summary>
  /// Returns the current visible navigation entry for this browser. This
  /// function can only be called on the UI thread.
  /// <c>struct _cef_navigation_entry_t*(CEF_CALLBACK* get_visible_navigation_entry)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefNavigationEntry*> _GetVisibleNavigationEntry;

  /// <summary>
  /// Set accessibility state for all frames. |accessibility_state| may be
  /// default, enabled or disabled. If |accessibility_state| is STATE_DEFAULT
  /// then accessibility will be disabled by default and the state may be
  /// further controlled with the "force-renderer-accessibility" and "disable-
  /// renderer-accessibility" command-line switches. If |accessibility_state| is
  /// STATE_ENABLED then accessibility will be enabled. If |accessibility_state|
  /// is STATE_DISABLED then accessibility will be completely disabled.
  ///
  /// For windowed browsers accessibility will be enabled in Complete mode
  /// (which corresponds to kAccessibilityModeComplete in Chromium). In this
  /// mode all platform accessibility objects will be created and managed by
  /// Chromium's internal implementation. The client needs only to detect the
  /// screen reader and call this function appropriately. For example, on macOS
  /// the client can handle the @"AXEnhancedUserStructure" accessibility
  /// attribute to detect VoiceOver state changes and on Windows the client can
  /// handle WM_GETOBJECT with OBJID_CLIENT to detect accessibility readers.
  ///
  /// For windowless browsers accessibility will be enabled in TreeOnly mode
  /// (which corresponds to kAccessibilityModeWebContentsOnly in Chromium). In
  /// this mode renderer accessibility is enabled, the full tree is computed,
  /// and events are passed to CefAccessibiltyHandler, but platform
  /// accessibility objects are not created. The client may implement platform
  /// accessibility objects using CefAccessibiltyHandler callbacks if desired.
  /// <c>void(CEF_CALLBACK* set_accessibility_state)(struct _cef_browser_host_t* self, cef_state_t accessibility_state);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefState, void> _SetAccessibilityState;

  /// <summary>
  /// Enable notifications of auto resize via
  /// cef_display_handler_t::OnAutoResize. Notifications are disabled by
  /// default. |min_size| and |max_size| define the range of allowed sizes.
  /// <c>void(CEF_CALLBACK* set_auto_resize_enabled)(struct _cef_browser_host_t* self, int enabled, const cef_size_t* min_size, const cef_size_t* max_size);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, CefSize*, CefSize*, void> _SetAutoResizeEnabled;

  /// <summary>
  /// Returns the extension hosted in this browser or NULL if no extension is
  /// hosted. See cef_request_context_t::LoadExtension for details.
  /// <c>struct _cef_extension_t*(CEF_CALLBACK* get_extension)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, CefExtension*> _GetExtension;

  /// <summary>
  /// Returns true (1) if this browser is hosting an extension background
  /// script. Background hosts do not have a window and are not displayable. See
  /// cef_request_context_t::LoadExtension for details.
  /// <c>int(CEF_CALLBACK* is_background_host)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int> _IsBackgroundHost;

  /// <summary>
  /// Set whether the browser's audio is muted.
  /// <c>void(CEF_CALLBACK* set_audio_muted)(struct _cef_browser_host_t* self,int mute);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int, void> _SetAudioMuted;

  /// <summary>
  /// Returns true (1) if the browser's audio is muted.  This function can only
  /// be called on the UI thread.
  /// <c>int(CEF_CALLBACK* is_audio_muted)(struct _cef_browser_host_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserHost*, int> _IsAudioMuted;

}
