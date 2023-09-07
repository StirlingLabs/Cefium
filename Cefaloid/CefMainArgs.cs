using System.Runtime.Versioning;

namespace Cefaloid;

/// <summary>
/// <c>cef_main_args_t</c>
/// </summary>
/// <seealso cref="CefMainArgsForWindows"/>
/// <seealso cref="CefMainArgsForLinux"/>
/// <seealso cref="CefMainArgsForMac"/>
[PublicAPI, StructLayout(LayoutKind.Explicit)]
public struct CefMainArgs {

  public static readonly unsafe int Size
    = OperatingSystem.IsWindows() ? sizeof(CefMainArgsForWindows)
    : OperatingSystem.IsLinux() ? sizeof(CefMainArgsForLinux)
    : OperatingSystem.IsMacOS() ? sizeof(CefMainArgsForMac)
    : throw new PlatformNotSupportedException();

  [FieldOffset(0), SupportedOSPlatform("windows")]
  public CefMainArgsForWindows ForWindows;

  [FieldOffset(0), SupportedOSPlatform("linux")]
  public CefMainArgsForLinux ForLinux;

  [FieldOffset(0), SupportedOSPlatform("macos")]
  public CefMainArgsForMac ForMac;

}