namespace Cefium;

/// <inheritdoc cref="CefRunFileDialogCallback" />
[PublicAPI]
public static class CefRunFileDialogCallbackExtensions {

  /// <inheritdoc cref="CefRunFileDialogCallback._OnFileDialogDismissed" />
  public static unsafe void OnFileDialogDismissed(ref this CefRunFileDialogCallback self, ref CefStringList filePaths)
    => self._OnFileDialogDismissed(self.AsPointer(), filePaths.AsPointer());

}
