namespace Cefaloid;

/// <inheritdoc cref="CefEndTracingCallback"/>
[PublicAPI]
public static class CefEndTracingCallbackExtensions {

  /// <inheritdoc cref="CefEndTracingCallback._OnEndTracingComplete"/>
  public static unsafe void OnEndTracingComplete(ref this CefEndTracingCallback self, ref CefString tracingFile)
    => self._OnEndTracingComplete(self.AsPointer(), tracingFile.AsPointer());

  /// <inheritdoc cref="Cef.EndTracing"/>
  public static void EndTracing(ref this CefEndTracingCallback self, ref CefString tracingFile)
    => Cef.EndTracing(ref tracingFile, ref self);

}
