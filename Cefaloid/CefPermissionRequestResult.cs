namespace Cefaloid;

/// <summary>
/// Permission request results.
/// <c>cef_permission_request_result_t</c>
/// </summary>
[PublicAPI]
public enum CefPermissionRequestResult {

  /// <summary>
  /// Accept the permission request as an explicit user action.
  /// <c>CEF_PERMISSION_RESULT_ACCEPT</c>
  /// </summary>
  Accept,

  /// <summary>
  /// Deny the permission request as an explicit user action.
  /// <c>CEF_PERMISSION_RESULT_DENY</c>
  /// </summary>
  Deny,

  /// <summary>
  /// Dismiss the permission request as an explicit user action.
  /// <c>CEF_PERMISSION_RESULT_DISMISS</c>
  /// </summary>
  Dismiss,

  /// <summary>
  /// Ignore the permission request. If the prompt remains unhandled (e.g.
  /// OnShowPermissionPrompt returns false and there is no default permissions
  /// UI) then any related promises may remain unresolved.
  /// <c>CEF_PERMISSION_RESULT_IGNORE</c>
  /// </summary>
  Ignore,

}
