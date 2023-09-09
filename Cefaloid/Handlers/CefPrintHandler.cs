namespace Cefaloid;

/// <summary>
/// Implement this structure to handle printing on Linux. Each browser will have
/// only one print job in progress at a time. The functions of this structure
/// will be called on the browser process UI thread.
/// <c>cef_print_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPrintHandler : ICefRefCountedBase<CefPrintHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefPrintHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called when printing has started for the specified |browser|. This
  /// function will be called before the other OnPrint*() functions and
  /// irrespective of how printing was initiated (e.g.
  /// cef_browser_host_t::print(), JavaScript window.print() or PDF extension
  /// print button).
  /// <c>void(CEF_CALLBACK* on_print_start)(struct _cef_print_handler_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintHandler*, CefBrowser*, void> _OnPrintStart;

  /// <summary>
  /// Synchronize |settings| with client state. If |get_defaults| is true (1)
  /// then populate |settings| with the default print settings. Do not keep a
  /// reference to |settings| outside of this callback.
  /// <c>void(CEF_CALLBACK* on_print_settings)(struct _cef_print_handler_t* self, struct _cef_browser_t* browser, struct _cef_print_settings_t* settings, int get_defaults)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintHandler*, CefBrowser*, CefPrintSettings*, int, void> _OnPrintSettings;

  /// <summary>
  /// Show the print dialog. Execute |callback| once the dialog is dismissed.
  /// Return true (1) if the dialog will be displayed or false (0) to cancel the
  /// printing immediately.
  /// <c>int(CEF_CALLBACK* on_print_dialog)(struct _cef_print_handler_t* self, struct _cef_browser_t* browser, int has_selection, struct _cef_print_dialog_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintHandler*, CefBrowser*, int, CefPrintDialogCallback*, int> _OnPrintDialog;

  /// <summary>
  /// Send the print job to the printer. Execute |callback| once the job is
  /// completed. Return true (1) if the job will proceed or false (0) to cancel
  /// the job immediately.
  /// <c>int(CEF_CALLBACK* on_print_job)(struct _cef_print_handler_t* self, struct _cef_browser_t* browser, const cef_string_t* document_name, const cef_string_t* pdf_file_path, struct _cef_print_job_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintHandler*, CefBrowser*, CefString*, CefString*, CefPrintJobCallback*, int> _OnPrintJob;

  /// <summary>
  /// Reset client state related to printing.
  /// <c>void(CEF_CALLBACK* on_print_reset)(struct _cef_print_handler_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintHandler*, CefBrowser*, void> _OnPrintReset;

  /// <summary>
  /// Return the PDF paper size in device units. Used in combination with
  /// cef_browser_host_t::print_to_pdf().
  /// <c>cef_size_t(CEF_CALLBACK* get_pdf_paper_size)(struct _cef_print_handler_t* self, struct _cef_browser_t* browser, int device_units_per_inch)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintHandler*, CefBrowser*, int, CefSize> _GetPdfPaperSize;

}
