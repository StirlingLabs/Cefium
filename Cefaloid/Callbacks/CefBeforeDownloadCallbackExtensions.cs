namespace Cefaloid;

/// <inheritdoc cref="CefBeforeDownloadCallback"/>
[PublicAPI]
public static class CefBeforeDownloadCallbackExtensions {

  /// <inheritdoc cref="CefBeforeDownloadCallback._Continue"/>
  public static unsafe void Continue(ref this CefBeforeDownloadCallback self, ref CefString downloadPath, bool showDialog)
    => self._Continue(self.AsPointer(), downloadPath.AsPointer(), showDialog ? 1 : 0);

}
