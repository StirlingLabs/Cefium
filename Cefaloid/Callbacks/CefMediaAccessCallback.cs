namespace Cefaloid;

/// <summary>
/// <c>cef_media_access_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaAccessCallback : ICefRefCountedBase<CefMediaAccessCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefMediaAccessCallback() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Call to allow or deny media access. If this callback was initiated in
  /// response to a getUserMedia (indicated by
  /// CEF_MEDIA_PERMISSION_DEVICE_AUDIO_CAPTURE and/or
  /// CEF_MEDIA_PERMISSION_DEVICE_VIDEO_CAPTURE being set) then
  /// |allowed_permissions| must match |required_permissions| passed to
  /// OnRequestMediaAccessPermission.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_media_access_callback_t* self, uint32 allowed_permissions)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaAccessCallback*, CefMediaAccessPermissionTypes, void> _Continue;

  /// <summary>
  /// Cancel the media access request.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_media_access_callback_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaAccessCallback*, void> _Cancel;

}
