namespace Cefium;

/// <summary>
/// Manage access to preferences.
/// <c>cef_preference_manager_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPreferenceManager : ICefRefCountedBase<CefPreferenceManager> {

  /// <inheritdoc cref="CefPreferenceManager"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefPreferenceManager() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns true (1) if a preference with the specified |name| exists. This
  /// function must be called on the browser process UI thread.
  /// <c>int(CEF_CALLBACK* has_preference)(struct _cef_preference_manager_t* self, const cef_string_t* name);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPreferenceManager*, CefString*, int> _HasPreference;

  /// <summary>
  /// Returns the value for the preference with the specified |name|. Returns
  /// NULL if the preference does not exist. The returned object contains a copy
  /// of the underlying preference value and modifications to the returned
  /// object will not modify the underlying preference value. This function must
  /// be called on the browser process UI thread.
  /// <c>struct _cef_value_t*(CEF_CALLBACK* get_preference)(struct _cef_preference_manager_t* self, const cef_string_t* name);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPreferenceManager*, CefString*, CefValue*> _GetPreference;

  /// <summary>
  /// Returns all preferences as a dictionary. If |include_defaults| is true (1)
  /// then preferences currently at their default value will be included. The
  /// returned object contains a copy of the underlying preference values and
  /// modifications to the returned object will not modify the underlying
  /// preference values. This function must be called on the browser process UI
  /// thread.
  /// <c>struct _cef_dictionary_value_t*(CEF_CALLBACK* get_all_preferences)(struct _cef_preference_manager_t* self, int include_defaults);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPreferenceManager*, int, CefDictionaryValue*> _GetAllPreferences;

  /// <summary>
  /// Returns true (1) if the preference with the specified |name| can be
  /// modified using SetPreference. As one example preferences set via the
  /// command-line usually cannot be modified. This function must be called on
  /// the browser process UI thread.
  /// <c>int(CEF_CALLBACK* can_set_preference)(struct _cef_preference_manager_t* self, const cef_string_t* name);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPreferenceManager*, CefString*, int> _CanSetPreference;

  /// <summary>
  /// Set the |value| associated with preference |name|. Returns true (1) if the
  /// value is set successfully and false (0) otherwise. If |value| is NULL the
  /// preference will be restored to its default value. If setting the
  /// preference fails then |error| will be populated with a detailed
  /// description of the problem. This function must be called on the browser
  /// process UI thread.
  /// <c>int(CEF_CALLBACK* set_preference)(struct _cef_preference_manager_t* self, const cef_string_t* name, struct _cef_value_t* value, cef_string_t* error);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPreferenceManager*, CefString*, CefValue*, CefString*, int> _SetPreference;

}
