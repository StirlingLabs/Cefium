namespace Cefaloid;

/// <summary>
/// Implement this structure for asynchronous task execution. If the task is
/// posted successfully and if the associated message loop is still running then
/// the execute() function will be called on the target thread. If the task
/// fails to post then the task object may be destroyed on the source thread
/// instead of the target thread. For this reason be cautious when performing
/// work in the task object destructor.
/// <c>cef_task_t</c>
/// </summary>
/// <seealso cref="CefTaskExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefTask : ICefRefCountedBase<CefTask> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefTask() {
  }

  ///
  /// Base structure.
  ///
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be executed on the target thread.
  /// <c>void(CEF_CALLBACK* execute)(struct _cef_task_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefTask*, void> _Execute;

  /// <summary>
  /// Post a task for execution on the specified thread. Equivalent to using
  /// cef_task_runner_t::GetForThread(threadId)->PostTask(task).
  ///
  /// <c>CEF_EXPORT int cef_post_task(cef_thread_id_t threadId, cef_task_t* task);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_post_task", CallingConvention = CallingConvention.Cdecl)]
  public static extern int _PostTask(CefThreadId threadId, ref CefTask task);

  /// <inheritdoc cref="_PostTask"/>
  public static bool PostTask(CefThreadId threadId, ref CefTask task)
    => _PostTask(threadId, ref task) != 0;

  /// <summary>
  /// Post a task for delayed execution on the specified thread. Equivalent to
  /// using cef_task_runner_t::GetForThread(threadId)->PostDelayedTask(task,
  /// delay_ms).
  ///
  /// <c>CEF_EXPORT int cef_post_delayed_task(cef_thread_id_t threadId, cef_task_t* task, int64 delay_ms);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_post_delayed_task", CallingConvention = CallingConvention.Cdecl)]
  public static extern int _PostDelayedTask(CefThreadId threadId, ref CefTask task, long delayMs);

  /// <inheritdoc cref="_PostDelayedTask"/>
  public static bool PostDelayedTask(CefThreadId threadId, ref CefTask task, long delayMs)
    => _PostDelayedTask(threadId, ref task, delayMs) != 0;

}
