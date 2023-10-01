namespace Cefium;

/// <inheritdoc cref="CefRunContextMenuCallback" />
[PublicAPI]
public static class CefRunContextMenuCallbackExtensions {

  /// <inheritdoc cref="CefRunContextMenuCallback._Continue"/>
  public static unsafe bool Continue(ref this CefRunContextMenuCallback self, int commandId, CefEventFlags eventFlags) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), commandId, eventFlags);
    return true;
  }

  /// <inheritdoc cref="CefRunContextMenuCallback._Cancel"/>
  public static unsafe bool Cancel(ref this CefRunContextMenuCallback self) {
    if (self._Cancel is null) return false;

    self._Cancel(self.AsPointer());
    return true;
  }

}
