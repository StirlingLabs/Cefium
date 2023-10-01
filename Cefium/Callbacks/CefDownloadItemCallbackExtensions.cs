namespace Cefium;

/// <inheritdoc cref="CefDownloadItemCallback"/>
[PublicAPI]
public static class CefDownloadItemCallbackExtensions {

  /// <inheritdoc cref="CefDownloadItemCallback._Cancel"/>
  public static unsafe bool Cancel(ref this CefDownloadItemCallback self) {
    if (self._Cancel is null) return false;

    self._Cancel(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefDownloadItemCallback._Pause"/>
  public static unsafe bool Pause(ref this CefDownloadItemCallback self) {
    if (self._Pause is null) return false;

    self._Pause(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefDownloadItemCallback._Resume"/>
  public static unsafe bool Resume(ref this CefDownloadItemCallback self) {
    if (self._Resume is null) return false;

    self._Resume(self.AsPointer());
    return true;
  }

}
