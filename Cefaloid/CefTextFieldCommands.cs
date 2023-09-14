namespace Cefaloid;

public enum CefTextFieldCommands : int { // cef_text_field_commands_t
  CefTfcCut = 1, // CEF_TFC_CUT
  CefTfcCopy = 2, // CEF_TFC_COPY
  CefTfcPaste = 3, // CEF_TFC_PASTE
  CefTfcUndo = 4, // CEF_TFC_UNDO
  CefTfcDelete = 5, // CEF_TFC_DELETE
  CefTfcSelectAll = 6, // CEF_TFC_SELECT_ALL
}