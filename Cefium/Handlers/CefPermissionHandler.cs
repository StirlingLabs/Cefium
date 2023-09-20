namespace Cefium;

/// <summary>
/// <c>cef_permission_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPermissionHandler : ICefRefCountedBase<CefPermissionHandler> {

  /// <inheritdoc cref="CefPermissionHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefPermissionHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called when a page requests permission to access media.
  /// |requesting_origin| is the URL origin requesting permission.
  /// |requested_permissions| is a combination of values from
  /// cef_media_access_permission_types_t that represent the requested
  /// permissions. Return true (1) and call cef_media_access_callback_t
  /// functions either in this function or at a later time to continue or cancel
  /// the request. Return false (0) to proceed with default handling. With the
  /// Chrome runtime, default handling will display the permission request UI.
  /// With the Alloy runtime, default handling will deny the request. This
  /// function will not be called if the "--enable-media-stream" command-line
  /// switch is used to grant all permissions.
  /// <c>int(CEF_CALLBACK* on_request_media_access_permission)(struct _cef_permission_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, const cef_string_t* requesting_origin, uint32 requested_permissions, struct _cef_media_access_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPermissionHandler*, CefBrowser*, CefFrame*, CefString*, CefMediaAccessPermissionTypes, CefMediaAccessCallback*, int> _OnRequestMediaAccessPermission;

  /// <summary>
  /// Called when a page should show a permission prompt. |prompt_id| uniquely
  /// identifies the prompt. |requesting_origin| is the URL origin requesting
  /// permission. |requested_permissions| is a combination of values from
  /// cef_permission_request_types_t that represent the requested permissions.
  /// Return true (1) and call cef_permission_prompt_callback_t::Continue either
  /// in this function or at a later time to continue or cancel the request.
  /// Return false (0) to proceed with default handling. With the Chrome
  /// runtime, default handling will display the permission prompt UI. With the
  /// Alloy runtime, default handling is CEF_PERMISSION_RESULT_IGNORE.
  /// <c>int(CEF_CALLBACK* on_show_permission_prompt)(struct _cef_permission_handler_t* self, struct _cef_browser_t* browser, uint64 prompt_id, const cef_string_t* requesting_origin, uint32 requested_permissions, struct _cef_permission_prompt_callback_t* callback)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPermissionHandler*, CefBrowser*, ulong, CefString*, uint, CefPermissionPromptCallback*, int> _OnShowPermissionPrompt;

  /// <summary>
  /// Called when a permission prompt handled via OnShowPermissionPrompt is
  /// dismissed. |prompt_id| will match the value that was passed to
  /// OnShowPermissionPrompt. |result| will be the value passed to
  /// cef_permission_prompt_callback_t::Continue or CEF_PERMISSION_RESULT_IGNORE
  /// if the dialog was dismissed for other reasons such as navigation, browser
  /// closure, etc. This function will not be called if OnShowPermissionPrompt
  /// returned false (0) for |prompt_id|.
  /// <c>void(CEF_CALLBACK* on_dismiss_permission_prompt)(struct _cef_permission_handler_t* self, struct _cef_browser_t* browser, uint64 prompt_id, cef_permission_request_result_t result)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPermissionHandler*, CefBrowser*, ulong, CefPermissionRequestResult, void> _OnDismissPermissionPrompt;

}
