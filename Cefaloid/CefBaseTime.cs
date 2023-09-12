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
/// <remarks>
/// .NET Ticks are assumed to be 100-nanosecond intervals.
/// CEF Ticks are assumed to be microsecond intervals.
/// </remarks>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefBaseTime
  : IEquatable<CefBaseTime>,
    IComparable<CefBaseTime>,
    IComparisonOperators<CefBaseTime, CefBaseTime, bool>,
    IAdditionOperators<CefBaseTime, TimeSpan, CefBaseTime>,
    ISubtractionOperators<CefBaseTime, TimeSpan, CefBaseTime>,
    ISubtractionOperators<CefBaseTime, CefBaseTime, TimeSpan>,
    ISpanFormattable {

  /// <summary>
  /// The .NET tick count of the CefBaseTime epoch.
  /// </summary>
  public const long EpochTicks = 11644473600000000L;

  /// <summary>
  /// The CefBaseTime epoch as a <see cref="DateTime"/>.
  /// </summary>
  public static DateTime Epoch {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => new(EpochTicks, DateTimeKind.Utc);
  }

  /// <summary>
  /// The value of the CefBaseTime in CEF ticks.
  /// </summary>
  public long Value;

  private CefBaseTime(long now)
    => Value = now;

  /// <summary>
  /// Converts a <see cref="DateTime"/> to a <see cref="CefBaseTime"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefBaseTime FromDateTime(DateTime dateTime) {
    var utc = dateTime.ToUniversalTime();
    var since = utc - Epoch;
    return new() {Value = since.Ticks / 10};
  }

  /// <summary>
  /// Converts a <see cref="CefBaseTime"/> to a <see cref="DateTime"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public DateTime ToDateTime()
    => Epoch + new TimeSpan(Value * 10);

  /// <inheritdoc cref="ToDateTime"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator DateTime(CefBaseTime time) => time.ToDateTime();

  /// <inheritdoc cref="FromDateTime"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator CefBaseTime(DateTime time) => FromDateTime(time);

  /// <inheritdoc cref="Equals(CefBaseTime)"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(CefBaseTime left, CefBaseTime right) => left.Value == right.Value;

  /// <summary>
  /// Compares two <see cref="CefBaseTime"/> values for inequality.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(CefBaseTime left, CefBaseTime right) => left.Value != right.Value;

  /// <summary>
  /// Determines which of two <see cref="CefBaseTime"/> values is earlier.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(CefBaseTime left, CefBaseTime right) => left.Value < right.Value;

  /// <summary>
  /// Determines which of two <see cref="CefBaseTime"/> values is later.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(CefBaseTime left, CefBaseTime right) => left.Value > right.Value;

  /// <summary>
  /// Determines which of two <see cref="CefBaseTime"/> values is earlier or the same.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(CefBaseTime left, CefBaseTime right) => left.Value <= right.Value;

  /// <summary>
  /// Determines which of two <see cref="CefBaseTime"/> values is later or the same.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(CefBaseTime left, CefBaseTime right) => left.Value >= right.Value;

  /// <summary>
  /// Compares two <see cref="CefBaseTime"/> values for equality.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object? obj) => obj is CefBaseTime time && Equals(time);

  /// <summary>
  /// Compares two <see cref="CefBaseTime"/> values for equality.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(CefBaseTime other) => Value == other.Value;

  /// <inheritdoc cref="Int64.GetHashCode"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode() => Value.GetHashCode();

  /// <inheritdoc cref="DateTime.ToString()"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString() => ToDateTime().ToString(CultureInfo.InvariantCulture);

  /// <inheritdoc cref="DateTime.ToString(IFormatProvider)"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(IFormatProvider? info) => ToDateTime().ToString(info);

  /// <inheritdoc cref="DateTime.ToString(string,IFormatProvider)"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(string? format, IFormatProvider? info) => ToDateTime().ToString(format, info);

  /// <inheritdoc cref="ISpanFormattable.TryFormat"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    => ToDateTime().TryFormat(destination, out charsWritten, format, provider);

  /// <inheritdoc cref="DateTime.ToString(string)"/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(string? format) => ToDateTime().ToString(format);

  /// <summary>
  /// Compares this instance to a specified <see cref="CefBaseTime"/> to another.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(CefBaseTime other) => Value.CompareTo(other.Value);

  /// <summary>
  /// Adds two specified <see cref="CefBaseTime"/> instances together.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefBaseTime operator +(CefBaseTime left, TimeSpan right)
    => new() {Value = left.Value + right.Ticks / 10};

  /// <summary>
  /// Subtracts a <see cref="TimeSpan"/> from a <see cref="CefBaseTime"/>.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static CefBaseTime operator -(CefBaseTime left, TimeSpan right)
    => new() {Value = left.Value - right.Ticks / 10};

  /// <summary>
  /// Subtracts one <see cref="CefBaseTime"/> instance from another.
  /// </summary>
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
