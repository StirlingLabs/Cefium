namespace Cefium;

/// <summary>
///
/// <c>cef_v8interceptor_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefV8Interceptor : ICefRefCountedBase<CefV8Interceptor> {

  /// <inheritdoc cref="CefV8Interceptor"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefV8Interceptor() {
  }

  /// <summary>
  /// Base structure.
  /// <c>cef_base_ref_counted_t base;</c>
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Handle retrieval of the interceptor value identified by |name|. |object|
  /// is the receiver ('this' object) of the interceptor. If retrieval succeeds,
  /// set |retval| to the return value. If the requested value does not exist,
  /// don't set either |retval| or |exception|. If retrieval fails, set
  /// |exception| to the exception that will be thrown. If the property has an
  /// associated accessor, it will be called only if you don't set |retval|.
  /// Return true (1) if interceptor retrieval was handled, false (0) otherwise.
  /// <c>int(CEF_CALLBACK* get_byname)(struct _cef_v8interceptor_t* self, const cef_string_t* name, struct _cef_v8value_t* object, struct _cef_v8value_t** retval, cef_string_t* exception);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Interceptor*, ref CefString, ref CefV8Value, CefV8Value**, ref CefString, int> _GetByName;

  /// <summary>
  /// Handle retrieval of the interceptor value identified by |index|. |object|
  /// is the receiver ('this' object) of the interceptor. If retrieval succeeds,
  /// set |retval| to the return value. If the requested value does not exist,
  /// don't set either |retval| or |exception|. If retrieval fails, set
  /// |exception| to the exception that will be thrown. Return true (1) if
  /// interceptor retrieval was handled, false (0) otherwise.
  /// <c>int(CEF_CALLBACK* get_byindex)(struct _cef_v8interceptor_t* self, int index, struct _cef_v8value_t* object, struct _cef_v8value_t** retval, cef_string_t* exception);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Interceptor*, int, ref CefV8Value, CefV8Value**, ref CefString, int> _GetByIndex;

  /// <summary>
  /// Handle assignment of the interceptor value identified by |name|. |object|
  /// is the receiver ('this' object) of the interceptor. |value| is the new
  /// value being assigned to the interceptor. If assignment fails, set
  /// |exception| to the exception that will be thrown. This setter will always
  /// be called, even when the property has an associated accessor. Return true
  /// (1) if interceptor assignment was handled, false (0) otherwise.
  /// <c>int(CEF_CALLBACK* set_byname)(struct _cef_v8interceptor_t* self, const cef_string_t* name, struct _cef_v8value_t* object, struct _cef_v8value_t* value, cef_string_t* exception);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Interceptor*, ref CefString, ref CefV8Value, ref CefV8Value, ref CefString, int> _SetByName;

  /// <summary>
  /// Handle assignment of the interceptor value identified by |index|. |object|
  /// is the receiver ('this' object) of the interceptor. |value| is the new
  /// value being assigned to the interceptor. If assignment fails, set
  /// |exception| to the exception that will be thrown. Return true (1) if
  /// interceptor assignment was handled, false (0) otherwise.
  /// <c>int(CEF_CALLBACK* set_byindex)(struct _cef_v8interceptor_t* self, int index, struct _cef_v8value_t* object, struct _cef_v8value_t* value, cef_string_t* exception);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Interceptor*, int, ref CefV8Value, ref CefV8Value, ref CefString, int> _SetByIndex;

}
