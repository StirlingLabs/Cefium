namespace Cefium;

/// <inheritdoc cref="CefV8Exception"/>
[PublicAPI]
public static class CefV8ExceptionExtensions {

  /// <inheritdoc cref="CefV8Exception._GetMessage"/>
  public static unsafe CefStringUserFree* GetMessage(ref this CefV8Exception self)
    => self._GetMessage is not null ? self._GetMessage(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Exception._GetSourceLine"/>
  public static unsafe CefStringUserFree* GetSourceLine(ref this CefV8Exception self)
    => self._GetSourceLine is not null ? self._GetSourceLine(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Exception._GetScriptResourceName"/>
  public static unsafe CefStringUserFree* GetScriptResourceName(ref this CefV8Exception self)
    => self._GetScriptResourceName is not null ? self._GetScriptResourceName(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Exception._GetLineNumber"/>
  public static unsafe int GetLineNumber(ref this CefV8Exception self)
    => self._GetLineNumber is not null ? self._GetLineNumber(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Exception._GetStartPosition"/>
  public static unsafe int GetStartPosition(ref this CefV8Exception self)
    => self._GetStartPosition is not null ? self._GetStartPosition(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Exception._GetEndPosition"/>
  public static unsafe int GetEndPosition(ref this CefV8Exception self)
    => self._GetEndPosition is not null ? self._GetEndPosition(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Exception._GetStartColumn"/>
  public static unsafe int GetStartColumn(ref this CefV8Exception self)
    => self._GetStartColumn is not null ? self._GetStartColumn(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Exception._GetEndColumn"/>
  public static unsafe int GetEndColumn(ref this CefV8Exception self)
    => self._GetEndColumn is not null ? self._GetEndColumn(self.AsPointer()) : default;

}
