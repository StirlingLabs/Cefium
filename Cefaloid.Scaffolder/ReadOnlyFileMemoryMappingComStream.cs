using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Dia2Lib;

namespace Cefaloid.Scaffolder;

public class ReadOnlyFileMemoryMappingComStream : Stream, IStream, IDisposable {

  private readonly ReadOnlyFileMemoryMapping _fileMapping;

  private long _index;

  private readonly bool _disposesFileMapping;

  public unsafe byte* BasePointer => _fileMapping.Pointer;

  public unsafe byte* CurrentPointer => _fileMapping.Pointer + _index;

  public ReadOnlyFileMemoryMappingComStream(string path)
    => _fileMapping = new(path);

  public ReadOnlyFileMemoryMappingComStream(ReadOnlyFileMemoryMapping fileMapping, bool disposesFileMapping = false) {
    _fileMapping = fileMapping;
    _disposesFileMapping = disposesFileMapping;
  }

  public unsafe void RemoteRead([UnscopedRef] out byte pv, uint cb, [UnscopedRef] out uint pcbRead) {
    var copySize = checked((int) cb);
    if (_index + copySize > (long) _fileMapping.Length)
      copySize = checked((int) (_fileMapping.Length - (ulong) _index));
    Unsafe.SkipInit(out pv);
    var pDest = (byte*) Unsafe.AsPointer(ref pv);
    var dest = new Span<byte>(pDest, copySize);
    _fileMapping.AsSpan((ulong) _index, (ulong) copySize)
      .CopyTo(dest);
    pcbRead = checked((uint) copySize);
  }

  public void RemoteWrite(ref byte pv, uint cb, [UnscopedRef] out uint pcbWritten)
    => throw new NotSupportedException();

  public void RemoteSeek(_LARGE_INTEGER dlibMove, uint dwOrigin, [UnscopedRef] out _ULARGE_INTEGER plibNewPosition) {
    var newPos = (StreamSeek) dwOrigin switch {
      StreamSeek.Set => dlibMove.QuadPart,
      StreamSeek.Current => _index + dlibMove.QuadPart,
      StreamSeek.End => (long) (_fileMapping.Length - (ulong) dlibMove.QuadPart),
      _ => throw new NotSupportedException()
    };

    _fileMapping.RangeCheck(newPos);
    plibNewPosition.QuadPart = (ulong) newPos;
    _index = newPos;
  }

  public void SetSize(_ULARGE_INTEGER libNewSize)
    => throw new NotSupportedException();

  public void RemoteCopyTo(IStream pstm, _ULARGE_INTEGER cb, [UnscopedRef] out _ULARGE_INTEGER pcbRead, [UnscopedRef] out _ULARGE_INTEGER pcbWritten) {
    var copySize = checked((int) cb.QuadPart);
    if (_index + copySize > (long) _fileMapping.Length)
      copySize = checked((int) (_fileMapping.Length - (ulong) _index));
    var src = _fileMapping.AsSpan((ulong) _index, (ulong) copySize);
    ref var pv = ref MemoryMarshal.GetReference(src);
    pcbRead.QuadPart = checked((ulong) copySize);
    pstm.RemoteWrite(ref pv, (uint) copySize, out var written);
    pcbWritten.QuadPart = written;
  }

  public void Commit(uint grfCommitFlags)
    => throw new NotSupportedException();

  public void Revert() {
    // do nothing
  }

  public void LockRegion(_ULARGE_INTEGER libOffset, _ULARGE_INTEGER cb, uint dwLockType)
    => _fileMapping.RangeCheck(_index + (long) libOffset.QuadPart);

  public void UnlockRegion(_ULARGE_INTEGER libOffset, _ULARGE_INTEGER cb, uint dwLockType)
    => _fileMapping.RangeCheck(_index + (long) libOffset.QuadPart);

  public void Stat([UnscopedRef] out tagSTATSTG pstatstg, uint grfStatFlag) {
    var fi = _fileMapping.FileInfo;
    var atime = fi.LastAccessTime.ToFileTime();
    var ctime = fi.CreationTime.ToFileTime();
    var mtime = fi.LastWriteTime.ToFileTime();
    pstatstg = new() {
      type = (uint) StorageType.Stream,
      atime = Unsafe.As<long, _FILETIME>(ref atime),
      ctime = Unsafe.As<long, _FILETIME>(ref ctime),
      mtime = Unsafe.As<long, _FILETIME>(ref mtime),
      pwcsName = fi.FullName,
      cbSize = {QuadPart = _fileMapping.Length}
    };
  }

  public void Clone([UnscopedRef] out IStream ppstm) {
    ppstm = new ReadOnlyFileMemoryMappingComStream(_fileMapping);
    ((ReadOnlyFileMemoryMappingComStream) ppstm)._index = _index;
  }

  public void Dispose() {
    _index = long.MinValue;
    if (_disposesFileMapping)
      _fileMapping.Dispose();
  }

  public override void Flush() {
  }

  public override int Read(byte[] buffer, int offset, int count) {
    var copySize = count;
    if (_index + copySize > (long) _fileMapping.Length)
      copySize = checked((int) (_fileMapping.Length - (ulong) _index));
    _fileMapping.AsSpan((ulong) _index, (ulong) copySize)
      .CopyTo(buffer.AsSpan(offset, copySize));
    _index += copySize;
    return copySize;
  }

  public override long Seek(long offset, SeekOrigin origin) {
    var newPos = origin switch {
      SeekOrigin.Begin => offset,
      SeekOrigin.Current => _index + offset,
      SeekOrigin.End => (long) (_fileMapping.Length - (ulong) offset),
      _ => throw new NotSupportedException()
    };

    _fileMapping.RangeCheck(newPos);
    _index = newPos;
    return newPos;
  }

  public override void SetLength(long value)
    => throw new NotSupportedException();

  public override void Write(byte[] buffer, int offset, int count)
    => throw new NotSupportedException();

  public override bool CanRead
    => true;

  public override bool CanSeek
    => true;

  public override bool CanWrite
    => false;

  public override long Length
    => (long) _fileMapping.Length;

  public override long Position {
    get => _index;
    set => Seek(value, SeekOrigin.Begin);
  }

}
