namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=48)]
public struct CefTestServerHandler : ICefRefCountedBase<CefTestServerHandler> { // cef_test_server_handler_t
  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTestServerHandler*,CefTestServer*,CefRequest*,CefTestServerConnection*,int> _OnTestServerRequest; // on_test_server_request @ 40, 8 bytes
}
