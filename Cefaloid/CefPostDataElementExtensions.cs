namespace Cefaloid;

/// <inheritdoc cref="CefPostDataElement"/>
[PublicAPI]
public static class CefPostDataElementExtensions {

  /// <inheritdoc cref="CefPostDataElement._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefPostDataElement self) => self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostDataElement._SetToEmpty"/>
  public static unsafe void SetToEmpty(ref this CefPostDataElement self) => self._SetToEmpty(self.AsPointer());

  /// <inheritdoc cref="CefPostDataElement._SetToFile"/>
  public static unsafe void SetToFile(ref this CefPostDataElement self, ref CefString fileName) => self._SetToFile(self.AsPointer(), fileName.AsPointer());

  /// <inheritdoc cref="CefPostDataElement._SetToBytes"/>
  public static unsafe void SetToBytes(ref this CefPostDataElement self, nuint size, void* bytes) => self._SetToBytes(self.AsPointer(), size, bytes);

  /// <inheritdoc cref="CefPostDataElement._SetToBytes"/>
  public static unsafe void SetToBytes<T>(ref this CefPostDataElement self, ReadOnlySpan<T> span) where T : struct {
    var bytes = MemoryMarshal.AsBytes(span);
    fixed (void* ptr = bytes)
      self._SetToBytes(self.AsPointer(), unchecked((nuint) bytes.Length), ptr);
  }

  /// <inheritdoc cref="CefPostDataElement._GetType"/>
  public static unsafe CefPostDataElementType GetType(ref this CefPostDataElement self) => self._GetType(self.AsPointer());

  /// <inheritdoc cref="CefPostDataElement._GetFile"/>
  public static unsafe CefStringUserFree GetFile(ref this CefPostDataElement self) => self._GetFile(self.AsPointer());

  /// <inheritdoc cref="CefPostDataElement._GetBytesCount"/>
  public static unsafe nuint GetBytesCount(ref this CefPostDataElement self) => self._GetBytesCount(self.AsPointer());

  /// <inheritdoc cref="CefPostDataElement._GetBytes"/>
  public static unsafe nuint GetBytes(ref this CefPostDataElement self, nuint size, void* bytes) => self._GetBytes(self.AsPointer(), size, bytes);

  /// <inheritdoc cref="CefPostDataElement._GetBytes"/>
  public static unsafe nuint GetBytes<T>(ref this CefPostDataElement self, Span<T> span) where T : struct {
    var bytes = MemoryMarshal.AsBytes(span);
    fixed (void* ptr = bytes)
      return self._GetBytes(self.AsPointer(), unchecked((nuint) bytes.Length), ptr);
  }

}
