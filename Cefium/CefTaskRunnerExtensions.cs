namespace Cefium;

/// <inheritdoc cref="CefTaskRunner"/>
[PublicAPI]
public static class CefTaskRunnerExtensions {

  /// <inheritdoc cref="CefTaskRunner._IsSame"/>
  public static unsafe bool IsSame(ref this CefTaskRunner self, ref CefTaskRunner that) => self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefTaskRunner._BelongsToCurrentThread"/>
  public static unsafe bool BelongsToCurrentThread(ref this CefTaskRunner self) => self._BelongsToCurrentThread(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefTaskRunner._BelongsToThread"/>
  public static unsafe bool BelongsToThread(ref this CefTaskRunner self, CefThreadId threadId) => self._BelongsToThread(self.AsPointer(), threadId) != 0;

  /// <inheritdoc cref="CefTaskRunner._PostTask"/>
  public static unsafe bool PostTask(ref this CefTaskRunner self, ref CefTask task) => self._PostTask(self.AsPointer(), task.AsPointer()) != 0;

  /// <inheritdoc cref="CefTaskRunner._PostDelayedTask"/>
  public static unsafe bool PostDelayedTask(ref this CefTaskRunner self, ref CefTask task, long delayMs) => self._PostDelayedTask(self.AsPointer(), task.AsPointer(), delayMs) != 0;

}
