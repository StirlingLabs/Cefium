namespace Cefium;

/// <summary>
/// Structure used to represent drag data. The functions of this structure may
/// be called on any thread.
/// <c>cef_drag_data_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDragData : ICefRefCountedBase<CefDragData> {

  /// <inheritdoc cref="CefDragData"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDragData() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_drag_data_t object.
  /// <c>CEF_EXPORT cef_drag_data_t* cef_drag_data_create(void)</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_drag_data_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefDragData* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefDragData* CreateUndefined()
    => _Create();

  /// <summary>
  /// Returns a copy of the current object.
  /// <c>struct _cef_drag_data_t*(CEF_CALLBACK* clone)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefDragData*> _Clone;

  /// <summary>
  /// Returns true (1) if this object is read-only.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, int> _IsReadOnly;

  /// <summary>
  /// Returns true (1) if the drag data is a link.
  /// <c>int(CEF_CALLBACK* is_link)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, int> _IsLink;

  /// <summary>
  /// Returns true (1) if the drag data is a text or html fragment.
  /// <c>int(CEF_CALLBACK* is_fragment)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, int> _IsFragment;

  /// <summary>
  /// Returns true (1) if the drag data is a file.
  /// <c>int(CEF_CALLBACK* is_file)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, int> _IsFile;

  /// <summary>
  /// Return the link URL that is being dragged.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_link_url)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStringUserFree*> _GetLinkUrl;

  /// <summary>
  /// Return the title associated with the link being dragged.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_link_title)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStringUserFree*> _GetLinkTitle;

  /// <summary>
  /// Return the metadata, if any, associated with the link being dragged.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_link_metadata)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStringUserFree*> _GetLinkMetadata;

  /// <summary>
  /// Return the plain text fragment that is being dragged.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_fragment_text)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStringUserFree*> _GetFragmentText;

  /// <summary>
  /// Return the text/html fragment that is being dragged.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_fragment_html)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStringUserFree*> _GetFragmentHtml;

  /// <summary>
  /// Return the base URL that the fragment came from. This value is used for
  /// resolving relative URLs and may be NULL.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_fragment_base_url)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStringUserFree*> _GetFragmentBaseUrl;

  /// <summary>
  /// Return the name of the file being dragged out of the browser window.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_file_name)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStringUserFree*> _GetFileName;

  /// <summary>
  /// Write the contents of the file being dragged out of the web view into
  /// |writer|. Returns the number of bytes sent to |writer|. If |writer| is
  /// NULL this function will return the size of the file contents in bytes.
  /// Call get_file_name() to get a suggested name for the file.
  /// <c>size_t(CEF_CALLBACK* get_file_contents)(struct _cef_drag_data_t* self, struct _cef_stream_writer_t* writer)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStreamWriter*, nuint> _GetFileContents;

  /// <summary>
  /// Retrieve the list of file names that are being dragged into the browser
  /// window.
  /// <c>int(CEF_CALLBACK* get_file_names)(struct _cef_drag_data_t* self, cef_string_list_t names)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefStringList*, int> _GetFileNames;

  /// <summary>
  /// Set the link URL that is being dragged.
  /// <c>void(CEF_CALLBACK* set_link_url)(struct _cef_drag_data_t* self, const cef_string_t* url)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefString*, void> _SetLinkUrl;

  /// <summary>
  /// Set the title associated with the link being dragged.
  /// <c>void(CEF_CALLBACK* set_link_title)(struct _cef_drag_data_t* self, const cef_string_t* title)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefString*, void> _SetLinkTitle;

  /// <summary>
  /// Set the metadata associated with the link being dragged.
  /// <c>void(CEF_CALLBACK* set_link_metadata)(struct _cef_drag_data_t* self, const cef_string_t* data)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefString*, void> _SetLinkMetadata;

  /// <summary>
  /// Set the plain text fragment that is being dragged.
  /// <c>void(CEF_CALLBACK* set_fragment_text)(struct _cef_drag_data_t* self, const cef_string_t* text)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefString*, void> _SetFragmentText;

  /// <summary>
  /// Set the text/html fragment that is being dragged.
  /// <c>void(CEF_CALLBACK* set_fragment_html)(struct _cef_drag_data_t* self, const cef_string_t* html)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefString*, void> _SetFragmentHtml;

  /// <summary>
  /// Set the base URL that the fragment came from.
  /// <c>void(CEF_CALLBACK* set_fragment_base_url)(struct _cef_drag_data_t* self, const cef_string_t* base_url)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefString*, void> _SetFragmentBaseUrl;

  /// <summary>
  /// Reset the file contents. You should do this before calling
  /// cef_browser_host_t::DragTargetDragEnter as the web view does not allow us
  /// to drag in this kind of data.
  /// <c>void(CEF_CALLBACK* reset_file_contents)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, void> _ResetFileContents;

  /// <summary>
  /// Add a file that is being dragged into the webview.
  /// <c>void(CEF_CALLBACK* add_file)(struct _cef_drag_data_t* self, const cef_string_t* path, const cef_string_t* display_name)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefString*, CefString*, void> _AddFile;

  /// <summary>
  /// Clear list of filenames.
  /// <c>void(CEF_CALLBACK* clear_filenames)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, void> _ClearFileNames;

  /// <summary>
  /// Get the image representation of drag data. May return NULL if no image
  /// representation is available.
  /// <c>struct _cef_image_t*(CEF_CALLBACK* get_image)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefImage*> _GetImage;

  /// <summary>
  /// Get the image hotspot (drag start location relative to image dimensions).
  /// <c>cef_point_t(CEF_CALLBACK* get_image_hotspot)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, CefPoint> _GetImageHotspot;

  /// <summary>
  /// Returns true (1) if an image representation of drag data is available.
  /// <c>int(CEF_CALLBACK* has_image)(struct _cef_drag_data_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDragData*, int> _HasImage;

}
