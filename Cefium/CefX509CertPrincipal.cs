namespace Cefium;

/// <summary>
/// Structure representing the issuer or subject field of an X.509 certificate.
/// <c>cef_x509cert_principal_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefX509CertPrincipal : ICefRefCountedBase<CefX509CertPrincipal> {

  /// <inheritdoc cref="CefX509CertPrincipal"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefX509CertPrincipal() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns a name that can be used to represent the issuer. It tries in this
  /// order: Common Name (CN), Organization Name (O) and Organizational Unit
  /// Name (OU) and returns the first non-NULL one found.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_display_name)(struct _cef_x509cert_principal_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringUserFree*> _GetDisplayName;

  /// <summary>
  /// Returns the common name.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_common_name)(struct _cef_x509cert_principal_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringUserFree*> _GetCommonName;

  /// <summary>
  /// Returns the locality name.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_locality_name)(struct _cef_x509cert_principal_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringUserFree*> _GetLocalityName;

  /// <summary>
  /// Returns the state or province name.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_state_or_province_name)(struct _cef_x509cert_principal_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringUserFree*> _GetStateOrProvinceName;

  /// <summary>
  /// Returns the country name.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_country_name)(struct _cef_x509cert_principal_t* self)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringUserFree*> _GetCountryName;

  /*
  /// <summary>
  /// Retrieve the list of street addresses.
  /// <c>void(CEF_CALLBACK* get_street_addresses)(struct _cef_x509cert_principal_t* self, cef_string_list_t addresses)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringList*> _GetStreetAddresses;
  */

  /// <summary>
  /// Retrieve the list of organization names.
  /// <c>void(CEF_CALLBACK* get_organization_names)(struct _cef_x509cert_principal_t* self, cef_string_list_t names)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringList*> _GetOrganizationNames;

  /// <summary>
  /// Retrieve the list of organization unit names.
  /// <c>void(CEF_CALLBACK* get_organization_unit_names)(struct _cef_x509cert_principal_t* self, cef_string_list_t names)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringList*> _GetOrganizationUnitNames;

  /*
  /// <summary>
  /// Retrieve the list of domain components.
  /// <c>void(CEF_CALLBACK* get_domain_components)(struct _cef_x509cert_principal_t* self, cef_string_list_t components)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509CertPrincipal*, CefStringList*> _GetDomainComponents;
  */

}
