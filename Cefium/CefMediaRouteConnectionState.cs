namespace Cefium;

/// <summary>
/// Connection state for a MediaRoute object.
/// <c>cef_media_route_connection_state_t</c>
/// </summary>
[PublicAPI]
public enum CefMediaRouteConnectionState {

  /// <summary>
  /// <c>CEF_MRCS_UNKNOWN</c>
  /// </summary>
  Unknown,

  /// <summary>
  /// <c>CEF_MRCS_CONNECTING</c>
  /// </summary>
  Connecting,

  /// <summary>
  /// <c>CEF_MRCS_CONNECTED</c>
  /// </summary>
  Connected,

  /// <summary>
  /// <c>CEF_MRCS_CLOSED</c>
  /// </summary>
  Closed,

  /// <summary>
  /// <c>CEF_MRCS_TERMINATED</c>
  /// </summary>
  Terminated,

}
