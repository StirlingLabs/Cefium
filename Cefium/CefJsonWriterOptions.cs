namespace Cefium;

public enum CefJsonWriterOptions : int {

  // cef_json_writer_options_t
  JsonWriterDefault = 0, // JSON_WRITER_DEFAULT

  JsonWriterOmitBinaryValues = 1, // JSON_WRITER_OMIT_BINARY_VALUES

  JsonWriterOmitDoubleTypePreservation = 2, // JSON_WRITER_OMIT_DOUBLE_TYPE_PRESERVATION

  JsonWriterPrettyPrint = 4, // JSON_WRITER_PRETTY_PRINT

}
