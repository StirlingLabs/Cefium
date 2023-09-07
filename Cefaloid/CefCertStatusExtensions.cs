namespace Cefaloid;

/// <inheritdoc cref="CefCertStatus"/>
[PublicAPI]
public static class CefCertStatusExtensions {

  /// <summary>
  /// Returns true (1) if the certificate status represents an error.
  /// <c>CEF_EXPORT int cef_is_cert_status_error(cef_cert_status_t status);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_is_cert_status_error", CallingConvention = CallingConvention.Cdecl)]
  internal static extern int _IsCertStatusError(CefCertStatus status);

  /// <inheritdoc cref="_IsCertStatusError"/>
  public static bool IsError(this CefCertStatus status) => _IsCertStatusError(status) != 0;

}