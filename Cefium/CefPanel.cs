namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 536)]
public struct CefPanel : ICefRefCountedBase<CefPanel> {

  // cef_panel_t
  [DllImport("cef", EntryPoint = "cef_panel_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefPanel* _Create(CefPanelDelegate* arg0);

  public CefView Base; // base @ 0, 440 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, CefWindow*> _AsWindow; // as_window @ 440, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, CefFillLayout*> _SetToFillLayout; // set_to_fill_layout @ 448, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, CefBoxLayoutSettings*, CefBoxLayout*> _SetToBoxLayout; // set_to_box_layout @ 456, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, CefLayout*> _GetLayout; // get_layout @ 464, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, void> _Layout; // layout @ 472, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, CefView*, void> _AddChildView; // add_child_view @ 480, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, CefView*, int, void> _AddChildViewAt; // add_child_view_at @ 488, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, CefView*, int, void> _ReorderChildView; // reorder_child_view @ 496, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, CefView*, void> _RemoveChildView; // remove_child_view @ 504, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, void> _RemoveAllChildViews; // remove_all_child_views @ 512, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, uint> _GetChildViewCount; // get_child_view_count @ 520, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefPanel*, int, CefView*> _GetChildViewAt; // get_child_view_at @ 528, 8 bytes

}
