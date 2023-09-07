namespace Cefaloid;

/// <summary>
/// Browser initialization settings. Specify NULL or 0 to get the recommended
/// default values. The consequences of using custom values may not be well
/// tested. Many of these and other settings can also configured using command-
/// line switches.
/// <c>cef_browser_settings_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefBrowserSettings : ICefSizedStruct<CefBrowserSettings> {

  public CefBrowserSettings()
    => this.InitializeBase();

  /// <summary>
  /// Size of this structure.
  /// </summary>
  public nuint Size;

  /// <summary>
  /// The maximum rate in frames per second (fps) that CefRenderHandler::OnPaint
  /// will be called for a windowless browser. The actual fps may be lower if
  /// the browser cannot generate frames at the requested rate. The minimum
  /// value is 1 and the maximum value is 60 (default 30). This value can also
  /// be changed dynamically via CefBrowserHost::SetWindowlessFrameRate.
  /// </summary>
  public int WindowlessFrameRate;

  // BEGIN values that map to WebPreferences settings.

  public CefString StandardFontFamily;

  public CefString FixedFontFamily;

  public CefString SerifFontFamily;

  public CefString SansSerifFontFamily;

  public CefString CursiveFontFamily;

  public CefString FantasyFontFamily;

  public int DefaultFontSize;

  public int DefaultFixedFontSize;

  public int MinimumFontSize;

  public int MinimumLogicalFontSize;

  /// <summary>
  /// Default encoding for Web content. If empty "ISO-8859-1" will be used. Also
  /// configurable using the "default-encoding" command-line switch.
  /// </summary>
  public CefString DefaultEncoding;

  /// <summary>
  /// Controls the loading of fonts from remote sources. Also configurable using
  /// the "disable-remote-fonts" command-line switch.
  /// </summary>
  public CefState EnableRemoteFonts;

  /// <summary>
  /// Controls whether JavaScript can be executed. Also configurable using the
  /// "disable-javascript" command-line switch.
  /// </summary>
  public CefState EnableJavascript;

  /// <summary>
  /// Controls whether JavaScript can be used to close windows that were not
  /// opened via JavaScript. JavaScript can still be used to close windows that
  /// were opened via JavaScript or that have no back/forward history. Also
  /// configurable using the "disable-javascript-close-windows" command-line
  /// switch.
  /// </summary>
  public CefState EnableJavascriptCloseWindows;

  /// <summary>
  /// Controls whether JavaScript can access the clipboard. Also configurable
  /// using the "disable-javascript-access-clipboard" command-line switch.
  /// </summary>
  public CefState EnableJavascriptAccessClipboard;

  /// <summary>
  /// Controls whether DOM pasting is supported in the editor via
  /// execCommand("paste"). The |javascript_access_clipboard| setting must also
  /// be enabled. Also configurable using the "disable-javascript-dom-paste"
  /// command-line switch.
  /// </summary>
  public CefState EnableJavascriptDomPaste;

  /// <summary>
  /// Controls whether image URLs will be loaded from the network. A cached
  /// image will still be rendered if requested. Also configurable using the
  /// "disable-image-loading" command-line switch.
  /// </summary>
  public CefState EnableImageLoading;

  /// <summary>
  /// Controls whether standalone images will be shrunk to fit the page. Also
  /// configurable using the "image-shrink-standalone-to-fit" command-line
  /// switch.
  /// </summary>
  public CefState EnableImageShrinkStandaloneToFit;

  /// <summary>
  /// Controls whether text areas can be resized. Also configurable using the
  /// "disable-text-area-resize" command-line switch.
  /// </summary>
  public CefState EnableTextAreaResize;

  /// <summary>
  /// Controls whether the tab key can advance focus to links. Also configurable
  /// using the "disable-tab-to-links" command-line switch.
  /// </summary>
  public CefState EnableTabToLinks;

  /// <summary>
  /// Controls whether local storage can be used. Also configurable using the
  /// "disable-local-storage" command-line switch.
  /// </summary>
  public CefState EnableLocalStorage;

  /// <summary>
  /// Controls whether databases can be used. Also configurable using the
  /// "disable-databases" command-line switch.
  /// </summary>
  public CefState EnableDatabases;

  /// <summary>
  /// Controls whether WebGL can be used. Note that WebGL requires hardware
  /// support and may not work on all systems even when enabled. Also
  /// configurable using the "disable-webgl" command-line switch.
  /// </summary>
  public CefState EnableWebGL;

  // END values that map to WebPreferences settings.

  /// <summary>
  /// Background color used for the browser before a document is loaded and when
  /// no document color is specified. The alpha component must be either fully
  /// opaque (0xFF) or fully transparent (0x00). If the alpha component is fully
  /// opaque then the RGB components will be used as the background color. If
  /// the alpha component is fully transparent for a windowed browser then the
  /// CefSettings.background_color value will be used. If the alpha component is
  /// fully transparent for a windowless (off-screen) browser then transparent
  /// painting will be enabled.
  /// </summary>
  public CefColor BackgroundColor;

  /// <summary>
  /// Comma delimited ordered list of language codes without any whitespace that
  /// will be used in the "Accept-Language" HTTP header. May be set globally
  /// using the CefSettings.accept_language_list value. If both values are
  /// empty then "en-US,en" will be used.
  /// </summary>
  public CefString AcceptLanguageList;

  /// <summary>
  /// Controls whether the Chrome status bubble will be used. Only supported
  /// with the Chrome runtime. For details about the status bubble see
  /// https://www.chromium.org/user-experience/status-bubble/
  /// </summary>
  public CefState EnableChromeStatusBubble;

}
