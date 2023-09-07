namespace Cefaloid;

/// <summary>
/// Structure that should be implemented to handle V8 function calls. The
/// functions of this structure will be called on the thread associated with the
/// V8 function.
/// <c>cef_v8handler_t</c>
/// </summary>
/// <seealso cref="CefV8HandlerExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefV8Handler : ICefRefCountedBase<CefV8Handler> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefV8Handler() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Handle execution of the function identified by |name|. |object| is the
  /// receiver ('this' object) of the function. |arguments| is the list of
  /// arguments passed to the function. If execution succeeds set |retval| to
  /// the function return value. If execution fails set |exception| to the
  /// exception that will be thrown. Return true (1) if execution was handled.
  /// <c>int(CEF_CALLBACK* execute)(struct _cef_v8handler_t* self, const cef_string_t* name, struct _cef_v8value_t* object, size_t argumentsCount, struct _cef_v8value_t* const* arguments, struct _cef_v8value_t** retval, cef_string_t* exception);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Handler*, CefString*, CefValue*, nuint, CefValue**, CefValue**, CefString*, int> _Execute;



}
