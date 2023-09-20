namespace Cefium;

/// <inheritdoc cref="CefSetCookieCallback" />
[PublicAPI]
public static class CefSetCookieCallbackExtensions {

  /// <inheritdoc cref="CefSetCookieCallback._OnComplete"/>
  public static unsafe void OnComplete(ref this CefSetCookieCallback self, bool success)
    => self._OnComplete(self.AsPointer(), success ? 1 : 0);

}
