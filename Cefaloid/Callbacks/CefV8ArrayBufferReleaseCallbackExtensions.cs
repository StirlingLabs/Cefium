namespace Cefaloid;

/// <inheritdoc cref="CefV8ArrayBufferReleaseCallback"/>
[PublicAPI]
public static class CefV8ArrayBufferReleaseCallbackExtensions {

  /// <inheritdoc cref="CefV8ArrayBufferReleaseCallback._ReleaseBuffer"/>
  public static unsafe void ReleaseBuffer(ref this CefV8ArrayBufferReleaseCallback self, void* buffer)
    => self._ReleaseBuffer(self.AsPointer(), buffer);

}
