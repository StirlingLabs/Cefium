namespace Cefium;

public enum CefUriUnescapeRule : int {

  // cef_uri_unescape_rule_t
  UuNone = 0, // UU_NONE

  UuNormal = 1, // UU_NORMAL

  UuSpaces = 2, // UU_SPACES

  UuPathSeparators = 4, // UU_PATH_SEPARATORS

  UuUrlSpecialCharsExceptPathSeparators = 8, // UU_URL_SPECIAL_CHARS_EXCEPT_PATH_SEPARATORS

  UuReplacePlusWithSpace = 16, // UU_REPLACE_PLUS_WITH_SPACE

}
