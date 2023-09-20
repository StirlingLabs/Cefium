namespace Cefium;

/// <inheritdoc cref="CefMainArgs"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMainArgsForLinux {

  /// <summary>
  /// The argument count.
  /// </summary>
  public int ArgumentCount;

  /// <summary>
  /// The arguments.
  /// </summary>
  public unsafe char** ArgumentVector;

}
