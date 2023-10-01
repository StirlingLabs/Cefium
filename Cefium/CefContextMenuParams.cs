namespace Cefium;

/// <summary>
/// Provides information about the context menu state. The functions of this
/// structure can only be accessed on browser process the UI thread.
/// <c>cef_context_menu_params_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefContextMenuParams : ICefRefCountedBase<CefContextMenuParams> {

  /// <inheritdoc cref="CefContextMenuParams"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefContextMenuParams() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the X coordinate of the mouse where the context menu was invoked.
  /// Coords are relative to the associated RenderView's origin.
  /// <c>int(CEF_CALLBACK* get_xcoord)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, int> _GetXCoord;

  /// <summary>
  /// Returns the Y coordinate of the mouse where the context menu was invoked.
  /// Coords are relative to the associated RenderView's origin.
  /// <c>int(CEF_CALLBACK* get_ycoord)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, int> _GetYCoord;

  /// <summary>
  /// Returns flags representing the type of node that the context menu was
  /// invoked on.
  /// <c>cef_context_menu_type_flags_t(CEF_CALLBACK* get_type_flags)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefContextMenuTypeFlags> _GetTypeFlags;

  /// <summary>
  /// Returns the URL of the link, if any, that encloses the node that the
  /// context menu was invoked on.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_link_url)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetLinkUrl;

  /// <summary>
  /// Returns the link URL, if any, to be used ONLY for "copy link address". We
  /// don't validate this field in the frontend process.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_unfiltered_link_url)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetUnfilteredLinkUrl;

  /// <summary>
  /// Returns the source URL, if any, for the element that the context menu was
  /// invoked on. Example of elements with source URLs are img, audio, and
  /// video.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_source_url)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetSourceUrl;

  /// <summary>
  /// Returns true (1) if the context menu was invoked on an image which has
  /// non-NULL contents.
  /// <c>int(CEF_CALLBACK* has_image_contents)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, int> _HasImageContents;

  /// <summary>
  /// Returns the title text or the alt text if the context menu was invoked on
  /// an image.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_title_text)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetTitleText;

  /// <summary>
  /// Returns the URL of the top level page that the context menu was invoked
  /// on.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_page_url)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetPageUrl;

  /// <summary>
  /// Returns the URL of the subframe that the context menu was invoked on.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_frame_url)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetFrameUrl;

  /// <summary>
  /// Returns the character encoding of the subframe that the context menu was
  /// invoked on.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_frame_charset)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetFrameCharset;

  /// <summary>
  /// Returns the type of context node that the context menu was invoked on.
  /// <c>cef_context_menu_media_type_t(CEF_CALLBACK* get_media_type)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefContextMenuMediaType> _GetMediaType;

  /// <summary>
  /// Returns flags representing the actions supported by the media element, if
  /// any, that the context menu was invoked on.
  /// <c>cef_context_menu_media_state_flags_t(CEF_CALLBACK* get_media_state_flags)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefContextMenuMediaStateFlags> _GetMediaStateFlags;

  /// <summary>
  /// Returns the text of the selection, if any, that the context menu was
  /// invoked on.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_selection_text)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetSelectionText;

  /// <summary>
  /// Returns the text of the misspelled word, if any, that the context menu was
  /// invoked on.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_misspelled_word)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringUserFree*> _GetMisspelledWord;

  /// <summary>
  /// Returns true (1) if suggestions exist, false (0) otherwise. Fills in
  /// |suggestions| from the spell check service for the misspelled word if
  /// there is one.
  /// <c>int(CEF_CALLBACK* get_dictionary_suggestions)(struct _cef_context_menu_params_t* self, cef_string_list_t suggestions);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefStringList*, int> _GetDictionarySuggestions;

  /// <summary>
  /// Returns true (1) if the context menu was invoked on an editable node.
  /// <c>int(CEF_CALLBACK* is_editable)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, int> _IsEditable;

  /// <summary>
  /// Returns true (1) if the context menu was invoked on an editable node where
  /// spell-check is enabled.
  /// <c>int(CEF_CALLBACK* is_spell_check_enabled)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, int> _IsSpellCheckEnabled;

  /// <summary>
  /// Returns flags representing the actions supported by the editable node, if
  /// any, that the context menu was invoked on.
  /// <c>cef_context_menu_edit_state_flags_t(CEF_CALLBACK* get_edit_state_flags)(struct _cef_context_menu_params_t* self);</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, CefContextMenuEditStateFlags> _GetEditStateFlags;

  /// <summary>
  /// Returns true (1) if the context menu contains items specified by the
  /// renderer process.
  /// <c>int(CEF_CALLBACK* is_custom_menu)(struct _cef_context_menu_params_t* self);</c>
  ///</summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefContextMenuParams*, int> _IsCustomMenu;

}
