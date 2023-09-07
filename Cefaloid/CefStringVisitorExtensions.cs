namespace Cefaloid;

/// <inheritdoc cref="CefStringVisitor"/>
[PublicAPI]
public static class CefStringVisitorExtensions {

  /// <inheritdoc cref="CefStringVisitor._Visit"/>
  public static unsafe void Visit(ref this CefStringVisitor self, ref CefString @string)
    => self._Visit(self.AsPointer(), @string.AsPointer());

}
