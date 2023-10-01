namespace Cefium;

/// <inheritdoc cref="CefRefCountedBase"/>
[PublicAPI]
public static class CefRefCountedExtensions {

  /// <inheritdoc cref="CefRefCountedBase._AddRef"/>
  public static unsafe bool AddRef(ref this CefRefCountedBase self) {
    if (self._AddRef is null) return false;

    self._AddRef(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefRefCountedBase._Release"/>
  public static unsafe bool Release(ref this CefRefCountedBase self)
    => self._Release is not null && self._Release(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefRefCountedBase._HasOneRef"/>
  public static unsafe bool HasOneRef(ref this CefRefCountedBase self)
    => self._HasOneRef is not null && self._HasOneRef(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefRefCountedBase._HasAtLeastOneRef"/>
  public static unsafe bool HasAtLeastOneRef(ref this CefRefCountedBase self)
    => self._HasAtLeastOneRef is not null && self._HasAtLeastOneRef(self.AsPointer()) != 0;

  public static ref T As<T>(ref this CefRefCountedBase self)
    where T : unmanaged, ICefRefCountedBase<T>
    => ref Unsafe.As<CefRefCountedBase, T>(ref self);

}
