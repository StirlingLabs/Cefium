namespace Cefaloid;

/// <summary>
/// Supported JavaScript dialog types.
/// <c>cef_jsdialog_type_t</c>
/// </summary>
public enum CefJsDialogType {

  /// <summary>
  /// <c>JSDIALOGTYPE_ALERT</c>
  /// </summary>
  Alert = 0,

  /// <summary>
  /// <c>JSDIALOGTYPE_CONFIRM</c>
  /// </summary>
  Confirm,

  /// <summary>
  /// <c>JSDIALOGTYPE_PROMPT</c>
  /// </summary>
  Prompt,

}
