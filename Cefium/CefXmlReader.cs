namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 272)]
public struct CefXmlReader : ICefRefCountedBase<CefXmlReader> {

  // cef_xml_reader_t
  [DllImport("cef", EntryPoint = "cef_xml_reader_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefXmlReader* _Create(CefStreamReader* arg0, CefXmlEncodingType arg1, CefString* arg2);

  public CefRefCountedBase Base; // base @ 0, 40 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _MoveToNextNode; // move_to_next_node @ 40, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _Close; // close @ 48, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _HasError; // has_error @ 56, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetError; // get_error @ 64, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefXmlNodeType> _GetType; // get_type @ 72, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _GetDepth; // get_depth @ 80, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetLocalName; // get_local_name @ 88, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetPrefix; // get_prefix @ 96, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetQualifiedName; // get_qualified_name @ 104, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetNamespaceUri; // get_namespace_uri @ 112, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetBaseUri; // get_base_uri @ 120, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetXmlLang; // get_xml_lang @ 128, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _IsEmptyElement; // is_empty_element @ 136, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _HasValue; // has_value @ 144, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetValue; // get_value @ 152, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _HasAttributes; // has_attributes @ 160, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, uint> _GetAttributeCount; // get_attribute_count @ 168, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int, CefString*> _GetAttributeByindex; // get_attribute_byindex @ 176, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*, CefString*> _GetAttributeByqname; // get_attribute_byqname @ 184, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*, CefString*, CefString*> _GetAttributeBylname; // get_attribute_bylname @ 192, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetInnerXml; // get_inner_xml @ 200, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*> _GetOuterXml; // get_outer_xml @ 208, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _GetLineNumber; // get_line_number @ 216, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int, int> _MoveToAttributeByindex; // move_to_attribute_byindex @ 224, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*, int> _MoveToAttributeByqname; // move_to_attribute_byqname @ 232, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, CefString*, CefString*, int> _MoveToAttributeBylname; // move_to_attribute_bylname @ 240, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _MoveToFirstAttribute; // move_to_first_attribute @ 248, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _MoveToNextAttribute; // move_to_next_attribute @ 256, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefXmlReader*, int> _MoveToCarryingElement; // move_to_carrying_element @ 264, 8 bytes

}
