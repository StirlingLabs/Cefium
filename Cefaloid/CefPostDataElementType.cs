namespace Cefaloid;

/// <summary>
/// Post data elements may represent either bytes or files.
/// <c>cef_postdataelement_type_t</c>
/// </summary>
[PublicAPI]
public enum CefPostDataElementType {

  /// <summary>
  /// <c>PDE_TYPE_EMPTY</c>
  /// </summary>
  Empty = 0,

  /// <summary>
  /// <c>PDE_TYPE_BYTES</c>
  /// </summary>
  Bytes,

  /// <summary>
  /// <c>PDE_TYPE_FILE</c>
  /// </summary>
  File

}
