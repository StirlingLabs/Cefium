namespace Cefium;

/// <summary>
/// Supported content setting values. Should be kept in sync with Chromium's
/// ContentSetting type.
/// <c>cef_content_setting_values_t</c>
/// </summary>
[PublicAPI]
public enum CefContentSettingValues {

  Default = 0,

  Allow,

  Block,

  Ask,

  SessionOnly,

  DetectImportantContent,

  NumValues

}
