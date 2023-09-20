namespace Cefium;

/// <summary>
/// Structure used to implement browser process callbacks. The functions of this
/// structure will be called on the browser process main thread unless otherwise
/// indicated.
/// <c>cef_browser_process_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefBrowserProcessHandler : ICefRefCountedBase<CefBrowserProcessHandler> {

  /// <inheritdoc cref="CefBrowserProcessHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefBrowserProcessHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Provides an opportunity to register custom preferences prior to global and
  /// request context initialization.
  ///
  /// If |type| is CEF_PREFERENCES_TYPE_GLOBAL the registered preferences can be
  /// accessed via cef_preference_manager_t::GetGlobalPreferences after
  /// OnContextInitialized is called. Global preferences are registered a single
  /// time at application startup. See related cef_settings_t.cache_path and
  /// cef_settings_t.persist_user_preferences configuration.
  ///
  /// If |type| is CEF_PREFERENCES_TYPE_REQUEST_CONTEXT the preferences can be
  /// accessed via the cef_request_context_t after
  /// cef_request_context_handler_t::OnRequestContextInitialized is called.
  /// Request context preferences are registered each time a new
  /// cef_request_context_t is created. It is intended but not required that all
  /// request contexts have the same registered preferences. See related
  /// cef_request_context_settings_t.cache_path and
  /// cef_request_context_settings_t.persist_user_preferences configuration.
  ///
  /// Do not keep a reference to the |registrar| object. This function is called
  /// on the browser process UI thread.
  /// <c>void(CEF_CALLBACK* on_register_custom_preferences)(struct _cef_browser_process_handler_t* self, cef_preferences_type_t type, struct _cef_preference_registrar_t* registrar);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserProcessHandler*, CefPreferencesType, CefPreferenceRegistrar*, void> _OnRegisterCustomPreferences;

  /// <summary>
  /// Called on the browser process UI thread immediately after the CEF context
  /// has been initialized.
  /// <c>void(CEF_CALLBACK* on_context_initialized)(struct _cef_browser_process_handler_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserProcessHandler*, void> _OnContextInitialized;

  /// <summary>
  /// Called before a child process is launched. Will be called on the browser
  /// process UI thread when launching a render process and on the browser
  /// process IO thread when launching a GPU process. Provides an opportunity to
  /// modify the child process command line. Do not keep a reference to
  /// |command_line| outside of this function.
  /// <c>void(CEF_CALLBACK* on_before_child_process_launch)(struct _cef_browser_process_handler_t* self, struct _cef_command_line_t* command_line);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserProcessHandler*, CefCommandLine*, void> _OnBeforeChildProcessLaunch;

  /// <summary>
  /// Called from any thread when work has been scheduled for the browser
  /// process main (UI) thread. This callback is used in combination with
  /// cef_settings_t.external_message_pump and cef_do_message_loop_work() in
  /// cases where the CEF message loop must be integrated into an existing
  /// application message loop (see additional comments and warnings on
  /// CefDoMessageLoopWork). This callback should schedule a
  /// cef_do_message_loop_work() call to happen on the main (UI) thread.
  /// |delay_ms| is the requested delay in milliseconds. If |delay_ms| is &amp;lt;= 0
  /// then the call should happen reasonably soon. If |delay_ms| is > 0 then the
  /// call should be scheduled to happen after the specified delay and any
  /// currently pending scheduled call should be cancelled.
  /// <c>void(CEF_CALLBACK* on_schedule_message_pump_work)(struct _cef_browser_process_handler_t* self, int64 delay_ms);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserProcessHandler*, long, void> _OnScheduleMessagePumpWork;

  /// <summary>
  /// Return the default client for use with a newly created browser window. If
  /// null is returned the browser will be unmanaged (no callbacks will be
  /// executed for that browser) and application shutdown will be blocked until
  /// the browser window is closed manually. This function is currently only
  /// used with the chrome runtime.
  /// <c>struct _cef_client_t*(CEF_CALLBACK* get_default_client)(struct _cef_browser_process_handler_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBrowserProcessHandler*, CefClient*> _GetDefaultClient;

}
