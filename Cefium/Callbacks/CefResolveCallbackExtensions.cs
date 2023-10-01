namespace Cefium;

/// <inheritdoc cref="CefResolveCallback" />
[PublicAPI]
public static class CefResolveCallbackExtensions {

  /// <inheritdoc cref="CefResolveCallback._OnResolveCompleted"/>
  public static unsafe bool OnResolveCompleted(ref this CefResolveCallback self, CefErrorCode result, ref CefStringList resolvedIps) {
    if (self._OnResolveCompleted is null) return false;

    self._OnResolveCompleted(self.AsPointer(), result, resolvedIps.AsPointer());
    return true;
  }

}
