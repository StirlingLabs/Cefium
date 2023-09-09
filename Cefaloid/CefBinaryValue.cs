namespace Cefaloid;

/// <summary>
/// Structure representing a binary value. Can be used on any process and
/// thread.
/// <c>cef_binary_value_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefBinaryValue : ICefRefCountedBase<CefBinaryValue> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefBinaryValue() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Creates a new object that is not owned by any other object. The specified
  /// |data| will be copied.
  /// <c>CEF_EXPORT cef_binary_value_t* cef_binary_value_create(const void* data, size_t data_size);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_binary_value_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefBinaryValue* Create(void* data, uint dataSize);

  /// <summary>
  /// Returns true (1) if this object is valid. This object may become invalid
  /// if the underlying data is owned by another object (e.g. list or
  /// dictionary) and that other object is then modified or destroyed. Do not
  /// call any other functions if this function returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_binary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBinaryValue*, int> _IsValid;

  /// <summary>
  /// Returns true (1) if this object is currently owned by another object.
  /// <c>int(CEF_CALLBACK* is_owned)(struct _cef_binary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBinaryValue*, int> _IsOwned;

  /// <summary>
  /// Returns true (1) if this object and |that| object have the same underlying
  /// data.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_binary_value_t* self, struct _cef_binary_value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBinaryValue*, CefBinaryValue*, int> _IsSame;

  /// <summary>
  /// Returns true (1) if this object and |that| object have an equivalent
  /// underlying value but are not necessarily the same object.
  /// <c>int(CEF_CALLBACK* is_equal)(struct _cef_binary_value_t* self, struct _cef_binary_value_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBinaryValue*, CefBinaryValue*, int> _IsEqual;

  /// <summary>
  /// Returns a copy of this object. The data in this object will also be
  /// copied.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* copy)(struct _cef_binary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBinaryValue*, CefBinaryValue*> _Copy;

  /// <summary>
  /// Returns the data size.
  /// <c>size_t(CEF_CALLBACK* get_size)(struct _cef_binary_value_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBinaryValue*, nuint> _GetSize;

  /// <summary>
  /// Read up to |buffer_size| number of bytes into |buffer|. Reading begins at
  /// the specified byte |data_offset|. Returns the number of bytes read.
  /// <c>size_t(CEF_CALLBACK* get_data)(struct _cef_binary_value_t* self,void* buffer, size_t buffer_size, size_t data_offset);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefBinaryValue*, void*, nuint, nuint, nuint> _GetData;

}
