namespace Cefaloid;

/// <summary>
/// Structure representing SSL information.
/// <c>cef_sslinfo_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSslInfo : ICefRefCountedBase<CefSslInfo> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefSslInfo() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Returns a bitmask containing any and all problems verifying the server
  /// certificate.
  /// <c>cef_cert_status_t(CEF_CALLBACK* get_cert_status)(struct _cef_sslinfo_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSslInfo*, CefCertStatus> _GetCertStatus;

  /// <summary>
  /// Returns the X.509 certificate.
  /// <c>struct _cef_x509certificate_t*(CEF_CALLBACK* get_x509certificate)(struct _cef_sslinfo_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSslInfo*, CefX509Certificate*> _GetX509certificate;

}
