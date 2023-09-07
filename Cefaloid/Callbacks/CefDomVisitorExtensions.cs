namespace Cefaloid;

/// <inheritdoc cref="CefDomVisitor"/>
[PublicAPI]
public static class CefDomVisitorExtensions {

  /// <inheritdoc cref="CefDomVisitor._Visit"/>
  public static unsafe void Visit(ref this CefDomVisitor self, ref CefDomDocument document)
    => self._Visit(self.AsPointer(), document.AsPointer());

}
