namespace Cefaloid;

/// <inheritdoc cref="CefPostData"/>
[PublicAPI]
public static class CefPostDataExtensions {

  /// <inheritdoc cref="CefPostData._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefPostData self) => self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostData._HasExcludedElements"/>
  public static unsafe bool HasExcludedElements(ref this CefPostData self) => self._HasExcludedElements(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostData._GetElementCount"/>
  public static unsafe nuint GetElementCount(ref this CefPostData self) => self._GetElementCount(self.AsPointer());

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe void GetElements(ref this CefPostData self, ref nuint elementsCount, ref CefPostDataElement* elements)
    => self._GetElements(self.AsPointer(), elementsCount.AsPointer(), AsPointer(ref elements));

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe CefPostDataElement*[] GetElements(ref this CefPostData self) {
    var count = self.GetElementCount();
    var elements = new CefPostDataElement*[count];
    fixed (CefPostDataElement** arrayData = elements)
      self.GetElements(ref count, ref *arrayData);
    return elements;
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe void ForEachElement(ref this CefPostData self, delegate *<CefPostDataElement*, bool> action) {
    var count = self.GetElementCount();
    var elements = stackalloc CefPostDataElement*[checked((int) count)];
    self.GetElements(ref count, ref *elements);
    for (nuint i = 0; i < count; ++i) {
      if (!action(elements[i]))
        break;
    }
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe void WithElements(ref this CefPostData self, delegate *<CefPostDataElement**, nuint, void> action) {
    var count = self.GetElementCount();
    var elements = stackalloc CefPostDataElement*[checked((int) count)];
    self.GetElements(ref count, ref *elements);
    action(elements, count);
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe void WithElements<TArg>(ref this CefPostData self, delegate *<CefPostDataElement**, nuint, TArg, void> action, TArg actionArg) {
    var count = self.GetElementCount();
    var elements = stackalloc CefPostDataElement*[checked((int) count)];
    self.GetElements(ref count, ref *elements);
    action(elements, count, actionArg);
  }

  /// <inheritdoc cref="CefPostData._GetElements"/>
  public static unsafe void ForEachElement<TArg>(ref this CefPostData self, delegate *<CefPostDataElement*, TArg, bool> action, TArg actionArg) {
    var count = self.GetElementCount();
    var elements = stackalloc CefPostDataElement*[checked((int) count)];
    self.GetElements(ref count, ref *elements);
    for (nuint i = 0; i < count; ++i) {
      if (!action(elements[i], actionArg))
        break;
    }
  }

  /// <inheritdoc cref="CefPostData._RemoveElement"/>
  public static unsafe bool RemoveElement(ref this CefPostData self, ref CefPostDataElement element) => self._RemoveElement(self.AsPointer(), element.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostData._AddElement"/>
  public static unsafe bool AddElement(ref this CefPostData self, ref CefPostDataElement element) => self._AddElement(self.AsPointer(), element.AsPointer()) != 0;

  /// <inheritdoc cref="CefPostData._RemoveElements"/>
  public static unsafe void RemoveElements(ref this CefPostData self) => self._RemoveElements(self.AsPointer());

}
