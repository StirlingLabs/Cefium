namespace Cefium;

/// <inheritdoc cref="CefV8Context" />
[PublicAPI]
public static class CefV8ContextExtensions {

  /// <inheritdoc cref="CefV8Context._GetTaskRunner" />
  public static unsafe CefTaskRunner* GetTaskRunner(this ref CefV8Context self)
    => self._GetTaskRunner is not null ? self._GetTaskRunner(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Context._IsValid" />
  public static unsafe bool IsValid(this ref CefV8Context self)
    => self._IsValid is not null && self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Context._GetBrowser" />
  public static unsafe CefBrowser* GetBrowser(this ref CefV8Context self)
    => self._GetBrowser is not null ? self._GetBrowser(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Context._GetFrame" />
  public static unsafe CefFrame* GetFrame(this ref CefV8Context self)
    => self._GetFrame is not null ? self._GetFrame(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Context._GetGlobal" />
  public static unsafe CefV8Value* GetGlobal(this ref CefV8Context self)
    => self._GetGlobal is not null ? self._GetGlobal(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Context._Enter" />
  public static unsafe bool Enter(this ref CefV8Context self)
    => self._Enter is not null && self._Enter(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Context._Exit" />
  public static unsafe bool Exit(this ref CefV8Context self)
    => self._Exit is not null && self._Exit(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Context._IsSame" />
  public static unsafe bool IsSame(this ref CefV8Context self, ref CefV8Context that)
    => self._IsSame is not null && self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Context._Eval" />
  public static unsafe bool Eval(this ref CefV8Context self, ref CefString code, ref CefString scriptUrl, int startLine, ref CefV8Value* retval, ref CefV8Exception* exception)
    => self._Eval is not null && self._Eval(self.AsPointer(), code.AsPointer(), scriptUrl.AsPointer(), startLine, AsPointer(ref retval), AsPointer(ref exception)) != 0;

  /// <inheritdoc cref="CefV8Context._Eval" />
  public static unsafe bool Eval(this ref CefV8Context self, ref CefString code, CefString* scriptUrl, int startLine, ref CefV8Value* retval, ref CefV8Exception* exception)
    => self._Eval is not null && self._Eval(self.AsPointer(), code.AsPointer(), scriptUrl, startLine, AsPointer(ref retval), AsPointer(ref exception)) != 0;

  /// <inheritdoc cref="CefV8Context._Eval" />
  public static unsafe bool Eval(this ref CefV8Context self, CefString* code, ref CefString scriptUrl, int startLine, ref CefV8Value* retval, ref CefV8Exception* exception)
    => self._Eval is not null && self._Eval(self.AsPointer(), code, scriptUrl.AsPointer(), startLine, AsPointer(ref retval), AsPointer(ref exception)) != 0;

  /// <inheritdoc cref="CefV8Context._Eval" />
  public static unsafe bool Eval(this ref CefV8Context self, CefString* code, CefString* scriptUrl, int startLine, ref CefV8Value* retval, ref CefV8Exception* exception)
    => self._Eval is not null && self._Eval(self.AsPointer(), code, scriptUrl, startLine, AsPointer(ref retval), AsPointer(ref exception)) != 0;

}
