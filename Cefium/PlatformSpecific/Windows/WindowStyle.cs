using System.Runtime.Versioning;

namespace Cefium;

/// <summary>
/// Windows window styles.
/// </summary>
/// <remarks>
/// After the window has been created, these styles cannot be modified, except as noted.
/// </remarks>
[PublicAPI, SupportedOSPlatform("windows"), Flags]
public enum WindowStyle : uint {

  /// <summary>
  /// The window is an overlapped window. An overlapped window has a
  /// title bar and a border. Same as the WS_TILED style.
  /// <c>WS_OVERLAPPED</c>
  /// </summary>
  Overlapped = 0x00000000,

  /// <summary>
  /// The window is a pop-up window. This style cannot be used with
  /// the WS_CHILD style.
  /// <c>WS_POPUP</c>
  /// </summary>
  Popup = 0x80000000,

  /// <summary>
  /// The window is a child window. A window with this style cannot have a
  /// menu bar. This style cannot be used with the WS_POPUP style.
  /// <c>WS_CHILD</c>
  /// </summary>
  Child = 0x40000000,

  /// <summary>
  /// The window is initially minimized. Same as the WS_ICONIC style.
  /// <c>WS_MINIMIZE</c>
  /// </summary>
  Minimize = 0x20000000,

  /// <summary>
  /// The window is initially visible.
  /// This style can be turned on and off by using the ShowWindow
  /// or SetWindowPos function.
  /// <c>WS_VISIBLE</c>
  /// </summary>
  Visible = 0x10000000,

  /// <summary>
  /// The window is initially disabled. A disabled window cannot receive
  /// input from the user. To change this after a window has been created,
  /// use the EnableWindow function.
  /// <c>WS_DISABLED</c>
  /// </summary>
  Disabled = 0x08000000,

  /// <summary>
  /// Clips child windows relative to each other; that is, when a particular
  /// child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style
  /// clips all other overlapping child windows out of the region of the
  /// child window to be updated. If WS_CLIPSIBLINGS is not specified and
  /// child windows overlap, it is possible, when drawing within the client
  /// area of a child window, to draw within the client area of a
  /// neighboring child window.
  /// <c>WS_CLIPSIBLINGS</c>
  /// </summary>
  ClipSiblings = 0x04000000,

  /// <summary>
  /// Excludes the area occupied by child windows when drawing occurs within
  /// the parent window. This style is used when creating the parent window.
  /// <c>WS_CLIPCHILDREN</c>
  /// </summary>
  ClipChildren = 0x02000000,

  /// <summary>
  /// The window is initially maximized.
  /// <c>WS_MAXIMIZE</c>
  /// </summary>
  Maximize = 0x01000000,

  /// <summary>
  /// The window has a title bar (includes the WS_BORDER style).
  /// <c>WS_CAPTION</c>
  /// </summary>
  Caption = 0x00C00000,

  /// <summary>
  /// The window has a thin-line border
  /// <c>WS_BORDER</c>
  /// </summary>
  Border = 0x00800000,

  /// <summary>
  /// The window has a border of a style typically used with dialog boxes.
  /// A window with this style cannot have a title bar.
  /// <c>WS_DLGFRAME</c>
  /// </summary>
  DialogFrame = 0x00400000,

  /// <summary>
  /// The window has a vertical scroll bar.
  /// <c>WS_VSCROLL</c>
  /// </summary>
  VerticalScroll = 0x00200000,

  /// <summary>
  /// The window has a horizontal scroll bar.
  /// <c>WS_HSCROLL</c>
  /// </summary>
  HorizontalScroll = 0x00100000,

  /// <summary>
  /// The window has a window menu on its title bar.
  /// The WS_CAPTION style must also be specified.
  /// <c>WS_SYSMENU</c>
  /// </summary>
  SystemMenu = 0x00080000,

  /// <summary>
  /// The window has a sizing border. Same as the WS_SIZEBOX style.
  /// <c>WS_THICKFRAME</c>
  /// </summary>
  ThickFrame = 0x00040000,

  /// <summary>
  /// The window is the first control of a group of controls.
  /// The group consists of this first control and all controls defined
  /// after it, up to the next control with the WS_GROUP style. The first
  /// control in each group usually has the WS_TABSTOP style so that
  /// the user can move from group to group. The user can subsequently
  /// change the keyboard focus from one control in the group to the next
  /// control in the group by using the direction keys.
  /// You can turn this style on and off to change dialog box navigation.
  /// To change this style after a window has been created, use the
  /// SetWindowLong function.
  /// <c>WS_GROUP</c>
  /// </summary>
  Group = 0x00020000,

  /// <summary>
  /// The window is a control that can receive the keyboard focus when the
  /// user presses the TAB key. Pressing the TAB key changes the keyboard
  /// focus to the next control with the WS_TABSTOP style.
  /// You can turn this style on and off to change dialog box navigation.
  /// To change this style after a window has been created, use the
  /// SetWindowLong function. For user-created windows and modeless dialogs
  /// to work with tab stops, alter the message loop to call the
  /// IsDialogMessage function.
  /// <c>WS_TABSTOP</c>
  /// </summary>
  TabStop = 0x00010000,

  /// <summary>
  /// The window has a minimize button. Cannot be combined with the
  /// WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.
  /// <c>WS_MINIMIZEBOX</c>
  /// </summary>
  MinimizeBox = 0x00020000,

  /// <summary>
  /// The window has a maximize button. Cannot be combined with the
  /// WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.
  /// <c>WS_MAXIMIZEBOX</c>
  /// </summary>
  MaximizeBox = 0x00010000,

  /// <summary>
  /// The window is an overlapped window.
  /// An overlapped window has a title bar and a border.
  /// Same as the WS_OVERLAPPED style.
  /// <c>WS_TILED</c>
  /// </summary>
  Tiled = Overlapped,

  /// <summary>
  /// The window is initially minimized. Same as the WS_MINIMIZE style.
  /// <c>WS_ICONIC</c>
  /// </summary>
  Iconic = Minimize,

  /// <summary>
  /// The window has a sizing border. Same as the WS_THICKFRAME style.
  /// <c>WS_SIZEBOX</c>
  /// </summary>
  SizeBox = ThickFrame,

  /// <summary>
  /// The window is an overlapped window.
  /// Same as the WS_OVERLAPPEDWINDOW style.
  /// <c>WS_TILEDWINDOW</c>
  /// </summary>
  TiledWindow = OverlappedWindow,

  /// <summary>
  /// The window is an overlapped window. Same as the WS_TILEDWINDOW style.
  /// <c>WS_OVERLAPPEDWINDOW</c>
  /// </summary>
  OverlappedWindow = (Overlapped | Caption | SystemMenu | ThickFrame | MinimizeBox | MaximizeBox),

  /// <summary>
  /// The window is a pop-up window. The WS_CAPTION and WS_POPUPWINDOW
  /// styles must be combined to make the window menu visible.
  /// <c>WS_POPUPWINDOW</c>
  /// </summary>
  PopupWindow = (Popup | Border | SystemMenu),

  /// <summary>
  /// Same as the WS_CHILD style.
  /// <c>WS_CHILDWINDOW</c>
  /// </summary>
  ChildWindow = (Child)

}
