namespace Cefaloid;

/// <summary>
/// Callback structure used for asynchronous continuation of
/// cef_extension_handler_t::GetExtensionResource.
/// <c>_cef_get_extension_resource_callback_t</c>
/// </summary>
/// <seealso cref="CefExtensionHandler"/>
/// <seealso cref="CefGetExtensionResourceCallbackExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefGetExtensionResourceCallback : ICefRefCountedBase<CefGetExtensionResourceCallback> {

  /// <see cref="CefGetExtensionResourceCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefGetExtensionResourceCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Continue the request. Read the resource contents from |stream|.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_get_extension_resource_callback_t* self, struct _cef_stream_reader_t* stream);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefGetExtensionResourceCallback*, CefStreamReader*, void> _Continue;

  /// <summary>
  /// Cancel the request.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_get_extension_resource_callback_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefGetExtensionResourceCallback*, void> _Cancel;

}
