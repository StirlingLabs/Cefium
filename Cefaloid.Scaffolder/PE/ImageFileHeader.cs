using System.Reflection;
using System.Runtime.InteropServices;

namespace Cefaloid.Scaffolder;

[StructLayout(LayoutKind.Sequential)]
public struct ImageFileHeader {

  public ImageFileMachine Machine;

  public ushort NumberOfSections;

  public uint TimeDateStamp;

  public uint PointerToSymbolTable;

  public uint NumberOfSymbols;

  public ushort SizeOfOptionalHeader;

  public ImageFileCharacteristics Characteristics;

}
