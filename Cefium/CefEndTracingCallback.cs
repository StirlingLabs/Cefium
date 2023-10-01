namespace Cefium;

/// <summary>
/// Implement this structure to receive notification when tracing has completed.
/// The functions of this structure will be called on the browser process UI
/// thread.
/// <c>cef_end_tracing_callback_t</c>
/// </summary>
/// <seealso cref="CefEndTracingCallbackExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefEndTracingCallback {

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called after all processes have sent their trace data. |tracing_file| is
  /// the path at which tracing data was written. The client is responsible for
  /// deleting |tracing_file|.
  /// <c>void(CEF_CALLBACK* on_end_tracing_complete)(struct _cef_end_tracing_callback_t* self, const cef_string_t* tracing_file);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefEndTracingCallback*, CefString*, void> _OnEndTracingComplete;

}
