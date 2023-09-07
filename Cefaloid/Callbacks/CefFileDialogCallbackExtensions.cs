namespace Cefaloid;

/// <inheritdoc cref="CefFileDialogCallback"/>
[PublicAPI]
public static class CefFileDialogCallbackExtensions {

  /// <inheritdoc cref="CefFileDialogCallback._Continue"/>
  public static unsafe void Continue(ref this CefFileDialogCallback self, ref CefStringList filePaths)
    => self._Continue(self.AsPointer(), filePaths.AsPointer());

  /// <inheritdoc cref="CefFileDialogCallback._Cancel"/>
  public static unsafe void Cancel(ref this CefFileDialogCallback self)
    => self._Cancel(self.AsPointer());

}
