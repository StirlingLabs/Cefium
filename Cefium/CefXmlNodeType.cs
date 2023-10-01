namespace Cefium;

public enum CefXmlNodeType : int {

  // cef_xml_node_type_t
  XmlNodeUnsupported = 0, // XML_NODE_UNSUPPORTED

  XmlNodeProcessingInstruction = 1, // XML_NODE_PROCESSING_INSTRUCTION

  XmlNodeDocumentType = 2, // XML_NODE_DOCUMENT_TYPE

  XmlNodeElementStart = 3, // XML_NODE_ELEMENT_START

  XmlNodeElementEnd = 4, // XML_NODE_ELEMENT_END

  XmlNodeAttribute = 5, // XML_NODE_ATTRIBUTE

  XmlNodeText = 6, // XML_NODE_TEXT

  XmlNodeCdata = 7, // XML_NODE_CDATA

  XmlNodeEntityReference = 8, // XML_NODE_ENTITY_REFERENCE

  XmlNodeWhitespace = 9, // XML_NODE_WHITESPACE

  XmlNodeComment = 10, // XML_NODE_COMMENT

}
