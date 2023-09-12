namespace Cefaloid;

/// <summary>
/// Structure that wraps other data value types. Complex types (binary,
/// dictionary and list) will be referenced but not owned by this object. Can be
/// used on any process and thread.
/// <c>cef_value_t</c>
/// </summary>
public struct CefValue : ICefRefCountedBase<CefV8Value> {

  /// <inheritdoc cref="CefValue"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefValue() {
  }

  /// <summary>
  /// Base structure.
  /// <c>cef_base_ref_counted_t base;</c>
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Creates a new object.
  /// <c>CEF_EXPORT cef_value_t* cef_value_create(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_value_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefValue* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefValue* Create()
    => _Create();

  /// <summary>
  /// Returns true (1) if the underlying data is valid. This will always be true
  /// (1) for simple types. For complex types (binary, dictionary and list) the
  /// underlying data may become invalid if owned by another object (e.g. list
  /// or dictionary) and that other object is then modified or destroyed. This
  /// value object can be re-used by calling Set*() even if the underlying data
  /// is invalid.
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsValid;

  /// <summary>
  /// Returns true (1) if the underlying data is owned by another object.
  /// <c>int(CEF_CALLBACK* is_owned)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsOwned;

  /// <summary>
  /// Returns true (1) if the underlying data is read-only. Some APIs may expose
  /// read-only objects.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsReadOnly;

  /// <summary>
  /// Returns true (1) if this object and |that| object have the same underlying
  /// data. If true (1) modifications to this object will also affect |that|
  /// object and vice-versa.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_value_t* self, struct _cef_value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefValue*, int> _IsSame;

  /// <summary>
  /// Returns true (1) if this object and |that| object have an equivalent
  /// underlying value but are not necessarily the same object.
  /// <c>int(CEF_CALLBACK* is_equal)(struct _cef_value_t* self, struct _cef_value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefValue*, int> _IsEqual;

  /// <summary>
  /// Returns a copy of this object. The underlying data will also be copied.
  /// <c>struct _cef_value_t*(CEF_CALLBACK* copy)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefValue*> _Copy;

  /// <summary>
  /// Returns the underlying value type.
  /// <c>cef_value_type_t(CEF_CALLBACK* get_type)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefValueType> _GetType;

  /// <summary>
  /// Returns the underlying value as type bool.
  /// <c>int(CEF_CALLBACK* get_bool)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _GetBool;

  /// <summary>
  /// Returns the underlying value as type int.
  /// <c>int(CEF_CALLBACK* get_int)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _GetInt;

  /// <summary>
  /// Returns the underlying value as type double.
  /// <c>double(CEF_CALLBACK* get_double)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, double> _GetDouble;

  /// <summary>
  /// Returns the underlying value as type string.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_string)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefString> _GetString;

  /// <summary>
  /// Returns the underlying value as type binary. The returned reference may
  /// become invalid if the value is owned by another object or if ownership is
  /// transferred to another object in the future. To maintain a reference to
  /// the value after assigning ownership to a dictionary or list pass this
  /// object to the set_value() function instead of passing the returned
  /// reference to set_binary().
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_binary)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefBinaryValue*> _GetBinary;

  /// <summary>
  /// Returns the underlying value as type dictionary. The returned reference
  /// may become invalid if the value is owned by another object or if ownership
  /// is transferred to another object in the future. To maintain a reference to
  /// the value after assigning ownership to a dictionary or list pass this
  /// object to the set_value() function instead of passing the returned
  /// reference to set_dictionary().
  /// <c>struct _cef_dictionary_value_t*(CEF_CALLBACK* get_dictionary)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefDictionaryValue*> _GetDictionary;

  /// <summary>
  /// Returns the underlying value as type list. The returned reference may
  /// become invalid if the value is owned by another object or if ownership is
  /// transferred to another object in the future. To maintain a reference to
  /// the value after assigning ownership to a dictionary or list pass this
  /// object to the set_value() function instead of passing the returned
  /// reference to set_list().
  /// <c>struct _cef_list_value_t*(CEF_CALLBACK* get_list)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefListValue*> _GetList;

  /// <summary>
  /// Sets the underlying value as type null. Returns true (1) if the value was
  /// set successfully.
  /// <c>int(CEF_CALLBACK* set_null)(struct _cef_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _SetNull;

  /// <summary>
  /// Sets the underlying value as type bool. Returns true (1) if the value was
  /// set successfully.
  /// <c>int(CEF_CALLBACK* set_bool)(struct _cef_value_t* self, int value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int, int> _SetBool;

  /// <summary>
  /// Sets the underlying value as type int. Returns true (1) if the value was
  /// set successfully.
  /// <c>int(CEF_CALLBACK* set_int)(struct _cef_value_t* self, int value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int, int> _SetInt;

  /// <summary>
  /// Sets the underlying value as type double. Returns true (1) if the value
  /// was set successfully.
  /// <c>int(CEF_CALLBACK* set_double)(struct _cef_value_t* self, double value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, double, int> _SetDouble;

  /// <summary>
  /// Sets the underlying value as type string. Returns true (1) if the value
  /// was set successfully.
  /// <c>int(CEF_CALLBACK* set_string)(struct _cef_value_t* self, const cef_string_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, ref CefString, int> _SetString;

  /// <summary>
  /// Sets the underlying value as type binary. Returns true (1) if the value
  /// was set successfully. This object keeps a reference to |value| and
  /// ownership of the underlying data remains unchanged.
  /// <c>int(CEF_CALLBACK* set_binary)(struct _cef_value_t* self, struct _cef_binary_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefBinaryValue*, int> _SetBinary;

  /// <summary>
  /// Sets the underlying value as type dict. Returns true (1) if the value was
  /// set successfully. This object keeps a reference to |value| and ownership
  /// of the underlying data remains unchanged.
  /// <c>int(CEF_CALLBACK* set_dictionary)(struct _cef_value_t* self, struct _cef_dictionary_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefDictionaryValue*, int> _SetDictionary;

  /// <summary>
  /// Sets the underlying value as type list. Returns true (1) if the value was
  /// set successfully. This object keeps a reference to |value| and ownership
  /// of the underlying data remains unchanged.
  /// <c>int(CEF_CALLBACK* set_list)(struct _cef_value_t* self, struct _cef_list_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefListValue*, int> _SetList;

}
