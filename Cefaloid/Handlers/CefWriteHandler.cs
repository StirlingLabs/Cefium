namespace Cefaloid;

/// <summary>
/// Structure the client can implement to provide a custom stream writer. The
/// functions of this structure may be called on any thread.
/// <c>cef_write_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefWriteHandler : ICefRefCountedBase<CefWriteHandler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefWriteHandler() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Write raw binary data.
  /// <c>size_t(CEF_CALLBACK* write)(struct _cef_write_handler_t* self, const void* ptr, size_t size, size_t n)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefWriteHandler*, void*, nuint, nuint, nuint> _Write;

  /// <summary>
  /// Seek to the specified offset position. |whence| may be any one of
  /// SEEK_CUR, SEEK_END or SEEK_SET. Return zero on success and non-zero on
  /// failure.
  /// <c>int(CEF_CALLBACK* seek)(struct _cef_write_handler_t* self, int64 offset, int whence)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefWriteHandler*, long, int, int> _Seek;

  /// <summary>
  /// Return the current offset position.
  /// <c>int64(CEF_CALLBACK* tell)(struct _cef_write_handler_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefWriteHandler*, long> _Tell;

  /// <summary>
  /// Flush the stream.
  /// <c>int(CEF_CALLBACK* flush)(struct _cef_write_handler_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefWriteHandler*, int> _Flush;

  /// <summary>
  /// Return true (1) if this handler performs work like accessing the file
  /// system which may block. Used as a hint for determining the thread to
  /// access the handler from.
  /// <c>int(CEF_CALLBACK* may_block)(struct _cef_write_handler_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefWriteHandler*, int> _MayBlock;

}
