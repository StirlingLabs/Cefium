namespace Cefium;

/// <inheritdoc cref="CefPostData"/>
[PublicAPI]
public static class CefPostDataExtensions {

  /// <inheritdoc cref="CefPostData._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefPostData self)
    => self._IsReadOnly is not null && self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostData._HasExcludedElements"/>
  public static unsafe bool HasExcludedElements(ref this CefPostData self)
    => self._HasExcludedElements is not null && self._HasExcludedElements(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostData._GetElementCount"/>
  public static unsafe nuint GetElementCount(ref this CefPostData self)
    => self._GetElementCount is not null ? self._GetElementCount(self.AsPointer()) : default;

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe bool GetElements(ref this CefPostData self, ref nuint elementsCount, ref CefPostDataElement* elements) {
    if (self._GetElements is null) return false;

    self._GetElements(self.AsPointer(), elementsCount.AsPointer(), AsPointer(ref elements));
    return true;
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe CefPostDataElement*[]? GetElements(ref this CefPostData self) {
    if (self._GetElementCount is null || self._GetElements is null) return null;

    var count = self.GetElementCount();
    var elements = new CefPostDataElement*[count];
    fixed (CefPostDataElement** arrayData = elements)
      self.GetElements(ref count, ref *arrayData);
    return elements;
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe bool ForEachElement(ref this CefPostData self, delegate *<CefPostDataElement*, bool> action) {
    if (self._GetElementCount is null || self._GetElements is null) return false;

    var count = self.GetElementCount();
    var elements = stackalloc CefPostDataElement*[checked((int) count)];
    self.GetElements(ref count, ref *elements);
    for (nuint i = 0; i < count; ++i) {
      if (!action(elements[i]))
        break;
    }

    return true;
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe bool WithElements(ref this CefPostData self, delegate *<CefPostDataElement**, nuint, void> action) {
    if (self._GetElementCount is null || self._GetElements is null) return false;

    var count = self.GetElementCount();
    var elements = stackalloc CefPostDataElement*[checked((int) count)];
    self.GetElements(ref count, ref *elements);
    action(elements, count);
    return true;
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe bool WithElements<TArg>(ref this CefPostData self, delegate *<CefPostDataElement**, nuint, TArg, void> action, TArg actionArg) {
    if (self._GetElementCount is null || self._GetElements is null) return false;

    var count = self.GetElementCount();
    var elements = stackalloc CefPostDataElement*[checked((int) count)];
    self.GetElements(ref count, ref *elements);
    action(elements, count, actionArg);
    return true;
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe bool ForEachElement<TArg>(ref this CefPostData self, delegate *<CefPostDataElement*, TArg, bool> action, TArg actionArg) {
    if (self._GetElementCount is null || self._GetElements is null) return false;

    var count = self.GetElementCount();
    var elements = stackalloc CefPostDataElement*[checked((int) count)];
    self.GetElements(ref count, ref *elements);
    for (nuint i = 0; i < count; ++i) {
      if (!action(elements[i], actionArg))
        break;
    }

    return true;
  }

  /// <inheritdoc cref="CefPostData._RemoveElement"/>
  public static unsafe bool RemoveElement(ref this CefPostData self, ref CefPostDataElement element)
    => self._RemoveElement is not null && self._RemoveElement(self.AsPointer(), element.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostData._AddElement"/>
  public static unsafe bool AddElement(ref this CefPostData self, ref CefPostDataElement element)
    => self._AddElement is not null && self._AddElement(self.AsPointer(), element.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostData._RemoveElements"/>
  public static unsafe bool RemoveElements(ref this CefPostData self) {
    if (self._RemoveElements is null) return false;

    self._RemoveElements(self.AsPointer());
    return true;
  }

}
