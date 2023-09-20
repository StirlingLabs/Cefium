namespace Cefium;

/// <inheritdoc cref="CefScopedBase"/>
[PublicAPI]
public static class CefScopedBaseExtensions {

  /// <inheritdoc cref="CefScopedBase._Delete"/>
  public static unsafe void Delete(ref this CefScopedBase self) {
    if (self._Delete is not null) self._Delete(self.AsPointer());
  }

}
