namespace Cefaloid;

/// <summary>
/// This provides a constraint for <see cref="CefRefCountedExtensions"/>.
/// </summary>
/// <seealso cref="CefRefCountedBase"/>
/// <seealso cref="CefRefCountedExtensions"/>
[PublicAPI]
public interface ICefRefCountedBase<T> where T : unmanaged, ICefRefCountedBase<T> {

  public virtual static unsafe T* Create() {
    var p = (T*) NativeMemory.AllocZeroed((nuint) Unsafe.SizeOf<T>());
    p->InitializeBase();
    return p;
  }

  public virtual static unsafe CefRef<T> New() => new(T.Create());

}
