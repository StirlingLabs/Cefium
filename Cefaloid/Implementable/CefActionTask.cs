namespace Cefaloid;

[PublicAPI]
[StructLayout(LayoutKind.Sequential)]
public struct CefActionTask : ICefRefCountedBase<CefActionTask> {

  public CefTask Task;

  public CefDelegateType Type;

  public unsafe void* pAction;

  public unsafe delegate*<void> StaticAction => (delegate*<void>) pAction;

  public unsafe delegate*<object?, void> ActionWithContext => (delegate*<object?, void>) pAction;

  public GCHandle Context;

  public static unsafe void Initialize(ref CefActionTask task) {
    task.Task._Execute = &Execute;
    task.Task.Base.RegisterDisposer(static (ref CefActionTask self) => {
      if (self.Type != CefDelegateType.Uninitialized && self.Context.IsAllocated)
        self.Context.Free();
    });
  }

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
  public static unsafe void Execute(CefTask* self) {
    var task = (CefActionTask*) self;
    switch (task->Type) {
      case CefDelegateType.Static:
        task->StaticAction();
        break;
      case CefDelegateType.WithContext:
        if (task->Context.IsAllocated)
          task->ActionWithContext(task->Context.Target!);
        else
          task->ActionWithContext(null!);
        break;
      default:
        // uninitialized or invalid
        break;
    }
  }

  public unsafe void SetAction(Action action) {
    var m = action.Method;
    pAction = (void*) m.MethodHandle.GetFunctionPointer();

    if (Type != CefDelegateType.Uninitialized && Context.IsAllocated)
      Context.Free();

    if (m.IsStatic)
      Type = CefDelegateType.Static;
    else {
      Type = CefDelegateType.WithContext;
      Context = GCHandle.Alloc(action.Target);
    }
  }

}
