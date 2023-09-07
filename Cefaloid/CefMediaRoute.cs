namespace Cefaloid;

/// <summary>
/// Represents the route between a media source and sink. Instances of this
/// object are created via cef_media_router_t::CreateRoute and retrieved via
/// cef_media_observer_t::OnRoutes. Contains the status and metadata of a
/// routing operation. The functions of this structure may be called on any
/// browser process thread unless otherwise indicated.
/// <c>cef_media_route_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaRoute : ICefRefCountedBase<CefMediaRoute> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefMediaRoute() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the ID for this route.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_id)(struct _cef_media_route_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRoute*, CefStringUserFree*> _GetId;

  /// <summary>
  /// Returns the source associated with this route.
  /// <c>struct _cef_media_source_t*(CEF_CALLBACK* get_source)(struct _cef_media_route_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRoute*, CefMediaSource*> _GetSource;

  /// <summary>
  /// Returns the sink associated with this route.
  /// <c>struct _cef_media_sink_t*(CEF_CALLBACK* get_sink)(struct _cef_media_route_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRoute*, CefMediaSink*> _GetSink;

  /// <summary>
  /// Send a message over this route. |message| will be copied if necessary.
  /// <c>void(CEF_CALLBACK* send_route_message)(struct _cef_media_route_t* self, const void* message, size_t message_size);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRoute*, void*, nuint, void> _SendRouteMessage;

  /// <summary>
  /// Terminate this route. Will result in an asynchronous call to
  /// cef_media_observer_t::OnRoutes on all registered observers.
  /// <c>void(CEF_CALLBACK* terminate)(struct _cef_media_route_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRoute*, void> _Terminate;

}
