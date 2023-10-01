namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 136)]
public struct CefZipReader : ICefRefCountedBase<CefZipReader> {

  // cef_zip_reader_t
  [DllImport("cef", EntryPoint = "cef_zip_reader_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefZipReader* _Create(CefStreamReader* arg0);

  public CefRefCountedBase Base; // base @ 0, 40 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, int> _MoveToFirstFile; // move_to_first_file @ 40, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, int> _MoveToNextFile; // move_to_next_file @ 48, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, CefString*, int, int> _MoveToFile; // move_to_file @ 56, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, int> _Close; // close @ 64, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, CefString*> _GetFileName; // get_file_name @ 72, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, int> _GetFileSize; // get_file_size @ 80, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, CefBaseTime> _GetFileLastModified; // get_file_last_modified @ 88, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, CefString*, int> _OpenFile; // open_file @ 96, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, int> _CloseFile; // close_file @ 104, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, void*, uint, int> _ReadFile; // read_file @ 112, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, int> _Tell; // tell @ 120, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefZipReader*, int> _Eof; // eof @ 128, 8 bytes

}
