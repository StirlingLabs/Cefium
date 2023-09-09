namespace Cefaloid;

/// <summary>
/// <c>cef_permission_prompt_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPermissionPromptCallback : ICefRefCountedBase<CefPermissionPromptCallback> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefPermissionPromptCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Complete the permissions request with the specified |result|.
  /// <c>void(CEF_CALLBACK* cont)(struct _cef_permission_prompt_callback_t* self, cef_permission_request_result_t result)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPermissionPromptCallback*, CefPermissionRequestResult, void> _Continue;

}
