namespace Cefaloid;

/// <summary>
/// Generic callback structure used for asynchronous continuation.
/// <c>cef_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCallback : ICefRefCountedBase<CefCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Continue processing.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_callback_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCallback*, void> _Continue;

  /// <summary>
  /// Cancel processing.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_callback_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCallback*, void> _Cancel;

}
