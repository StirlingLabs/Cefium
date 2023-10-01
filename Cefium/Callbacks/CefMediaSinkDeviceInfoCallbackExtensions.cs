namespace Cefium;

/// <inheritdoc cref="CefMediaSinkDeviceInfoCallback" />
[PublicAPI]
public static class CefMediaSinkDeviceInfoCallbackExtensions {

  /// <inheritdoc cref="CefMediaSinkDeviceInfoCallback._OnMediaSinkDeviceInfo"/>
  public static unsafe bool OnMediaSinkDeviceInfo(ref this CefMediaSinkDeviceInfoCallback self, ref CefMediaSinkDeviceInfo deviceInfo) {
    if (self._OnMediaSinkDeviceInfo is null) return false;

    self._OnMediaSinkDeviceInfo(self.AsPointer(), deviceInfo.AsPointer());
    return true;
  }

}
