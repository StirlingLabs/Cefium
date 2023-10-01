namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 440)]
public struct CefView : ICefRefCountedBase<CefView> {

  // cef_view_t
  public CefRefCountedBase Base; // base @ 0, 40 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefBrowserView*> _AsBrowserView; // as_browser_view @ 40, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefButton*> _AsButton; // as_button @ 48, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefPanel*> _AsPanel; // as_panel @ 56, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefScrollView*> _AsScrollView; // as_scroll_view @ 64, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefTextField*> _AsTextfield; // as_textfield @ 72, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefString*> _GetTypeString; // get_type_string @ 80, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int, CefString*> _ToString; // to_string @ 88, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _IsValid; // is_valid @ 96, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _IsAttached; // is_attached @ 104, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefView*, int> _IsSame; // is_same @ 112, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefViewDelegate*> _GetDelegate; // get_delegate @ 120, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefWindow*> _GetWindow; // get_window @ 128, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _GetId; // get_id @ 136, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int, void> _SetId; // set_id @ 144, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _GetGroupId; // get_group_id @ 152, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int, void> _SetGroupId; // set_group_id @ 160, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefView*> _GetParentView; // get_parent_view @ 168, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int, CefView*> _GetViewForId; // get_view_for_id @ 176, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefRect*, void> _SetBounds; // set_bounds @ 184, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefRect> _GetBounds; // get_bounds @ 192, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefRect> _GetBoundsInScreen; // get_bounds_in_screen @ 200, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefSize*, void> _SetSize; // set_size @ 208, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefSize> _GetSize; // get_size @ 216, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefPoint*, void> _SetPosition; // set_position @ 224, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefPoint> _GetPosition; // get_position @ 232, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefInsets*, void> _SetInsets; // set_insets @ 240, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefInsets> _GetInsets; // get_insets @ 248, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefSize> _GetPreferredSize; // get_preferred_size @ 256, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, void> _SizeToPreferredSize; // size_to_preferred_size @ 264, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefSize> _GetMinimumSize; // get_minimum_size @ 272, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefSize> _GetMaximumSize; // get_maximum_size @ 280, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int, int> _GetHeightForWidth; // get_height_for_width @ 288, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, void> _InvalidateLayout; // invalidate_layout @ 296, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int, void> _SetVisible; // set_visible @ 304, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _IsVisible; // is_visible @ 312, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _IsDrawn; // is_drawn @ 320, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int, void> _SetEnabled; // set_enabled @ 328, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _IsEnabled; // is_enabled @ 336, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int, void> _SetFocusable; // set_focusable @ 344, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _IsFocusable; // is_focusable @ 352, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, int> _IsAccessibilityFocusable; // is_accessibility_focusable @ 360, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, void> _RequestFocus; // request_focus @ 368, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, uint, void> _SetBackgroundColor; // set_background_color @ 376, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, uint> _GetBackgroundColor; // get_background_color @ 384, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefPoint*, int> _ConvertPointToScreen; // convert_point_to_screen @ 392, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefPoint*, int> _ConvertPointFromScreen; // convert_point_from_screen @ 400, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefPoint*, int> _ConvertPointToWindow; // convert_point_to_window @ 408, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefPoint*, int> _ConvertPointFromWindow; // convert_point_from_window @ 416, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefView*, CefPoint*, int> _ConvertPointToView; // convert_point_to_view @ 424, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefView*, CefView*, CefPoint*, int> _ConvertPointFromView; // convert_point_from_view @ 432, 8 bytes

}
