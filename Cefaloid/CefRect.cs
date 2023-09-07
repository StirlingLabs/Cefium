namespace Cefaloid;

/// <summary>
/// Structure representing a rectangle.
/// </summary>
/// <seealso cref="CefInsets"/>
/// <seealso cref="CefPoint"/>
/// <seealso cref="CefSize"/>
/// <seealso cref="CefGeometryExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public unsafe struct CefRect
  : IEquatable<CefRect>,
    IComparable<CefRect>,
    IComparisonOperators<CefRect, CefRect, bool>,
    IAdditionOperators<CefRect, CefPoint, CefRect>,
    ISubtractionOperators<CefRect, CefPoint, CefRect>,
    IAdditionOperators<CefRect, CefSize, CefRect>,
    ISubtractionOperators<CefRect, CefSize, CefRect> {

  public CefPoint Point;

  public CefSize Size;

#pragma warning disable CS9084
  public ref int X {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => ref Point.X;
  }

  public ref int Y {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => ref Point.Y;
  }

  public ref int Width {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => ref Size.Width;
  }

  public ref int Height {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => ref Size.Height;
  }
#pragma warning restore CS9084

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetTopLeft() => new(X, Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetTopRight() => new(X + Width, Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetBottomLeft() => new(X, Y + Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetBottomRight() => new(X + Width, Y + Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetMiddleCenter()
    => new((int) MathF.FusedMultiplyAdd(Width, 0.5f, X), (int) MathF.FusedMultiplyAdd(Height, 0.5f, Y));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetMiddleLeft()
    => new(X, (int) MathF.FusedMultiplyAdd(Height, 0.5f, Y));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetMiddleRight()
    => new(X + Width, (int) MathF.FusedMultiplyAdd(Height, 0.5f, Y));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetCenter()
    => new((int) MathF.FusedMultiplyAdd(Width, 0.5f, X), (int) MathF.FusedMultiplyAdd(Height, 0.5f, Y));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetCenterLeft()
    => new(X, (int) MathF.FusedMultiplyAdd(Height, 0.5f, Y));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetCenterRight()
    => new(X + Width, (int) MathF.FusedMultiplyAdd(Height, 0.5f, Y));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetTopCenter()
    => new((int) MathF.FusedMultiplyAdd(Width, 0.5f, X), Y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetBottomCenter()
    => new((int) MathF.FusedMultiplyAdd(Width, 0.5f, X), Y + Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefPoint GetPointInside(float x, float y)
    => new((int) MathF.FusedMultiplyAdd(Width, x, X), (int) MathF.FusedMultiplyAdd(Height, y, Y));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefRect(CefPoint point, CefSize size)
    => (Point, Size) = (point, size);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefRect(int x, int y, int width, int height)
    => (X, Y, Width, Height) = (x, y, width, height);

  public override string ToString()
    => $"[({X}, {Y}) {Width}x{Height}]";

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Deconstruct(out int x, out int y, out int width, out int height)
    => (x, y, width, height) = (X, Y, Width, Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj)
    => obj is CefRect other && Equals(other);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode() {
    unchecked {
      return (Point.GetHashCode() * 397) ^ Size.GetHashCode();
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefRect other)
    => TupleEquals(X, Y, Width, Height, other.X, other.Y, other.Width, other.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefRect other)
    => Point.CompareTo(other.Point) == 0 ? Size.CompareTo(other.Size) : Point.CompareTo(other.Point);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefRect left, CefRect right)
    => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefRect left, CefRect right)
    => !(left == right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefRect operator +(CefRect left, CefPoint right)
    => new(left.X + right.X, left.Y + right.Y, left.Width, left.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefRect operator -(CefRect left, CefPoint right)
    => new(left.X - right.X, left.Y - right.Y, left.Width, left.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefRect operator +(CefRect left, CefSize right)
    => new(left.X, left.Y, left.Width + right.Width, left.Height + right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefRect operator -(CefRect left, CefSize right)
    => new(left.X, left.Y, left.Width - right.Width, left.Height - right.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefRect left, CefRect right)
    => left.CompareTo(right) < 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefRect left, CefRect right)
    => left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefRect left, CefRect right)
    => left.CompareTo(right) > 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefRect left, CefRect right)
    => left.CompareTo(right) >= 0;

  public static implicit operator CefRect(in ValueTuple<int, int, int, int> value)
    => Unsafe.As<ValueTuple<int, int, int, int>, CefRect>(ref Unsafe.AsRef(value));

  public static implicit operator CefRect(in ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>> value)
    => Unsafe.As<ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>, CefRect>(ref Unsafe.AsRef(value));

}
