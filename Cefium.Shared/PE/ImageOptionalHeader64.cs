using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cefium.Shared;

[StructLayout(LayoutKind.Sequential)]
public struct ImageOptionalHeader64 {

  public ushort Magic;

  public byte MajorLinkerVersion;

  public byte MinorLinkerVersion;

  public uint SizeOfCode;

  public uint SizeOfInitializedData;

  public uint SizeOfUninitializedData;

  public uint AddressOfEntryPoint;

  public uint BaseOfCode;

  public ulong ImageBase;

  public uint SectionAlignment;

  public uint FileAlignment;

  public ushort MajorOperatingSystemVersion;

  public ushort MinorOperatingSystemVersion;

  public ushort MajorImageVersion;

  public ushort MinorImageVersion;

  public ushort MajorSubsystemVersion;

  public ushort MinorSubsystemVersion;

  public uint Win32VersionValue;

  public uint SizeOfImage;

  public uint SizeOfHeaders;

  public uint CheckSum;

  public ushort Subsystem;

  public ushort DllCharacteristics;

  public ulong SizeOfStackReserve;

  public ulong SizeOfStackCommit;

  public ulong SizeOfHeapReserve;

  public ulong SizeOfHeapCommit;

  public uint LoaderFlags;

  public uint NumberOfRvaAndSizes;

  public ImageDataDirectory ExportTableDirectory;

  public ImageDataDirectory ImportTableDirectory;

  public ImageDataDirectory ResourceTableDirectory;

  public ImageDataDirectory ExceptionTableDirectory;

  public ImageDataDirectory CertificateTableDirectory;

  public ImageDataDirectory BaseRelocationTableDirectory;

  public ImageDataDirectory DebugDirectoryDirectory;

  public ImageDataDirectory ArchitectureDirectory;

  public ImageDataDirectory GlobalPtrDirectory;

  public ImageDataDirectory TLSTableDirectory;

  public ImageDataDirectory LoadConfigTableDirectory;

  public ImageDataDirectory BoundImportDirectory;

  public ImageDataDirectory ImportAddressTableDirectory;

  public ImageDataDirectory DelayImportDescriptorDirectory;

  public ImageDataDirectory CLRRuntimeHeaderDirectory;

  public ImageDataDirectory ReservedDirectoryDirectory;

  public Span<ImageDataDirectory> DataDirectories
    => MemoryMarshal.CreateSpan(ref ExportTableDirectory, 16);

  public readonly ref ImageExportDirectory GetExportTable(in ImageDosHeader header)
    => ref ExportTableDirectory.Resolve<ImageExportDirectory>(header);

}
