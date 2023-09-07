namespace Cefaloid;

/// <summary>
/// Implement this structure to provide handler implementations. Methods will be
/// called by the process and/or thread indicated.
/// <c>cef_app_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefApp : ICefRefCountedBase<CefApp> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefApp() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// This function should be called from the application entry point function to
  /// execute a secondary process. It can be used to run secondary processes from
  /// the browser client executable (default behavior) or from a separate
  /// executable specified by the cef_settings_t.browser_subprocess_path value. If
  /// called for the browser process (identified by no "type" command-line value)
  /// it will return immediately with a value of -1. If called for a recognized
  /// secondary process it will block until the process should exit and then
  /// return the process exit code. The |application| parameter may be NULL. The
  /// |windows_sandbox_info| parameter is only used on Windows and may be NULL
  /// (see cef_sandbox_win.h for details).
  /// <c>CEF_EXPORT int cef_execute_process(const cef_main_args_t* args, cef_app_t* application, void* windows_sandbox_info);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_execute_process", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _ExecuteProcess(CefMainArgs* args, CefApp* application, void* sandboxInfo);

  /// <inheritdoc cref="_ExecuteProcess"/>
  public static unsafe int ExecuteProcess(ref CefMainArgs args, ref CefApp application, void* sandboxInfo)
    => _ExecuteProcess(args.AsPointer(), application.AsPointer(), sandboxInfo);

  /// <inheritdoc cref="_ExecuteProcess"/>
  public static unsafe int ExecuteProcess(ref CefMainArgs args, ref CefApp application)
    => _ExecuteProcess(args.AsPointer(), application.AsPointer(), null);

  /// <inheritdoc cref="_ExecuteProcess"/>
  public static unsafe int ExecuteProcess(ref CefMainArgs args, void* sandboxInfo)
    => _ExecuteProcess(args.AsPointer(), null, sandboxInfo);

  /// <inheritdoc cref="_ExecuteProcess"/>
  public static unsafe int ExecuteProcess(ref CefMainArgs args)
    => _ExecuteProcess(args.AsPointer(), null, null);

  /// <summary>
  /// This function should be called on the main application thread to initialize
  /// the CEF browser process. The |application| parameter may be NULL. A return
  /// value of true (1) indicates that it succeeded and false (0) indicates that
  /// it failed. The |windows_sandbox_info| parameter is only used on Windows and
  /// may be NULL (see cef_sandbox_win.h for details).
  /// <c>CEF_EXPORT int cef_initialize(const cef_main_args_t* args, const struct _cef_settings_t* settings, cef_app_t* application, void* windows_sandbox_info);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_initialize", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _Initialize(CefMainArgs* args, CefSettings* settings, CefApp* application, void* sandboxInfo);

  /// <inheritdoc cref="_Initialize"/>
  public static unsafe bool Initialize(ref CefMainArgs args, ref CefSettings settings, void* sandboxInfo = null)
    => _Initialize(args.AsPointer(), settings.AsPointer(), null, sandboxInfo) != 0;

  /// <summary>
  /// This function should be called on the main application thread to shut down
  /// the CEF browser process before the application exits.
  /// <c>CEF_EXPORT void cef_shutdown(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_shutdown", CallingConvention = CallingConvention.Cdecl)]
  public static extern void Shutdown();

  /// <summary>
  /// Perform a single iteration of CEF message loop processing. This function is
  /// provided for cases where the CEF message loop must be integrated into an
  /// existing application message loop. Use of this function is not recommended
  /// for most users; use either the cef_run_message_loop() function or
  /// cef_settings_t.multi_threaded_message_loop if possible. When using this
  /// function care must be taken to balance performance against excessive CPU
  /// usage. It is recommended to enable the cef_settings_t.external_message_pump
  /// option when using this function so that
  /// cef_browser_process_handler_t::on_schedule_message_pump_work() callbacks can
  /// facilitate the scheduling process. This function should only be called on
  /// the main application thread and only if cef_initialize() is called with a
  /// cef_settings_t.multi_threaded_message_loop value of false (0). This function
  /// will not block.
  /// <c>CEF_EXPORT void cef_do_message_loop_work(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_do_message_loop_work", CallingConvention = CallingConvention.Cdecl)]
  public static extern void DoMessageLoopWork();

  /// <summary>
  /// Run the CEF message loop. Use this function instead of an application-
  /// provided message loop to get the best balance between performance and CPU
  /// usage. This function should only be called on the main application thread
  /// and only if cef_initialize() is called with a
  /// cef_settings_t.multi_threaded_message_loop value of false (0). This function
  /// will block until a quit message is received by the system.
  /// <c>CEF_EXPORT void cef_run_message_loop(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_run_message_loop", CallingConvention = CallingConvention.Cdecl)]
  public static extern void RunMessageLoop();

  /// <summary>
  /// Quit the CEF message loop that was started by calling
  /// cef_run_message_loop(). This function should only be called on the main
  /// application thread and only if cef_run_message_loop() was used.
  /// <c>CEF_EXPORT void cef_quit_message_loop(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_quit_message_loop", CallingConvention = CallingConvention.Cdecl)]
  public static extern void QuitMessageLoop();

  /// <summary>
  /// Provides an opportunity to view and/or modify command-line arguments
  /// before processing by CEF and Chromium. The |process_type| value will be
  /// NULL for the browser process. Do not keep a reference to the
  /// cef_command_line_t object passed to this function. The
  /// cef_settings_t.command_line_args_disabled value can be used to start with
  /// an NULL command-line object. Any values specified in CefSettings that
  /// equate to command-line arguments will be set before this function is
  /// called. Be cautious when using this function to modify command-line
  /// arguments for non-browser processes as this may result in undefined
  /// behavior including crashes.
  /// <c>void(CEF_CALLBACK* on_before_command_line_processing)(struct _cef_app_t* self, const cef_string_t* process_type, struct _cef_command_line_t* command_line);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefApp*, CefString*, CefCommandLine*, void> OnBeforeCommandLineProcessing;

  /// <summary>
  /// Provides an opportunity to register custom schemes. Do not keep a
  /// reference to the |registrar| object. This function is called on the main
  /// thread for each process and the registered schemes should be the same
  /// across all processes.
  /// <c>void(CEF_CALLBACK* on_register_custom_schemes)(struct _cef_app_t* self, struct _cef_scheme_registrar_t* registrar);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefApp*, CefSchemeRegistrar*, void> OnRegisterCustomSchemes;

  /// <summary>
  /// Return the handler for resource bundle events. If
  /// cef_settings_t.pack_loading_disabled is true (1) a handler must be
  /// returned. If no handler is returned resources will be loaded from pack
  /// files. This function is called by the browser and render processes on
  /// multiple threads.
  /// <c>struct _cef_resource_bundle_handler_t*(CEF_CALLBACK* get_resource_bundle_handler)(struct _cef_app_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefApp*, CefResourceBundleHandler*> GetResourceBundleHandler;

  /// <summary>
  /// Return the handler for functionality specific to the browser process. This
  /// function is called on multiple threads in the browser process.
  /// <c>struct _cef_browser_process_handler_t*(CEF_CALLBACK* get_browser_process_handler)(struct _cef_app_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefApp*, CefBrowserProcessHandler*> GetBrowserProcessHandler;

  /// <summary>
  /// Return the handler for functionality specific to the render process. This
  /// function is called on the render process main thread.
  /// <c>struct _cef_render_process_handler_t*(CEF_CALLBACK* get_render_process_handler)(struct _cef_app_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefApp*, CefRenderProcessHandler*> GetRenderProcessHandler;

}
