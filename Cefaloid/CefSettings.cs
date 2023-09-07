namespace Cefaloid;

/// <summary>
/// Initialization settings. Specify NULL or 0 to get the recommended default
/// values. Many of these and other settings can also configured using command-
/// line switches.
/// <c>cef_settings_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSettings : ICefSizedStruct<CefSettings> {

  public CefSettings()
    => this.InitializeBase();

  /// <summary>
  /// Size of this structure.
  /// </summary>
  public nuint Size;

  /// <summary>
  /// Set to true (1) to disable the sandbox for sub-processes. See
  /// cef_sandbox_win.h for requirements to enable the sandbox on Windows. Also
  /// configurable using the "no-sandbox" command-line switch.
  /// </summary>
  private int _NoSandbox;

  /// <inheritdoc cref="_NoSandbox"/>
  public bool NoSandbox {
    get => _NoSandbox != 0;
    set => _NoSandbox = value ? 1 : 0;
  }

  /// <summary>
  /// The path to a separate executable that will be launched for sub-processes.
  /// If this value is empty on Windows or Linux then the main process
  /// executable will be used. If this value is empty on macOS then a helper
  /// executable must exist at "Contents/Frameworks/&lt;app&gt;
  /// Helper.app/Contents/MacOS/&lt;app&gt; Helper" in the top-level app bundle. See
  /// the comments on CefExecuteProcess() for details. If this value is
  /// non-empty then it must be an absolute path. Also configurable using the
  /// "browser-subprocess-path" command-line switch.
  /// </summary>
  public CefString BrowserSubprocessPath;

  /// <summary>
  /// The path to the CEF framework directory on macOS. If this value is empty
  /// then the framework must exist at "Contents/Frameworks/Chromium Embedded
  /// Framework.framework" in the top-level app bundle. If this value is
  /// non-empty then it must be an absolute path. Also configurable using the
  /// "framework-dir-path" command-line switch.
  /// </summary>
  public CefString FrameworkDirPath;

  /// <summary>
  /// The path to the main bundle on macOS. If this value is empty then it
  /// defaults to the top-level app bundle. If this value is non-empty then it
  /// must be an absolute path. Also configurable using the "main-bundle-path"
  /// command-line switch.
  /// </summary>
  public CefString MainBundlePath;

  /// <summary>
  /// Set to true (1) to enable use of the Chrome runtime in CEF. This feature
  /// is considered experimental and is not recommended for most users at this
  /// time. See issue #2969 for details.
  /// </summary>
  private int _ChromeRuntime;

  /// <inheritdoc cref="_ChromeRuntime"/>
  public bool ChromeRuntime {
    get => _ChromeRuntime != 0;
    set => _ChromeRuntime = value ? 1 : 0;
  }

  /// <summary>
  /// Set to true (1) to have the browser process message loop run in a separate
  /// thread. If false (0) then the CefDoMessageLoopWork() function must be
  /// called from your application message loop. This option is only supported
  /// on Windows and Linux.
  /// </summary>
  private int _MultiThreadedMessageLoop;

  /// <inheritdoc cref="_MultiThreadedMessageLoop"/>
  public bool MultiThreadedMessageLoop {
    get => _MultiThreadedMessageLoop != 0;
    set => _MultiThreadedMessageLoop = value ? 1 : 0;
  }

  /// <summary>
  /// Set to true (1) to control browser process main (UI) thread message pump
  /// scheduling via the CefBrowserProcessHandler::OnScheduleMessagePumpWork()
  /// callback. This option is recommended for use in combination with the
  /// CefDoMessageLoopWork() function in cases where the CEF message loop must
  /// be integrated into an existing application message loop (see additional
  /// comments and warnings on CefDoMessageLoopWork). Enabling this option is
  /// not recommended for most users; leave this option disabled and use either
  /// the CefRunMessageLoop() function or multi_threaded_message_loop if
  /// possible.
  /// </summary>
  private int _ExternalMessagePump;

  /// <inheritdoc cref="_ExternalMessagePump"/>
  public bool ExternalMessagePump {
    get => _ExternalMessagePump != 0;
    set => _ExternalMessagePump = value ? 1 : 0;
  }

  /// <summary>
  /// Set to true (1) to enable windowless (off-screen) rendering support. Do
  /// not enable this value if the application does not use windowless rendering
  /// as it may reduce rendering performance on some systems.
  /// </summary>
  private int _WindowlessRenderingEnabled;

  /// <inheritdoc cref="_WindowlessRenderingEnabled"/>
  public bool WindowlessRenderingEnabled {
    get => _WindowlessRenderingEnabled != 0;
    set => _WindowlessRenderingEnabled = value ? 1 : 0;
  }

  /// <summary>
  /// Set to true (1) to disable configuration of browser process features using
  /// standard CEF and Chromium command-line arguments. Configuration can still
  /// be specified using CEF data structures or via the
  /// CefApp::OnBeforeCommandLineProcessing() method.
  /// </summary>
  private int _CommandLineArgsDisabled;

  /// <inheritdoc cref="_CommandLineArgsDisabled"/>
  public bool CommandLineArgsDisabled {
    get => _CommandLineArgsDisabled != 0;
    set => _CommandLineArgsDisabled = value ? 1 : 0;
  }

  /// <summary>
  /// The location where data for the global browser cache will be stored on
  /// disk. If this value is non-empty then it must be an absolute path that is
  /// either equal to or a child directory of CefSettings.root_cache_path. If
  /// this value is empty then browsers will be created in "incognito mode"
  /// where in-memory caches are used for storage and no data is persisted to
  /// disk. HTML5 databases such as localStorage will only persist across
  /// sessions if a cache path is specified. Can be overridden for individual
  /// CefRequestContext instances via the CefRequestContextSettings.cache_path
  /// value. When using the Chrome runtime the "default" profile will be used if
  /// |cache_path| and |root_cache_path| have the same value.
  /// </summary>
  public CefString CachePath;

  /// <summary>
  /// The root directory that all CefSettings.cache_path and
  /// CefRequestContextSettings.cache_path values must have in common. If this
  /// value is empty and CefSettings.cache_path is non-empty then it will
  /// default to the CefSettings.cache_path value. If this value is non-empty
  /// then it must be an absolute path. Failure to set this value correctly may
  /// result in the sandbox blocking read/write access to the cache_path
  /// directory.
  /// </summary>
  public CefString RootCachePath;

  /// <summary>
  /// The location where user data such as the Widevine CDM module and spell
  /// checking dictionary files will be stored on disk. If this value is empty
  /// then the default platform-specific user data directory will be used
  /// ("~/.config/cef_user_data" directory on Linux, "~/Library/Application
  /// Support/CEF/User Data" directory on MacOS, "AppData\Local\CEF\User Data"
  /// directory under the user profile directory on Windows). If this value is
  /// non-empty then it must be an absolute path. When using the Chrome runtime
  /// this value will be ignored in favor of the |root_cache_path| value.
  /// </summary>
  public CefString UserDataPath;

  /// <summary>
  /// To persist session cookies (cookies without an expiry date or validity
  /// interval) by default when using the global cookie manager set this value
  /// to true (1). Session cookies are generally intended to be transient and
  /// most Web browsers do not persist them. A |cache_path| value must also be
  /// specified to enable this feature. Also configurable using the
  /// "persist-session-cookies" command-line switch. Can be overridden for
  /// individual CefRequestContext instances via the
  /// CefRequestContextSettings.persist_session_cookies value.
  /// </summary>
  private int _PersistSessionCookies;

  /// <inheritdoc cref="_PersistSessionCookies"/>
  public bool PersistSessionCookies {
    get => _PersistSessionCookies != 0;
    set => _PersistSessionCookies = value ? 1 : 0;
  }

  /// <summary>
  /// To persist user preferences as a JSON file in the cache path directory set
  /// this value to true (1). A |cache_path| value must also be specified
  /// to enable this feature. Also configurable using the
  /// "persist-user-preferences" command-line switch. Can be overridden for
  /// individual CefRequestContext instances via the
  /// CefRequestContextSettings.persist_user_preferences value.
  /// </summary>
  private int _PersistUserPreferences;

  /// <inheritdoc cref="_PersistUserPreferences"/>
  public bool PersistUserPreferences {
    get => _PersistUserPreferences != 0;
    set => _PersistUserPreferences = value ? 1 : 0;
  }

  /// <summary>
  /// Value that will be returned as the User-Agent HTTP header. If empty the
  /// default User-Agent string will be used. Also configurable using the
  /// "user-agent" command-line switch.
  /// </summary>
  public CefString UserAgent;

  /// <summary>
  /// Value that will be inserted as the product portion of the default
  /// User-Agent string. If empty the Chromium product version will be used. If
  /// |userAgent| is specified this value will be ignored. Also configurable
  /// using the "user-agent-product" command-line switch.
  /// </summary>
  public CefString UserAgentProduct;

  /// <summary>
  /// The locale string that will be passed to WebKit. If empty the default
  /// locale of "en-US" will be used. This value is ignored on Linux where
  /// locale is determined using environment variable parsing with the
  /// precedence order: LANGUAGE, LC_ALL, LC_MESSAGES and LANG. Also
  /// configurable using the "lang" command-line switch.
  /// </summary>
  public CefString Locale;

  /// <summary>
  /// The directory and file name to use for the debug log. If empty a default
  /// log file name and location will be used. On Windows and Linux a
  /// "debug.log" file will be written in the main executable directory. On
  /// MacOS a "~/Library/Logs/[app name]_debug.log" file will be written where
  /// [app name] is the name of the main app executable. Also configurable using
  /// the "log-file" command-line switch.
  /// </summary>
  public CefString LogFile;

  /// <summary>
  /// The log severity. Only messages of this severity level or higher will be
  /// logged. When set to DISABLE no messages will be written to the log file,
  /// but FATAL messages will still be output to stderr. Also configurable using
  /// the "log-severity" command-line switch with a value of "verbose", "info",
  /// "warning", "error", "fatal" or "disable".
  /// </summary>
  public CefLogSeverity LogSeverity;

  /// <summary>
  /// Custom flags that will be used when initializing the V8 JavaScript engine.
  /// The consequences of using custom flags may not be well tested. Also
  /// configurable using the "js-flags" command-line switch.
  /// </summary>
  public CefString JavascriptFlags;

  /// <summary>
  /// The fully qualified path for the resources directory. If this value is
  /// empty the *.pak files must be located in the module directory on
  /// Windows/Linux or the app bundle Resources directory on MacOS. If this
  /// value is non-empty then it must be an absolute path. Also configurable
  /// using the "resources-dir-path" command-line switch.
  /// </summary>
  public CefString ResourcesDirPath;

  /// <summary>
  /// The fully qualified path for the locales directory. If this value is empty
  /// the locales directory must be located in the module directory. If this
  /// value is non-empty then it must be an absolute path. This value is ignored
  /// on MacOS where pack files are always loaded from the app bundle Resources
  /// directory. Also configurable using the "locales-dir-path" command-line
  /// switch.
  /// </summary>
  public CefString LocalesDirPath;

  /// <summary>
  /// Set to true (1) to disable loading of pack files for resources and
  /// locales. A resource bundle handler must be provided for the browser and
  /// render processes via CefApp::GetResourceBundleHandler() if loading of pack
  /// files is disabled. Also configurable using the "disable-pack-loading"
  /// command- line switch.
  /// </summary>
  private int _PackLoadingDisabled;

  /// <inheritdoc cref="_PackLoadingDisabled"/>
  public bool PackLoadingDisabled {
    get => _PackLoadingDisabled != 0;
    set => _PackLoadingDisabled = value ? 1 : 0;
  }

  /// <summary>
  /// Set to a value between 1024 and 65535 to enable remote debugging on the
  /// specified port. Also configurable using the "remote-debugging-port"
  /// command-line switch. Remote debugging can be accessed by loading the
  /// chrome://inspect page in Google Chrome. Port numbers 9222 and 9229 are
  /// discoverable by default. Other port numbers may need to be configured via
  /// "Discover network targets" on the Devices tab.
  /// </summary>
  public int RemoteDebuggingPort;

  /// <summary>
  /// The number of stack trace frames to capture for uncaught exceptions.
  /// Specify a positive value to enable the
  /// CefRenderProcessHandler::OnUncaughtException() callback. Specify 0
  /// (default value) and OnUncaughtException() will not be called. Also
  /// configurable using the "uncaught-exception-stack-size" command-line
  /// switch.
  /// </summary>
  public int UncaughtExceptionStackSize;

  /// <summary>
  /// Background color used for the browser before a document is loaded and when
  /// no document color is specified. The alpha component must be either fully
  /// opaque (0xFF) or fully transparent (0x00). If the alpha component is fully
  /// opaque then the RGB components will be used as the background color. If
  /// the alpha component is fully transparent for a windowed browser then the
  /// default value of opaque white be used. If the alpha component is fully
  /// transparent for a windowless (off-screen) browser then transparent
  /// painting will be enabled.
  /// </summary>
  public CefColor BackgroundColor;

  /// <summary>
  /// Comma delimited ordered list of language codes without any whitespace that
  /// will be used in the "Accept-Language" HTTP header. May be overridden on a
  /// per-browser basis using the CefBrowserSettings.accept_language_list value.
  /// If both values are empty then "en-US,en" will be used. Can be overridden
  /// for individual CefRequestContext instances via the
  /// CefRequestContextSettings.accept_language_list value.
  /// </summary>
  public CefString AcceptLanguageList;

  /// <summary>
  /// Comma delimited list of schemes supported by the associated
  /// CefCookieManager. If |cookieable_schemes_exclude_defaults| is false (0)
  /// the default schemes ("http", "https", "ws" and "wss") will also be
  /// supported. Not specifying a |cookieable_schemes_list| value and setting
  /// |cookieable_schemes_exclude_defaults| to true (1) will disable all loading
  /// and saving of cookies. These settings will only impact the global
  /// CefRequestContext. Individual CefRequestContext instances can be
  /// configured via the CefRequestContextSettings.cookieable_schemes_list and
  /// CefRequestContextSettings.cookieable_schemes_exclude_defaults values.
  /// </summary>
  public CefString CookieableSchemesList;

  private int _CookieableSchemesExcludeDefaults;

  /// <inheritdoc cref="_CookieableSchemesExcludeDefaults"/>
  public bool CookieableSchemesExcludeDefaults {
    get => _CookieableSchemesExcludeDefaults != 0;
    set => _CookieableSchemesExcludeDefaults = value ? 1 : 0;
  }

}
