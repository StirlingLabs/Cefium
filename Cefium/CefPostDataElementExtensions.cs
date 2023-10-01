namespace Cefium;

/// <inheritdoc cref="CefPostDataElement"/>
[PublicAPI]
public static class CefPostDataElementExtensions {

  /// <inheritdoc cref="CefPostDataElement._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefPostDataElement self)
    => self._IsReadOnly is not null && self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostDataElement._SetToEmpty"/>
  public static unsafe bool SetToEmpty(ref this CefPostDataElement self) {
    if (self._SetToEmpty is null) return false;

    self._SetToEmpty(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefPostDataElement._SetToFile"/>
  public static unsafe bool SetToFile(ref this CefPostDataElement self, ref CefString fileName) {
    if (self._SetToFile is null) return false;

    self._SetToFile(self.AsPointer(), fileName.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefPostDataElement._SetToBytes"/>
  public static unsafe bool SetToBytes(ref this CefPostDataElement self, nuint size, void* bytes) {
    if (self._SetToBytes is null) return false;

    self._SetToBytes(self.AsPointer(), size, bytes);
    return true;
  }

  /// <inheritdoc cref="CefPostDataElement._SetToBytes"/>
  public static unsafe bool SetToBytes<T>(ref this CefPostDataElement self, ReadOnlySpan<T> span) where T : struct {
    if (self._SetToBytes is null) return false;

    var bytes = MemoryMarshal.AsBytes(span);
    fixed (void* ptr = bytes)
      self._SetToBytes(self.AsPointer(), unchecked((nuint) bytes.Length), ptr);
    return true;
  }

  /// <inheritdoc cref="CefPostDataElement._GetType"/>
  public static unsafe CefPostDataElementType GetType(ref this CefPostDataElement self)
    => self._GetType is not null ? self._GetType(self.AsPointer()) : default;

  /// <inheritdoc cref="CefPostDataElement._GetFile"/>
  public static unsafe CefStringUserFree GetFile(ref this CefPostDataElement self)
    => self._GetFile is not null ? self._GetFile(self.AsPointer()) : default;

  /// <inheritdoc cref="CefPostDataElement._GetBytesCount"/>
  public static unsafe nuint GetBytesCount(ref this CefPostDataElement self)
    => self._GetBytesCount is not null ? self._GetBytesCount(self.AsPointer()) : default;

  /// <inheritdoc cref="CefPostDataElement._GetBytes"/>
  public static unsafe nuint GetBytes(ref this CefPostDataElement self, nuint size, void* bytes)
    => self._GetBytes is not null ? self._GetBytes(self.AsPointer(), size, bytes) : default;

  /// <inheritdoc cref="CefPostDataElement._GetBytes"/>
  public static unsafe nuint GetBytes<T>(ref this CefPostDataElement self, Span<T> span) where T : struct {
    if (self._GetBytes is null) return default;

    var bytes = MemoryMarshal.AsBytes(span);
    fixed (void* ptr = bytes)
      return self._GetBytes(self.AsPointer(), unchecked((nuint) bytes.Length), ptr);
  }

}
