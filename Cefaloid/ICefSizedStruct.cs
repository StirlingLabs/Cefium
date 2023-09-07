namespace Cefaloid;

/// <summary>
/// This provides a constraint for <see cref="CefSizedStructExtensions"/>.
/// </summary>
/// <seealso cref="CefSizedStructExtensions"/>
[PublicAPI]
public interface ICefSizedStruct<T> where T : unmanaged, ICefSizedStruct<T> {
  public static unsafe T* Create() {
    var size = (nuint) Unsafe.SizeOf<T>();
    var p = (nuint*) NativeMemory.AllocZeroed(size);
    *p = size;
    return (T*) p;
  }

}
