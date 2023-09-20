namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=688)]
public struct CefTextField { // cef_textfield_t
  [DllImport("cef", EntryPoint = "cef_textfield_create", CallingConvention = CallingConvention.Cdecl)]
  internal static extern unsafe CefTextField* _Create(CefTextfieldDelegate* arg0);

  public CefView Base; // base @ 0, 440 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,int,void> _SetPasswordInput; // set_password_input @ 440, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,int> _IsPasswordInput; // is_password_input @ 448, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,int,void> _SetReadOnly; // set_read_only @ 456, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,int> _IsReadOnly; // is_read_only @ 464, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*> _GetText; // get_text @ 472, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*,void> _SetText; // set_text @ 480, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*,void> _AppendText; // append_text @ 488, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*,void> _InsertOrReplaceText; // insert_or_replace_text @ 496, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,int> _HasSelection; // has_selection @ 504, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*> _GetSelectedText; // get_selected_text @ 512, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,int,void> _SelectAll; // select_all @ 520, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,void> _ClearSelection; // clear_selection @ 528, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefRange> _GetSelectedRange; // get_selected_range @ 536, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefRange*,void> _SelectRange; // select_range @ 544, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint> _GetCursorPosition; // get_cursor_position @ 552, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint,void> _SetTextColor; // set_text_color @ 560, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint> _GetTextColor; // get_text_color @ 568, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint,void> _SetSelectionTextColor; // set_selection_text_color @ 576, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint> _GetSelectionTextColor; // get_selection_text_color @ 584, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint,void> _SetSelectionBackgroundColor; // set_selection_background_color @ 592, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint> _GetSelectionBackgroundColor; // get_selection_background_color @ 600, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*,void> _SetFontList; // set_font_list @ 608, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint,CefRange*,void> _ApplyTextColor; // apply_text_color @ 616, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefTextStyle,int,CefRange*,void> _ApplyTextStyle; // apply_text_style @ 624, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefTextFieldCommands,int> _IsCommandEnabled; // is_command_enabled @ 632, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefTextFieldCommands,void> _ExecuteCommand; // execute_command @ 640, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,void> _ClearEditHistory; // clear_edit_history @ 648, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*,void> _SetPlaceholderText; // set_placeholder_text @ 656, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*> _GetPlaceholderText; // get_placeholder_text @ 664, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,uint,void> _SetPlaceholderTextColor; // set_placeholder_text_color @ 672, 8 bytes
  internal unsafe delegate * unmanaged[Cdecl]<CefTextField*,CefString*,void> _SetAccessibleName; // set_accessible_name @ 680, 8 bytes
}
