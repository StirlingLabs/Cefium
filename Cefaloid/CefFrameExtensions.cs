namespace Cefaloid;

/// <inheritdoc cref="CefFrame"/>
[PublicAPI]
public static class CefFrameExtensions {

  /// <inheritdoc cref="CefFrame._IsValid"/>
  public static unsafe bool IsValid(ref this CefFrame self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefFrame._Undo"/>
  public static unsafe void Undo(ref this CefFrame self) => self._Undo(self.AsPointer());

  /// <inheritdoc cref="CefFrame._Redo"/>
  public static unsafe void Redo(ref this CefFrame self) => self._Redo(self.AsPointer());

  /// <inheritdoc cref="CefFrame._Cut"/>
  public static unsafe void Cut(ref this CefFrame self) => self._Cut(self.AsPointer());

  /// <inheritdoc cref="CefFrame._Copy"/>
  public static unsafe void Copy(ref this CefFrame self) => self._Copy(self.AsPointer());

  /// <inheritdoc cref="CefFrame._Paste"/>
  public static unsafe void Paste(ref this CefFrame self) => self._Paste(self.AsPointer());

  /// <inheritdoc cref="CefFrame._Delete"/>
  public static unsafe void Delete(ref this CefFrame self) => self._Delete(self.AsPointer());

  /// <inheritdoc cref="CefFrame._SelectAll"/>
  public static unsafe void SelectAll(ref this CefFrame self) => self._SelectAll(self.AsPointer());

  /// <inheritdoc cref="CefFrame._ViewSource"/>
  public static unsafe void ViewSource(ref this CefFrame self) => self._ViewSource(self.AsPointer());

  /// <inheritdoc cref="CefFrame._GetSource"/>
  public static unsafe void GetSource(ref this CefFrame self, ref CefStringVisitor visitor) => self._GetSource(self.AsPointer(), visitor.AsPointer());

  /// <inheritdoc cref="CefFrame._GetText"/>
  public static unsafe void GetText(ref this CefFrame self, ref CefStringVisitor visitor) => self._GetText(self.AsPointer(), visitor.AsPointer());

  /// <inheritdoc cref="CefFrame._LoadRequest"/>
  public static unsafe void LoadRequest(ref this CefFrame self, ref CefRequest cefRequest) => self._LoadRequest(self.AsPointer(), cefRequest.AsPointer());

  /// <inheritdoc cref="CefFrame._LoadUrl"/>
  public static unsafe void LoadUrl(ref this CefFrame self, ref CefString url) => self._LoadUrl(self.AsPointer(), url.AsPointer());

  /// <inheritdoc cref="CefFrame._ExecuteJavaScript"/>
  public static unsafe void ExecuteJavaScript(ref this CefFrame self, ref CefString code, ref CefString scriptUrl, int startLine)
    => self._ExecuteJavaScript(self.AsPointer(), code.AsPointer(), scriptUrl.AsPointer(), startLine);

  /// <inheritdoc cref="CefFrame._IsMain"/>
  public static unsafe bool IsMain(ref this CefFrame self) => self._IsMain(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefFrame._IsFocused"/>
  public static unsafe bool IsFocused(ref this CefFrame self) => self._IsFocused(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefFrame._GetName"/>
  public static unsafe CefStringUserFree* GetName(ref this CefFrame self) => self._GetName(self.AsPointer());

  /// <inheritdoc cref="CefFrame._GetIdentifier"/>
  public static unsafe long GetIdentifier(ref this CefFrame self) => self._GetIdentifier(self.AsPointer());

  /// <inheritdoc cref="CefFrame._GetParent"/>
  public static unsafe CefFrame* GetParent(ref this CefFrame self) => self._GetParent(self.AsPointer());

  /// <inheritdoc cref="CefFrame._GetUrl"/>
  public static unsafe CefStringUserFree* GetUrl(ref this CefFrame self) => self._GetUrl(self.AsPointer());

  /// <inheritdoc cref="CefFrame._GetBrowser"/>
  public static unsafe CefBrowser* GetBrowser(ref this CefFrame self) => self._GetBrowser(self.AsPointer());

  /// <inheritdoc cref="CefFrame._GetV8Context"/>
  public static unsafe CefV8Context* GetV8Context(ref this CefFrame self) => self._GetV8Context(self.AsPointer());

  /// <inheritdoc cref="CefFrame._VisitDom"/>
  public static unsafe void VisitDom(ref this CefFrame self, ref CefDomVisitor visitor) => self._VisitDom(self.AsPointer(), visitor.AsPointer());

  /// <inheritdoc cref="CefFrame._CreateUrlRequest"/>
  public static unsafe CefUrlRequest* CreateUrlRequest(ref this CefFrame self, ref CefRequest cefRequest, ref CefUrlRequestClient client)
    => self._CreateUrlRequest(self.AsPointer(), cefRequest.AsPointer(), client.AsPointer());

  /// <inheritdoc cref="CefFrame._SendProcessMessage"/>
  public static unsafe void SendProcessMessage(ref this CefFrame self, CefProcessId targetProcess, ref CefProcessMessage message)
    => self._SendProcessMessage(self.AsPointer(), targetProcess, message.AsPointer());

}
