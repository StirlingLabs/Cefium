namespace Cefium;

/// <summary>
/// Structure used to write data to a stream. The functions of this structure
/// may be called on any thread.
/// <c>cef_stream_writer_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefStreamWriter : ICefRefCountedBase<CefStreamWriter> {

  /// <inheritdoc cref="CefStreamWriter"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefStreamWriter() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_stream_writer_t object for a file.
  /// <c>CEF_EXPORT cef_stream_writer_t* cef_stream_writer_create_for_file(const cef_string_t* fileName)</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_stream_writer_create_for_file", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefStreamWriter* CreateForFile(CefString* fileName);

  /// <summary>
  /// Create a new cef_stream_writer_t object for a custom handler.
  /// <c>CEF_EXPORT cef_stream_writer_t* cef_stream_writer_create_for_handler(cef_write_handler_t* handler)</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_stream_writer_create_for_handler", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefStreamWriter* CreateForHandler(CefWriteHandler* handler);

  /// <summary>
  /// Write raw binary data.
  /// <c>size_t(CEF_CALLBACK* write)(struct _cef_stream_writer_t* self, const void* ptr, size_t size, size_t n)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamWriter*, void*, nuint, nuint, nuint> _Write;

  /// <summary>
  /// Seek to the specified offset position. |whence| may be any one of
  /// SEEK_CUR, SEEK_END or SEEK_SET. Returns zero on success and non-zero on
  /// failure.
  /// <c>int(CEF_CALLBACK* seek)(struct _cef_stream_writer_t* self, int64 offset, int whence)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamWriter*, long, int, int> _Seek;

  /// <summary>
  /// Return the current offset position.
  /// <c>int64(CEF_CALLBACK* tell)(struct _cef_stream_writer_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamWriter*, long> _Tell;

  /// <summary>
  /// Flush the stream.
  /// <c>int(CEF_CALLBACK* flush)(struct _cef_stream_writer_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamWriter*, int> _Flush;

  /// <summary>
  /// Returns true (1) if this writer performs work like accessing the file
  /// system which may block. Used as a hint for determining the thread to
  /// access the writer from.
  /// <c>int(CEF_CALLBACK* may_block)(struct _cef_stream_writer_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStreamWriter*, int> _MayBlock;

}
