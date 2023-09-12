namespace Cefaloid;

/// <summary>
/// Implement this structure to handle audio events.
/// <c>cef_audio_handler_t</c>
/// </summary>
/// <seealso cref="CefAudioHandlerExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefAudioHandler : ICefRefCountedBase<CefAudioHandler> {

  /// <inheritdoc cref="CefAudioHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefAudioHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called on the UI thread to allow configuration of audio stream parameters.
  /// Return true (1) to proceed with audio stream capture, or false (0) to
  /// cancel it. All members of |params| can optionally be configured here, but
  /// they are also pre-filled with some sensible defaults.
  /// <c>int(CEF_CALLBACK* get_audio_parameters)(struct _cef_audio_handler_t* self, struct _cef_browser_t* browser, cef_audio_parameters_t* params);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAudioHandler*, CefBrowser*, CefAudioParameters*, int> _GetAudioParameters;

  /// <summary>
  /// Called on a browser audio capture thread when the browser starts streaming
  /// audio. OnAudioStreamStopped will always be called after
  /// OnAudioStreamStarted; both functions may be called multiple times for the
  /// same browser. |params| contains the audio parameters like sample rate and
  /// channel layout. |channels| is the number of channels.
  /// <c>void(CEF_CALLBACK* on_audio_stream_started)(struct _cef_audio_handler_t* self, struct _cef_browser_t* browser, const cef_audio_parameters_t* params, int channels);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAudioHandler*, CefBrowser*, CefAudioParameters*, int, void> _OnAudioStreamStarted;

  /// <summary>
  /// Called on the audio stream thread when a PCM packet is received for the
  /// stream. |data| is an array representing the raw PCM data as a floating
  /// point type, i.e. 4-byte value(s). |frames| is the number of frames in the
  /// PCM packet. |pts| is the presentation timestamp (in milliseconds since the
  /// Unix Epoch) and represents the time at which the decompressed packet
  /// should be presented to the user. Based on |frames| and the
  /// |channel_layout| value passed to OnAudioStreamStarted you can calculate
  /// the size of the |data| array in bytes.
  /// <c>void(CEF_CALLBACK* on_audio_stream_packet)(struct _cef_audio_handler_t* self, struct _cef_browser_t* browser, const float** data, int frames, int64 pts);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAudioHandler*, CefBrowser*, float**, int, long, void> _OnAudioStreamPacket;

  /// <summary>
  /// Called on the UI thread when the stream has stopped. OnAudioSteamStopped
  /// will always be called after OnAudioStreamStarted; both functions may be
  /// called multiple times for the same stream.
  /// <c>void(CEF_CALLBACK* on_audio_stream_stopped)(struct _cef_audio_handler_t* self, struct _cef_browser_t* browser);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAudioHandler*, CefBrowser*, void> _OnAudioStreamStopped;

  /// <summary>
  /// Called on the UI or audio stream thread when an error occurred. During the
  /// stream creation phase this callback will be called on the UI thread while
  /// in the capturing phase it will be called on the audio stream thread. The
  /// stream will be stopped immediately.
  /// <c>void(CEF_CALLBACK* on_audio_stream_error)(struct _cef_audio_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* message);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefAudioHandler*, CefBrowser*, CefString*, void> _OnAudioStreamError;

}
