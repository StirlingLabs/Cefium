namespace Cefaloid;

/// <inheritdoc cref="CefPrintDialogCallback" />
[PublicAPI]
public static class CefPrintDialogCallbackExtensions {

  /// <inheritdoc cref="CefPrintDialogCallback._Continue"/>
  public static unsafe void Continue(ref this CefPrintDialogCallback self, ref CefPrintSettings settings)
    => self._Continue(self.AsPointer(), settings.AsPointer());

  /// <inheritdoc cref="CefPrintDialogCallback._Cancel"/>
  public static unsafe void Cancel(ref this CefPrintDialogCallback self)
    => self._Cancel(self.AsPointer());

}
