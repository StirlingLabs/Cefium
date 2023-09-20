namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=56)]
public struct CefTestServer : ICefRefCountedBase<CefTestServer> { // cef_test_server_t
  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTestServer*,void> _Stop; // stop @ 40, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTestServer*,CefString*> _GetOrigin; // get_origin @ 48, 8 bytes
}
