namespace Cefium;

/// <inheritdoc cref="CefCallback"/>
[PublicAPI]
public static class CefCallbackExtensions {

  /// <inheritdoc cref="CefCallback._Continue"/>
  public static unsafe void Continue(ref this CefCallback self)
    => self._Continue(self.AsPointer());

}
