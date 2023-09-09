namespace Cefaloid;

/// <summary>
/// Supported SSL version values. See net/ssl/ssl_connection_status_flags.h
/// for more information.
/// <c>cef_ssl_version_t</c>
/// </summary>
[PublicAPI]
public enum CefSslVersion {

  /// <summary>
  /// <c>SSL_CONNECTION_VERSION_UNKNOWN</c>
  /// </summary>
  Unknown = 0, // Unknown SSL version.

  /// <summary>
  /// <c>SSL_CONNECTION_VERSION_SSL2</c>
  /// </summary>
  Ssl2 = 1,

  /// <summary>
  /// <c>SSL_CONNECTION_VERSION_SSL3</c>
  /// </summary>
  Ssl3 = 2,

  /// <summary>
  /// <c>SSL_CONNECTION_VERSION_TLS1</c>
  /// </summary>
  Tls1 = 3,

  /// <summary>
  /// <c>SSL_CONNECTION_VERSION_TLS1_1</c>
  /// </summary>
  Tls11 = 4,

  /// <summary>
  /// <c>SSL_CONNECTION_VERSION_TLS1_2</c>
  /// </summary>
  Tls12 = 5,

  /// <summary>
  /// <c>SSL_CONNECTION_VERSION_TLS1_3</c>
  /// </summary>
  Tls13 = 6,

  /// <summary>
  /// <c>SSL_CONNECTION_VERSION_QUIC</c>
  /// </summary>
  Quic = 7,

}
