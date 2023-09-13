namespace Cefaloid;

/// <summary>
/// Structure representing insets.
/// </summary>
/// <seealso cref="CefRect"/>
/// <seealso cref="CefPoint"/>
/// <seealso cref="CefSize"/>
/// <seealso cref="CefGeometryExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefInsets
  : IEquatable<CefInsets>,
    IComparable<CefInsets>,
    IComparisonOperators<CefInsets, CefInsets, bool>,
    IAdditionOperators<CefInsets, CefPoint, CefInsets>,
    ISubtractionOperators<CefInsets, CefPoint, CefInsets>,
    IAdditionOperators<CefInsets, CefSize, CefInsets>,
    ISubtractionOperators<CefInsets, CefSize, CefInsets> {

  public int Top;

  public int Left;

  public int Bottom;

  public int Right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int GetWidth() => Right - Left;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void SetWidth(int value) => Right = Left + value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int GetHeight() => Bottom - Top;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void SetHeight(int value) => Bottom = Top + value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefSize GetSize() => new(GetWidth(), GetHeight());

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetTopLeft() => new(Left, Top);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetTopRight() => new(Right, Top);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetBottomLeft() => new(Left, Bottom);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetBottomRight() => new(Right, Bottom);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetMiddleCenter()
    => new((int) MathF.FusedMultiplyAdd(0.5f, Right - Left, Left), (int) MathF.FusedMultiplyAdd(0.5f, Bottom - Top, Top));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetMiddleLeft()
    => new(Left, (int) MathF.FusedMultiplyAdd(0.5f, Bottom - Top, Top));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetMiddleRight()
    => new(Right, (int) MathF.FusedMultiplyAdd(0.5f, Bottom - Top, Top));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetTopCenter()
    => new((int) MathF.FusedMultiplyAdd(0.5f, Right - Left, Left), Top);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetBottomCenter()
    => new((int) MathF.FusedMultiplyAdd(0.5f, Right - Left, Left), Bottom);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetPointInside(float x, float y)
    => new((int) MathF.FusedMultiplyAdd(Right - Left, x, Left), (int) MathF.FusedMultiplyAdd(Bottom - Top, y, Top));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefInsets(int left, int top, int right, int bottom)
    => (Left, Top, Right, Bottom) = (left, top, right, bottom);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString()
    => $"({Left}, {Top}, {Right}, {Bottom})";

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Deconstruct(out int left, out int top, out int right, out int bottom)
    => (left, top, right, bottom) = (Left, Top, Right, Bottom);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj)
    => obj is CefInsets other && Equals(other);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode() {
    unchecked {
      var hashCode = Left;
      hashCode = (hashCode * 397) ^ Top;
      hashCode = (hashCode * 397) ^ Right;
      hashCode = (hashCode * 397) ^ Bottom;
      return hashCode;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefInsets other)
    => TupleEquals(Left, Top, Right, Bottom, other.Left, other.Top, other.Right, other.Bottom);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefInsets other)
    => Left == other.Left
      ? Top == other.Top
        ? Right == other.Right
          ? Bottom.CompareTo(other.Bottom)
          : Right.CompareTo(other.Right)
        : Top.CompareTo(other.Top)
      : Left.CompareTo(other.Left);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefInsets left, CefInsets right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefInsets left, CefInsets right)
    => !(left == right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefInsets left, CefInsets right)
    => left.CompareTo(right) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefInsets left, CefInsets right)
    => left.CompareTo(right) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefInsets left, CefInsets right)
    => left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefInsets left, CefInsets right)
    => left.CompareTo(right) >= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefInsets operator +(CefInsets left, CefPoint right)
    => new(left.Left + right.X, left.Top + right.Y, left.Right + right.X, left.Bottom + right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefInsets operator -(CefInsets left, CefPoint right)
    => new(left.Left - right.X, left.Top - right.Y, left.Right - right.X, left.Bottom - right.Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefInsets operator +(CefInsets left, CefSize right)
    => new(left.Left, left.Top, left.Right + right.Width, left.Bottom + right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefInsets operator -(CefInsets left, CefSize right)
    => new(left.Left, left.Top, left.Right - right.Width, left.Bottom - right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Shrink(int left, int top, int right, int bottom) {
    Left += left;
    Top += top;
    Right -= right;
    Bottom -= bottom;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Shrink(in CefInsets insets)
    => Shrink(insets.Left, insets.Top, insets.Right, insets.Bottom);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Shrink(int width, int height) {
    var halfWidthFloor = width >> 1;
    var halfWidthCeil = width - halfWidthFloor;
    var halfHeightFloor = height >> 1;
    var halfHeightCeil = height - halfHeightFloor;

    Left += halfWidthFloor;
    Top += halfHeightFloor;
    Right -= halfWidthCeil;
    Bottom -= halfHeightCeil;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Shrink(in CefSize size)
    => Shrink(size.Width, size.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Grow(int left, int top, int right, int bottom) {
    Left -= left;
    Top -= top;
    Right += right;
    Bottom += bottom;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Grow(in CefInsets insets)
    => Grow(insets.Left, insets.Top, insets.Right, insets.Bottom);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Grow(int width, int height) {
    var halfWidthFloor = width >> 1;
    var halfWidthCeil = width - halfWidthFloor;
    var halfHeightFloor = height >> 1;
    var halfHeightCeil = height - halfHeightFloor;

    Left -= halfWidthFloor;
    Top -= halfHeightFloor;
    Right += halfWidthCeil;
    Bottom += halfHeightCeil;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Grow(in CefSize size)
    => Grow(size.Width, size.Height);

  public static implicit operator CefInsets(in ValueTuple<int, int, int, int> value)
    => Unsafe.As<ValueTuple<int, int, int, int>, CefInsets>(ref Unsafe.AsRef(value));

}
