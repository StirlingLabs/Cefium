namespace Cefaloid;

/// <summary>
/// Callback structure for asynchronous continuation of print job requests.
/// <c>cef_print_job_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPrintJobCallback : ICefRefCountedBase<CefPrintJobCallback> {

  /// <see cref="CefPrintJobCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefPrintJobCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Indicate completion of the print job.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_print_job_callback_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintJobCallback*, void> _Continue;

}
