namespace Cefium;

/// <inheritdoc cref="CefSharedMemoryRegion"/>
[PublicAPI]
public static class CefSharedMemoryRegionExtensions {

  /// <inheritdoc cref="CefSharedMemoryRegion._IsValid"/>
  public static unsafe bool IsValid(this ref CefSharedMemoryRegion self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefSharedMemoryRegion._Size"/>
  public static unsafe nuint Size(this ref CefSharedMemoryRegion self) => self._Size(self.AsPointer());

  /// <inheritdoc cref="CefSharedMemoryRegion._Memory"/>
  public static unsafe void* Memory(this ref CefSharedMemoryRegion self) => self._Memory(self.AsPointer());

  public static unsafe Span<byte> AsSpan(this ref CefSharedMemoryRegion self)
    => new(self.Memory(), checked((int) self.Size()));

  public static unsafe ReadOnlySpan<byte> AsReadOnlySpan(this ref CefSharedMemoryRegion self)
    => new(self.Memory(), checked((int) self.Size()));

  public static Span<T> AsSpan<T>(this ref CefSharedMemoryRegion self) where T : struct
    => MemoryMarshal.Cast<byte, T>(self.AsSpan());

  public static ReadOnlySpan<T> AsReadOnlySpan<T>(this ref CefSharedMemoryRegion self) where T : struct
    => MemoryMarshal.Cast<byte, T>(self.AsReadOnlySpan());

}
