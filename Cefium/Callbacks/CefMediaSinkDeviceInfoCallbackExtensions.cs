namespace Cefium;

/// <inheritdoc cref="CefMediaSinkDeviceInfoCallback" />
[PublicAPI]
public static class CefMediaSinkDeviceInfoCallbackExtensions {

  /// <inheritdoc cref="CefMediaSinkDeviceInfoCallback._OnMediaSinkDeviceInfo"/>
  public static unsafe void Continue(ref this CefMediaSinkDeviceInfoCallback self, ref CefMediaSinkDeviceInfo deviceInfo)
    => self._OnMediaSinkDeviceInfo(self.AsPointer(), deviceInfo.AsPointer());

}
