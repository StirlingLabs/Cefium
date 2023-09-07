namespace Cefaloid;

/// <inheritdoc cref="CefResourceBundle"/>
[PublicAPI]
public static class CefResourceBundleExtensions {

  /// <inheritdoc cref="CefResourceBundle._GetLocalizedString"/>
  public static unsafe CefStringUserFree* GetLocalizedString(ref this CefResourceBundle self, int stringId)
    => self._GetLocalizedString(self.AsPointer(), stringId);

  /// <inheritdoc cref="CefResourceBundle._GetDataResource"/>
  public static unsafe CefBinaryValue* GetDataResource(ref this CefResourceBundle self, int resourceId)
    => self._GetDataResource(self.AsPointer(), resourceId);

  /// <inheritdoc cref="CefResourceBundle._GetDataResourceForScale"/>
  public static unsafe CefBinaryValue* GetDataResourceForScale(ref this CefResourceBundle self, int resourceId, CefScaleFactor scaleFactor)
    => self._GetDataResourceForScale(self.AsPointer(), resourceId, scaleFactor);

}
