namespace Cefaloid;

/// <inheritdoc cref="CefDownloadImageCallback"/>
[PublicAPI]
public static class CefDownloadImageCallbackExtensions {

  /// <inheritdoc cref="CefDownloadImageCallback._OnDownloadImageFinished"/>
  public static unsafe void OnComplete(ref this CefDownloadImageCallback self, ref CefString imageUrl, int httpStatusCode, ref CefImage image)
    => self._OnDownloadImageFinished(self.AsPointer(), imageUrl.AsPointer(), httpStatusCode, image.AsPointer());

}
