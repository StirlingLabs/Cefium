namespace Cefaloid;

/// <summary>
/// Margin type for PDF printing.
/// <c>cef_pdf_print_margin_type_t</c>
/// </summary>
[PublicAPI]
public enum CefPdfPrintMarginType {

  /// <summary>
  /// Default margins of 1cm (~0.4 inches).
  /// <c>PDF_PRINT_MARGIN_DEFAULT</c>
  /// </summary>
  Default,

  /// <summary>
  /// No margins.
  /// <c>PDF_PRINT_MARGIN_NONE</c>
  /// </summary>
  None,

  /// <summary>
  /// Custom margins using the |margin_*| values from cef_pdf_print_settings_t.
  /// <c>PDF_PRINT_MARGIN_CUSTOM</c>
  /// </summary>
  Custom,

}
