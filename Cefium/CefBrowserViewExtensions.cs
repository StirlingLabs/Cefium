namespace Cefium;

[PublicAPI]
public static class CefBrowserViewExtensions {

  /// <inheritdoc cref="CefBrowserView._Create"/>
  public static unsafe CefBrowser* GetBrowser(ref this CefBrowserView self)
    => self._GetBrowser is not null ? self._GetBrowser(self.AsPointer()) : null;

  /// <inheritdoc cref="CefBrowserView._GetChromeToolbar"/>
  public static unsafe CefView* GetChromeToolbar(ref this CefBrowserView self)
    => self._GetChromeToolbar is not null ? self._GetChromeToolbar(self.AsPointer()) : null;

  /// <inheritdoc cref="CefBrowserView._SetPreferAccelerators"/>
  public static unsafe bool SetPreferAccelerators(ref this CefBrowserView self, int preferAccelerators) {
    if (self._SetPreferAccelerators is null)
      return false;

    self._SetPreferAccelerators(self.AsPointer(), preferAccelerators);
    return true;
  }

}
