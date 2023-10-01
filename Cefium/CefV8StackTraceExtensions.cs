namespace Cefium;

/// <inheritdoc cref="CefV8StackTrace" />
[PublicAPI]
public static class CefV8StackTraceExtensions {

  /// <inheritdoc cref="CefV8StackTrace._IsValid" />
  public static unsafe bool IsValid(ref this CefV8StackTrace self)
    => self._IsValid is not null && self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8StackTrace._GetFrameCount" />
  public static unsafe int GetFrameCount(ref this CefV8StackTrace self)
    => self._GetFrameCount is not null ? self._GetFrameCount(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8StackTrace._GetFrame" />
  public static unsafe CefV8StackFrame* GetFrame(ref this CefV8StackTrace self, int index)
    => self._GetFrame is not null ? self._GetFrame(self.AsPointer(), index) : default;

}
