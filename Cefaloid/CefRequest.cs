namespace Cefaloid;

/// <summary>
/// Structure used to represent a web request. The functions of this structure
/// may be called on any thread.
/// <c>cef_request_t</c>
/// </summary>
/// <seealso cref="CefRequestExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRequest : ICefRefCountedBase<CefRequest> {

  /// <inheritdoc cref="CefRequest"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefRequest() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns true (1) if this object is read-only.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, int> _IsReadOnly;

  /// <summary>
  /// Get the fully qualified URL.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_url)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefStringUserFree*> _GetUrl;

  /// <summary>
  /// Set the fully qualified URL.
  /// <c>void(CEF_CALLBACK* set_url)(struct _cef_request_t* self, const cef_string_t* url);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefString*, void> _SetUrl;

  /// <summary>
  /// Get the request function type. The value will default to POST if post data
  /// is provided and GET otherwise.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_method)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefStringUserFree*> _GetMethod;

  /// <summary>
  /// Set the request function type.
  /// <c>void(CEF_CALLBACK* set_method)(struct _cef_request_t* self, const cef_string_t* method);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefString*, void> _SetMethod;

  /// <summary>
  /// Set the referrer URL and policy. If non-NULL the referrer URL must be
  /// fully qualified with an HTTP or HTTPS scheme component. Any username,
  /// password or ref component will be removed.
  /// <c>void(CEF_CALLBACK* set_referrer)(struct _cef_request_t* self, const cef_string_t* referrer_url, cef_referrer_policy_t policy);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefString*, CefReferrerPolicy, void> _SetReferrer;

  /// <summary>
  /// Get the referrer URL.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_referrer_url)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefStringUserFree*> _GetReferrerUrl;

  /// <summary>
  /// Get the referrer policy.
  /// <c>cef_referrer_policy_t(CEF_CALLBACK* get_referrer_policy)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefReferrerPolicy> _GetReferrerPolicy;

  /// <summary>
  /// Get the post data.
  /// <c>struct _cef_post_data_t*(CEF_CALLBACK* get_post_data)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefPostData*> _GetPostData;

  /// <summary>
  /// Set the post data.
  /// <c>void(CEF_CALLBACK* set_post_data)(struct _cef_request_t* self, struct _cef_post_data_t* postData);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefPostData*, void> _SetPostData;

  /// <summary>
  /// Get the header values. Will not include the Referer value if any.
  /// <c>void(CEF_CALLBACK* get_header_map)(struct _cef_request_t* self, cef_string_multimap_t headerMap);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefStringMultimap*, void> _GetHeaderMap;

  /// <summary>
  /// Set the header values. If a Referer value exists in the header map it will
  /// be removed and ignored.
  /// <c>void(CEF_CALLBACK* set_header_map)(struct _cef_request_t* self, cef_string_multimap_t headerMap);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefStringMultimap*, void> _SetHeaderMap;

  /// <summary>
  /// Returns the first header value for |name| or an NULL string if not found.
  /// Will not return the Referer value if any. Use GetHeaderMap instead if
  /// |name| might have multiple values.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_header_by_name)(struct _cef_request_t* self, const cef_string_t* name);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefString*, CefStringUserFree*> _GetHeaderByName;

  /// <summary>
  /// Set the header |name| to |value|. If |overwrite| is true (1) any existing
  /// values will be replaced with the new value. If |overwrite| is false (0)
  /// any existing values will not be overwritten. The Referer value cannot be
  /// set using this function.
  /// <c>void(CEF_CALLBACK* set_header_by_name)(struct _cef_request_t* self, const cef_string_t* name, const cef_string_t* value, int overwrite);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefString*, CefString*, int, void> _SetHeaderByName;

  /// <summary>
  /// Set all values at one time.
  /// <c>void(CEF_CALLBACK* set)(struct _cef_request_t* self, const cef_string_t* url, const cef_string_t* method, struct _cef_post_data_t* postData, cef_string_multimap_t headerMap);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefString*, CefString*, CefPostData*, CefStringMultimap*, void> _Set;

  /// <summary>
  /// Get the flags used in combination with cef_urlrequest_t. See
  /// cef_urlrequest_flags_t for supported values.
  /// <c>int(CEF_CALLBACK* get_flags)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, int> _GetFlags;

  /// <summary>
  /// Set the flags used in combination with cef_urlrequest_t.  See
  /// cef_urlrequest_flags_t for supported values.
  /// <c>void(CEF_CALLBACK* set_flags)(struct _cef_request_t* self, int flags);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, int, void> _SetFlags;

  /// <summary>
  /// Get the URL to the first party for cookies used in combination with
  /// cef_urlrequest_t.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_first_party_for_cookies)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefStringUserFree*> _GetFirstPartyForCookies;

  /// <summary>
  /// Set the URL to the first party for cookies used in combination with
  /// cef_urlrequest_t.
  /// <c>void(CEF_CALLBACK* set_first_party_for_cookies)(struct _cef_request_t* self, const cef_string_t* url);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefString*, void> _SetFirstPartyForCookies;

  /// <summary>
  /// Get the resource type for this request. Only available in the browser
  /// process.
  /// <c>cef_resource_type_t(CEF_CALLBACK* get_resource_type)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefResourceType> _GetResourceType;

  /// <summary>
  /// Get the transition type for this request. Only available in the browser
  /// process and only applies to requests that represent a main frame or sub-
  /// frame navigation.
  /// <c>cef_transition_type_t(CEF_CALLBACK* get_transition_type)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, CefTransitionType> _GetTransitionType;

  /// <summary>
  /// Returns the globally unique identifier for this request or 0 if not
  /// specified. Can be used by cef_resource_request_handler_t implementations
  /// in the browser process to track a single request across multiple
  /// callbacks.
  /// <c>uint64(CEF_CALLBACK* get_identifier)(struct _cef_request_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRequest*, ulong> _GetIdentifier;

}
