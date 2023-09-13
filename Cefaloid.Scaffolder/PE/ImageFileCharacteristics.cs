namespace Cefaloid.Scaffolder;

[Flags]
public enum ImageFileCharacteristics : ushort {

  // IMAGE_FILE_RELOCS_STRIPPED
  RelocsStripped = 0x0001,

  // IMAGE_FILE_EXECUTABLE_IMAGE
  ExecutableImage = 0x0002,

  // IMAGE_FILE_LINE_NUMS_STRIPPED
  LineNumsStripped = 0x0004,

  // IMAGE_FILE_LOCAL_SYMS_STRIPPED
  LocalSymsStripped = 0x0008,

  // IMAGE_FILE_AGGRESIVE_WS_TRIM
  AggressiveWsTrim = 0x0010,

  // IMAGE_FILE_LARGE_ADDRESS_AWARE
  LargeAddressAware = 0x0020,

  // IMAGE_FILE_BYTES_REVERSED_LO
  BytesReversedLo = 0x0080,

  // IMAGE_FILE_32BIT_MACHINE
  Bit32Machine = 0x0100,

  // IMAGE_FILE_DEBUG_STRIPPED
  DebugStripped = 0x0200,

  // IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP
  RemovableRunFromSwap = 0x0400,

  // IMAGE_FILE_NET_RUN_FROM_SWAP
  NetRunFromSwap = 0x0800,

  // IMAGE_FILE_SYSTEM
  System = 0x1000,

  // IMAGE_FILE_DLL
  Dll = 0x2000,

  // IMAGE_FILE_UP_SYSTEM_ONLY
  UpSystemOnly = 0x4000,

  // IMAGE_FILE_BYTES_REVERSED_HI
  BytesReversedHi = 0x8000,

}