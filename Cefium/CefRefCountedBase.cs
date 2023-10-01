namespace Cefium;

/// <summary>
/// All ref-counted framework structures must include this structure first.
/// <c>cef_base_ref_counted_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRefCountedBase {

  /// <summary>
  /// Size of the data structure.
  /// </summary>
  public nuint Size;

  /// <summary>
  /// Called to increment the reference count for the object. Should be called
  /// for every new copy of a pointer to a given object.
  /// <c>void(CEF_CALLBACK* add_ref)(struct _cef_base_ref_counted_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRefCountedBase*, void> _AddRef;

  /// <summary>
  /// Called to decrement the reference count for the object. If the reference
  /// count falls to 0 the object should self-delete. Returns true (1) if the
  /// resulting reference count is 0.
  /// <c>int(CEF_CALLBACK* release)(struct _cef_base_ref_counted_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRefCountedBase*, int> _Release;

  /// <summary>
  /// Returns true (1) if the current reference count is 1.
  /// <c>int(CEF_CALLBACK* has_one_ref)(struct _cef_base_ref_counted_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRefCountedBase*, int> _HasOneRef;

  /// <summary>
  /// Returns true (1) if the current reference count is at least 1.
  /// <c>int(CEF_CALLBACK* has_at_least_one_ref)(struct _cef_base_ref_counted_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefRefCountedBase*, int> _HasAtLeastOneRef;

}
