namespace Cefium;

/// <inheritdoc cref="CefDomVisitor"/>
[PublicAPI]
public static class CefDomVisitorExtensions {

  /// <inheritdoc cref="CefDomVisitor._Visit"/>
  public static unsafe bool Visit(ref this CefDomVisitor self, ref CefDomDocument document) {
    if (self._Visit is null) return false;

    self._Visit(self.AsPointer(), document.AsPointer());
    return true;
  }

}
