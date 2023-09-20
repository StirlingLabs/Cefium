namespace Cefium;

/// <summary>
/// Supported SSL content status flags. See content/public/common/ssl_status.h
/// for more information.
/// <c>cef_ssl_content_status_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefSslContentStatus {

  /// <summary>
  /// <c>SSL_CONTENT_NORMAL_CONTENT</c>
  /// </summary>
  NormalContent = 0,

  /// <summary>
  /// <c>SSL_CONTENT_DISPLAYED_INSECURE_CONTENT</c>
  /// </summary>
  DisplayedInsecureContent = 1 << 0,

  /// <summary>
  /// <c>SSL_CONTENT_RAN_INSECURE_CONTENT</c>
  /// </summary>
  RanInsecureContent = 1 << 1,

}
