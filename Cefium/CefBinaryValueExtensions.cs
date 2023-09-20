namespace Cefium;

/// <inheritdoc cref="CefBinaryValue"/>
public static class CefBinaryValueExtensions {

  /// <inheritdoc cref="CefBinaryValue._IsValid"/>
  public static unsafe bool IsValid(ref this CefBinaryValue self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBinaryValue._IsOwned"/>
  public static unsafe bool IsOwned(ref this CefBinaryValue self) => self._IsOwned(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBinaryValue._IsSame"/>
  public static unsafe bool IsSame(ref this CefBinaryValue self, ref CefBinaryValue that) => self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefBinaryValue._IsEqual"/>
  public static unsafe bool IsEqual(ref this CefBinaryValue self, ref CefBinaryValue that) => self._IsEqual(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefBinaryValue._Copy"/>
  public static unsafe CefBinaryValue* Copy(ref this CefBinaryValue self) => self._Copy(self.AsPointer());

  /// <inheritdoc cref="CefBinaryValue._GetSize"/>
  public static unsafe nuint GetSize(ref this CefBinaryValue self) => self._GetSize(self.AsPointer());

  /// <inheritdoc cref="CefBinaryValue._GetData"/>
  public static unsafe nuint GetData(ref this CefBinaryValue self, void* buffer, nuint bufferSize, nuint dataOffset) => self._GetData(self.AsPointer(), buffer, bufferSize, dataOffset);

}
