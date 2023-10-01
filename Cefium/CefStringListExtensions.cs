namespace Cefium;

/// <inheritdoc cref="CefStringList"/>
[PublicAPI]
public static class CefStringListExtensions {

  /// <inheritdoc cref="CefStringList._Size"/>
  public static unsafe nuint Size(this ref CefStringList self)
    => CefStringList._Size(self.AsPointer());

  /// <inheritdoc cref="CefStringList._Value"/>
  public static unsafe CefString* Value(this ref CefStringList self, nuint index)
    => CefStringList._Value(self.AsPointer(), index);

  /// <inheritdoc cref="CefStringList._Append"/>
  public static unsafe ref CefStringList Append(this ref CefStringList self, ref CefString value) {
    CefStringList._Append(self.AsPointer(), value.AsPointer());
    return ref self;
  }

  /// <inheritdoc cref="CefStringList._Clear"/>
  public static unsafe void Clear(this ref CefStringList self)
    => CefStringList._Clear(self.AsPointer());

  /// <inheritdoc cref="CefStringList._Free"/>
  public static unsafe void Free(this ref CefStringList self)
    => CefStringList._Free(self.AsPointer());

  /// <inheritdoc cref="CefStringList._Copy"/>
  public static unsafe CefStringList* Copy(this ref CefStringList self)
    => CefStringList._Copy(self.AsPointer());

}
