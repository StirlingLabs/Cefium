#pragma warning disable CS8909 // these function pointer comparisons should be valid
using System.Collections.Concurrent;

namespace Cefium;

[PublicAPI]
public static class CefRefCountedBaseExtensions {

  internal static readonly ConcurrentDictionary<nint, nuint> RefCounts = new();

  internal static readonly ConcurrentDictionary<nint, LinkedList<Action<nint>>> Disposers = new();

  public static unsafe void RegisterDisposer(in this CefRefCountedBase ptr, Action<nint> disposer)
    => RegisterDisposer((nint) Unsafe.AsPointer(ref Unsafe.AsRef(ptr)), disposer);

  public static unsafe void RegisterDisposer<T>(in this CefRefCountedBase ptr, RefAction<T> disposer)
    where T : unmanaged, ICefRefCountedBase<T>
    => RegisterDisposer((nint) Unsafe.AsPointer(ref Unsafe.AsRef(ptr)),
      ptr => disposer(ref Unsafe.AsRef<T>((void*) ptr)));

  public static unsafe bool UnregisterDisposer(in this CefRefCountedBase ptr, Action<nint> disposer)
    => UnregisterDisposer((nint) Unsafe.AsPointer(ref Unsafe.AsRef(ptr)), disposer);

  public static void RegisterDisposer(nint ptr, Action<nint> disposer)
    => Disposers.AddOrUpdate(ptr,
      static (_, disposer) => new() {disposer},
      static (_, disposers, disposer) => {
        lock (disposers) {
          disposers.AddLast(disposer);
          return disposers;
        }
      },
      disposer
    );

  public static bool UnregisterDisposer(nint ptr, Action<nint> disposer) {
    if (!Disposers.TryGetValue(ptr, out var disposers))
      return false;

    lock (disposers) {
      var found = disposers.Find(disposer);
      if (found is not null)
        disposers.Remove(found);
      else
        return false;

      if (disposers.Count == 0)
        Disposers.TryRemove(new(ptr, disposers));
    }

    return true;
  }

  internal static bool ExecuteDisposers(nint ptr) {
    if (!Disposers.TryRemove(ptr, out var disposers))
      return false;

    lock (disposers) {
      foreach (var disposer in disposers) {
        try { disposer.Invoke(ptr); }
        catch {
          // TODO: error handling
        }
      }
    }

    return true;
  }

  private static unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRefCountedBase*, void>
    _pfnAddRef = &AddRef;

  private static unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRefCountedBase*, int>
    _pfnRelease = &Release;

  private static unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRefCountedBase*, int>
    _pfnHasOneRef = &HasOneRef;

  private static unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRefCountedBase*, int>
    _pfnHasAtLeastOneRef = &HasAtLeastOneRef;

  public static unsafe void InitializeBase<T>(ref this T self) where T : unmanaged, ICefRefCountedBase<T> {
    ref var baseRef = ref self.GetBaseRef();
    baseRef.Size = (nuint) Unsafe.SizeOf<T>();
    baseRef._AddRef = _pfnAddRef;
    baseRef._Release = _pfnRelease;
    baseRef._HasOneRef = _pfnHasOneRef;
    baseRef._HasAtLeastOneRef = _pfnHasAtLeastOneRef;
  }

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
  private static unsafe void AddRef(CefRefCountedBase* self)
    => AddRefImpl(self);

  public static unsafe void AddRef<T>(ref this T self) where T : unmanaged, ICefRefCountedBase<T>
    => AddRefImpl(self.GetBasePointer());

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static unsafe void AddRefImpl(CefRefCountedBase* self) {
    if (self->_AddRef != _pfnAddRef) {
      self->_AddRef(self);
      return;
    }

    RefCounts.AddOrUpdate((nint) self,
      _ => 1,
      (_, count) => count + 1
    );
  }

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
  private static unsafe int Release(CefRefCountedBase* self)
    => ReleaseImpl(self);

  public static unsafe int Release<T>(ref this T self) where T : unmanaged, ICefRefCountedBase<T>
    => ReleaseImpl(self.GetBasePointer());

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static unsafe int ReleaseImpl(CefRefCountedBase* self) {
    if (self->_Release != _pfnRelease)
      return self->_Release(self);

    var ptr = (nint) self;
    var count = RefCounts.AddOrUpdate(ptr,
      _ => 0,
      (_, c) => c - 1
    );

    if (count > 0)
      return (int) Math.Min(int.MaxValue, count);

    while (!RefCounts.TryRemove(new(ptr, 0))) {
      if (!RefCounts.TryGetValue(ptr, out var newCount))
        return 0;

      return (int) Math.Min(int.MaxValue, newCount);
    }

    ExecuteDisposers(ptr);
    NativeMemory.Free((void*) ptr);

    return (int) Math.Min(int.MaxValue, count);
  }

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
  private static unsafe int HasOneRef(CefRefCountedBase* self)
    => HasOneRefImpl(self);

  public static unsafe int HasOneRef<T>(ref this T self) where T : unmanaged, ICefRefCountedBase<T>
    => HasOneRefImpl(self.GetBasePointer());

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static unsafe int HasOneRefImpl(CefRefCountedBase* self) {
    if (self->_HasOneRef != _pfnHasOneRef)
      return self->_HasOneRef(self);

    return RefCounts.TryGetValue((nint) self, out var count) && count == 1 ? 1 : 0;
  }

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
  private static unsafe int HasAtLeastOneRef(CefRefCountedBase* self)
    => HasAtLeastOneRefImpl(self);

  public static unsafe int HasAtLeastOneRef<T>(ref this T self) where T : unmanaged, ICefRefCountedBase<T>
    => HasAtLeastOneRefImpl(self.GetBasePointer());

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static unsafe int HasAtLeastOneRefImpl(CefRefCountedBase* self) {
    if (self->_HasAtLeastOneRef != _pfnHasAtLeastOneRef)
      return self->_HasAtLeastOneRef(self);

    return RefCounts.TryGetValue((nint) self, out var count) && count >= 1 ? 1 : 0;
  }

  public static unsafe int GetManagedRefCount<T>(ref this T self) where T : unmanaged, ICefRefCountedBase<T>
    => RefCounts.TryGetValue((nint) self.AsPointer(), out var count) ? (int) count : 0;

  public static unsafe CefRef<T> CreateManagedRef<T>(ref T p) where T : unmanaged, ICefRefCountedBase<T>
    => new(p.AsPointer());

  [MustUseReturnValue]
  public static unsafe CefStackRef<T> CreateStackRef<T>(ref T p) where T : unmanaged, ICefRefCountedBase<T>
    => new(p.AsPointer());

  public static ref CefRefCountedBase GetBaseRef<T>(ref this T self) where T : unmanaged, ICefRefCountedBase<T>
    => ref Unsafe.As<T, CefRefCountedBase>(ref self);

  public static unsafe CefRefCountedBase* GetBasePointer<T>(ref this T self) where T : unmanaged, ICefRefCountedBase<T>
    => (CefRefCountedBase*) self.AsPointer();

}
