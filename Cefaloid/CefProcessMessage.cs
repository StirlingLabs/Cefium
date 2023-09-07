namespace Cefaloid;

/// <summary>
/// Structure representing a message. Can be used on any process and thread.
/// <c>cef_process_message_t</c>
/// </summary>
/// <seealso cref="CefProcessMessageExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefProcessMessage : ICefRefCountedBase<CefProcessMessage> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefProcessMessage() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_process_message_t object with the specified name.
  /// <c>CEF_EXPORT cef_process_message_t* cef_process_message_create(const cef_string_t* name);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_process_message_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefProcessMessage* Create(CefString* name);

  /// <summary>
  /// Returns true (1) if this object is valid. Do not call any other functions
  /// if this function returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_process_message_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefProcessMessage*, int> _IsValid;

  /// <summary>
  /// Returns true (1) if the values of this object are read-only. Some APIs may
  /// expose read-only objects.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_process_message_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefProcessMessage*, int> _IsReadOnly;

  /// <summary>
  /// Returns a writable copy of this object. Returns nullptr when message
  /// contains a shared memory region.
  /// <c>struct _cef_process_message_t*(CEF_CALLBACK* copy)(struct _cef_process_message_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefProcessMessage*, CefProcessMessage*> _Copy;

  /// <summary>
  /// Returns the message name.
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_name)(struct _cef_process_message_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefProcessMessage*, CefStringUserFree*> _GetName;

  /// <summary>
  /// Returns the shared memory region. Returns nullptr when message contains an
  /// argument list.
  /// <c>struct _cef_shared_memory_region_t*(CEF_CALLBACK* get_shared_memory_region)(struct _cef_process_message_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefProcessMessage*, CefSharedMemoryRegion*> _GetSharedMemoryRegion;

}
