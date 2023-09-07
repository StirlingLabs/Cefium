namespace Cefaloid;

/// <inheritdoc cref="CefTask"/>
[PublicAPI]
public static class CefTaskExtensions {

  /// <inheritdoc cref="CefTask._Execute"/>
  public static unsafe void Execute(ref this CefTask self) => self._Execute(self.AsPointer());

}
