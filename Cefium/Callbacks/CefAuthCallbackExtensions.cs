namespace Cefium;

/// <inheritdoc cref="CefAuthCallback"/>
[PublicAPI]
public static class CefAuthCallbackExtensions {

  /// <inheritdoc cref="CefAuthCallback._Continue"/>
  public static unsafe bool Continue(ref this CefAuthCallback self, ref CefString username, ref CefString password) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), username.AsPointer(), password.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefAuthCallback._Cancel"/>
  public static unsafe bool Cancel(ref this CefAuthCallback self) {
    if (self._Cancel is null) return false;

    self._Cancel(self.AsPointer());
    return true;
  }

}
