namespace Cefium;

/// <inheritdoc cref="CefV8Accessor"/>
[PublicAPI]
public static class CefV8AccessorExtensions {

  /// <inheritdoc cref="CefV8Accessor._Get"/>
  public static unsafe bool Get(ref this CefV8Accessor self, ref CefString name, ref CefV8Value @object, ref CefV8Value* retval, ref CefString exception)
    => self._Get(self.AsPointer(), ref name, ref @object, AsPointer(ref retval), ref exception) != 0;

  /// <inheritdoc cref="CefV8Accessor._Set"/>
  public static unsafe bool Set(ref this CefV8Accessor self, ref CefString name, ref CefV8Value @object, ref CefV8Value value, ref CefString exception)
    => self._Set(self.AsPointer(), ref name, ref @object, ref value, ref exception) != 0;

}
