namespace Cefaloid;

/// <summary>
/// Structure representing a V8 value handle. V8 handles can only be accessed
/// from the thread on which they are created. Valid threads for creating a V8
/// handle include the render process main thread (TID_RENDERER) and WebWorker
/// threads. A task runner for posting tasks on the associated thread can be
/// retrieved via the cef_v8context_t::get_task_runner() function.
/// <c>cef_v8value_t</c>
/// </summary>
/// <seealso cref="CefValueExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefValue : ICefRefCountedBase<CefValue> {
  [Obsolete(DoNotConstructDirectly, true)]
  public CefValue() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Creates a new object.
  /// <c>CEF_EXPORT cef_value_t* cef_value_create(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_v8value_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefValue* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefValue* Create() => _Create();

  /// <summary>
  /// Returns true (1) if the underlying handle is valid and it can be accessed
  /// on the current thread. Do not call any other functions if this function
  /// returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsValid;

  /// <summary>
  /// True if the value type is undefined.
  /// <c>int(CEF_CALLBACK* is_undefined)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsUndefined;

  /// <summary>
  /// True if the value type is null.
  /// <c>int(CEF_CALLBACK* is_null)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsNull;

  /// <summary>
  /// True if the value type is bool.
  /// <c>int(CEF_CALLBACK* is_bool)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsBool;

  /// <summary>
  /// True if the value type is int.
  /// <c>int(CEF_CALLBACK* is_int)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsInt;

  /// <summary>
  /// True if the value type is unsigned int.
  /// <c>int(CEF_CALLBACK* is_uint)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsUInt;

  /// <summary>
  /// True if the value type is double.
  /// <c>int(CEF_CALLBACK* is_double)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsDouble;

  /// <summary>
  /// True if the value type is Date.
  /// <c>int(CEF_CALLBACK* is_date)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsDate;

  /// <summary>
  /// True if the value type is string.
  /// <c>int(CEF_CALLBACK* is_string)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsString;

  /// <summary>
  /// True if the value type is object.
  /// <c>int(CEF_CALLBACK* is_object)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsObject;

  /// <summary>
  /// True if the value type is array.
  /// <c>int(CEF_CALLBACK* is_array)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsArray;

  /// <summary>
  /// True if the value type is an ArrayBuffer.
  /// <c>int(CEF_CALLBACK* is_array_buffer)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsArrayBuffer;

  /// <summary>
  /// True if the value type is function.
  /// <c>int(CEF_CALLBACK* is_function)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsFunction;

  /// <summary>
  /// True if the value type is a Promise.
  /// <c>int(CEF_CALLBACK* is_promise)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsPromise;

  /// <summary>
  /// Returns true (1) if this object is pointing to the same handle as |that|
  /// object.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_v8value_t* self, struct _cef_v8value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefValue*, int> _IsSame;

  /// <summary>
  /// Return a bool value.
  /// <c>int(CEF_CALLBACK* get_bool_value)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _GetBoolValue;

  /// <summary>
  /// Return an int value.
  /// <c>int32(CEF_CALLBACK* get_int_value)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _GetIntValue;

  /// <summary>
  /// Return an unsigned int value.
  /// <c>uint32(CEF_CALLBACK* get_uint_value)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, uint> _GetUIntValue;

  /// <summary>
  /// Return a double value.
  /// <c>double(CEF_CALLBACK* get_double_value)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, double> _GetDoubleValue;

  /// <summary>
  /// Return a Date value.
  /// <c>cef_basetime_t(CEF_CALLBACK* get_date_value)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefBaseTime> _GetDateValue;

  /// <summary>
  /// Return a string value.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_string_value)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefString*> _GetStringValue;

  /// <summary>
  /// Returns true (1) if this is a user created object.
  /// <c>int(CEF_CALLBACK* is_user_created)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _IsUserCreated;

  /// <summary>
  /// Returns true (1) if the last function call resulted in an exception. This
  /// attribute exists only in the scope of the current CEF value object.
  /// <c>int(CEF_CALLBACK* has_exception)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _HasException;

  /// <summary>
  /// Returns the exception resulting from the last function call. This
  /// attribute exists only in the scope of the current CEF value object.
  /// <c>struct _cef_v8exception_t*(CEF_CALLBACK* get_exception)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefV8Exception*> _GetException;

  /// <summary>
  /// Clears the last exception and returns true (1) on success.
  /// <c>int(CEF_CALLBACK* clear_exception)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _ClearException;

  /// <summary>
  /// Returns true (1) if this object will re-throw future exceptions. This
  /// attribute exists only in the scope of the current CEF value object.
  /// <c>int(CEF_CALLBACK* will_rethrow_exceptions)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _WillRethrowExceptions;

  /// <summary>
  /// Set whether this object will re-throw future exceptions. By default
  /// exceptions are not re-thrown. If a exception is re-thrown the current
  /// context should not be accessed again until after the exception has been
  /// caught and not re-thrown. Returns true (1) on success. This attribute
  /// exists only in the scope of the current CEF value object.
  /// <c>int(CEF_CALLBACK* set_rethrow_exceptions)(struct _cef_v8value_t* self, int rethrow);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int, int> _SetRethrowExceptions;

  /// <summary>
  /// Returns true (1) if the object has a value with the specified identifier.
  /// <c>int(CEF_CALLBACK* has_value_bykey)(struct _cef_v8value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefString*, int> _HasValueByKey;

  /// <summary>
  /// Returns true (1) if the object has a value with the specified identifier.
  /// <c>int(CEF_CALLBACK* has_value_byindex)(struct _cef_v8value_t* self, int index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int, int> _HasValueByIndex;

  /// <summary>
  /// Deletes the value with the specified identifier and returns true (1) on
  /// success. Returns false (0) if this function is called incorrectly or an
  /// exception is thrown. For read-only and don't-delete values this function
  /// will return true (1) even though deletion failed.
  /// <c>int(CEF_CALLBACK* delete_value_bykey)(struct _cef_v8value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefString*, int> _DeleteValueByKey;

  /// <summary>
  /// Deletes the value with the specified identifier and returns true (1) on
  /// success. Returns false (0) if this function is called incorrectly,
  /// deletion fails or an exception is thrown. For read-only and don't-delete
  /// values this function will return true (1) even though deletion failed.
  /// <c>int(CEF_CALLBACK* delete_value_byindex)(struct _cef_v8value_t* self, int index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int, int> _DeleteValueByIndex;

  /// <summary>
  /// Returns the value with the specified identifier on success. Returns NULL
  /// if this function is called incorrectly or an exception is thrown.
  /// <c>struct _cef_v8value_t*(CEF_CALLBACK* get_value_bykey)(struct _cef_v8value_t* self, const cef_string_t* key);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefString*, CefValue*> _GetValueByKey;

  /// <summary>
  /// Returns the value with the specified identifier on success. Returns NULL
  /// if this function is called incorrectly or an exception is thrown.
  /// <c>struct _cef_v8value_t*(CEF_CALLBACK* get_value_byindex)(struct _cef_v8value_t* self, int index);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int, CefValue*> _GetValueByIndex;

  /// <summary>
  /// Associates a value with the specified identifier and returns true (1) on
  /// success. Returns false (0) if this function is called incorrectly or an
  /// exception is thrown. For read-only values this function will return true
  /// (1) even though assignment failed.
  /// <c>int(CEF_CALLBACK* set_value_bykey)(struct _cef_v8value_t* self, const cef_string_t* key, struct _cef_v8value_t* value, cef_v8_propertyattribute_t attribute);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefString*, CefValue*, CefV8PropertyAttribute, int> _SetValueByKey;

  /// <summary>
  /// Associates a value with the specified identifier and returns true (1) on
  /// success. Returns false (0) if this function is called incorrectly or an
  /// exception is thrown. For read-only values this function will return true
  /// (1) even though assignment failed.
  /// <c>int(CEF_CALLBACK* set_value_byindex)(struct _cef_v8value_t* self, int index, struct _cef_v8value_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int, CefValue*, int> _SetValueByIndex;

  /// <summary>
  /// Registers an identifier and returns true (1) on success. Access to the
  /// identifier will be forwarded to the cef_v8accessor_t instance passed to
  /// cef_v8value_t::cef_v8value_create_object(). Returns false (0) if this
  /// function is called incorrectly or an exception is thrown. For read-only
  /// values this function will return true (1) even though assignment failed.
  /// <c>int(CEF_CALLBACK* set_value_byaccessor)(struct _cef_v8value_t* self, const cef_string_t* key, cef_v8_accesscontrol_t settings, cef_v8_propertyattribute_t attribute);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefString*, CefV8AccessControl, CefV8PropertyAttribute, int> _SetValueByAccessor;

  /// <summary>
  /// Read the keys for the object's values into the specified vector. Integer-
  /// based keys will also be returned as strings.
  /// <c>int(CEF_CALLBACK* get_keys)(struct _cef_v8value_t* self, cef_string_list_t keys);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefStringList*, int> _GetKeys;

  /// <summary>
  /// Sets the user data for this object and returns true (1) on success.
  /// Returns false (0) if this function is called incorrectly. This function
  /// can only be called on user created objects.
  /// <c>int(CEF_CALLBACK* set_user_data)(struct _cef_v8value_t* self, struct _cef_base_ref_counted_t* user_data);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefRefCountedBase*, int> _SetUserData;

  /// <summary>
  /// Returns the user data, if any, assigned to this object.
  /// <c>struct _cef_base_ref_counted_t*(CEF_CALLBACK* get_user_data)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefRefCountedBase*> _GetUserData;

  /// <summary>
  /// Returns the amount of externally allocated memory registered for the
  /// object.
  /// <c>int(CEF_CALLBACK* get_externally_allocated_memory)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _GetExternallyAllocatedMemory;

  /// <summary>
  /// Adjusts the amount of registered external memory for the object. Used to
  /// give V8 an indication of the amount of externally allocated memory that is
  /// kept alive by JavaScript objects. V8 uses this information to decide when
  /// to perform global garbage collection. Each cef_v8value_t tracks the amount
  /// of external memory associated with it and automatically decreases the
  /// global total by the appropriate amount on its destruction.
  /// |change_in_bytes| specifies the number of bytes to adjust by. This
  /// function returns the number of bytes associated with the object after the
  /// adjustment. This function can only be called on user created objects.
  /// <c>int(CEF_CALLBACK* adjust_externally_allocated_memory)(struct _cef_v8value_t* self, int change_in_bytes);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int, int> _AdjustExternallyAllocatedMemory;

  /// <summary>
  /// Returns the number of elements in the array.
  /// <c>int(CEF_CALLBACK* get_array_length)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _GetArrayLength;

  /// <summary>
  /// Returns the ReleaseCallback object associated with the ArrayBuffer or NULL
  /// if the ArrayBuffer was not created with CreateArrayBuffer.
  /// <c>struct _cef_v8array_buffer_release_callback_t*(CEF_CALLBACK* get_array_buffer_release_callback)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefV8ArrayBufferReleaseCallback*> _GetArrayBufferReleaseCallback;

  /// <summary>
  /// Prevent the ArrayBuffer from using it's memory block by setting the length
  /// to zero. This operation cannot be undone. If the ArrayBuffer was created
  /// with CreateArrayBuffer then
  /// cef_v8array_buffer_release_callback_t::ReleaseBuffer will be called to
  /// release the underlying buffer.
  /// <c>int(CEF_CALLBACK* neuter_array_buffer)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, int> _NeuterArrayBuffer;

  /// <summary>
  /// Returns the function name.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_function_name)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefStringUserFree*> _GetFunctionName;

  /// <summary>
  /// Returns the function handler or NULL if not a CEF-created function.
  /// <c>struct _cef_v8handler_t*(CEF_CALLBACK* get_function_handler)(struct _cef_v8value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefV8Handler*> _GetFunctionHandler;

  /// <summary>
  /// Execute the function using the current V8 context. This function should
  /// only be called from within the scope of a cef_v8handler_t or
  /// cef_v8accessor_t callback, or in combination with calling enter() and
  /// exit() on a stored cef_v8context_t reference. |object| is the receiver
  /// ('this' object) of the function. If |object| is NULL the current context's
  /// global object will be used. |arguments| is the list of arguments that will
  /// be passed to the function. Returns the function return value on success.
  /// Returns NULL if this function is called incorrectly or an exception is
  /// thrown.
  /// <c>struct _cef_v8value_t*(CEF_CALLBACK* execute_function)(struct _cef_v8value_t* self, struct _cef_v8value_t* object, size_t argumentsCount, struct _cef_v8value_t* const* arguments);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefValue*, uint, CefValue*, CefValue*> _ExecuteFunction;

  /// <summary>
  /// Execute the function using the specified V8 context. |object| is the
  /// receiver ('this' object) of the function. If |object| is NULL the
  /// specified context's global object will be used. |arguments| is the list of
  /// arguments that will be passed to the function. Returns the function return
  /// value on success. Returns NULL if this function is called incorrectly or
  /// an exception is thrown.
  /// <c>struct _cef_v8value_t*(CEF_CALLBACK* execute_function_with_context)(struct _cef_v8value_t* self, struct _cef_v8context_t* context, struct _cef_v8value_t* object, size_t argumentsCount, struct _cef_v8value_t* const* arguments);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefV8Context*, CefValue*, uint, CefValue*, CefValue*> _ExecuteFunctionWithContext;

  /// <summary>
  /// Resolve the Promise using the current V8 context. This function should
  /// only be called from within the scope of a cef_v8handler_t or
  /// cef_v8accessor_t callback, or in combination with calling enter() and
  /// exit() on a stored cef_v8context_t reference. |arg| is the argument passed
  /// to the resolved promise. Returns true (1) on success. Returns false (0) if
  /// this function is called incorrectly or an exception is thrown.
  /// <c>int(CEF_CALLBACK* resolve_promise)(struct _cef_v8value_t* self, struct _cef_v8value_t* arg);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefValue*, int> _ResolvePromise;

  /// <summary>
  /// Reject the Promise using the current V8 context. This function should only
  /// be called from within the scope of a cef_v8handler_t or cef_v8accessor_t
  /// callback, or in combination with calling enter() and exit() on a stored
  /// cef_v8context_t reference. Returns true (1) on success. Returns false (0)
  /// if this function is called incorrectly or an exception is thrown.
  /// <c>int(CEF_CALLBACK* reject_promise)(struct _cef_v8value_t* self, const cef_string_t* errorMsg);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefValue*, CefString*, int> _RejectPromise;

}
