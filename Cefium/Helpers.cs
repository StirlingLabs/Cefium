using System.ComponentModel;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using InlineIL;

namespace Cefium;

/// <summary>
/// Helper methods used throughout Cefium.
/// </summary>
[PublicAPI]
public static class Helpers {

  // TODO: .NET 8 intrinsic for interpolate
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static float Interpolate(float from, float to, float t)
    => MathF.FusedMultiplyAdd(to - from, t, from);

  // TODO: .NET 8 intrinsic for interpolate
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static double Interpolate(double from, double to, double t)
    => Math.FusedMultiplyAdd(to - from, t, from);

  // TODO: .NET 8 intrinsic for interpolate
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static Vector128<float> Interpolate(in this Vector128<float> from, in Vector128<float> to, float t) {
    var delta = Vector128.Subtract(to, from);
    if (AdvSimd.Arm64.IsSupported)
      return AdvSimd.Arm64.FusedMultiplyAddByScalar(from, delta, Vector64.Create(t));
    if (AdvSimd.IsSupported)
      return AdvSimd.FusedMultiplyAdd(from, delta, Vector128.Create(t));

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (Fma.IsSupported)
      return Fma.MultiplyAdd(delta, Vector128.Create(t), from);

    return Vector128.Add(Vector128.Multiply(delta, t), from);
  }

  // TODO: .NET 8 intrinsic for interpolate
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static Vector256<float> Interpolate(in this Vector256<float> from, in Vector256<float> to, float t) {
    var delta = Vector256.Subtract(to, from);

    if (Fma.IsSupported)
      return Fma.MultiplyAdd(delta, Vector256.Create(t), from);

    var scaled = Vector256.Multiply(delta, t);
    return Vector256.Add(scaled, from);
  }

  /// <summary>
  /// Performs parallel equality checks on pairs of numerical values.
  /// Logically it performs the following in parallel;
  /// <paramref name="a1"/> is <paramref name="a2"/>
  /// and <paramref name="b1"/> is <paramref name="b2"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static bool TupleEquals<T>(T a1, T b1, T a2, T b2)
    where T
    : ISubtractionOperators<T, T, T>
    , IBitwiseOperators<T, T, T>
    , IEqualityOperators<T, T, bool>
    , IAdditiveIdentity<T, T> {
    unchecked {
      var a = a1 - a2;
      var b = b1 - b2;
      return (a | b) == T.AdditiveIdentity;
    }
  }

  /// <summary>
  /// Performs parallel equality checks on triples of numerical values.
  /// Logically it performs the following in parallel;
  /// <paramref name="a1"/> is <paramref name="a2"/>
  /// and <paramref name="b1"/> is <paramref name="b2"/>
  /// and <paramref name="c1"/> is <paramref name="c2"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static bool TupleEquals<T>(T a1, T b1, T c1, T a2, T b2, T c2)
    where T
    : ISubtractionOperators<T, T, T>
    , IBitwiseOperators<T, T, T>
    , IEqualityOperators<T, T, bool>
    , IAdditiveIdentity<T, T> {
    unchecked {
      var a = a1 - a2;
      var b = b1 - b2;
      var c = c1 - c2;
      return (a | b | c) == T.AdditiveIdentity;
    }
  }

  /// <summary>
  /// Performs parallel equality checks on quadruples of numerical values.
  /// Logically it performs the following in parallel;
  /// <paramref name="a1"/> is <paramref name="a2"/>
  /// and <paramref name="b1"/> is <paramref name="b2"/>
  /// and <paramref name="c1"/> is <paramref name="c2"/>
  /// and <paramref name="d1"/> is <paramref name="d2"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static bool TupleEquals<T>(T a1, T b1, T c1, T d1, T a2, T b2, T c2, T d2)
    where T
    : ISubtractionOperators<T, T, T>
    , IBitwiseOperators<T, T, T>
    , IEqualityOperators<T, T, bool>
    , IAdditiveIdentity<T, T> {
    unchecked {
      var a = a1 - a2;
      var b = b1 - b2;
      var c = c1 - c2;
      var d = d1 - d2;
      return (a | b | c | d) == T.AdditiveIdentity;
    }
  }

  internal static unsafe T* AsPointer<T>(ref this T self) where T : unmanaged
    => (T*) Unsafe.AsPointer(ref self);

  internal static ref T AsRef<T>(ref this T self) where T : unmanaged
    => ref Unsafe.AsRef(self);

  internal static unsafe void** AsPointer(ref void* self) {
    IL.Emit.Ldarg_0();
    IL.Emit.Ret();
    throw IL.Unreachable();
  }

  internal static unsafe void*** AsPointer(ref void** self) {
    IL.Emit.Ldarg_0();
    IL.Emit.Ret();
    throw IL.Unreachable();
  }

  internal static unsafe T** AsPointer<T>(ref T* self) where T : unmanaged {
    IL.Emit.Ldarg_0();
    IL.Emit.Ret();
    throw IL.Unreachable();
  }

  internal static unsafe T*** AsPointer<T>(ref T** self) where T : unmanaged {
    IL.Emit.Ldarg_0();
    IL.Emit.Ret();
    throw IL.Unreachable();
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static void Add<T>(this Queue<T> queue, T item)
    => queue.Enqueue(item);

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static void Add<T>(this Stack<T> stack, T item)
    => stack.Push(item);

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static void Add<T>(this LinkedList<T> stack, T item)
    => stack.AddLast(item);

}
