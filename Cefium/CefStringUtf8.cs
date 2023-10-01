namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 24)]
public struct CefStringUtf8 {

  // cef_string_utf8_t
  public unsafe sbyte* Str; // str @ 0, 8 bytes

  public uint Length; // length @ 8, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<sbyte*, void> _Dtor; // dtor @ 16, 8 bytes

}
