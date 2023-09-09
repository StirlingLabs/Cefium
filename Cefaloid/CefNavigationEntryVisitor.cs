namespace Cefaloid;

/// <summary>
/// Callback structure for cef_browser_host_t::GetNavigationEntries. The
/// functions of this structure will be called on the browser process UI thread.
/// <c>cef_navigation_entry_visitor_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefNavigationEntryVisitor : ICefRefCountedBase<CefNavigationEntryVisitor> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefNavigationEntryVisitor() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be executed. Do not keep a reference to |entry| outside
  /// of this callback. Return true (1) to continue visiting entries or false
  /// (0) to stop. |current| is true (1) if this entry is the currently loaded
  /// navigation entry. |index| is the 0-based index of this entry and |total|
  /// is the total number of entries.
  /// <c>int(CEF_CALLBACK* visit)(struct _cef_navigation_entry_visitor_t* self, struct _cef_navigation_entry_t* entry, int current, int index, int total);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefNavigationEntryVisitor*, CefNavigationEntry*, int, int, int, int> _Visit;

}
