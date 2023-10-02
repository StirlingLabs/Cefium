using System.Runtime.Versioning;

namespace Cefium;

/// <summary>
/// Windows extended window styles.
/// </summary>
[PublicAPI, SupportedOSPlatform("windows"), Flags]
public enum WindowStyleEx : uint {

  /// <summary>
  /// The window has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
  /// <c>WS_EX_DLGMODALFRAME</c>
  /// </summary>
  DialogModalFrame = 0x00000001,

  /// <summary>
  /// The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
  /// <c>WS_EX_NOPARENTNOTIFY</c>
  /// </summary>
  NoParentNotify = 0x00000004,

  /// <summary>
  /// The window should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the SetWindowPos function.
  /// <c>WS_EX_TOPMOST</c>
  /// </summary>
  Topmost = 0x00000008,

  /// <summary>
  /// The window accepts drag-drop files.
  /// <c>WS_EX_ACCEPTFILES</c>
  /// </summary>
  AcceptFiles = 0x00000010,

  /// <summary>
  /// The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted.
  /// To achieve transparency without these restrictions, use the SetWindowRgn function.
  /// <c>WS_EX_TRANSPARENT</c>
  /// </summary>
  Transparent = 0x00000020,

  /// <summary>
  /// The window is a MDI child window.
  /// <c>WS_EX_MDICHILD</c>
  /// </summary>
  Mdichild = 0x00000040,

  /// <summary>
  /// The window is intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE.
  /// <c>WS_EX_TOOLWINDOW</c>
  /// </summary>
  Toolwindow = 0x00000080,

  /// <summary>
  /// The window has a border with a raised edge.
  /// <c>WS_EX_WINDOWEDGE</c>
  /// </summary>
  WindowEdge = 0x00000100,

  /// <summary>
  /// The window has a border with a sunken edge.
  /// <c>WS_EX_CLIENTEDGE</c>
  /// </summary>
  ClientEdge = 0x00000200,

  /// <summary>
  /// The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window.
  /// WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
  /// <c>WS_EX_CONTEXTHELP</c>
  /// </summary>
  ContextHelp = 0x00000400,

  /// <summary>
  /// The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored.
  /// Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
  /// <c>WS_EX_RIGHT</c>
  /// </summary>
  Right = 0x00001000,

  /// <summary>
  /// The window has generic left-aligned properties. This is the default.
  /// <c>WS_EX_LEFT</c>
  /// </summary>
  Left = 0x00000000,

  /// <summary>
  /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
  /// <c>WS_EX_RTLREADING</c>
  /// </summary>
  RightToLeftReading = 0x00002000,

  /// <summary>
  /// The window text is displayed using left-to-right reading-order properties. This is the default.
  /// <c>WS_EX_LTRREADING</c>
  /// </summary>
  LeftToRightReading = 0x00000000,

  /// <summary>
  /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
  /// <c>WS_EX_LEFTSCROLLBAR</c>
  /// </summary>
  LeftScrollbar = 0x00004000,

  /// <summary>
  /// The vertical scroll bar (if present) is to the right of the client area. This is the default.
  /// <c>WS_EX_RIGHTSCROLLBAR</c>
  /// </summary>
  RightScrollbar = 0x00000000,

  /// <summary>
  /// The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
  /// <c>WS_EX_CONTROLPARENT</c>
  /// </summary>
  ControlParent = 0x00010000,

  /// <summary>
  /// The window has a three-dimensional border style intended to be used for items that do not accept user input.
  /// <c>WS_EX_STATICEDGE</c>
  /// </summary>
  StaticEdge = 0x00020000,

  /// <summary>
  /// Forces a top-level window onto the taskbar when the window is visible.
  /// <c>WS_EX_APPWINDOW</c>
  /// </summary>
  ApplicationWindow = 0x00040000,

  /// <summary>
  /// The window is an overlapped window.
  /// <c>WS_EX_OVERLAPPEDWINDOW</c>
  /// </summary>
  OverlappedWindow = (WindowEdge | ClientEdge),

  /// <summary>
  /// The window is palette window, which is a modeless dialog box that presents an array of commands.
  /// <c>WS_EX_PALETTEWINDOW</c>
  /// </summary>
  PaletteWindow = (WindowEdge | Toolwindow | Topmost),

  /// <summary>
  /// The window is a layered window. This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
  /// Windows 8: The WS_EX_LAYERED style is supported for top-level windows and child windows. Previous Windows versions support WS_EX_LAYERED only for top-level windows.
  /// <c>WS_EX_LAYERED</c>
  /// </summary>
  Layered = 0x00080000,

  /// <summary>
  /// The window does not pass its window layout to its child windows.
  /// </summary>
  /// <remarks>
  /// Disable inheritance of mirroring by children
  /// <c>WS_EX_NOINHERITLAYOUT</c>
  /// </remarks>
  NoInheritLayout = 0x00100000,

  /// <summary>
  /// The window does not render to a redirection surface. This is for windows that do not have visible content or that use mechanisms other than surfaces to provide their visual.
  /// <c>WS_EX_NOREDIRECTIONBITMAP</c>
  /// </summary>
  NoRedirectionBitmap = 0x00200000,

  /// <summary>
  /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the horizontal origin of the window is on the right edge. Increasing horizontal values advance to the left.
  /// </summary>
  /// <remarks>
  /// Right to left mirroring
  /// <c>WS_EX_LAYOUTRTL</c>
  /// </remarks>
  LayoutRightToLeft = 0x00400000,

  /// <summary>
  /// Paints all descendants of a window in bottom-to-top painting order using double-buffering. Bottom-to-top painting order allows a descendent window to have translucency (alpha) and transparency (color-key) effects, but only if the descendent window also has the WS_EX_TRANSPARENT bit set. Double-buffering allows the window and its descendents to be painted without flicker. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
  /// Windows 2000: This style is not supported.
  /// <c>WS_EX_COMPOSITED</c>
  /// </summary>
  Composited = 0x02000000,

  /// <summary>
  /// A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window.
  /// The window should not be activated through programmatic access or via keyboard navigation by accessible technology, such as Narrator.
  /// To activate the window, use the SetActiveWindow or SetForegroundWindow function.
  /// The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
  /// <c>WS_EX_NOACTIVATE</c>
  /// </summary>
  NoActivate = 0x08000000,

}
