namespace Cefaloid;

/// <summary>
/// Callback for asynchronous continuation of cef_resource_handler_t::read().
/// <c>cef_resource_read_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefResourceReadCallback : ICefRefCountedBase<CefResourceReadCallback> {

  /// <see cref="CefResourceReadCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefResourceReadCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Callback for asynchronous continuation of read(). If |bytes_read| == 0 the
  /// response will be considered complete. If |bytes_read| > 0 then read() will
  /// be called again until the request is complete (based on either the result
  /// or the expected content length). If |bytes_read| &lt; 0 then the request will
  /// fail and the |bytes_read| value will be treated as the error code.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_resource_read_callback_t* self, int bytes_read);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceReadCallback*, int, void> _Continue;

}
