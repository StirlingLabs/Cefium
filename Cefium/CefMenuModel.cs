namespace Cefium;

/// <summary>
/// Supports creation and modification of menus. See cef_menu_id_t for the
/// command ids that have default implementations. All user-defined command ids
/// should be between MENU_ID_USER_FIRST and MENU_ID_USER_LAST. The functions of
/// this structure can only be accessed on the browser process the UI thread.
///<c>cef_menu_model_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefMenuModel : ICefRefCountedBase<CefMenuModel> {

  /// <inheritdoc cref="CefMenuModel"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefMenuModel() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new MenuModel with the specified |delegate|.
  /// <c>CEF_EXPORT cef_menu_model_t* cef_menu_model_create(struct _cef_menu_model_delegate_t* delegate);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_menu_model_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern CefMenuModel Create(ref CefMenuModelDelegate @delegate);

  /// <summary>
  /// Returns true (1) if this menu is a submenu.
  /// <c>int(CEF_CALLBACK* is_sub_menu)(struct _cef_menu_model_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int> _IsSubMenu;

  /// <summary>
  /// Clears the menu. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* clear)(struct _cef_menu_model_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int> _Clear;

  /// <summary>
  /// Returns the number of items in this menu.
  /// <c>size_t(CEF_CALLBACK* get_count)(struct _cef_menu_model_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint> _GetCount;

  /// <summary>
  /// Add a separator to the menu. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* add_separator)(struct _cef_menu_model_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int> _AddSeparator;

  /// <summary>
  /// Add an item to the menu. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* add_item)(struct _cef_menu_model_t* self, int command_id, const cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefString*, int> _AddItem;

  /// <summary>
  /// Add a check item to the menu. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* add_check_item)(struct _cef_menu_model_t* self, int command_id, const cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefString*, int> _AddCheckItem;

  /// <summary>
  /// Add a radio item to the menu. Only a single item with the specified
  /// |group_id| can be checked at a time. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* add_radio_item)(struct _cef_menu_model_t* self, int command_id, const cef_string_t* label, int group_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefString*, int, int> _AddRadioItem;

  /// <summary>
  /// Add a sub-menu to the menu. The new sub-menu is returned.
  /// <c>struct _cef_menu_model_t*(CEF_CALLBACK* add_sub_menu)(struct _cef_menu_model_t* self, int command_id, const cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefString*, CefMenuModel*> _AddSubMenu;

  /// <summary>
  /// Insert a separator in the menu at the specified |index|. Returns true (1)
  /// on success.
  /// <c>int(CEF_CALLBACK* insert_separator_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _InsertSeparatorAt;

  /// <summary>
  /// Insert an item in the menu at the specified |index|. Returns true (1) on
  /// success.
  /// <c>int(CEF_CALLBACK* insert_item_at)(struct _cef_menu_model_t* self, size_t index, int command_id, const cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, CefString*, int> _InsertItemAt;

  /// <summary>
  /// Insert a check item in the menu at the specified |index|. Returns true (1)
  /// on success.
  /// <c>int(CEF_CALLBACK* insert_check_item_at)(struct _cef_menu_model_t* self, size_t index, int command_id, const cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, CefString*, int> _InsertCheckItemAt;

  /// <summary>
  /// Insert a radio item in the menu at the specified |index|. Only a single
  /// item with the specified |group_id| can be checked at a time. Returns true
  /// (1) on success.
  /// <c>int(CEF_CALLBACK* insert_radio_item_at)(struct _cef_menu_model_t* self, size_t index, int command_id, const cef_string_t* label, int group_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, CefString*, int, int> _InsertRadioItemAt;

  /// <summary>
  /// Insert a sub-menu in the menu at the specified |index|. The new sub-menu
  /// is returned.
  /// <c>struct _cef_menu_model_t*(CEF_CALLBACK* insert_sub_menu_at)(struct _cef_menu_model_t* self, size_t index, int command_id, const cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, CefString*, CefMenuModel*> _InsertSubMenuAt;

  /// <summary>
  /// Removes the item with the specified |command_id|. Returns true (1) on
  /// success.
  /// <c>int(CEF_CALLBACK* remove)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int> _Remove;

  /// <summary>
  /// Removes the item at the specified |index|. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* remove_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _RemoveAt;

  /// <summary>
  /// Returns the index associated with the specified |command_id| or -1 if not
  /// found due to the command id not existing in the menu.
  /// <c>int(CEF_CALLBACK* get_index_of)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int> _GetIndexOf;

  /// <summary>
  /// Returns the command id at the specified |index| or -1 if not found due to
  /// invalid range or the index being a separator.
  /// <c>int(CEF_CALLBACK* get_command_id_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _GetCommandIdAt;

  /// <summary>
  /// Sets the command id at the specified |index|. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_command_id_at)(struct _cef_menu_model_t* self, size_t index, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, int> _SetCommandIdAt;

  /// <summary>
  /// Returns the label for the specified |command_id| or NULL if not found.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_label)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefStringUserFree*> _GetLabel;

  /// <summary>
  /// Returns the label at the specified |index| or NULL if not found due to
  /// invalid range or the index being a separator.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_label_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, CefStringUserFree*> _GetLabelAt;

  /// <summary>
  /// Sets the label for the specified |command_id|. Returns true (1) on
  /// success.
  /// <c>int(CEF_CALLBACK* set_label)(struct _cef_menu_model_t* self, int command_id, const cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefString*, int> _SetLabel;

  /// <summary>
  /// Set the label at the specified |index|. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_label_at)(struct _cef_menu_model_t* self, size_t index, const cef_string_t* label);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, CefString*, int> _SetLabelAt;

  /// <summary>
  /// Returns the item type for the specified |command_id|.
  /// <c>cef_menu_item_type_t(CEF_CALLBACK* get_type)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefMenuItemType> _GetType;

  /// <summary>
  /// Returns the item type at the specified |index|.
  /// <c>cef_menu_item_type_t(CEF_CALLBACK* get_type_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, CefMenuItemType> _GetTypeAt;

  /// <summary>
  /// Returns the group id for the specified |command_id| or -1 if invalid.
  /// <c>int(CEF_CALLBACK* get_group_id)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int> _GetGroupId;

  /// <summary>
  /// Returns the group id at the specified |index| or -1 if invalid.
  /// <c>int(CEF_CALLBACK* get_group_id_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _GetGroupIdAt;

  /// <summary>
  /// Sets the group id for the specified |command_id|. Returns true (1) on
  /// success.
  /// <c>int(CEF_CALLBACK* set_group_id)(struct _cef_menu_model_t* self, int command_id, int group_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int, int> _SetGroupId;

  /// <summary>
  /// Sets the group id at the specified |index|. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_group_id_at)(struct _cef_menu_model_t* self, size_t index, int group_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, int> _SetGroupIdAt;

  /// <summary>
  /// Returns the submenu for the specified |command_id| or NULL if invalid.
  /// <c>struct _cef_menu_model_t*(CEF_CALLBACK* get_sub_menu)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefMenuModel*> _GetSubMenu;

  /// <summary>
  /// Returns the submenu at the specified |index| or NULL if invalid.
  /// <c>struct _cef_menu_model_t*(CEF_CALLBACK* get_sub_menu_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, CefMenuModel*> _GetSubMenuAt;

  /// <summary>
  /// Returns true (1) if the specified |command_id| is visible.
  /// <c>int(CEF_CALLBACK* is_visible)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int> _IsVisible;

  /// <summary>
  /// Returns true (1) if the specified |index| is visible.
  /// <c>int(CEF_CALLBACK* is_visible_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _IsVisibleAt;

  /// <summary>
  /// Change the visibility of the specified |command_id|. Returns true (1) on
  /// success.
  /// <c>int(CEF_CALLBACK* set_visible)(struct _cef_menu_model_t* self, int command_id, int visible);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int, int> _SetVisible;

  /// <summary>
  /// Change the visibility at the specified |index|. Returns true (1) on
  /// success.
  /// <c>int(CEF_CALLBACK* set_visible_at)(struct _cef_menu_model_t* self, size_t index, int visible);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, int> _SetVisibleAt;

  /// <summary>
  /// Returns true (1) if the specified |command_id| is enabled.
  /// <c>int(CEF_CALLBACK* is_enabled)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int> _IsEnabled;

  /// <summary>
  /// Returns true (1) if the specified |index| is enabled.
  /// <c>int(CEF_CALLBACK* is_enabled_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _IsEnabledAt;

  /// <summary>
  /// Change the enabled status of the specified |command_id|. Returns true (1)
  /// on success.
  /// <c>int(CEF_CALLBACK* set_enabled)(struct _cef_menu_model_t* self, int command_id, int enabled);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int, int> _SetEnabled;

  /// <summary>
  /// Change the enabled status at the specified |index|. Returns true (1) on
  /// success.
  /// <c>int(CEF_CALLBACK* set_enabled_at)(struct _cef_menu_model_t* self, size_t index, int enabled);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, int> _SetEnabledAt;

  /// <summary>
  /// Returns true (1) if the specified |command_id| is checked. Only applies to
  /// check and radio items.
  /// <c>int(CEF_CALLBACK* is_checked)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int> _IsChecked;

  /// <summary>
  /// Returns true (1) if the specified |index| is checked. Only applies to
  /// check and radio items.
  /// <c>int(CEF_CALLBACK* is_checked_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _IsCheckedAt;

  /// <summary>
  /// Check the specified |command_id|. Only applies to check and radio items.
  /// Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_checked)(struct _cef_menu_model_t* self, int command_id, int checked);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int, int> _SetChecked;

  /// <summary>
  /// Check the specified |index|. Only applies to check and radio items.
  /// Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_checked_at)(struct _cef_menu_model_t* self, size_t index, int checked);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, int> _SetCheckedAt;

  /// <summary>
  /// Returns true (1) if the specified |command_id| has a keyboard accelerator
  /// assigned.
  /// <c>int(CEF_CALLBACK* has_accelerator)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int> _HasAccelerator;

  /// <summary>
  /// Returns true (1) if the specified |index| has a keyboard accelerator
  /// assigned.
  /// <c>int(CEF_CALLBACK* has_accelerator_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _HasAcceleratorAt;

  /// <summary>
  /// Set the keyboard accelerator for the specified |command_id|. |key_code|
  /// can be any virtual key or character value. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_accelerator)(struct _cef_menu_model_t* self, int command_id, int key_code, int shift_pressed, int ctrl_pressed, int alt_pressed);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int, int, int, int> _SetAccelerator;

  /// <summary>
  /// Set the keyboard accelerator at the specified |index|. |key_code| can be
  /// any virtual key or character value. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_accelerator_at)(struct _cef_menu_model_t* self, size_t index, int key_code, int shift_pressed, int ctrl_pressed, int alt_pressed);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int, int, int, int> _SetAcceleratorAt;

  /// <summary>
  /// Remove the keyboard accelerator for the specified |command_id|. Returns
  /// true (1) on success.
  /// <c>int(CEF_CALLBACK* remove_accelerator)(struct _cef_menu_model_t* self, int command_id);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int> _RemoveAccelerator;

  /// <summary>
  /// Remove the keyboard accelerator at the specified |index|. Returns true (1)
  /// on success.
  /// <c>int(CEF_CALLBACK* remove_accelerator_at)(struct _cef_menu_model_t* self, size_t index);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int> _RemoveAcceleratorAt;

  /// <summary>
  /// Retrieves the keyboard accelerator for the specified |command_id|. Returns
  /// true (1) on success.
  /// <c>int(CEF_CALLBACK* get_accelerator)(struct _cef_menu_model_t* self, int command_id, int* key_code, int* shift_pressed, int* ctrl_pressed, int* alt_pressed);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, int*, int*, int*, int*, int> _GetAccelerator;

  /// <summary>
  /// Retrieves the keyboard accelerator for the specified |index|. Returns true
  /// (1) on success.
  /// <c>int(CEF_CALLBACK* get_accelerator_at)(struct _cef_menu_model_t* self, size_t index, int* key_code, int* shift_pressed, int* ctrl_pressed, int* alt_pressed);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, nuint, int*, int*, int*, int*, int> _GetAcceleratorAt;

  /// <summary>
  /// Set the explicit color for |command_id| and |color_type| to |color|.
  /// Specify a |color| value of 0 to remove the explicit color. If no explicit
  /// color or default color is set for |color_type| then the system color will
  /// be used. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_color)(struct _cef_menu_model_t* self, int command_id, cef_menu_color_type_t color_type, cef_color_t color);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefMenuColorType, uint, int> _SetColor;

  /// <summary>
  /// Set the explicit color for |command_id| and |index| to |color|. Specify a
  /// |color| value of 0 to remove the explicit color. Specify an |index| value
  /// of -1 to set the default color for items that do not have an explicit
  /// color set. If no explicit color or default color is set for |color_type|
  /// then the system color will be used. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* set_color_at)(struct _cef_menu_model_t* self, int index, cef_menu_color_type_t color_type, cef_color_t color);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefMenuColorType, uint, int> _SetColorAt;

  /// <summary>
  /// Returns in |color| the color that was explicitly set for |command_id| and
  /// |color_type|. If a color was not set then 0 will be returned in |color|.
  /// Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* get_color)(struct _cef_menu_model_t* self, int command_id, cef_menu_color_type_t color_type, cef_color_t* color);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefMenuColorType, uint*, int> _GetColor;

  /// <summary>
  /// Returns in |color| the color that was explicitly set for |command_id| and
  /// |color_type|. Specify an |index| value of -1 to return the default color
  /// in |color|. If a color was not set then 0 will be returned in |color|.
  /// Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* get_color_at)(struct _cef_menu_model_t* self, int index, cef_menu_color_type_t color_type, cef_color_t* color);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefMenuColorType, uint*, int> _GetColorAt;

  /// <summary>
  /// Sets the font list for the specified |command_id|. If |font_list| is NULL
  /// the system font will be used. Returns true (1) on success. The format is
  /// "&lt;FONT_FAMILY_LIST&gt;,[STYLES] &lt;SIZE&gt;", where: - FONT_FAMILY_LIST is a
  /// comma-separated list of font family names, - STYLES is an optional space-
  /// separated list of style names
  ///   (case-sensitive "Bold" and "Italic" are supported), and
  /// - SIZE is an integer font size in pixels with the suffix "px".
  ///
  /// Here are examples of valid font description strings: - "Arial, Helvetica,
  /// Bold Italic 14px" - "Arial, 14px"
  /// <c>int(CEF_CALLBACK* set_font_list)(struct _cef_menu_model_t* self, int command_id, const cef_string_t* font_list);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefString*, int> _SetFontList;

  /// <summary>
  /// Sets the font list for the specified |index|. Specify an |index| value of
  /// -1 to set the default font. If |font_list| is NULL the system font will be
  /// used. Returns true (1) on success. The format is
  /// "&lt;FONT_FAMILY_LIST&gt;,[STYLES] &lt;SIZE&gt;", where: - FONT_FAMILY_LIST is a
  /// comma-separated list of font family names, - STYLES is an optional space-
  /// separated list of style names
  ///   (case-sensitive "Bold" and "Italic" are supported), and
  /// - SIZE is an integer font size in pixels with the suffix "px".
  ///
  /// Here are examples of valid font description strings: - "Arial, Helvetica,
  /// Bold Italic 14px" - "Arial, 14px"
  /// <c>int(CEF_CALLBACK* set_font_list_at)(struct _cef_menu_model_t* self, int index, const cef_string_t* font_list);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefMenuModel*, int, CefString*, int> _SetFontListAt;

}
