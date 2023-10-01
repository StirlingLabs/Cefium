namespace Cefium;

/// <inheritdoc cref="CefV8ArrayBufferReleaseCallback"/>
[PublicAPI]
public static class CefV8ArrayBufferReleaseCallbackExtensions {

  /// <inheritdoc cref="CefV8ArrayBufferReleaseCallback._ReleaseBuffer"/>
  public static unsafe bool ReleaseBuffer(ref this CefV8ArrayBufferReleaseCallback self, void* buffer) {
    if (self._ReleaseBuffer is null) return false;

    self._ReleaseBuffer(self.AsPointer(), buffer);
    return true;
  }

}
