namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=72)]
public struct CefThread : ICefRefCountedBase<CefThread> { // cef_thread_t
  [DllImport("cef", EntryPoint = "cef_thread_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefThread* _Create(CefString* arg0,CefThreadPriority arg1,CefMessageLoopType arg2,int arg3,CefComInitMode arg4);


  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefThread*,CefTaskRunner*> _GetTaskRunner; // get_task_runner @ 40, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefThread*,ulong> _GetPlatformThreadId; // get_platform_thread_id @ 48, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefThread*,void> _Stop; // stop @ 56, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefThread*,int> _IsRunning; // is_running @ 64, 8 bytes
}
