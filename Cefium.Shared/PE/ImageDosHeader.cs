using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cefium.Shared;

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "IdentifierTypo")]
public struct ImageDosHeader {

  public ushort Magic;

  public ushort LastPageByteCount;

  public ushort PageCount;

  public ushort RelocationCount;

  public ushort HeaderParagraphCount;

  public ushort MinAllocParagraphs;

  public ushort MaxAllocParagraphs;

  public ushort InitialStackSegment;

  public ushort InitialStackPointer;

  public ushort Checksum;

  public ushort InitialInstructionPointer;

  public ushort InitialCodeSegment;

  public ushort LinearFileAddressOfRelocationTable;

  public ushort OverlayNumber;

  public ushort Reserved1_0;
  public ushort Reserved1_1;
  public ushort Reserved1_2;
  public ushort Reserved1_3;

  public ushort OemId;

  public ushort OemInfo;

  public ushort Reserved2_0;
  public ushort Reserved2_1;
  public ushort Reserved2_2;
  public ushort Reserved2_3;
  public ushort Reserved2_4;
  public ushort Reserved2_5;
  public ushort Reserved2_6;
  public ushort Reserved2_7;
  public ushort Reserved2_8;
  public ushort Reserved2_9;

  public uint LinearFileAddressOfNewHeaders;

  public readonly unsafe ref ImageNtHeaders64 GetImageNtHeaders64() {
    var p = (byte*) Unsafe.AsPointer(ref Unsafe.AsRef(this));
    p += LinearFileAddressOfNewHeaders;
    return ref Unsafe.AsRef<ImageNtHeaders64>(p);
  }

}
