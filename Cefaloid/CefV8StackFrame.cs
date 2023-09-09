namespace Cefaloid;

/// <summary>
/// Structure representing a V8 stack frame handle. V8 handles can only be
/// accessed from the thread on which they are created. Valid threads for
/// creating a V8 handle include the render process main thread (TID_RENDERER)
/// and WebWorker threads. A task runner for posting tasks on the associated
/// thread can be retrieved via the cef_v8context_t::get_task_runner() function.
/// <c>cef_v8stack_frame_t</c>
/// </summary>
/// <seealso cref="CefV8StackFrameExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefV8StackFrame : ICefRefCountedBase<CefV8StackFrame> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefV8StackFrame() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns true (1) if the underlying handle is valid and it can be accessed
  /// on the current thread. Do not call any other functions if this function
  /// returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_v8stack_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackFrame*, int> _IsValid;

  /// <summary>
  /// Returns the name of the resource script that contains the function.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_script_name)(struct _cef_v8stack_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackFrame*, CefStringUserFree*> _GetScriptName;

  /// <summary>
  /// Returns the name of the resource script that contains the function or the
  /// sourceURL value if the script name is undefined and its source ends with a
  /// "//@ sourceURL=..." string.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_script_name_or_source_url)(struct _cef_v8stack_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackFrame*, CefStringUserFree*> _GetScriptNameOrSourceUrl;

  /// <summary>
  /// Returns the name of the function.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_function_name)(struct _cef_v8stack_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackFrame*, CefStringUserFree*> _GetFunctionName;

  /// <summary>
  /// Returns the 1-based line number for the function call or 0 if unknown.
  /// <c>int(CEF_CALLBACK* get_line_number)(struct _cef_v8stack_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackFrame*, int> _GetLineNumber;

  /// <summary>
  /// Returns the 1-based column offset on the line for the function call or 0
  /// if unknown.
  /// <c>int(CEF_CALLBACK* get_column)(struct _cef_v8stack_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackFrame*, int> _GetColumn;

  /// <summary>
  /// Returns true (1) if the function was compiled using eval().
  /// <c>int(CEF_CALLBACK* is_eval)(struct _cef_v8stack_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackFrame*, int> _IsEval;

  /// <summary>
  /// Returns true (1) if the function was called as a constructor via "new".
  /// <c>int(CEF_CALLBACK* is_constructor)(struct _cef_v8stack_frame_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8StackFrame*, int> _IsConstructor;

}
