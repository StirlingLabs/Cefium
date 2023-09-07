namespace Cefaloid;

/// <summary>
/// Process termination status values.
/// <c>cef_termination_status_t</c>
/// </summary>
[PublicAPI]
public enum CefTerminationStatus {

  /// <summary>
  /// Non-zero exit status.
  /// <c>TS_ABNORMAL_TERMINATION</c>
  /// </summary>
  AbnormalTermination,

  /// <summary>
  /// SIGKILL or task manager kill.
  /// <c>TS_PROCESS_WAS_KILLED</c>
  /// </summary>
  ProcessWasKilled,

  /// <summary>
  /// Segmentation fault.
  /// <c>TS_PROCESS_CRASHED</c>
  /// </summary>
  ProcessCrashed,

  /// <summary>
  /// Out of memory. Some platforms may use TS_PROCESS_CRASHED instead.
  /// <c>TS_PROCESS_OOM</c>
  /// </summary>
  ProcessOom,

}