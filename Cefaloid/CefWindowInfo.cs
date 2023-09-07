using System.Runtime.Versioning;

#pragma warning disable CS9084

namespace Cefaloid;

/// <summary>
/// Structure representing window information.
/// <c>cef_window_info_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Explicit)]
public unsafe struct CefWindowInfo {

  public static readonly int Size
    = OperatingSystem.IsWindows() ? sizeof(CefWindowInfoForWindows)
    : OperatingSystem.IsLinux() ? sizeof(CefWindowInfoForLinux)
    : OperatingSystem.IsMacOS() ? sizeof(CefWindowInfoForMac)
    : throw new PlatformNotSupportedException();

  [FieldOffset(0), SupportedOSPlatform("windows")]
  public CefWindowInfoForWindows ForWindows;

  [FieldOffset(0), SupportedOSPlatform("linux")]
  public CefWindowInfoForLinux ForLinux;

  [FieldOffset(0), SupportedOSPlatform("macos")]
  public CefWindowInfoForMac ForMac;

  /// <summary>
  /// The initial title of the window, to be set when the window is created.
  /// Some layout managers (e.g., Compiz) can look at the window title
  /// in order to decide where to place the window when it is
  /// created. When this attribute is not empty, the window title will
  /// be set before the window is mapped to the display. Otherwise the
  /// title will be initially empty.
  /// </summary>
  /// <exception cref="PlatformNotSupportedException"></exception>
  public ref CefString WindowName {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get {
      if (OperatingSystem.IsWindows())
        return ref ForWindows.WindowName;

      if (OperatingSystem.IsLinux())
        return ref ForLinux.WindowName;

      if (OperatingSystem.IsMacOS())
        return ref ForMac.WindowName;

      throw new PlatformNotSupportedException();
    }
  }

  /// <summary>
  /// Initial window bounds.
  /// </summary>
  /// <exception cref="PlatformNotSupportedException"></exception>
  public ref CefRect Bounds {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get {
      if (OperatingSystem.IsWindows())
        return ref ForWindows.Bounds;

      if (OperatingSystem.IsLinux())
        return ref ForLinux.Bounds;

      if (OperatingSystem.IsMacOS())
        return ref ForMac.Bounds;

      throw new PlatformNotSupportedException();
    }
  }

  public nint ParentWindowOrView {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get {
      if (OperatingSystem.IsWindows())
        return ForWindows.ParentWindow;

      if (OperatingSystem.IsLinux())
        return ForLinux.ParentWindow;

      if (OperatingSystem.IsMacOS())
        return ForMac.ParentView;

      throw new PlatformNotSupportedException();
    }
  }

  /// <summary>
  /// Windows:
  /// Handle for the new browser window. Only used with windowed rendering.
  ///
  /// Linux:
  /// Pointer for the new browser window. Only used with windowed rendering.
  ///
  /// Mac:
  /// NSView pointer for the new browser view. Only used with windowed
  /// rendering.
  /// </summary>
  /// <exception cref="PlatformNotSupportedException"></exception>
  public nint WindowOrView {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get {
      if (OperatingSystem.IsWindows())
        return ForWindows.Window;

      if (OperatingSystem.IsLinux())
        return ForLinux.Window;

      if (OperatingSystem.IsMacOS())
        return ForMac.View;

      throw new PlatformNotSupportedException();
    }
  }

  [SuppressMessage("ReSharper", "InconsistentNaming")]
  internal ref int _WindowlessRenderingEnabled {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get {
      if (OperatingSystem.IsWindows())
        return ref ForWindows.WindowlessRenderingEnabled;

      if (OperatingSystem.IsLinux())
        return ref ForLinux.WindowlessRenderingEnabled;

      if (OperatingSystem.IsMacOS())
        return ref ForMac.WindowlessRenderingEnabled;

      throw new PlatformNotSupportedException();
    }
  }

  public bool WindowlessRenderingEnabled {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _WindowlessRenderingEnabled != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _WindowlessRenderingEnabled = value ? 1 : 0;
  }

  [SuppressMessage("ReSharper", "InconsistentNaming")]
  internal ref int _SharedTextureEnabled {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get {
      if (OperatingSystem.IsWindows())
        return ref ForWindows.SharedTextureEnabled;

      if (OperatingSystem.IsLinux())
        return ref ForLinux.SharedTextureEnabled;

      if (OperatingSystem.IsMacOS())
        return ref ForMac.SharedTextureEnabled;

      throw new PlatformNotSupportedException();
    }
  }

  public bool SharedTextureEnabled {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _SharedTextureEnabled != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _SharedTextureEnabled = value ? 1 : 0;
  }

  [SuppressMessage("ReSharper", "InconsistentNaming")]
  internal ref int _ExternalBeginFrameEnabled {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get {
      if (OperatingSystem.IsWindows())
        return ref ForWindows.ExternalBeginFrameEnabled;

      if (OperatingSystem.IsLinux())
        return ref ForLinux.ExternalBeginFrameEnabled;

      if (OperatingSystem.IsMacOS())
        return ref ForMac.ExternalBeginFrameEnabled;

      throw new PlatformNotSupportedException();
    }
  }

  public bool ExternalBeginFrameEnabled {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => _ExternalBeginFrameEnabled != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    set => _ExternalBeginFrameEnabled = value ? 1 : 0;
  }

}
