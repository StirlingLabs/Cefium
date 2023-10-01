namespace Cefium;

/// <summary>
/// Structure representing a V8 stack trace handle. V8 handles can only be
/// accessed from the thread on which they are created. Valid threads for
/// creating a V8 handle include the render process main thread (TID_RENDERER)
/// and WebWorker threads. A task runner for posting tasks on the associated
/// thread can be retrieved via the cef_v8context_t::get_task_runner() function.
/// <c>cef_v8_stack_trace_t</c>
/// </summary>
/// <seealso cref="CefV8StackTraceExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefV8StackTrace : ICefRefCountedBase<CefV8StackTrace> {

  /// <inheritdoc cref="CefV8StackTrace"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefV8StackTrace() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the stack trace for the currently active context. |frame_limit| is
  /// the maximum number of frames that will be captured.
  /// <c>CEF_EXPORT cef_v8stack_trace_t* cef_v8stack_trace_get_current(int frame_limit);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_v8stack_trace_get_current", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefV8StackTrace* GetCurrent(int frameLimit);

  /// <summary>
  /// Returns true (1) if the underlying handle is valid and it can be accessed
  /// on the current thread. Do not call any other functions if this function
  /// returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_v8stack_trace_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackTrace*, int> _IsValid;

  /// <summary>
  /// Returns the number of stack frames.
  /// <c>int(CEF_CALLBACK* get_frame_count)(struct _cef_v8stack_trace_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackTrace*, int> _GetFrameCount;

  /// <summary>
  /// Returns the stack frame at the specified 0-based index.
  /// <c>struct _cef_v8stack_frame_t*(CEF_CALLBACK* get_frame)(struct _cef_v8stack_trace_t* self, int index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackTrace*, int, CefV8StackFrame*> _GetFrame;

}
