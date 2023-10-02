namespace Cefium;

/// <inheritdoc cref="CefSchemeRegistrar"/>
[PublicAPI]
public static class CefSchemeRegistrarExtensions {

  /// <inheritdoc cref="CefSchemeRegistrar._AddCustomScheme"/>
  public static unsafe bool AddCustomScheme(this ref CefSchemeRegistrar self, ref CefString schemeName, CefSchemeOptions options)
    => self._AddCustomScheme(self.AsPointer(), schemeName.AsPointer(), options) != 0;

}
