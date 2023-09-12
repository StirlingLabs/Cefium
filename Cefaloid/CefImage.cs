namespace Cefaloid;

/// <summary>
/// Container for a single image represented at different scale factors. All
/// image representations should be the same size in density independent pixel
/// (DIP) units. For example, if the image at scale factor 1.0 is 100x100 pixels
/// then the image at scale factor 2.0 should be 200x200 pixels -- both images
/// will display with a DIP size of 100x100 units. The functions of this
/// structure can be called on any browser process thread.
/// <c>cef_image_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefImage : ICefRefCountedBase<CefImage> {

  /// <inheritdoc cref="CefImage"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefImage() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_image_t. It will initially be NULL. Use the Add*()
  /// functions to add representations at different scale factors.
  /// <c>CEF_EXPORT cef_image_t* cef_image_create(void)</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_image_create", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefImage* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefImage* CreateUndefined()
    => _Create();

  /// <summary>
  /// Returns true (1) if this Image is NULL.
  /// <c>int(CEF_CALLBACK* is_empty)(struct _cef_image_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, int> _IsEmpty;

  /// <summary>
  /// Returns true (1) if this Image and |that| Image share the same underlying
  /// storage. Will also return true (1) if both images are NULL.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_image_t* self, struct _cef_image_t* that)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, CefImage*, int> _IsSame;

  /// <summary>
  /// Add a bitmap image representation for |scale_factor|. Only 32-bit
  /// RGBA/BGRA formats are supported. |pixel_width| and |pixel_height| are the
  /// bitmap representation size in pixel coordinates. |pixel_data| is the array
  /// of pixel data and should be |pixel_width| x |pixel_height| x 4 bytes in
  /// size. |color_type| and |alpha_type| values specify the pixel format.
  /// <c>int(CEF_CALLBACK* add_bitmap)(struct _cef_image_t* self, float scale_factor, int pixel_width, int pixel_height, cef_color_type_t color_type, cef_alpha_type_t alpha_type, const void* pixel_data, size_t pixel_data_size)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, int, int, CefColorType, CefAlphaType, void*, nuint, int> _AddBitmap;

  /// <summary>
  /// Add a PNG image representation for |scale_factor|. |png_data| is the image
  /// data of size |png_data_size|. Any alpha transparency in the PNG data will
  /// be maintained.
  /// <c>int(CEF_CALLBACK* add_png)(struct _cef_image_t* self, float scale_factor, const void* png_data, size_t png_data_size)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, void*, nuint, int> _AddPng;

  /// <summary>
  /// Create a JPEG image representation for |scale_factor|. |jpeg_data| is the
  /// image data of size |jpeg_data_size|. The JPEG format does not support
  /// transparency so the alpha byte will be set to 0xFF for all pixels.
  /// <c>int(CEF_CALLBACK* add_jpeg)(struct _cef_image_t* self, float scale_factor, const void* jpeg_data, size_t jpeg_data_size)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, void*, nuint, int> _AddJpeg;

  /// <summary>
  /// Returns the image width in density independent pixel (DIP) units.
  /// <c>size_t(CEF_CALLBACK* get_width)(struct _cef_image_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, nuint> _GetWidth;

  /// <summary>
  /// Returns the image height in density independent pixel (DIP) units.
  /// <c>size_t(CEF_CALLBACK* get_height)(struct _cef_image_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, nuint> _GetHeight;

  /// <summary>
  /// Returns true (1) if this image contains a representation for
  /// |scale_factor|.
  /// <c>int(CEF_CALLBACK* has_representation)(struct _cef_image_t* self, float scale_factor)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, int> _HasRepresentation;

  /// <summary>
  /// Removes the representation for |scale_factor|. Returns true (1) on
  /// success.
  /// <c>int(CEF_CALLBACK* remove_representation)(struct _cef_image_t* self, float scale_factor)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, int> _RemoveRepresentation;

  /// <summary>
  /// Returns information for the representation that most closely matches
  /// |scale_factor|. |actual_scale_factor| is the actual scale factor for the
  /// representation. |pixel_width| and |pixel_height| are the representation
  /// size in pixel coordinates. Returns true (1) on success.
  /// <c>int(CEF_CALLBACK* get_representation_info)(struct _cef_image_t* self, float scale_factor, float* actual_scale_factor, int* pixel_width, int* pixel_height)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, float*, int*, int*, int> _GetRepresentationInfo;

  /// <summary>
  /// Returns the bitmap representation that most closely matches
  /// |scale_factor|. Only 32-bit RGBA/BGRA formats are supported. |color_type|
  /// and |alpha_type| values specify the desired output pixel format.
  /// |pixel_width| and |pixel_height| are the output representation size in
  /// pixel coordinates. Returns a cef_binary_value_t containing the pixel data
  /// on success or NULL on failure.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_as_bitmap)(struct _cef_image_t* self, float scale_factor, cef_color_type_t color_type, cef_alpha_type_t alpha_type, int* pixel_width, int* pixel_height)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, CefColorType, CefAlphaType, int*, int*, CefBinaryValue*> _GetAsBitmap;

  /// <summary>
  /// Returns the PNG representation that most closely matches |scale_factor|.
  /// If |with_transparency| is true (1) any alpha transparency in the image
  /// will be represented in the resulting PNG data. |pixel_width| and
  /// |pixel_height| are the output representation size in pixel coordinates.
  /// Returns a cef_binary_value_t containing the PNG image data on success or
  /// NULL on failure.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_as_png)(struct _cef_image_t* self, float scale_factor, int with_transparency, int* pixel_width, int* pixel_height)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, int, int*, int*, CefBinaryValue*> _GetAsPng;

  /// <summary>
  /// Returns the JPEG representation that most closely matches |scale_factor|.
  /// |quality| determines the compression level with 0 == lowest and 100 ==
  /// highest. The JPEG format does not support alpha transparency and the alpha
  /// channel, if any, will be discarded. |pixel_width| and |pixel_height| are
  /// the output representation size in pixel coordinates. Returns a
  /// cef_binary_value_t containing the JPEG image data on success or NULL on
  /// failure.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_as_jpeg)(struct _cef_image_t* self, float scale_factor, int quality, int* pixel_width, int* pixel_height)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefImage*, float, int, int*, int*, CefBinaryValue*> _GetAsJpeg;

}
