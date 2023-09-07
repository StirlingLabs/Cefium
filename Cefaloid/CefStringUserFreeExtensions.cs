namespace Cefaloid;

/// <inheritdoc cref="CefStringUserFree"/>
[PublicAPI]
public static class CefStringUserFreeExtensions {

  /// <inheritdoc cref="CefStringUserFree.Free"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void Free(ref this CefStringUserFree str)
    => CefStringUserFree.Free(str.AsPointer());

}