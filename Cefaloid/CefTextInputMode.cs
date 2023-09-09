namespace Cefaloid;

/// <summary>
/// Input mode of a virtual keyboard. These constants match their equivalents
/// in Chromium's text_input_mode.h and should not be renumbered.
/// See https://html.spec.whatwg.org/#input-modalities:-the-inputmode-attribute
/// <c>cef_text_input_mode_t</c>
/// </summary>
[PublicAPI]
public enum CefTextInputMode {

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_DEFAULT</c>
  /// </summary>
  Default,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_NONE</c>
  /// </summary>
  None,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_TEXT</c>
  /// </summary>
  Text,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_TEL</c>
  /// </summary>
  Tel,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_URL</c>
  /// </summary>
  Url,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_EMAIL</c>
  /// </summary>
  Email,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_NUMERIC</c>
  /// </summary>
  Numeric,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_DECIMAL</c>
  /// </summary>
  Decimal,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_SEARCH</c>
  /// </summary>
  Search,

  /// <summary>
  /// <c>CEF_TEXT_INPUT_MODE_MAX</c>
  /// </summary>
  Max = Search,

}
