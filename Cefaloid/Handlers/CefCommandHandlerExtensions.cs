namespace Cefaloid;

/// <inheritdoc cref="CefCommandHandler"/>
[PublicAPI]
public static class CefCommandHandlerExtensions {

  /// <inheritdoc cref="CefCommandHandler._OnChromeCommand"/>
  public static unsafe bool OnChromeCommand(ref this CefCommandHandler self, ref CefBrowser browser, int commandId, CefWindowOpenDisposition disposition)
    => self._OnChromeCommand(self.AsPointer(), browser.AsPointer(), commandId, disposition) != 0;

}
