namespace Cefium;

/// <inheritdoc cref="CefPrintJobCallback" />
[PublicAPI]
public static class CefPrintJobCallbackExtensions {

  /// <inheritdoc cref="CefPrintJobCallback._Continue"/>
  public static unsafe void Continue(ref this CefPrintJobCallback self)
    => self._Continue(self.AsPointer());

}
