namespace Cefaloid;

/// <summary>
/// DOM document types.
/// <c>cef_dom_document_type_t</c>
/// </summary>
/// <seealso cref="CefDomDocument"/>
[PublicAPI]
public enum CefDomDocumentType {

  /// <summary>
  /// <c>DOM_DOCUMENT_TYPE_UNKNOWN</c>
  /// </summary>
  Unknown = 0,

  /// <summary>
  /// <c>DOM_DOCUMENT_TYPE_HTML</c>
  /// </summary>
  Html,

  /// <summary>
  /// <c>DOM_DOCUMENT_TYPE_XHTML</c>
  /// </summary>
  Xhtml,

  /// <summary>
  /// <c>DOM_DOCUMENT_TYPE_PLUGIN</c>
  /// </summary>
  Plugin

}
