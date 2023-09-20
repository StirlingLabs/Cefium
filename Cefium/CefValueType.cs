namespace Cefium;

/// <summary>
/// Supported value types.
/// <c>cef_value_type_t</c>
/// </summary>
/// <seealso cref="CefListValue"/>
/// <seealso cref="CefDictionaryValue"/>
[PublicAPI]
public enum CefValueType {

  /// <summary>
  /// <c>VTYPE_INVALID</c>
  /// </summary>
  Invalid = 0,

  /// <summary>
  /// <c>VTYPE_NULL</c>
  /// </summary>
  Null,

  /// <summary>
  /// <c>VTYPE_BOOL</c>
  /// </summary>
  Bool,

  /// <summary>
  /// <c>VTYPE_INT</c>
  /// </summary>
  Int,

  /// <summary>
  /// <c>VTYPE_DOUBLE</c>
  /// </summary>
  Double,

  /// <summary>
  /// <c>VTYPE_STRING</c>
  /// </summary>
  String,

  /// <summary>
  /// <c>VTYPE_BINARY</c>
  /// </summary>
  Binary,

  /// <summary>
  /// <c>VTYPE_DICTIONARY</c>
  /// </summary>
  Dictionary,

  /// <summary>
  /// <c>VTYPE_LIST</c>
  /// </summary>
  List

}
