namespace Cefium;

/// <summary>
/// Implement this structure to filter resource response content. The functions
/// of this structure will be called on the browser process IO thread.
/// <c>cef_response_filter_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefResponseFilter : ICefRefCountedBase<CefResponseFilter> {

  /// <inheritdoc cref="CefResponseFilter"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefResponseFilter() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Initialize the response filter. Will only be called a single time. The
  /// filter will not be installed if this function returns false (0).
  /// <c>int(CEF_CALLBACK* init_filter)(struct _cef_response_filter_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponseFilter*, int> _InitFilter;

  /// <summary>
  /// Called to filter a chunk of data. Expected usage is as follows:
  ///
  ///  1. Read input data from |data_in| and set |data_in_read| to the number of
  ///     bytes that were read up to a maximum of |data_in_size|. |data_in| will
  ///     be NULL if |data_in_size| is zero.
  ///  2. Write filtered output data to |data_out| and set |data_out_written| to
  ///     the number of bytes that were written up to a maximum of
  ///     |data_out_size|. If no output data was written then all data must be
  ///     read from |data_in| (user must set |data_in_read| = |data_in_size|).
  ///  3. Return RESPONSE_FILTER_DONE if all output data was written or
  ///     RESPONSE_FILTER_NEED_MORE_DATA if output data is still pending.
  ///
  /// This function will be called repeatedly until the input buffer has been
  /// fully read (user sets |data_in_read| = |data_in_size|) and there is no
  /// more input data to filter (the resource response is complete). This
  /// function may then be called an additional time with an NULL input buffer
  /// if the user filled the output buffer (set |data_out_written| =
  /// |data_out_size|) and returned RESPONSE_FILTER_NEED_MORE_DATA to indicate
  /// that output data is still pending.
  ///
  /// Calls to this function will stop when one of the following conditions is
  /// met:
  ///
  ///  1. There is no more input data to filter (the resource response is
  ///     complete) and the user sets |data_out_written| = 0 or returns
  ///     RESPONSE_FILTER_DONE to indicate that all data has been written, or;
  ///  2. The user returns RESPONSE_FILTER_ERROR to indicate an error.
  ///
  /// Do not keep a reference to the buffers passed to this function.
  /// <c>cef_response_filter_status_t(CEF_CALLBACK* filter)(struct _cef_response_filter_t* self, void* data_in, size_t data_in_size, size_t* data_in_read, void* data_out, size_t data_out_size, size_t* data_out_written);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResponseFilter*, void*, nuint, nuint*, void*, nuint, nuint*, CefResponseFilterStatus> _Filter;

}
