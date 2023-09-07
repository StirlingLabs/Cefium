namespace Cefaloid;

/// <inheritdoc cref="CefCompletionCallback"/>
[PublicAPI]
public static class CefCompletionCallbackExtensions {

  /// <inheritdoc cref="CefCompletionCallback._OnComplete"/>
  public static unsafe void OnComplete(ref this CefCompletionCallback self)
    => self._OnComplete(self.AsPointer());

}
