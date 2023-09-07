namespace Cefaloid;

/// <summary>
/// Structure representing a point in floating point pixel coordinates.
/// This acts as an intermediate value when working with <see cref="CefPoint"/>s that
/// may have fractional values.
/// </summary>
/// <remarks>
/// This is not part of CEF, but is a helpful struct provided by Cefaloid.
/// </remarks>
/// <seealso cref="CefPoint"/>
/// <seealso cref="CefGeometryExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefFractionalPoint
  : IEquatable<CefFractionalPoint>,
    IComparable<CefFractionalPoint>,
    IComparisonOperators<CefFractionalPoint, CefFractionalPoint, bool>,
    IAdditionOperators<CefFractionalPoint, CefFractionalPoint, CefFractionalPoint>,
    ISubtractionOperators<CefFractionalPoint, CefFractionalPoint, CefFractionalPoint>,
    IAdditionOperators<CefFractionalPoint, CefSize, CefFractionalPoint>,
    ISubtractionOperators<CefFractionalPoint, CefSize, CefFractionalPoint>,
    IUnaryNegationOperators<CefFractionalPoint, CefFractionalPoint>,
    IEquatable<CefPoint>,
    IComparable<CefPoint>,
    IComparisonOperators<CefFractionalPoint, CefPoint, bool>,
    IAdditionOperators<CefFractionalPoint, CefPoint, CefFractionalPoint>,
    ISubtractionOperators<CefFractionalPoint, CefPoint, CefFractionalPoint>,
    IMultiplyOperators<CefFractionalPoint, float, CefFractionalPoint> {

  /// <summary>
  /// The X coordinate.
  /// Generally this refers to horizontal space, with 0 being the leftmost coordinate.
  /// </summary>
  /// <seealso cref="CefPoint.X"/>
  public float X;

  /// <summary>
  /// The Y coordinate.
  /// Generally this refers to vertical space, with 0 being the topmost coordinate.
  /// </summary>
  /// <seealso cref="CefPoint.Y"/>
  public float Y;

  /// <summary>
  /// Creates a new <see cref="CefFractionalPoint"/> with the given coordinates.
  /// </summary>
  /// <param name="x">The X coordinate.</param>
  /// <param name="y">The Y coordinate.</param>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefFractionalPoint(float x, float y)
    => (X, Y) = (x, y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefFractionalPoint(CefPoint point)
    => (X, Y) = (point.X, point.Y);

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
  public CefFractionalPoint Interpolate(CefFractionalPoint other, float t)
    => new(Helpers.Interpolate(X, other.X, t), Helpers.Interpolate(Y, other.Y, t));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefFractionalPoint GetMidpoint(CefFractionalPoint other)
    => (this + other) * 0.5f;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator CefPoint(CefFractionalPoint point)
    => new(
      (int) MathF.Round(point.X, MidpointRounding.ToPositiveInfinity),
      (int) MathF.Round(point.Y, MidpointRounding.ToPositiveInfinity)
    );

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator CefFractionalPoint(CefPoint point)
    => new(point.X, point.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefFractionalPoint other)
    => TupleEquals(X, Y, other.X, other.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefPoint other)
    => other.Equals(this);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefFractionalPoint other) {
    var xComparison = X.CompareTo(other.X);
    return xComparison == 0 ? Y.CompareTo(other.Y) : xComparison;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefPoint other) {
    var xComparison = X.CompareTo(other.X);
    return xComparison == 0 ? Y.CompareTo(other.Y) : xComparison;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefFractionalPoint left, CefFractionalPoint right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefFractionalPoint left, CefFractionalPoint right)
    => !(left == right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefFractionalPoint left, CefPoint right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefFractionalPoint left, CefPoint right)
    => !(left == right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefPoint left, CefFractionalPoint right)
    => right.Equals(left);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefPoint left, CefFractionalPoint right)
    => !(left == right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefFractionalPoint left, CefFractionalPoint right)
    => left.CompareTo(right) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefFractionalPoint left, CefFractionalPoint right)
    => left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefFractionalPoint left, CefFractionalPoint right)
    => left.CompareTo(right) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefFractionalPoint left, CefFractionalPoint right)
    => left.CompareTo(right) >= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefFractionalPoint left, CefPoint right)
    => left.CompareTo(right) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefFractionalPoint left, CefPoint right)
    => left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefFractionalPoint left, CefPoint right)
    => left.CompareTo(right) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefFractionalPoint left, CefPoint right)
    => left.CompareTo(right) >= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefPoint left, CefFractionalPoint right)
    => right.CompareTo(left) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefPoint left, CefFractionalPoint right)
    => right.CompareTo(left) >= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefPoint left, CefFractionalPoint right)
    => right.CompareTo(left) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefPoint left, CefFractionalPoint right)
    => right.CompareTo(left) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator +(CefFractionalPoint left, CefFractionalPoint right)
    => new(left.X + right.X, left.Y + right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator +(CefFractionalPoint left, CefPoint right)
    => new(left.X + right.X, left.Y + right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator +(CefPoint left, CefFractionalPoint right)
    => new(left.X + right.X, left.Y + right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator -(CefFractionalPoint left, CefFractionalPoint right)
    => new(left.X - right.X, left.Y - right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator -(CefFractionalPoint left, CefPoint right)
    => new(left.X - right.X, left.Y - right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator -(CefPoint left, CefFractionalPoint right)
    => new(left.X - right.X, left.Y - right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator -(CefFractionalPoint point)
    => new(-point.X, -point.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalPoint operator +(CefFractionalPoint left, CefSize right)
    => new(left.X + right.Width, left.Y + right.Height);

  public static CefFractionalPoint operator -(CefFractionalPoint left, CefSize right)
    => new(left.X - right.Width, left.Y - right.Height);

  public static CefFractionalPoint operator *(CefFractionalPoint left, float right)
    => new(left.X * right, left.Y * right);

  public override bool Equals(object? obj)
    => obj is CefFractionalPoint other && Equals(other);

  public override int GetHashCode() {
    unchecked {
      return (X.GetHashCode() * 397) ^ Y.GetHashCode();
    }
  }

  public override string ToString() => $"({X}, {Y})";

  public static implicit operator CefFractionalPoint(in ValueTuple<float, float> value)
    => Unsafe.As<ValueTuple<float, float>, CefFractionalPoint>(ref Unsafe.AsRef(value));

}
