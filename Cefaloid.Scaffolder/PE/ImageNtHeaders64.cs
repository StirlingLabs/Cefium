using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cefaloid.Scaffolder;

[StructLayout(LayoutKind.Sequential)]
public struct ImageNtHeaders64 {

  public uint Signature;

  public ImageFileHeader FileHeader;

  public ImageOptionalHeader64 OptionalHeader;

  public unsafe Span<ImageSectionHeader> SectionHeaders
    => new((void*) (
        (ulong) Unsafe.AsPointer(ref Unsafe.AsRef(OptionalHeader))
        + (uint) Unsafe.SizeOf<ImageOptionalHeader64>()),
      FileHeader.NumberOfSections
    );

  public unsafe ref ImageSectionHeader GetSectionHeader(int index) {
    if ((uint) index > FileHeader.NumberOfSections)
      throw new ArgumentOutOfRangeException(nameof(index));

    var pFirstSectionHeader = (ImageSectionHeader*) (
      (ulong) Unsafe.AsPointer(ref Unsafe.AsRef(OptionalHeader))
      + (uint) Unsafe.SizeOf<ImageOptionalHeader64>());

    return ref Unsafe.AsRef<ImageSectionHeader>(&pFirstSectionHeader[index]);
  }

  public unsafe void* ResolveRva(uint rva, in ImageDosHeader header) {
    var baseAddr = (ulong)Unsafe.AsPointer(ref Unsafe.AsRef(header));
    foreach (ref var sectionHeader in SectionHeaders) {
      var sectionVa = sectionHeader.VirtualAddress;
      var sectionVs = sectionHeader.VirtualSize;
      var sectionVaEnd = sectionVa + sectionVs;
      if (sectionVa <= rva && rva < sectionVaEnd)
        return (void*) (baseAddr + (rva - sectionVa + sectionHeader.PointerToRawData));
    }

    return null;
  }

}
