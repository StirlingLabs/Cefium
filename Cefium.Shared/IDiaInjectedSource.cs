using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace Cefium.Shared.Dia2;

[SuppressUnmanagedCodeSecurity]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("AE605CDC-8105-4A23-B710-3259F1E26112")]
[ComImport]
public interface IDiaInjectedSource {

  [DispId(1)]
  uint crc { get; }

  [DispId(2)]
  ulong length { get; }

  [DispId(3)]
  string fileName { get; }

  [DispId(4)]
  string objectFileName { get; }

  [DispId(5)]
  string virtualFilename { get; }

  [DispId(6)]
  uint sourceCompression { get; }

  void get_source([In] uint cbData, out uint pcbData, ref byte pbData);

}
