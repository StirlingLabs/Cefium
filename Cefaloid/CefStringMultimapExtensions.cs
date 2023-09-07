namespace Cefaloid;

/// <inheritdoc cref="CefStringMultimap"/>
[PublicAPI]
public static class CefStringMultimapExtensions {

  /// <inheritdoc cref="CefStringMultimap._Size"/>
  public static nuint Size(ref this CefStringMultimap self) => CefStringMultimap._Size(ref self);

  /// <inheritdoc cref="CefStringMultimap._FindCount"/>
  public static nuint FindCount(ref this CefStringMultimap self, ref CefString key)
    => CefStringMultimap._FindCount(ref self, ref key);

  /// <inheritdoc cref="CefStringMultimap._Enumerate"/>
  public static bool Enumerate(ref this CefStringMultimap self, ref CefString key, nuint valueIndex, ref CefString value)
    => CefStringMultimap._Enumerate(ref self, ref key, valueIndex, ref value) != 0;

  /// <inheritdoc cref="CefStringMultimap._Key"/>
  public static bool Key(ref this CefStringMultimap self, nuint index, ref CefString key)
    => CefStringMultimap._Key(ref self, index, ref key) != 0;

  /// <inheritdoc cref="CefStringMultimap._Value"/>
  public static bool Value(ref this CefStringMultimap self, nuint index, ref CefString value)
    => CefStringMultimap._Value(ref self, index, ref value) != 0;

  /// <inheritdoc cref="CefStringMultimap._Append"/>
  public static void Append(ref this CefStringMultimap self, ref CefString key, ref CefString value)
    => CefStringMultimap._Append(ref self, ref key, ref value);

  /// <inheritdoc cref="CefStringMultimap._Clear"/>
  public static void Clear(ref this CefStringMultimap self) => CefStringMultimap._Clear(ref self);

  /// <inheritdoc cref="CefStringMultimap._Free"/>
  public static void Free(ref this CefStringMultimap self) => CefStringMultimap._Free(ref self);

}
