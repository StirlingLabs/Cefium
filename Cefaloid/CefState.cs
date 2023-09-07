namespace Cefaloid;

/// <summary>
/// Represents the state of a setting.
/// </summary>
[PublicAPI]
public enum CefState {

  /// <summary>
  /// Use the default state for the setting.
  /// </summary>
  Default = 0,

  /// <summary>
  /// Enable or allow the setting.
  /// </summary>
  Enabled,

  /// <summary>
  /// Disable or disallow the setting.
  /// </summary>
  Disabled

}
