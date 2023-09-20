namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=104)]
public struct CefServerHandler : ICefRefCountedBase<CefServerHandler> { // cef_server_handler_t
  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServerHandler*,CefServer*,void> _OnServerCreated; // on_server_created @ 40, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServerHandler*,CefServer*,void> _OnServerDestroyed; // on_server_destroyed @ 48, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServerHandler*,CefServer*,int,void> _OnClientConnected; // on_client_connected @ 56, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServerHandler*,CefServer*,int,void> _OnClientDisconnected; // on_client_disconnected @ 64, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServerHandler*,CefServer*,int,CefString*,CefRequest*,void> _OnHttpRequest; // on_http_request @ 72, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServerHandler*,CefServer*,int,CefString*,CefRequest*,CefCallback*,void> _OnWebSocketRequest; // on_web_socket_request @ 80, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServerHandler*,CefServer*,int,void> _OnWebSocketConnected; // on_web_socket_connected @ 88, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServerHandler*,CefServer*,int,void*,uint,void> _OnWebSocketMessage; // on_web_socket_message @ 96, 8 bytes
}
