namespace Cefaloid;

public enum CefXmlEncodingType : int { // cef_xml_encoding_type_t
  XmlEncodingNone = 0, // XML_ENCODING_NONE
  XmlEncodingUtf8 = 1, // XML_ENCODING_UTF8
  XmlEncodingUtf16Le = 2, // XML_ENCODING_UTF16LE
  XmlEncodingUtf16Be = 3, // XML_ENCODING_UTF16BE
  XmlEncodingAscii = 4, // XML_ENCODING_ASCII
}