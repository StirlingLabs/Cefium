namespace Cefium;

/// <summary>
/// Structure used to implement a custom resource bundle structure. See
/// CefSettings for additional options related to resource bundle loading. The
/// functions of this structure may be called on multiple threads.
/// <c>cef_resource_bundle_handler_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefResourceBundleHandler : ICefRefCountedBase<CefResourceBundleHandler> {

  /// <inheritdoc cref="CefResourceBundleHandler"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefResourceBundleHandler() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Called to retrieve a localized translation for the specified |string_id|.
  /// To provide the translation set |string| to the translation string and
  /// return true (1). To use the default translation return false (0). Include
  /// cef_pack_strings.h for a listing of valid string ID values.
  /// <c>int(CEF_CALLBACK* get_localized_string)(struct _cef_resource_bundle_handler_t* self, int string_id, cef_string_t* string);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceBundleHandler*, int, CefString*, int> _GetLocalizedString;

  /// <summary>
  /// Called to retrieve data for the specified scale independent |resource_id|.
  /// To provide the resource data set |data| and |data_size| to the data
  /// pointer and size respectively and return true (1). To use the default
  /// resource data return false (0). The resource data will not be copied and
  /// must remain resident in memory. Include cef_pack_resources.h for a listing
  /// of valid resource ID values.
  /// <c>int(CEF_CALLBACK* get_data_resource)(struct _cef_resource_bundle_handler_t* self, int resource_id, void** data, size_t* data_size);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceBundleHandler*, int, void**, nuint*, int> _GetDataResource;

  /// <summary>
  /// Called to retrieve data for the specified |resource_id| nearest the scale
  /// factor |scale_factor|. To provide the resource data set |data| and
  /// |data_size| to the data pointer and size respectively and return true (1).
  /// To use the default resource data return false (0). The resource data will
  /// not be copied and must remain resident in memory. Include
  /// cef_pack_resources.h for a listing of valid resource ID values.
  /// <c>int(CEF_CALLBACK* get_data_resource_for_scale)(struct _cef_resource_bundle_handler_t* self, int resource_id, cef_scale_factor_t scale_factor, void** data, size_t* data_size);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefResourceBundleHandler*, int, CefScaleFactor, void**, nuint*, int> _GetDataResourceForScale;

}
