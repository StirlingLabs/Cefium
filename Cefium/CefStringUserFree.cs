namespace Cefium;

/// <inheritdoc cref="CefString"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public unsafe struct CefStringUserFree {

  internal CefString _Str;

#pragma warning disable CS9084

  public ref void* Str => ref _Str.Str;

  public ref nuint Length => ref _Str.Length;

#pragma warning restore CS9084

  public bool HasDestructor {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _Str.HasDestructor;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Destroy()
    => _Str.Destroy();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySpan<byte> AsByteSpan()
    => _Str.AsByteSpan();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySpan<char> AsCharSpan()
    => _Str.AsCharSpan();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySpan<int> AsIntSpan()
    => _Str.AsIntSpan();

  /// <summary>
  /// These functions free the string structure allocated by the associated
  /// alloc function. Any string contents will first be cleared.
  /// <c>CEF_EXPORT void cef_string_userfree_utf16_free(cef_string_userfree_utf8_t str);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_userfree_utf16_free", CallingConvention = CallingConvention.Cdecl)]
  public static extern void Free(CefStringUserFree* str);

}
