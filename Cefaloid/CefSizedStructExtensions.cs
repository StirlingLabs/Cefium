namespace Cefaloid;

[PublicAPI]
public static class CefSizedStructExtensions {

  public static unsafe void InitializeBase<T>(ref this T self) where T : unmanaged, ICefSizedStruct<T>
    => *(nuint*) self.AsPointer() = (nuint) Unsafe.SizeOf<T>();

}