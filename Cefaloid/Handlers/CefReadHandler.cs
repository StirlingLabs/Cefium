namespace Cefaloid;

/// <summary>
/// Structure the client can implement to provide a custom stream reader. The
/// functions of this structure may be called on any thread.
/// <c>cef_read_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefReadHandler : ICefRefCountedBase<CefReadHandler> {

  /// <inheritdoc cref="CefReadHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefReadHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Read raw binary data.
  /// <c>size_t(CEF_CALLBACK* read)(struct _cef_read_handler_t* self, void* ptr, size_t size, size_t n)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefReadHandler*, void*, nuint, nuint, nuint> _Read;

  /// <summary>
  /// Seek to the specified offset position. |whence| may be any one of
  /// SEEK_CUR, SEEK_END or SEEK_SET. Return zero on success and non-zero on
  /// failure.
  /// <c>int(CEF_CALLBACK* seek)(struct _cef_read_handler_t* self, int64 offset, int whence)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefReadHandler*, long, int, int> _Seek;

  /// <summary>
  /// Return the current offset position.
  /// <c>int64(CEF_CALLBACK* tell)(struct _cef_read_handler_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefReadHandler*, long> _Tell;

  /// <summary>
  /// Return non-zero if at end of file.
  /// <c>int(CEF_CALLBACK* eof)(struct _cef_read_handler_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefReadHandler*, int> _Eof;

  /// <summary>
  /// Return true (1) if this handler performs work like accessing the file
  /// system which may block. Used as a hint for determining the thread to
  /// access the handler from.
  /// <c>int(CEF_CALLBACK* may_block)(struct _cef_read_handler_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefReadHandler*, int> _MayBlock;

}
