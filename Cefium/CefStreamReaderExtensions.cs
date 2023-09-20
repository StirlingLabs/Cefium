namespace Cefium;

/// <inheritdoc cref="CefStreamReader" />
[PublicAPI]
public static class CefStreamReaderExtensions {

  /// <inheritdoc cref="CefStreamReader._Read"/>
  public static unsafe nuint Read(ref this CefStreamReader self, void* ptr, nuint size, nuint n)
    => self._Read(self.AsPointer(), ptr, size, n);

  /// <inheritdoc cref="CefStreamReader._Seek"/>
  public static unsafe bool Seek(ref this CefStreamReader self, long offset, int whence)
    => self._Seek(self.AsPointer(), offset, whence) == 0;

  /// <inheritdoc cref="CefStreamReader._Tell"/>
  public static unsafe long Tell(ref this CefStreamReader self)
    => self._Tell(self.AsPointer());

  /// <inheritdoc cref="CefStreamReader._Eof"/>
  public static unsafe bool Eof(ref this CefStreamReader self)
    => self._Eof(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefStreamReader._MayBlock"/>
  public static unsafe bool MayBlock(ref this CefStreamReader self)
    => self._MayBlock(self.AsPointer()) != 0;

}
