namespace Cefium;

/// <inheritdoc cref="CefAudioHandler"/>
[PublicAPI]
public static class CefAudioHandlerExtensions {

  /// <inheritdoc cref="CefAudioHandler._GetAudioParameters"/>
  public static unsafe bool GetAudioParameters(ref this CefAudioHandler self, ref CefBrowser browser, ref CefAudioParameters parameters)
    => self._GetAudioParameters is not null && self._GetAudioParameters(self.AsPointer(), browser.AsPointer(), parameters.AsPointer()) != 0;

  /// <inheritdoc cref="CefAudioHandler._OnAudioStreamStarted"/>
  public static unsafe bool OnAudioStreamStarted(ref this CefAudioHandler self, ref CefBrowser browser, ref CefAudioParameters parameters, int channels) {
    if (self._OnAudioStreamStarted is null) return false;

    self._OnAudioStreamStarted(self.AsPointer(), browser.AsPointer(), parameters.AsPointer(), channels);
    return true;
  }

  /// <inheritdoc cref="CefAudioHandler._OnAudioStreamPacket"/>
  public static unsafe bool OnAudioStreamPacket(ref this CefAudioHandler self, ref CefBrowser browser, ref float* data, int frames, long pts) {
    if (self._OnAudioStreamPacket is null) return false;

    self._OnAudioStreamPacket(self.AsPointer(), browser.AsPointer(), AsPointer(ref data), frames, pts);
    return true;
  }

  /// <inheritdoc cref="CefAudioHandler._OnAudioStreamStopped"/>
  public static unsafe bool OnAudioStreamStopped(ref this CefAudioHandler self, ref CefBrowser browser) {
    if (self._OnAudioStreamStopped is null) return false;

    self._OnAudioStreamStopped(self.AsPointer(), browser.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefAudioHandler._OnAudioStreamError"/>
  public static unsafe bool OnAudioStreamError(ref this CefAudioHandler self, ref CefBrowser browser, ref CefString message) {
    if (self._OnAudioStreamError is null) return false;

    self._OnAudioStreamError(self.AsPointer(), browser.AsPointer(), message.AsPointer());
    return true;
  }

}
