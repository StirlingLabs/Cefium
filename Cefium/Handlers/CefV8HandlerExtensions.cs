﻿namespace Cefium;

/// <inheritdoc cref="CefV8Handler"/>
[PublicAPI]
public static class CefV8HandlerExtensions {

  /// <inheritdoc cref="CefV8Handler._Execute"/>
  public static unsafe bool Execute(ref this CefV8Handler self, ref CefString name, ref CefV8Value @object, nuint argumentsCount, ref CefV8Value* arguments, ref CefV8Value* retval, ref CefString exception) {
    if (self._Execute is null) return false;

    return self._Execute(self.AsPointer(), name.AsPointer(), @object.AsPointer(), argumentsCount, AsPointer(ref arguments), AsPointer(ref retval), exception.AsPointer()) != 0;
  }

}
