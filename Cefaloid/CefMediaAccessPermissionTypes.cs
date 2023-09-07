namespace Cefaloid;

/// <summary>
/// Media access permissions used by OnRequestMediaAccessPermission.
/// <c>cef_media_access_permission_types_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefMediaAccessPermissionTypes {

  /// <summary>
  /// No permission.
  /// <c>CEF_MEDIA_PERMISSION_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// Device audio capture permission.
  /// <c>CEF_MEDIA_PERMISSION_DEVICE_AUDIO_CAPTURE</c>
  /// </summary>
  DeviceAudioCapture = 1 << 0,

  /// <summary>
  /// Device video capture permission.
  /// <c>CEF_MEDIA_PERMISSION_DEVICE_VIDEO_CAPTURE</c>
  /// </summary>
  DeviceVideoCapture = 1 << 1,

  /// <summary>
  /// Desktop audio capture permission.
  /// <c>CEF_MEDIA_PERMISSION_DESKTOP_AUDIO_CAPTURE</c>
  /// </summary>
  DesktopAudioCapture = 1 << 2,

  /// <summary>
  /// Desktop video capture permission.
  /// <c>CEF_MEDIA_PERMISSION_DESKTOP_VIDEO_CAPTURE</c>
  /// </summary>
  DesktopVideoCapture = 1 << 3,

}
