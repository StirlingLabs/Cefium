namespace Cefium;

/// <summary>
/// Structure representing the audio parameters for setting up the audio
/// handler.
/// <c>cef_audio_parameters_t</c>
///</summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefAudioParameters {

  /// <summary>
  /// Layout of the audio channels
  ///</summary>
  public CefChannelLayout ChannelLayout;

  /// <summary>
  /// Sample rate
  ///</summary>
  public int SampleRate;

  /// <summary>
  /// Number of frames per buffer
  ///</summary>
  public int FramesPerBuffer;

}
