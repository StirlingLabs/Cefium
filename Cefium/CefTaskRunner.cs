namespace Cefium;

/// <summary>
/// Structure that asynchronously executes tasks on the associated thread. It is
/// safe to call the functions of this structure on any thread.
///
/// CEF maintains multiple internal threads that are used for handling different
/// types of tasks in different processes. The cef_thread_id_t definitions in
/// cef_types.h list the common CEF threads. Task runners are also available for
/// other CEF threads as appropriate (for example, V8 WebWorker threads).
/// <c>cef_task_runner_t</c>
/// </summary>
/// <seealso cref="CefTask"/>
/// <seealso cref="CefTaskRunnerExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefTaskRunner : ICefRefCountedBase<CefTaskRunner> {

  /// <inheritdoc cref="CefTaskRunner"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefTaskRunner() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns true (1) if this object is pointing to the same task runner as
  /// |that| object.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_task_runner_t* self, struct _cef_task_runner_t* that)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefTaskRunner*, CefTaskRunner*, int> _IsSame;

  /// <summary>
  /// Returns true (1) if this task runner belongs to the current thread.
  /// <c>int(CEF_CALLBACK* belongs_to_current_thread)(struct _cef_task_runner_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefTaskRunner*, int> _BelongsToCurrentThread;

  /// <summary>
  /// Returns true (1) if this task runner is for the specified CEF thread.
  /// <c>int(CEF_CALLBACK* belongs_to_thread)(struct _cef_task_runner_t* self, cef_thread_id_t threadId);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefTaskRunner*, CefThreadId, int> _BelongsToThread;

  /// <summary>
  /// Post a task for execution on the thread associated with this task runner.
  /// Execution will occur asynchronously.
  /// <c>int(CEF_CALLBACK* post_task)(struct _cef_task_runner_t* self, struct _cef_task_t* task);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefTaskRunner*, CefTask*, int> _PostTask;

  /// <summary>
  /// Post a task for delayed execution on the thread associated with this task
  /// runner. Execution will occur asynchronously. Delayed tasks are not
  /// supported on V8 WebWorker threads and will be executed without the
  /// specified delay.
  /// <c>int(CEF_CALLBACK* post_delayed_task)(struct _cef_task_runner_t* self, struct _cef_task_t* task, int64 delay_ms);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefTaskRunner*, CefTask*, long, int> _PostDelayedTask;

  /// <summary>
  /// Returns the task runner for the current thread. Only CEF threads will have
  /// task runners. An NULL reference will be returned if this function is called
  /// on an invalid thread.
  ///
  /// <c>CEF_EXPORT cef_task_runner_t* cef_task_runner_get_for_current_thread(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_task_runner_get_for_current_thread", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefTaskRunner* GetForCurrentThread();

  /// <summary>
  /// Returns the task runner for the specified CEF thread.
  ///
  /// <c>CEF_EXPORT cef_task_runner_t* cef_task_runner_get_for_thread(cef_thread_id_t threadId);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_task_runner_get_for_thread", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefTaskRunner* GetForThread(CefThreadId threadId);

}
