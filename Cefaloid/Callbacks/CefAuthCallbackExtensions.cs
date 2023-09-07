namespace Cefaloid;

/// <inheritdoc cref="CefAuthCallback"/>
[PublicAPI]
public static class CefAuthCallbackExtensions {

  /// <inheritdoc cref="CefAuthCallback._Continue"/>
  public static unsafe void Continue(ref this CefAuthCallback self, ref CefString username, ref CefString password)
    => self._Continue(self.AsPointer(), username.AsPointer(), password.AsPointer());

  /// <inheritdoc cref="CefAuthCallback._Cancel"/>
  public static unsafe void Cancel(ref this CefAuthCallback self)
    => self._Cancel(self.AsPointer());

}
