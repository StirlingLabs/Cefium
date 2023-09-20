namespace Cefium;

/// <summary>
/// Supported file dialog modes.
/// <c>cef_file_dialog_mode_t</c>
/// </summary>
[PublicAPI]
public enum CefFileDialogMode {

  /// <summary>
  /// Requires that the file exists before allowing the user to pick it.
  /// <c>FILE_DIALOG_OPEN</c>
  /// </summary>
  Open = 0,

  /// <summary>
  ///
  /// Like Open, but allows picking multiple files to open.
  /// <c>FILE_DIALOG_OPEN_MULTIPLE</c>
  /// </summary>
  OpenMultiple,

  /// <summary>
  /// Like Open, but selects a folder to open.
  /// <c>FILE_DIALOG_OPEN_FOLDER</c>
  /// </summary>
  OpenFolder,

  /// <summary>
  /// Allows picking a nonexistent file, and prompts to overwrite if the file
  /// already exists.
  /// <c>FILE_DIALOG_SAVE</c>
  /// </summary>
  Save

}
