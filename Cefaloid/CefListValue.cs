namespace Cefaloid;

/// <summary>
/// Structure representing a list value. Can be used on any process and thread.
/// <c>cef_list_value_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefListValue : ICefRefCountedBase<CefListValue> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefListValue() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Creates a new object that is not owned by any other object.
  /// <c>CEF_EXPORT cef_list_value_t* cef_list_value_create(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_list_value_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefListValue* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefListValue* CreateUndefined()
    => _Create();

  /// <summary>
  /// Returns true (1) if this object is valid. This object may become invalid
  /// if the underlying data is owned by another object (e.g. list or
  /// dictionary) and that other object is then modified or destroyed. Do not
  /// call any other functions if this function returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_list_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, int> _IsValid;

  /// <summary>
  /// Returns true (1) if this object is currently owned by another object.
  /// <c>int(CEF_CALLBACK* is_owned)(struct _cef_list_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, int> _IsOwned;

  /// <summary>
  /// Returns true (1) if the values of this object are read-only. Some APIs may
  /// expose read-only objects.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_list_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, int> _IsReadOnly;

  /// <summary>
  /// Returns true (1) if this object and |that| object have the same underlying
  /// data. If true (1) modifications to this object will also affect |that|
  /// object and vice-versa.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_list_value_t* self, struct _cef_list_value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, CefListValue*, int> _IsSame;

  /// <summary>
  /// Returns true (1) if this object and |that| object have an equivalent
  /// underlying value but are not necessarily the same object.
  /// <c>int(CEF_CALLBACK* is_equal)(struct _cef_list_value_t* self, struct _cef_list_value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, CefListValue*, int> _IsEqual;

  /// <summary>
  /// Returns a writable copy of this object.
  /// <c>struct _cef_list_value_t*(CEF_CALLBACK* copy)(struct _cef_list_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, CefListValue*> _Copy;

  /// <summary>
  /// Sets the number of values. If the number of values is expanded all new
  /// value slots will default to type null. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_size)(struct _cef_list_value_t* self, size_t size);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, int> _SetSize;

  /// <summary>
  /// Returns the number of values.
  /// <c>size_t(CEF_CALLBACK* get_size)(struct _cef_list_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint> _GetSize;

  /// <summary>
  /// Removes all values. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* clear)(struct _cef_list_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, int> _Clear;

  /// <summary>
  /// Removes the value at the specified index.
  /// <c>int(CEF_CALLBACK* remove)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, int> _Remove;

  /// <summary>
  /// Returns the value type at the specified index.
  /// <c>cef_value_type_t(CEF_CALLBACK* get_type)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefValueType> _GetType;

  /// <summary>
  /// Returns the value at the specified index. For simple types the returned
  /// value will copy existing data and modifications to the value will not
  /// modify this object. For complex types (binary, dictionary and list) the
  /// returned value will reference existing data and modifications to the value
  /// will modify this object.
  /// <c>struct _cef_value_t*(CEF_CALLBACK* get_value)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefValue*> _GetValue;

  /// <summary>
  /// Returns the value at the specified index as type bool.
  /// <c>int(CEF_CALLBACK* get_bool)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, int> _GetBool;

  /// <summary>
  /// Returns the value at the specified index as type int.
  /// <c>int(CEF_CALLBACK* get_int)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, int> _GetInt;

  /// <summary>
  /// Returns the value at the specified index as type double.
  /// <c>double(CEF_CALLBACK* get_double)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, double> _GetDouble;

  /// <summary>
  /// Returns the value at the specified index as type string.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_string)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefStringUserFree*> _GetString;

  /// <summary>
  /// Returns the value at the specified index as type binary. The returned
  /// value will reference existing data.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_binary)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefBinaryValue*> _GetBinary;

  /// <summary>
  /// Returns the value at the specified index as type dictionary. The returned
  /// value will reference existing data and modifications to the value will
  /// modify this object.
  /// <c>struct _cef_dictionary_value_t*(CEF_CALLBACK* get_dictionary)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefDictionaryValue*> _GetDictionary;

  /// <summary>
  /// Returns the value at the specified index as type list. The returned value
  /// will reference existing data and modifications to the value will modify
  /// this object.
  /// <c>struct _cef_list_value_t*(CEF_CALLBACK* get_list)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefListValue*> _GetList;

  /// <summary>
  /// Sets the value at the specified index. Returns true (1) if the value was
  /// set successfully. If |value| represents simple data then the underlying
  /// data will be copied and modifications to |value| will not modify this
  /// object. If |value| represents complex data (binary, dictionary or list)
  /// then the underlying data will be referenced and modifications to |value|
  /// will modify this object.
  /// <c>int(CEF_CALLBACK* set_value)(struct _cef_list_value_t* self, size_t index, struct _cef_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefValue*, int> _SetValue;

  /// <summary>
  /// Sets the value at the specified index as type null. Returns true (1) if
  /// the value was set successfully.
  /// <c>int(CEF_CALLBACK* set_null)(struct _cef_list_value_t* self, size_t index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, int> _SetNull;

  /// <summary>
  /// Sets the value at the specified index as type bool. Returns true (1) if
  /// the value was set successfully.
  /// <c>int(CEF_CALLBACK* set_bool)(struct _cef_list_value_t* self, size_t index, int value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, int, int> _SetBool;

  /// <summary>
  /// Sets the value at the specified index as type int. Returns true (1) if the
  /// value was set successfully.
  /// <c>int(CEF_CALLBACK* set_int)(struct _cef_list_value_t* self, size_t index, int value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, int, int> _SetInt;

  /// <summary>
  /// Sets the value at the specified index as type double. Returns true (1) if
  /// the value was set successfully.
  /// <c>int(CEF_CALLBACK* set_double)(struct _cef_list_value_t* self, size_t index, double value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, double, int> _SetDouble;

  /// <summary>
  /// Sets the value at the specified index as type string. Returns true (1) if
  /// the value was set successfully.
  /// <c>int(CEF_CALLBACK* set_string)(struct _cef_list_value_t* self, size_t index, const cef_string_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefString*, int> _SetString;

  /// <summary>
  /// Sets the value at the specified index as type binary. Returns true (1) if
  /// the value was set successfully. If |value| is currently owned by another
  /// object then the value will be copied and the |value| reference will not
  /// change. Otherwise, ownership will be transferred to this object and the
  /// |value| reference will be invalidated.
  /// <c>int(CEF_CALLBACK* set_binary)(struct _cef_list_value_t* self, size_t index, struct _cef_binary_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefBinaryValue*, int> _SetBinary;

  /// <summary>
  /// Sets the value at the specified index as type dict. Returns true (1) if
  /// the value was set successfully. If |value| is currently owned by another
  /// object then the value will be copied and the |value| reference will not
  /// change. Otherwise, ownership will be transferred to this object and the
  /// |value| reference will be invalidated.
  /// <c>int(CEF_CALLBACK* set_dictionary)(struct _cef_list_value_t* self, size_t index, struct _cef_dictionary_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefDictionaryValue*, int> _SetDictionary;

  /// <summary>
  /// Sets the value at the specified index as type list. Returns true (1) if
  /// the value was set successfully. If |value| is currently owned by another
  /// object then the value will be copied and the |value| reference will not
  /// change. Otherwise, ownership will be transferred to this object and the
  /// |value| reference will be invalidated.
  /// <c>int(CEF_CALLBACK* set_list)(struct _cef_list_value_t* self, size_t index, struct _cef_list_value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefListValue*, nuint, CefListValue*, int> _SetList;

}
