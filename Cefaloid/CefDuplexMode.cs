namespace Cefaloid;

/// <summary>
/// Print job duplex mode values.
/// <c>cef_duplex_mode_t</c>
/// </summary>
[PublicAPI]
public enum CefDuplexMode {

  /// <summary>
  /// <c>DUPLEX_MODE_UNKNOWN</c>
  /// </summary>
  Unknown = -1,

  /// <summary>
  /// <c>DUPLEX_MODE_SIMPLEX</c>
  /// </summary>
  Simplex,

  /// <summary>
  /// <c>DUPLEX_MODE_LONG_EDGE</c>
  /// </summary>
  LongEdge,

  /// <summary>
  /// <c>DUPLEX_MODE_SHORT_EDGE</c>
  /// </summary>
  ShortEdge,

}