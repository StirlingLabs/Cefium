namespace Cefium;

/// <inheritdoc cref="CefResourceReadCallback" />
[PublicAPI]
public static class CefResourceReadCallbackExtensions {

  /// <inheritdoc cref="CefResourceReadCallback._Continue"/>
  public static unsafe bool Continue(ref this CefResourceReadCallback self, int bytesRead) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), bytesRead);
    return true;
  }

}
