namespace Cefium;

/// <inheritdoc cref="CefBeforeDownloadCallback"/>
[PublicAPI]
public static class CefBeforeDownloadCallbackExtensions {

  /// <inheritdoc cref="CefBeforeDownloadCallback._Continue"/>
  public static unsafe bool Continue(ref this CefBeforeDownloadCallback self, ref CefString downloadPath, bool showDialog) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), downloadPath.AsPointer(), showDialog ? 1 : 0);
    return true;
  }

}
