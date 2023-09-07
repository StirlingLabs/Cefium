namespace Cefaloid;

/// <summary>
/// Structure that wraps platform-dependent share memory region mapping.
/// <c>cef_shared_memory_region_t</c>
/// </summary>
/// <seealso cref="CefSharedMemoryRegionExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSharedMemoryRegion : ICefRefCountedBase<CefSharedMemoryRegion> {

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns true (1) if the mapping is valid.
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_shared_memory_region_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSharedMemoryRegion*, int> _IsValid;

  /// <summary>
  /// Returns the size of the mapping in bytes. Returns 0 for invalid instances.
  /// <c>size_t(CEF_CALLBACK* size)(struct _cef_shared_memory_region_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSharedMemoryRegion*, nuint> _Size;

  /// <summary>
  /// Returns the pointer to the memory. Returns nullptr for invalid instances.
  /// The returned pointer is only valid for the life span of this object.
  /// <c>const void*(CEF_CALLBACK* memory)(struct _cef_shared_memory_region_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSharedMemoryRegion*, void*> _Memory;

}
