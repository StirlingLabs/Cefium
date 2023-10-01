namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 24)]
public struct CefStringWide {

  // cef_string_wide_t
  public unsafe char* Str; // str @ 0, 8 bytes

  public uint Length; // length @ 8, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<char*, void> _Dtor; // dtor @ 16, 8 bytes

}
