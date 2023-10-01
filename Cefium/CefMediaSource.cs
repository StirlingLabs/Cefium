namespace Cefium;

/// <summary>
/// Represents a source from which media can be routed. Instances of this object
/// are retrieved via cef_media_router_t::GetSource. The functions of this
/// structure may be called on any browser process thread unless otherwise
/// indicated.
/// <c>cef_media_source_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMediaSource : ICefRefCountedBase<CefMediaSource> {

  /// <inheritdoc cref="CefMediaSource"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefMediaSource() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the ID (media source URN or URL) for this source.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_id)(struct _cef_media_source_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSource*, CefStringUserFree*> _GetId;

  /// <summary>
  /// Returns true (1) if this source outputs its content via Cast.
  /// <c>int(CEF_CALLBACK* is_cast_source)(struct _cef_media_source_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSource*, int> _IsCastSource;

  /// <summary>
  /// Returns true (1) if this source outputs its content via DIAL.
  /// <c>int(CEF_CALLBACK* is_dial_source)(struct _cef_media_source_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMediaSource*, int> _IsDialSource;

}
