namespace Cefaloid;

/// <inheritdoc cref="CefV8Handler"/>
[PublicAPI]
public static class CefV8HandlerExtensions {

  /// <inheritdoc cref="CefV8Handler._Execute"/>
  public static unsafe bool Execute(ref this CefV8Handler self, ref CefString name, ref CefValue @object, nuint argumentsCount, ref CefValue* arguments, ref CefValue* retval, ref CefString exception)
    => self._Execute(self.AsPointer(), name.AsPointer(), @object.AsPointer(), argumentsCount, AsPointer(ref arguments), AsPointer(ref retval), exception.AsPointer()) != 0;

}
