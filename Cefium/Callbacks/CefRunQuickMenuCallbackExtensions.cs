namespace Cefium;

/// <inheritdoc cref="CefRunQuickMenuCallback" />
[PublicAPI]
public static class CefRunQuickMenuCallbackExtensions {

  /// <inheritdoc cref="CefRunQuickMenuCallback._Continue"/>
  public static unsafe bool Continue(ref this CefRunQuickMenuCallback self, int commandId, CefEventFlags eventFlags) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), commandId, eventFlags);
    return true;
  }

  /// <inheritdoc cref="CefRunQuickMenuCallback._Cancel"/>
  public static unsafe bool Cancel(ref this CefRunQuickMenuCallback self) {
    if (self._Cancel is null) return false;

    self._Cancel(self.AsPointer());
    return true;
  }

}
