#if SCRAP
using System.Runtime.InteropServices;

namespace Cefium.Tests;

[StructLayout(LayoutKind.Sequential)]
public struct WindowsBlendFunction {

  public byte BlendOp;

  public byte BlendFlags;

  public byte SourceConstantAlpha;

  public byte AlphaFormat;

}

[Flags]
public enum UpdateLayeredWindowFlags : uint {

  ColorKey = 1,

  Alpha = 1 << 1,

  Opaque = 1 << 2,

  NoResize = 1 << 3

}

[StructLayout(LayoutKind.Sequential)]
public struct WindowMargins {

  public int Left;

  public int Right;

  public int Top;

  public int Bottom;

}

[Flags]
public enum DwmBlurBehindFlags {

  Enable = 1,

  BlurRegion = 1 << 1,

  TransitionOnMaximized = 1 << 2

}

[StructLayout(LayoutKind.Sequential)]
public struct DwmBlurBehind {

  public DwmBlurBehindFlags Flags;

  private int _Enable;

  public bool Enable {
    get => _Enable != 0;
    set => _Enable = value ? 1 : 0;
  }

  public unsafe void* HRgnBlur;

  private int _TransitionOnMaximized;

  private bool TransitionOnMaximized {
    get => _TransitionOnMaximized != 0;
    set => _TransitionOnMaximized = value ? 1 : 0;
  }

}

public partial class Tests {

  [DllImport("User32", EntryPoint = "GetDC", SetLastError = true)]
  public static extern unsafe void* GetDC(void* hWnd);

  [DllImport("User32", EntryPoint = "UpdateLayeredWindow", SetLastError = true)]
  public static extern unsafe bool UpdateLayeredWindow(
    void* hWnd,
    void* hDcDest,
    CefPoint* dest, CefSize* size,
    void* hDcSrc,
    CefPoint* src, uint crKey,
    WindowsBlendFunction* blend,
    UpdateLayeredWindowFlags flags
  );

  [DllImport("DwmApi", EntryPoint = "DwmExtendFrameIntoClientArea", SetLastError = true)]
  public static extern unsafe nint DwmExtendFrameIntoClientArea(void* hWnd, WindowMargins* pMarInset);

  [DllImport("DwmApi", EntryPoint = "DwmEnableBlurBehindWindow", SetLastError = true)]
  public static extern unsafe nint DwmEnableBlurBehindWindow(void* hWnd, DwmBlurBehind* pBlurBehind);

  [DllImport("User32", EntryPoint = "SetLayeredWindowAttributes", SetLastError = true)]
  public static extern unsafe bool SetLayeredWindowAttributes(void* hWnd, uint crKey, byte bAlpha, UpdateLayeredWindowFlags dwFlags);

}
#endif
