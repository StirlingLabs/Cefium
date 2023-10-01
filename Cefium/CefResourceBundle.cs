namespace Cefium;

/// <summary>
/// Structure used for retrieving resources from the resource bundle (*.pak)
/// files loaded by CEF during startup or via the cef_resource_bundle_handler_t
/// returned from cef_app_t::GetResourceBundleHandler. See CefSettings for
/// additional options related to resource bundle loading. The functions of this
/// structure may be called on any thread unless otherwise indicated.
/// <c>cef_resource_bundle_t</c>
/// </summary>
/// <seealso cref="CefResourceBundleExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefResourceBundle : ICefRefCountedBase<CefResourceBundle> {

  /// <inheritdoc cref="CefResourceBundle"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefResourceBundle() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the global resource bundle instance.
  /// <c>CEF_EXPORT cef_resource_bundle_t* cef_resource_bundle_get_global(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_resource_bundle_get_global", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefResourceBundle* GetGlobal();

  /// <summary>
  /// Returns the localized string for the specified |string_id| or an NULL
  /// string if the value is not found. Include cef_pack_strings.h for a listing
  /// of valid string ID values.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_localized_string)(struct _cef_resource_bundle_t* self, int string_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceBundle*, int, CefStringUserFree*> _GetLocalizedString;

  /// <summary>
  /// Returns a cef_binary_value_t containing the decompressed contents of the
  /// specified scale independent |resource_id| or NULL if not found. Include
  /// cef_pack_resources.h for a listing of valid resource ID values.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_data_resource)(struct _cef_resource_bundle_t* self, int resource_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceBundle*, int, CefBinaryValue*> _GetDataResource;

  /// <summary>
  /// Returns a cef_binary_value_t containing the decompressed contents of the
  /// specified |resource_id| nearest the scale factor |scale_factor| or NULL if
  /// not found. Use a |scale_factor| value of SCALE_FACTOR_NONE for scale
  /// independent resources or call GetDataResource instead.Include
  /// cef_pack_resources.h for a listing of valid resource ID values.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_data_resource_for_scale)(struct _cef_resource_bundle_t* self, int resource_id, cef_scale_factor_t scale_factor);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceBundle*, int, CefScaleFactor, CefBinaryValue*> _GetDataResourceForScale;

}
