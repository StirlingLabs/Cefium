namespace Cefaloid;

/// <summary>
/// Structure used to implement a custom request handler structure. The
/// functions of this structure will be called on the IO thread unless otherwise
/// indicated.
/// <c>cef_resource_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefResourceHandler : ICefRefCountedBase<CefResourceHandler> {

  /// <inheritdoc cref="CefResourceHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefResourceHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Open the response stream. To handle the request immediately set
  /// |handle_request| to true (1) and return true (1). To decide at a later
  /// time set |handle_request| to false (0), return true (1), and execute
  /// |callback| to continue or cancel the request. To cancel the request
  /// immediately set |handle_request| to true (1) and return false (0). This
  /// function will be called in sequence but not from a dedicated thread. For
  /// backwards compatibility set |handle_request| to false (0) and return false
  /// (0) and the ProcessRequest function will be called.
  /// <c>int(CEF_CALLBACK* open)(struct _cef_resource_handler_t* self, struct _cef_request_t* request, int* handle_request, struct _cef_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceHandler*, CefRequest*, int*, CefCallback*, int> _Open;

  /// <summary>
  /// Begin processing the request. To handle the request return true (1) and
  /// call cef_callback_t::cont() once the response header information is
  /// available (cef_callback_t::cont() can also be called from inside this
  /// function if header information is available immediately). To cancel the
  /// request return false (0).
  ///
  /// WARNING: This function is deprecated. Use Open instead.
  /// <c>int(CEF_CALLBACK* process_request)(struct _cef_resource_handler_t* self, struct _cef_request_t* request, struct _cef_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceHandler*, CefRequest*, CefCallback*, int> _ProcessRequest;

  /// <summary>
  /// Retrieve response header information. If the response length is not known
  /// set |response_length| to -1 and read_response() will be called until it
  /// returns false (0). If the response length is known set |response_length|
  /// to a positive value and read_response() will be called until it returns
  /// false (0) or the specified number of bytes have been read. Use the
  /// |response| object to set the mime type, http status code and other
  /// optional header values. To redirect the request to a new URL set
  /// |redirectUrl| to the new URL. |redirectUrl| can be either a relative or
  /// fully qualified URL. It is also possible to set |response| to a redirect
  /// http status code and pass the new URL via a Location header. Likewise with
  /// |redirectUrl| it is valid to set a relative or fully qualified URL as the
  /// Location header value. If an error occured while setting up the request
  /// you can call set_error() on |response| to indicate the error condition.
  /// <c>void(CEF_CALLBACK* get_response_headers)(struct _cef_resource_handler_t* self, struct _cef_response_t* response, int64* response_length, cef_string_t* redirectUrl);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceHandler*, CefResponse*, long*, CefString*, void> _GetResponseHeaders;

  /// <summary>
  /// Skip response data when requested by a Range header. Skip over and discard
  /// |bytes_to_skip| bytes of response data. If data is available immediately
  /// set |bytes_skipped| to the number of bytes skipped and return true (1). To
  /// read the data at a later time set |bytes_skipped| to 0, return true (1)
  /// and execute |callback| when the data is available. To indicate failure set
  /// |bytes_skipped| to &lt; 0 (e.g. -2 for ERR_FAILED) and return false (0). This
  /// function will be called in sequence but not from a dedicated thread.
  /// <c>int(CEF_CALLBACK* skip)(struct _cef_resource_handler_t* self, int64 bytes_to_skip, int64* bytes_skipped, struct _cef_resource_skip_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceHandler*, long, long*, CefResourceSkipCallback*, int> _Skip;

  /// <summary>
  /// Read response data. If data is available immediately copy up to
  /// |bytes_to_read| bytes into |data_out|, set |bytes_read| to the number of
  /// bytes copied, and return true (1). To read the data at a later time keep a
  /// pointer to |data_out|, set |bytes_read| to 0, return true (1) and execute
  /// |callback| when the data is available (|data_out| will remain valid until
  /// the callback is executed). To indicate response completion set
  /// |bytes_read| to 0 and return false (0). To indicate failure set
  /// |bytes_read| to &lt; 0 (e.g. -2 for ERR_FAILED) and return false (0). This
  /// function will be called in sequence but not from a dedicated thread. For
  /// backwards compatibility set |bytes_read| to -1 and return false (0) and
  /// the ReadResponse function will be called.
  /// <c>int(CEF_CALLBACK* read)(struct _cef_resource_handler_t* self, void* data_out, int bytes_to_read, int* bytes_read, struct _cef_resource_read_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceHandler*, void*, int, int*, CefResourceReadCallback*, int> _Read;

  /// <summary>
  /// Read response data. If data is available immediately copy up to
  /// |bytes_to_read| bytes into |data_out|, set |bytes_read| to the number of
  /// bytes copied, and return true (1). To read the data at a later time set
  /// |bytes_read| to 0, return true (1) and call cef_callback_t::cont() when
  /// the data is available. To indicate response completion return false (0).
  ///
  /// WARNING: This function is deprecated. Use Skip and Read instead.
  /// <c>int(CEF_CALLBACK* read_response)(struct _cef_resource_handler_t* self, void* data_out, int bytes_to_read, int* bytes_read, struct _cef_callback_t* callback);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceHandler*, void*, int, int*, CefCallback*, int> _ReadResponse;

  /// <summary>
  /// Request processing has been canceled.
  /// <c>void(CEF_CALLBACK* cancel)(struct _cef_resource_handler_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceHandler*, void> _Cancel;

}
