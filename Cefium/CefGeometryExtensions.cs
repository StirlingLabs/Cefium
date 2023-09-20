namespace Cefium;

/// <summary>
/// Extension methods for <see cref="CefPoint"/>, <see cref="CefSize"/>, <see cref="CefRect"/>, and <see cref="CefInsets"/>.
/// This class primarily provides reinterpretation between the aforementioned structs as well as tuples.
/// </summary>
/// <remarks>
/// This is not part of CEF, but is a helpful set of extensions provided by Cefium.
/// </remarks>
/// <seealso cref="CefPoint"/>
/// <seealso cref="CefSize"/>
/// <seealso cref="CefRect"/>
/// <seealso cref="CefInsets"/>
/// <seealso cref="CefFractionalPoint"/>
[PublicAPI]
public static class CefGeometryExtensions {

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefRect ToCefRect(in this CefInsets insets)
    => new(insets.Left, insets.Top, insets.Right - insets.Left, insets.Bottom - insets.Top);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefInsets ToCefInsets(in this CefRect rect)
    => new(rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref CefInsets AsCefInsets(ref this (int Left, int Top, int Right, int Bottom) rect)
    => ref Unsafe.As<(int Left, int Top, int Right, int Bottom), CefInsets>(ref Unsafe.AsRef(rect));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref readonly CefInsets AsCefInsetsReadOnly(in this (int Left, int Top, int Right, int Bottom) rect)
    => ref Unsafe.As<(int Left, int Top, int Right, int Bottom), CefInsets>(ref Unsafe.AsRef(rect));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref CefRect AsCefRect(ref this (int X, int Y, int Width, int Height) rect)
    => ref Unsafe.As<(int X, int Y, int Width, int Height), CefRect>(ref Unsafe.AsRef(rect));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref readonly CefRect AsCefRectReadOnly(in this (int X, int Y, int Width, int Height) rect)
    => ref Unsafe.As<(int X, int Y, int Width, int Height), CefRect>(ref Unsafe.AsRef(rect));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref CefSize AsCefSize(ref this CefPoint point)
    => ref Unsafe.As<CefPoint, CefSize>(ref Unsafe.AsRef(point));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref CefSize AsCefSize(ref this (int Width, int Height) size)
    => ref Unsafe.As<(int Width, int Height), CefSize>(ref Unsafe.AsRef(size));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref readonly CefSize AsCefSizeReadOnly(in this (int Width, int Height) size)
    => ref Unsafe.As<(int Width, int Height), CefSize>(ref Unsafe.AsRef(size));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref CefPoint AsCefPoint(ref this CefSize size)
    => ref Unsafe.As<CefSize, CefPoint>(ref Unsafe.AsRef(size));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref CefPoint AsCefPoint(ref this (int X, int Y) size)
    => ref Unsafe.As<(int X, int Y), CefPoint>(ref Unsafe.AsRef(size));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref readonly CefPoint AsCefPointReadOnly(in this (int X, int Y) size)
    => ref Unsafe.As<(int X, int Y), CefPoint>(ref Unsafe.AsRef(size));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref CefFractionalPoint AsCefFractionalPoint(ref this (float X, float Y) size)
    => ref Unsafe.As<(float X, float Y), CefFractionalPoint>(ref Unsafe.AsRef(size));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref readonly CefFractionalPoint AsCefFractionalPointReadOnly(in this (float X, float Y) size)
    => ref Unsafe.As<(float X, float Y), CefFractionalPoint>(ref Unsafe.AsRef(size));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref CefFractionalSize AsCefFractionalSize(ref this (float Width, float Height) size)
    => ref Unsafe.As<(float Width, float Height), CefFractionalSize>(ref Unsafe.AsRef(size));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref readonly CefFractionalSize AsCefFractionalSizeReadOnly(in this (float Width, float Height) size)
    => ref Unsafe.As<(float Width, float Height), CefFractionalSize>(ref Unsafe.AsRef(size));

}
