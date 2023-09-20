using System.Runtime.Versioning;

namespace Cefium;

/// <inheritdoc cref="CefWindowInfo"/>
/// <seealso cref="CefWindowInfo"/>
[SupportedOSPlatform("macos")]
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefWindowInfoForMac {

  /// <summary>
  /// The window name.
  /// </summary>
  public CefString WindowName;

  /// <summary>
  /// Initial window bounds.
  /// </summary>
  public CefRect Bounds;

  /// <summary>
  /// Set to true (1) to create the view initially hidden.
  /// </summary>
  public int Hidden;

  /// <summary>
  /// NSView pointer for the parent view.
  /// </summary>
  public nint ParentView;

  /// <summary>
  /// Set to true (1) to create the browser using windowless (off-screen)
  /// rendering. No view will be created for the browser and all rendering will
  /// occur via the CefRenderHandler interface. The |parent_view| value will be
  /// used to identify monitor info and to act as the parent view for dialogs,
  /// context menus, etc. If |parent_view| is not provided then the main screen
  /// monitor will be used and some functionality that requires a parent view
  /// may not function correctly. In order to create windowless browsers the
  /// CefSettings.windowless_rendering_enabled value must be set to true.
  /// Transparent painting is enabled by default but can be disabled by setting
  /// CefBrowserSettings.background_color to an opaque value.
  /// </summary>
  public int WindowlessRenderingEnabled;

  /// <summary>
  /// Set to true (1) to enable shared textures for windowless rendering. Only
  /// valid if windowless_rendering_enabled above is also set to true. Currently
  /// only supported on Windows (D3D11).
  /// </summary>
  public int SharedTextureEnabled;

  /// <summary>
  /// Set to true (1) to enable the ability to issue BeginFrame from the client
  /// application.
  /// </summary>
  public int ExternalBeginFrameEnabled;

  /// <summary>
  /// NSView pointer for the new browser view. Only used with windowed
  /// rendering.
  /// </summary>
  public nint View;

}
