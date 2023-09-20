namespace Cefium;

/// <summary>
/// Structure used to represent a single element in the request post data. The
/// functions of this structure may be called on any thread.
/// <c>cef_post_data_element_t</c>
/// </summary>
/// <seealso cref="CefPostDataElementExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPostDataElement : ICefRefCountedBase<CefPostDataElement> {

  /// <inheritdoc cref="CefPostDataElement"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefPostDataElement() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  [DllImport("cef", EntryPoint = "cef_post_data_element_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefPostDataElement* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefPostDataElement* CreateUndefined()
    => _Create();

  /// <summary>
  /// Returns true (1) if this object is read-only.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_post_data_element_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostDataElement*, int> _IsReadOnly;

  /// <summary>
  /// Remove all contents from the post data element.
  /// <c>void(CEF_CALLBACK* set_to_empty)(struct _cef_post_data_element_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostDataElement*, void> _SetToEmpty;

  /// <summary>
  /// The post data element will represent a file.
  /// <c>void(CEF_CALLBACK* set_to_file)(struct _cef_post_data_element_t* self, const cef_string_t* fileName);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostDataElement*, CefString*, void> _SetToFile;

  /// <summary>
  /// The post data element will represent bytes.  The bytes passed in will be
  /// copied.
  /// <c>void(CEF_CALLBACK* set_to_bytes)(struct _cef_post_data_element_t* self, size_t size, const void* bytes);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostDataElement*, nuint, void*, void> _SetToBytes;

  /// <summary>
  /// Return the type of this post data element.
  /// <c>cef_postdataelement_type_t(CEF_CALLBACK* get_type)(struct _cef_post_data_element_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostDataElement*, CefPostDataElementType> _GetType;

  /// <summary>
  /// Return the file name.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_file)(struct _cef_post_data_element_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostDataElement*, CefStringUserFree> _GetFile;

  /// <summary>
  /// Return the number of bytes.
  /// <c>size_t(CEF_CALLBACK* get_bytes_count)(struct _cef_post_data_element_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostDataElement*, nuint> _GetBytesCount;

  /// <summary>
  /// Read up to |size| bytes into |bytes| and return the number of bytes
  /// actually read.
  /// <c>size_t(CEF_CALLBACK* get_bytes)(struct _cef_post_data_element_t* self, size_t size, void* bytes);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPostDataElement*, nuint, void*, nuint> _GetBytes;

}
