namespace Cefaloid;

/// <summary>
/// Existing process IDs.
/// </summary>
[PublicAPI]
public enum CefProcessId {

  /// <summary>
  /// Browser process.
  /// <c>PID_BROWSER</c>
  /// </summary>
  Browser = 0,

  /// <summary>
  /// Renderer process.
  /// <c>PID_RENDERER</c>
  /// </summary>
  Renderer,

}
