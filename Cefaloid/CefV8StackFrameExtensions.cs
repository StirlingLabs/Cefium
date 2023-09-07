namespace Cefaloid;

/// <inheritdoc cref="CefV8StackFrame"/>
[PublicAPI]
public static class CefV8StackFrameExtensions {

  /// <inheritdoc cref="CefV8StackFrame._IsValid"/>
  public static unsafe bool IsValid(ref this CefV8StackFrame self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8StackFrame._GetScriptName"/>
  public static unsafe CefStringUserFree* GetScriptName(ref this CefV8StackFrame self) => self._GetScriptName(self.AsPointer());

  /// <inheritdoc cref="CefV8StackFrame._GetScriptNameOrSourceUrl"/>
  public static unsafe CefStringUserFree* GetScriptNameOrSourceUrl(ref this CefV8StackFrame self) => self._GetScriptNameOrSourceUrl(self.AsPointer());

  /// <inheritdoc cref="CefV8StackFrame._GetFunctionName"/>
  public static unsafe CefStringUserFree* GetFunctionName(ref this CefV8StackFrame self) => self._GetFunctionName(self.AsPointer());

  /// <inheritdoc cref="CefV8StackFrame._GetLineNumber"/>
  public static unsafe int GetLineNumber(ref this CefV8StackFrame self) => self._GetLineNumber(self.AsPointer());

  /// <inheritdoc cref="CefV8StackFrame._GetColumn"/>
  public static unsafe int GetColumn(ref this CefV8StackFrame self) => self._GetColumn(self.AsPointer());

  /// <inheritdoc cref="CefV8StackFrame._IsEval"/>
  public static unsafe bool IsEval(ref this CefV8StackFrame self) => self._IsEval(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8StackFrame._IsConstructor"/>
  public static unsafe bool IsConstructor(ref this CefV8StackFrame self) => self._IsConstructor(self.AsPointer()) != 0;

}
