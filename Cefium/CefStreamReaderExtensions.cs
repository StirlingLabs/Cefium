namespace Cefium;

/// <inheritdoc cref="CefStreamReader" />
[PublicAPI]
public static class CefStreamReaderExtensions {

  /// <inheritdoc cref="CefStreamReader._Read"/>
  public static unsafe nuint Read(ref this CefStreamReader self, void* ptr, nuint size, nuint n)
    => self._Read is not null ? self._Read(self.AsPointer(), ptr, size, n) : default;

  /// <inheritdoc cref="CefStreamReader._Seek"/>
  public static unsafe bool Seek(ref this CefStreamReader self, long offset, int whence) {
    if (self._Seek is null) return false;

    return self._Seek(self.AsPointer(), offset, whence) == 0;
  }

  /// <inheritdoc cref="CefStreamReader._Tell"/>
  public static unsafe long Tell(ref this CefStreamReader self)
    => self._Tell is not null ? self._Tell(self.AsPointer()) : default;

  /// <inheritdoc cref="CefStreamReader._Eof"/>
  public static unsafe bool Eof(ref this CefStreamReader self)
    => self._Eof is not null && self._Eof(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefStreamReader._MayBlock"/>
  public static unsafe bool MayBlock(ref this CefStreamReader self)
    => self._MayBlock is not null && self._MayBlock(self.AsPointer()) != 0;

}
