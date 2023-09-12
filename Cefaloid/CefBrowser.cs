namespace Cefaloid;

/// <summary>
/// Structure used to represent a browser. When used in the browser process the
/// functions of this structure may be called on any thread unless otherwise
/// indicated in the comments. When used in the render process the functions of
/// this structure may only be called on the main thread.
/// <c>_cef_browser_t</c>
/// </summary>
/// <seealso cref="CefBrowserExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefBrowser : ICefRefCountedBase<CefBrowser> {

  /// <inheritdoc cref="CefBrowser"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefBrowser() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// True if this object is currently valid. This will return false (0) after
  /// cef_life_span_handler_t::OnBeforeClose is called.
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, int> _IsValid;

  /// <summary>
  /// Returns the browser host object. This function can only be called in the
  /// browser process.
  /// <c>struct _cef_browser_host_t*(CEF_CALLBACK* get_host)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, CefBrowserHost*> _GetHost;

  /// <summary>
  /// Returns true (1) if the browser can navigate backwards.
  /// <c>int(CEF_CALLBACK* can_go_back)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, int> _CanGoBack;

  /// <summary>
  /// Navigate backwards.
  /// <c>void(CEF_CALLBACK* go_back)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, void> _GoBack;

  /// <summary>
  /// Returns true (1) if the browser can navigate forwards.
  /// <c>int(CEF_CALLBACK* can_go_forward)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, int> _CanGoForward;

  /// <summary>
  /// Navigate forwards.
  /// <c>void(CEF_CALLBACK* go_forward)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, void> _GoForward;

  /// <summary>
  /// Returns true (1) if the browser is currently loading.
  /// <c>int(CEF_CALLBACK* is_loading)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, int> _IsLoading;

  /// <summary>
  /// Reload the current page.
  /// <c>void(CEF_CALLBACK* reload)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, void> _Reload;

  /// <summary>
  /// Reload the current page ignoring any cached data.
  /// <c>void(CEF_CALLBACK* reload_ignore_cache)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, void> _ReloadIgnoreCache;

  /// <summary>
  /// Stop loading the page.
  /// <c>void(CEF_CALLBACK* stop_load)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, void> _StopLoad;

  /// <summary>
  /// Returns the globally unique identifier for this browser. This value is
  /// also used as the tabId for extension APIs.
  /// <c>int(CEF_CALLBACK* get_identifier)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, int> _GetIdentifier;

  /// <summary>
  /// Returns true (1) if this object is pointing to the same handle as |that|
  /// object.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_browser_t* self,struct _cef_browser_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, CefBrowser*, int> _IsSame;

  /// <summary>
  /// Returns true (1) if the browser is a popup.
  /// <c>int(CEF_CALLBACK* is_popup)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, int> _IsPopup;

  /// <summary>
  /// Returns true (1) if a document has been loaded in the browser.
  /// <c>int(CEF_CALLBACK* has_document)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, int> _HasDocument;

  /// <summary>
  /// Returns the main (top-level) frame for the browser. In the browser process
  /// this will return a valid object until after
  /// cef_life_span_handler_t::OnBeforeClose is called. In the renderer process
  /// this will return NULL if the main frame is hosted in a different renderer
  /// process (e.g. for cross-origin sub-frames). The main frame object will
  /// change during cross-origin navigation or re-navigation after renderer
  /// process termination (due to crashes, etc).
  /// <c>struct _cef_frame_t*(CEF_CALLBACK* get_main_frame)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, CefFrame*> _GetMainFrame;

  /// <summary>
  /// Returns the focused frame for the browser.
  /// <c>struct _cef_frame_t*(CEF_CALLBACK* get_focused_frame)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, CefFrame*> _GetFocusedFrame;

  /// <summary>
  /// Returns the frame with the specified identifier, or NULL if not found.
  /// <c>struct _cef_frame_t*(CEF_CALLBACK* get_frame_byident)(struct _cef_browser_t* self, int64 identifier);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, long, CefFrame*> _GetFrameByIdent;

  /// <summary>
  /// Returns the frame with the specified name, or NULL if not found.
  /// <c>struct _cef_frame_t*(CEF_CALLBACK* get_frame)(struct _cef_browser_t* self, const cef_string_t* name);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, CefString*, CefFrame*> _GetFrame;

  /// <summary>
  /// Returns the number of frames that currently exist.
  /// <c>size_t(CEF_CALLBACK* get_frame_count)(struct _cef_browser_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, nuint> _GetFrameCount;

  /// <summary>
  /// Returns the identifiers of all existing frames.
  /// <c>void(CEF_CALLBACK* get_frame_identifiers)(struct _cef_browser_t* self, size_t* identifiersCount, int64* identifiers);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, nuint*, long*, void> _GetFrameIdentifiers;

  /// <summary>
  /// Returns the names of all existing frames.
  /// <c>void(CEF_CALLBACK* get_frame_names)(struct _cef_browser_t* self, cef_string_list_t names);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowser*, CefStringList*, void> _GetFrameNames;

}
