namespace Cefaloid;

/// <inheritdoc cref="CefGetExtensionResourceCallback" />
[PublicAPI]
public static class CefGetExtensionResourceCallbackExtensions {

  /// <inheritdoc cref="CefGetExtensionResourceCallback._Continue"/>
  public static unsafe void Continue(ref this CefGetExtensionResourceCallback self, ref CefStreamReader stream)
    => self._Continue(self.AsPointer(), stream.AsPointer());

  /// <inheritdoc cref="CefGetExtensionResourceCallback._Cancel"/>
  public static unsafe void Cancel(ref this CefGetExtensionResourceCallback self)
    => self._Cancel(self.AsPointer());

}
