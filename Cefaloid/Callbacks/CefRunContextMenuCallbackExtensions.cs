namespace Cefaloid;

/// <inheritdoc cref="CefRunContextMenuCallback" />
[PublicAPI]
public static class CefRunContextMenuCallbackExtensions {

  /// <inheritdoc cref="CefRunContextMenuCallback._Continue"/>
  public static unsafe void Continue(ref this CefRunContextMenuCallback self, int commandId, CefEventFlags eventFlags)
    => self._Continue(self.AsPointer(), commandId, eventFlags);

  /// <inheritdoc cref="CefRunContextMenuCallback._Cancel"/>
  public static unsafe void Cancel(ref this CefRunContextMenuCallback self)
    => self._Cancel(self.AsPointer());

}
