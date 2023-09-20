using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;

namespace Cefium.Shared;

public class ReadOnlyFileMemoryMapping : IReadOnlyList<byte>, IDisposable {

  public readonly FileInfo FileInfo;

  public readonly MemoryMappedFile MappedFile;

  public readonly MemoryMappedViewAccessor View;

  private readonly unsafe byte* _pointer;

  public unsafe byte* Pointer => _pointer;

  public readonly ulong Length;

  public unsafe ReadOnlyFileMemoryMapping(string path) {
    FileInfo = new(path);
    if (!FileInfo.Exists)
      throw FileNotFound(path);

    Length = (ulong) FileInfo.Length;
    MappedFile = MemoryMappedFile.CreateFromFile(path, FileMode.Open, null, 0, MemoryMappedFileAccess.Read);
    View = MappedFile.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read);
    View.SafeMemoryMappedViewHandle.AcquirePointer(ref _pointer);
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  private static FileNotFoundException FileNotFound(string path)
    => new("File must exist and must be file-like (e.g.can't be a directory)", path);

  public void Dispose() {
    View.SafeMemoryMappedViewHandle.ReleasePointer();
    View.Dispose();
    MappedFile.Dispose();
    GC.SuppressFinalize(this);
  }

  ~ReadOnlyFileMemoryMapping()
    => Dispose();

  public unsafe ref readonly byte this[ulong address] {
    get {
      RangeCheck(address);
      return ref _pointer[address];
    }
  }

  public unsafe ref readonly byte this[long address] {
    get {
      RangeCheck(address);
      return ref _pointer[address];
    }
  }

  public unsafe ref readonly byte this[uint address] {
    get {
      RangeCheck(address);
      return ref _pointer[address];
    }
  }

  public unsafe ref readonly byte this[int address] {
    get {
      RangeCheck(address);
      return ref _pointer[address];
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal void RangeCheck(ulong address) {
    if (address >= Length)
      ThrowArgumentOutOfRangeException(nameof(address));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal void RangeCheck(long address)
    => RangeCheck((ulong) address);

  [MethodImpl(MethodImplOptions.NoInlining), DoesNotReturn]
  private static void ThrowArgumentOutOfRangeException(string paramName)
    => throw new ArgumentOutOfRangeException(paramName);

  public unsafe void Read<T>(ulong address, Span<T> buffer) {
    var count = (ulong) buffer.Length;
    var size = count * (ulong) Unsafe.SizeOf<T>();
    RangeCheck(address + size);
    var srcSpan = new Span<T>(_pointer + address, checked((int) count));
    srcSpan.CopyTo(buffer);
  }

  public int Count
    => checked((int) Length);

  byte IReadOnlyList<byte>.this[int index]
    => this[index];

  public ref struct Enumerator {

    private readonly ReadOnlyFileMemoryMapping _mapping;

    private readonly ulong _end;

    private ulong _current;

    public Enumerator(ReadOnlyFileMemoryMapping mapping) {
      _mapping = mapping;
      _end = mapping.Length;
      _current = 0;
    }

    public ref readonly byte Current {
      get {
        if (_current >= _end)
          ThrowInvalidOperationException();
        return ref _mapping[_current];
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining), DoesNotReturn]
    private static void ThrowInvalidOperationException()
      => throw new InvalidOperationException();

    public bool MoveNext() {
      if (_current >= _end)
        return false;

      _current++;
      return true;
    }

  }

  public Enumerator GetEnumerator()
    => new(this);

  IEnumerator<byte> IEnumerable<byte>.GetEnumerator() {
    for (ulong i = 0; i < Length; i++)
      yield return this[i];
  }

  IEnumerator IEnumerable.GetEnumerator()
    => ((IEnumerable<byte>) this).GetEnumerator();

  public unsafe ReadOnlySpan<byte> AsSpan()
    => new(_pointer, checked((int) Length));

  public unsafe ReadOnlySpan<byte> AsSpan(uint address) {
    RangeCheck(address);
    return new(_pointer + address, checked((int) (Length - address)));
  }

  public unsafe ReadOnlySpan<byte> AsSpan(ulong address) {
    RangeCheck(address);
    return new(_pointer + address, checked((int) (Length - address)));
  }

  public unsafe ReadOnlySpan<byte> AsSpan(uint address, uint length) {
    RangeCheck(address + length);
    return new(_pointer + address, checked((int) length));
  }

  public unsafe ReadOnlySpan<byte> AsSpan(ulong address, ulong length) {
    RangeCheck(address + length);
    return new(_pointer + address, checked((int) length));
  }

}
