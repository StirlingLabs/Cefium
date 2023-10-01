namespace Cefium;

/// <inheritdoc cref="CefClient"/>
[PublicAPI]
public static class CefClientExtensions {

  /// <inheritdoc cref="CefClient._GetAudioHandler"/>
  public static unsafe CefAudioHandler* GetAudioHandler(ref this CefClient self)
    => self._GetAudioHandler is not null ? self._GetAudioHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetCommandHandler"/>
  public static unsafe CefCommandHandler* GetCommandHandler(ref this CefClient self)
    => self._GetCommandHandler is not null ? self._GetCommandHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetContextMenuHandler"/>
  public static unsafe CefContextMenuHandler* GetContextMenuHandler(ref this CefClient self)
    => self._GetContextMenuHandler is not null ? self._GetContextMenuHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetDialogHandler"/>
  public static unsafe CefDialogHandler* GetDialogHandler(ref this CefClient self)
    => self._GetDialogHandler is not null ? self._GetDialogHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetDisplayHandler"/>
  public static unsafe CefDisplayHandler* GetDisplayHandler(ref this CefClient self)
    => self._GetDisplayHandler is not null ? self._GetDisplayHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetDownloadHandler"/>
  public static unsafe CefDownloadHandler* GetDownloadHandler(ref this CefClient self)
    => self._GetDownloadHandler is not null ? self._GetDownloadHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetDragHandler"/>
  public static unsafe CefDragHandler* GetDragHandler(ref this CefClient self)
    => self._GetDragHandler is not null ? self._GetDragHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetFindHandler"/>
  public static unsafe CefFindHandler* GetFindHandler(ref this CefClient self)
    => self._GetFindHandler is not null ? self._GetFindHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetFocusHandler"/>
  public static unsafe CefFocusHandler* GetFocusHandler(ref this CefClient self)
    => self._GetFocusHandler is not null ? self._GetFocusHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetFrameHandler"/>
  public static unsafe CefFrameHandler* GetFrameHandler(ref this CefClient self)
    => self._GetFrameHandler is not null ? self._GetFrameHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetPermissionHandler"/>
  public static unsafe CefPermissionHandler* GetPermissionHandler(ref this CefClient self)
    => self._GetPermissionHandler is not null ? self._GetPermissionHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetJsDialogHandler"/>
  public static unsafe CefJsDialogHandler* GetJsDialogHandler(ref this CefClient self)
    => self._GetJsDialogHandler is not null ? self._GetJsDialogHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetKeyboardHandler"/>
  public static unsafe CefKeyboardHandler* GetKeyboardHandler(ref this CefClient self)
    => self._GetKeyboardHandler is not null ? self._GetKeyboardHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetLifeSpanHandler"/>
  public static unsafe CefLifeSpanHandler* GetLifeSpanHandler(ref this CefClient self)
    => self._GetLifeSpanHandler is not null ? self._GetLifeSpanHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetLoadHandler"/>
  public static unsafe CefLoadHandler* GetLoadHandler(ref this CefClient self)
    => self._GetLoadHandler is not null ? self._GetLoadHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetPrintHandler"/>
  public static unsafe CefPrintHandler* GetPrintHandler(ref this CefClient self)
    => self._GetPrintHandler is not null ? self._GetPrintHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetRenderHandler"/>
  public static unsafe CefRenderHandler* GetRenderHandler(ref this CefClient self)
    => self._GetRenderHandler is not null ? self._GetRenderHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._GetRequestHandler"/>
  public static unsafe CefRequestHandler* GetRequestHandler(ref this CefClient self)
    => self._GetRequestHandler is not null ? self._GetRequestHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefClient._OnProcessMessageReceived"/>
  public static unsafe bool OnProcessMessageReceived(ref this CefClient self, ref CefBrowser browser, ref CefFrame frame, CefProcessId sourceProcess, ref CefProcessMessage message)
    => self._OnProcessMessageReceived is not null && self._OnProcessMessageReceived(self.AsPointer(), browser.AsPointer(), frame.AsPointer(), sourceProcess, message.AsPointer()) != 0;

}
