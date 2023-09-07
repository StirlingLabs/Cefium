namespace Cefaloid;

/// <summary>
/// DOM node types.
/// <c>cef_dom_node_type_t</c>
/// </summary>
/// <seealso cref="CefDomNode"/>
[PublicAPI]
public enum CefDomNodeType {

  /// <summary>
  /// Unsupported node type.
  /// <c>DOM_NODE_TYPE_UNSUPPORTED</c>
  /// </summary>
  Unsupported = 0,

  /// <summary>
  /// An element node like &lt;a&gt; or &lt;div&gt;.
  /// <c>DOM_NODE_TYPE_ELEMENT</c>
  /// </summary>
  Element,

  /// <summary>
  /// A #text node.
  /// <c>DOM_NODE_TYPE_ATTRIBUTE</c>
  /// </summary>
  Attribute,

  /// <summary>
  /// A #text node.
  /// <c>DOM_NODE_TYPE_TEXT</c>
  /// </summary>
  Text,

  /// <summary>
  /// A #cdata-section node.
  /// <c>DOM_NODE_TYPE_CDATA_SECTION</c>
  /// </summary>
  CdataSection,

  /// <summary>
  /// Processing instruction node.
  /// <c>DOM_NODE_TYPE_PROCESSING_INSTRUCTIONS</c>
  /// </summary>
  ProcessingInstructions,

  /// <summary>
  /// A comment node.
  /// <c>DOM_NODE_TYPE_COMMENT</c>
  /// </summary>
  Comment,

  /// <summary>
  /// A document node.
  /// <c>DOM_NODE_TYPE_DOCUMENT</c>
  /// </summary>
  Document,

  /// <summary>
  /// A document type node.
  /// <c>DOM_NODE_TYPE_DOCUMENT_TYPE</c>
  /// </summary>
  DocumentType,

  /// <summary>
  /// A document fragment node.
  /// <c>DOM_NODE_TYPE_DOCUMENT_FRAGMENT</c>
  /// </summary>
  DocumentFragment,

}
