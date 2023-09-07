namespace Cefaloid;

/// <seealso cref="CefThreadId"/>
[PublicAPI]
public static class CefThreadIdExtensions {

  /// <summary>
  /// Returns true (1) if called on the specified thread. Equivalent to using
  /// cef_task_runner_t::GetForThread(threadId)->belongs_to_current_thread().
  ///
  /// <c>CEF_EXPORT int cef_currently_on(cef_thread_id_t threadId);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_currently_on", CallingConvention = CallingConvention.Cdecl)]
  internal static extern int _CurrentlyOn(CefThreadId threadId);

  public static bool CurrentlyOn(this CefThreadId threadId) => _CurrentlyOn(threadId) != 0;

}
