namespace Cefaloid;

/// <summary>
/// Structure used to represent an entry in navigation history.
/// <c>cef_navigation_entry_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefNavigationEntry : ICefRefCountedBase<CefNavigationEntry> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefNavigationEntry() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns true (1) if this object is valid. Do not call any other functions
  /// if this function returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, int> _IsValid;

  /// <summary>
  /// Returns the actual URL of the page. For some pages this may be data: URL
  /// or similar. Use get_display_url() to return a display-friendly version.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_url)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, CefStringUserFree*> _GetUrl;

  /// <summary>
  /// Returns a display-friendly version of the URL.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_display_url)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, CefStringUserFree*> _GetDisplayUrl;

  /// <summary>
  /// Returns the original URL that was entered by the user before any
  /// redirects.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_original_url)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, CefStringUserFree*> _GetOriginalUrl;

  /// <summary>
  /// Returns the title set by the page. This value may be NULL.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_title)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, CefStringUserFree*> _GetTitle;

  /// <summary>
  /// Returns the transition type which indicates what the user did to move to
  /// this page from the previous page.
  /// <c>cef_transition_type_t(CEF_CALLBACK* get_transition_type)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, CefTransitionType> _GetTransitionType;

  /// <summary>
  /// Returns true (1) if this navigation includes post data.
  /// <c>int(CEF_CALLBACK* has_post_data)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, int> _HasPostData;

  /// <summary>
  /// Returns the time for the last known successful navigation completion. A
  /// navigation may be completed more than once if the page is reloaded. May be
  /// 0 if the navigation has not yet completed.
  /// <c>cef_basetime_t(CEF_CALLBACK* get_completion_time)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, CefBaseTime> _GetCompletionTime;

  /// <summary>
  /// Returns the HTTP status code for the last known successful navigation
  /// response. May be 0 if the response has not yet been received or if the
  /// navigation has not yet completed.
  /// <c>int(CEF_CALLBACK* get_http_status_code)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, int> _GetHttpStatusCode;

  /// <summary>
  /// Returns the SSL information for this navigation entry.
  /// <c>struct _cef_sslstatus_t*(CEF_CALLBACK* get_sslstatus)(struct _cef_navigation_entry_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntry*, CefSslStatus*> _GetSslStatus;

}
