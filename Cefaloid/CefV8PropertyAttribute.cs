namespace Cefaloid;

/// <summary>
/// V8 property attribute values.
/// <c>cef_v8_propertyattribute_t</c>
/// </summary>
[PublicAPI, Flags]
public enum CefV8PropertyAttribute {

  /// <summary>
  /// Writeable, Enumerable, Configurable
  /// <c>V8_PROPERTY_ATTRIBUTE_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// Not writeable
  /// <c>V8_PROPERTY_ATTRIBUTE_READONLY</c>
  /// </summary>
  ReadOnly = 1 << 0,

  /// <summary>
  /// Not enumerable
  /// <c>V8_PROPERTY_ATTRIBUTE_DONTENUM</c>
  /// </summary>
  DontEnum = 1 << 1,

  /// <summary>
  /// Not configurable
  /// <c>V8_PROPERTY_ATTRIBUTE_DONTDELETE</c>
  /// </summary>
  DontDelete = 1 << 2

}
