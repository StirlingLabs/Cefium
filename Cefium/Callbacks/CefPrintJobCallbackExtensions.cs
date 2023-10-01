namespace Cefium;

/// <inheritdoc cref="CefPrintJobCallback" />
[PublicAPI]
public static class CefPrintJobCallbackExtensions {

  /// <inheritdoc cref="CefPrintJobCallback._Continue"/>
  public static unsafe bool Continue(ref this CefPrintJobCallback self) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer());
    return true;
  }

}
