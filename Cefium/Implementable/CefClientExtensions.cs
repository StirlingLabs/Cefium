namespace Cefium;

/// <inheritdoc cref="CefClient"/>
[PublicAPI]
public static class CefClientExtensions {

  /// <inheritdoc cref="CefClient._GetAudioHandler"/>
  public static unsafe CefAudioHandler* GetAudioHandler(ref this CefClient self) => self._GetAudioHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetCommandHandler"/>
  public static unsafe CefCommandHandler* GetCommandHandler(ref this CefClient self) => self._GetCommandHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetContextMenuHandler"/>
  public static unsafe CefContextMenuHandler* GetContextMenuHandler(ref this CefClient self) => self._GetContextMenuHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetDialogHandler"/>
  public static unsafe CefDialogHandler* GetDialogHandler(ref this CefClient self) => self._GetDialogHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetDisplayHandler"/>
  public static unsafe CefDisplayHandler* GetDisplayHandler(ref this CefClient self) => self._GetDisplayHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetDownloadHandler"/>
  public static unsafe CefDownloadHandler* GetDownloadHandler(ref this CefClient self) => self._GetDownloadHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetDragHandler"/>
  public static unsafe CefDragHandler* GetDragHandler(ref this CefClient self) => self._GetDragHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetFindHandler"/>
  public static unsafe CefFindHandler* GetFindHandler(ref this CefClient self) => self._GetFindHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetFocusHandler"/>
  public static unsafe CefFocusHandler* GetFocusHandler(ref this CefClient self) => self._GetFocusHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetFrameHandler"/>
  public static unsafe CefFrameHandler* GetFrameHandler(ref this CefClient self) => self._GetFrameHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetPermissionHandler"/>
  public static unsafe CefPermissionHandler* GetPermissionHandler(ref this CefClient self) => self._GetPermissionHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetJsDialogHandler"/>
  public static unsafe CefJsDialogHandler* GetJsDialogHandler(ref this CefClient self) => self._GetJsDialogHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetKeyboardHandler"/>
  public static unsafe CefKeyboardHandler* GetKeyboardHandler(ref this CefClient self) => self._GetKeyboardHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetLifeSpanHandler"/>
  public static unsafe CefLifeSpanHandler* GetLifeSpanHandler(ref this CefClient self) => self._GetLifeSpanHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetLoadHandler"/>
  public static unsafe CefLoadHandler* GetLoadHandler(ref this CefClient self) => self._GetLoadHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetPrintHandler"/>
  public static unsafe CefPrintHandler* GetPrintHandler(ref this CefClient self) => self._GetPrintHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetRenderHandler"/>
  public static unsafe CefRenderHandler* GetRenderHandler(ref this CefClient self) => self._GetRenderHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._GetRequestHandler"/>
  public static unsafe CefRequestHandler* GetRequestHandler(ref this CefClient self) => self._GetRequestHandler(self.AsPointer());

  /// <inheritdoc cref="CefClient._OnProcessMessageReceived"/>
  public static unsafe bool OnProcessMessageReceived(ref this CefClient self, ref CefBrowser browser, ref CefFrame frame, CefProcessId sourceProcess, ref CefProcessMessage message)
    => self._OnProcessMessageReceived(self.AsPointer(), browser.AsPointer(), frame.AsPointer(), sourceProcess, message.AsPointer()) != 0;

}
