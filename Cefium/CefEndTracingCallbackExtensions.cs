namespace Cefium;

/// <inheritdoc cref="CefEndTracingCallback"/>
[PublicAPI]
public static class CefEndTracingCallbackExtensions {

  /// <inheritdoc cref="CefEndTracingCallback._OnEndTracingComplete"/>
  public static unsafe bool OnEndTracingComplete(ref this CefEndTracingCallback self, ref CefString tracingFile) {
    if (self._OnEndTracingComplete is null) return false;

    self._OnEndTracingComplete(self.AsPointer(), tracingFile.AsPointer());
    return true;
  }

  /// <inheritdoc cref="Cef.EndTracing"/>
  public static void EndTracing(ref this CefEndTracingCallback self, ref CefString tracingFile)
    => Cef.EndTracing(ref tracingFile, ref self);

}
