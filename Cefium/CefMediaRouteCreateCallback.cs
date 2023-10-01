namespace Cefium;

/// <summary>
/// Callback structure for cef_media_router_t::CreateRoute. The functions of
/// this structure will be called on the browser process UI thread.
/// <c>cef_media_route_create_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaRouteCreateCallback : ICefRefCountedBase<CefMediaRouteCreateCallback> {

  /// <inheritdoc cref="CefMediaRouteCreateCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefMediaRouteCreateCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be executed when the route creation has finished.
  /// |result| will be CEF_MRCR_OK if the route creation succeeded. |error| will
  /// be a description of the error if the route creation failed. |route| is the
  /// resulting route, or NULL if the route creation failed.
  /// <c>void(CEF_CALLBACK* on_media_route_create_finished)(struct _cef_media_route_create_callback_t* self, cef_media_route_create_result_t result, const cef_string_t* error, struct _cef_media_route_t* route);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaRouteCreateCallback*, CefMediaRouteCreateResult, CefString*, CefMediaRoute*, void> _OnMediaRouteCreateFinished;

}
