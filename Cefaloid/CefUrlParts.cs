namespace Cefaloid;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 240)]
public struct CefUrlParts {

  // cef_urlparts_t

  /// <summary>
  /// Creates a URL from the specified |parts|, which must contain a non-NULL spec
  /// or a non-NULL host and path (at a minimum), but not both. Returns false (0)
  /// if |parts| isn't initialized as described.
  /// </summary>
  /// <c>CEF_EXPORT int cef_create_url(const struct _cef_urlparts_t* parts, cef_string_t* url);</c>
  [DllImport("cef", EntryPoint = "cef_create_url", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _CreateUrl(CefUrlParts* parts, CefString* url);

  /// <inheritdoc cref="_CreateUrl"/>
  public static unsafe bool TryCreateUrl(ref CefUrlParts parts, out CefString url) {
    url = default;
    var success = _CreateUrl(parts.AsPointer(), url.AsPointer());
    return success != 0;
  }

  /// <summary>
  /// Parse the specified |url| into its component parts. Returns false (0) if the
  /// URL is NULL or invalid.
  /// <c>CEF_EXPORT int cef_parse_url(const cef_string_t* url, struct _cef_urlparts_t* parts);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_parse_url", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _ParseUrl(CefString* url, CefUrlParts* parts);

  /// <inheritdoc cref="_ParseUrl"/>
  public static unsafe bool TryParseUrl(ref CefString url, out CefUrlParts parts) {
    parts = default;
    var success = _ParseUrl(url.AsPointer(), parts.AsPointer());
    return success != 0;
  }



  public CefString Spec; // spec @ 0, 24 bytes

  public CefString Scheme; // scheme @ 24, 24 bytes

  public CefString Username; // username @ 48, 24 bytes

  public CefString Password; // password @ 72, 24 bytes

  public CefString Host; // host @ 96, 24 bytes

  public CefString Port; // port @ 120, 24 bytes

  public CefString Origin; // origin @ 144, 24 bytes

  public CefString Path; // path @ 168, 24 bytes

  public CefString Query; // query @ 192, 24 bytes

  public CefString Fragment; // fragment @ 216, 24 bytes

}
