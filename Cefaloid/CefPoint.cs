namespace Cefaloid;

/// <summary>
/// Structure representing a point.
/// </summary>
/// <seealso cref="CefRect"/>
/// <seealso cref="CefInsets"/>
/// <seealso cref="CefSize"/>
/// <seealso cref="CefFractionalPoint"/>
/// <seealso cref="CefGeometryExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPoint
  : IEquatable<CefPoint>,
    IComparable<CefPoint>,
    IComparisonOperators<CefPoint, CefPoint, bool>,
    IAdditionOperators<CefPoint, CefPoint, CefPoint>,
    ISubtractionOperators<CefPoint, CefPoint, CefPoint>,
    IAdditionOperators<CefPoint, CefSize, CefPoint>,
    ISubtractionOperators<CefPoint, CefSize, CefPoint>,
    IMultiplyOperators<CefPoint, int, CefPoint>,
    IMultiplyOperators<CefPoint, float, CefFractionalPoint>,
    IDivisionOperators<CefPoint, float, CefFractionalPoint>,
    IUnaryNegationOperators<CefPoint, CefPoint> {

  public int X;

  public int Y;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint(int x, int y) {
    X = x;
    Y = y;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public float GetDistanceSquared(CefPoint other)
    => MathF.Pow(X - other.X, 2) + MathF.Pow(Y - other.Y, 2);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public float GetDistance(CefPoint other)
    => MathF.Sqrt(GetDistanceSquared(other));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public float GetDistanceSquared(CefFractionalPoint other)
    => MathF.Pow(X - other.X, 2) + MathF.Pow(Y - other.Y, 2);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public float GetDistance(CefFractionalPoint other)
    => MathF.Sqrt(GetDistanceSquared(other));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString() {
    return $"({X}, {Y})";
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Deconstruct(out int x, out int y)
    => (x, y) = (X, Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj)
    => obj is CefPoint point && Equals(point);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefPoint other)
    => TupleEquals(X, Y, other.X, other.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode()
    => HashCode.Combine(X, Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefPoint other)
    => X == other.X ? Y.CompareTo(other.Y) : X.CompareTo(other.X);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefPoint left, CefPoint right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefPoint left, CefPoint right)
    => !(left == right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefPoint left, CefPoint right)
    => left.CompareTo(right) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefPoint left, CefPoint right)
    => left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefPoint left, CefPoint right)
    => left.CompareTo(right) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefPoint left, CefPoint right)
    => left.CompareTo(right) >= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefPoint operator +(CefPoint left, CefPoint right)
    => new(left.X + right.X, left.Y + right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefPoint operator -(CefPoint left, CefPoint right)
    => new(left.X - right.X, left.Y - right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefPoint operator *(CefPoint left, int right)
    => new(left.X * right, left.Y * right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator *(CefPoint left, float right)
    => new(left.X * right, left.Y * right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator /(CefPoint left, float right)
    => new(left.X / right, left.Y / right);

  public static CefPoint operator -(CefPoint value)
    => new(-value.X, -value.Y);

  public static CefPoint operator +(CefPoint left, CefSize right)
    => new(left.X + right.Width, left.Y + right.Height);

  public static CefPoint operator -(CefPoint left, CefSize right)
    => new(left.X - right.Width, left.Y - right.Height);

  public static implicit operator CefPoint(in ValueTuple<int, int> value)
    => Unsafe.As<ValueTuple<int, int>, CefPoint>(ref Unsafe.AsRef(value));

}
