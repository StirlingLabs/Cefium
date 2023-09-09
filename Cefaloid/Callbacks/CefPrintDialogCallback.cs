namespace Cefaloid;

/// <summary>
/// Callback structure for asynchronous continuation of print dialog requests.
/// <c>cef_print_dialog_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPrintDialogCallback : ICefRefCountedBase<CefPrintDialogCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefPrintDialogCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Continue printing with the specified |settings|.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_print_dialog_callback_t* self, struct _cef_print_settings_t* settings)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintDialogCallback*, CefPrintSettings*, void> _Continue;

  /// <summary>
  /// Cancel the printing.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_print_dialog_callback_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintDialogCallback*, void> _Cancel;

}
