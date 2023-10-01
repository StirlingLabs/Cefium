namespace Cefium;

/// <inheritdoc cref="CefExtension"/>
[PublicAPI]
public static class CefExtensionExtensions {

  /// <inheritdoc cref="CefExtension._GetIdentifier"/>
  public static unsafe CefStringUserFree* GetIdentifier(this ref CefExtension self)
    => self._GetIdentifier is not null ? self._GetIdentifier(self.AsPointer()) : default;

  /// <inheritdoc cref="CefExtension._GetPath"/>
  public static unsafe CefStringUserFree* GetPath(this ref CefExtension self)
    => self._GetPath is not null ? self._GetPath(self.AsPointer()) : default;

  /// <inheritdoc cref="CefExtension._GetManifest"/>
  public static unsafe CefDictionaryValue* GetManifest(this ref CefExtension self)
    => self._GetManifest is not null ? self._GetManifest(self.AsPointer()) : default;

  /// <inheritdoc cref="CefExtension._IsSame"/>
  public static unsafe bool IsSame(this ref CefExtension self, ref CefExtension that)
    => self._IsSame is not null && self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefExtension._GetHandler"/>
  public static unsafe CefExtensionHandler* GetHandler(this ref CefExtension self)
    => self._GetHandler is not null ? self._GetHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefExtension._GetLoaderContext"/>
  public static unsafe CefRequestContext* GetLoaderContext(this ref CefExtension self)
    => self._GetLoaderContext is not null ? self._GetLoaderContext(self.AsPointer()) : default;

  /// <inheritdoc cref="CefExtension._IsLoaded"/>
  public static unsafe bool IsLoaded(this ref CefExtension self)
    => self._IsLoaded is not null && self._IsLoaded(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefExtension._Unload"/>
  public static unsafe bool Unload(this ref CefExtension self) {
    if (self._Unload is null) return false;

    self._Unload(self.AsPointer());
    return true;
  }

}
