namespace Cefium;

/// <inheritdoc cref="CefFrame"/>
[PublicAPI]
public static class CefFrameExtensions {

  /// <inheritdoc cref="CefFrame._IsValid"/>
  public static unsafe bool IsValid(ref this CefFrame self)
    => self._IsValid is not null && self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefFrame._Undo"/>
  public static unsafe bool Undo(ref this CefFrame self) {
    if (self._Undo is null) return false;

    self._Undo(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._Redo"/>
  public static unsafe bool Redo(ref this CefFrame self) {
    if (self._Redo is null) return false;

    self._Redo(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._Cut"/>
  public static unsafe bool Cut(ref this CefFrame self) {
    if (self._Cut is null) return false;

    self._Cut(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._Copy"/>
  public static unsafe bool Copy(ref this CefFrame self) {
    if (self._Copy is null) return false;

    self._Copy(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._Paste"/>
  public static unsafe bool Paste(ref this CefFrame self) {
    if (self._Paste is null) return false;

    self._Paste(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._Delete"/>
  public static unsafe bool Delete(ref this CefFrame self) {
    if (self._Delete is null) return false;

    self._Delete(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._SelectAll"/>
  public static unsafe bool SelectAll(ref this CefFrame self) {
    if (self._SelectAll is null) return false;

    self._SelectAll(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._ViewSource"/>
  public static unsafe bool ViewSource(ref this CefFrame self) {
    if (self._ViewSource is null) return false;

    self._ViewSource(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._GetSource"/>
  public static unsafe bool GetSource(ref this CefFrame self, ref CefStringVisitor visitor) {
    if (self._GetSource is null) return false;

    self._GetSource(self.AsPointer(), visitor.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._GetText"/>
  public static unsafe bool GetText(ref this CefFrame self, ref CefStringVisitor visitor) {
    if (self._GetText is null) return false;

    self._GetText(self.AsPointer(), visitor.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._LoadRequest"/>
  public static unsafe bool LoadRequest(ref this CefFrame self, ref CefRequest cefRequest) {
    if (self._LoadRequest is null) return false;

    self._LoadRequest(self.AsPointer(), cefRequest.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._LoadUrl"/>
  public static unsafe bool LoadUrl(ref this CefFrame self, ref CefString url) {
    if (self._LoadUrl is null) return false;

    self._LoadUrl(self.AsPointer(), url.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._ExecuteJavaScript"/>
  public static unsafe bool ExecuteJavaScript(ref this CefFrame self, ref CefString code, ref CefString scriptUrl, int startLine) {
    if (self._ExecuteJavaScript is null) return false;

    self._ExecuteJavaScript(self.AsPointer(), code.AsPointer(), scriptUrl.AsPointer(), startLine);
    return true;
  }

  /// <inheritdoc cref="CefFrame._IsMain"/>
  public static unsafe bool IsMain(ref this CefFrame self)
    => self._IsMain is not null && self._IsMain(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefFrame._IsFocused"/>
  public static unsafe bool IsFocused(ref this CefFrame self)
    => self._IsFocused is not null && self._IsFocused(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefFrame._GetName"/>
  public static unsafe CefStringUserFree* GetName(ref this CefFrame self)
    => self._GetName is not null ? self._GetName(self.AsPointer()) : default;

  /// <inheritdoc cref="CefFrame._GetIdentifier"/>
  public static unsafe long GetIdentifier(ref this CefFrame self)
    => self._GetIdentifier is not null ? self._GetIdentifier(self.AsPointer()) : default;

  /// <inheritdoc cref="CefFrame._GetParent"/>
  public static unsafe CefFrame* GetParent(ref this CefFrame self)
    => self._GetParent is not null ? self._GetParent(self.AsPointer()) : default;

  /// <inheritdoc cref="CefFrame._GetUrl"/>
  public static unsafe CefStringUserFree* GetUrl(ref this CefFrame self)
    => self._GetUrl is not null ? self._GetUrl(self.AsPointer()) : default;

  /// <inheritdoc cref="CefFrame._GetBrowser"/>
  public static unsafe CefBrowser* GetBrowser(ref this CefFrame self)
    => self._GetBrowser is not null ? self._GetBrowser(self.AsPointer()) : default;

  /// <inheritdoc cref="CefFrame._GetV8Context"/>
  public static unsafe CefV8Context* GetV8Context(ref this CefFrame self)
    => self._GetV8Context is not null ? self._GetV8Context(self.AsPointer()) : default;

  /// <inheritdoc cref="CefFrame._VisitDom"/>
  public static unsafe bool VisitDom(ref this CefFrame self, ref CefDomVisitor visitor) {
    if (self._VisitDom is null) return false;

    self._VisitDom(self.AsPointer(), visitor.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFrame._CreateUrlRequest"/>
  public static unsafe CefUrlRequest* CreateUrlRequest(ref this CefFrame self, ref CefRequest cefRequest, ref CefUrlRequestClient client)
    => self._CreateUrlRequest is not null ? self._CreateUrlRequest(self.AsPointer(), cefRequest.AsPointer(), client.AsPointer()) : default;

  /// <inheritdoc cref="CefFrame._SendProcessMessage"/>
  public static unsafe bool SendProcessMessage(ref this CefFrame self, CefProcessId targetProcess, ref CefProcessMessage message) {
    if (self._SendProcessMessage is null) return false;

    self._SendProcessMessage(self.AsPointer(), targetProcess, message.AsPointer());
    return true;
  }

}
