namespace Cefium;

/// <summary>
/// <c>cef_preferences_type_t</c>
/// </summary>
[PublicAPI]
public enum CefPreferencesType {

  /// <summary>
  /// Global preferences registered a single time at application startup.
  /// <c>CEF_PREFERENCES_TYPE_GLOBAL</c>
  /// </summary>
  Global,

  /// <summary>
  /// Request context preferences registered each time a new CefRequestContext
  /// is created.
  /// <c>CEF_PREFERENCES_TYPE_REQUEST_CONTEXT</c>
  /// </summary>
  RequestContext

}
