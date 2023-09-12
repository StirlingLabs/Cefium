namespace Cefaloid;

/// <summary>
/// Callback for asynchronous continuation of cef_resource_handler_t::skip().
/// <c>cef_resource_skip_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefResourceSkipCallback : ICefRefCountedBase<CefResourceSkipCallback> {

  /// <see cref="CefResourceSkipCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefResourceSkipCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Callback for asynchronous continuation of skip(). If |bytes_skipped| > 0
  /// then either skip() will be called again until the requested number of
  /// bytes have been skipped or the request will proceed. If |bytes_skipped| &lt;=
  /// 0 the request will fail with ERR_REQUEST_RANGE_NOT_SATISFIABLE.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_resource_skip_callback_t* self, int64 bytes_skipped);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceSkipCallback*, long, void> _Continue;

}
