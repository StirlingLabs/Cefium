using System.Runtime.Versioning;

namespace Cefium;

/// <summary>
/// This is a union of all of the variants of
/// <c>cef_main_args_t</c> - since the struct
/// is only passed by reference, CEF will only
/// read the relevant data for the platform.
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
