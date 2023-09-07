namespace Cefaloid;

/// <inheritdoc cref="CefResourceSkipCallback" />
[PublicAPI]
public static class CefResourceSkipCallbackExtensions {

  /// <inheritdoc cref="CefResourceSkipCallback._Continue"/>
  public static unsafe void Continue(ref this CefResourceSkipCallback self, long bytesSkipped)
    => self._Continue(self.AsPointer(), bytesSkipped);

}
