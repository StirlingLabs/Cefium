namespace Cefaloid;

/// <inheritdoc cref="CefPermissionPromptCallback" />
[PublicAPI]
public static class CefPermissionPromptCallbackExtensions {

  /// <inheritdoc cref="CefPermissionPromptCallback._Continue"/>
  public static unsafe void Continue(ref this CefPermissionPromptCallback self, CefPermissionRequestResult result)
    => self._Continue(self.AsPointer(), result);

}
