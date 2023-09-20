using System.Buffers;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Cefium;

/// <summary>
/// This is a semi-opaque structure that represents a string in CEF.
/// Allocate and manipulate them using CEF exported functions.
///
/// CEF string type definitions. Whomever allocates |str| is responsible for
/// providing an appropriate |dtor| implementation that will free the string in
/// the same memory space. When reusing an existing string structure make sure
/// to call |dtor| for the old value before assigning new |str| and |dtor|
/// values. Static strings will have a NULL |dtor| value. Using the below
/// functions if you want this managed for you.
/// <c>cef_string_t</c>
/// </summary>
/// <seealso cref="CefStringExtensions"/>
#if DEBUG
#pragma warning disable CS0618 // Type or member is obsolete
[DebuggerDisplay("{DebugString}")]
#pragma warning restore CS0618
#endif
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public unsafe struct CefString {

  public void* Str;

  public nuint Length;

  private delegate * unmanaged[Cdecl, SuppressGCTransition]<void*, void> _Dtor;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal CefString(void* str, nuint length, delegate * unmanaged[Cdecl, SuppressGCTransition]<void*, void> dtor) {
    Str = str;
    Length = length;
    _Dtor = dtor;
  }

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)})]
  private static void CallNativeMemoryFree(void* p)
    => NativeMemory.Free(p);

  public static CefString CreateViaCopy(string str) {
    var strLength = str.Length;
    var mem = NativeMemory.Alloc((nuint) ((strLength + 1) * 2));
    var memSpan = new Span<char>(mem, strLength);
    var charSpan = (ReadOnlySpan<char>) str;
    charSpan.CopyTo(memSpan);
    var cefStr = new CefString(mem, (nuint) strLength, &CallNativeMemoryFree);

    // does the CefString structure itself get copied or do we need to have it pinned somewhere as well?
    return cefStr;
  }

  private static readonly ConcurrentDictionary<nint, MemoryHandle> PointersToPinnedHandles = new();

  [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)})]
  private static void CallPinnedRelease(void* p) {
    var ptr = (nint) p;
    if (PointersToPinnedHandles.TryRemove(ptr, out var handle))
      handle.Dispose();
  }

  public static CefString CreateViaPin(MemoryHandle pinnedHandle, nuint length) {
    var p = pinnedHandle.Pointer;
    if (!PointersToPinnedHandles.TryAdd((nint) p, pinnedHandle))
      throw new InvalidOperationException("This was already pinned; using it again could result in an unpin-before-use.");

    var cefStr = new CefString(p, length, &CallPinnedRelease);

    // does the CefString structure itself get copied or do we need to have it pinned somewhere as well?
    return cefStr;
  }

  public static CefString CreateViaPin(ReadOnlyMemory<char> str)
    => CreateViaPin(str.Pin(), (nuint) str.Length);

  public static CefString CreateViaPin(string str)
    => CreateViaPin(str.AsMemory());

  public static CefString CreateFromConst(char* str, nuint length)
    => new(str, length, null);

  public bool HasDestructor {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _Dtor is not null;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Destroy() {
    if (HasDestructor) _Dtor(Str);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySpan<byte> AsByteSpan() => new(Str, checked((int) Length));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySpan<char> AsCharSpan() => new(Str, checked((int) Length));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySpan<int> AsIntSpan() => new(Str, checked((int) Length));

#if DEBUG

  [Obsolete("This is only for the debugger.")]
  public string DebugString {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => AsCharSpan().ToString();
  }
#endif

}
