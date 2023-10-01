namespace Cefium;

/// <inheritdoc cref="CefPdfPrintCallback" />
[PublicAPI]
public static class CefPdfPrintCallbackExtensions {

  /// <inheritdoc cref="CefPdfPrintCallback._OnPdfPrintFinished"/>
  public static unsafe bool OnPdfPrintFinished(ref this CefPdfPrintCallback self, ref CefString path, bool ok) {
    if (self._OnPdfPrintFinished is null) return false;

    self._OnPdfPrintFinished(self.AsPointer(), path.AsPointer(), ok ? 1 : 0);
    return true;
  }

}
