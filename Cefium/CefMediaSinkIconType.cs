namespace Cefium;

/// <summary>
/// Icon types for a MediaSink object. Should be kept in sync with Chromium's
/// media_router::SinkIconType type.
/// <c>cef_media_sink_icon_type_t</c>
/// </summary>
[PublicAPI]
public enum CefMediaSinkIconType {

  /// <summary>
  /// <c>CEF_MSIT_CAST</c>
  /// </summary>
  Cast,

  /// <summary>
  /// <c>CEF_MSIT_CAST_AUDIO_GROUP</c>
  /// </summary>
  CastAudioGroup,

  /// <summary>
  /// <c>CEF_MSIT_CAST_AUDIO</c>
  /// </summary>
  CastAudio,

  /// <summary>
  /// <c>CEF_MSIT_MEETING</c>
  /// </summary>
  Meeting,

  /// <summary>
  /// <c>CEF_MSIT_HANGOUT</c>
  /// </summary>
  Hangout,

  /// <summary>
  /// <c>CEF_MSIT_EDUCATION</c>
  /// </summary>
  Education,

  /// <summary>
  /// <c>CEF_MSIT_WIRED_DISPLAY</c>
  /// </summary>
  WiredDisplay,

  /// <summary>
  /// <c>CEF_MSIT_GENERIC</c>
  /// </summary>
  Generic,

  /// <summary>
  /// The total number of values.
  /// <c>CEF_MSIT_TOTAL_COUNT</c>
  /// </summary>
  TotalCount

}
