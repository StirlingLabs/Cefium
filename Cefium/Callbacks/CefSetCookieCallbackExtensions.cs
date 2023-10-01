namespace Cefium;

/// <inheritdoc cref="CefSetCookieCallback" />
[PublicAPI]
public static class CefSetCookieCallbackExtensions {

  /// <inheritdoc cref="CefSetCookieCallback._OnComplete"/>
  public static unsafe bool OnComplete(ref this CefSetCookieCallback self, bool success) {
    if (self._OnComplete is null) return false;

    self._OnComplete(self.AsPointer(), success ? 1 : 0);
    return true;
  }

}
