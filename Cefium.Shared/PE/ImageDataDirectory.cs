using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cefium.Shared;

[StructLayout(LayoutKind.Sequential)]
public struct ImageDataDirectory {

  public uint VirtualAddress;

  public uint Size;

  public readonly unsafe Span<byte> ToSpan(in ImageDosHeader header) {
    ref var ntHeaders = ref header.GetImageNtHeaders64();
    var address = ntHeaders.ResolveRva(VirtualAddress, header);
    return new(address, (int) Size);
  }

  public readonly ref T Resolve<T>(in ImageDosHeader header)
    where T : unmanaged {
    var span = ToSpan(header);
    var cast = MemoryMarshal.Cast<byte, T>(span);
    return ref cast[0];
  }

  public readonly ref T Resolve<T>(in ImageDosHeader header, int offset)
    where T : unmanaged {
    var span = ToSpan(header).Slice(offset);
    var cast = MemoryMarshal.Cast<byte, T>(span);
    return ref cast[0];
  }

}
