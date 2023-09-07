namespace Cefaloid;

/// <summary>
/// Flags that represent CefURLRequest status.
/// <c>cef_urlrequest_status_t</c>
/// </summary>
[PublicAPI]
public enum CefUrlRequestStatus {
  /// <summary>
  /// Unknown status.
  /// <c>UR_UNKNOWN</c>
  /// </summary>
  Unknown = 0,
  /// <summary>
  /// Request succeeded.
  /// <c>UR_SUCCESS</c>
  /// </summary>
  Success,
  /// <summary>
  /// An IO request is pending, and the caller will be informed when it is
  /// completed.
  /// <c>UR_IO_PENDING</c>
  /// </summary>
  IoPending,
  /// <summary>
  /// Request was canceled programatically.
  /// <c>UR_CANCELED</c>
  /// </summary>
  Canceled,
  /// <summary>
  /// Request failed for some reason.
  /// <c>UR_FAILED</c>
  /// </summary>
  Failed,
}
