namespace Cefaloid;

/// <summary>
/// This provides a constraint for <see cref="CefRefCountedExtensions"/>.
/// </summary>
/// <seealso cref="CefRefCountedBase"/>
/// <seealso cref="CefRefCountedExtensions"/>
[PublicAPI]
public interface ICefRefCountedBase<T> where T : unmanaged, ICefRefCountedBase<T> {

  public virtual static unsafe T* CreateUndefined() {
    var p = (T*) NativeMemory.AllocZeroed((nuint) Unsafe.SizeOf<T>());
    p->InitializeBase();
    T.Initialize(ref *p);
    return p;
  }

  public virtual static void Initialize(ref T item) {
    // default
  }

  public virtual static unsafe CefRef<T> New() => new(T.CreateUndefined());

}
