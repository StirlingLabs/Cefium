using System.IO.MemoryMappedFiles;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using static System.Environment;

namespace Cefaloid;

[PublicAPI]
[SuppressMessage("Usage", "CA2255",
  Justification = "ModuleInitializer is required to preemptively load the native library.")]
public static class Cefaloid {

  [SuppressMessage("ReSharper", "StringLiteralTypo")]
  private static readonly string LibraryOsId = OperatingSystem.IsWindows()
    ? RuntimeInformation.ProcessArchitecture == Architecture.Arm64
      ? "windowsarm64"
      : "windows64"
    : OperatingSystem.IsMacOS()
      ? RuntimeInformation.ProcessArchitecture == Architecture.Arm64
        ? "macosarm64"
        : "macosx64"
      : RuntimeInformation.ProcessArchitecture == Architecture.Arm64
        ? "linuxarm64"
        : "linux64";

  internal static readonly string MinimalCefCdnUrl = $"https://cef-builds.spotifycdn.com/cef_binary_110.0.28%2Bg16a2153%2Bchromium-110.0.5481.104_{LibraryOsId}_minimal.tar.bz2";

  internal static readonly string ArchiveSubdirectory1 = $@"cef_binary_110.0.28+g16a2153+chromium-110.0.5481.104_{LibraryOsId}_minimal/Release/";

  internal static readonly string ArchiveSubdirectory2 = $@"cef_binary_110.0.28+g16a2153+chromium-110.0.5481.104_{LibraryOsId}_minimal/Resources/";

  private const string CefVersion = "110.0.28";

  private const long WindowsX64ExpectedContentLength = 169_269_806;

  private static readonly byte[] WindowsX64ExpectedSha256 = {
    0x1F, 0x46, 0x4E, 0x81, 0x24, 0xFD, 0x70, 0x03, 0xB4, 0x9C, 0xDD, 0x12, 0x11, 0x2C, 0x2E, 0x75,
    0xB5, 0x57, 0xAD, 0xAA, 0x3D, 0x89, 0x8B, 0x8C, 0xA9, 0xC6, 0x25, 0x5A, 0xA6, 0xA9, 0x5B, 0x8C
  };

  private const long MacOsX64ExpectedContentLength = 96_933_885;

  private static readonly byte[] MacOsX64ExpectedSha256 = {
    0x4B, 0x24, 0x11, 0x3B, 0xA1, 0x74, 0x9C, 0x02, 0x64, 0x04, 0x72, 0xB2, 0xB2, 0x5E, 0x7E, 0xC0,
    0xBD, 0xE6, 0x07, 0x11, 0x7C, 0xB3, 0x1A, 0xD7, 0xFB, 0x82, 0x32, 0xAB, 0x85, 0x0C, 0xE3, 0x04
  };

  private const long LinuxX64ExpectedContentLength = 303_511_761;

  private static readonly byte[] LinuxX64ExpectedSha256 = {
    0x87, 0xF2, 0xBE, 0xD7, 0x2B, 0xE1, 0x4C, 0x5C, 0x15, 0x37, 0xE7, 0xA6, 0x09, 0x4E, 0xA0, 0xDA,
    0xC6, 0x63, 0x53, 0x2A, 0xC9, 0xD3, 0xF8, 0xDF, 0x28, 0x26, 0xE6, 0xEA, 0xBD, 0x95, 0xC2, 0x4D
  };

  private const long WindowsArm64ContentLength = 154_200_655;

  private static readonly byte[] WindowsArm64ExpectedSha256 = {
    0x56, 0x15, 0xCE, 0x86, 0xEA, 0x3D, 0xF9, 0x03, 0x5F, 0x98, 0x7B, 0xE4, 0x2C, 0xF7, 0x8B, 0x0F,
    0x9E, 0x21, 0xEE, 0xE8, 0x7D, 0x37, 0x73, 0xA1, 0xFF, 0xE8, 0xE4, 0xCC, 0x2E, 0x36, 0x95, 0xCA
  };

  private const long MacOsArm64ContentLength = 92_731_070;

  private static readonly byte[] MacOsArm64ExpectedSha256 = {
    0x2D, 0xA4, 0x53, 0xC1, 0x88, 0xB5, 0xF8, 0x91, 0x17, 0x74, 0x52, 0x08, 0x26, 0xAD, 0xE7, 0x60,
    0x79, 0x9C, 0x9B, 0x9A, 0xE0, 0xD5, 0x87, 0x88, 0x7D, 0xB1, 0x94, 0x12, 0xC5, 0x63, 0x99, 0x49
  };

  private const long LinuxArm64ContentLength = 391_328_068;

  private static readonly byte[] LinuxArm64ExpectedSha256 = {
    0xC1, 0x16, 0xA0, 0x3E, 0x3C, 0xEF, 0xC3, 0x4D, 0xF7, 0x10, 0x31, 0xD7, 0xDE, 0xD5, 0x68, 0x08,
    0x00, 0xB3, 0x89, 0xE6, 0xD5, 0x91, 0x32, 0xE0, 0x70, 0x1D, 0x02, 0xAE, 0x56, 0xC2, 0x4C, 0xA9
  };

  private const int MaxDownloadAttempts = 3;

  private static int _initialized;

  public static bool IsInitialized => _initialized == 1;

  private static int _downloading;

  public static bool IsDownloading => _downloading == 1 && _ready == 0;

  private static int _ready;

  public static bool IsReady => _ready == 1;

  public static readonly string LocalAppDataPathBase = GetEnvironmentVariable("CEFALOID_LOCALAPPDATA")
    ?? Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData, SpecialFolderOption.Create), "Cefaloid");

  public static readonly string LocalAppDataPath = Path.Combine(LocalAppDataPathBase, CefVersion);

  [SuppressMessage("ReSharper", "StringLiteralTypo")]
  private static readonly string LibraryFileName = OperatingSystem.IsWindows()
    ? "libcef.dll"
    : OperatingSystem.IsMacOS()
      ? "Chromium Embedded Framework.framework/Chromium Embedded Framework"
      : "libcef.so";

  [SupportedOSPlatform("macos")]
  public static readonly string FrameworkPath = Path.Combine(LocalAppDataPath, "Chromium Embedded Framework.framework");

  private static readonly string LibraryFilePath = Path.Combine(LocalAppDataPath, LibraryFileName);

  private static WeakReference<Stream>? _tarOnDiskStreamWeakRef;

  private static WeakReference<Stream>? _tarBeingReadStreamWeakRef;

  private static long _tarSize;

  private static readonly Encoding Utf8NoBom = new UTF8Encoding(false, false);

  [ModuleInitializer]
  public static void Initialize() {
    if (Interlocked.CompareExchange(ref _initialized, 1, 0) != 0)
      return;

    if (!File.Exists(LibraryFilePath))
      DownloadAndInstall();
    else
      Interlocked.Exchange(ref _ready, 1);
    NativeLibrary.SetDllImportResolver(typeof(Cefaloid).Assembly,
      (name, assembly, _)
        => {
        if (name != "cef" || assembly != typeof(Cefaloid).Assembly)
          return default;

        if (!IsReady)
          while (IsDownloading)
            Thread.Sleep(1);

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (File.Exists(LibraryFilePath))
          return NativeLibrary.Load(LibraryFilePath);

        return default;
      });
  }

  private static async void DownloadAndInstall(int attempt = 0) {
    if (IsReady) return;

    if (Interlocked.CompareExchange(ref _downloading, 1, 0) != 0)
      return;

    if (attempt > MaxDownloadAttempts)
      throw new InvalidOperationException("Failed to acquire CEF library.");

    var url = MinimalCefCdnUrl;
    try {
      // create a temp file to download the archive to
      var fileName = Path.GetFileName(new Uri(url).PathAndQuery);
      var tempFile = Path.Combine(Path.GetTempPath(), fileName);
      var fileInfo = new FileInfo(tempFile);
      if (fileInfo.Exists)
        await ResumeDownload(attempt, url, fileInfo);
      else
        await Download(attempt, url, tempFile);

      fileInfo.Refresh();
      using var tempFileMap = MemoryMappedFile.CreateFromFile(fileInfo.FullName, FileMode.Open);

      if (!VerifyCefPackage(tempFileMap, fileInfo.Length))
        throw new InvalidOperationException("Verification of CEF package failed.");

      await using var readStream = tempFileMap.CreateViewStream(0, fileInfo.Length, MemoryMappedFileAccess.Read);

      readStream.Position = 0;

      _tarSize = readStream.Length;

      _tarBeingReadStreamWeakRef = new(readStream);

      await ExtractCefTarBz2(readStream);

      Interlocked.Exchange(ref _ready, 1);
    }
    catch {
      DownloadAndInstall(attempt + 1);
    }
  }

  private static unsafe bool VerifyCefPackage(MemoryMappedFile file, long length) {
    using var view = file.CreateViewAccessor(0, length, MemoryMappedFileAccess.Read);

    byte* ptr = null;
    view.SafeMemoryMappedViewHandle.AcquirePointer(ref ptr);

    var viewSpan = new ReadOnlySpan<byte>(ptr, (int) length);
    Span<byte> hashSpan = stackalloc byte[32];

    SHA256.TryHashData(viewSpan, hashSpan, out _);

    view.SafeMemoryMappedViewHandle.ReleasePointer();

    return hashSpan.SequenceEqual(
      OperatingSystem.IsWindows()
        ? RuntimeInformation.ProcessArchitecture == Architecture.Arm64
          ? WindowsArm64ExpectedSha256
          : WindowsX64ExpectedSha256
        : OperatingSystem.IsMacOS()
          ? RuntimeInformation.ProcessArchitecture == Architecture.Arm64
            ? MacOsArm64ExpectedSha256
            : MacOsX64ExpectedSha256
          : OperatingSystem.IsLinux()
            ? RuntimeInformation.ProcessArchitecture == Architecture.Arm64
              ? LinuxArm64ExpectedSha256
              : LinuxX64ExpectedSha256
            : throw new PlatformNotSupportedException("Unsupported platform."));
  }

  private static async Task ExtractCefTarBz2(Stream readStream) {
    // prepare the decompression stream
    await using var decompressionStream = new BZip2InputStream(readStream);
    // extract tar archive

    await using var archive = new TarInputStream(decompressionStream, Utf8NoBom);
    // extract the files
    while (await archive.GetNextEntryAsync(default) is { } item) {
      if (item.IsDirectory)
        continue;

      var itemName = item.Name;

      var startsWithSubdir1 = StringStartsWithIgnoreCaseAndSlashDirection(itemName, ArchiveSubdirectory1);
      var startsWithSubdir2 = !startsWithSubdir1 && StringStartsWithIgnoreCaseAndSlashDirection(itemName, ArchiveSubdirectory2);
      if (!startsWithSubdir1 && !startsWithSubdir2)
        continue;

      var ext = Path.GetExtension(itemName);
      if (ext is ".lib" or ".a") continue;

      var subdirLen = startsWithSubdir1
        ? ArchiveSubdirectory1.Length
        : ArchiveSubdirectory2.Length;
      var targetPath = Path.Combine(LocalAppDataPath, itemName[subdirLen..]);
      var targetDir = Path.GetDirectoryName(targetPath);
      if (targetDir is not null && !Directory.Exists(targetDir))
        Directory.CreateDirectory(targetDir);

      // extract to LocalAppDataPath
      var fso = new FileStreamOptions {
        Access = FileAccess.Write,
        Mode = FileMode.Create,
        Share = FileShare.Read | FileShare.Delete,
        BufferSize = 4096,
        Options = FileOptions.SequentialScan,
        PreallocationSize = item.Size
      };

      if (!OperatingSystem.IsWindows())
        fso.UnixCreateMode = (UnixFileMode) item.TarHeader.Mode;

      await using var targetStream = new FileStream(targetPath, fso);
      await archive.CopyEntryContentsAsync(targetStream, default);
    }
  }

  private static async Task Download(int attempt, string url, string tempFile) {
    using var http = new HttpClient {
      DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower,
      DefaultRequestVersion = new(3, 0)
    };
    var response = await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

    if (!response.IsSuccessStatusCode)
      DownloadAndInstall(attempt + 1);

    SetExpectedDownloadLength(response);

    await using var writeStream = new FileStream(tempFile, new FileStreamOptions {
      Access = FileAccess.Write,
      Mode = FileMode.Create,
      Share = FileShare.Read | FileShare.Delete,
      BufferSize = 4096,
      Options = FileOptions.SequentialScan,
      PreallocationSize = _tarSize
    });

    var downloadStream = await response.Content.ReadAsStreamAsync();
    _tarOnDiskStreamWeakRef = new(writeStream);
    await downloadStream.CopyToAsync(writeStream);
    writeStream.Flush();
  }

  private static void SetExpectedDownloadLength(HttpResponseMessage response) {
    var length = response.Content.Headers.ContentLength ?? 0;
    if (length > 0)
      _tarSize = length;
    else
      _tarSize = OperatingSystem.IsWindows()
        ? RuntimeInformation.ProcessArchitecture == Architecture.Arm64
          ? WindowsArm64ContentLength
          : WindowsX64ExpectedContentLength
        : OperatingSystem.IsMacOS()
          ? RuntimeInformation.ProcessArchitecture == Architecture.Arm64
            ? MacOsArm64ContentLength
            : MacOsX64ExpectedContentLength
          : RuntimeInformation.ProcessArchitecture == Architecture.Arm64
            ? LinuxArm64ContentLength
            : LinuxX64ExpectedContentLength;
  }

  private static async Task ResumeDownload(int attempt, string url, FileInfo fileInfo) {
    using var http = new HttpClient {
      DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower,
      DefaultRequestVersion = new(3, 0)
    };
    // resume download after trimming off 256kB
    var resumeOffset = Math.Max(0, fileInfo.Length - 256 * 1024);
    http.DefaultRequestHeaders.Range = new(resumeOffset, null);
    var response = await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

    if (!response.IsSuccessStatusCode)
      DownloadAndInstall(attempt + 1);

    SetExpectedDownloadLength(response);

    await using var writeStream = fileInfo.Open(FileMode.Open, FileAccess.Write, FileShare.Read);
    writeStream.Seek(resumeOffset, SeekOrigin.Begin);
    // trim off the last 256kB
    writeStream.SetLength(resumeOffset);
    var downloadStream = await response.Content.ReadAsStreamAsync();
    _tarOnDiskStreamWeakRef = new(writeStream);
    await downloadStream.CopyToAsync(writeStream);
    writeStream.Flush();
  }

  public static float DownloadProgress {
    get {
      if (_tarOnDiskStreamWeakRef is null)
        return 0f;

      if (!_tarOnDiskStreamWeakRef.TryGetTarget(out var stream))
        return 1f;

      if (_tarSize <= 0)
        return 0f;

      try { return (float) stream.Position / _tarSize; }
      catch (ObjectDisposedException) {
        _tarOnDiskStreamWeakRef.SetTarget(null!);
        return 1f;
      }
      catch {
        return 0f;
      }
    }
  }

  public static float ExtractProgress {
    get {
      if (_tarBeingReadStreamWeakRef is null)
        return 0f;

      if (!_tarBeingReadStreamWeakRef.TryGetTarget(out var stream))
        return 1f;

      try { return (float) stream.Position / _tarSize; }
      catch (ObjectDisposedException) {
        _tarBeingReadStreamWeakRef.SetTarget(null!);
        return 1f;
      }
      catch {
        return 0f;
      }
    }
  }

  public static float InstallProgress
    => !IsReady
      ? MathF.Min(99.99f, (DownloadProgress + ExtractProgress) / 2)
      : 1f; // don't return 100% unless IsReady

  private static bool StringStartsWithIgnoreCaseAndSlashDirection(string? a, string? b) {
    if (a is null || b is null)
      return false;

    if (a.Length < b.Length)
      return false;

    var aSpan = a.AsSpan();
    var bSpan = b.AsSpan();

    for (var i = 0; i < bSpan.Length; i++) {
      var aChar = char.ToUpper(aSpan[i]);
      var bChar = char.ToUpper(bSpan[i]);
      if (aChar == '\\') aChar = '/';
      if (bChar == '\\') bChar = '/';
      if (aChar == bChar) continue;

      return false;
    }

    return true;
  }

}
