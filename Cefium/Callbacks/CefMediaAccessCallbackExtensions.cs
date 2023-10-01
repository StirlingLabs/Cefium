namespace Cefium;

/// <inheritdoc cref="CefMediaAccessCallback" />
[PublicAPI]
public static class CefMediaAccessCallbackExtensions {

  /// <inheritdoc cref="CefMediaAccessCallback._Continue"/>
  public static unsafe bool Continue(ref this CefMediaAccessCallback self, CefMediaAccessPermissionTypes allowedPermissions) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), allowedPermissions);
    return true;
  }

}
