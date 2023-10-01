namespace Cefium;

/// <inheritdoc cref="CefResourceSkipCallback" />
[PublicAPI]
public static class CefResourceSkipCallbackExtensions {

  /// <inheritdoc cref="CefResourceSkipCallback._Continue"/>
  public static unsafe bool Continue(ref this CefResourceSkipCallback self, long bytesSkipped) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), bytesSkipped);
    return true;
  }

}
