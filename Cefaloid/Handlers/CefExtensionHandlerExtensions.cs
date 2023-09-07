namespace Cefaloid;

/// <inheritdoc cref="CefExtensionHandler" />
[PublicAPI]
public static class CefExtensionHandlerExtensions {

  /// <inheritdoc cref="CefExtensionHandler._OnExtensionLoadFailed"/>
  public static unsafe void OnExtensionLoadFailed(ref this CefExtensionHandler self, CefErrorCode result)
    => self._OnExtensionLoadFailed(self.AsPointer(), result);

  /// <inheritdoc cref="CefExtensionHandler._OnExtensionLoaded"/>
  public static unsafe void OnExtensionLoaded(ref this CefExtensionHandler self, ref CefExtension extension)
    => self._OnExtensionLoaded(self.AsPointer(), extension.AsPointer());

  /// <inheritdoc cref="CefExtensionHandler._OnExtensionUnloaded"/>
  public static unsafe void OnExtensionUnloaded(ref this CefExtensionHandler self, ref CefExtension extension)
    => self._OnExtensionUnloaded(self.AsPointer(), extension.AsPointer());

  /// <inheritdoc cref="CefExtensionHandler._OnBeforeBackgroundBrowser"/>
  public static unsafe bool OnBeforeBackgroundBrowser(ref this CefExtensionHandler self, ref CefExtension extension, ref CefString url, ref CefClient* client, ref CefBrowserSettings settings)
    => self._OnBeforeBackgroundBrowser(self.AsPointer(), extension.AsPointer(), url.AsPointer(), AsPointer(ref client), settings.AsPointer()) != 0;

  /// <inheritdoc cref="CefExtensionHandler._OnBeforeBrowser"/>
  public static unsafe bool OnBeforeBrowser(ref this CefExtensionHandler self, ref CefExtension extension, ref CefBrowser browser, ref CefBrowser activeBrowser, int index, ref CefString url, int active, ref CefWindowInfo windowInfo,
    ref CefClient* client, ref CefBrowserSettings settings)
    => self._OnBeforeBrowser(self.AsPointer(), extension.AsPointer(), browser.AsPointer(), activeBrowser.AsPointer(), index, url.AsPointer(), active, windowInfo.AsPointer(), AsPointer(ref client), settings.AsPointer()) != 0;

  /// <inheritdoc cref="CefExtensionHandler._GetActiveBrowser"/>
  public static unsafe CefBrowser* GetActiveBrowser(ref this CefExtensionHandler self, ref CefExtension extension, ref CefBrowser browser, int includeIncognito)
    => self._GetActiveBrowser(self.AsPointer(), extension.AsPointer(), browser.AsPointer(), includeIncognito);

  /// <inheritdoc cref="CefExtensionHandler._CanAccessBrowser"/>
  public static unsafe bool CanAccessBrowser(ref this CefExtensionHandler self, ref CefExtension extension, ref CefBrowser browser, int includeIncognito, ref CefBrowser targetBrowser)
    => self._CanAccessBrowser(self.AsPointer(), extension.AsPointer(), browser.AsPointer(), includeIncognito, targetBrowser.AsPointer()) != 0;

  /// <inheritdoc cref="CefExtensionHandler._GetExtensionResource"/>
  public static unsafe bool GetExtensionResource(ref this CefExtensionHandler self, ref CefExtension extension, ref CefBrowser browser, ref CefString file, ref CefGetExtensionResourceCallback callback)
    => self._GetExtensionResource(self.AsPointer(), extension.AsPointer(), browser.AsPointer(), file.AsPointer(), callback.AsPointer()) != 0;

}
