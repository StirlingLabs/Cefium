namespace Cefaloid;

/// <summary>
/// Structure that manages custom preference registrations.
/// <c>cef_preference_registrar_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPreferenceRegistrar {


  /// <summary>
  /// Base structure.
  /// </summary>
  public CefScopedBase Base;

  /// <summary>
  /// Register a preference with the specified |name| and |default_value|. To
  /// avoid conflicts with built-in preferences the |name| value should contain
  /// an application-specific prefix followed by a period (e.g. "myapp.value").
  /// The contents of |default_value| will be copied. The data type for the
  /// preference will be inferred from |default_value|'s type and cannot be
  /// changed after registration. Returns true (1) on success. Returns false (0)
  /// if |name| is already registered or if |default_value| has an invalid type.
  /// This function must be called from within the scope of the
  /// cef_browser_process_handler_t::OnRegisterCustomPreferences callback.
  /// <c>int(CEF_CALLBACK* add_preference)(struct _cef_preference_registrar_t* self, const cef_string_t* name, struct _cef_value_t* default_value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPreferenceRegistrar*, CefString*, CefValue*, int> _AddPreference;
}
