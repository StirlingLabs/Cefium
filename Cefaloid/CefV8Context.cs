namespace Cefaloid;

/// <summary>
/// Structure representing a V8 context handle. V8 handles can only be accessed
/// from the thread on which they are created. Valid threads for creating a V8
/// handle include the render process main thread (TID_RENDERER) and WebWorker
/// threads. A task runner for posting tasks on the associated thread can be
/// retrieved via the cef_v8context_t::get_task_runner() function.
/// <c>cef_v8context_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefV8Context : ICefRefCountedBase<CefV8Context> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefV8Context() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the current (top) context object in the V8 context stack.
  /// <c>CEF_EXPORT cef_v8context_t* cef_v8context_get_current_context(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_v8context_get_current_context", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefV8Context* GetCurrentContext();

  /// <summary>
  /// Returns the entered (bottom) context object in the V8 context stack.
  /// <c>CEF_EXPORT cef_v8context_t* cef_v8context_get_entered_context(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_v8context_get_entered_context", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefV8Context* GetEnteredContext();

  /// <summary>
  /// Returns true (1) if V8 is currently inside a context.
  /// <c>CEF_EXPORT int cef_v8context_in_context(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_v8context_in_context", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe int _InContext();

  /// <inheritdoc cref="_InContext"/>
  public static bool InContext => _InContext() != 0;

  /// <summary>
  /// Returns the task runner associated with this context. V8 handles can only
  /// be accessed from the thread on which they are created. This function can
  /// be called on any render process thread.
  /// <c>struct _cef_task_runner_t*(CEF_CALLBACK* get_task_runner)(struct _cef_v8context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, CefTaskRunner*> _GetTaskRunner;

  /// <summary>
  /// Returns true (1) if the underlying handle is valid and it can be accessed
  /// on the current thread. Do not call any other functions if this function
  /// returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_v8context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, int> _IsValid;

  /// <summary>
  /// Returns the browser for this context. This function will return an NULL
  /// reference for WebWorker contexts.
  /// <c>struct _cef_browser_t*(CEF_CALLBACK* get_browser)(struct _cef_v8context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, CefBrowser*> _GetBrowser;

  /// <summary>
  /// Returns the frame for this context. This function will return an NULL
  /// reference for WebWorker contexts.
  /// <c>struct _cef_frame_t*(CEF_CALLBACK* get_frame)(struct _cef_v8context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, CefFrame*> _GetFrame;

  /// <summary>
  /// Returns the global object for this context. The context must be entered
  /// before calling this function.
  /// <c>struct _cef_v8value_t*(CEF_CALLBACK* get_global)(struct _cef_v8context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, CefValue*> _GetGlobal;

  /// <summary>
  /// Enter this context. A context must be explicitly entered before creating a
  /// V8 Object, Array, Function or Date asynchronously. exit() must be called
  /// the same number of times as enter() before releasing this context. V8
  /// objects belong to the context in which they are created. Returns true (1)
  /// if the scope was entered successfully.
  /// <c>int(CEF_CALLBACK* enter)(struct _cef_v8context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, int> _Enter;

  /// <summary>
  /// Exit this context. Call this function only after calling enter(). Returns
  /// true (1) if the scope was exited successfully.
  /// <c>int(CEF_CALLBACK* exit)(struct _cef_v8context_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, int> _Exit;

  /// <summary>
  /// Returns true (1) if this object is pointing to the same handle as |that|
  /// object.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_v8context_t* self, struct _cef_v8context_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, CefV8Context*, int> _IsSame;

  /// <summary>
  /// Execute a string of JavaScript code in this V8 context. The |script_url|
  /// parameter is the URL where the script in question can be found, if any.
  /// The |start_line| parameter is the base line number to use for error
  /// reporting. On success |retval| will be set to the return value, if any,
  /// and the function will return true (1). On failure |exception| will be set
  /// to the exception, if any, and the function will return false (0).
  /// <c>int(CEF_CALLBACK* eval)(struct _cef_v8context_t* self, const cef_string_t* code, const cef_string_t* script_url, int start_line, struct _cef_v8value_t** retval, struct _cef_v8exception_t** exception);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Context*, CefString*, CefString*, int, CefValue**, CefV8Exception**, int> _Eval;

}
