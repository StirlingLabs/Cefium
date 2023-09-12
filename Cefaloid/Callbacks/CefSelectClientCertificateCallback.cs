namespace Cefaloid;

/// <summary>
/// Callback structure used to select a client certificate for authentication.
/// <c>cef_select_client_certificate_callback_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefSelectClientCertificateCallback : ICefRefCountedBase<CefSelectClientCertificateCallback> {

  /// <see cref="CefSelectClientCertificateCallback"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefSelectClientCertificateCallback() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Chooses the specified certificate for client certificate authentication.
  /// NULL value means that no client certificate should be used.
  /// <c>void(CEF_CALLBACK* select)(struct _cef_select_client_certificate_callback_t* self, struct _cef_x509certificate_t* cert)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefSelectClientCertificateCallback*, CefX509Certificate*, void> _Select;

}
