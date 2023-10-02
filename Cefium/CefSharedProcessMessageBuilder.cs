namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 72)]
public struct CefSharedProcessMessageBuilder : ICefRefCountedBase<CefSharedProcessMessageBuilder> {

  // cef_shared_process_message_builder_t
  [DllImport("cef", EntryPoint = "cef_shared_process_message_builder_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefSharedProcessMessageBuilder* _Create(CefString* arg0, uint arg1);

  public CefRefCountedBase Base; // base @ 0, 40 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefSharedProcessMessageBuilder*, int> _IsValid; // is_valid @ 40, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefSharedProcessMessageBuilder*, uint> _Size; // size @ 48, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefSharedProcessMessageBuilder*, void*> _Memory; // memory @ 56, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefSharedProcessMessageBuilder*, CefProcessMessage*> _Build; // build @ 64, 8 bytes

}
