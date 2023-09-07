namespace Cefaloid;

/// <inheritdoc cref="CefJsDialogCallback" />
[PublicAPI]
public static class CefJsDialogCallbackExtensions {

  /// <inheritdoc cref="CefJsDialogCallback._Continue"/>
  public static unsafe void Continue(ref this CefJsDialogCallback self, int success, ref CefString userInput)
    => self._Continue(self.AsPointer(), success, userInput.AsPointer());

}
