namespace Cefium;

/// <inheritdoc cref="CefPrintDialogCallback" />
[PublicAPI]
public static class CefPrintDialogCallbackExtensions {

  /// <inheritdoc cref="CefPrintDialogCallback._Continue"/>
  public static unsafe bool Continue(ref this CefPrintDialogCallback self, ref CefPrintSettings settings) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), settings.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefPrintDialogCallback._Cancel"/>
  public static unsafe bool Cancel(ref this CefPrintDialogCallback self) {
    if (self._Cancel is null) return false;

    self._Cancel(self.AsPointer());
    return true;
  }

}
