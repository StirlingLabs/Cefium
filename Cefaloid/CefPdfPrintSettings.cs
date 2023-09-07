namespace Cefaloid;

/// <summary>
/// Structure representing PDF print settings. These values match the parameters
/// supported by the DevTools Page.printToPDF function. See
/// https://chromedevtools.github.io/devtools-protocol/tot/Page/#method-printToPDF
/// <c>cef_pdf_print_settings_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPdfPrintSettings {

  /// <summary>
  /// Set to true (1) for landscape mode or false (0) for portrait mode.
  /// </summary>
  private int _Landscape;

  /// <inheritdoc cref="_Landscape"/>
  public bool Landscape {
    get => _Landscape != 0;
    set => _Landscape = value ? 1 : 0;
  }

  /// <summary>
  /// Set to true (1) to print background graphics.
  /// </summary>
  private int _PrintBackground;

  /// <inheritdoc cref="_PrintBackground"/>
  public bool PrintBackground {
    get => _PrintBackground != 0;
    set => _PrintBackground = value ? 1 : 0;
  }

  /// <summary>
  /// The percentage to scale the PDF by before printing (e.g. .5 is 50%).
  /// If this value is less than or equal to zero the default value of 1.0
  /// will be used.
  /// </summary>
  public double Scale;

  /// <summary>
  /// Output paper width in inches. If less than or
  /// equal to zero then the default paper size (letter, 8.5 x 11 inches) will
  /// be used.
  /// </summary>
  public double PaperWidth;

  /// <summary>
  /// Output paper height in inches. If less than or
  /// equal to zero then the default paper size (letter, 8.5 x 11 inches) will
  /// be used.
  /// </summary>
  public double PaperHeight;

  /// <summary>
  /// Set to true (1) to prefer page size as defined by css. Defaults to false
  /// (0), in which case the content will be scaled to fit the paper size.
  /// </summary>
  private int _PreferCssPageSize;

  /// <inheritdoc cref="_PreferCssPageSize"/>
  public bool PreferCssPageSize {
    get => _PreferCssPageSize != 0;
    set => _PreferCssPageSize = value ? 1 : 0;
  }

  /// <summary>
  /// Margin type.
  /// </summary>
  public CefPdfPrintMarginType MarginType;

  /// <summary>
  /// Margins in inches. Only used if |margin_type| is set to
  /// PDF_PRINT_MARGIN_CUSTOM.
  /// </summary>
  public double MarginTop;

  /// <summary>
  /// Margins in inches. Only used if |margin_type| is set to
  /// PDF_PRINT_MARGIN_CUSTOM.
  /// </summary>
  public double MarginRight;

  /// <summary>
  /// Margins in inches. Only used if |margin_type| is set to
  /// PDF_PRINT_MARGIN_CUSTOM.
  /// </summary>
  public double MarginBottom;

  /// <summary>
  /// Margins in inches. Only used if |margin_type| is set to
  /// PDF_PRINT_MARGIN_CUSTOM.
  /// </summary>
  public double MarginLeft;

  /// <summary>
  /// Paper ranges to print, one based, e.g., '1-5, 8, 11-13'. Pages are printed
  /// in the document order, not in the order specified, and no more than once.
  /// Defaults to empty string, which implies the entire document is printed.
  /// The page numbers are quietly capped to actual page count of the document,
  /// and ranges beyond the end of the document are ignored. If this results in
  /// no pages to print, an error is reported. It is an error to specify a range
  /// with start greater than end.
  /// </summary>
  public CefString PageRanges;

  /// <summary>
  /// Set to true (1) to display the header and/or footer. Modify
  /// |header_template| and/or |footer_template| to customize the display.
  /// </summary>
  private int _DisplayHeaderFooter;

  /// <inheritdoc cref="_DisplayHeaderFooter"/>
  public bool DisplayHeaderFooter {
    get => _DisplayHeaderFooter != 0;
    set => _DisplayHeaderFooter = value ? 1 : 0;
  }

  /// <summary>
  /// HTML template for the print header. Only displayed if
  /// |display_header_footer| is true (1). Should be valid HTML markup with
  /// the following classes used to inject printing values into them:
  ///
  /// - date: formatted print date
  /// - title: document title
  /// - url: document location
  /// - pageNumber: current page number
  /// - totalPages: total pages in the document
  ///
  /// For example, "&lt;span class=title&gt;&lt;/span&gt;" would generate a span containing
  /// the title.
  /// </summary>
  public CefString HeaderTemplate;

  /// <summary>
  /// HTML template for the print footer. Only displayed if
  /// |display_header_footer| is true (1). Uses the same format as
  /// |header_template|.
  /// </summary>
  public CefString FooterTemplate;

}
