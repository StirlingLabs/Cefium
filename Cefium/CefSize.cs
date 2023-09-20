namespace Cefium;

/// <summary>
/// Structure representing a size.
/// </summary>
/// <seealso cref="CefRect"/>
/// <seealso cref="CefFractionalSize"/>
/// <seealso cref="CefInsets"/>
/// <seealso cref="CefPoint"/>
/// <seealso cref="CefFractionalPoint"/>
/// <seealso cref="CefGeometryExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSize
  : IEquatable<CefSize>,
    IComparable<CefSize>,
    IComparisonOperators<CefSize, CefSize, bool>,
    IAdditionOperators<CefSize, CefSize, CefSize>,
    ISubtractionOperators<CefSize, CefSize, CefSize>,
    IMultiplyOperators<CefSize, float, CefFractionalSize>,
    IDivisionOperators<CefSize, float, CefFractionalSize> {

  /// <summary>
  /// The width.
  /// </summary>
  public int Width;

  /// <summary>
  /// The height.
  /// </summary>
  public int Height;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefSize(int width, int height) {
    Width = width;
    Height = height;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString()
    => $"[{Width}x{Height}]";

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Deconstruct(out int width, out int height)
    => (width, height) = (Width, Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj)
    => obj is CefSize other && Equals(other);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode() {
    unchecked {
      return (Width * 397) ^ Height;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefSize other)
    => TupleEquals(Width, Height, other.Width, other.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefSize other)
    => Width == other.Width ? Height.CompareTo(other.Height) : Width.CompareTo(other.Width);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefSize left, CefSize right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefSize left, CefSize right)
    => !(left == right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefSize left, CefSize right)
    => left.CompareTo(right) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefSize left, CefSize right)
    => left.CompareTo(right) >= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefSize left, CefSize right)
    => left.CompareTo(right) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefSize left, CefSize right)
    => left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefSize operator +(CefSize left, CefSize right)
    => new(left.Width + right.Width, left.Height + right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefSize operator -(CefSize left, CefSize right)
    => new(left.Width - right.Width, left.Height - right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator *(CefSize left, float right)
    => new(left.Width * right, left.Height * right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator *(float left, CefSize right)
    => new(left * right.Width, left * right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator /(CefSize left, float right)
    => new(left.Width / right, left.Height / right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator /(float left, CefSize right)
    => new(left / right.Width, left / right.Height);

  public static implicit operator CefSize(in ValueTuple<int, int> value)
    => Unsafe.As<ValueTuple<int, int>, CefSize>(ref Unsafe.AsRef(value));

}
