namespace Cefaloid;

/// <inheritdoc cref="CefMainArgs"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMainArgsForLinux {
  public int ArgumentCount;

  public unsafe char** ArgumentVector;
}
