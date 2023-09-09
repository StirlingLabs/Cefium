namespace Cefaloid;

/// <summary>
/// Callback structure for cef_browser_host_t::PrintToPDF. The functions of this
/// structure will be called on the browser process UI thread.
/// <c>cef_pdf_print_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPdfPrintCallback : ICefRefCountedBase<CefPdfPrintCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefPdfPrintCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be executed when the PDF printing has completed. |path|
  /// is the output path. |ok| will be true (1) if the printing completed
  /// successfully or false (0) otherwise.
  /// <c>void(CEF_CALLBACK* on_pdf_print_finished)(struct _cef_pdf_print_callback_t* self, const cef_string_t* path, int ok);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPdfPrintCallback*, CefString*, int, void> _OnPdfPrintFinished;

}
