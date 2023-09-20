namespace Cefium;

/// <inheritdoc cref="CefPdfPrintCallback" />
[PublicAPI]
public static class CefPdfPrintCallbackExtensions {

  /// <inheritdoc cref="CefPdfPrintCallback._OnPdfPrintFinished"/>
  public static unsafe void OnPdfPrintFinished(ref this CefPdfPrintCallback self, ref CefString path, bool ok)
    => self._OnPdfPrintFinished(self.AsPointer(), path.AsPointer(), ok ? 1 : 0);

}
