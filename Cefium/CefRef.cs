namespace Cefium;

[PublicAPI]
public sealed class CefRef<T>
  : IDisposable,
    IEquatable<CefRef<T>>,
    IEqualityOperators<CefRef<T>, CefRef<T>, bool>,
    IEquatable<object?>,
    IEqualityOperators<CefRef<T>, object?, bool>
  where T : unmanaged, ICefRefCountedBase<T> {

  public unsafe T* Pointer;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal unsafe CefRef(T* pointer)
    => Pointer = pointer;

  ~CefRef() => Dispose();

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
    GC.SuppressFinalize(this);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe implicit operator T*(in CefRef<T> cefRef)
    => cefRef.Pointer;

  [MustUseReturnValue]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe explicit operator CefRef<T>(T* pointer) {
    var x = new CefRef<T>(pointer);
    x.Target.AddRef();
    return x;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe bool Equals(CefRef<T>? other) {
    var otherPointer = other is null ? null : other.Pointer;
    return Pointer == otherPointer;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe bool Equals(CefStackRef<T> other)
    => Pointer == other.Pointer;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override unsafe bool Equals(object? obj)
    => obj is CefRef<T> other && Equals(other)
      || obj is null && Pointer == null;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
  public override unsafe int GetHashCode()
    => Pointer == null ? 0 : ((nint) Pointer).GetHashCode();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator ==(CefRef<T>? left, CefRef<T>? right)
    => (left is null ? null : left.Pointer) == (right is null ? null : right.Pointer);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator !=(CefRef<T>? left, CefRef<T>? right)
    => (left is null ? null : left.Pointer) != (right is null ? null : right.Pointer);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator ==(CefRef<T>? left, T* right)
    => (left is null ? null : left.Pointer) == right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator !=(CefRef<T>? left, T* right)
    => (left is null ? null : left.Pointer) != right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator ==(T* left, CefRef<T>? right)
    => left == (right is null ? null : right.Pointer);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe bool operator !=(T* left, CefRef<T>? right) {
    var rightPointer = right is null ? null : right.Pointer;
    return left != rightPointer;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefRef<T>? left, object? obj)
    => left?.Equals(obj) ?? obj is null;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefRef<T>? left, object? obj)
    => !(left == obj);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(object? obj, CefRef<T>? right)
    => right?.Equals(obj) ?? obj is null;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(object? obj, CefRef<T>? right)
    => !(obj == right);

}
