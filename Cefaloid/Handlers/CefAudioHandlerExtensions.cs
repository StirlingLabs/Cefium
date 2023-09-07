namespace Cefaloid;

/// <inheritdoc cref="CefAudioHandler"/>
[PublicAPI]
public static class CefAudioHandlerExtensions {

  /// <inheritdoc cref="CefAudioHandler._GetAudioParameters"/>
  public static unsafe bool GetAudioParameters(ref this CefAudioHandler self, ref CefBrowser browser, ref CefAudioParameters parameters)
    => self._GetAudioParameters(self.AsPointer(), browser.AsPointer(), parameters.AsPointer()) != 0;

  /// <inheritdoc cref="CefAudioHandler._OnAudioStreamStarted"/>
  public static unsafe void OnAudioStreamStarted(ref this CefAudioHandler self, ref CefBrowser browser, ref CefAudioParameters parameters, int channels)
    => self._OnAudioStreamStarted(self.AsPointer(), browser.AsPointer(), parameters.AsPointer(), channels);

  /// <inheritdoc cref="CefAudioHandler._OnAudioStreamPacket"/>
  public static unsafe void OnAudioStreamPacket(ref this CefAudioHandler self, ref CefBrowser browser, ref float* data, int frames, long pts)
    => self._OnAudioStreamPacket(self.AsPointer(), browser.AsPointer(), AsPointer(ref data), frames, pts);

  /// <inheritdoc cref="CefAudioHandler._OnAudioStreamStopped"/>
  public static unsafe void OnAudioStreamStopped(ref this CefAudioHandler self, ref CefBrowser browser)
    => self._OnAudioStreamStopped(self.AsPointer(), browser.AsPointer());

  /// <inheritdoc cref="CefAudioHandler._OnAudioStreamError"/>
  public static unsafe void OnAudioStreamError(ref this CefAudioHandler self, ref CefBrowser browser, ref CefString message)
    => self._OnAudioStreamError(self.AsPointer(), browser.AsPointer(), message.AsPointer());

}
