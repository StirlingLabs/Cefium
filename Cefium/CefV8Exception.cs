namespace Cefium;

/// <summary>
/// Structure representing a V8 exception. The functions of this structure may
/// be called on any render process thread.
/// <c>cef_v8exception_t</c>
/// </summary>
/// <seealso cref="CefV8ExceptionExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefV8Exception : ICefRefCountedBase<CefV8Exception> {

  /// <inheritdoc cref="CefV8Exception"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefV8Exception() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the exception message.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_message)(struct _cef_v8exception_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Exception*, CefStringUserFree*> _GetMessage;

  /// <summary>
  /// Returns the line of source code that the exception occurred within.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_source_line)(struct _cef_v8exception_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Exception*, CefStringUserFree*> _GetSourceLine;

  /// <summary>
  /// Returns the resource name for the script from where the function causing
  /// the error originates.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_script_resource_name)(struct _cef_v8exception_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Exception*, CefStringUserFree*> _GetScriptResourceName;

  /// <summary>
  /// Returns the 1-based number of the line where the error occurred or 0 if
  /// the line number is unknown.
  /// <c>int(CEF_CALLBACK* get_line_number)(struct _cef_v8exception_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Exception*, int> _GetLineNumber;

  /// <summary>
  /// Returns the index within the script of the first character where the error
  /// occurred.
  /// <c>int(CEF_CALLBACK* get_start_position)(struct _cef_v8exception_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Exception*, int> _GetStartPosition;

  /// <summary>
  /// Returns the index within the script of the last character where the error
  /// occurred.
  /// <c>int(CEF_CALLBACK* get_end_position)(struct _cef_v8exception_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Exception*, int> _GetEndPosition;

  /// <summary>
  /// Returns the index within the line of the first character where the error
  /// occurred.
  /// <c>int(CEF_CALLBACK* get_start_column)(struct _cef_v8exception_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Exception*, int> _GetStartColumn;

  /// <summary>
  /// Returns the index within the line of the last character where the error
  /// occurred.
  /// <c>int(CEF_CALLBACK* get_end_column)(struct _cef_v8exception_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefV8Exception*, int> _GetEndColumn;

}
