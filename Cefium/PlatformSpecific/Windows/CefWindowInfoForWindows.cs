using System.Runtime.Versioning;

namespace Cefium;

/// <inheritdoc cref="CefWindowInfo"/>
/// <seealso cref="CefWindowInfo"/>
[SupportedOSPlatform("windows")]
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefWindowInfoForWindows {

  /// <remarks>
  /// Standard parameters required by CreateWindowEx()
  /// </remarks>
  public WindowStyleEx ExStyle;

  /// <remarks>
  /// Standard parameters required by CreateWindowEx()
  /// </remarks>
  public CefString WindowName;

  /// <remarks>
  /// Standard parameters required by CreateWindowEx()
  /// </remarks>
  public WindowStyle Style;

  /// <remarks>
  /// Standard parameters required by CreateWindowEx()
  /// </remarks>
  public CefRect Bounds;

  /// <remarks>
  /// Standard parameters required by CreateWindowEx()
  /// </remarks>
  public nint ParentWindow;

  /// <remarks>
  /// Standard parameters required by CreateWindowEx()
  /// </remarks>
  public nint Menu;

  /// <summary>
  /// Set to true (1) to create the browser using windowless (off-screen)
  /// rendering. No window will be created for the browser and all rendering
  /// will occur via the CefRenderHandler interface. The |parent_window| value
  /// will be used to identify monitor info and to act as the parent window for
  /// dialogs, context menus, etc. If |parent_window| is not provided then the
  /// main screen monitor will be used and some functionality that requires a
  /// parent window may not function correctly. In order to create windowless
  /// browsers the CefSettings.windowless_rendering_enabled value must be set to
  /// true. Transparent painting is enabled by default but can be disabled by
  /// setting CefBrowserSettings.background_color to an opaque value.
  /// </summary>
  public int WindowlessRenderingEnabled;

  /// <summary>
  /// Set to true (1) to enable shared textures for windowless rendering. Only
  /// valid if windowless_rendering_enabled above is also set to true. Currently
  /// only supported on Windows (D3D11).
  /// </summary>
  public int SharedTextureEnabled;

  /// <summary>
  /// Set to true (1) to enable the ability to issue BeginFrame requests from
  /// the client application by calling CefBrowserHost::SendExternalBeginFrame.
  /// </summary>
  public int ExternalBeginFrameEnabled;

  /// <summary>
  /// Handle for the new browser window. Only used with windowed rendering.
  /// </summary>
  public nint Window;

}
