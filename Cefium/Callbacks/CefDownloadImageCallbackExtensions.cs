namespace Cefium;

/// <inheritdoc cref="CefDownloadImageCallback"/>
[PublicAPI]
public static class CefDownloadImageCallbackExtensions {

  /// <inheritdoc cref="CefDownloadImageCallback._OnDownloadImageFinished"/>
  public static unsafe bool OnDownloadImageFinished(ref this CefDownloadImageCallback self, ref CefString imageUrl, int httpStatusCode, ref CefImage image) {
    if (self._OnDownloadImageFinished is null) return false;

    self._OnDownloadImageFinished(self.AsPointer(), imageUrl.AsPointer(), httpStatusCode, image.AsPointer());
    return true;
  }

}
