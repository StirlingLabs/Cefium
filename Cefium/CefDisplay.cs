namespace Cefium;

/// <summary>
/// This structure typically, but not always, corresponds to a physical display
/// connected to the system. A fake Display may exist on a headless system, or a
/// Display may correspond to a remote, virtual display. All size and position
/// values are in density independent pixel (DIP) coordinates unless otherwise
/// indicated. Methods must be called on the browser process UI thread unless
/// otherwise indicated.
/// <c>cef_display_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDisplay : ICefRefCountedBase<CefDisplay> {

  /// <inheritdoc cref="CefDisplay"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDisplay() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the primary Display.
  /// <c>CEF_EXPORT cef_display_t* cef_display_get_primary(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_get_primary", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefDisplay* GetPrimary();

  /// <summary>
  /// Returns the Display nearest |point|. Set |input_pixel_coords| to true (1) if
  /// |point| is in pixel screen coordinates instead of DIP screen coordinates.
  /// <c>CEF_EXPORT cef_display_t* cef_display_get_nearest_point(const cef_point_t* point, int input_pixel_coords);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_get_nearest_point", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefDisplay* GetNearestPoint(CefPoint* point, int inputPixelCoords);

  /// <summary>
  /// Returns the Display that most closely intersects |bounds|.  Set
  /// |input_pixel_coords| to true (1) if |bounds| is in pixel screen coordinates
  /// instead of DIP screen coordinates.
  /// <c>CEF_EXPORT cef_display_t* cef_display_get_matching_bounds(const cef_rect_t* bounds, int input_pixel_coords);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_get_matching_bounds", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefDisplay* GetMatchingBounds(CefRect* bounds, int inputPixelCoords);

  /// <summary>
  /// Returns the total number of Displays. Mirrored displays are excluded; this
  /// function is intended to return the number of distinct, usable displays.
  /// <c>CEF_EXPORT size_t cef_display_get_count(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_get_count", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe nuint GetCount();

  /// <summary>
  /// Returns all Displays. Mirrored displays are excluded; this function is
  /// intended to return distinct, usable displays.
  /// <c>CEF_EXPORT void cef_display_get_alls(size_t* displaysCount, cef_display_t** displays);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_get_alls", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe void GetAll(nuint* displaysCount, CefDisplay** displays);

  /// <summary>
  /// Convert |point| from DIP screen coordinates to pixel screen coordinates.
  /// This function is only used on Windows.
  /// <c>CEF_EXPORT cef_point_t cef_display_convert_screen_point_to_pixels(const cef_point_t* point);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_convert_screen_point_to_pixels", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefPoint ConvertScreenPointToPixels(CefPoint* point);

  /// <summary>
  /// Convert |point| from pixel screen coordinates to DIP screen coordinates.
  /// This function is only used on Windows.
  /// <c>CEF_EXPORT cef_point_t cef_display_convert_screen_point_from_pixels(const cef_point_t* point);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_convert_screen_point_from_pixels", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefPoint ConvertScreenPointFromPixels(CefPoint* point);

  /// <summary>
  /// Convert |rect| from DIP screen coordinates to pixel screen coordinates. This
  /// function is only used on Windows.
  /// <c>CEF_EXPORT cef_rect_t cef_display_convert_screen_rect_to_pixels(const cef_rect_t* rect);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_convert_screen_rect_to_pixels", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefRect ConvertScreenRectToPixels(CefRect* rect);

  /// <summary>
  /// Convert |rect| from pixel screen coordinates to DIP screen coordinates. This
  /// function is only used on Windows.
  /// <c>CEF_EXPORT cef_rect_t cef_display_convert_screen_rect_from_pixels(const cef_rect_t* rect);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_display_convert_screen_rect_from_pixels", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefRect ConvertScreenRectFromPixels(CefRect* rect);

  /// <summary>
  /// Returns the unique identifier for this Display.
  /// <c>int64(CEF_CALLBACK* get_id)(struct _cef_display_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplay*, long> GetIdDelegate;

  /// <summary>
  /// Returns this Display's device pixel scale factor. This specifies how much
  /// the UI should be scaled when the actual output has more pixels than
  /// standard displays (which is around 100~120dpi). The potential return
  /// values differ by platform.
  /// <c>float(CEF_CALLBACK* get_device_scale_factor)(struct _cef_display_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplay*, float> GetDeviceScaleFactorDelegate;

  /// <summary>
  /// Convert |point| from DIP coordinates to pixel coordinates using this
  /// Display's device scale factor.
  /// <c>void(CEF_CALLBACK* convert_point_to_pixels)(struct _cef_display_t* self, cef_point_t* point);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplay*, CefPoint*, void> ConvertPointToPixelsDelegate;

  /// <summary>
  /// Convert |point| from pixel coordinates to DIP coordinates using this
  /// Display's device scale factor.
  /// <c>void(CEF_CALLBACK* convert_point_from_pixels)(struct _cef_display_t* self, cef_point_t* point);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplay*, CefPoint*, void> ConvertPointFromPixelsDelegate;

  /// <summary>
  /// Returns this Display's bounds in DIP screen coordinates. This is the full
  /// size of the display.
  /// <c>cef_rect_t(CEF_CALLBACK* get_bounds)(struct _cef_display_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplay*, CefRect> GetBoundsDelegate;

  /// <summary>
  /// Returns this Display's work area in DIP screen coordinates. This excludes
  /// areas of the display that are occupied with window manager toolbars, etc.
  /// <c>cef_rect_t(CEF_CALLBACK* get_work_area)(struct _cef_display_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplay*, CefRect> GetWorkAreaDelegate;

  /// <summary>
  /// Returns this Display's rotation in degrees.
  /// <c>int(CEF_CALLBACK* get_rotation)(struct _cef_display_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDisplay*, int> GetRotationDelegate;

}
