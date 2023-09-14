namespace Cefaloid;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=80)]
public struct CefWaitableEvent : ICefRefCountedBase<CefWaitableEvent> { // cef_waitable_event_t
  [DllImport("cef", EntryPoint = "cef_waitable_event_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefWaitableEvent* _Create(int arg0,int arg1);


  public CefRefCountedBase Base; // base @ 0, 40 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWaitableEvent*,void> _Reset; // reset @ 40, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWaitableEvent*,void> _Signal; // signal @ 48, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWaitableEvent*,int> _IsSignaled; // is_signaled @ 56, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWaitableEvent*,void> _Wait; // wait @ 64, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefWaitableEvent*,int,int> _TimedWait; // timed_wait @ 72, 8 bytes
}
