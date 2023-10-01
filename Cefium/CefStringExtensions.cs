namespace Cefium;

/// <inheritdoc cref="CefString"/>
[PublicAPI]
public static class CefStringExtensions {

  /// <summary>
  /// Reinterpret casts a <see cref="CefStringUserFree"/> as a <see cref="CefString"/>.
  /// </summary>
  public static ref CefString AsCefString(ref this CefStringUserFree self)
    => ref Unsafe.As<CefStringUserFree, CefString>(ref self);

  /// <summary>
  /// Reinterpret casts a <see cref="CefString"/> as a <see cref="CefStringUserFree"/>.
  /// </summary>
  public static ref CefStringUserFree AsCefStringUserFree(ref this CefString self)
    => ref Unsafe.As<CefString, CefStringUserFree>(ref self);

  /// <summary>
  /// These functions set string values. If |copy| is true (1) the value will be
  /// copied instead of referenced. It is up to the user to properly manage
  /// the lifespan of references.
  /// <c>CEF_EXPORT int cef_string_utf16_set(const char16* src, size_t src_len, cef_string_utf16_t* output, int copy);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_string_utf16_set", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe int _SetUtf16(char* src, nuint srcLen, CefString* output, int copy);

  /// <inheritdoc cref="_SetUtf16"/>
  public static unsafe bool SetCefString(this string src, ref CefString output, bool copy = true) {
    // assuming CEF_STRING_TYPE_UTF16
    fixed (char* pSrc = src)
      return _SetUtf16(pSrc, (nuint) src.Length, output.AsPointer(), copy ? 1 : 0) != 0;
  }

  /// <inheritdoc cref="_SetUtf16"/>
  public static unsafe bool SetCefString(this string src, CefString* output, bool copy = true) {
    // assuming CEF_STRING_TYPE_UTF16
    fixed (char* pSrc = src)
      return _SetUtf16(pSrc, (nuint) src.Length, output, copy ? 1 : 0) != 0;
  }

  /// <inheritdoc cref="_SetUtf16"/>
  public static ref CefString CreateCefString(this string str, [UnscopedRef] out CefString cefStr) {
    // assuming CEF_STRING_TYPE_UTF16
    cefStr = new();
    if (!str.SetCefString(ref cefStr))
      throw FailedToSetCefString();

    return ref cefStr;
  }

  /// <inheritdoc cref="_SetUtf16"/>
  public static unsafe ref CefString CreateCefString(this string str, CefString* cefStr) {
    // assuming CEF_STRING_TYPE_UTF16
    *cefStr = new();
    if (!str.SetCefString(cefStr))
      throw FailedToSetCefString();

    return ref Unsafe.AsRef<CefString>(cefStr);
  }

  /// <inheritdoc cref="_SetUtf16"/>
  public static CefString CreateCefString(this string str) {
    // assuming CEF_STRING_TYPE_UTF16
    str.CreateCefString(out var cefStr);
    return cefStr;
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  private static InvalidOperationException FailedToSetCefString()
    => new("Failed to set CEF string.");

}
