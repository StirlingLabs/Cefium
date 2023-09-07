namespace Cefaloid;

/// <summary>
/// Existing thread IDs.
/// <c>cef_thread_id_t</c>
/// </summary>
/// <seealso cref="CefThreadIdExtensions"/>
[PublicAPI]
public enum CefThreadId {

  /// <summary>
  /// The main thread in the browser. This will be the same as the main
  /// application thread if CefInitialize() is called with a
  /// CefSettings.multi_threaded_message_loop value of false. Do not perform
  /// blocking tasks on this thread. All tasks posted after
  /// CefBrowserProcessHandler::OnContextInitialized() and before CefShutdown()
  /// are guaranteed to run. This thread will outlive all other CEF threads.
  /// <c>TID_UI</c>
  /// </summary>
  /// <remarks>Only available in the browser process.</remarks>
  Ui = 0,

  /// <summary>
  /// Used for blocking tasks like file system access where the user won't
  /// notice if the task takes an arbitrarily long time to complete. All tasks
  /// posted after CefBrowserProcessHandler::OnContextInitialized() and before
  /// CefShutdown() are guaranteed to run.
  /// <c>TID_IO</c>
  /// </summary>
  /// <remarks>Only available in the browser process.</remarks>
  FileBackground,

  /// <summary>
  /// Used for blocking tasks like file system access that affect UI or
  /// responsiveness of future user interactions. Do not use if an immediate
  /// response to a user interaction is expected. All tasks posted after
  /// CefBrowserProcessHandler::OnContextInitialized() and before CefShutdown()
  /// are guaranteed to run.
  /// Examples:
  /// - Updating the UI to reflect progress on a long task.
  /// - Loading data that might be shown in the UI after a future user
  ///   interaction.
  /// <c>TID_FILE_USER_VISIBLE</c>
  /// </summary>
  /// <remarks>Only available in the browser process.</remarks>
  FileUserVisible,

  /// <summary>
  /// Used for blocking tasks like file system access that affect UI
  /// immediately after a user interaction. All tasks posted after
  /// CefBrowserProcessHandler::OnContextInitialized() and before CefShutdown()
  /// are guaranteed to run.
  /// Example: Generating data shown in the UI immediately after a click.
  /// <c>TID_FILE_USER_BLOCKING</c>
  /// </summary>
  /// <remarks>Only available in the browser process.</remarks>
  FileUserBlocking,

  /// <summary>
  /// Used to launch and terminate browser processes.
  /// <c>TID_PROCESS_LAUNCHER</c>
  /// </summary>
  /// <remarks>Only available in the browser process.</remarks>
  ProcessLauncher,

  /// <summary>
  /// Used to process IPC and network messages. Do not perform blocking tasks on
  /// this thread. All tasks posted after
  /// CefBrowserProcessHandler::OnContextInitialized() and before CefShutdown()
  /// are guaranteed to run.
  /// <c>TID_IO</c>
  /// </summary>
  /// <remarks>Only available in the browser process.</remarks>
  Io,

  /// <summary>
  /// The main thread in the renderer. Used for all WebKit and V8 interaction.
  /// Tasks may be posted to this thread after
  /// CefRenderProcessHandler::OnWebKitInitialized but are not guaranteed to
  /// run before sub-process termination (sub-processes may be killed at any
  /// time without warning).
  /// <c>TID_RENDERER</c>
  /// </summary>
  /// <remarks>Only available in the render process.</remarks>
  Renderer

}
