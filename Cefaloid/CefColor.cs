namespace Cefaloid;

/// <summary>
/// 32-bit ARGB color value, un-premultiplied. Color components are always in
/// a known order. Equivalent to the SkColor type.
/// <c>cef_color_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefColor
  : IEquatable<CefColor>,
    IComparable<CefColor>,
    IComparisonOperators<CefColor, CefColor, bool>,
    IAdditionOperators<CefColor, CefColor, CefColor>,
    ISubtractionOperators<CefColor, CefColor, CefColor>,
    IMultiplyOperators<CefColor, float, CefColor> {

  /// <summary>
  /// The 32-bit unsigned integer representation of the color.
  /// </summary>
  public uint Value;

  /// <summary>
  /// The alpha component of the color.
  /// </summary>
  /// <remarks>
  /// Generally used for opacity or transparency.
  /// </remarks>
  public byte Alpha {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (byte) (Value >> 24);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => Value = (Value & 0x00FFFFFF) | ((uint) value << 24);
  }

  /// <summary>
  /// The red component of the color.
  /// </summary>
  public byte Red {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (byte) (Value >> 16);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => Value = (Value & 0xFF00FFFF) | ((uint) value << 16);
  }

  /// <summary>
  /// The green component of the color.
  /// </summary>
  public byte Green {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (byte) (Value >> 8);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => Value = (Value & 0xFFFF00FF) | ((uint) value << 8);
  }

  /// <summary>
  /// The blue component of the color.
  /// </summary>
  public byte Blue {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (byte) Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => Value = (Value & 0xFFFFFF00) | value;
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given <paramref name="value"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefColor(uint value)
    => Value = value;

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given
  /// components <paramref name="r"/>, <paramref name="g"/>,
  /// <paramref name="b"/> and <paramref name="a"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public CefColor(byte r, byte g, byte b, byte a = 255)
    => Value = ((uint) a << 24) | ((uint) r << 16) | ((uint) g << 8) | b;

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given
  /// components <paramref name="r"/>, <paramref name="g"/>,
  /// <paramref name="b"/> and <paramref name="a"/>.
  /// </summary>
  public CefColor(float r, float g, float b, float a = 1)
    => Value = (uint) (
      ((byte) (a * 255) << 24)
      | ((byte) (r * 255) << 16)
      | ((byte) (g * 255) << 8)
      | (byte) (b * 255));

  /// <summary>
  /// Converts a <see cref="CefColor"/> to a <see cref="uint"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator uint(CefColor value)
    => value.Value;

  /// <summary>
  /// Converts a <see cref="uint"/> to a <see cref="CefColor"/>.
  /// </summary>
  /// <param name="value"></param>
  /// <returns></returns>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator CefColor(uint value)
    => new(value);

  /// <inheritdoc cref="Equals(CefColor)"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefColor lhs, CefColor rhs)
    => lhs.Value == rhs.Value;

  /// <summary>
  /// Compares two <see cref="CefColor"/> values for inequality.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefColor lhs, CefColor rhs)
    => lhs.Value != rhs.Value;

  /// <inheritdoc cref="Object.Equals(object)" />
  /// <seealso cref="Equals(CefColor)"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj)
    => obj is CefColor color && Value == color.Value;

  /// <inheritdoc cref="UInt32.GetHashCode"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode()
    => Value.GetHashCode();

  /// <summary>
  /// Compares two <see cref="CefColor"/> values for equality.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefColor other)
    => Value == other.Value;

  /// <summary>
  /// Compares this <see cref="CefColor"/> to another.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefColor other)
    => Value.CompareTo(other.Value);

  /// <summary>
  /// Adds two <see cref="CefColor"/> together, clamping the result.
  /// </summary>
  public static CefColor operator +(CefColor lhs, CefColor rhs) {
    var r = (byte) Math.Clamp(lhs.Red + rhs.Red, 0, 255);
    var g = (byte) Math.Clamp(lhs.Green + rhs.Green, 0, 255);
    var b = (byte) Math.Clamp(lhs.Blue + rhs.Blue, 0, 255);
    var a = (byte) Math.Clamp(lhs.Alpha + rhs.Alpha, 0, 255);
    return new(r, g, b, a);
  }

  /// <summary>
  /// Subtracts two <see cref="CefColor"/> together, clamping the result.
  /// </summary>
  public static CefColor operator -(CefColor lhs, CefColor rhs) {
    var r = (byte) Math.Clamp(lhs.Red - rhs.Red, 0, 255);
    var g = (byte) Math.Clamp(lhs.Green - rhs.Green, 0, 255);
    var b = (byte) Math.Clamp(lhs.Blue - rhs.Blue, 0, 255);
    var a = (byte) Math.Clamp(lhs.Alpha - rhs.Alpha, 0, 255);
    return new(r, g, b, a);
  }

  /// <summary>
  /// Multiplies a <see cref="CefColor"/> by a <see cref="float"/>, clamping the result.
  /// </summary>
  /// <remarks>
  /// Midpoint rounding is toward positive infinity.
  /// </remarks>
  public static CefColor operator *(CefColor lhs, float rhs) {
    var r = (byte) MathF.Round(lhs.Red * rhs, MidpointRounding.ToPositiveInfinity);
    var g = (byte) MathF.Round(lhs.Green * rhs, MidpointRounding.ToPositiveInfinity);
    var b = (byte) MathF.Round(lhs.Blue * rhs, MidpointRounding.ToPositiveInfinity);
    var a = (byte) MathF.Round(lhs.Alpha * rhs, MidpointRounding.ToPositiveInfinity);
    return new(r, g, b, a);
  }

  /// <summary>
  /// Determines whether one <see cref="CefColor"/> is greater than another.
  /// </summary>
  public static bool operator >(CefColor left, CefColor right)
    => left.Value > right.Value;

  /// <summary>
  /// Determines whether one <see cref="CefColor"/> is greater than or equal to another.
  /// </summary>
  public static bool operator >=(CefColor left, CefColor right)
    => left.Value >= right.Value;

  /// <summary>
  /// Determines whether one <see cref="CefColor"/> is less than another.
  /// </summary>
  public static bool operator <(CefColor left, CefColor right)
    => left.Value < right.Value;

  /// <summary>
  /// Determines whether one <see cref="CefColor"/> is less than or equal to another.
  /// </summary>
  public static bool operator <=(CefColor left, CefColor right)
    => left.Value <= right.Value;

  /// <summary>
  /// Decomposes a <see cref="CefColor"/> into its components.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Deconstruct(out byte r, out byte g, out byte b, out byte a) {
    r = Red;
    g = Green;
    b = Blue;
    a = Alpha;
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> to a <see cref="string"/> in the form <c>#AARRGGBB</c>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString()
    => $"#{Value:X8}";
  //  ({Red / 255.0f,5:0.#%} R, {Green / 255.0f,5:0.#%} G, {Blue / 255.0f,5:0.#%} B, {Alpha / 255.0f,5:0.#%} A)

  /// <summary>
  /// Reports whether the color is considered web-safe.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool IsWebSafe()
    => Red % 51 == 0 && Green % 51 == 0 && Blue % 51 == 0;

  /// <summary>
  /// Reports whether the color is gray-scale.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool IsGrayScale()
    => Red == Green && Green == Blue;

  /// <summary>
  /// Reports whether the color is considered dark.
  /// </summary>
  public bool IsDark()
    => Red * 0.299f + Green * 0.587f + Blue * 0.114f < 186;

  /// <summary>
  /// Reports whether the color is considered light.
  /// </summary>
  public bool IsLight()
    => !IsDark();

  /// <summary>
  /// Reports whether the color is considered transparent.
  /// </summary>
  public bool IsTransparent()
    => Alpha < 255;

  /// <summary>
  /// Reports whether the color is considered opaque.
  /// </summary>
  public bool IsOpaque()
    => Alpha == 255;

  /// <summary>
  /// Replaces the alpha component of the color.
  /// </summary>
  public CefColor WithAlpha(float alpha)
    => new(Red, Green, Blue, (byte) (alpha * 255));

  /// <summary>
  /// Replaces the alpha component of the color.
  /// </summary>
  public CefColor WithAlpha(byte alpha)
    => new(Red, Green, Blue, alpha);

  /// <summary>
  /// Replaces the red component of the color.
  /// </summary>
  public CefColor WithRed(float red)
    => new((byte) (red * 255), Green, Blue, Alpha);

  /// <summary>
  /// Replaces the red component of the color.
  /// </summary>
  public CefColor WithRed(byte red)
    => new(red, Green, Blue, Alpha);

  /// <summary>
  /// Replaces the green component of the color.
  /// </summary>
  public CefColor WithGreen(float green)
    => new(Red, (byte) (green * 255), Blue, Alpha);

  /// <summary>
  /// Replaces the green component of the color.
  /// </summary>
  public CefColor WithGreen(byte green)
    => new(Red, green, Blue, Alpha);

  /// <summary>
  /// Replaces the blue component of the color.
  /// </summary>
  public CefColor WithBlue(float blue)
    => new(Red, Green, (byte) (blue * 255), Alpha);

  /// <summary>
  /// Replaces the blue component of the color.
  /// </summary>
  public CefColor WithBlue(byte blue)
    => new(Red, Green, blue, Alpha);

  /// <summary>
  /// Replaces the hue component of the color.
  /// </summary>
  public CefColor WithHue(float hue) {
    ToHsl(out _, out var sat, out var lum);
    return FromHsl(hue, sat, lum, Alpha / 255.0f);
  }

  /// <summary>
  /// Replaces the saturation component of the color.
  /// </summary>
  public CefColor WithSaturation(float saturation) {
    ToHsl(out var hue, out _, out var lum);
    return FromHsl(hue, saturation, lum, Alpha / 255.0f);
  }

  /// <summary>
  /// Replaces the luminosity component of the color.
  /// </summary>
  public CefColor WithLuminosity(float luminosity) {
    ToHsl(out var hue, out var sat, out _);
    return FromHsl(hue, sat, luminosity, Alpha / 255.0f);
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given <paramref name="hue"/>,
  /// <paramref name="saturation"/>, <paramref name="luminosity"/> and <paramref name="alpha"/>.
  /// </summary>
  public static CefColor FromHsl(float hue, float saturation, float luminosity, float alpha = 1) {
    if (luminosity == 0)
      return new(0, 0, 0, alpha);

    if (saturation == 0)
      return new(luminosity, luminosity, luminosity, alpha);

    var y = luminosity <= 0.5f
      ? luminosity * (1f + saturation)
      : luminosity + saturation - luminosity * saturation;
    var x = 2f * luminosity - y;
    var r = GetColorComponent(x, y, hue + 1f / 3f);
    var g = GetColorComponent(x, y, hue);
    var b = GetColorComponent(x, y, hue - 1f / 3f);

    return new(r, g, b, alpha);

    static float GetColorComponent(float x, float y, float z) {
      z = z < 0 ? z + 1 : z > 1 ? z - 1 : z;
      return z switch {
        < 1f / 6f => x + (y - x) * 6f * z,
        < 0.5f => y,
        < 2f / 3f => x + (y - x) * (2f / 3f - z) * 6f,
        _ => x
      };
    }
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given <paramref name="hue"/>,
  /// <paramref name="saturation"/>, <paramref name="value"/> and <paramref name="alpha"/>.
  /// </summary>
  public static CefColor FromHsv(float hue, float saturation, float value, float alpha = 1) {
    if (saturation == 0)
      return new(value, value, value, alpha);

    var hh = hue / 60f;
    var i = (int) hh;
    var ff = hh - i;
    var p = value * (1f - saturation);
    var q = value * (1f - saturation * ff);
    var t = value * (1f - saturation * (1f - ff));

    return i switch {
      0 => new(value, t, p, alpha),
      1 => new(q, value, p, alpha),
      2 => new(p, value, t, alpha),
      3 => new(p, q, value, alpha),
      4 => new(t, p, value, alpha),
      _ => new(value, p, q, alpha)
    };
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given <paramref name="hue"/>,
  /// <paramref name="white"/>, <paramref name="black"/> and <paramref name="alpha"/>.
  /// </summary>
  public static CefColor FromHwb(float hue, float white, float black, float alpha = 1) {
    if (white + black >= 1) {
      var gray = white / (white + black);
      return new(gray, gray, gray);
    }

    var rgb = FromHsl(hue, 100, 50, alpha);
    rgb *= 1 - white - black;
    rgb += new CefColor(white, white, white, 0);
    return rgb;
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into <paramref name="hue"/>,
  /// <paramref name="white"/> and <paramref name="black"/>.
  /// </summary>
  public void ToHwb(out float hue, out float white, out float black) {
    ToHsl(out hue, out _, out var lum);
    white = MathF.Min(lum, 1 - lum);
    black = 1 - lum - white;
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given <paramref name="cyan"/>,
  /// <paramref name="magenta"/>, <paramref name="yellow"/>, <paramref name="black"/>
  /// and <paramref name="alpha"/>.
  /// </summary>
  public static CefColor FromCmyk(float cyan, float magenta, float yellow, float black, float alpha = 1) {
    var r = 1 - MathF.Min(1, cyan * (1 - black) + black);
    var g = 1 - MathF.Min(1, magenta * (1 - black) + black);
    var b = 1 - MathF.Min(1, yellow * (1 - black) + black);
    return new(r, g, b, alpha);
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given <paramref name="cyan"/>,
  /// <paramref name="magenta"/>, <paramref name="yellow"/> and <paramref name="alpha"/>.
  /// </summary>
  public static CefColor FromCmy(float cyan, float magenta, float yellow, float alpha = 1) {
    var r = 1 - cyan;
    var g = 1 - magenta;
    var b = 1 - yellow;
    return new(r, g, b, alpha);
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given <paramref name="lumaY"/>,
  /// <paramref name="chromaU"/>, <paramref name="chromaV"/> and <paramref name="alpha"/>.
  /// </summary>
  public static CefColor FromYuv(float lumaY, float chromaU, float chromaV, float alpha = 1) {
    var r = lumaY + 1.13983f * chromaV;
    var g = lumaY - 0.39465f * chromaU - 0.58060f * chromaV;
    var b = lumaY + 2.03211f * chromaU;
    return new(r, g, b, alpha);
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given CIELAB <paramref name="l"/>,
  /// <paramref name="a"/>, <paramref name="b"/> and <paramref name="alpha"/>.
  /// </summary>
  /// <param name="l">Perceptual lightness.</param>
  /// <param name="a">Green-red color component.</param>
  /// <param name="b">Blue-yellow color component.</param>
  /// <param name="alpha">Alpha component.</param>
  public static CefColor FromLab(float l, float a, float b, float alpha = 1) {
    var y = (l + 16f) / 116f;
    var x = a / 500f + y;
    var z = y - b / 200f;
    var red = 3.2404542f * x * x * x - 1.5371385f * y * y * y - 0.4985314f * z * z * z;
    var green = -0.9692660f * x * x * x + 1.8760108f * y * y * y + 0.0415560f * z * z * z;
    var blue = 0.0556434f * x * x * x - 0.2040259f * y * y * y + 1.0572252f * z * z * z;
    return new(red, green, blue, alpha);
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given CIELCh <paramref name="l"/>,
  /// <paramref name="c"/>, <paramref name="h"/> and <paramref name="alpha"/>.
  /// </summary>
  /// <param name="l">Perceptual lightness.</param>
  /// <param name="c">Chroma, relative saturation.</param>
  /// <param name="h">Hue angle in degrees.</param>
  /// &lt;param name="alpha"&gt;Alpha component.&lt;/param&gt;
  public static CefColor FromLch(float l, float c, float h, float alpha = 1) {
    var (sin, cos) = float.SinCos(h * MathF.PI / 180f);
    var a = c * cos;
    var b = c * sin;
    return FromLab(l, a, b, alpha);
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into <paramref name="hue"/>,
  /// <paramref name="saturation"/> and <paramref name="luminosity"/>.
  /// </summary>
  public void ToHsl(out float hue, out float saturation, out float luminosity) {
    var max = Math.Max(Red, Math.Max(Green, Blue));
    var min = Math.Min(Red, Math.Min(Green, Blue));
    luminosity = (max + min) / (2f * 255f);
    var delta = max - min / 255f;
    if (delta == 0) {
      hue = 0;
      saturation = 0;
      return;
    }

    //saturation = luminosity < 0.5f
    //  ? delta / (max + min)
    //  : delta / (2 - max - min);
    //saturation = delta / (1 - MathF.Abs(2 * luminosity - 1));
    saturation = luminosity is 0 or 1
      ? 0
      : (max - luminosity) / MathF.Min(luminosity, 1 - luminosity);
    hue = 0f;
    if (Red == max)
      hue = (Green - Blue) / delta + (Green < Blue ? 6 : 0);
    else if (Green == max)
      hue = (Blue - Red) / delta + 2;
    else if (Blue == max)
      hue = (Red - Green) / delta + 4;
    hue *= 60;
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into <paramref name="cyan"/>,
  /// <paramref name="magenta"/>, <paramref name="yellow"/> and <paramref name="black"/>.
  /// </summary>
  public void ToCmyk(out float cyan, out float magenta, out float yellow, out float black) {
    cyan = 1 - Red;
    magenta = 1 - Green;
    yellow = 1 - Blue;
    black = Math.Min(cyan, Math.Min(magenta, yellow));
    cyan = (cyan - black) / (1 - black);
    magenta = (magenta - black) / (1 - black);
    yellow = (yellow - black) / (1 - black);
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into <paramref name="cyan"/>,
  /// <paramref name="magenta"/> and <paramref name="yellow"/>.
  /// </summary>
  public void ToCmy(out float cyan, out float magenta, out float yellow) {
    cyan = 1 - Red;
    magenta = 1 - Green;
    yellow = 1 - Blue;
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into <paramref name="hue"/>,
  /// <paramref name="saturation"/> and <paramref name="value"/>.
  /// </summary>
  public void ToHsv(out float hue, out float saturation, out float value) {
    var max = Math.Max(Red, Math.Max(Green, Blue));
    var min = Math.Min(Red, Math.Min(Green, Blue));
    value = max / 255f;
    var delta = max - min;
    if (delta == 0) {
      hue = 0;
      saturation = 0;
      return;
    }

    saturation = delta / (float) max;
    hue = 0f;
    if (Red == max)
      hue = (Green - Blue) / delta + (Green < Blue ? 6 : 0);
    else if (Green == max)
      hue = (Blue - Red) / delta + 2;
    else if (Blue == max)
      hue = (Red - Green) / delta + 4;
    hue *= 60;
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into <paramref name="lumaY"/>,
  /// <paramref name="chromaU"/> and <paramref name="chromaV"/>.
  /// </summary>
  public void ToYuv(out float lumaY, out float chromaU, out float chromaV) {
    lumaY = 0.299f * Red + 0.587f * Green + 0.114f * Blue;
    chromaU = -0.14713f * Red - 0.28886f * Green + 0.436f * Blue;
    chromaV = 0.615f * Red - 0.51499f * Green - 0.10001f * Blue;
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into CIELAB <paramref name="l"/>,
  /// <paramref name="a"/> and <paramref name="b"/>.
  /// </summary>
  /// <param name="l">Perceptual lightness.</param>
  /// <param name="a">Green-red color component.</param>
  /// <param name="b">Blue-yellow color component.</param>
  public void ToLab(out float l, out float a, out float b) {
    var x = Red / 255f;
    var y = Green / 255f;
    var z = Blue / 255f;
    x = x > 0.04045f ? MathF.Pow((x + 0.055f) / 1.055f, 2.4f) : x / 12.92f;
    y = y > 0.04045f ? MathF.Pow((y + 0.055f) / 1.055f, 2.4f) : y / 12.92f;
    z = z > 0.04045f ? MathF.Pow((z + 0.055f) / 1.055f, 2.4f) : z / 12.92f;
    x = x * 100f;
    y = y * 100f;
    z = z * 100f;
    l = 116f * y - 16f;
    a = 500f * (x - y);
    b = 200f * (y - z);
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into CIELCh/CIEHLC <paramref name="l"/>,
  /// <paramref name="c"/> and <paramref name="h"/>.
  /// </summary>
  /// <param name="l">Perceptual lightness.</param>
  /// <param name="c">Chroma, relative saturation.</param>
  /// <param name="h">Hue angle in degrees.</param>
  public void ToLch(out float l, out float c, out float h) {
    ToLab(out l, out var a, out var b);
    c = MathF.Sqrt(a * a + b * b);
    h = MathF.Atan2(b, a) * 180f / MathF.PI;
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into OKLab <paramref name="l"/>,
  /// <paramref name="a"/> and <paramref name="b"/>.
  /// </summary>
  /// <param name="l">Perceptual lightness.</param>
  /// <param name="a">Green-red color component.</param>
  /// <param name="b">Blue-yellow color component.</param>
  public void ToOklab(out float l, out float a, out float b) {
    var x = Red / 255f;
    var y = Green / 255f;
    var z = Blue / 255f;
    x = x > 0.04045f ? MathF.Pow((x + 0.055f) / 1.055f, 2.4f) : x / 12.92f;
    y = y > 0.04045f ? MathF.Pow((y + 0.055f) / 1.055f, 2.4f) : y / 12.92f;
    z = z > 0.04045f ? MathF.Pow((z + 0.055f) / 1.055f, 2.4f) : z / 12.92f;
    x = x * 100f;
    y = y * 100f;
    z = z * 100f;
    l = 0.2104542553f * x + 0.7936177850f * y - 0.0040720468f * z;
    a = 1.9779984951f * x - 2.4285922050f * y + 0.4505937099f * z;
    b = 0.0259040371f * x + 0.7827717662f * y - 0.8086757660f * z;
  }

  /// <summary>
  /// Converts a <see cref="CefColor"/> into OKLCh <paramref name="l"/>,
  /// <paramref name="c"/> and <paramref name="h"/>.
  /// </summary>
  /// <param name="l">Perceptual lightness.</param>
  /// <param name="c">Chroma, relative saturation.</param>
  /// <param name="h">Hue angle in degrees.</param>
  public void ToOklch(out float l, out float c, out float h) {
    ToOklab(out l, out var a, out var b);
    c = MathF.Sqrt(a * a + b * b);
    h = MathF.Atan2(b, a) * 180f / MathF.PI;
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given OKLab <paramref name="l"/>,
  /// <paramref name="a"/> and <paramref name="b"/>.
  /// </summary>
  public CefColor FromOklab(float l, float a, float b) {
    var x = 0.999999998450f * l + 0.3963377774f * a + 0.2158037573f * b;
    var y = 0.999999996030f * l - 0.1055613458f * a - 0.0638541728f * b;
    var z = 0.999999997450f * l - 0.0894841775f * a - 1.2914855480f * b;
    x = x > 0.008856f ? MathF.Pow(x, 1f / 3f) : 7.787f * x + 16f / 116f;
    y = y > 0.008856f ? MathF.Pow(y, 1f / 3f) : 7.787f * y + 16f / 116f;
    z = z > 0.008856f ? MathF.Pow(z, 1f / 3f) : 7.787f * z + 16f / 116f;
    x = x * 95.047f;
    y = y * 100f;
    z = z * 108.883f;
    x = x > 0.0031308f ? 1.055f * MathF.Pow(x, 1f / 2.4f) - 0.055f : 12.92f * x;
    y = y > 0.0031308f ? 1.055f * MathF.Pow(y, 1f / 2.4f) - 0.055f : 12.92f * y;
    z = z > 0.0031308f ? 1.055f * MathF.Pow(z, 1f / 2.4f) - 0.055f : 12.92f * z;
    x = x / 100f;
    y = y / 100f;
    z = z / 100f;
    return new(
      (byte) (x * 255f),
      (byte) (y * 255f),
      (byte) (z * 255f),
      Alpha
    );
  }

  /// <summary>
  /// Creates a new <see cref="CefColor"/> from the given OKLCh <paramref name="l"/>,
  /// <paramref name="c"/> and <paramref name="h"/>.
  /// </summary>
  public CefColor FromOklch(float l, float c, float h) {
    var (sin, cos) = float.SinCos(h * MathF.PI / 180f);
    var a = c * cos;
    var b = c * sin;
    return FromOklab(l, a, b);
  }

  /// <summary>
  /// Interpolates between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor Interpolate(CefColor other, float t) {
    var r = Helpers.Interpolate(Red, other.Red, t);
    var g = Helpers.Interpolate(Green, other.Green, t);
    var b = Helpers.Interpolate(Blue, other.Blue, t);
    var a = Helpers.Interpolate(Alpha, other.Alpha, t);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Creates an averaged <see cref="CefColor"/> from two others.
  /// </summary>
  public CefColor Average(CefColor other) {
    var r = (Red + other.Red) / 2;
    var g = (Green + other.Green) / 2;
    var b = (Blue + other.Blue) / 2;
    var a = (Alpha + other.Alpha) / 2;
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Generates a <see cref="CefColor"/> from the difference between two others.
  /// </summary>
  public CefColor Difference(CefColor other) {
    var r = MathF.Abs(Red - other.Red);
    var g = MathF.Abs(Green - other.Green);
    var b = MathF.Abs(Blue - other.Blue);
    var a = MathF.Abs(Alpha - other.Alpha);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Multiplies two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor Multiply(CefColor other) {
    var r = (Red * other.Red) / 255;
    var g = (Green * other.Green) / 255;
    var b = (Blue * other.Blue) / 255;
    var a = (Alpha * other.Alpha) / 255;
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a screen blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor Screen(CefColor other) {
    var r = 255 - (((255 - Red) * (255 - other.Red)) / 255);
    var g = 255 - (((255 - Green) * (255 - other.Green)) / 255);
    var b = 255 - (((255 - Blue) * (255 - other.Blue)) / 255);
    var a = 255 - (((255 - Alpha) * (255 - other.Alpha)) / 255);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs an overlay blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor Overlay(CefColor other) {
    var r = Red < 128 ? (2 * Red * other.Red) / 255 : 255 - (2 * (255 - Red) * (255 - other.Red)) / 255;
    var g = Green < 128 ? (2 * Green * other.Green) / 255 : 255 - (2 * (255 - Green) * (255 - other.Green)) / 255;
    var b = Blue < 128 ? (2 * Blue * other.Blue) / 255 : 255 - (2 * (255 - Blue) * (255 - other.Blue)) / 255;
    var a = Alpha < 128 ? (2 * Alpha * other.Alpha) / 255 : 255 - (2 * (255 - Alpha) * (255 - other.Alpha)) / 255;
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs an exclusion blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor Exclusion(CefColor other) {
    var r = (Red + other.Red) - ((Red * other.Red) / 255);
    var g = (Green + other.Green) - ((Green * other.Green) / 255);
    var b = (Blue + other.Blue) - ((Blue * other.Blue) / 255);
    var a = (Alpha + other.Alpha) - ((Alpha * other.Alpha) / 255);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a hard light blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor HardLight(CefColor other) {
    var r = other.Red < 128 ? (2 * Red * other.Red) / 255 : 255 - (2 * (255 - Red) * (255 - other.Red)) / 255;
    var g = other.Green < 128 ? (2 * Green * other.Green) / 255 : 255 - (2 * (255 - Green) * (255 - other.Green)) / 255;
    var b = other.Blue < 128 ? (2 * Blue * other.Blue) / 255 : 255 - (2 * (255 - Blue) * (255 - other.Blue)) / 255;
    var a = other.Alpha < 128 ? (2 * Alpha * other.Alpha) / 255 : 255 - (2 * (255 - Alpha) * (255 - other.Alpha)) / 255;
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a soft light blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor SoftLight(CefColor other) {
    var r = other.Red < 128 ? (2 * Red * other.Red) / 255 + (Red * Red * (255 - (2 * other.Red))) / 65025 : 255 - (2 * (255 - Red) * (255 - other.Red)) / 255 + (Red * Red * (2 * other.Red - 255)) / 65025;
    var g = other.Green < 128 ? (2 * Green * other.Green) / 255 + (Green * Green * (255 - (2 * other.Green))) / 65025 : 255 - (2 * (255 - Green) * (255 - other.Green)) / 255 + (Green * Green * (2 * other.Green - 255)) / 65025;
    var b = other.Blue < 128 ? (2 * Blue * other.Blue) / 255 + (Blue * Blue * (255 - (2 * other.Blue))) / 65025 : 255 - (2 * (255 - Blue) * (255 - other.Blue)) / 255 + (Blue * Blue * (2 * other.Blue - 255)) / 65025;
    var a = other.Alpha < 128 ? (2 * Alpha * other.Alpha) / 255 + (Alpha * Alpha * (255 - (2 * other.Alpha))) / 65025 : 255 - (2 * (255 - Alpha) * (255 - other.Alpha)) / 255 + (Alpha * Alpha * (2 * other.Alpha - 255)) / 65025;
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a dodge blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor ColorDodge(CefColor other) {
    var r = other.Red == 255 ? 255 : MathF.Min(255, (Red * 255) / (float) (255 - other.Red));
    var g = other.Green == 255 ? 255 : MathF.Min(255, (Green * 255) / (float) (255 - other.Green));
    var b = other.Blue == 255 ? 255 : MathF.Min(255, (Blue * 255) / (float) (255 - other.Blue));
    var a = other.Alpha == 255 ? 255 : MathF.Min(255, (Alpha * 255) / (float) (255 - other.Alpha));
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a burn blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor ColorBurn(CefColor other) {
    var r = other.Red == 0 ? 0 : MathF.Max(0, 255 - ((255 - Red) * 255) / other.Red);
    var g = other.Green == 0 ? 0 : MathF.Max(0, 255 - ((255 - Green) * 255) / other.Green);
    var b = other.Blue == 0 ? 0 : MathF.Max(0, 255 - ((255 - Blue) * 255) / other.Blue);
    var a = other.Alpha == 0 ? 0 : MathF.Max(0, 255 - ((255 - Alpha) * 255) / other.Alpha);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a linear dodge blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor LinearDodge(CefColor other) {
    var r = MathF.Min(255, Red + other.Red);
    var g = MathF.Min(255, Green + other.Green);
    var b = MathF.Min(255, Blue + other.Blue);
    var a = MathF.Min(255, Alpha + other.Alpha);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a linear burn blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor LinearBurn(CefColor other) {
    var r = MathF.Max(0, Red + other.Red - 255);
    var g = MathF.Max(0, Green + other.Green - 255);
    var b = MathF.Max(0, Blue + other.Blue - 255);
    var a = MathF.Max(0, Alpha + other.Alpha - 255);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs linear light blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor LinearLight(CefColor other) {
    var r = other.Red < 128 ? MathF.Max(0, Red + 2 * other.Red - 255) : MathF.Min(255, Red + 2 * (other.Red - 128));
    var g = other.Green < 128 ? MathF.Max(0, Green + 2 * other.Green - 255) : MathF.Min(255, Green + 2 * (other.Green - 128));
    var b = other.Blue < 128 ? MathF.Max(0, Blue + 2 * other.Blue - 255) : MathF.Min(255, Blue + 2 * (other.Blue - 128));
    var a = other.Alpha < 128 ? MathF.Max(0, Alpha + 2 * other.Alpha - 255) : MathF.Min(255, Alpha + 2 * (other.Alpha - 128));
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a vivid light blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor VividLight(CefColor other) {
    var r = other.Red < 128 ? ColorBurn(other) : ColorDodge(other);
    var g = other.Green < 128 ? ColorBurn(other) : ColorDodge(other);
    var b = other.Blue < 128 ? ColorBurn(other) : ColorDodge(other);
    var a = other.Alpha < 128 ? ColorBurn(other) : ColorDodge(other);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

  /// <summary>
  /// Performs a pin light blend between two <see cref="CefColor"/>s.
  /// </summary>
  public CefColor PinLight(CefColor other) {
    var r = other.Red < 128 ? MathF.Min(2 * other.Red, Red) : MathF.Max(2 * (other.Red - 128), Red);
    var g = other.Green < 128 ? MathF.Min(2 * other.Green, Green) : MathF.Max(2 * (other.Green - 128), Green);
    var b = other.Blue < 128 ? MathF.Min(2 * other.Blue, Blue) : MathF.Max(2 * (other.Blue - 128), Blue);
    var a = other.Alpha < 128 ? MathF.Min(2 * other.Alpha, Alpha) : MathF.Max(2 * (other.Alpha - 128), Alpha);
    return new((byte) r, (byte) g, (byte) b, (byte) a);
  }

}
