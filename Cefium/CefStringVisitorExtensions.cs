namespace Cefium;

/// <inheritdoc cref="CefStringVisitor"/>
[PublicAPI]
public static class CefStringVisitorExtensions {

  /// <inheritdoc cref="CefStringVisitor._Visit"/>
  public static unsafe bool Visit(ref this CefStringVisitor self, ref CefString @string) {
    if (self._Visit is null) return false;

    self._Visit(self.AsPointer(), @string.AsPointer());
    return true;
  }

}
