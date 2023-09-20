namespace Cefium;

/// <summary>
/// A delegate-based implementation of <see cref="CefTask"/>.
/// </summary>
[PublicAPI]
[StructLayout(LayoutKind.Sequential)]
public struct CefActionTask : ICefRefCountedBase<CefActionTask> {

  /// <summary>
  /// The CefTask header.
  /// </summary>
  public CefTask Task;

  internal CefDelegateType Type;

  internal unsafe void* pAction;

  internal unsafe delegate*<void> StaticAction => (delegate*<void>) pAction;

  internal unsafe delegate*<object?, void> ActionWithContext => (delegate*<object?, void>) pAction;

  internal GCHandle Context;

  static unsafe void ICefRefCountedBase<CefActionTask>.Initialize(ref CefActionTask task) {
    task.Task._Execute = &Execute;
    task.Task.Base.RegisterDisposer(static (ref CefActionTask self) => {
      if (self.Type != CefDelegateType.Uninitialized && self.Context.IsAllocated)
        self.Context.Free();
    });
  }

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
  internal static unsafe void Execute(CefTask* self) {
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

  /// <summary>
  /// Sets the action to be executed.
  /// </summary>
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
