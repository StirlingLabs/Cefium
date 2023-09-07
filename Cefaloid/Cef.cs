using System.Runtime.Versioning;

namespace Cefaloid;

/// <summary>
/// Externally visible symbols that are not associated with a specific structure.
/// Mostly contains startup/shutdown/registration/global scope functions.
/// </summary>
[PublicAPI]
public static class Cef {

  /// <summary>
  /// Launches the process specified via |command_line|. Returns true (1) upon
  /// success. Must be called on the browser process TID_PROCESS_LAUNCHER thread.
  ///
  /// Unix-specific notes: - All file descriptors open in the parent process will
  /// be closed in the
  ///   child process except for stdin, stdout, and stderr.
  /// - If the first argument on the command line does not contain a slash,
  ///   PATH will be searched. (See man execvp.)
  /// CEF_EXPORT int cef_launch_process(struct _cef_command_line_t* command_line);
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_launch_process", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe int _LaunchProcess(CefCommandLine* commandLine);

  /// <inheritdoc cref="_LaunchProcess"/>
  public static unsafe bool LaunchProcess(ref CefCommandLine commandLine)
    => _LaunchProcess(commandLine.AsPointer()) != 0;

  /// <summary>
  /// Register a new V8 extension with the specified JavaScript extension code and
  /// handler. Functions implemented by the handler are prototyped using the
  /// keyword 'native'. The calling of a native function is restricted to the
  /// scope in which the prototype of the native function is defined. This
  /// function may only be called on the render process main thread.
  ///
  /// Example JavaScript extension code: <pre>
  ///   // create the 'example' global object if it doesn't already exist.
  ///   if (!example)
  ///     example = {};
  ///   // create the 'example.test' global object if it doesn't already exist.
  ///   if (!example.test)
  ///     example.test = {};
  ///   (function() {
  ///     // Define the function 'example.test.myfunction'.
  ///     example.test.myfunction = function() {
  ///       // Call CefV8Handler::Execute() with the function name 'MyFunction'
  ///       // and no arguments.
  ///       native function MyFunction();
  ///       return MyFunction();
  ///     };
  ///     // Define the getter function for parameter 'example.test.myparam'.
  ///     example.test.__defineGetter__('myparam', function() {
  ///       // Call CefV8Handler::Execute() with the function name 'GetMyParam'
  ///       // and no arguments.
  ///       native function GetMyParam();
  ///       return GetMyParam();
  ///     });
  ///     // Define the setter function for parameter 'example.test.myparam'.
  ///     example.test.__defineSetter__('myparam', function(b) {
  ///       // Call CefV8Handler::Execute() with the function name 'SetMyParam'
  ///       // and a single argument.
  ///       native function SetMyParam();
  ///       if(b) SetMyParam(b);
  ///     });
  ///
  ///     // Extension definitions can also contain normal JavaScript variables
  ///     // and functions.
  ///     var myint = 0;
  ///     example.test.increment = function() {
  ///       myint += 1;
  ///       return myint;
  ///     };
  ///   })();
  /// </pre>
  ///
  /// Example usage in the page: <pre>
  ///   // Call the function.
  ///   example.test.myfunction();
  ///   // Set the parameter.
  ///   example.test.myparam = value;
  ///   // Get the parameter.
  ///   value = example.test.myparam;
  ///   // Call another function.
  ///   example.test.increment();
  /// </pre>
  /// <c>CEF_EXPORT int cef_register_extension(const cef_string_t* extension_name, const cef_string_t* javascript_code, cef_v8handler_t* handler);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_register_extension", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe int _RegisterExtension(CefString* extensionName, CefString* javascriptCode, CefV8Handler* handler);

  /// <inheritdoc cref="_RegisterExtension"/>
  public static unsafe bool RegisterExtension(ref CefString extensionName, ref CefString javascriptCode, ref CefV8Handler handler)
    => _RegisterExtension(extensionName.AsPointer(), javascriptCode.AsPointer(), handler.AsPointer()) != 0;

  /// <summary>
  /// Start tracing events on all processes. Tracing is initialized asynchronously
  /// and |callback| will be executed on the UI thread after initialization is
  /// complete.
  ///
  /// If CefBeginTracing was called previously, or if a CefEndTracingAsync call is
  /// pending, CefBeginTracing will fail and return false (0).
  ///
  /// |categories| is a comma-delimited list of category wildcards. A category can
  /// have an optional '-' prefix to make it an excluded category. Having both
  /// included and excluded categories in the same list is not supported.
  ///
  /// Examples: - "test_MyTest*" - "test_MyTest*,test_OtherStuff" -
  /// "-excluded_category1,-excluded_category2"
  ///
  /// This function must be called on the browser process UI thread.
  /// <c>CEF_EXPORT int cef_begin_tracing(const cef_string_t* categories, struct _cef_completion_callback_t* callback);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_begin_tracing", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe int _BeginTracing(CefString* categories, CefCompletionCallback* callback);

  /// <inheritdoc cref="_BeginTracing"/>
  public static unsafe bool BeginTracing(ref CefString categories, ref CefCompletionCallback callback)
    => _BeginTracing(categories.AsPointer(), callback.AsPointer()) != 0;

  /// <summary>
  /// Stop tracing events on all processes.
  ///
  /// This function will fail and return false (0) if a previous call to
  /// CefEndTracingAsync is already pending or if CefBeginTracing was not called.
  ///
  /// |tracing_file| is the path at which tracing data will be written and
  /// |callback| is the callback that will be executed once all processes have
  /// sent their trace data. If |tracing_file| is NULL a new temporary file path
  /// will be used. If |callback| is NULL no trace data will be written.
  ///
  /// This function must be called on the browser process UI thread.
  /// <c>CEF_EXPORT int cef_end_tracing(const cef_string_t* tracing_file, cef_end_tracing_callback_t* callback);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_end_tracing", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe int _EndTracing(CefString* tracingFile, CefEndTracingCallback* callback);

  /// <inheritdoc cref="_EndTracing"/>
  public static unsafe bool EndTracing(ref CefString tracingFile, ref CefEndTracingCallback callback)
    => _EndTracing(tracingFile.AsPointer(), callback.AsPointer()) != 0;

  /// <summary>
  /// Returns the current system trace time or, if none is defined, the current
  /// high-res time. Can be used by clients to synchronize with the time
  /// information in trace events.
  /// <c>CEF_EXPORT int64 cef_now_from_system_trace_time(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_now_from_system_trace_time", CallingConvention = CallingConvention.Cdecl)]
  public static extern long NowFromSystemTraceTime();

  /// <summary>
  /// Call during process startup to enable High-DPI support on Windows 7 or
  /// newer. Older versions of Windows should be left DPI-unaware because they do
  /// not support DirectWrite and GDI fonts are kerned very badly.
  /// <c>CEF_EXPORT void cef_enable_highdpi_support(void);</c>
  /// </summary>
  [SupportedOSPlatform("windows")]
  [DllImport("cef", EntryPoint = "cef_enable_highdpi_support", CallingConvention = CallingConvention.Cdecl)]
  public static extern void EnableHighDpiSupportForWindows();

  /// <summary>
  /// Set to true (1) before calling Windows APIs like TrackPopupMenu that enter a
  /// modal message loop. Set to false (0) after exiting the modal message loop.
  /// <c>CEF_EXPORT void cef_set_osmodal_loop(int osModalLoop);</c>
  /// </summary>
  [SupportedOSPlatform("windows")]
  [DllImport("cef", EntryPoint = "cef_set_osmodal_loop", CallingConvention = CallingConvention.Cdecl)]
  private static extern void SetOsModalLoopForWindows(int osModalLoop);

  /// <inheritdoc cref="SetOsModalLoopForWindows"/>
  [SupportedOSPlatform("windows")]
  public static void SetOsModalLoopForWindows(bool osModalLoop)
    => SetOsModalLoopForWindows(osModalLoop ? 1 : 0);

  /// <summary>
  /// Run the main thread on 32-bit Windows using a fiber with the preferred 4MiB
  /// stack size. This function must be called at the top of the executable entry
  /// point function (`main()` or `wWinMain()`). It is used in combination with
  /// the initial stack size of 0.5MiB configured via the `/STACK:0x80000` linker
  /// flag on executable targets. This saves significant memory on threads (like
  /// those in the Windows thread pool, and others) whose stack size can only be
  /// controlled via the linker flag.
  ///
  /// CEF's main thread needs at least a 1.5 MiB stack size in order to avoid
  /// stack overflow crashes. However, if this is set in the PE file then other
  /// threads get this size as well, leading to address-space exhaustion in 32-bit
  /// CEF. This function uses fibers to switch the main thread to a 4 MiB stack
  /// (roughly the same effective size as the 64-bit build's 8 MiB stack) before
  /// running any other code.
  ///
  /// Choose the function variant that matches the entry point function type used
  /// by the executable. Reusing the entry point minimizes confusion when
  /// examining call stacks in crash reports.
  ///
  /// If this function is already running on the fiber it will return -1
  /// immediately, meaning that execution should proceed with the remainder of the
  /// entry point function. Otherwise, this function will block until the entry
  /// point function has completed execution on the fiber and then return a result
  /// >= 0, meaning that the entry point function should return the result
  /// immediately without proceeding with execution.
  /// <c>CEF_EXPORT int cef_run_winmain_with_preferred_stack_size(wWinMainPtr wWinMain, HINSTANCE hInstance, LPWSTR lpCmdLine, int nCmdShow);</c>
  /// <c>CEF_EXPORT int cef_run_main_with_preferred_stack_size(mainPtr main, int argc, char* argv[]);</c>
  /// </summary>
  /// <seealso cref="RunWinMainWithPreferredStackSize"/>
  /// <seealso cref="RunMainWithPreferredStackSize"/>
  [SupportedOSPlatform("windows")]
  [DllImport("cef", EntryPoint = "cef_run_winmain_with_preferred_stack_size", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe int RunWinMainWithPreferredStackSize(nint wWinMain, nint hInstance, char* lpCmdLine, int nCmdShow);

  /// <inheritdoc cref="RunWinMainWithPreferredStackSize"/>
  [SupportedOSPlatform("windows")]
  [DllImport("cef", EntryPoint = "cef_run_main_with_preferred_stack_size", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe int RunMainWithPreferredStackSize(nint main, int argc, char** argv);

  /// <summary>
  /// Creates a new instance of a CEF ref counted object.
  /// The object is created on the heap (it is unmanaged) and
  /// is deleted when all references to it are released.
  ///
  /// The CefRef class is a wrapper around the unmanaged object
  /// accounts for one reference to the object while CEF internally
  /// accounts for any other references.
  /// </summary>
  public static CefRef<T> New<T>() where T : unmanaged, ICefRefCountedBase<T> {
    var r = T.New();
    r.Target.AddRef();
    return r;
  }

}
