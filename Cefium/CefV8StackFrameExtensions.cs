namespace Cefium;

/// <inheritdoc cref="CefV8StackFrame"/>
[PublicAPI]
public static class CefV8StackFrameExtensions {

  /// <inheritdoc cref="CefV8StackFrame._IsValid"/>
  public static unsafe bool IsValid(ref this CefV8StackFrame self)
    => self._IsValid is not null && self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8StackFrame._GetScriptName"/>
  public static unsafe CefStringUserFree* GetScriptName(ref this CefV8StackFrame self)
    => self._GetScriptName is not null ? self._GetScriptName(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8StackFrame._GetScriptNameOrSourceUrl"/>
  public static unsafe CefStringUserFree* GetScriptNameOrSourceUrl(ref this CefV8StackFrame self)
    => self._GetScriptNameOrSourceUrl is not null ? self._GetScriptNameOrSourceUrl(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8StackFrame._GetFunctionName"/>
  public static unsafe CefStringUserFree* GetFunctionName(ref this CefV8StackFrame self)
    => self._GetFunctionName is not null ? self._GetFunctionName(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8StackFrame._GetLineNumber"/>
  public static unsafe int GetLineNumber(ref this CefV8StackFrame self)
    => self._GetLineNumber is not null ? self._GetLineNumber(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8StackFrame._GetColumn"/>
  public static unsafe int GetColumn(ref this CefV8StackFrame self)
    => self._GetColumn is not null ? self._GetColumn(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8StackFrame._IsEval"/>
  public static unsafe bool IsEval(ref this CefV8StackFrame self)
    => self._IsEval is not null && self._IsEval(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8StackFrame._IsConstructor"/>
  public static unsafe bool IsConstructor(ref this CefV8StackFrame self)
    => self._IsConstructor is not null && self._IsConstructor(self.AsPointer()) != 0;

}
