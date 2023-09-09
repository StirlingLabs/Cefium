namespace Cefaloid;

/// <inheritdoc cref="CefDomDocument"/>
[PublicAPI]
public static class CefDomDocumentExtensions {

  /// <inheritdoc cref="CefDomDocument._GetType"/>
  public static unsafe CefDomDocumentType GetType(ref this CefDomDocument self) => self._GetType(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetDocument"/>
  public static unsafe CefDomNode* GetDocument(ref this CefDomDocument self) => self._GetDocument(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetBody"/>
  public static unsafe CefDomNode* GetBody(ref this CefDomDocument self) => self._GetBody(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetHead"/>
  public static unsafe CefDomNode* GetHead(ref this CefDomDocument self) => self._GetHead(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetTitle"/>
  public static unsafe CefStringUserFree* GetTitle(ref this CefDomDocument self) => self._GetTitle(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetFocusedNode"/>
  public static unsafe CefDomNode* GetFocusedNode(ref this CefDomDocument self) => self._GetFocusedNode(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._HasSelection"/>
  public static unsafe bool HasSelection(ref this CefDomDocument self) => self._HasSelection(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomDocument._GetSelectionStartOffset"/>
  public static unsafe int GetSelectionStartOffset(ref this CefDomDocument self) => self._GetSelectionStartOffset(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetSelectionEndOffset"/>
  public static unsafe int GetSelectionEndOffset(ref this CefDomDocument self) => self._GetSelectionEndOffset(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetSelectionAsMarkup"/>
  public static unsafe CefStringUserFree* GetSelectionAsMarkup(ref this CefDomDocument self) => self._GetSelectionAsMarkup(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetSelectionAsText"/>
  public static unsafe CefStringUserFree* GetSelectionAsText(ref this CefDomDocument self) => self._GetSelectionAsText(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetBaseUrl"/>
  public static unsafe CefStringUserFree* GetBaseUrl(ref this CefDomDocument self) => self._GetBaseUrl(self.AsPointer());

  /// <inheritdoc cref="CefDomDocument._GetCompleteUrl"/>
  public static unsafe CefStringUserFree* GetCompleteUrl(ref this CefDomDocument self, ref CefString partialUrl)
    => self._GetCompleteUrl(self.AsPointer(), partialUrl.AsPointer());

}
