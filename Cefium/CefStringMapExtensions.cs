namespace Cefium;

/// <inheritdoc cref="CefStringMap"/>
[PublicAPI]
public static class CefStringMapExtensions {

  /// <summary>
  /// Return the number of elements in the string map.
  /// <c>size_t(CEF_CALLBACK* get_size)(struct _cef_string_map_t* self);</c>
  /// </summary>
  public static unsafe int Size(ref this CefStringMap self) => CefStringMap._Size(self.AsPointer());

  /// <inheritdoc cref="CefStringMap._Find"/>
  public static unsafe bool Find(ref this CefStringMap self, ref CefString key, ref CefString value)
    => CefStringMap._Find(self.AsPointer(), key.AsPointer(), value.AsPointer()) != 0;

  /// <inheritdoc cref="CefStringMap._Key"/>
  public static unsafe bool Key(ref this CefStringMap self, int index, ref CefString key)
    => CefStringMap._Key(self.AsPointer(), index, key.AsPointer()) != 0;

  /// <inheritdoc cref="CefStringMap._Value"/>
  public static unsafe bool Value(ref this CefStringMap self, int index, ref CefString value)
    => CefStringMap._Value(self.AsPointer(), index, value.AsPointer()) != 0;

  /// <inheritdoc cref="CefStringMap._Append"/>
  public static unsafe bool Append(ref this CefStringMap self, ref CefString key, ref CefString value)
    => CefStringMap._Append(self.AsPointer(), key.AsPointer(), value.AsPointer()) != 0;

  /// <inheritdoc cref="CefStringMap._Clear"/>
  public static unsafe void Clear(ref this CefStringMap self) => CefStringMap._Clear(self.AsPointer());

  /// <inheritdoc cref="CefStringMap._Free"/>
  public static unsafe void Free(ref this CefStringMap self) => CefStringMap._Free(self.AsPointer());

}
