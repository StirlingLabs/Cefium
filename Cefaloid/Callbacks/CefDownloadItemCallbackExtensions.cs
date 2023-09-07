namespace Cefaloid;

/// <inheritdoc cref="CefDownloadItemCallback"/>
[PublicAPI]
public static class CefDownloadItemCallbackExtensions {

  /// <inheritdoc cref="CefDownloadItemCallback._Cancel"/>
  public static unsafe void Cancel(ref this CefDownloadItemCallback self)
    => self._Cancel(self.AsPointer());

  /// <inheritdoc cref="CefDownloadItemCallback._Pause"/>
  public static unsafe void Pause(ref this CefDownloadItemCallback self)
    => self._Pause(self.AsPointer());

  /// <inheritdoc cref="CefDownloadItemCallback._Resume"/>
  public static unsafe void Resume(ref this CefDownloadItemCallback self)
    => self._Resume(self.AsPointer());

}
