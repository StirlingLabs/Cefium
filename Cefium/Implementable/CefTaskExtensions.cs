namespace Cefium;

/// <inheritdoc cref="CefTask"/>
[PublicAPI]
public static class CefTaskExtensions {

  /// <inheritdoc cref="CefTask._Execute"/>
  public static unsafe bool Execute(ref this CefTask self) {
    if (self._Execute is null) return false;

    self._Execute(self.AsPointer());
    return true;
  }

}
