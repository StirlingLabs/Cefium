namespace Cefium;

/// <inheritdoc cref="CefCallback"/>
[PublicAPI]
public static class CefCallbackExtensions {

  /// <inheritdoc cref="CefCallback._Continue"/>
  public static unsafe bool Continue(ref this CefCallback self) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer());
    return true;
  }

}
