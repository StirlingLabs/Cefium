namespace Cefium;

/// <inheritdoc cref="CefDeleteCookiesCallback"/>
[PublicAPI]
public static class CefDeleteCookiesCallbackExtensions {

  /// <inheritdoc cref="CefDeleteCookiesCallback._OnComplete"/>
  public static unsafe void OnComplete(ref this CefDeleteCookiesCallback self, int numDeleted)
    => self._OnComplete(self.AsPointer(), numDeleted);

}
