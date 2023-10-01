namespace Cefium;

/// <inheritdoc cref="CefGetExtensionResourceCallback" />
[PublicAPI]
public static class CefGetExtensionResourceCallbackExtensions {

  /// <inheritdoc cref="CefGetExtensionResourceCallback._Continue"/>
  public static unsafe bool Continue(ref this CefGetExtensionResourceCallback self, ref CefStreamReader stream) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), stream.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefGetExtensionResourceCallback._Cancel"/>
  public static unsafe bool Cancel(ref this CefGetExtensionResourceCallback self) {
    if (self._Cancel is null) return false;

    self._Cancel(self.AsPointer());
    return true;
  }

}
