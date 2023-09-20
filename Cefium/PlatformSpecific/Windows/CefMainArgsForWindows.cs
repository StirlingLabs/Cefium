namespace Cefium;

/// <inheritdoc cref="CefMainArgs"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMainArgsForWindows {

  /// <summary>
  /// <c>HINSTANCE</c>
  /// </summary>
  public nint InstanceHandle;

}
