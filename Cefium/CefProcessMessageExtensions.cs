namespace Cefium;

/// <inheritdoc cref="CefProcessMessage"/>
[PublicAPI]
public static class CefProcessMessageExtensions {

  /// <inheritdoc cref="CefProcessMessage._IsValid"/>
  public static unsafe bool IsValid(this ref CefProcessMessage self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefProcessMessage._IsReadOnly"/>
  public static unsafe bool IsReadOnly(this ref CefProcessMessage self) => self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefProcessMessage._Copy"/>
  public static unsafe CefProcessMessage* Copy(this ref CefProcessMessage self) => self._Copy(self.AsPointer());

  /// <inheritdoc cref="CefProcessMessage._GetName"/>
  public static unsafe CefStringUserFree* GetName(this ref CefProcessMessage self) => self._GetName(self.AsPointer());

  /// <inheritdoc cref="CefProcessMessage._GetSharedMemoryRegion"/>
  public static unsafe CefSharedMemoryRegion* GetSharedMemoryRegion(this ref CefProcessMessage self) => self._GetSharedMemoryRegion(self.AsPointer());

}
