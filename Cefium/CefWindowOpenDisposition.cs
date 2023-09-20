namespace Cefium;

/// <summary>
/// The manner in which a link click should be opened. These constants match
/// their equivalents in Chromium's window_open_disposition.h and should not be
/// renumbered.
/// <c>cef_window_open_disposition_t</c>
/// </summary>
[PublicAPI]
public enum CefWindowOpenDisposition {

  /// <summary>
  /// Unknown window disposition. This is the default value.
  /// </summary>
  Unknown,

  /// <summary>
  /// Current tab. This is the default in most cases.
  /// <c>WOD_CURRENT_TAB</c>
  /// </summary>
  CurrentTab,

  /// <summary>
  /// Indicates that only one tab with the url should exist in the same window.
  /// <c>WOD_SINGLETON_TAB</c>
  /// </summary>
  SingletonTab,

  /// <summary>
  /// Shift key + Middle mouse button or meta/ctrl key while clicking.
  /// <c>WOD_NEW_FOREGROUND_TAB</c>
  /// </summary>
  NewForegroundTab,

  /// <summary>
  /// Middle mouse button or meta/ctrl key while clicking.
  /// <c>WOD_NEW_BACKGROUND_TAB</c>
  /// </summary>
  NewBackgroundTab,

  /// <summary>
  /// New popup window.
  /// <c>WOD_NEW_POPUP</c>
  /// </summary>
  NewPopup,

  /// <summary>
  /// Shift key while clicking.
  /// <c>WOD_NEW_WINDOW</c>
  /// </summary>
  NewWindow,

  /// <summary>
  /// Alt key while clicking.
  /// <c>WOD_SAVE_TO_DISK</c>
  /// </summary>
  SaveToDisk,

  /// <summary>
  /// New off-the-record (incognito) window.
  /// <c>WOD_OFF_THE_RECORD</c>
  /// </summary>
  OffTheRecord,

  /// <summary>
  /// Special case error condition from the renderer.
  /// <c>WOD_IGNORE_ACTION</c>
  /// </summary>
  IgnoreAction,

  /// <summary>
  /// Activates an existing tab containing the url, rather than navigating.
  /// This is similar to SINGLETON_TAB, but searches across all windows from
  /// the current profile and anonymity (instead of just the current one);
  /// closes the current tab on switching if the current tab was the NTP with
  /// no session history; and behaves like CURRENT_TAB instead of
  /// NEW_FOREGROUND_TAB when no existing tab is found.
  /// <c>WOD_SWITCH_TO_TAB</c>
  /// </summary>
  SwitchToTab,

  /// <summary>
  /// Creates a new document picture-in-picture window showing a child WebView.
  /// <c>WOD_NEW_PICTURE_IN_PICTURE</c>
  /// </summary>
  NewPictureInPicture,

}
