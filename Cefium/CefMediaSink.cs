namespace Cefium;

/// <summary>
/// Represents a sink to which media can be routed. Instances of this object are
/// retrieved via cef_media_observer_t::OnSinks. The functions of this structure
/// may be called on any browser process thread unless otherwise indicated.
/// <c>cef_media_sink_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaSink : ICefRefCountedBase<CefMediaSink> {

  /// <inheritdoc cref="CefMediaSink"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefMediaSink() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the ID for this sink.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_id)(struct _cef_media_sink_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSink*, CefStringUserFree*> _GetId;

  /// <summary>
  /// Returns the name of this sink.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_name)(struct _cef_media_sink_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSink*, CefStringUserFree*> _GetName;

  /// <summary>
  /// Returns the icon type for this sink.
  /// <c>cef_media_sink_icon_type_t(CEF_CALLBACK* get_icon_type)(struct _cef_media_sink_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSink*, CefMediaSinkIconType> _GetIconType;

  /// <summary>
  /// Asynchronously retrieves device info.
  /// <c>void(CEF_CALLBACK* get_device_info)(struct _cef_media_sink_t* self, struct _cef_media_sink_device_info_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSink*, CefMediaSinkDeviceInfoCallback*, void> _GetDeviceInfo;

  /// <summary>
  /// Returns true (1) if this sink accepts content via Cast.
  /// <c>int(CEF_CALLBACK* is_cast_sink)(struct _cef_media_sink_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSink*, int> _IsCastSink;

  /// <summary>
  /// Returns true (1) if this sink accepts content via DIAL.
  /// <c>int(CEF_CALLBACK* is_dial_sink)(struct _cef_media_sink_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSink*, int> _IsDialSink;

  /// <summary>
  /// Returns true (1) if this sink is compatible with |source|.
  /// <c>int(CEF_CALLBACK* is_compatible_with)(struct _cef_media_sink_t* self, struct _cef_media_source_t* source);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSink*, CefMediaSource*, int> _IsCompatibleWith;

}
