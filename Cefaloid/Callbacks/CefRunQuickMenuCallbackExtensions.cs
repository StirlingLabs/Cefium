namespace Cefaloid;

/// <inheritdoc cref="CefRunQuickMenuCallback" />
[PublicAPI]
public static class CefRunQuickMenuCallbackExtensions {

  /// <inheritdoc cref="CefRunQuickMenuCallback._Continue"/>
  public static unsafe void Continue(ref this CefRunQuickMenuCallback self, int commandId, CefEventFlags eventFlags)
    => self._Continue(self.AsPointer(), commandId, eventFlags);

  /// <inheritdoc cref="CefRunQuickMenuCallback._Cancel"/>
  public static unsafe void Cancel(ref this CefRunQuickMenuCallback self)
    => self._Cancel(self.AsPointer());

}
