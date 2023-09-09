namespace Cefaloid;

/// <summary>
///
/// <c>cef_v8accessor_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefV8Accessor : ICefRefCountedBase<CefV8Accessor> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefV8Accessor() {
  }

  /// <summary>
  /// Base structure.
  /// <c>cef_base_ref_counted_t base;</c>
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Handle retrieval the accessor value identified by |name|. |object| is the
  /// receiver ('this' object) of the accessor. If retrieval succeeds set
  /// |retval| to the return value. If retrieval fails set |exception| to the
  /// exception that will be thrown. Return true (1) if accessor retrieval was
  /// handled.
  /// <c>int(CEF_CALLBACK* get)(struct _cef_v8accessor_t* self, const cef_string_t* name, struct _cef_v8value_t* object, struct _cef_v8value_t** retval, cef_string_t* exception);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Accessor*, ref CefString, ref CefV8Value, CefV8Value**, ref CefString, int> _Get;

  /// <summary>
  /// Handle assignment of the accessor value identified by |name|. |object| is
  /// the receiver ('this' object) of the accessor. |value| is the new value
  /// being assigned to the accessor. If assignment fails set |exception| to the
  /// exception that will be thrown. Return true (1) if accessor assignment was
  /// handled.
  /// <c>int(CEF_CALLBACK* set)(struct _cef_v8accessor_t* self, const cef_string_t* name, struct _cef_v8value_t* object, struct _cef_v8value_t* value, cef_string_t* exception);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Accessor*, ref CefString, ref CefV8Value, ref CefV8Value, ref CefString, int> _Set;

}
