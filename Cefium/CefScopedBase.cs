namespace Cefium;

/// <summary>
/// All scoped framework structures must include this structure first.
/// <c>cef_base_scoped_t</c>
/// </summary>
/// <seealso cref="CefScopedBaseExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefScopedBase {

  /// <summary>
  /// Size of the data structure.
  /// </summary>
  public nuint Size;

  /// <summary>
  /// Called to delete this object. May be NULL if the object is not owned.
  /// <c>void(CEF_CALLBACK* del)(struct _cef_base_scoped_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefScopedBase*, void> _Delete;

}
