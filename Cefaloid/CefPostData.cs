namespace Cefaloid;

/// <summary>
/// Structure used to represent post data for a web request. The functions of
/// this structure may be called on any thread.
/// <c>cef_post_data_t</c>
/// </summary>
/// <seealso cref="CefPostDataExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPostData : ICefRefCountedBase<CefPostData> {
  [Obsolete(DoNotConstructDirectly, true)]
  public CefPostData() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_post_data_t object.
  /// <c>CEF_EXPORT cef_post_data_t* cef_post_data_create(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_post_data_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefPostData* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefPostData* Create() => _Create();

  /// <summary>
  /// Returns true (1) if this object is read-only.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_post_data_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostData*, int> _IsReadOnly;

  /// <summary>
  /// Returns true (1) if the underlying POST data includes elements that are
  /// not represented by this cef_post_data_t object (for example, multi-part
  /// file upload data). Modifying cef_post_data_t objects with excluded
  /// elements may result in the request failing.
  /// <c>int(CEF_CALLBACK* has_excluded_elements)(struct _cef_post_data_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostData*, int> _HasExcludedElements;

  /// <summary>
  /// Returns the number of existing post data elements.
  /// <c>size_t(CEF_CALLBACK* get_element_count)(struct _cef_post_data_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostData*, nuint> _GetElementCount;

  /// <summary>
  /// Retrieve the post data elements.
  /// <c>void(CEF_CALLBACK* get_elements)(struct _cef_post_data_t* self, size_t* elementsCount, struct _cef_post_data_element_t** elements);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostData*, nuint*, CefPostDataElement**, void> _GetElements;

  /// <summary>
  /// Remove the specified post data element.  Returns true (1) if the removal
  /// succeeds.
  /// <c>int(CEF_CALLBACK* remove_element)(struct _cef_post_data_t* self, struct _cef_post_data_element_t* element);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostData*, CefPostDataElement*, int> _RemoveElement;

  /// <summary>
  /// Add the specified post data element.  Returns true (1) if the add
  /// succeeds.
  /// <c>int(CEF_CALLBACK* add_element)(struct _cef_post_data_t* self, struct _cef_post_data_element_t* element);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostData*, CefPostDataElement*, int> _AddElement;

  /// <summary>
  /// Remove all existing post data elements.
  /// <c>void(CEF_CALLBACK* remove_elements)(struct _cef_post_data_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostData*, void> _RemoveElements;

}
