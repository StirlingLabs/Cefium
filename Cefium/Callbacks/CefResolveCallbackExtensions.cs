namespace Cefium;

/// <inheritdoc cref="CefResolveCallback" />
[PublicAPI]
public static class CefResolveCallbackExtensions {

  /// <inheritdoc cref="CefResolveCallback._OnResolveCompleted"/>
  public static unsafe void OnResolveCompleted(ref this CefResolveCallback self, CefErrorCode result, ref CefStringList resolvedIps)
    => self._OnResolveCompleted(self.AsPointer(), result, resolvedIps.AsPointer());

}
