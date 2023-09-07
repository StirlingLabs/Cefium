namespace Cefaloid;

/// <inheritdoc cref="CefExtension"/>
[PublicAPI]
public static class CefExtensionExtensions {

  /// <inheritdoc cref="CefExtension._GetIdentifier"/>
  public static unsafe CefStringUserFree* GetIdentifier(this ref CefExtension self) => self._GetIdentifier(self.AsPointer());

  /// <inheritdoc cref="CefExtension._GetPath"/>
  public static unsafe CefStringUserFree* GetPath(this ref CefExtension self) => self._GetPath(self.AsPointer());

  /// <inheritdoc cref="CefExtension._GetManifest"/>
  public static unsafe CefDictionaryValue* GetManifest(this ref CefExtension self) => self._GetManifest(self.AsPointer());

  /// <inheritdoc cref="CefExtension._IsSame"/>
  public static unsafe bool IsSame(this ref CefExtension self, ref CefExtension that) => self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefExtension._GetHandler"/>
  public static unsafe CefExtensionHandler* GetHandler(this ref CefExtension self) => self._GetHandler(self.AsPointer());

  /// <inheritdoc cref="CefExtension._GetLoaderContext"/>
  public static unsafe CefRequestContext* GetLoaderContext(this ref CefExtension self) => self._GetLoaderContext(self.AsPointer());

  /// <inheritdoc cref="CefExtension._IsLoaded"/>
  public static unsafe bool IsLoaded(this ref CefExtension self) => self._IsLoaded(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefExtension._Unload"/>
  public static unsafe void Unload(this ref CefExtension self) => self._Unload(self.AsPointer());

}
