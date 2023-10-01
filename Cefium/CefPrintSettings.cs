namespace Cefium;

/// <summary>
/// <c>cef_print_dialog_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefPrintSettings {

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_print_settings_t object.
  /// <c>CEF_EXPORT cef_print_settings_t* cef_print_settings_create(void)</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_print_settings_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefPrintSettings* Create();

  /// <summary>
  /// Returns true (1) if this object is valid. Do not call any other functions
  /// if this function returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int> _IsValid;

  /// <summary>
  /// Returns true (1) if the values of this object are read-only. Some APIs may
  /// expose read-only objects.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int> _IsReadOnly;

  /// <summary>
  /// Set the page orientation.
  /// <c>void(CEF_CALLBACK* set_orientation)(struct _cef_print_settings_t* self, int landscape)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int, void> _SetOrientation;

  /// <summary>
  /// Returns true (1) if the orientation is landscape.
  /// <c>int(CEF_CALLBACK* is_landscape)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int> _IsLandscape;

  /// <summary>
  /// Set the printer printable area in device units. Some platforms already
  /// provide flipped area. Set |landscape_needs_flip| to false (0) on those
  /// platforms to avoid double flipping.
  /// <c>void(CEF_CALLBACK* set_printer_printable_area)(struct _cef_print_settings_t* self, const cef_size_t* physical_size_device_units, const cef_rect_t* printable_area_device_units, int landscape_needs_flip)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, CefSize*, CefRect*, int, void> _SetPrinterPrintableArea;

  /// <summary>
  /// Set the device name.
  /// <c>void(CEF_CALLBACK* set_device_name)(struct _cef_print_settings_t* self, const cef_string_t* name)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, CefString*, void> _SetDeviceName;

  /// <summary>
  /// Get the device name.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_device_name)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, CefStringUserFree*> _GetDeviceName;

  /// <summary>
  /// Set the DPI (dots per inch).
  /// <c>void(CEF_CALLBACK* set_dpi)(struct _cef_print_settings_t* self, int dpi)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int, void> _SetDpi;

  /// <summary>
  /// Get the DPI (dots per inch).
  /// <c>int(CEF_CALLBACK* get_dpi)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int> _GetDpi;

  /// <summary>
  /// Set the page ranges.
  /// <c>void(CEF_CALLBACK* set_page_ranges)(struct _cef_print_settings_t* self, size_t rangesCount, cef_range_t const* ranges)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, nuint, CefRange*, void> _SetPageRanges;

  /// <summary>
  /// Returns the number of page ranges that currently exist.
  /// <c>size_t(CEF_CALLBACK* get_page_ranges_count)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, nuint> _GetPageRangesCount;

  /// <summary>
  /// Retrieve the page ranges.
  /// <c>void(CEF_CALLBACK* get_page_ranges)(struct _cef_print_settings_t* self, size_t* rangesCount, cef_range_t* ranges)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, nuint*, CefRange*, void> _GetPageRanges;

  /// <summary>
  /// Set whether only the selection will be printed.
  /// <c>void(CEF_CALLBACK* set_selection_only)(struct _cef_print_settings_t* self, int selection_only)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int, void> _SetSelectionOnly;

  /// <summary>
  /// Returns true (1) if only the selection will be printed.
  /// <c>int(CEF_CALLBACK* is_selection_only)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int> _IsSelectionOnly;

  /// <summary>
  /// Set whether pages will be collated.
  /// <c>void(CEF_CALLBACK* set_collate)(struct _cef_print_settings_t* self, int collate)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int, void> _SetCollate;

  /// <summary>
  /// Returns true (1) if pages will be collated.
  /// <c>int(CEF_CALLBACK* will_collate)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int> _WillCollate;

  /// <summary>
  /// Set the color model.
  /// <c>void(CEF_CALLBACK* set_color_model)(struct _cef_print_settings_t* self, cef_color_model_t model)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, CefColorModel, void> _SetColorModel;

  /// <summary>
  /// Get the color model.
  /// <c>cef_color_model_t(CEF_CALLBACK* get_color_model)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, CefColorModel> _GetColorModel;

  /// <summary>
  /// Set the number of copies.
  /// <c>void(CEF_CALLBACK* set_copies)(struct _cef_print_settings_t* self, int copies)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int, void> _SetCopies;

  /// <summary>
  /// Get the number of copies.
  /// <c>int(CEF_CALLBACK* get_copies)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, int> _GetCopies;

  /// <summary>
  /// Set the duplex mode.
  /// <c>void(CEF_CALLBACK* set_duplex_mode)(struct _cef_print_settings_t* self, cef_duplex_mode_t mode)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, CefDuplexMode, void> _SetDuplexMode;

  /// <summary>
  /// Get the duplex mode.
  /// <c>cef_duplex_mode_t(CEF_CALLBACK* get_duplex_mode)(struct _cef_print_settings_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefPrintSettings*, CefDuplexMode> _GetDuplexMode;

}
