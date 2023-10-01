namespace Cefium;

/// <inheritdoc cref="CefRunFileDialogCallback" />
[PublicAPI]
public static class CefRunFileDialogCallbackExtensions {

  /// <inheritdoc cref="CefRunFileDialogCallback._OnFileDialogDismissed" />
  public static unsafe bool OnFileDialogDismissed(ref this CefRunFileDialogCallback self, ref CefStringList filePaths) {
    if (self._OnFileDialogDismissed is null) return false;

    self._OnFileDialogDismissed(self.AsPointer(), filePaths.AsPointer());
    return true;
  }

}
