using System.Globalization;

namespace Cefaloid;

/// <summary>
/// Represents a wall clock time in UTC. Values are not guaranteed to be
/// monotonically non-decreasing and are subject to large amounts of skew.
/// Time is stored internally as microseconds since the Windows epoch (1601).
///
/// This is equivalent of Chromium `base::Time` (see base/time/time.h).
/// <c>cef_basetime_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefBaseTime
  : IEquatable<CefBaseTime>,
    IComparable<CefBaseTime>,
    IComparisonOperators<CefBaseTime, CefBaseTime, bool>,
    IAdditionOperators<CefBaseTime, TimeSpan, CefBaseTime>,
    ISubtractionOperators<CefBaseTime, TimeSpan, CefBaseTime>,
    ISubtractionOperators<CefBaseTime, CefBaseTime, TimeSpan>,
    ISpanFormattable {

  public const long EpochTicks = 11644473600000000L;

  public static DateTime Epoch {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => new(EpochTicks, DateTimeKind.Utc);
  }

  public long Value;

  private CefBaseTime(long now)
    => Value = now;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefBaseTime FromDateTime(DateTime dateTime) {
    var utc = dateTime.ToUniversalTime();
    var since = utc - Epoch;
    return new() {Value = since.Ticks / 10};
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public DateTime ToDateTime()
    => Epoch + new TimeSpan(Value * 10);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator DateTime(CefBaseTime time) => time.ToDateTime();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator CefBaseTime(DateTime time) => FromDateTime(time);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefBaseTime left, CefBaseTime right) => left.Value == right.Value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefBaseTime left, CefBaseTime right) => left.Value != right.Value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefBaseTime left, CefBaseTime right) => left.Value < right.Value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefBaseTime left, CefBaseTime right) => left.Value > right.Value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefBaseTime left, CefBaseTime right) => left.Value <= right.Value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefBaseTime left, CefBaseTime right) => left.Value >= right.Value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj) => obj is CefBaseTime time && Equals(time);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefBaseTime other) => Value == other.Value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode() => Value.GetHashCode();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString() => ToDateTime().ToString(CultureInfo.InvariantCulture);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(IFormatProvider? info) => ToDateTime().ToString(info);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(string? format, IFormatProvider? info) => ToDateTime().ToString(format, info);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    => ToDateTime().TryFormat(destination, out charsWritten, format, provider);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(string? format) => ToDateTime().ToString(format);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefBaseTime other) => Value.CompareTo(other.Value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefBaseTime operator +(CefBaseTime left, TimeSpan right)
    => new() {Value = left.Value + right.Ticks / 10};

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefBaseTime operator -(CefBaseTime left, TimeSpan right)
    => new() {Value = left.Value - right.Ticks / 10};

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static TimeSpan operator -(CefBaseTime left, CefBaseTime right)
    => new((left.Value - right.Value) * 10);

  /// <summary>
  /// Retrieve the current system time.
  /// <c>CEF_EXPORT cef_basetime_t cef_basetime_now();</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_basetime_now", CallingConvention = CallingConvention.Cdecl)]
  private static extern long _Now();

  /// <inheritdoc cref="_Now"/>
  public static CefBaseTime Now => new(_Now());

  /// <inheritdoc cref="CefTime.FromCefBaseTime"/>
  public CefTime ToCefTime()
    => CefTime.FromCefBaseTime(this);

}
