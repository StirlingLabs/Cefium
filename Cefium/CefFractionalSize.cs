namespace Cefium;

/// <summary>
/// Structure representing a size in floating point pixel coordinates.
/// This acts as an intermediate value when working with <see cref="CefSize"/>s that
/// may have fractional values.
/// </summary>
/// <remarks>
/// This is not part of CEF, but is a helpful struct provided by Cefium.
/// </remarks>
/// <seealso cref="CefSize"/>
/// <seealso cref="CefGeometryExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefFractionalSize
  : IEquatable<CefFractionalSize>,
    IComparable<CefFractionalSize>,
    IComparisonOperators<CefFractionalSize, CefFractionalSize, bool>,
    IAdditionOperators<CefFractionalSize, CefFractionalSize, CefFractionalSize>,
    ISubtractionOperators<CefFractionalSize, CefFractionalSize, CefFractionalSize>,
    IAdditionOperators<CefFractionalSize, CefSize, CefFractionalSize>,
    ISubtractionOperators<CefFractionalSize, CefSize, CefFractionalSize>,
    IEquatable<CefSize>,
    IComparable<CefSize>,
    IMultiplyOperators<CefFractionalSize, float, CefFractionalSize>,
    IDivisionOperators<CefFractionalSize, float, CefFractionalSize> {

  /// <summary>
  /// The width.
  /// </summary>
  /// <seealso cref="CefSize.Width"/>
  public float Width;

  /// <summary>
  /// The height.
  /// </summary>
  /// <seealso cref="CefSize.Height"/>
  public float Height;

  /// <summary>
  /// Creates a new instance of <see cref="CefFractionalSize"/> with the specified
  /// width and height.
  /// </summary>
  /// <param name="width">The width.</param>
  /// <param name="height">The height.</param>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefFractionalSize(float width, float height)
    => (Width, Height) = (width, height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefFractionalSize other)
    => Width.Equals(other.Width) && Height.Equals(other.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefFractionalSize other)
    => Width.CompareTo(other.Width) != 0
      ? Width.CompareTo(other.Width)
      : Height.CompareTo(other.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefFractionalSize left, CefFractionalSize right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefFractionalSize left, CefFractionalSize right)
    => !left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefFractionalSize left, CefFractionalSize right)
    => left.CompareTo(right) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefFractionalSize left, CefFractionalSize right)
    => left.CompareTo(right) >= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefFractionalSize left, CefFractionalSize right)
    => left.CompareTo(right) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefFractionalSize left, CefFractionalSize right)
    => left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator +(CefFractionalSize left, CefFractionalSize right)
    => new(left.Width + right.Width, left.Height + right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator -(CefFractionalSize left, CefFractionalSize right)
    => new(left.Width - right.Width, left.Height - right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator +(CefFractionalSize left, CefSize right)
    => new(left.Width + right.Width, left.Height + right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator -(CefFractionalSize left, CefSize right)
    => new(left.Width - right.Width, left.Height - right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefSize other)
    => Width.Equals(other.Width) && Height.Equals(other.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefSize other)
    => Width.CompareTo(other.Width) != 0
      ? Width.CompareTo(other.Width)
      : Height.CompareTo(other.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator *(CefFractionalSize left, float right)
    => new(left.Width * right, left.Height * right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefFractionalSize operator /(CefFractionalSize left, float right)
    => new(left.Width / right, left.Height / right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj)
    => obj is CefFractionalSize other && Equals(other);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode() {
    unchecked {
      return (Width.GetHashCode() * 397) ^ Height.GetHashCode();
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString() => $"[{Width}x{Height}]";

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator CefSize(CefFractionalSize size)
    => new((int) Math.Round(size.Width), (int) Math.Round(size.Height));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator CefFractionalSize(CefSize size)
    => new(size.Width, size.Height);

  public static implicit operator CefFractionalSize(in ValueTuple<float, float> value)
    => Unsafe.As<ValueTuple<float, float>, CefSize>(ref Unsafe.AsRef(value));

}
