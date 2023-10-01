namespace Cefium;

/// <summary>
/// Structure used to represent a web response. The functions of this structure
/// may be called on any thread.
/// <c>cef_response_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefResponse : ICefRefCountedBase<CefResponse> {

  /// <inheritdoc cref="CefResponse"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefResponse() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_response_t object.
  /// <c>CEF_EXPORT cef_response_t* cef_response_create(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_response_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefResponse* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefResponse* CreateUndefined()
    => _Create();

  /// <summary>
  /// Returns true (1) if this object is read-only.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_response_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, int> _IsReadOnly;

  /// <summary>
  /// Get the response error code. Returns ERR_NONE if there was no error.
  /// <c>cef_errorcode_t(CEF_CALLBACK* get_error)(struct _cef_response_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefErrorCode> _GetError;

  /// <summary>
  /// Set the response error code. This can be used by custom scheme handlers to
  /// return errors during initial request processing.
  /// <c>void(CEF_CALLBACK* set_error)(struct _cef_response_t* self, cef_errorcode_t error)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefErrorCode, void> _SetError;

  /// <summary>
  /// Get the response status code.
  /// <c>int(CEF_CALLBACK* get_status)(struct _cef_response_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, int> _GetStatus;

  /// <summary>
  /// Set the response status code.
  /// <c>void(CEF_CALLBACK* set_status)(struct _cef_response_t* self, int status)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, int, void> _SetStatus;

  /// <summary>
  /// Get the response status text.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_status_text)(struct _cef_response_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefStringUserFree*> _GetStatusText;

  /// <summary>
  /// Set the response status text.
  /// <c>void(CEF_CALLBACK* set_status_text)(struct _cef_response_t* self, const cef_string_t* statusText)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefString*, void> _SetStatusText;

  /// <summary>
  /// Get the response mime type.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_mime_type)(struct _cef_response_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefStringUserFree*> _GetMimeType;

  /// <summary>
  /// Set the response mime type.
  /// <c>void(CEF_CALLBACK* set_mime_type)(struct _cef_response_t* self, const cef_string_t* mimeType)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefString*, void> _SetMimeType;

  /// <summary>
  /// Get the response charset.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_charset)(struct _cef_response_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefStringUserFree*> _GetCharset;

  /// <summary>
  /// Set the response charset.
  /// <c>void(CEF_CALLBACK* set_charset)(struct _cef_response_t* self, const cef_string_t* charset)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefString*, void> _SetCharset;

  /// <summary>
  /// Get the value for the specified response header field.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_header_by_name)(struct _cef_response_t* self, const cef_string_t* name)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefString*, CefStringUserFree*> _GetHeaderByName;

  /// <summary>
  /// Set the header |name| to |value|. If |overwrite| is true (1) any existing
  /// values will be replaced with the new value. If |overwrite| is false (0)
  /// any existing values will not be overwritten.
  /// <c>void(CEF_CALLBACK* set_header_by_name)(struct _cef_response_t* self, const cef_string_t* name, const cef_string_t* value, int overwrite)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefString*, CefString*, int, void> _SetHeaderByName;

  /// <summary>
  /// Get all response header fields.
  /// <c>void(CEF_CALLBACK* get_header_map)(struct _cef_response_t* self, cef_string_multimap_t headerMap)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefStringMultimap*, void> _GetHeaderMap;

  /// <summary>
  /// Set all response header fields.
  /// <c>void(CEF_CALLBACK* set_header_map)(struct _cef_response_t* self, cef_string_multimap_t headerMap)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefStringMultimap*, void> _SetHeaderMap;

  /// <summary>
  /// Get the resolved URL after redirects or changed as a result of HSTS.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_url)(struct _cef_response_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefStringUserFree*> _GetUrl;

  /// <summary>
  /// Set the resolved URL after redirects or changed as a result of HSTS.
  /// <c>void(CEF_CALLBACK* set_url)(struct _cef_response_t* self, const cef_string_t* url)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponse*, CefString*, void> _SetUrl;

}
