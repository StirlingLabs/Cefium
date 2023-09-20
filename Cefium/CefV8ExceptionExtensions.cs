namespace Cefium;

/// <inheritdoc cref="CefV8Exception"/>
[PublicAPI]
public static class CefV8ExceptionExtensions {

  /// <inheritdoc cref="CefV8Exception._GetMessage"/>
  public static unsafe CefStringUserFree* GetMessage(ref this CefV8Exception self)
    => self._GetMessage(self.AsPointer());

  /// <inheritdoc cref="CefV8Exception._GetSourceLine"/>
  public static unsafe CefStringUserFree* GetSourceLine(ref this CefV8Exception self)
    => self._GetSourceLine(self.AsPointer());

  /// <inheritdoc cref="CefV8Exception._GetScriptResourceName"/>
  public static unsafe CefStringUserFree* GetScriptResourceName(ref this CefV8Exception self)
    => self._GetScriptResourceName(self.AsPointer());

  /// <inheritdoc cref="CefV8Exception._GetLineNumber"/>
  public static unsafe int GetLineNumber(ref this CefV8Exception self)
    => self._GetLineNumber(self.AsPointer());

  /// <inheritdoc cref="CefV8Exception._GetStartPosition"/>
  public static unsafe int GetStartPosition(ref this CefV8Exception self)
    => self._GetStartPosition(self.AsPointer());

  /// <inheritdoc cref="CefV8Exception._GetEndPosition"/>
  public static unsafe int GetEndPosition(ref this CefV8Exception self)
    => self._GetEndPosition(self.AsPointer());

  /// <inheritdoc cref="CefV8Exception._GetStartColumn"/>
  public static unsafe int GetStartColumn(ref this CefV8Exception self)
    => self._GetStartColumn(self.AsPointer());

  /// <inheritdoc cref="CefV8Exception._GetEndColumn"/>
  public static unsafe int GetEndColumn(ref this CefV8Exception self)
    => self._GetEndColumn(self.AsPointer());

}
