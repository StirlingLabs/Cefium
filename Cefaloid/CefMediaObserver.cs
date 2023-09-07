namespace Cefaloid;

/// <summary>
/// Implemented by the client to observe MediaRouter events and registered via
/// cef_media_router_t::AddObserver. The functions of this structure will be
/// called on the browser process UI thread.
/// <c>cef_media_observer_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaObserver : ICefRefCountedBase<CefMediaObserver> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefMediaObserver() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// The list of available media sinks has changed or
  /// cef_media_router_t::NotifyCurrentSinks was called.
  /// <c>void(CEF_CALLBACK* on_sinks)(struct _cef_media_observer_t* self, size_t sinksCount, struct _cef_media_sink_t* const* sinks);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaObserver*, nuint, CefMediaSink**, void> _OnSinks;

  /// <summary>
  /// The list of available media routes has changed or
  /// cef_media_router_t::NotifyCurrentRoutes was called.
  /// <c>void(CEF_CALLBACK* on_routes)(struct _cef_media_observer_t* self, size_t routesCount, struct _cef_media_route_t* const* routes);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaObserver*, nuint, CefMediaRoute**, void> _OnRoutes;

  /// <summary>
  /// The connection state of |route| has changed.
  /// <c>void(CEF_CALLBACK* on_route_state_changed)(struct _cef_media_observer_t* self, struct _cef_media_route_t* route, cef_media_route_connection_state_t state);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaObserver*, CefMediaRoute*, CefMediaRouteConnectionState, void> _OnRouteStateChanged;

  /// <summary>
  /// A message was recieved over |route|. |message| is only valid for the scope
  /// of this callback and should be copied if necessary.
  /// <c>void(CEF_CALLBACK* on_route_message_received)(struct _cef_media_observer_t* self, struct _cef_media_route_t* route, const void* message, size_t message_size);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaObserver*, CefMediaRoute*, void*, nuint, void> _OnRouteMessageReceived;

}
