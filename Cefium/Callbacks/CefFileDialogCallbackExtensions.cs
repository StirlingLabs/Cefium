namespace Cefium;

/// <inheritdoc cref="CefFileDialogCallback"/>
[PublicAPI]
public static class CefFileDialogCallbackExtensions {

  /// <inheritdoc cref="CefFileDialogCallback._Continue"/>
  public static unsafe bool Continue(ref this CefFileDialogCallback self, ref CefStringList filePaths) {
    if (self._Continue is null) return false;

    self._Continue(self.AsPointer(), filePaths.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefFileDialogCallback._Cancel"/>
  public static unsafe bool Cancel(ref this CefFileDialogCallback self) {
    if (self._Cancel is null) return false;

    self._Cancel(self.AsPointer());
    return true;
  }

}
