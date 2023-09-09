namespace Cefaloid;

/// <summary>
/// Structure to implement for visiting the DOM. The functions of this structure
/// will be called on the render process main thread.
/// <c>cef_domvisitor_t</c>
/// </summary>
/// <seealso cref="CefFrame"/>
/// <seealso cref="CefDomVisitorExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDomVisitor : ICefRefCountedBase<CefDomVisitor> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefDomVisitor() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method executed for visiting the DOM. The document object passed to this
  /// function represents a snapshot of the DOM at the time this function is
  /// executed. DOM objects are only valid for the scope of this function. Do
  /// not keep references to or attempt to access any DOM objects outside the
  /// scope of this function.
  /// <c>void(CEF_CALLBACK* visit)(struct _cef_domvisitor_t* self, struct _cef_domdocument_t* document);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDomVisitor*, CefDomDocument*, void> _Visit;

}
