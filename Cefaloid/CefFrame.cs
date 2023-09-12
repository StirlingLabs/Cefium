namespace Cefaloid;

/// <summary>
/// Structure used to represent a frame in the browser window. When used in the
/// browser process the functions of this structure may be called on any thread
/// unless otherwise indicated in the comments. When used in the render process
/// the functions of this structure may only be called on the main thread.
/// <c>cef_frame_t</c>
/// </summary>
/// <seealso cref="CefBrowser"/>
/// <seealso cref="CefFrameExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefFrame : ICefRefCountedBase<CefFrame> {

  /// <inheritdoc cref="CefFrame"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefFrame() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// True if this object is currently attached to a valid frame.
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, int> _IsValid;

  /// <summary>
  /// Execute undo in this frame.
  /// <c>void(CEF_CALLBACK* undo)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, void> _Undo;

  /// <summary>
  /// Execute redo in this frame.
  /// <c>void(CEF_CALLBACK* redo)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, void> _Redo;

  /// <summary>
  /// Execute cut in this frame.
  /// <c>void(CEF_CALLBACK* cut)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, void> _Cut;

  /// <summary>
  /// Execute copy in this frame.
  /// <c>void(CEF_CALLBACK* copy)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, void> _Copy;

  /// <summary>
  /// Execute paste in this frame.
  /// <c>void(CEF_CALLBACK* paste)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, void> _Paste;

  /// <summary>
  /// Execute delete in this frame.
  /// <c>void(CEF_CALLBACK* del)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, void> _Delete;

  /// <summary>
  /// Execute select all in this frame.
  /// <c>void(CEF_CALLBACK* select_all)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, void> _SelectAll;

  /// <summary>
  /// Save this frame's HTML source to a temporary file and open it in the
  /// default text viewing application. This function can only be called from
  /// the browser process.
  /// <c>void(CEF_CALLBACK* view_source)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, void> _ViewSource;

  /// <summary>
  /// Retrieve this frame's HTML source as a string sent to the specified
  /// visitor.
  /// <c>void(CEF_CALLBACK* get_source)(struct _cef_frame_t* self, struct _cef_string_visitor_t* visitor);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefStringVisitor*, void> _GetSource;

  /// <summary>
  /// Retrieve this frame's display text as a string sent to the specified
  /// visitor.
  /// <c>void(CEF_CALLBACK* get_text)(struct _cef_frame_t* self, struct _cef_string_visitor_t* visitor);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefStringVisitor*, void> _GetText;

  /// <summary>
  /// Load the request represented by the |request| object.
  ///
  /// WARNING: This function will fail with "bad IPC message" reason
  /// INVALID_INITIATOR_ORIGIN (213) unless you first navigate to the request
  /// origin using some other mechanism (LoadURL, link click, etc).
  ///
  /// <c>void(CEF_CALLBACK* load_request)(struct _cef_frame_t* self, struct _cef_request_t* request);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefRequest*, void> _LoadRequest;

  /// <summary>
  /// Load the specified |url|.
  /// <c>void(CEF_CALLBACK* load_url)(struct _cef_frame_t* self, const cef_string_t* url);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefString*, void> _LoadUrl;

  /// <summary>
  /// Execute a string of JavaScript code in this frame. The |script_url|
  /// parameter is the URL where the script in question can be found, if any.
  /// The renderer may request this URL to show the developer the source of the
  /// error.  The |start_line| parameter is the base line number to use for
  /// error reporting.
  /// <c>void(CEF_CALLBACK* execute_java_script)(struct _cef_frame_t* self, const cef_string_t* code, const cef_string_t* script_url, int start_line);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefString*, CefString*, int, void> _ExecuteJavaScript;

  /// <summary>
  /// Returns true (1) if this is the main (top-level) frame.
  /// <c>int(CEF_CALLBACK* is_main)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, int> _IsMain;

  /// <summary>
  /// Returns true (1) if this is the focused frame.
  /// <c>int(CEF_CALLBACK* is_focused)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, int> _IsFocused;

  /// <summary>
  /// Returns the name for this frame. If the frame has an assigned name (for
  /// example, set via the iframe "name" attribute) then that value will be
  /// returned. Otherwise a unique name will be constructed based on the frame
  /// parent hierarchy. The main (top-level) frame will always have an NULL name
  /// value.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_name)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefStringUserFree*> _GetName;

  /// <summary>
  /// Returns the globally unique identifier for this frame or &lt; 0 if the
  /// underlying frame does not yet exist.
  ///
  /// <c>int64(CEF_CALLBACK* get_identifier)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, long> _GetIdentifier;

  /// <summary>
  /// Returns the parent of this frame or NULL if this is the main (top-level)
  /// frame.
  /// <c>struct _cef_frame_t*(CEF_CALLBACK* get_parent)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefFrame*> _GetParent;

  /// <summary>
  /// Returns the URL currently loaded in this frame.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_url)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefStringUserFree*> _GetUrl;

  /// <summary>
  /// Returns the browser that this frame belongs to.
  /// <c>struct _cef_browser_t*(CEF_CALLBACK* get_browser)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefBrowser*> _GetBrowser;

  /// <summary>
  /// Get the V8 context associated with the frame. This function can only be
  /// called from the render process.
  /// <c>struct _cef_v8context_t*(CEF_CALLBACK* get_v8context)(struct _cef_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefV8Context*> _GetV8Context;

  /// <summary>
  /// Visit the DOM document. This function can only be called from the render
  /// process.
  /// <c>void(CEF_CALLBACK* visit_dom)(struct _cef_frame_t* self, struct _cef_domvisitor_t* visitor);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefDomVisitor*, void> _VisitDom;

  /// <summary>
  /// Create a new URL request that will be treated as originating from this
  /// frame and the associated browser. This request may be intercepted by the
  /// client via cef_resource_request_handler_t or cef_scheme_handler_factory_t.
  /// Use cef_urlrequest_t::Create instead if you do not want the request to
  /// have this association, in which case it may be handled differently (see
  /// documentation on that function). Requests may originate from both the
  /// browser process and the render process.
  ///
  /// For requests originating from the browser process:
  ///   - POST data may only contain a single element of type PDE_TYPE_FILE or
  ///     PDE_TYPE_BYTES.
  ///
  /// For requests originating from the render process:
  ///   - POST data may only contain a single element of type PDE_TYPE_BYTES.
  ///   - If the response contains Content-Disposition or Mime-Type header
  ///     values that would not normally be rendered then the response may
  ///     receive special handling inside the browser (for example, via the
  ///     file download code path instead of the URL request code path).
  ///
  /// The |request| object will be marked as read-only after calling this
  /// function.
  /// <c>struct _cef_urlrequest_t*(CEF_CALLBACK* create_urlrequest)(struct _cef_frame_t* self, struct _cef_request_t* request, struct _cef_urlrequest_client_t* client);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefRequest*, CefUrlRequestClient*, CefUrlRequest*> _CreateUrlRequest;

  /// <summary>
  /// Send a message to the specified |target_process|. Ownership of the message
  /// contents will be transferred and the |message| reference will be
  /// invalidated. Message delivery is not guaranteed in all cases (for example,
  /// if the browser is closing, navigating, or if the target process crashes).
  /// Send an ACK message back from the target process if confirmation is
  /// required.
  /// <c>void(CEF_CALLBACK* send_process_message)(struct _cef_frame_t* self, cef_process_id_t target_process, struct _cef_process_message_t* message);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefFrame*, CefProcessId, CefProcessMessage*, void> _SendProcessMessage;

}
