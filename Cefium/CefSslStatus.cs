namespace Cefium;

/// <summary>
/// Structure representing the SSL information for a navigation entry.
/// <c>cef_sslstatus_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSslStatus : ICefRefCountedBase<CefSslStatus> {

  /// <inheritdoc cref="CefSslStatus"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefSslStatus() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns true (1) if the status is related to a secure SSL/TLS connection.
  /// <c>int(CEF_CALLBACK* is_secure_connection)(struct _cef_sslstatus_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSslStatus*, int> _IsSecureConnection;

  /// <summary>
  /// Returns a bitmask containing any and all problems verifying the server
  /// certificate.
  /// <c>cef_cert_status_t(CEF_CALLBACK* get_cert_status)(struct _cef_sslstatus_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSslStatus*, CefCertStatus> _GetCertStatus;

  /// <summary>
  /// Returns the SSL version used for the SSL connection.
  /// <c>cef_ssl_version_t(CEF_CALLBACK* get_sslversion)(struct _cef_sslstatus_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSslStatus*, CefSslVersion*> _GetSslVersion;

  /// <summary>
  /// Returns a bitmask containing the page security content status.
  /// <c>cef_ssl_content_status_t(CEF_CALLBACK* get_content_status)(struct _cef_sslstatus_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSslStatus*, CefSslContentStatus> _GetContentStatus;

  /// <summary>
  /// Returns the X.509 certificate.
  /// <c>struct _cef_x509certificate_t*(CEF_CALLBACK* get_x509certificate)(struct _cef_sslstatus_t* self)</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSslStatus*, CefX509Certificate*> _GetX509Certificate;

}
