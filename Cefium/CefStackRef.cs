namespace Cefium;

[PublicAPI]
public struct CefStackRef<T>
  : IDisposable,
    IEquatable<CefStackRef<T>>,
    IEqualityOperators<CefStackRef<T>, CefStackRef<T>, bool>,
    IEquatable<object?>,
    IEqualityOperators<CefStackRef<T>, object?, bool>
  where T : unmanaged, ICefRefCountedBase<T> {

  public unsafe T* Pointer;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal unsafe CefStackRef(T* pointer)
    => Pointer = pointer;

  public unsafe ref T Target {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => ref Unsafe.AsRef<T>(Pointer);
  }

  public unsafe bool IsNull {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => Pointer == null;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe void Dispose() {
    if (!IsNull)
      Target.Release();
    Pointer = default;
  }

  [MustUseReturnValue]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe implicit operator CefStackRef<T>(CefRef<T> cefRef) {
    CefStackRef<T> cefStackRef = new(cefRef.Pointer);
    cefStackRef.Target.AddRef();
    return cefStackRef;
  }

  [MustUseReturnValue]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe implicit operator CefRef<T>(in CefStackRef<T> cefStackRef) {
    CefRef<T> cefRef = new(cefStackRef.Pointer);
    cefRef.Target.AddRef();
    return cefRef;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe implicit operator T*(in CefStackRef<T> cefStackRef)
    => cefStackRef.Pointer;

  [MustUseReturnValue]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe explicit operator CefStackRef<T>(T* pointer) {
    var x = new CefStackRef<T>(pointer);
    x.Target.AddRef();
    return x;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe bool Equals(CefStackRef<T> other)
    => Pointer == other.Pointer;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe bool Equals(CefRef<T> other)
    => Pointer == other.Pointer;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override unsafe bool Equals(object? obj)
    => obj is CefStackRef<T> onStack && Equals(onStack)
      || obj is CefRef<T> onHeap && Equals(onHeap)
      || obj is null && Pointer == null;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
  public override unsafe int GetHashCode()
    => Pointer == null ? 0 : ((nint) Pointer).GetHashCode();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefStackRef<T> left, CefStackRef<T> right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefStackRef<T> left, CefStackRef<T> right)
    => !left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefStackRef<T> left, CefRef<T> right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefStackRef<T> left, CefRef<T> right)
    => !left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefRef<T> left, CefStackRef<T> right)
    => right.Equals(left);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefRef<T> left, CefStackRef<T> right)
    => !right.Equals(left);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator ==(CefStackRef<T> left, T* right)
    => left.Pointer == right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator !=(CefStackRef<T> left, T* right)
    => left.Pointer != right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator ==(T* left, CefStackRef<T> right)
    => left == right.Pointer;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator !=(T* left, CefStackRef<T> right)
    => left != right.Pointer;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefStackRef<T> left, object? obj)
    => left.Equals(obj);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefStackRef<T> left, object? obj)
    => !left.Equals(obj);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(object? obj, CefStackRef<T> right)
    => right.Equals(obj);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(object? obj, CefStackRef<T> right)
    => !right.Equals(obj);

}
