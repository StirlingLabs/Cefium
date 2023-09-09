namespace Cefaloid;

/// <summary>
/// Callback structure that is passed to cef_v8value_t::CreateArrayBuffer.
/// <c>cef_v8array_buffer_release_callback_t</c>
/// </summary>
/// <seealso cref="CefV8ArrayBufferReleaseCallbackExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefV8ArrayBufferReleaseCallback : ICefRefCountedBase<CefV8ArrayBufferReleaseCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefV8ArrayBufferReleaseCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called to release |buffer| when the ArrayBuffer JS object is garbage
  /// collected. |buffer| is the value that was passed to CreateArrayBuffer
  /// along with this object.
  /// <c>void(CEF_CALLBACK* release_buffer)(struct _cef_v8array_buffer_release_callback_t* self, void* buffer);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8ArrayBufferReleaseCallback*, void*, void> _ReleaseBuffer;

}
