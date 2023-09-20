namespace Cefium;

/// <inheritdoc cref="CefV8Interceptor"/>
[PublicAPI]
public static class CefV8InterceptorExtensions {

  /// <inheritdoc cref="CefV8Interceptor._GetByName"/>
  public static unsafe bool GetByName(ref this CefV8Interceptor self, ref CefString name, ref CefV8Value @object, ref CefV8Value* retval, ref CefString exception)
    => self._GetByName(self.AsPointer(), ref name, ref @object, AsPointer(ref retval), ref exception) != 0;

  /// <inheritdoc cref="CefV8Interceptor._GetByIndex"/>
  public static unsafe bool GetByIndex(ref this CefV8Interceptor self, int index, ref CefV8Value @object, ref CefV8Value* retval, ref CefString exception)
    => self._GetByIndex(self.AsPointer(), index, ref @object, AsPointer(ref retval), ref exception) != 0;

  /// <inheritdoc cref="CefV8Interceptor._SetByName"/>
  public static unsafe bool SetByName(ref this CefV8Interceptor self, ref CefString name, ref CefV8Value @object, ref CefV8Value value, ref CefString exception)
    => self._SetByName(self.AsPointer(), ref name, ref @object, ref value, ref exception) != 0;

  /// <inheritdoc cref="CefV8Interceptor._SetByIndex"/>
  public static unsafe bool SetByIndex(ref this CefV8Interceptor self, int index, ref CefV8Value @object, ref CefV8Value value, ref CefString exception)
    => self._SetByIndex(self.AsPointer(), index, ref @object, ref value, ref exception) != 0;

}
