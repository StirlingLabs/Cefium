namespace Cefium;

/// <summary>
/// Callback structure for cef_media_sink_t::GetDeviceInfo. The functions of
/// this structure will be called on the browser process UI thread.
/// <c>cef_media_sink_device_info_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaSinkDeviceInfoCallback : ICefRefCountedBase<CefMediaSinkDeviceInfoCallback> {

  /// <see cref="CefMediaSinkDeviceInfoCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefMediaSinkDeviceInfoCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be executed asyncronously once device information has
  /// been retrieved.
  /// <c>void(CEF_CALLBACK* on_media_sink_device_info)(struct _cef_media_sink_device_info_callback_t* self, const struct _cef_media_sink_device_info_t* device_info);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSinkDeviceInfoCallback*, CefMediaSinkDeviceInfo*, void> _OnMediaSinkDeviceInfo;

}
