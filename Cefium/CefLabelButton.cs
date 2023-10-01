namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size = 576)]
public struct CefLabelButton : ICefRefCountedBase<CefLabelButton> {

  // cef_label_button_t
  [DllImport("cef", EntryPoint = "cef_label_button_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefLabelButton* _Create(CefButtonDelegate* arg0, CefString* arg1);

  public CefButton Base; // base @ 0, 488 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefMenuButton*> _AsMenuButton; // as_menu_button @ 488, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefString*, void> _SetText; // set_text @ 496, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefString*> _GetText; // get_text @ 504, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefButtonState, CefImage*, void> _SetImage; // set_image @ 512, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefButtonState, CefImage*> _GetImage; // get_image @ 520, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefButtonState, uint, void> _SetTextColor; // set_text_color @ 528, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, uint, void> _SetEnabledTextColors; // set_enabled_text_colors @ 536, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefString*, void> _SetFontList; // set_font_list @ 544, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefHorizontalAlignment, void> _SetHorizontalAlignment; // set_horizontal_alignment @ 552, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefSize*, void> _SetMinimumSize; // set_minimum_size @ 560, 8 bytes

  public unsafe delegate * unmanaged[Cdecl]<CefLabelButton*, CefSize*, void> _SetMaximumSize; // set_maximum_size @ 568, 8 bytes

}
