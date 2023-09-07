namespace Cefaloid;

/// <summary>
/// Time information. Values should always be in UTC.
/// <c>cef_time_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefTime {

  /// <summary>
  /// Four or five digit year "2007" (1601 to 30827 on Windows, 1970 to 2038 on
  /// 32-bit POSIX)
  /// </summary>
  public int Year;

  /// <summary>
  /// 1-based month (values 1 = January, etc.)
  /// </summary>
  public int Month;

  /// <summary>
  /// 0-based day of week (0 = Sunday, etc.)
  /// </summary>
  public DayOfWeek DayOfWeek;

  /// <summary>
  /// 1-based day of month (1-31)
  /// </summary>
  public int DayOfMonth;

  /// <summary>
  /// Hour within the current day (0-23)
  /// </summary>
  public int Hour;

  /// <summary>
  /// Minute within the current hour (0-59)
  /// </summary>
  public int Minute;

  /// <summary>
  /// Second within the current minute (0-59 plus leap seconds which may take
  /// it up to 60).
  /// </summary>
  public int Second;

  /// <summary>
  /// Milliseconds within the current second (0-999)
  /// </summary>
  public int Millisecond;

  /// <summary>
  /// Retrieve the current system time. Returns true (1) on success and false (0)
  /// on failure.
  /// <c>CEF_EXPORT int cef_time_now(cef_time_t* cef_time);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_time_now", CallingConvention = CallingConvention.Cdecl)]
  private static extern int _Now(out CefTime time);

  /// <inheritdoc cref="_Now"/>
  public static CefTime Now {
    get {
      if (_Now(out var time) != 0)
        return time;

      throw new("Failed to get the current time from CEF via cef_time_now.");
    }
  }

  /// <summary>
  /// Converts cef_time_t to cef_basetime_t. Returns true (1) on success and
  /// false (0) on failure.
  /// <c>CEF_EXPORT int cef_time_to_basetime(const cef_time_t* from, cef_basetime_t* to);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_time_to_basetime", CallingConvention = CallingConvention.Cdecl)]
  private static extern int _ToBaseTime(ref CefTime from, out CefBaseTime to);

  /// <inheritdoc cref="_ToBaseTime"/>
  public static CefBaseTime ToCefBaseTime(CefTime time) {
    if (_ToBaseTime(ref time, out var baseTime) != 0)
      return baseTime;

    throw new("Failed to convert CefTime to CefBaseTime via cef_time_to_basetime.");
  }

  /// <summary>
  /// Converts cef_basetime_t to cef_time_t. Returns true (1) on success and
  /// false (0) on failure.
  /// <c>CEF_EXPORT int cef_time_from_basetime(const cef_basetime_t from, cef_time_t* to);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_time_from_basetime", CallingConvention = CallingConvention.Cdecl)]
  private static extern int _FromBaseTime(CefBaseTime from, out CefTime to);

  /// <inheritdoc cref="_FromBaseTime"/>
  public static CefTime FromCefBaseTime(CefBaseTime baseTime) {
    if (_FromBaseTime(baseTime, out var time) != 0)
      return time;

    throw new("Failed to convert CefBaseTime to CefTime via cef_time_from_basetime.");
  }

  /// <inheritdoc cref="_FromBaseTime"/>
  public static explicit operator CefTime(CefBaseTime baseTime) => FromCefBaseTime(baseTime);

  /// <inheritdoc cref="_ToBaseTime"/>
  public static explicit operator CefBaseTime(CefTime time) => ToCefBaseTime(time);

}
