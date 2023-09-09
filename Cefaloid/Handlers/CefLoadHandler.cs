namespace Cefaloid;

/// <summary>
/// Implement this structure to handle events related to browser load status.
/// The functions of this structure will be called on the browser process UI
/// thread or render process main thread (TID_RENDERER).
/// <c>cef_load_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefLoadHandler : ICefRefCountedBase<CefLoadHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefLoadHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called when the loading state has changed. This callback will be executed
  /// twice -- once when loading is initiated either programmatically or by user
  /// action, and once when loading is terminated due to completion, /// cancellation of failure. It will be called before any calls to OnLoadStart
  /// and after all calls to OnLoadError and/or OnLoadEnd.
  /// <c>void(CEF_CALLBACK* on_loading_state_change)(struct _cef_load_handler_t* self, struct _cef_browser_t* browser, int isLoading, int canGoBack, int canGoForward)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefLoadHandler*, CefBrowser*, int, int, int, void> _OnLoadingStateChange;

  /// <summary>
  /// Called after a navigation has been committed and before the browser begins
  /// loading contents in the frame. The |frame| value will never be NULL --
  /// call the is_main() function to check if this frame is the main frame.
  /// |transition_type| provides information about the source of the navigation
  /// and an accurate value is only available in the browser process. Multiple
  /// frames may be loading at the same time. Sub-frames may start or continue
  /// loading after the main frame load has ended. This function will not be
  /// called for same page navigations (fragments, history state, etc.) or for
  /// navigations that fail or are canceled before commit. For notification of
  /// overall browser load status use OnLoadingStateChange instead.
  /// <c>void(CEF_CALLBACK* on_load_start)(struct _cef_load_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, cef_transition_type_t transition_type)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefLoadHandler*, CefBrowser*, CefFrame*, CefTransitionType, void> _OnLoadStart;

  /// <summary>
  /// Called when the browser is done loading a frame. The |frame| value will
  /// never be NULL -- call the is_main() function to check if this frame is the
  /// main frame. Multiple frames may be loading at the same time. Sub-frames
  /// may start or continue loading after the main frame load has ended. This
  /// function will not be called for same page navigations (fragments, history
  /// state, etc.) or for navigations that fail or are canceled before commit.
  /// For notification of overall browser load status use OnLoadingStateChange
  /// instead.
  /// <c>void(CEF_CALLBACK* on_load_end)(struct _cef_load_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, int httpStatusCode)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefLoadHandler*, CefBrowser*, CefFrame*, int, void> _OnLoadEnd;

  /// <summary>
  /// Called when a navigation fails or is canceled. This function may be called
  /// by itself if before commit or in combination with OnLoadStart/OnLoadEnd if
  /// after commit. |errorCode| is the error code number, |errorText| is the
  /// error text and |failedUrl| is the URL that failed to load. See
  /// net\base\net_error_list.h for complete descriptions of the error codes.
  /// <c>void(CEF_CALLBACK* on_load_error)(struct _cef_load_handler_t* self, struct _cef_browser_t* browser, struct _cef_frame_t* frame, cef_errorcode_t errorCode, const cef_string_t* errorText, const cef_string_t* failedUrl)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefLoadHandler*, CefBrowser*, CefFrame*, CefErrorCode, CefString*, CefString*, void> _OnLoadError;

}
