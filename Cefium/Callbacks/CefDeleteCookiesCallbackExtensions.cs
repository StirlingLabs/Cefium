namespace Cefium;

/// <inheritdoc cref="CefDeleteCookiesCallback"/>
[PublicAPI]
public static class CefDeleteCookiesCallbackExtensions {

  /// <inheritdoc cref="CefDeleteCookiesCallback._OnComplete"/>
  public static unsafe bool OnComplete(ref this CefDeleteCookiesCallback self, int numDeleted) {
    if (self._OnComplete is null) return false;

    self._OnComplete(self.AsPointer(), numDeleted);
    return true;
  }

}
