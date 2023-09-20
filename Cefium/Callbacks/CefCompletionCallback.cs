namespace Cefium;

/// <summary>
/// Generic callback structure used for asynchronous completion.
/// <c>cef_completion_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCompletionCallback : ICefRefCountedBase<CefCompletionCallback> {

  /// <see cref="CefCompletionCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefCompletionCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be called once the task is complete.
  /// <c>void(CEF_CALLBACK* on_complete)(struct _cef_completion_callback_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCompletionCallback*, void> _OnComplete;

}
