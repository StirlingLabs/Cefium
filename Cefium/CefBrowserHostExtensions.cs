namespace Cefium;

/// <inheritdoc cref="CefBrowserHost"/>
[PublicAPI]
public static partial class CefBrowserHostExtensions {

  /// <inheritdoc cref="CefBrowserHost._GetBrowser"/>
  public static unsafe CefBrowser* GetBrowser(ref this CefBrowserHost self) => self._GetBrowser(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._CloseBrowser"/>
  public static unsafe void CloseBrowser(ref this CefBrowserHost self, bool forceClose) => self._CloseBrowser(self.AsPointer(), forceClose ? 1 : 0);

  /// <inheritdoc cref="CefBrowserHost._TryCloseBrowser"/>
  public static unsafe bool TryCloseBrowser(ref this CefBrowserHost self) => self._TryCloseBrowser(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._SetFocus"/>
  public static unsafe void SetFocus(ref this CefBrowserHost self, bool enable) => self._SetFocus(self.AsPointer(), enable ? 1 : 0);

  /// <inheritdoc cref="CefBrowserHost._GetWindowHandle"/>
  public static unsafe nint GetWindowHandle(ref this CefBrowserHost self) => self._GetWindowHandle(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._GetOpenerWindowHandle"/>
  public static unsafe nint GetOpenerWindowHandle(ref this CefBrowserHost self) => self._GetOpenerWindowHandle(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._HasView"/>
  public static unsafe bool HasView(ref this CefBrowserHost self) => self._HasView(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._GetClient"/>
  public static unsafe CefClient* GetClient(ref this CefBrowserHost self) => self._GetClient(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._GetRequestContext"/>
  public static unsafe CefRequestContext* GetRequestContext(ref this CefBrowserHost self) => self._GetRequestContext(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._GetZoomLevel"/>
  public static unsafe double GetZoomLevel(ref this CefBrowserHost self) => self._GetZoomLevel(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._SetZoomLevel"/>
  public static unsafe void SetZoomLevel(ref this CefBrowserHost self, double zoomLevel) => self._SetZoomLevel(self.AsPointer(), zoomLevel);

  /// <inheritdoc cref="CefBrowserHost._RunFileDialog"/>
  public static unsafe void RunFileDialog(ref this CefBrowserHost self, CefFileDialogMode mode, ref CefString title, ref CefString defaultFileName, ref CefStringList acceptTypes, ref CefRunFileDialogCallback callback)
    => self._RunFileDialog(self.AsPointer(), mode, title.AsPointer(), defaultFileName.AsPointer(), acceptTypes.AsPointer(), callback.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._StartDownload"/>
  public static unsafe void StartDownload(ref this CefBrowserHost self, ref CefString url) => self._StartDownload(self.AsPointer(), url.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._DownloadImage"/>
  public static unsafe void DownloadImage(ref this CefBrowserHost self, ref CefString imageUrl, bool isFavicon, uint maxImageSize, bool bypassCache, ref CefDownloadImageCallback callback)
    => self._DownloadImage(self.AsPointer(), imageUrl.AsPointer(), isFavicon ? 1 : 0, maxImageSize, bypassCache ? 1 : 0, callback.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._Print"/>
  public static unsafe void Print(ref this CefBrowserHost self) => self._Print(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._PrintToPdf"/>
  public static unsafe void PrintToPdf(ref this CefBrowserHost self, ref CefString path, ref CefPdfPrintSettings settings, ref CefPdfPrintCallback callback)
    => self._PrintToPdf(self.AsPointer(), path.AsPointer(), settings.AsPointer(), callback.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._Find"/>
  public static unsafe void Find(ref this CefBrowserHost self, ref CefString searchText, bool forward, bool matchCase, bool findNext)
    => self._Find(self.AsPointer(), searchText.AsPointer(), forward ? 1 : 0, matchCase ? 1 : 0, findNext ? 1 : 0);

  /// <inheritdoc cref="CefBrowserHost._StopFinding"/>
  public static unsafe void StopFinding(ref this CefBrowserHost self, bool clearSelection) => self._StopFinding(self.AsPointer(), clearSelection ? 1 : 0);

  /// <inheritdoc cref="CefBrowserHost._ShowDevTools"/>
  public static unsafe void ShowDevTools(ref this CefBrowserHost self, ref CefWindowInfo cefWindowInfo, ref CefClient client, ref CefBrowserSettings settings, ref CefPoint inspectElementAt)
    => self._ShowDevTools(self.AsPointer(), cefWindowInfo.AsPointer(), client.AsPointer(), settings.AsPointer(), inspectElementAt.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._CloseDevTools"/>
  public static unsafe void CloseDevTools(ref this CefBrowserHost self) => self._CloseDevTools(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._HasDevTools"/>
  public static unsafe bool HasDevTools(ref this CefBrowserHost self) => self._HasDevTools(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._SendDevToolsMessage"/>
  public static unsafe void SendDevToolsMessage(ref this CefBrowserHost self, void* message, nuint messageSize)
    => self._SendDevToolsMessage(self.AsPointer(), message, messageSize);

  /// <inheritdoc cref="CefBrowserHost._SendDevToolsMessage"/>
  public static unsafe void SendDevToolsMessage(ref this CefBrowserHost self, ReadOnlySpan<byte> message) {
    fixed (byte* pMessage = message)
      SendDevToolsMessage(ref self, pMessage, (nuint) message.Length);
  }

  /// <inheritdoc cref="CefBrowserHost._SendDevToolsMessage"/>
  public static void SendDevToolsMessage<T>(ref this CefBrowserHost self, ReadOnlySpan<T> message) where T : struct
    => SendDevToolsMessage(ref self, MemoryMarshal.AsBytes(message));

  /// <inheritdoc cref="CefBrowserHost._ExecuteDevToolsMethod"/>
  public static unsafe void ExecuteDevToolsMethod(ref this CefBrowserHost self, int messageId, ref CefString method, ref CefDictionaryValue @params)
    => self._ExecuteDevToolsMethod(self.AsPointer(), messageId, method.AsPointer(), @params.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._AddDevToolsMessageObserver"/>
  public static unsafe void AddDevToolsMessageObserver(ref this CefBrowserHost self, ref CefDevToolsMessageObserver observer)
    => self._AddDevToolsMessageObserver(self.AsPointer(), observer.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._GetNavigationEntries"/>
  public static unsafe void GetNavigationEntries(ref this CefBrowserHost self, ref CefNavigationEntryVisitor visitor, bool currentOnly)
    => self._GetNavigationEntries(self.AsPointer(), visitor.AsPointer(), currentOnly ? 1 : 0);

  /// <inheritdoc cref="CefBrowserHost._ReplaceMisspelling"/>
  public static unsafe void ReplaceMisspelling(ref this CefBrowserHost self, ref CefString word) => self._ReplaceMisspelling(self.AsPointer(), word.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._AddWordToDictionary"/>
  public static unsafe void AddWordToDictionary(ref this CefBrowserHost self, ref CefString word) => self._AddWordToDictionary(self.AsPointer(), word.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._IsWindowRenderingDisabled"/>
  public static unsafe bool IsWindowRenderingDisabled(ref this CefBrowserHost self) => self._IsWindowRenderingDisabled(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._WasResized"/>
  public static unsafe void WasResized(ref this CefBrowserHost self) => self._WasResized(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._WasHidden"/>
  public static unsafe void WasHidden(ref this CefBrowserHost self, bool hidden) => self._WasHidden(self.AsPointer(), hidden ? 1 : 0);

  /// <inheritdoc cref="CefBrowserHost._NotifyScreenInfoChanged"/>
  public static unsafe void NotifyScreenInfoChanged(ref this CefBrowserHost self) => self._NotifyScreenInfoChanged(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._Invalidate"/>
  public static unsafe void Invalidate(ref this CefBrowserHost self, CefPaintElementType type) => self._Invalidate(self.AsPointer(), type);

  /// <inheritdoc cref="CefBrowserHost._SendExternalBeginFrame"/>
  public static unsafe void SendExternalBeginFrame(ref this CefBrowserHost self)
    => self._SendExternalBeginFrame(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._SendKeyEvent"/>
  public static unsafe void SendKeyEvent(ref this CefBrowserHost self, ref CefKeyEvent @event) => self._SendKeyEvent(self.AsPointer(), @event.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._SendMouseClickEvent"/>
  public static unsafe void SendMouseClickEvent(ref this CefBrowserHost self, ref CefMouseEvent @event, CefMouseButton type, bool mouseUp, int clickCount)
    => self._SendMouseClickEvent(self.AsPointer(), @event.AsPointer(), type, mouseUp ? 1 : 0, clickCount);

  /// <inheritdoc cref="CefBrowserHost._SendMouseMoveEvent"/>
  public static unsafe void SendMouseMoveEvent(ref this CefBrowserHost self, ref CefMouseEvent @event, bool mouseLeave)
    => self._SendMouseMoveEvent(self.AsPointer(), @event.AsPointer(), mouseLeave ? 1 : 0);

  /// <inheritdoc cref="CefBrowserHost._SendMouseWheelEvent"/>
  public static unsafe void SendMouseWheelEvent(ref this CefBrowserHost self, ref CefMouseEvent @event, int deltaX, int deltaY)
    => self._SendMouseWheelEvent(self.AsPointer(), @event.AsPointer(), deltaX, deltaY);

  /// <inheritdoc cref="CefBrowserHost._SendTouchEvent"/>
  public static unsafe void SendTouchEvent(ref this CefBrowserHost self, ref CefTouchEvent @event) => self._SendTouchEvent(self.AsPointer(), @event.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._SendCaptureLostEvent"/>
  public static unsafe void SendCaptureLostEvent(ref this CefBrowserHost self) => self._SendCaptureLostEvent(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._NotifyMoveOrResizeStarted"/>
  public static unsafe void NotifyMoveOrResizeStarted(ref this CefBrowserHost self) => self._NotifyMoveOrResizeStarted(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._GetWindowlessFrameRate"/>
  public static unsafe int GetWindowlessFrameRate(ref this CefBrowserHost self) => self._GetWindowlessFrameRate(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._SetWindowlessFrameRate"/>
  public static unsafe void SetWindowlessFrameRate(ref this CefBrowserHost self, int frameRate) => self._SetWindowlessFrameRate(self.AsPointer(), frameRate);

  /// <inheritdoc cref="CefBrowserHost._ImeSetComposition"/>
  public static unsafe void ImeSetComposition(ref this CefBrowserHost self, ref CefString text, nuint underlinesCount, ref CefCompositionUnderline underlines, ref CefRange replacementRange, ref CefRange selectionRange)
    => self._ImeSetComposition(self.AsPointer(), text.AsPointer(), underlinesCount, underlines.AsPointer(), replacementRange.AsPointer(), selectionRange.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._ImeCommitText"/>
  public static unsafe void ImeCommitText(ref this CefBrowserHost self, ref CefString text, ref CefRange replacementRange, int relativeCursorPos)
    => self._ImeCommitText(self.AsPointer(), text.AsPointer(), replacementRange.AsPointer(), relativeCursorPos);

  /// <inheritdoc cref="CefBrowserHost._ImeFinishComposingText"/>
  public static unsafe void ImeFinishComposingText(ref this CefBrowserHost self, bool keepSelection) => self._ImeFinishComposingText(self.AsPointer(), keepSelection ? 1 : 0);

  /// <inheritdoc cref="CefBrowserHost._ImeCancelComposition"/>
  public static unsafe void ImeCancelComposition(ref this CefBrowserHost self) => self._ImeCancelComposition(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._DragTargetDragEnter"/>
  public static unsafe void DragTargetDragEnter(ref this CefBrowserHost self, ref CefDragData dragData, ref CefMouseEvent @event, CefDragOperationsMask allowedOps)
    => self._DragTargetDragEnter(self.AsPointer(), dragData.AsPointer(), @event.AsPointer(), allowedOps);

  /// <inheritdoc cref="CefBrowserHost._DragTargetDragOver"/>
  public static unsafe void DragTargetDragOver(ref this CefBrowserHost self, ref CefMouseEvent @event, CefDragOperationsMask allowedOps)
    => self._DragTargetDragOver(self.AsPointer(), @event.AsPointer(), allowedOps);

  /// <inheritdoc cref="CefBrowserHost._DragTargetDragLeave"/>
  public static unsafe void DragTargetDragLeave(ref this CefBrowserHost self) => self._DragTargetDragLeave(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._DragTargetDrop"/>
  public static unsafe void DragTargetDrop(ref this CefBrowserHost self, ref CefMouseEvent @event) => self._DragTargetDrop(self.AsPointer(), @event.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._DragSourceEndedAt"/>
  public static unsafe void DragSourceEndedAt(ref this CefBrowserHost self, int x, int y, CefDragOperationsMask op)
    => self._DragSourceEndedAt(self.AsPointer(), x, y, op);

  /// <inheritdoc cref="CefBrowserHost._DragSourceSystemDragEnded"/>
  public static unsafe void DragSourceSystemDragEnded(ref this CefBrowserHost self) => self._DragSourceSystemDragEnded(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._GetVisibleNavigationEntry"/>
  public static unsafe CefNavigationEntry* GetVisibleNavigationEntry(ref this CefBrowserHost self) => self._GetVisibleNavigationEntry(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._SetAccessibilityState"/>
  public static unsafe void SetAccessibilityState(ref this CefBrowserHost self, CefState state) => self._SetAccessibilityState(self.AsPointer(), state);

  /// <inheritdoc cref="CefBrowserHost._SetAutoResizeEnabled"/>
  public static unsafe void SetAutoResizeEnabled(ref this CefBrowserHost self, bool enabled, CefSize minSize, CefSize maxSize)
    => self._SetAutoResizeEnabled(self.AsPointer(), enabled ? 1 : 0, minSize.AsPointer(), maxSize.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._GetExtension"/>
  public static unsafe CefExtension* GetExtension(ref this CefBrowserHost self) => self._GetExtension(self.AsPointer());

  /// <inheritdoc cref="CefBrowserHost._IsBackgroundHost"/>
  public static unsafe bool IsBackgroundHost(ref this CefBrowserHost self) => self._IsBackgroundHost(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowserHost._SetAudioMuted"/>
  public static unsafe void SetAudioMuted(ref this CefBrowserHost self, int mute) => self._SetAudioMuted(self.AsPointer(), mute);

  /// <inheritdoc cref="CefBrowserHost._IsAudioMuted"/>
  public static unsafe bool IsAudioMuted(ref this CefBrowserHost self) => self._IsAudioMuted(self.AsPointer()) != 0;

}
