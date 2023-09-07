namespace Cefaloid;

/// <summary>
/// Structure used to represent a DOM document. The functions of this structure
/// should only be called on the render process main thread thread.
/// <c>cef_domdocument_t</c>
/// </summary>
/// <seealso cref="CefDomDocumentExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDomDocument : ICefRefCountedBase<CefDomDocument> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefDomDocument() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the document type.
  /// <c>cef_dom_document_type_t(CEF_CALLBACK* get_type)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefDomDocumentType> _GetType;

  /// <summary>
  /// Returns the root document node.
  /// <c>struct _cef_domnode_t*(CEF_CALLBACK* get_document)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefDomNode*> _GetDocument;

  /// <summary>
  /// Returns the BODY node of an HTML document.
  /// <c>struct _cef_domnode_t*(CEF_CALLBACK* get_body)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefDomNode*> _GetBody;

  /// <summary>
  /// Returns the HEAD node of an HTML document.
  /// <c>struct _cef_domnode_t*(CEF_CALLBACK* get_head)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefDomNode*> _GetHead;

  /// <summary>
  /// Returns the title of an HTML document.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_title)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefStringUserFree*> _GetTitle;

  /// <summary>
  /// Returns the document element with the specified ID value.
  /// <c>struct _cef_domnode_t*(CEF_CALLBACK* get_element_by_id)(struct _cef_domdocument_t* self, const cef_string_t* id);</c>
  /// </summary>
  ///
  /// Returns the node that currently has keyboard focus.
  /// <c>struct _cef_domnode_t*(CEF_CALLBACK* get_focused_node)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefDomNode*> _GetFocusedNode;

  /// <summary>
  /// Returns true (1) if a portion of the document is selected.
  /// <c>int(CEF_CALLBACK* has_selection)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, int> _HasSelection;

  /// <summary>
  /// Returns the selection offset within the start node.
  /// <c>int(CEF_CALLBACK* get_selection_start_offset)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, int> _GetSelectionStartOffset;

  /// <summary>
  /// Returns the selection offset within the end node.
  /// <c>int(CEF_CALLBACK* get_selection_end_offset)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, int> _GetSelectionEndOffset;

  /// <summary>
  /// Returns the contents of this selection as markup.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_selection_as_markup)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefStringUserFree*> _GetSelectionAsMarkup;

  /// <summary>
  /// Returns the contents of this selection as text.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_selection_as_text)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefStringUserFree*> _GetSelectionAsText;

  /// <summary>
  /// Returns the base URL for the document.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_base_url)(struct _cef_domdocument_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefStringUserFree*> _GetBaseUrl;

  /// <summary>
  /// Returns a complete URL based on the document base URL and the specified
  /// partial URL.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_complete_url)(struct _cef_domdocument_t* self, const cef_string_t* partialURL);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomDocument*, CefString*, CefStringUserFree*> _GetCompleteUrl;

}
