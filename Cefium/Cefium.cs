using System.IO.MemoryMappedFiles;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using static System.Environment;

namespace Cefium;

/// <summary>
/// The main entry point for Cefium.
/// Handles downloading, installing and loading the CEF library.
/// </summary>
[PublicAPI]
[SuppressMessage("Usage", "CA2255",
  Justification = "ModuleInitializer is required to preemptively load the native library.")]
public static class Cefium {

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

  /// <summary>
  /// The version of CEF (Chromium Embedded Framework) used by this version of Cefium.
  /// Coincidentally, this will always match the version of Cefium.
  /// </summary>
  public const string CefVersion = "116.0.21";

  /// <summary>
  /// The metadata of the CEF version used by this version of Cefium.
  /// </summary>
  public const string CefVersionMetadata = "g9c7dc32";

  /// <summary>
  /// The version of Chromium this version of CEF is based on.
  /// </summary>
  public const string ChromiumVersion = "116.0.5845.181";

  internal static readonly string MinimalCefCdnUrl
    = $"https://cef-builds.spotifycdn.com/cef_binary_{CefVersion}%2B{CefVersionMetadata}%2Bchromium-{ChromiumVersion}_{LibraryOsId}_minimal.tar.bz2";

  internal static readonly string ArchiveSubdirectory1
    = $@"cef_binary_{CefVersion}+{CefVersionMetadata}+chromium-{ChromiumVersion}_{LibraryOsId}_minimal/Release/";

  internal static readonly string ArchiveSubdirectory2
    = $@"cef_binary_{CefVersion}+{CefVersionMetadata}+chromium-{ChromiumVersion}_{LibraryOsId}_minimal/Resources/";

  private const long WindowsX64ExpectedContentLength = 172_199_405;

  private static readonly byte[] WindowsX64ExpectedSha256 = {
    0xFF, 0x91, 0xDB, 0x57, 0x20, 0xA4, 0xDD, 0x26, 0xD5, 0x65, 0x8D, 0x25, 0xAF, 0x95, 0x46, 0xF5,
    0x88, 0x90, 0xA7, 0x3A, 0x47, 0xC6, 0x55, 0xBE, 0x91, 0xE8, 0xDB, 0x34, 0xFC, 0x43, 0x22, 0x85
  };

  private const long WindowsArm64ContentLength = 161_059_867;

  private static readonly byte[] WindowsArm64ExpectedSha256 = {
    0x1A, 0xAF, 0xD9, 0x55, 0xFD, 0x93, 0x44, 0x7F, 0x39, 0x3E, 0xE8, 0xBA, 0x43, 0x39, 0x80, 0xBE,
    0x2B, 0x91, 0xA8, 0xB2, 0x24, 0x01, 0xB1, 0xE0, 0x79, 0x3C, 0x7D, 0x8D, 0xBE, 0x1B, 0x90, 0x8E
  };

  private const long MacOsX64ExpectedContentLength = 99_469_511;

  private static readonly byte[] MacOsX64ExpectedSha256 = {
    0x55, 0x50, 0x8F, 0x90, 0x1C, 0xDC, 0x7D, 0x48, 0xB5, 0x90, 0x4F, 0xF7, 0xD2, 0xB2, 0x56, 0x99,
    0xCA, 0x0F, 0xB8, 0x4E, 0x93, 0x56, 0x9F, 0x00, 0x98, 0xFF, 0x58, 0xFE, 0x91, 0xAA, 0x65, 0xCF
  };

  private const long MacOsArm64ContentLength = 95_334_715;

  private static readonly byte[] MacOsArm64ExpectedSha256 = {
    0x45, 0x47, 0xFC, 0x0A, 0xE2, 0x7D, 0x55, 0x3D, 0xC8, 0x65, 0x0C, 0xD0, 0x9A, 0xFC, 0x9D, 0x26,
    0xC0, 0x30, 0x0A, 0x8C, 0x1B, 0xA3, 0x03, 0x49, 0x4C, 0xA9, 0x91, 0xB8, 0x91, 0x60, 0xAB, 0xBE
  };

  private const long LinuxX64ExpectedContentLength = 319_623_253;

  private static readonly byte[] LinuxX64ExpectedSha256 = {
    0x72, 0x3D, 0xD4, 0x20, 0xAF, 0xAC, 0x14, 0xCB, 0xDF, 0x85, 0x21, 0x37, 0x06, 0x10, 0x6B, 0xCE,
    0x69, 0x7D, 0xC8, 0xB1, 0x60, 0xE5, 0xE4, 0x87, 0x70, 0xC3, 0xA4, 0x10, 0xD6, 0x69, 0x10, 0xA1
  };

  private const long LinuxArm64ContentLength = 420_733_541;

  private static readonly byte[] LinuxArm64ExpectedSha256 = {
    0xCD, 0xD4, 0x34, 0x27, 0x13, 0x44, 0x71, 0xDD, 0x97, 0xED, 0x2F, 0xBF, 0x17, 0x51, 0x19, 0x9E,
    0x5F, 0x8A, 0xDF, 0x9F, 0xAA, 0x3E, 0x09, 0x66, 0x10, 0x28, 0x6C, 0xB8, 0x84, 0x7D, 0x71, 0xB4
  };

  private const int MaxDownloadAttempts = 3;

  private static int _initialized;

  /// <summary>
  /// Whether or not Cefium has been initialized.
  /// </summary>
  public static bool IsInitialized => _initialized == 1;

  private static int _downloading;

  /// <summary>
  /// Whether or not Cefium is currently downloading the CEF library.
  /// </summary>
  public static bool IsDownloading => _downloading == 1 && _ready == 0;

  private static int _ready;

  /// <summary>
  /// Whether or not Cefium is ready to be used.
  /// </summary>
  public static bool IsReady => _ready == 1;

  /// <summary>
  /// The path to Cefium's versioned CEF installations.
  /// </summary>
  public static readonly string LocalAppDataPathBase = GetEnvironmentVariable("CEFALOID_LOCALAPPDATA")
    ?? Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData, SpecialFolderOption.Create), "Cefium");

  /// <summary>
  /// The path containing the CEF library, a versioned CEF installation managed by Cefium.
  /// </summary>
  public static readonly string LocalAppDataPath = Path.Combine(LocalAppDataPathBase, CefVersion);

  [SuppressMessage("ReSharper", "StringLiteralTypo")]
  private static readonly string LibraryFileName = OperatingSystem.IsWindows()
    ? "libcef.dll"
    : OperatingSystem.IsMacOS()
      ? "Chromium Embedded Framework.framework/Chromium Embedded Framework"
      : "libcef.so";

  /// <summary>
  /// The path to the CEF Framework on Mac OS.
  /// </summary>
  [SupportedOSPlatform("macos")]
  public static readonly string MacFrameworkPath = Path.Combine(LocalAppDataPath, "Chromium Embedded Framework.framework");

  private static readonly string LibraryFilePath = Path.Combine(LocalAppDataPath, LibraryFileName);

  private static WeakReference<Stream>? _tarOnDiskStreamWeakRef;

  private static WeakReference<Stream>? _tarBeingReadStreamWeakRef;

  private static long _tarSize;

  private static readonly Encoding Utf8NoBom = new UTF8Encoding(false, false);

  /// <summary>
  /// Initializes Cefium.
  /// This is called as a module initializer on .NET 6 and up.
  /// </summary>
  [ModuleInitializer]
  public static void Initialize() {
    if (Interlocked.CompareExchange(ref _initialized, 1, 0) != 0)
      return;

    if (!File.Exists(LibraryFilePath))
      DownloadAndInstall();
    else
      Interlocked.Exchange(ref _ready, 1);
    NativeLibrary.SetDllImportResolver(typeof(Cefium).Assembly,
      (name, assembly, _)
        => {
        if (name != "cef" || assembly != typeof(Cefium).Assembly)
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

  /// <summary>
  /// The download progress of the CEF library.
  /// </summary>
  /// <remarks>
  /// Extraction begins after downloading completes.
  /// Represented by a fractional value between 0.0 (0%) and 1.0 (100%).
  /// </remarks>
  /// <seealso cref="ExtractProgress"/>
  /// <seealso cref="InstallProgress"/>
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

  /// <summary>
  /// The extraction progress of the CEF library.
  /// </summary>
  /// <remarks>
  /// Extraction begins after downloading completes.
  /// Represented by a fractional value between 0.0 (0%) and 1.0 (100%).
  /// </remarks>
  /// <seealso cref="DownloadProgress"/>
  /// <seealso cref="InstallProgress"/>
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

  /// <summary>
  /// The combined download and extraction progress of the CEF library.
  /// </summary>
  /// <remarks>
  /// Represented by a fractional value between 0.0 (0%) and 1.0 (100%).
  /// </remarks>
  /// <seealso cref="DownloadProgress"/>
  /// <seealso cref="ExtractProgress"/>
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
