namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=72)]
public struct CefTestServerConnection : ICefRefCountedBase<CefTestServerConnection> { // _cef_test_server_connection_t
  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTestServerConnection*,CefString*,void*,uint,void> _SendHttp200Response; // send_http200response @ 40, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTestServerConnection*,void> _SendHttp404Response; // send_http404response @ 48, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTestServerConnection*,CefString*,void> _SendHttp500Response; // send_http500response @ 56, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTestServerConnection*,int,CefString*,void*,uint,CefStringMultimap*,void> _SendHttpResponse; // send_http_response @ 64, 8 bytes
}
