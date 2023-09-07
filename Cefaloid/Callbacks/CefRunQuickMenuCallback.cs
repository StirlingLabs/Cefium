namespace Cefaloid;

/// <summary>
/// Callback structure used for continuation of custom quick menu display.
/// <c>cef_run_quick_menu_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRunQuickMenuCallback : ICefRefCountedBase<CefRunQuickMenuCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefRunQuickMenuCallback() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Complete quick menu display by selecting the specified |command_id| and
  /// |event_flags|.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_run_quick_menu_callback_t* self, int command_id, cef_event_flags_t event_flags);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRunQuickMenuCallback*, int, CefEventFlags, void> _Continue;

  /// <summary>
  /// Cancel quick menu display.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_run_quick_menu_callback_t* self);</c>
  ///</summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRunQuickMenuCallback*, void> _Cancel;

}
