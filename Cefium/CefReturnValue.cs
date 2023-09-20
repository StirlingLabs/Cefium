namespace Cefium;

/// <summary>
/// Return value types.
/// <c>cef_return_value_t</c>
/// </summary>
[PublicAPI]
public enum CefReturnValue {

  /// <summary>
  /// Cancel immediately.
  /// <c>RV_CANCEL</c>
  /// </summary>
  Cancel = 0,

  /// <summary>
  /// Continue immediately.
  /// <c>RV_CONTINUE</c>
  /// </summary>
  Continue,

  /// <summary>
  /// Continue asynchronously (usually via a callback).
  /// <c>RV_CONTINUE_ASYNC</c>
  /// </summary>
  ContinueAsync,

}
