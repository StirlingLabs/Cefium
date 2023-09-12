namespace Cefaloid;

/// <summary>
/// Implement this structure to receive string values asynchronously.
/// <c>cef_string_visitor_t</c>
/// </summary>
/// <seealso cref="CefString"/>
/// <seealso cref="CefStringVisitorExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefStringVisitor : ICefRefCountedBase<CefStringVisitor> {

  /// <inheritdoc cref="CefStringVisitor"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefStringVisitor() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be executed.
  /// <c>void(CEF_CALLBACK* visit)(struct _cef_string_visitor_t* self, const cef_string_t* string);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefStringVisitor*, CefString*, void> _Visit;

}
