namespace Cefium;

/// <summary>
/// Flags used to customize the behavior of CefURLRequest.
/// <c>cef_urlrequest_flags_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefUrlRequestFlags {

  /// <summary>
  /// Default behavior.
  /// <c>UR_FLAG_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// If set the cache will be skipped when handling the request. Setting this
  /// value is equivalent to specifying the "Cache-Control: no-cache" request
  /// header. Setting this value in combination with UR_FLAG_ONLY_FROM_CACHE
  /// will cause the request to fail.
  /// <c>UR_FLAG_SKIP_CACHE</c>
  /// </summary>
  SkipCache = 1 << 0,

  /// <summary>
  /// If set the request will fail if it cannot be served from the cache (or
  /// some equivalent local store). Setting this value is equivalent to
  /// specifying the "Cache-Control: only-if-cached" request header. Setting
  /// this value in combination with UR_FLAG_SKIP_CACHE or UR_FLAG_DISABLE_CACHE
  /// will cause the request to fail.
  /// <c>UR_FLAG_ONLY_FROM_CACHE</c>
  /// </summary>
  OnlyFromCache = 1 << 1,

  /// <summary>
  /// If set the cache will not be used at all. Setting this value is equivalent
  /// to specifying the "Cache-Control: no-store" request header. Setting this
  /// value in combination with UR_FLAG_ONLY_FROM_CACHE will cause the request
  /// to fail.
  /// <c>UR_FLAG_DISABLE_CACHE</c>
  /// </summary>
  DisableCache = 1 << 2,

  /// <summary>
  /// If set user name, password, and cookies may be sent with the request, and
  /// cookies may be saved from the response.
  /// <c>UR_FLAG_ALLOW_STORED_CREDENTIALS</c>
  /// </summary>
  AllowStoredCredentials = 1 << 3,

  /// <summary>
  /// If set upload progress events will be generated when a request has a body.
  /// <c>UR_FLAG_REPORT_UPLOAD_PROGRESS</c>
  /// </summary>
  ReportUploadProgress = 1 << 4,

  /// <summary>
  /// If set the CefURLRequestClient::OnDownloadData method will not be called.
  /// <c>UR_FLAG_NO_DOWNLOAD_DATA</c>
  /// </summary>
  NoDownloadData = 1 << 5,

  /// <summary>
  /// If set 5XX redirect errors will be propagated to the observer instead of
  /// automatically re-tried. This currently only applies for requests
  /// originated in the browser process.
  /// <c>UR_FLAG_NO_RETRY_ON_5XX</c>
  /// </summary>
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  NoRetryOn5xx = 1 << 6,

  /// <summary>
  /// If set 3XX responses will cause the fetch to halt immediately rather than
  /// continue through the redirect.
  /// <c>UR_FLAG_STOP_ON_REDIRECT</c>
  /// </summary>
  StopOnRedirect = 1 << 7,

}
