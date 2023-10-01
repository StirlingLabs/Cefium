namespace Cefium;

/// <inheritdoc cref="CefPermissionPromptCallback" />
[PublicAPI]
public static class CefPermissionPromptCallbackExtensions {

  /// <inheritdoc cref="CefPermissionPromptCallback._Continue"/>
  public static unsafe bool Continue(ref this CefPermissionPromptCallback self, CefPermissionRequestResult result) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), result);
    return true;
  }

}
