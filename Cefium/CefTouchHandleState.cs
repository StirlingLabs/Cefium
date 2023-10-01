namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 36)]
public struct CefTouchHandleState {

  // cef_touch_handle_state_t
  public int TouchHandleId; // touch_handle_id @ 0, 4 bytes

  public uint Flags; // flags @ 4, 4 bytes

  public int Enabled; // enabled @ 8, 4 bytes

  public CefHorizontalAlignment Orientation; // orientation @ 12, 4 bytes

  public int MirrorVertical; // mirror_vertical @ 16, 4 bytes

  public int MirrorHorizontal; // mirror_horizontal @ 20, 4 bytes

  public CefPoint Origin; // origin @ 24, 8 bytes

  public float Alpha; // alpha @ 32, 4 bytes

}
