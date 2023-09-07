namespace Cefaloid;

/// <summary>
/// Structure used to read data from a stream. The functions of this structure
/// may be called on any thread.
/// <c>cef_stream_reader_t</c>
/// </summary>
/// <seealso cref="CefStreamReaderExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefStreamReader : ICefRefCountedBase<CefStreamReader> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefStreamReader() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_stream_reader_t object from a file.
  /// <c>CEF_EXPORT cef_stream_reader_t* cef_stream_reader_create_for_file(const cef_string_t* fileName);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_stream_reader_create_for_file", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefStreamReader* CreateForFile(in CefString fileName);

  /// <summary>
  /// Create a new cef_stream_reader_t object from data.
  /// <c>CEF_EXPORT cef_stream_reader_t* cef_stream_reader_create_for_data(void* data, size_t size);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_stream_reader_create_for_data", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefStreamReader* CreateForData(void* data, nuint size);

  /// <summary>
  /// Create a new cef_stream_reader_t object from a custom handler.
  /// <c>CEF_EXPORT cef_stream_reader_t* cef_stream_reader_create_for_handler(cef_read_handler_t* handler);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_stream_reader_create_for_handler", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefStreamReader* CreateForHandler(CefReadHandler* handler);

  /// <summary>
  /// Read raw binary data.
  /// <c>size_t(CEF_CALLBACK* read)(struct _cef_stream_reader_t* self, void* ptr, size_t size, size_t n);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamReader*, void*, nuint, nuint, nuint> _Read;

  /// <summary>
  /// Seek to the specified offset position. |whence| may be any one of
  /// SEEK_CUR, SEEK_END or SEEK_SET. Returns zero on success and non-zero on
  /// failure.
  /// <c>int(CEF_CALLBACK* seek)(struct _cef_stream_reader_t* self, int64 offset, int whence);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamReader*, long, int, int> _Seek;

  /// <summary>
  /// Return the current offset position.
  /// <c>int64(CEF_CALLBACK* tell)(struct _cef_stream_reader_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamReader*, long> _Tell;

  /// <summary>
  /// Return non-zero if at end of file.
  /// <c>int(CEF_CALLBACK* eof)(struct _cef_stream_reader_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamReader*, int> _Eof;

  /// <summary>
  /// Returns true (1) if this reader performs work like accessing the file
  /// system which may block. Used as a hint for determining the thread to
  /// access the reader from.
  /// <c>int(CEF_CALLBACK* may_block)(struct _cef_stream_reader_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamReader*, int> _MayBlock;

}
