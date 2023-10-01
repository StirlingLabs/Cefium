namespace Cefium;

/// <inheritdoc cref="CefDomNode" />
[PublicAPI]
public static class CefDomNodeExtensions {

  /// <inheritdoc cref="CefDomNode._GetType" />
  public static unsafe CefDomNodeType GetType(ref this CefDomNode self)
    => self._GetType is not null ? self._GetType(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._IsText" />
  public static unsafe bool IsText(ref this CefDomNode self)
    => self._IsText is not null && self._IsText(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._IsElement" />
  public static unsafe bool IsElement(ref this CefDomNode self)
    => self._IsElement is not null && self._IsElement(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._IsEditable" />
  public static unsafe bool IsEditable(ref this CefDomNode self)
    => self._IsEditable is not null && self._IsEditable(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._IsFormControlElement" />
  public static unsafe bool IsFormControlElement(ref this CefDomNode self)
    => self._IsFormControlElement is not null && self._IsFormControlElement(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._GetFormControlElementType" />
  public static unsafe CefStringUserFree* GetFormControlElementType(ref this CefDomNode self)
    => self._GetFormControlElementType is not null ? self._GetFormControlElementType(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._IsSame" />
  public static unsafe bool IsSame(ref this CefDomNode self, ref CefDomNode that)
    => self._IsSame is not null && self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._GetName" />
  public static unsafe CefStringUserFree* GetName(ref this CefDomNode self)
    => self._GetName is not null ? self._GetName(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._GetValue" />
  public static unsafe CefStringUserFree* GetValue(ref this CefDomNode self)
    => self._GetValue is not null ? self._GetValue(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._SetValue" />
  public static unsafe bool SetValue(ref this CefDomNode self, ref CefString value)
    => self._SetValue is not null && self._SetValue(self.AsPointer(), value.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._GetAsMarkup" />
  public static unsafe CefStringUserFree* GetAsMarkup(ref this CefDomNode self)
    => self._GetAsMarkup is not null ? self._GetAsMarkup(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._GetDocument" />
  public static unsafe CefDomDocument* GetDocument(ref this CefDomNode self)
    => self._GetDocument is not null ? self._GetDocument(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._GetParent" />
  public static unsafe CefDomNode* GetParent(ref this CefDomNode self)
    => self._GetParent is not null ? self._GetParent(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._GetPreviousSibling" />
  public static unsafe CefDomNode* GetPreviousSibling(ref this CefDomNode self)
    => self._GetPreviousSibling is not null ? self._GetPreviousSibling(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._GetNextSibling" />
  public static unsafe CefDomNode* GetNextSibling(ref this CefDomNode self)
    => self._GetNextSibling is not null ? self._GetNextSibling(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._HasChildren" />
  public static unsafe bool HasChildren(ref this CefDomNode self)
    => self._HasChildren is not null && self._HasChildren(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._GetFirstChild" />
  public static unsafe CefDomNode* GetFirstChild(ref this CefDomNode self)
    => self._GetFirstChild is not null ? self._GetFirstChild(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._GetElementTagName" />
  public static unsafe CefStringUserFree* GetElementTagName(ref this CefDomNode self)
    => self._GetElementTagName is not null ? self._GetElementTagName(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._HasElementAttributes" />
  public static unsafe bool HasElementAttributes(ref this CefDomNode self)
    => self._HasElementAttributes is not null && self._HasElementAttributes(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._HasElementAttribute" />
  public static unsafe bool HasElementAttribute(ref this CefDomNode self, ref CefString attrName)
    => self._HasElementAttribute is not null && self._HasElementAttribute(self.AsPointer(), attrName.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._GetElementAttribute" />
  public static unsafe CefStringUserFree* GetElementAttribute(ref this CefDomNode self, ref CefString attrName)
    => self._GetElementAttribute is not null ? self._GetElementAttribute(self.AsPointer(), attrName.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._GetElementAttributes" />
  public static unsafe CefStringMap* GetElementAttributes(ref this CefDomNode self)
    => self._GetElementAttributes is not null ? self._GetElementAttributes(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._SetElementAttribute" />
  public static unsafe bool SetElementAttribute(ref this CefDomNode self, ref CefString attrName, ref CefString value)
    => self._SetElementAttribute is not null && self._SetElementAttribute(self.AsPointer(), attrName.AsPointer(), value.AsPointer()) != 0;

  /// <inheritdoc cref="CefDomNode._GetElementInnerText" />
  public static unsafe CefStringUserFree* GetElementInnerText(ref this CefDomNode self)
    => self._GetElementInnerText is not null ? self._GetElementInnerText(self.AsPointer()) : default;

  /// <inheritdoc cref="CefDomNode._GetElementBounds" />
  public static unsafe bool GetElementBounds(ref this CefDomNode self, ref CefRect rect) {
    if (self._GetElementBounds is null) return false;

    self._GetElementBounds(self.AsPointer(), rect.AsPointer());
    return true;
  }

}
