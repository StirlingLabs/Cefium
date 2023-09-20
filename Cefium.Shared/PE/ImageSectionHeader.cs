using System.Runtime.InteropServices;

namespace Cefium.Shared;

[StructLayout(LayoutKind.Sequential)]
public struct ImageSectionHeader {

  [StructLayout(LayoutKind.Sequential, Size = 8)]
  public struct NameBytes {

    private byte _0;

    public ReadOnlySpan<byte> Value => MemoryMarshal.CreateReadOnlySpan(ref _0, 8);

    public static implicit operator ReadOnlySpan<byte>(NameBytes value) => value.Value;

  }

  public NameBytes Name;

  public uint PhysicalAddressOrVirtualSize;

  public uint PhysicalAddress => PhysicalAddressOrVirtualSize;

  public uint VirtualSize => PhysicalAddressOrVirtualSize;

  public uint VirtualAddress;

  public uint SizeOfRawData;

  public uint PointerToRawData;

  public uint PointerToRelocations;

  public uint PointerToLineNumbers;

  public ushort NumberOfRelocations;

  public ushort NumberOfLineNumbers;

  public DataSectionFlags Characteristics;

}
