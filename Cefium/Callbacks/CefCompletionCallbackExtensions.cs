namespace Cefium;

/// <inheritdoc cref="CefCompletionCallback"/>
[PublicAPI]
public static class CefCompletionCallbackExtensions {

  /// <inheritdoc cref="CefCompletionCallback._OnComplete"/>
  public static unsafe bool OnComplete(ref this CefCompletionCallback self) {
    if (self._OnComplete is null) return false;

    self._OnComplete(self.AsPointer());
    return true;
  }

}
