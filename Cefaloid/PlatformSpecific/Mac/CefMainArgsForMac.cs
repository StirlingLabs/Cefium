namespace Cefaloid;

/// <inheritdoc cref="CefMainArgs"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMainArgsForMac {
  public int ArgumentCount;

  public unsafe char** ArgumentVector;
}
