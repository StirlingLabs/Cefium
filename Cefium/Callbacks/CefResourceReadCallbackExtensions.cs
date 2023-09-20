namespace Cefium;

/// <inheritdoc cref="CefResourceReadCallback" />
[PublicAPI]
public static class CefResourceReadCallbackExtensions {

  /// <inheritdoc cref="CefResourceReadCallback._Continue"/>
  public static unsafe void Continue(ref this CefResourceReadCallback self, int bytesRead)
    => self._Continue(self.AsPointer(), bytesRead);

}
