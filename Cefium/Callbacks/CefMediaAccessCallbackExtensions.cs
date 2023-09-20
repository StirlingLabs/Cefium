namespace Cefium;

/// <inheritdoc cref="CefMediaAccessCallback" />
[PublicAPI]
public static class CefMediaAccessCallbackExtensions {

  /// <inheritdoc cref="CefMediaAccessCallback._Continue"/>
  public static unsafe void Continue(ref this CefMediaAccessCallback self, CefMediaAccessPermissionTypes allowedPermissions)
    => self._Continue(self.AsPointer(), allowedPermissions);

}
