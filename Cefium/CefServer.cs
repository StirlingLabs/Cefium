namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=144)]
public struct CefServer : ICefRefCountedBase<CefServer> { // _cef_server_t
  [DllImport("cef", EntryPoint = "cef_server_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe void _Create(CefString* arg0,uint arg1,int arg2,CefServerHandler* arg3);


  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,CefTaskRunner*> _GetTaskRunner; // get_task_runner @ 40, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,void> _Shutdown; // shutdown @ 48, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int> _IsRunning; // is_running @ 56, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,CefString*> _GetAddress; // get_address @ 64, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int> _HasConnection; // has_connection @ 72, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int,int> _IsValidConnection; // is_valid_connection @ 80, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int,CefString*,void*,uint,void> _SendHttp200Response; // send_http200response @ 88, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int,void> _SendHttp404Response; // send_http404response @ 96, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int,CefString*,void> _SendHttp500Response; // send_http500response @ 104, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int,int,CefString*,int,CefStringMultimap*,void> _SendHttpResponse; // send_http_response @ 112, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int,void*,uint,void> _SendRawData; // send_raw_data @ 120, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int,void> _CloseConnection; // close_connection @ 128, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefServer*,int,void*,uint,void> _SendWebSocketMessage; // send_web_socket_message @ 136, 8 bytes
}
