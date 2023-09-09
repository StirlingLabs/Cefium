namespace Cefaloid;

/// <summary>
/// Callback structure for cef_request_context_t::ResolveHost.
/// <c>cef_resolve_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefResolveCallback : ICefRefCountedBase<CefResolveCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefResolveCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called on the UI thread after the ResolveHost request has completed.
  /// |result| will be the result code. |resolved_ips| will be the list of
  /// resolved IP addresses or NULL if the resolution failed.
  /// <c>void(CEF_CALLBACK* on_resolve_completed)(struct _cef_resolve_callback_t* self, cef_errorcode_t result, cef_string_list_t resolved_ips);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResolveCallback*, CefErrorCode, CefStringList*, void> _OnResolveCompleted;

}
