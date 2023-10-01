namespace Cefium;

/// <inheritdoc cref="CefSelectClientCertificateCallback" />
[PublicAPI]
public static class CefSelectClientCertificateCallbackExtensions {

  /// <inheritdoc cref="CefSelectClientCertificateCallback._Select"/>
  public static unsafe bool Select(ref this CefSelectClientCertificateCallback self, ref CefX509Certificate cert) {
    if (self._Select is null) return false;

    self._Select(self.AsPointer(), cert.AsPointer());
    return true;
  }

}
