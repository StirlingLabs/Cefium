#pragma warning disable CS8909 // these function pointer comparisons should be valid
using System.Collections.Concurrent;

namespace Cefaloid;

[PublicAPI]
public static class CefRefCountedBaseExtensions {

  public static readonly ConcurrentDictionary<nint, nuint> RefCounts = new();

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

    // ReSharper disable once InvertIf
    if (count == 0) {
      RefCounts.TryRemove(ptr, out _);
      NativeMemory.Free((void*) ptr);
    }

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
