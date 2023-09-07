namespace Cefaloid;

/// <summary>
/// Log severity levels.
/// <c>cef_log_severity_t</c>
/// </summary>
[PublicAPI]
public enum CefLogSeverity {

  /// <summary>
  /// Default logging (currently INFO logging).
  /// <c>LOGSEVERITY_DEFAULT</c>
  /// </summary>
  Default,

  /// <summary>
  /// Verbose logging.
  /// <c>LOGSEVERITY_VERBOSE</c>
  /// </summary>
  Verbose,

  /// <summary>
  /// DEBUG logging.
  /// <c>LOGSEVERITY_DEBUG</c>
  /// </summary>
  Debug = Verbose,

  /// <summary>
  /// INFO logging.
  /// <c>LOGSEVERITY_INFO</c>
  /// </summary>
  Info,

  /// <summary>
  /// WARNING logging.
  /// <c>LOGSEVERITY_WARNING</c>
  /// </summary>
  Warning,

  /// <summary>
  /// ERROR logging.
  /// <c>LOGSEVERITY_ERROR</c>
  /// </summary>
  Error,

  /// <summary>
  /// FATAL logging.
  /// <c>LOGSEVERITY_FATAL</c>
  /// </summary>
  Fatal,

  /// <summary>
  /// Disable logging to file for all messages, and to stderr for messages with
  /// severity less than FATAL.
  /// <c>LOGSEVERITY_DISABLE</c>
  /// </summary>
  Disable = 99

}
