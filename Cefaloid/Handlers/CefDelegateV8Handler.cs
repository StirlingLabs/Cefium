namespace Cefaloid;

[PublicAPI]
[StructLayout(LayoutKind.Sequential)]
public struct CefDelegateV8Handler : ICefRefCountedBase<CefDelegateV8Handler> {

  public CefV8Handler V8Handler;

  public CefDelegateType Type;

  public unsafe void* pFunc;

  public unsafe delegate*<CefString*, CefV8Value*, nuint, CefV8Value**, CefV8Value**, CefString*, bool> StaticFunc
    => (delegate*<CefString*, CefV8Value*, nuint, CefV8Value**, CefV8Value**, CefString*, bool>) pFunc;

  public unsafe delegate*<object?, CefString*, CefV8Value*, nuint, CefV8Value**, CefV8Value**, CefString*, bool> FuncWithContext
    => (delegate*<object?, CefString*, CefV8Value*, nuint, CefV8Value**, CefV8Value**, CefString*, bool>) pFunc;

  public GCHandle Context;

  public static unsafe void Initialize(ref CefDelegateV8Handler task) {
    task.V8Handler._Execute = &Execute;
    task.V8Handler.Base.RegisterDisposer(static (ref CefDelegateV8Handler self) => {
      if (self.Type != CefDelegateType.Uninitialized && self.Context.IsAllocated)
        self.Context.Free();
    });
  }

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
  public static unsafe int Execute(CefV8Handler* self, CefString* name, CefV8Value* @object, nuint argumentsCount, CefV8Value** arguments, CefV8Value** retval, CefString* exception) {
    var task = (CefDelegateV8Handler*) self;
    switch (task->Type) {
      case CefDelegateType.Static:
        return task->StaticFunc(name, @object, argumentsCount, arguments, retval, exception) ? 1 : 0;

      case CefDelegateType.WithContext:
        if (task->Context.IsAllocated)
          return task->FuncWithContext(task->Context.Target!, name, @object, argumentsCount, arguments, retval, exception) ? 1 : 0;

        "Cefaloid: Calling delegate context was lost."
          .CreateCefString(exception);
        return 0;

      default:
        // uninitialized or invalid
        return 0;
    }
  }

  public unsafe delegate bool Handler(
    CefString* name,
    CefV8Value* @object,
    nuint argumentsCount,
    CefV8Value** arguments,
    CefV8Value** retval,
    CefString* exception
  );

  public unsafe void SetHandler(Handler handler) {
    var m = handler.Method;
    pFunc = (void*) m.MethodHandle.GetFunctionPointer();

    if (Type != CefDelegateType.Uninitialized && Context.IsAllocated)
      Context.Free();

    if (m.IsStatic)
      Type = CefDelegateType.Static;
    else {
      Type = CefDelegateType.WithContext;
      Context = GCHandle.Alloc(handler.Target);
    }
  }

}
