namespace Cefium;

/// <inheritdoc cref="CefScopedBase"/>
[PublicAPI]
public static class CefScopedBaseExtensions {

  /// <inheritdoc cref="CefScopedBase._Delete"/>
  public static unsafe bool Delete(ref this CefScopedBase self) {
    if (self._Delete is null)
      return false;

    self._Delete(self.AsPointer());
    return true;
  }

}
