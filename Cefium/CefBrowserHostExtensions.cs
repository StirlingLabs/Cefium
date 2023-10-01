namespace Cefium;

/// <inheritdoc cref="CefBrowserHost"/>
[PublicAPI]
public static partial class CefBrowserHostExtensions {

  /// <inheritdoc cref="CefBrowserHost._GetBrowser"/>
  public static unsafe CefBrowser* GetBrowser(ref this CefBrowserHost self)
    => self._GetBrowser is not null ? self._GetBrowser(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._CloseBrowser"/>
  public static unsafe bool CloseBrowser(ref this CefBrowserHost self, bool forceClose) {
    if (self._CloseBrowser is null) return false;

    self._CloseBrowser(self.AsPointer(), forceClose ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._TryCloseBrowser"/>
  public static unsafe bool TryCloseBrowser(ref this CefBrowserHost self)
    => self._TryCloseBrowser is not null && self._TryCloseBrowser(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._SetFocus"/>
  public static unsafe bool SetFocus(ref this CefBrowserHost self, bool enable) {
    if (self._SetFocus is null) return false;

    self._SetFocus(self.AsPointer(), enable ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._GetWindowHandle"/>
  public static unsafe nint GetWindowHandle(ref this CefBrowserHost self)
    => self._GetWindowHandle is not null ? self._GetWindowHandle(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._GetOpenerWindowHandle"/>
  public static unsafe nint GetOpenerWindowHandle(ref this CefBrowserHost self)
    => self._GetOpenerWindowHandle is not null ? self._GetOpenerWindowHandle(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._HasView"/>
  public static unsafe bool HasView(ref this CefBrowserHost self)
    => self._HasView is not null && self._HasView(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._GetClient"/>
  public static unsafe CefClient* GetClient(ref this CefBrowserHost self)
    => self._GetClient is not null ? self._GetClient(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._GetRequestContext"/>
  public static unsafe CefRequestContext* GetRequestContext(ref this CefBrowserHost self)
    => self._GetRequestContext is not null ? self._GetRequestContext(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._GetZoomLevel"/>
  public static unsafe double GetZoomLevel(ref this CefBrowserHost self)
    => self._GetZoomLevel is not null ? self._GetZoomLevel(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._SetZoomLevel"/>
  public static unsafe bool SetZoomLevel(ref this CefBrowserHost self, double zoomLevel) {
    if (self._SetZoomLevel is null) return false;

    self._SetZoomLevel(self.AsPointer(), zoomLevel);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._RunFileDialog"/>
  public static unsafe bool RunFileDialog(ref this CefBrowserHost self, CefFileDialogMode mode, ref CefString title, ref CefString defaultFileName, ref CefStringList acceptTypes, ref CefRunFileDialogCallback callback) {
    if (self._RunFileDialog is null) return false;

    self._RunFileDialog(self.AsPointer(), mode, title.AsPointer(), defaultFileName.AsPointer(), acceptTypes.AsPointer(), callback.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._StartDownload"/>
  public static unsafe bool StartDownload(ref this CefBrowserHost self, ref CefString url) {
    if (self._StartDownload is null) return false;

    self._StartDownload(self.AsPointer(), url.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._DownloadImage"/>
  public static unsafe bool DownloadImage(ref this CefBrowserHost self, ref CefString imageUrl, bool isFavicon, uint maxImageSize, bool bypassCache, ref CefDownloadImageCallback callback) {
    if (self._DownloadImage is null) return false;

    self._DownloadImage(self.AsPointer(), imageUrl.AsPointer(), isFavicon ? 1 : 0, maxImageSize, bypassCache ? 1 : 0, callback.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._Print"/>
  public static unsafe bool Print(ref this CefBrowserHost self) {
    if (self._Print is null) return false;

    self._Print(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._PrintToPdf"/>
  public static unsafe bool PrintToPdf(ref this CefBrowserHost self, ref CefString path, ref CefPdfPrintSettings settings, ref CefPdfPrintCallback callback) {
    if (self._PrintToPdf is null) return false;

    self._PrintToPdf(self.AsPointer(), path.AsPointer(), settings.AsPointer(), callback.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._Find"/>
  public static unsafe bool Find(ref this CefBrowserHost self, ref CefString searchText, bool forward, bool matchCase, bool findNext) {
    if (self._Find is null) return false;

    self._Find(self.AsPointer(), searchText.AsPointer(), forward ? 1 : 0, matchCase ? 1 : 0, findNext ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._StopFinding"/>
  public static unsafe bool StopFinding(ref this CefBrowserHost self, bool clearSelection) {
    if (self._StopFinding is null) return false;

    self._StopFinding(self.AsPointer(), clearSelection ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._ShowDevTools"/>
  public static unsafe bool ShowDevTools(ref this CefBrowserHost self, ref CefWindowInfo cefWindowInfo, ref CefClient client, ref CefBrowserSettings settings, ref CefPoint inspectElementAt) {
    if (self._ShowDevTools is null) return false;

    self._ShowDevTools(self.AsPointer(), cefWindowInfo.AsPointer(), client.AsPointer(), settings.AsPointer(), inspectElementAt.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._CloseDevTools"/>
  public static unsafe bool CloseDevTools(ref this CefBrowserHost self) {
    if (self._CloseDevTools is null) return false;

    self._CloseDevTools(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._HasDevTools"/>
  public static unsafe bool HasDevTools(ref this CefBrowserHost self)
    => self._HasDevTools is not null && self._HasDevTools(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._SendDevToolsMessage"/>
  public static unsafe bool SendDevToolsMessage(ref this CefBrowserHost self, void* message, nuint messageSize) {
    if (self._SendDevToolsMessage is null) return false;

    self._SendDevToolsMessage(self.AsPointer(), message, messageSize);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SendDevToolsMessage"/>
  public static unsafe bool SendDevToolsMessage(ref this CefBrowserHost self, ReadOnlySpan<byte> message) {
    fixed (byte* pMessage = message)
      return SendDevToolsMessage(ref self, pMessage, (nuint) message.Length);
  }

  /// <inheritdoc cref="CefBrowserHost._SendDevToolsMessage"/>
  public static void SendDevToolsMessage<T>(ref this CefBrowserHost self, ReadOnlySpan<T> message) where T : struct
    => SendDevToolsMessage(ref self, MemoryMarshal.AsBytes(message));

  /// <inheritdoc cref="CefBrowserHost._ExecuteDevToolsMethod"/>
  public static unsafe bool ExecuteDevToolsMethod(ref this CefBrowserHost self, int messageId, ref CefString method, ref CefDictionaryValue @params) {
    if (self._ExecuteDevToolsMethod is null) return false;

    self._ExecuteDevToolsMethod(self.AsPointer(), messageId, method.AsPointer(), @params.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._AddDevToolsMessageObserver"/>
  public static unsafe bool AddDevToolsMessageObserver(ref this CefBrowserHost self, ref CefDevToolsMessageObserver observer) {
    if (self._AddDevToolsMessageObserver is null) return false;

    self._AddDevToolsMessageObserver(self.AsPointer(), observer.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._GetNavigationEntries"/>
  public static unsafe bool GetNavigationEntries(ref this CefBrowserHost self, ref CefNavigationEntryVisitor visitor, bool currentOnly) {
    if (self._GetNavigationEntries is null) return false;

    self._GetNavigationEntries(self.AsPointer(), visitor.AsPointer(), currentOnly ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._ReplaceMisspelling"/>
  public static unsafe bool ReplaceMisspelling(ref this CefBrowserHost self, ref CefString word) {
    if (self._ReplaceMisspelling is null) return false;

    self._ReplaceMisspelling(self.AsPointer(), word.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._AddWordToDictionary"/>
  public static unsafe bool AddWordToDictionary(ref this CefBrowserHost self, ref CefString word) {
    if (self._AddWordToDictionary is null) return false;

    self._AddWordToDictionary(self.AsPointer(), word.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._IsWindowRenderingDisabled"/>
  public static unsafe bool IsWindowRenderingDisabled(ref this CefBrowserHost self)
    => self._IsWindowRenderingDisabled is not null && self._IsWindowRenderingDisabled(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._WasResized"/>
  public static unsafe bool WasResized(ref this CefBrowserHost self) {
    if (self._WasResized is null) return false;

    self._WasResized(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._WasHidden"/>
  public static unsafe bool WasHidden(ref this CefBrowserHost self, bool hidden) {
    if (self._WasHidden is null) return false;

    self._WasHidden(self.AsPointer(), hidden ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._NotifyScreenInfoChanged"/>
  public static unsafe bool NotifyScreenInfoChanged(ref this CefBrowserHost self) {
    if (self._NotifyScreenInfoChanged is null) return false;

    self._NotifyScreenInfoChanged(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._Invalidate"/>
  public static unsafe bool Invalidate(ref this CefBrowserHost self, CefPaintElementType type) {
    if (self._Invalidate is null) return false;

    self._Invalidate(self.AsPointer(), type);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SendExternalBeginFrame"/>
  public static unsafe bool SendExternalBeginFrame(ref this CefBrowserHost self) {
    if (self._SendExternalBeginFrame is null) return false;

    self._SendExternalBeginFrame(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SendKeyEvent"/>
  public static unsafe bool SendKeyEvent(ref this CefBrowserHost self, ref CefKeyEvent @event) {
    if (self._SendKeyEvent is null) return false;

    self._SendKeyEvent(self.AsPointer(), @event.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SendMouseClickEvent"/>
  public static unsafe bool SendMouseClickEvent(ref this CefBrowserHost self, ref CefMouseEvent @event, CefMouseButton type, bool mouseUp, int clickCount) {
    if (self._SendMouseClickEvent is null) return false;

    self._SendMouseClickEvent(self.AsPointer(), @event.AsPointer(), type, mouseUp ? 1 : 0, clickCount);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SendMouseMoveEvent"/>
  public static unsafe bool SendMouseMoveEvent(ref this CefBrowserHost self, ref CefMouseEvent @event, bool mouseLeave) {
    if (self._SendMouseMoveEvent is null) return false;

    self._SendMouseMoveEvent(self.AsPointer(), @event.AsPointer(), mouseLeave ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SendMouseWheelEvent"/>
  public static unsafe bool SendMouseWheelEvent(ref this CefBrowserHost self, ref CefMouseEvent @event, int deltaX, int deltaY) {
    if (self._SendMouseWheelEvent is null) return false;

    self._SendMouseWheelEvent(self.AsPointer(), @event.AsPointer(), deltaX, deltaY);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SendTouchEvent"/>
  public static unsafe bool SendTouchEvent(ref this CefBrowserHost self, ref CefTouchEvent @event) {
    if (self._SendTouchEvent is null) return false;

    self._SendTouchEvent(self.AsPointer(), @event.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SendCaptureLostEvent"/>
  public static unsafe bool SendCaptureLostEvent(ref this CefBrowserHost self) {
    if (self._SendCaptureLostEvent is null) return false;

    self._SendCaptureLostEvent(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._NotifyMoveOrResizeStarted"/>
  public static unsafe bool NotifyMoveOrResizeStarted(ref this CefBrowserHost self) {
    if (self._NotifyMoveOrResizeStarted is null) return false;

    self._NotifyMoveOrResizeStarted(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._GetWindowlessFrameRate"/>
  public static unsafe int GetWindowlessFrameRate(ref this CefBrowserHost self)
    => self._GetWindowlessFrameRate is not null ? self._GetWindowlessFrameRate(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._SetWindowlessFrameRate"/>
  public static unsafe bool SetWindowlessFrameRate(ref this CefBrowserHost self, int frameRate) {
    if (self._SetWindowlessFrameRate is null) return false;

    self._SetWindowlessFrameRate(self.AsPointer(), frameRate);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._ImeSetComposition"/>
  public static unsafe bool ImeSetComposition(ref this CefBrowserHost self, ref CefString text, nuint underlinesCount, ref CefCompositionUnderline underlines, ref CefRange replacementRange, ref CefRange selectionRange) {
    if (self._ImeSetComposition is null) return false;

    self._ImeSetComposition(self.AsPointer(), text.AsPointer(), underlinesCount, underlines.AsPointer(), replacementRange.AsPointer(), selectionRange.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._ImeCommitText"/>
  public static unsafe bool ImeCommitText(ref this CefBrowserHost self, ref CefString text, ref CefRange replacementRange, int relativeCursorPos) {
    if (self._ImeCommitText is null) return false;

    self._ImeCommitText(self.AsPointer(), text.AsPointer(), replacementRange.AsPointer(), relativeCursorPos);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._ImeFinishComposingText"/>
  public static unsafe bool ImeFinishComposingText(ref this CefBrowserHost self, bool keepSelection) {
    if (self._ImeFinishComposingText is null) return false;

    self._ImeFinishComposingText(self.AsPointer(), keepSelection ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._ImeCancelComposition"/>
  public static unsafe bool ImeCancelComposition(ref this CefBrowserHost self) {
    if (self._ImeCancelComposition is null) return false;

    self._ImeCancelComposition(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._DragTargetDragEnter"/>
  public static unsafe bool DragTargetDragEnter(ref this CefBrowserHost self, ref CefDragData dragData, ref CefMouseEvent @event, CefDragOperationsMask allowedOps) {
    if (self._DragTargetDragEnter is null) return false;

    self._DragTargetDragEnter(self.AsPointer(), dragData.AsPointer(), @event.AsPointer(), allowedOps);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._DragTargetDragOver"/>
  public static unsafe bool DragTargetDragOver(ref this CefBrowserHost self, ref CefMouseEvent @event, CefDragOperationsMask allowedOps) {
    if (self._DragTargetDragOver is null) return false;

    self._DragTargetDragOver(self.AsPointer(), @event.AsPointer(), allowedOps);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._DragTargetDragLeave"/>
  public static unsafe bool DragTargetDragLeave(ref this CefBrowserHost self) {
    if (self._DragTargetDragLeave is null) return false;

    self._DragTargetDragLeave(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._DragTargetDrop"/>
  public static unsafe bool DragTargetDrop(ref this CefBrowserHost self, ref CefMouseEvent @event) {
    if (self._DragTargetDrop is null) return false;

    self._DragTargetDrop(self.AsPointer(), @event.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._DragSourceEndedAt"/>
  public static unsafe bool DragSourceEndedAt(ref this CefBrowserHost self, int x, int y, CefDragOperationsMask op) {
    if (self._DragSourceEndedAt is null) return false;

    self._DragSourceEndedAt(self.AsPointer(), x, y, op);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._DragSourceSystemDragEnded"/>
  public static unsafe bool DragSourceSystemDragEnded(ref this CefBrowserHost self) {
    if (self._DragSourceSystemDragEnded is null) return false;

    self._DragSourceSystemDragEnded(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._GetVisibleNavigationEntry"/>
  public static unsafe CefNavigationEntry* GetVisibleNavigationEntry(ref this CefBrowserHost self)
    => self._GetVisibleNavigationEntry is not null ? self._GetVisibleNavigationEntry(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._SetAccessibilityState"/>
  public static unsafe bool SetAccessibilityState(ref this CefBrowserHost self, CefState state) {
    if (self._SetAccessibilityState is null) return false;

    self._SetAccessibilityState(self.AsPointer(), state);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._SetAutoResizeEnabled"/>
  public static unsafe bool SetAutoResizeEnabled(ref this CefBrowserHost self, bool enabled, CefSize minSize, CefSize maxSize) {
    if (self._SetAutoResizeEnabled is null) return false;

    self._SetAutoResizeEnabled(self.AsPointer(), enabled ? 1 : 0, minSize.AsPointer(), maxSize.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._GetExtension"/>
  public static unsafe CefExtension* GetExtension(ref this CefBrowserHost self)
    => self._GetExtension is not null ? self._GetExtension(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowserHost._IsBackgroundHost"/>
  public static unsafe bool IsBackgroundHost(ref this CefBrowserHost self)
    => self._IsBackgroundHost is not null && self._IsBackgroundHost(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._SetAudioMuted"/>
  public static unsafe bool SetAudioMuted(ref this CefBrowserHost self, int mute) {
    if (self._SetAudioMuted is null) return false;

    self._SetAudioMuted(self.AsPointer(), mute);
    return true;
  }

  /// <inheritdoc cref="CefBrowserHost._IsAudioMuted"/>
  public static unsafe bool IsAudioMuted(ref this CefBrowserHost self)
    => self._IsAudioMuted is not null && self._IsAudioMuted(self.AsPointer()) != 0;

}
