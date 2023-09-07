namespace Cefaloid;

/// <inheritdoc cref="CefSelectClientCertificateCallback" />
[PublicAPI]
public static class CefSelectClientCertificateCallbackExtensions {

  /// <inheritdoc cref="CefSelectClientCertificateCallback._Select"/>
  public static unsafe void Select(ref this CefSelectClientCertificateCallback self, ref CefX509Certificate cert)
    => self._Select(self.AsPointer(), cert.AsPointer());

}
