namespace Cefaloid;

/// <summary>
/// Structure representing a range.
/// <c>cef_range_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRange
  : IEquatable<CefRange>,
    IComparable<CefRange>,
    IComparisonOperators<CefRange, CefRange, bool>,
    IUnaryNegationOperators<CefRange, CefRange> {

  public int From;

  public int To;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefRange(int from, int to)
    => (From, To) = (from, to);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Deconstruct(out int from, out int to)
    => (from, to) = (From, To);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString() => $"{{{From}, {To}}}";

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefRange left, CefRange right) => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefRange left, CefRange right) => !left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefRange other) => TupleEquals(From, To, other.From, other.To);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj) => obj is CefRange other && Equals(other);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode() {
    unchecked {
      return (From * 397) ^ To;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefRange other) {
    var fromComparison = From.CompareTo(other.From);
    return fromComparison != 0
      ? fromComparison
      : To.CompareTo(other.To);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefRange operator -(CefRange value) => new(value.To, value.From);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefRange left, CefRange right) => left.CompareTo(right) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefRange left, CefRange right) => left.CompareTo(right) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefRange left, CefRange right) => left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefRange left, CefRange right) => left.CompareTo(right) >= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Normalize() {
    if (From > To)
      (From, To) = (To, From);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefRange ToNormalized()
    => From <= To
      ? this
      : new(To, From);

}
