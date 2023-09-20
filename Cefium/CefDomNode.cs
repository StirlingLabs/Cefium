namespace Cefium;

/// <summary>
/// Structure used to represent a DOM node. The functions of this structure should
/// only be called on the render process main thread.
/// <c>cef_domnode_t</c>
/// </summary>
/// <seealso cref="CefDomNodeExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDomNode : ICefRefCountedBase<CefDomNode> {

  /// <inheritdoc cref="CefDomNode"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDomNode() {
  }

  /// <summary>
  /// Base structure.
  /// <c>cef_base_t base</c>
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the type for this node.
  /// <c>cef_dom_node_type_t(CEF_CALLBACK* get_type)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefDomNodeType> _GetType;

  /// <summary>
  /// Returns true (1) if this is a text node.
  /// <c>int(CEF_CALLBACK* is_text)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, int> _IsText;

  /// <summary>
  /// Returns true (1) if this is an element node.
  /// <c>int(CEF_CALLBACK* is_element)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, int> _IsElement;

  /// <summary>
  /// Returns true (1) if this is an editable node.
  /// <c>int(CEF_CALLBACK* is_editable)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, int> _IsEditable;

  /// <summary>
  /// Returns true (1) if this is a form control element node.
  /// <c>int(CEF_CALLBACK* is_form_control_element)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, int> _IsFormControlElement;

  /// <summary>
  /// Returns the type of this form control element node.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_form_control_element_type)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefStringUserFree*> _GetFormControlElementType;

  /// <summary>
  /// Returns true (1) if this object is pointing to the same handle as |that|
  /// object.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_domnode_t* self, struct _cef_domnode_t* that);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefDomNode*, int> _IsSame;

  /// <summary>
  /// Returns the name of this node.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_name)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefStringUserFree*> _GetName;

  /// <summary>
  /// Returns the value of this node.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_value)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefStringUserFree*> _GetValue;

  /// <summary>
  /// Set the value of this node. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_value)(struct _cef_domnode_t* self, const cef_string_t* value);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefString*, int> _SetValue;

  /// <summary>
  /// Returns the contents of this node as markup.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_as_markup)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefStringUserFree*> _GetAsMarkup;

  /// <summary>
  /// Returns the document associated with this node.
  /// <c>cef_domdocument_t*(CEF_CALLBACK* get_document)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefDomDocument*> _GetDocument;

  /// <summary>
  /// Returns the parent node.
  /// <c>cef_domnode_t*(CEF_CALLBACK* get_parent)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefDomNode*> _GetParent;

  /// <summary>
  /// Returns the previous sibling node.
  /// <c>cef_domnode_t*(CEF_CALLBACK* get_previous_sibling)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefDomNode*> _GetPreviousSibling;

  /// <summary>
  /// Returns the next sibling node.
  /// <c>cef_domnode_t*(CEF_CALLBACK* get_next_sibling)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefDomNode*> _GetNextSibling;

  /// <summary>
  /// Returns true (1) if this node has child nodes.
  /// <c>int(CEF_CALLBACK* has_children)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, int> _HasChildren;

  /// <summary>
  /// Return the first child node.
  /// <c>cef_domnode_t*(CEF_CALLBACK* get_first_child)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefDomNode*> _GetFirstChild;

  /// <summary>
  /// Returns the last child node.
  /// <c>cef_domnode_t*(CEF_CALLBACK* get_last_child)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefDomNode*> _GetLastChild;

  /// <summary>
  /// Returns the tag name of this element.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_element_tag_name)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefStringUserFree*> _GetElementTagName;

  /// <summary>
  /// Returns true (1) if this element has attributes.
  /// <c>int(CEF_CALLBACK* has_element_attributes)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, int> _HasElementAttributes;

  /// <summary>
  /// Returns true (1) if this element has an attribute named |attrName|.
  /// <c>int(CEF_CALLBACK* has_element_attribute)(struct _cef_domnode_t* self, const cef_string_t* attrName);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefString*, int> _HasElementAttribute;

  /// <summary>
  /// Returns the element attribute named |attrName|.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_element_attribute)(struct _cef_domnode_t* self, const cef_string_t* attrName);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefString*, CefStringUserFree*> _GetElementAttribute;

  /// <summary>
  /// Returns a map of all element attributes.
  /// <c>cef_string_map_t*(CEF_CALLBACK* get_element_attributes)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefStringMap*> _GetElementAttributes;

  /// <summary>
  /// Set the value for the element attribute named |attrName|. Returns true (1)
  /// on success.
  /// <c>int(CEF_CALLBACK* set_element_attribute)(struct _cef_domnode_t* self, const cef_string_t* attrName, const cef_string_t* value);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefString*, CefString*, int> _SetElementAttribute;

  /// <summary>
  /// Returns the inner text of the element.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_element_inner_text)(struct _cef_domnode_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefStringUserFree*> _GetElementInnerText;

  /// <summary>
  /// Returns the bounds of the element.
  /// <c>void(CEF_CALLBACK* get_element_bounds)(struct _cef_domnode_t* self, cef_rect_t* rect);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomNode*, CefRect*, void> _GetElementBounds;

}
