namespace Cefaloid;

/// <summary>
/// Structure representing a dictionary value. Can be used on any process and
/// thread.
/// <c>cef_dictionary_value_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDictionaryValue : ICefRefCountedBase<CefDictionaryValue> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefDictionaryValue() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Creates a new object that is not owned by any other object.
  /// <c>CEF_EXPORT cef_dictionary_value_t* cef_dictionary_value_create(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_dictionary_value_create", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe CefDictionaryValue* _Create();


  /// <inheritdoc cref="_Create"/>
  public static unsafe CefDictionaryValue* Create() => _Create();

  /// <summary>
  /// Returns true (1) if this object is valid. This object may become invalid
  /// if the underlying data is owned by another object (e.g. list or
  /// dictionary) and that other object is then modified or destroyed. Do not
  /// call any other functions if this function returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_dictionary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, int> _IsValid;

  /// <summary>
  /// Returns true (1) if this object is currently owned by another object.
  /// <c>int(CEF_CALLBACK* is_owned)(struct _cef_dictionary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, int> _IsOwned;

  /// <summary>
  /// Returns true (1) if the values of this object are read-only. Some APIs may
  /// expose read-only objects.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_dictionary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, int> _IsReadOnly;

  /// <summary>
  /// Returns true (1) if this object and |that| object have the same underlying
  /// data. If true (1) modifications to this object will also affect |that|
  /// object and vice-versa.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_dictionary_value_t* self, struct _cef_dictionary_value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefDictionaryValue*, int> _IsSame;

  /// <summary>
  /// Returns true (1) if this object and |that| object have an equivalent
  /// underlying value but are not necessarily the same object.
  /// <c>int(CEF_CALLBACK* is_equal)(struct _cef_dictionary_value_t* self, struct _cef_dictionary_value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefDictionaryValue*, int> _IsEqual;

  /// <summary>
  /// Returns a writable copy of this object. If |exclude_NULL_children| is true
  /// (1) any NULL dictionaries or lists will be excluded from the copy.
  /// <c>struct _cef_dictionary_value_t*(CEF_CALLBACK* copy)(struct _cef_dictionary_value_t* self, int exclude_empty_children);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, int, CefDictionaryValue*> _Copy;

  /// <summary>
  /// Returns the number of values.
  /// <c>size_t(CEF_CALLBACK* get_size)(struct _cef_dictionary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, nuint> _GetSize;

  /// <summary>
  /// Removes all values. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* clear)(struct _cef_dictionary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, int> _Clear;

  /// <summary>
  /// Returns true (1) if the current dictionary has a value for the given key.
  /// <c>int(CEF_CALLBACK* has_key)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, int> _HasKey;

  /// <summary>
  /// Reads all keys for this dictionary into the specified vector.
  /// <c>int(CEF_CALLBACK* get_keys)(struct _cef_dictionary_value_t* self, cef_string_list_t keys);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefStringList*, int> _GetKeys;

  /// <summary>
  /// Removes the value at the specified key. Returns true (1) is the value was
  /// removed successfully.
  /// <c>int(CEF_CALLBACK* remove)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, int> _Remove;

  /// <summary>
  /// Returns the value type for the specified key.
  /// <c>cef_value_type_t(CEF_CALLBACK* get_type)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefValueType> _GetType;

  /// <summary>
  /// Returns the value at the specified key. For simple types the returned
  /// value will copy existing data and modifications to the value will not
  /// modify this object. For complex types (binary, dictionary and list) the
  /// returned value will reference existing data and modifications to the value
  /// will modify this object.
  /// <c>struct _cef_value_t*(CEF_CALLBACK* get_value)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefValue*> _GetValue;

  /// <summary>
  /// Returns the value at the specified key as type bool.
  /// <c>int(CEF_CALLBACK* get_bool)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, int> _GetBool;

  /// <summary>
  /// Returns the value at the specified key as type int.
  /// <c>int(CEF_CALLBACK* get_int)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, int> _GetInt;

  /// <summary>
  /// Returns the value at the specified key as type double.
  /// <c>double(CEF_CALLBACK* get_double)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, double> _GetDouble;

  /// <summary>
  /// Returns the value at the specified key as type string.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_string)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefStringUserFree*> _GetString;

  /// <summary>
  /// Returns the value at the specified key as type binary. The returned value
  /// will reference existing data.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_binary)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefBinaryValue*> _GetBinary;

  /// <summary>
  /// Returns the value at the specified key as type dictionary. The returned
  /// value will reference existing data and modifications to the value will
  /// modify this object.
  /// <c>struct _cef_dictionary_value_t*(CEF_CALLBACK* get_dictionary)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefDictionaryValue*> _GetDictionary;

  /// <summary>
  /// Returns the value at the specified key as type list. The returned value
  /// will reference existing data and modifications to the value will modify
  /// this object.
  /// <c>struct _cef_list_value_t*(CEF_CALLBACK* get_list)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefListValue*> _GetList;

  /// <summary>
  /// Sets the value at the specified key. Returns true (1) if the value was set
  /// successfully. If |value| represents simple data then the underlying data
  /// will be copied and modifications to |value| will not modify this object.
  /// If |value| represents complex data (binary, dictionary or list) then the
  /// underlying data will be referenced and modifications to |value| will
  /// modify this object.
  /// <c>int(CEF_CALLBACK* set_value)(struct _cef_dictionary_value_t* self, const cef_string_t* key,  struct _cef_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefValue*, int> _SetValue;

  /// <summary>
  /// Sets the value at the specified key as type null. Returns true (1) if the
  /// value was set successfully.
  /// <c>int(CEF_CALLBACK* set_null)(struct _cef_dictionary_value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, int> _SetNull;

  /// <summary>
  /// Sets the value at the specified key as type bool. Returns true (1) if the
  /// value was set successfully.
  /// <c>int(CEF_CALLBACK* set_bool)(struct _cef_dictionary_value_t* self, const cef_string_t* key,  int value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, int, int> _SetBool;

  /// <summary>
  /// Sets the value at the specified key as type int. Returns true (1) if the
  /// value was set successfully.
  /// <c>int(CEF_CALLBACK* set_int)(struct _cef_dictionary_value_t* self, const cef_string_t* key, int value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, int, int> _SetInt;

  /// <summary>
  /// Sets the value at the specified key as type double. Returns true (1) if
  /// the value was set successfully.
  /// <c>int(CEF_CALLBACK* set_double)(struct _cef_dictionary_value_t* self, const cef_string_t* key, double value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, double, int> _SetDouble;

  /// <summary>
  /// Sets the value at the specified key as type string. Returns true (1) if
  /// the value was set successfully.
  /// <c>int(CEF_CALLBACK* set_string)(struct _cef_dictionary_value_t* self, const cef_string_t* key, const cef_string_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefString*, int> _SetString;

  /// <summary>
  /// Sets the value at the specified key as type binary. Returns true (1) if
  /// the value was set successfully. If |value| is currently owned by another
  /// object then the value will be copied and the |value| reference will not
  /// change. Otherwise, ownership will be transferred to this object and the
  /// |value| reference will be invalidated.
  /// <c>int(CEF_CALLBACK* set_binary)(struct _cef_dictionary_value_t* self, const cef_string_t* key, struct _cef_binary_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefBinaryValue*, int> _SetBinary;

  /// <summary>
  /// Sets the value at the specified key as type dict. Returns true (1) if the
  /// value was set successfully. If |value| is currently owned by another
  /// object then the value will be copied and the |value| reference will not
  /// change. Otherwise, ownership will be transferred to this object and the
  /// |value| reference will be invalidated.
  /// <c>int(CEF_CALLBACK* set_dictionary)(struct _cef_dictionary_value_t* self, const cef_string_t* key, struct _cef_dictionary_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefDictionaryValue*, int> _SetDictionary;

  /// <summary>
  /// Sets the value at the specified key as type list. Returns true (1) if the
  /// value was set successfully. If |value| is currently owned by another
  /// object then the value will be copied and the |value| reference will not
  /// change. Otherwise, ownership will be transferred to this object and the
  /// |value| reference will be invalidated.
  /// <c>int(CEF_CALLBACK* set_list)(struct _cef_dictionary_value_t* self, const cef_string_t* key, struct _cef_list_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDictionaryValue*, CefString*, CefListValue*, int> _SetList;

}
