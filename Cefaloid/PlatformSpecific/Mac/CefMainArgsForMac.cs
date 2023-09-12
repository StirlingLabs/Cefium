namespace Cefaloid;

/// <inheritdoc cref="CefMainArgs"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMainArgsForMac {

  /// <summary>
  /// The argument count.
  /// </summary>
  public int ArgumentCount;

  /// <summary>
  /// The arguments.
  /// </summary>
  public unsafe char** ArgumentVector;

}
