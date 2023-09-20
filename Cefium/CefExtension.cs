namespace Cefium;

/// <summary>
/// Object representing an extension. Methods may be called on any thread unless
/// otherwise indicated.
/// </summary>
/// <seealso cref="CefExtensionExtensions"/>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefExtension : ICefRefCountedBase<CefExtension> {

  /// <inheritdoc cref="CefExtension"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefExtension() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the unique extension identifier. This is calculated based on the
  /// extension public key, if available, or on the extension path. See
  /// https://developer.chrome.com/extensions/manifest/key for details.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_identifier)(struct _cef_extension_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtension*, CefStringUserFree*> _GetIdentifier;

  /// <summary>
  /// Returns the absolute path to the extension directory on disk. This value
  /// will be prefixed with PK_DIR_RESOURCES if a relative path was passed to
  /// cef_request_context_t::LoadExtension.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_path)(struct _cef_extension_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtension*, CefStringUserFree*> _GetPath;

  /// <summary>
  /// Returns the extension manifest contents as a cef_dictionary_value_t
  /// object. See https://developer.chrome.com/extensions/manifest for details.
  /// <c>struct _cef_dictionary_value_t*(CEF_CALLBACK* get_manifest)(struct _cef_extension_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtension*, CefDictionaryValue*> _GetManifest;

  /// <summary>
  /// Returns true (1) if this object is the same extension as |that| object.
  /// Extensions are considered the same if identifier, path and loader context
  /// match.
  /// <c>int(CEF_CALLBACK* is_same)(struct _cef_extension_t* self, struct _cef_extension_t* that);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtension*, CefExtension*, int> _IsSame;

  /// <summary>
  /// Returns the handler for this extension. Will return NULL for internal
  /// extensions or if no handler was passed to
  /// cef_request_context_t::LoadExtension.
  /// <c>struct _cef_extension_handler_t*(CEF_CALLBACK* get_handler)(struct _cef_extension_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtension*, CefExtensionHandler*> _GetHandler;

  /// <summary>
  /// Returns the request context that loaded this extension. Will return NULL
  /// for internal extensions or if the extension has been unloaded. See the
  /// cef_request_context_t::LoadExtension documentation for more information
  /// about loader contexts. Must be called on the browser process UI thread.
  /// <c>struct _cef_request_context_t*(CEF_CALLBACK* get_loader_context)(struct _cef_extension_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtension*, CefRequestContext*> _GetLoaderContext;

  /// <summary>
  /// Returns true (1) if this extension is currently loaded. Must be called on
  /// the browser process UI thread.
  /// <c>int(CEF_CALLBACK* is_loaded)(struct _cef_extension_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtension*, int> _IsLoaded;

  /// <summary>
  /// Unload this extension if it is not an internal extension and is currently
  /// loaded. Will result in a call to
  /// cef_extension_handler_t::OnExtensionUnloaded on success.
  /// <c>void(CEF_CALLBACK* unload)(struct _cef_extension_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefExtension*, void> _Unload;

}
