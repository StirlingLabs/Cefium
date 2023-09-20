namespace Cefium;

/// <summary>
/// Structure representing a X.509 certificate.
/// <c>cef_x509certificate_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefX509Certificate : ICefRefCountedBase<CefX509Certificate> {

  /// <inheritdoc cref="CefX509Certificate"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefX509Certificate() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns the subject of the X.509 certificate. For HTTPS server
  /// certificates this represents the web server.  The common name of the
  /// subject should match the host name of the web server.
  /// <c>struct _cef_x509cert_principal_t*(CEF_CALLBACK* get_subject)(struct _cef_x509certificate_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, CefX509CertPrincipal*> _GetSubject;

  /// <summary>
  /// Returns the issuer of the X.509 certificate.
  /// <c>struct _cef_x509cert_principal_t*(CEF_CALLBACK* get_issuer)(struct _cef_x509certificate_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, CefX509CertPrincipal*> _GetIssuer;

  /// <summary>
  /// Returns the DER encoded serial number for the X.509 certificate. The value
  /// possibly includes a leading 00 byte.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_serial_number)(struct _cef_x509certificate_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, CefBinaryValue*> _GetSerialNumber;

  /// <summary>
  /// Returns the date before which the X.509 certificate is invalid.
  /// CefBaseTime.GetTimeT() will return 0 if no date was specified.
  /// <c>cef_basetime_t(CEF_CALLBACK* get_valid_start)(struct _cef_x509certificate_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, CefBaseTime> _GetValidStart;

  /// <summary>
  /// Returns the date after which the X.509 certificate is invalid.
  /// CefBaseTime.GetTimeT() will return 0 if no date was specified.
  /// <c>cef_basetime_t(CEF_CALLBACK* get_valid_expiry)(struct _cef_x509certificate_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, CefBaseTime> _GetValidExpiry;

  /// <summary>
  /// Returns the DER encoded data for the X.509 certificate.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_derencoded)(struct _cef_x509certificate_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, CefBinaryValue*> _GetDerEncoded;

  /// <summary>
  /// Returns the PEM encoded data for the X.509 certificate.
  /// <c>struct _cef_binary_value_t*(CEF_CALLBACK* get_pemencoded)(struct _cef_x509certificate_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, CefBinaryValue*> _GetPemEncoded;

  /// <summary>
  /// Returns the number of certificates in the issuer chain. If 0, the
  /// certificate is self-signed.
  /// <c>size_t(CEF_CALLBACK* get_issuer_chain_size)(struct _cef_x509certificate_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, nuint> _GetIssuerChainSize;

  /// <summary>
  /// Returns the DER encoded data for the certificate issuer chain. If we
  /// failed to encode a certificate in the chain it is still present in the
  /// array but is an NULL string.
  /// <c>void(CEF_CALLBACK* get_derencoded_issuer_chain)(struct _cef_x509certificate_t* self, size_t* chainCount, struct _cef_binary_value_t** chain)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, nuint, CefBinaryValue**, void> _GetDerEncodedIssuerChain;

  /// <summary>
  /// Returns the PEM encoded data for the certificate issuer chain. If we
  /// failed to encode a certificate in the chain it is still present in the
  /// array but is an NULL string.
  /// <c>void(CEF_CALLBACK* get_pemencoded_issuer_chain)(struct _cef_x509certificate_t* self, size_t* chainCount, struct _cef_binary_value_t** chain)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefX509Certificate*, nuint, CefBinaryValue**, void> _GetPemEncodedIssuerChain;

}
