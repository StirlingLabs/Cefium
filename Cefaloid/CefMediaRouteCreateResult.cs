namespace Cefaloid;

/// <summary>
/// Result codes for CefMediaRouter::CreateRoute. Should be kept in sync with
/// Chromium's media_router::mojom::RouteRequestResultCode type.
/// <c>cef_media_route_create_result_t</c>
/// </summary>
[PublicAPI]
public enum CefMediaRouteCreateResult {

  /// <summary>
  /// <c>CEF_MRCR_UNKNOWN_ERROR</c>
  /// </summary>
  UnknownError = 0,

  /// <summary>
  /// <c>CEF_MRCR_OK</c>
  /// </summary>
  Ok = 1,

  /// <summary>
  /// <c>CEF_MRCR_TIMED_OUT</c>
  /// </summary>
  TimedOut = 2,

  /// <summary>
  /// <c>CEF_MRCR_ROUTE_NOT_FOUND</c>
  /// </summary>
  RouteNotFound = 3,

  /// <summary>
  /// <c>CEF_MRCR_SINK_NOT_FOUND</c>
  /// </summary>
  SinkNotFound = 4,

  /// <summary>
  /// <c>CEF_MRCR_INVALID_ORIGIN</c>
  /// </summary>
  InvalidOrigin = 5,

  /// <summary>
  /// <c>CEF_MRCR_NO_SUPPORTED_PROVIDER</c>
  /// </summary>
  NoSupportedProvider = 7,

  /// <summary>
  /// <c>CEF_MRCR_CANCELLED</c>
  /// </summary>
  Cancelled = 8,

  /// <summary>
  /// <c>CEF_MRCR_ROUTE_ALREADY_EXISTS</c>
  /// </summary>
  RouteAlreadyExists = 9,

  /// <summary>
  /// <c>CEF_MRCR_ROUTE_ALREADY_TERMINATED</c>
  /// </summary>
  RouteAlreadyTerminated = 11,

}
