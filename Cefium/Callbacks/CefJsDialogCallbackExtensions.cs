namespace Cefium;

/// <inheritdoc cref="CefJsDialogCallback" />
[PublicAPI]
public static class CefJsDialogCallbackExtensions {

  /// <inheritdoc cref="CefJsDialogCallback._Continue"/>
  public static unsafe bool Continue(ref this CefJsDialogCallback self, int success, ref CefString userInput) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), success, userInput.AsPointer());
    return true;
  }

}
