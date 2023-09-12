namespace Cefaloid;

/// <summary>
/// Supports discovery of and communication with media devices on the local
/// network via the Cast and DIAL protocols. The functions of this structure may
/// be called on any browser process thread unless otherwise indicated.
/// <c>cef_media_router_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaRouter : ICefRefCountedBase<CefMediaRouter> {

  /// <inheritdoc cref="CefMediaRouter"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefMediaRouter() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the MediaRouter object associated with the global request context.
  /// If |callback| is non-NULL it will be executed asnychronously on the UI
  /// thread after the manager's storage has been initialized. Equivalent to
  /// calling cef_request_context_t::cef_request_context_get_global_context()->get
  /// _media_router().
  /// <c>CEF_EXPORT cef_media_router_t* cef_media_router_get_global(struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_media_router_get_global", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefMediaRouter* GetGlobal(CefCompletionCallback* callback);

  /// <summary>
  /// Add an observer for MediaRouter events. The observer will remain
  /// registered until the returned Registration object is destroyed.
  /// <c>struct _cef_registration_t*(CEF_CALLBACK* add_observer)(struct _cef_media_router_t* self, struct _cef_media_observer_t* observer);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRouter*, CefMediaObserver*, CefRegistration*> _AddObserver;

  /// <summary>
  /// Returns a MediaSource object for the specified media source URN. Supported
  /// URN schemes include "cast:" and "dial:", and will be already known by the
  /// client application (e.g. "cast:&lt;appId>?clientId=&amp;lt;clientId>").
  /// <c>struct _cef_media_source_t*(CEF_CALLBACK* get_source)(struct _cef_media_router_t* self, const cef_string_t* urn);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRouter*, CefString*, CefMediaSource*> _GetSource;

  /// <summary>
  /// Trigger an asynchronous call to cef_media_observer_t::OnSinks on all
  /// registered observers.
  /// <c>void(CEF_CALLBACK* notify_current_sinks)(struct _cef_media_router_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRouter*, void> _NotifyCurrentSinks;

  /// <summary>
  /// Create a new route between |source| and |sink|. Source and sink must be
  /// valid, compatible (as reported by cef_media_sink_t::IsCompatibleWith), and
  /// a route between them must not already exist. |callback| will be executed
  /// on success or failure. If route creation succeeds it will also trigger an
  /// asynchronous call to cef_media_observer_t::OnRoutes on all registered
  /// observers.
  /// <c>void(CEF_CALLBACK* create_route)(struct _cef_media_router_t* self, struct _cef_media_source_t* source, struct _cef_media_sink_t* sink, struct _cef_media_route_create_callback_t* callback);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRouter*, CefMediaSource*, CefMediaSink*, CefMediaRouteCreateCallback*, void> _CreateRoute;

  /// <summary>
  /// Trigger an asynchronous call to cef_media_observer_t::OnRoutes on all
  /// registered observers.
  /// <c>void(CEF_CALLBACK* notify_current_routes)(struct _cef_media_router_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRouter*, void> _NotifyCurrentRoutes;

}
