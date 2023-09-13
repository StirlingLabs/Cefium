namespace Cefaloid;

/// <summary>
/// Supported error code values.
/// <c>cef_errorcode_t</c>
/// </summary>
/// <remarks>
/// Ranges:
///     0- 99 System related errors
///   100-199 Connection related errors
///   200-299 Certificate errors
///   300-399 HTTP errors
///   400-499 Cache errors
///   500-599 ?
///   600-699 FTP errors
///   700-799 Certificate manager errors
///   800-899 DNS resolver errors
///
///
/// CEF source directs you from "cef_types.h" to
/// CEF's "include/base/internal/cef_net_error_list.h"
/// and then to Chromium's "net/base/net_error_list.h".
/// </remarks>
/// <seealso href="https://chromium.googlesource.com/chromium/src/+/main/net/base/net_error_list.h"/>
[PublicAPI]
public enum CefErrorCode {

  /// <summary>
  /// <c>ERR_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// An asynchronous IO operation is not yet complete.  This usually does not
  /// indicate a fatal error.  Typically this error will be generated as a
  /// notification to wait for some external notification that the IO operation
  /// finally completed.
  /// <c>NET_ERROR(IO_PENDING, -1)</c>
  /// </summary>
  IoPending = -1,

  /// <summary>
  /// A generic failure occurred.
  /// <c>NET_ERROR(FAILED, -2)</c>
  /// </summary>
  Failed = -2,

  /// <summary>
  /// An operation was aborted (due to user action).
  /// <c>NET_ERROR(ABORTED, -3)</c>
  /// </summary>
  Aborted = -3,

  /// <summary>
  /// An argument to the function is incorrect.
  /// <c>NET_ERROR(INVALID_ARGUMENT, -4)</c>
  /// </summary>
  InvalidArgument = -4,

  /// <summary>
  /// The handle or file descriptor is invalid.
  /// <c>NET_ERROR(INVALID_HANDLE, -5)</c>
  /// </summary>
  InvalidHandle = -5,

  /// <summary>
  /// The file or directory cannot be found.
  /// <c>NET_ERROR(FILE_NOT_FOUND, -6)</c>
  /// </summary>
  FileNotFound = -6,

  /// <summary>
  /// An operation timed out.
  /// <c>NET_ERROR(TIMED_OUT, -7)</c>
  /// </summary>
  TimedOut = -7,

  /// <summary>
  /// The file is too large.
  /// <c>NET_ERROR(FILE_TOO_BIG, -8)</c>
  /// </summary>
  FileTooBig = -8,

  /// <summary>
  /// An unexpected error.  This may be caused by a programming mistake or an
  /// invalid assumption.
  /// <c>NET_ERROR(UNEXPECTED, -9)</c>
  /// </summary>
  Unexpected = -9,

  /// <summary>
  /// Permission to access a resource, other than the network, was denied.
  /// <c>NET_ERROR(ACCESS_DENIED, -10)</c>
  /// </summary>
  AccessDenied = -10,

  /// <summary>
  /// The operation failed because of unimplemented functionality.
  /// <c>NET_ERROR(NOT_IMPLEMENTED, -11)</c>
  /// </summary>
  NotImplemented = -11,

  /// <summary>
  /// There were not enough resources to complete the operation.
  /// <c>NET_ERROR(INSUFFICIENT_RESOURCES, -12)</c>
  /// </summary>
  InsufficientResources = -12,

  /// <summary>
  /// Memory allocation failed.
  /// <c>NET_ERROR(OUT_OF_MEMORY, -13)</c>
  /// </summary>
  OutOfMemory = -13,

  /// <summary>
  /// The file upload failed because the file's modification time was different
  /// from the expectation.
  /// <c>NET_ERROR(UPLOAD_FILE_CHANGED, -14)</c>
  /// </summary>
  UploadFileChanged = -14,

  /// <summary>
  /// The socket is not connected.
  /// <c>NET_ERROR(SOCKET_NOT_CONNECTED, -15)</c>
  /// </summary>
  SocketNotConnected = -15,

  /// <summary>
  /// The file already exists.
  /// <c>NET_ERROR(FILE_EXISTS, -16)</c>
  /// </summary>
  FileExists = -16,

  /// <summary>
  /// The path or file name is too long.
  /// <c>NET_ERROR(FILE_PATH_TOO_LONG, -17)</c>
  /// </summary>
  FilePathTooLong = -17,

  /// <summary>
  /// Not enough room left on the disk.
  /// <c>NET_ERROR(FILE_NO_SPACE, -18)</c>
  /// </summary>
  FileNoSpace = -18,

  /// <summary>
  /// The file has a virus.
  /// <c>NET_ERROR(FILE_VIRUS_INFECTED, -19)</c>
  /// </summary>
  FileVirusInfected = -19,

  /// <summary>
  /// The client chose to block the request.
  /// <c>NET_ERROR(BLOCKED_BY_CLIENT, -20)</c>
  /// </summary>
  BlockedByClient = -20,

  /// <summary>
  /// The network changed.
  /// <c>NET_ERROR(NETWORK_CHANGED, -21)</c>
  /// </summary>
  NetworkChanged = -21,

  /// <summary>
  /// The request was blocked by the URL block list configured by the domain
  /// administrator.
  /// <c>NET_ERROR(BLOCKED_BY_ADMINISTRATOR, -22)</c>
  /// </summary>
  BlockedByAdministrator = -22,

  /// <summary>
  /// The socket is already connected.
  /// <c>NET_ERROR(SOCKET_IS_CONNECTED, -23)</c>
  /// </summary>
  SocketIsConnected = -23,

  /// <summary>
  /// Error -24 was removed (BLOCKED_ENROLLMENT_CHECK_PENDING)
  /// The upload failed because the upload stream needed to be re-read, due to a
  /// retry or a redirect, but the upload stream doesn't support that operation.
  /// <c>NET_ERROR(UPLOAD_STREAM_REWIND_NOT_SUPPORTED, -25)</c>
  /// </summary>
  UploadStreamRewindNotSupported = -25,

  /// <summary>
  /// The request failed because the URLRequestContext is shutting down, or has
  /// been shut down.
  /// <c>NET_ERROR(CONTEXT_SHUT_DOWN, -26)</c>
  /// </summary>
  ContextShutDown = -26,

  /// <summary>
  /// The request failed because the response was delivered along with requirements
  /// which are not met ('X-Frame-Options' and 'Content-Security-Policy' ancestor
  /// checks and 'Cross-Origin-Resource-Policy' for instance).
  /// <c>NET_ERROR(BLOCKED_BY_RESPONSE, -27)</c>
  /// </summary>
  BlockedByResponse = -27,

  /// <summary>
  /// Error -28 was removed (BLOCKED_BY_XSS_AUDITOR).
  /// The request was blocked by system policy disallowing some or all cleartext
  /// requests. Used for NetworkSecurityPolicy on Android.
  /// <c>NET_ERROR(CLEARTEXT_NOT_PERMITTED, -29)</c>
  /// </summary>
  CleartextNotPermitted = -29,

  /// <summary>
  /// The request was blocked by a Content Security Policy
  /// <c>NET_ERROR(BLOCKED_BY_CSP, -30)</c>
  /// </summary>
  BlockedByCsp = -30,

  /// <summary>
  /// The request was blocked because of no H/2 or QUIC session.
  /// <c>NET_ERROR(H2_OR_QUIC_REQUIRED, -31)</c>
  /// </summary>
  H2OrQuicRequired = -31,

  /// <summary>
  /// The request was blocked by CORB or ORB.
  /// <c>NET_ERROR(BLOCKED_BY_ORB, -32)</c>
  /// </summary>
  BlockedByOrb = -32,

  /// <summary>
  /// A connection was closed (corresponding to a TCP FIN).
  /// <c>NET_ERROR(CONNECTION_CLOSED, -100)</c>
  /// </summary>
  ConnectionClosed = -100,

  /// <summary>
  /// A connection was reset (corresponding to a TCP RST).
  /// <c>NET_ERROR(CONNECTION_RESET, -101)</c>
  /// </summary>
  ConnectionReset = -101,

  /// <summary>
  /// A connection attempt was refused.
  /// <c>NET_ERROR(CONNECTION_REFUSED, -102)</c>
  /// </summary>
  ConnectionRefused = -102,

  /// <summary>
  /// A connection timed out as a result of not receiving an ACK for data sent.
  /// This can include a FIN packet that did not get ACK'd.
  /// <c>NET_ERROR(CONNECTION_ABORTED, -103)</c>
  /// </summary>
  ConnectionAborted = -103,

  /// <summary>
  /// A connection attempt failed.
  /// <c>NET_ERROR(CONNECTION_FAILED, -104)</c>
  /// </summary>
  ConnectionFailed = -104,

  /// <summary>
  /// The host name could not be resolved.
  /// <c>NET_ERROR(NAME_NOT_RESOLVED, -105)</c>
  /// </summary>
  NameNotResolved = -105,

  /// <summary>
  /// The Internet connection has been lost.
  /// <c>NET_ERROR(INTERNET_DISCONNECTED, -106)</c>
  /// </summary>
  InternetDisconnected = -106,

  /// <summary>
  /// An SSL protocol error occurred.
  /// <c>NET_ERROR(SSL_PROTOCOL_ERROR, -107)</c>
  /// </summary>
  SslProtocolError = -107,

  /// <summary>
  /// The IP address or port number is invalid (e.g., cannot connect to the IP
  /// address 0 or the port 0).
  /// <c>NET_ERROR(ADDRESS_INVALID, -108)</c>
  /// </summary>
  AddressInvalid = -108,

  /// <summary>
  /// The IP address is unreachable.  This usually means that there is no route to
  /// the specified host or network.
  /// <c>NET_ERROR(ADDRESS_UNREACHABLE, -109)</c>
  /// </summary>
  AddressUnreachable = -109,

  /// <summary>
  /// The server requested a client certificate for SSL client authentication.
  /// <c>NET_ERROR(SSL_CLIENT_AUTH_CERT_NEEDED, -110)</c>
  /// </summary>
  SslClientAuthCertNeeded = -110,

  /// <summary>
  /// A tunnel connection through the proxy could not be established.
  /// <c>NET_ERROR(TUNNEL_CONNECTION_FAILED, -111)</c>
  /// </summary>
  TunnelConnectionFailed = -111,

  /// <summary>
  /// No SSL protocol versions are enabled.
  /// <c>NET_ERROR(NO_SSL_VERSIONS_ENABLED, -112)</c>
  /// </summary>
  NoSslVersionsEnabled = -112,

  /// <summary>
  /// The client and server don't support a common SSL protocol version or
  /// cipher suite.
  /// <c>NET_ERROR(SSL_VERSION_OR_CIPHER_MISMATCH, -113)</c>
  /// </summary>
  SslVersionOrCipherMismatch = -113,

  /// <summary>
  /// The server requested a renegotiation (rehandshake).
  /// <c>NET_ERROR(SSL_RENEGOTIATION_REQUESTED, -114)</c>
  /// </summary>
  SslRenegotiationRequested = -114,

  /// <summary>
  /// The proxy requested authentication (for tunnel establishment) with an
  /// unsupported method.
  /// <c>NET_ERROR(PROXY_AUTH_UNSUPPORTED, -115)</c>
  /// </summary>
  ProxyAuthUnsupported = -115,

  /// <summary>
  /// Error -116 was removed (CERT_ERROR_IN_SSL_RENEGOTIATION)
  /// The SSL handshake failed because of a bad or missing client certificate.
  /// <c>NET_ERROR(BAD_SSL_CLIENT_AUTH_CERT, -117)</c>
  /// </summary>
  BadSslClientAuthCert = -117,

  /// <summary>
  /// A connection attempt timed out.
  /// <c>NET_ERROR(CONNECTION_TIMED_OUT, -118)</c>
  /// </summary>
  ConnectionTimedOut = -118,

  /// <summary>
  /// There are too many pending DNS resolves, so a request in the queue was
  /// aborted.
  /// <c>NET_ERROR(HOST_RESOLVER_QUEUE_TOO_LARGE, -119)</c>
  /// </summary>
  HostResolverQueueTooLarge = -119,

  /// <summary>
  /// Failed establishing a connection to the SOCKS proxy server for a target host.
  /// <c>NET_ERROR(SOCKS_CONNECTION_FAILED, -120)</c>
  /// </summary>
  SocksConnectionFailed = -120,

  /// <summary>
  /// The SOCKS proxy server failed establishing connection to the target host
  /// because that host is unreachable.
  /// <c>NET_ERROR(SOCKS_CONNECTION_HOST_UNREACHABLE, -121)</c>
  /// </summary>
  SocksConnectionHostUnreachable = -121,

  /// <summary>
  /// The request to negotiate an alternate protocol failed.
  /// <c>NET_ERROR(ALPN_NEGOTIATION_FAILED, -122)</c>
  /// </summary>
  AlpnNegotiationFailed = -122,

  /// <summary>
  /// The peer sent an SSL no_renegotiation alert message.
  /// <c>NET_ERROR(SSL_NO_RENEGOTIATION, -123)</c>
  /// </summary>
  SslNoRenegotiation = -123,

  /// <summary>
  /// Winsock sometimes reports more data written than passed.  This is probably
  /// due to a broken LSP.
  /// <c>NET_ERROR(WINSOCK_UNEXPECTED_WRITTEN_BYTES, -124)</c>
  /// </summary>
  WinsockUnexpectedWrittenBytes = -124,

  /// <summary>
  /// An SSL peer sent us a fatal decompression_failure alert. This typically
  /// occurs when a peer selects DEFLATE compression in the mistaken belief that
  /// it supports it.
  /// <c>NET_ERROR(SSL_DECOMPRESSION_FAILURE_ALERT, -125)</c>
  /// </summary>
  SslDecompressionFailureAlert = -125,

  /// <summary>
  /// An SSL peer sent us a fatal bad_record_mac alert. This has been observed
  /// from servers with buggy DEFLATE support.
  /// <c>NET_ERROR(SSL_BAD_RECORD_MAC_ALERT, -126)</c>
  /// </summary>
  SslBadRecordMacAlert = -126,

  /// <summary>
  /// The proxy requested authentication (for tunnel establishment).
  /// <c>NET_ERROR(PROXY_AUTH_REQUESTED, -127)</c>
  /// </summary>
  ProxyAuthRequested = -127,

  /// <summary>
  /// Error -129 was removed (SSL_WEAK_SERVER_EPHEMERAL_DH_KEY).
  /// Could not create a connection to the proxy server. An error occurred
  /// either in resolving its name, or in connecting a socket to it.
  /// Note that this does NOT include failures during the actual "CONNECT" method
  /// of an HTTP proxy.
  /// <c>NET_ERROR(PROXY_CONNECTION_FAILED, -130)</c>
  /// </summary>
  ProxyConnectionFailed = -130,

  /// <summary>
  /// A mandatory proxy configuration could not be used. Currently this means
  /// that a mandatory PAC script could not be fetched, parsed or executed.
  /// <c>NET_ERROR(MANDATORY_PROXY_CONFIGURATION_FAILED, -131)</c>
  /// </summary>
  MandatoryProxyConfigurationFailed = -131,

  /// <summary>
  /// -132 was formerly ERR_ESET_ANTI_VIRUS_SSL_INTERCEPTION
  /// We've hit the max socket limit for the socket pool while preconnecting.  We
  /// don't bother trying to preconnect more sockets.
  /// <c>NET_ERROR(PRECONNECT_MAX_SOCKET_LIMIT, -133)</c>
  /// </summary>
  PreconnectMaxSocketLimit = -133,

  /// <summary>
  /// The permission to use the SSL client certificate's private key was denied.
  /// <c>NET_ERROR(SSL_CLIENT_AUTH_PRIVATE_KEY_ACCESS_DENIED, -134)</c>
  /// </summary>
  SslClientAuthPrivateKeyAccessDenied = -134,

  /// <summary>
  /// The SSL client certificate has no private key.
  /// <c>NET_ERROR(SSL_CLIENT_AUTH_CERT_NO_PRIVATE_KEY, -135)</c>
  /// </summary>
  SslClientAuthCertNoPrivateKey = -135,

  /// <summary>
  /// The certificate presented by the HTTPS Proxy was invalid.
  /// <c>NET_ERROR(PROXY_CERTIFICATE_INVALID, -136)</c>
  /// </summary>
  ProxyCertificateInvalid = -136,

  /// <summary>
  /// An error occurred when trying to do a name resolution (DNS).
  /// <c>NET_ERROR(NAME_RESOLUTION_FAILED, -137)</c>
  /// </summary>
  NameResolutionFailed = -137,

  /// <summary>
  /// Permission to access the network was denied. This is used to distinguish
  /// errors that were most likely caused by a firewall from other access denied
  /// errors. See also ERR_ACCESS_DENIED.
  /// <c>NET_ERROR(NETWORK_ACCESS_DENIED, -138)</c>
  /// </summary>
  NetworkAccessDenied = -138,

  /// <summary>
  /// The request throttler module cancelled this request to avoid DDOS.
  /// <c>NET_ERROR(TEMPORARILY_THROTTLED, -139)</c>
  /// </summary>
  TemporarilyThrottled = -139,

  /// <summary>
  /// A request to create an SSL tunnel connection through the HTTPS proxy
  /// received a 302 (temporary redirect) response.  The response body might
  /// include a description of why the request failed.
  ///
  /// TODO(https://crbug.com/928551): This is deprecated and should not be used by
  /// new code.
  /// <c>NET_ERROR(HTTPS_PROXY_TUNNEL_RESPONSE_REDIRECT, -140)</c>
  /// </summary>
  [Obsolete("Deprecated, see https://crbug.com/928551", true)]
  HttpsProxyTunnelResponseRedirect = -140,

  /// <summary>
  /// We were unable to sign the CertificateVerify data of an SSL client auth
  /// handshake with the client certificate's private key.
  ///
  /// Possible causes for this include the user implicitly or explicitly
  /// denying access to the private key, the private key may not be valid for
  /// signing, the key may be relying on a cached handle which is no longer
  /// valid, or the CSP won't allow arbitrary data to be signed.
  /// <c>NET_ERROR(SSL_CLIENT_AUTH_SIGNATURE_FAILED, -141)</c>
  /// </summary>
  SslClientAuthSignatureFailed = -141,

  /// <summary>
  /// The message was too large for the transport.  (for example a UDP message
  /// which exceeds size threshold).
  /// <c>NET_ERROR(MSG_TOO_BIG, -142)</c>
  /// </summary>
  MsgTooBig = -142,

  /// <summary>
  /// Error -143 was removed (SPDY_SESSION_ALREADY_EXISTS)
  /// Error -144 was removed (LIMIT_VIOLATION).
  /// Websocket protocol error. Indicates that we are terminating the connection
  /// due to a malformed frame or other protocol violation.
  /// <c>NET_ERROR(WS_PROTOCOL_ERROR, -145)</c>
  /// </summary>
  WsProtocolError = -145,

  /// <summary>
  /// Error -146 was removed (PROTOCOL_SWITCHED)
  /// Returned when attempting to bind an address that is already in use.
  /// <c>NET_ERROR(ADDRESS_IN_USE, -147)</c>
  /// </summary>
  AddressInUse = -147,

  /// <summary>
  /// An operation failed because the SSL handshake has not completed.
  /// <c>NET_ERROR(SSL_HANDSHAKE_NOT_COMPLETED, -148)</c>
  /// </summary>
  SslHandshakeNotCompleted = -148,

  /// <summary>
  /// SSL peer's public key is invalid.
  /// <c>NET_ERROR(SSL_BAD_PEER_PUBLIC_KEY, -149)</c>
  /// </summary>
  SslBadPeerPublicKey = -149,

  /// <summary>
  /// The certificate didn't match the built-in public key pins for the host name.
  /// The pins are set in net/http/transport_security_state.cc and require that
  /// one of a set of public keys exist on the path from the leaf to the root.
  /// <c>NET_ERROR(SSL_PINNED_KEY_NOT_IN_CERT_CHAIN, -150)</c>
  /// </summary>
  SslPinnedKeyNotInCertChain = -150,

  /// <summary>
  /// Server request for client certificate did not contain any types we support.
  /// <c>NET_ERROR(CLIENT_AUTH_CERT_TYPE_UNSUPPORTED, -151)</c>
  /// </summary>
  ClientAuthCertTypeUnsupported = -151,

  /// <summary>
  /// Error -152 was removed (ORIGIN_BOUND_CERT_GENERATION_TYPE_MISMATCH)
  /// An SSL peer sent us a fatal decrypt_error alert. This typically occurs when
  /// a peer could not correctly verify a signature (in CertificateVerify or
  /// ServerKeyExchange) or validate a Finished message.
  /// <c>NET_ERROR(SSL_DECRYPT_ERROR_ALERT, -153)</c>
  /// </summary>
  SslDecryptErrorAlert = -153,

  /// <summary>
  /// There are too many pending WebSocketJob instances, so the new job was not
  /// pushed to the queue.
  /// <c>NET_ERROR(WS_THROTTLE_QUEUE_TOO_LARGE, -154)</c>
  /// </summary>
  WsThrottleQueueTooLarge = -154,

  /// <summary>
  /// Error -155 was removed (TOO_MANY_SOCKET_STREAMS)
  /// The SSL server certificate changed in a renegotiation.
  /// <c>NET_ERROR(SSL_SERVER_CERT_CHANGED, -156)</c>
  /// </summary>
  SslServerCertChanged = -156,

  /// <summary>
  /// Error -157 was removed (SSL_INAPPROPRIATE_FALLBACK).
  /// Error -158 was removed (CT_NO_SCTS_VERIFIED_OK).
  /// The SSL server sent us a fatal unrecognized_name alert.
  /// <c>NET_ERROR(SSL_UNRECOGNIZED_NAME_ALERT, -159)</c>
  /// </summary>
  SslUnrecognizedNameAlert = -159,

  /// <summary>
  /// Failed to set the socket's receive buffer size as requested.
  /// <c>NET_ERROR(SOCKET_SET_RECEIVE_BUFFER_SIZE_ERROR, -160)</c>
  /// </summary>
  SocketSetReceiveBufferSizeError = -160,

  /// <summary>
  /// Failed to set the socket's send buffer size as requested.
  /// <c>NET_ERROR(SOCKET_SET_SEND_BUFFER_SIZE_ERROR, -161)</c>
  /// </summary>
  SocketSetSendBufferSizeError = -161,

  /// <summary>
  /// Failed to set the socket's receive buffer size as requested, despite success
  /// return code from setsockopt.
  /// <c>NET_ERROR(SOCKET_RECEIVE_BUFFER_SIZE_UNCHANGEABLE, -162)</c>
  /// </summary>
  SocketReceiveBufferSizeUnchangeable = -162,

  /// <summary>
  /// Failed to set the socket's send buffer size as requested, despite success
  /// return code from setsockopt.
  /// <c>NET_ERROR(SOCKET_SEND_BUFFER_SIZE_UNCHANGEABLE, -163)</c>
  /// </summary>
  SocketSendBufferSizeUnchangeable = -163,

  /// <summary>
  /// Failed to import a client certificate from the platform store into the SSL
  /// library.
  /// <c>NET_ERROR(SSL_CLIENT_AUTH_CERT_BAD_FORMAT, -164)</c>
  /// </summary>
  SslClientAuthCertBadFormat = -164,

  /// <summary>
  /// Error -165 was removed (SSL_FALLBACK_BEYOND_MINIMUM_VERSION).
  /// Resolving a hostname to an IP address list included the IPv4 address
  /// "127.0.53.53". This is a special IP address which ICANN has recommended to
  /// indicate there was a name collision, and alert admins to a potential
  /// problem.
  /// <c>NET_ERROR(ICANN_NAME_COLLISION, -166)</c>
  /// </summary>
  IcannNameCollision = -166,

  /// <summary>
  /// The SSL server presented a certificate which could not be decoded. This is
  /// not a certificate error code as no X509Certificate object is available. This
  /// error is fatal.
  /// <c>NET_ERROR(SSL_SERVER_CERT_BAD_FORMAT, -167)</c>
  /// </summary>
  SslServerCertBadFormat = -167,

  /// <summary>
  /// Certificate Transparency: Received a signed tree head that failed to parse.
  /// <c>NET_ERROR(CT_STH_PARSING_FAILED, -168)</c>
  /// </summary>
  CtSthParsingFailed = -168,

  /// <summary>
  /// Certificate Transparency: Received a signed tree head whose JSON parsing was
  /// OK but was missing some of the fields.
  /// <c>NET_ERROR(CT_STH_INCOMPLETE, -169)</c>
  /// </summary>
  CtSthIncomplete = -169,

  /// <summary>
  /// The attempt to reuse a connection to send proxy auth credentials failed
  /// before the AuthController was used to generate credentials. The caller should
  /// reuse the controller with a new connection. This error is only used
  /// internally by the network stack.
  /// <c>NET_ERROR(UNABLE_TO_REUSE_CONNECTION_FOR_PROXY_AUTH, -170)</c>
  /// </summary>
  UnableToReuseConnectionForProxyAuth = -170,

  /// <summary>
  /// Certificate Transparency: Failed to parse the received consistency proof.
  /// <c>NET_ERROR(CT_CONSISTENCY_PROOF_PARSING_FAILED, -171)</c>
  /// </summary>
  CtConsistencyProofParsingFailed = -171,

  /// <summary>
  /// The SSL server required an unsupported cipher suite that has since been
  /// removed. This error will temporarily be signaled on a fallback for one or two
  /// releases immediately following a cipher suite's removal, after which the
  /// fallback will be removed.
  /// <c>NET_ERROR(SSL_OBSOLETE_CIPHER, -172)</c>
  /// </summary>
  SslObsoleteCipher = -172,

  /// <summary>
  /// When a WebSocket handshake is done successfully and the connection has been
  /// upgraded, the URLRequest is cancelled with this error code.
  /// <c>NET_ERROR(WS_UPGRADE, -173)</c>
  /// </summary>
  WsUpgrade = -173,

  /// <summary>
  /// Socket ReadIfReady support is not implemented. This error should not be user
  /// visible, because the normal Read() method is used as a fallback.
  /// <c>NET_ERROR(READ_IF_READY_NOT_IMPLEMENTED, -174)</c>
  /// </summary>
  ReadIfReadyNotImplemented = -174,

  /// <summary>
  /// Error -175 was removed (SSL_VERSION_INTERFERENCE).
  /// No socket buffer space is available.
  /// <c>NET_ERROR(NO_BUFFER_SPACE, -176)</c>
  /// </summary>
  NoBufferSpace = -176,

  /// <summary>
  /// There were no common signature algorithms between our client certificate
  /// private key and the server's preferences.
  /// <c>NET_ERROR(SSL_CLIENT_AUTH_NO_COMMON_ALGORITHMS, -177)</c>
  /// </summary>
  SslClientAuthNoCommonAlgorithms = -177,

  /// <summary>
  /// TLS 1.3 early data was rejected by the server. This will be received before
  /// any data is returned from the socket. The request should be retried with
  /// early data disabled.
  /// <c>NET_ERROR(EARLY_DATA_REJECTED, -178)</c>
  /// </summary>
  EarlyDataRejected = -178,

  /// <summary>
  /// TLS 1.3 early data was offered, but the server responded with TLS 1.2 or
  /// earlier. This is an internal error code to account for a
  /// backwards-compatibility issue with early data and TLS 1.2. It will be
  /// received before any data is returned from the socket. The request should be
  /// retried with early data disabled.
  ///
  /// See https://tools.ietf.org/html/rfc8446#appendix-D.3 for details.
  /// <c>NET_ERROR(WRONG_VERSION_ON_EARLY_DATA, -179)</c>
  /// </summary>
  WrongVersionOnEarlyData = -179,

  /// <summary>
  /// TLS 1.3 was enabled, but a lower version was negotiated and the server
  /// returned a value indicating it supported TLS 1.3. This is part of a security
  /// check in TLS 1.3, but it may also indicate the user is behind a buggy
  /// TLS-terminating proxy which implemented TLS 1.2 incorrectly. (See
  /// https://crbug.com/boringssl/226.)
  /// <c>NET_ERROR(TLS13_DOWNGRADE_DETECTED, -180)</c>
  /// </summary>
  Tls13DowngradeDetected = -180,

  /// <summary>
  /// The server's certificate has a keyUsage extension incompatible with the
  /// negotiated TLS key exchange method.
  /// <c>NET_ERROR(SSL_KEY_USAGE_INCOMPATIBLE, -181)</c>
  /// </summary>
  SslKeyUsageIncompatible = -181,

  /// <summary>
  /// The ECHConfigList fetched over DNS cannot be parsed.
  /// <c>NET_ERROR(INVALID_ECH_CONFIG_LIST, -182)</c>
  /// </summary>
  InvalidEchConfigList = -182,

  /// <summary>
  /// ECH was enabled, but the server was unable to decrypt the encrypted
  /// ClientHello.
  /// <c>NET_ERROR(ECH_NOT_NEGOTIATED, -183)</c>
  /// </summary>
  EchNotNegotiated = -183,

  /// <summary>
  /// ECH was enabled, the server was unable to decrypt the encrypted ClientHello,
  /// and additionally did not present a certificate valid for the public name.
  /// <c>NET_ERROR(ECH_FALLBACK_CERTIFICATE_INVALID, -184)</c>
  /// </summary>
  EchFallbackCertificateInvalid = -184,

  /// <summary>
  /// Certificate error codes
  ///
  /// The values of certificate error codes must be consecutive.
  /// The server responded with a certificate whose common name did not match
  /// the host name.  This could mean:
  ///
  /// 1. An attacker has redirected our traffic to their server and is
  ///    presenting a certificate for which they know the private key.
  ///
  /// 2. The server is misconfigured and responding with the wrong cert.
  ///
  /// 3. The user is on a wireless network and is being redirected to the
  ///    network's login page.
  ///
  /// 4. The OS has used a DNS search suffix and the server doesn't have
  ///    a certificate for the abbreviated name in the address bar.
  ///
  /// <c>NET_ERROR(CERT_COMMON_NAME_INVALID, -200)</c>
  /// </summary>
  CertCommonNameInvalid = -200,

  /// <summary>
  /// The server responded with a certificate that, by our clock, appears to
  /// either not yet be valid or to have expired.  This could mean:
  ///
  /// 1. An attacker is presenting an old certificate for which they have
  ///    managed to obtain the private key.
  ///
  /// 2. The server is misconfigured and is not presenting a valid cert.
  ///
  /// 3. Our clock is wrong.
  ///
  /// <c>NET_ERROR(CERT_DATE_INVALID, -201)</c>
  /// </summary>
  CertDateInvalid = -201,

  /// <summary>
  /// The server responded with a certificate that is signed by an authority
  /// we don't trust.  The could mean:
  ///
  /// 1. An attacker has substituted the real certificate for a cert that
  ///    contains their public key and is signed by their cousin.
  ///
  /// 2. The server operator has a legitimate certificate from a CA we don't
  ///    know about, but should trust.
  ///
  /// 3. The server is presenting a self-signed certificate, providing no
  ///    defense against active attackers (but foiling passive attackers).
  ///
  /// <c>NET_ERROR(CERT_AUTHORITY_INVALID, -202)</c>
  /// </summary>
  CertAuthorityInvalid = -202,

  /// <summary>
  /// The server responded with a certificate that contains errors.
  /// This error is not recoverable.
  ///
  /// MSDN describes this error as follows:
  ///   "The SSL certificate contains errors."
  /// NOTE: It's unclear how this differs from ERR_CERT_INVALID. For consistency,
  /// use that code instead of this one from now on.
  ///
  /// <c>NET_ERROR(CERT_CONTAINS_ERRORS, -203)</c>
  /// </summary>
  CertContainsErrors = -203,

  /// <summary>
  /// The certificate has no mechanism for determining if it is revoked.  In
  /// effect, this certificate cannot be revoked.
  /// <c>NET_ERROR(CERT_NO_REVOCATION_MECHANISM, -204)</c>
  /// </summary>
  CertNoRevocationMechanism = -204,

  /// <summary>
  /// Revocation information for the security certificate for this site is not
  /// available.  This could mean:
  ///
  /// 1. An attacker has compromised the private key in the certificate and is
  ///    blocking our attempt to find out that the cert was revoked.
  ///
  /// 2. The certificate is unrevoked, but the revocation server is busy or
  ///    unavailable.
  ///
  /// <c>NET_ERROR(CERT_UNABLE_TO_CHECK_REVOCATION, -205)</c>
  /// </summary>
  CertUnableToCheckRevocation = -205,

  /// <summary>
  /// The server responded with a certificate has been revoked.
  /// We have the capability to ignore this error, but it is probably not the
  /// thing to do.
  /// <c>NET_ERROR(CERT_REVOKED, -206)</c>
  /// </summary>
  CertRevoked = -206,

  /// <summary>
  /// The server responded with a certificate that is invalid.
  /// This error is not recoverable.
  ///
  /// MSDN describes this error as follows:
  ///   "The SSL certificate is invalid."
  ///
  /// <c>NET_ERROR(CERT_INVALID, -207)</c>
  /// </summary>
  CertInvalid = -207,

  /// <summary>
  /// The server responded with a certificate that is signed using a weak
  /// signature algorithm.
  /// <c>NET_ERROR(CERT_WEAK_SIGNATURE_ALGORITHM, -208)</c>
  /// </summary>
  CertWeakSignatureAlgorithm = -208,

  /// <summary>
  /// -209 is available: was CERT_NOT_IN_DNS.
  /// The host name specified in the certificate is not unique.
  /// <c>NET_ERROR(CERT_NON_UNIQUE_NAME, -210)</c>
  /// </summary>
  CertNonUniqueName = -210,

  /// <summary>
  /// The server responded with a certificate that contains a weak key (e.g.
  /// a too-small RSA key).
  /// <c>NET_ERROR(CERT_WEAK_KEY, -211)</c>
  /// </summary>
  CertWeakKey = -211,

  /// <summary>
  /// The certificate claimed DNS names that are in violation of name constraints.
  /// <c>NET_ERROR(CERT_NAME_CONSTRAINT_VIOLATION, -212)</c>
  /// </summary>
  CertNameConstraintViolation = -212,

  /// <summary>
  /// The certificate's validity period is too long.
  /// <c>NET_ERROR(CERT_VALIDITY_TOO_LONG, -213)</c>
  /// </summary>
  CertValidityTooLong = -213,

  /// <summary>
  /// Certificate Transparency was required for this connection, but the server
  /// did not provide CT information that complied with the policy.
  /// <c>NET_ERROR(CERTIFICATE_TRANSPARENCY_REQUIRED, -214)</c>
  /// </summary>
  CertificateTransparencyRequired = -214,

  /// <summary>
  /// The certificate chained to a legacy Symantec root that is no longer trusted.
  /// https://g.co/chrome/symantecpkicerts
  /// <c>NET_ERROR(CERT_SYMANTEC_LEGACY, -215)</c>
  /// </summary>
  CertSymantecLegacy = -215,

  /// <summary>
  /// -216 was QUIC_CERT_ROOT_NOT_KNOWN which has been renumbered to not be in the
  /// certificate error range.
  /// The certificate is known to be used for interception by an entity other
  /// the device owner.
  /// <c>NET_ERROR(CERT_KNOWN_INTERCEPTION_BLOCKED, -217)</c>
  /// </summary>
  CertKnownInterceptionBlocked = -217,

  /// <summary>
  /// -218 was SSL_OBSOLETE_VERSION which is not longer used. TLS 1.0/1.1 instead
  /// cause SSL_VERSION_OR_CIPHER_MISMATCH now.
  /// Add new certificate error codes here.
  ///
  /// Update the value of CERT_END whenever you add a new certificate error
  /// code.
  /// The value immediately past the last certificate error code.
  /// <c>NET_ERROR(CERT_END, -219)</c>
  /// </summary>
  CertEnd = -219,

  /// <summary>
  /// The URL is invalid.
  /// <c>NET_ERROR(INVALID_URL, -300)</c>
  /// </summary>
  InvalidUrl = -300,

  /// <summary>
  /// The scheme of the URL is disallowed.
  /// <c>NET_ERROR(DISALLOWED_URL_SCHEME, -301)</c>
  /// </summary>
  DisallowedUrlScheme = -301,

  /// <summary>
  /// The scheme of the URL is unknown.
  /// <c>NET_ERROR(UNKNOWN_URL_SCHEME, -302)</c>
  /// </summary>
  UnknownUrlScheme = -302,

  /// <summary>
  /// Attempting to load an URL resulted in a redirect to an invalid URL.
  /// <c>NET_ERROR(INVALID_REDIRECT, -303)</c>
  /// </summary>
  InvalidRedirect = -303,

  /// <summary>
  /// Attempting to load an URL resulted in too many redirects.
  /// <c>NET_ERROR(TOO_MANY_REDIRECTS, -310)</c>
  /// </summary>
  TooManyRedirects = -310,

  /// <summary>
  /// Attempting to load an URL resulted in an unsafe redirect (e.g., a redirect
  /// to file:// is considered unsafe).
  /// <c>NET_ERROR(UNSAFE_REDIRECT, -311)</c>
  /// </summary>
  UnsafeRedirect = -311,

  /// <summary>
  /// Attempting to load an URL with an unsafe port number.  These are port
  /// numbers that correspond to services, which are not robust to spurious input
  /// that may be constructed as a result of an allowed web construct (e.g., HTTP
  /// looks a lot like SMTP, so form submission to port 25 is denied).
  /// <c>NET_ERROR(UNSAFE_PORT, -312)</c>
  /// </summary>
  UnsafePort = -312,

  /// <summary>
  /// The server's response was invalid.
  /// <c>NET_ERROR(INVALID_RESPONSE, -320)</c>
  /// </summary>
  InvalidResponse = -320,

  /// <summary>
  /// Error in chunked transfer encoding.
  /// <c>NET_ERROR(INVALID_CHUNKED_ENCODING, -321)</c>
  /// </summary>
  InvalidChunkedEncoding = -321,

  /// <summary>
  /// The server did not support the request method.
  /// <c>NET_ERROR(METHOD_NOT_SUPPORTED, -322)</c>
  /// </summary>
  MethodNotSupported = -322,

  /// <summary>
  /// The response was 407 (Proxy Authentication Required), yet we did not send
  /// the request to a proxy.
  /// <c>NET_ERROR(UNEXPECTED_PROXY_AUTH, -323)</c>
  /// </summary>
  UnexpectedProxyAuth = -323,

  /// <summary>
  /// The server closed the connection without sending any data.
  /// <c>NET_ERROR(EMPTY_RESPONSE, -324)</c>
  /// </summary>
  EmptyResponse = -324,

  /// <summary>
  /// The headers section of the response is too large.
  /// <c>NET_ERROR(RESPONSE_HEADERS_TOO_BIG, -325)</c>
  /// </summary>
  ResponseHeadersTooBig = -325,

  /// <summary>
  /// Error -326 was removed (PAC_STATUS_NOT_OK)
  /// The evaluation of the PAC script failed.
  /// <c>NET_ERROR(PAC_SCRIPT_FAILED, -327)</c>
  /// </summary>
  PacScriptFailed = -327,

  /// <summary>
  /// The response was 416 (Requested range not satisfiable) and the server cannot
  /// satisfy the range requested.
  /// <c>NET_ERROR(REQUEST_RANGE_NOT_SATISFIABLE, -328)</c>
  /// </summary>
  RequestRangeNotSatisfiable = -328,

  /// <summary>
  /// The identity used for authentication is invalid.
  /// <c>NET_ERROR(MALFORMED_IDENTITY, -329)</c>
  /// </summary>
  MalformedIdentity = -329,

  /// <summary>
  /// Content decoding of the response body failed.
  /// <c>NET_ERROR(CONTENT_DECODING_FAILED, -330)</c>
  /// </summary>
  ContentDecodingFailed = -330,

  /// <summary>
  /// An operation could not be completed because all network IO
  /// is suspended.
  /// <c>NET_ERROR(NETWORK_IO_SUSPENDED, -331)</c>
  /// </summary>
  NetworkIoSuspended = -331,

  /// <summary>
  /// FLIP data received without receiving a SYN_REPLY on the stream.
  /// <c>NET_ERROR(SYN_REPLY_NOT_RECEIVED, -332)</c>
  /// </summary>
  SynReplyNotReceived = -332,

  /// <summary>
  /// Converting the response to target encoding failed.
  /// <c>NET_ERROR(ENCODING_CONVERSION_FAILED, -333)</c>
  /// </summary>
  EncodingConversionFailed = -333,

  /// <summary>
  /// The server sent an FTP directory listing in a format we do not understand.
  /// <c>NET_ERROR(UNRECOGNIZED_FTP_DIRECTORY_LISTING_FORMAT, -334)</c>
  /// </summary>
  UnrecognizedFtpDirectoryListingFormat = -334,

  /// <summary>
  /// Obsolete.  Was only logged in NetLog when an HTTP/2 pushed stream expired.
  ///
  /// <c>NET_ERROR(INVALID_SPDY_STREAM, -335)</c>
  /// </summary>
  InvalidSpdyStream = -335,

  /// <summary>
  /// There are no supported proxies in the provided list.
  /// <c>NET_ERROR(NO_SUPPORTED_PROXIES, -336)</c>
  /// </summary>
  NoSupportedProxies = -336,

  /// <summary>
  /// There is an HTTP/2 protocol error.
  /// <c>NET_ERROR(HTTP2_PROTOCOL_ERROR, -337)</c>
  /// </summary>
  Http2ProtocolError = -337,

  /// <summary>
  /// Credentials could not be established during HTTP Authentication.
  /// <c>NET_ERROR(INVALID_AUTH_CREDENTIALS, -338)</c>
  /// </summary>
  InvalidAuthCredentials = -338,

  /// <summary>
  /// An HTTP Authentication scheme was tried which is not supported on this
  /// machine.
  /// <c>NET_ERROR(UNSUPPORTED_AUTH_SCHEME, -339)</c>
  /// </summary>
  UnsupportedAuthScheme = -339,

  /// <summary>
  /// Detecting the encoding of the response failed.
  /// <c>NET_ERROR(ENCODING_DETECTION_FAILED, -340)</c>
  /// </summary>
  EncodingDetectionFailed = -340,

  /// <summary>
  /// (GSSAPI) No Kerberos credentials were available during HTTP Authentication.
  /// <c>NET_ERROR(MISSING_AUTH_CREDENTIALS, -341)</c>
  /// </summary>
  MissingAuthCredentials = -341,

  /// <summary>
  /// An unexpected, but documented, SSPI or GSSAPI status code was returned.
  /// <c>NET_ERROR(UNEXPECTED_SECURITY_LIBRARY_STATUS, -342)</c>
  /// </summary>
  UnexpectedSecurityLibraryStatus = -342,

  /// <summary>
  /// The environment was not set up correctly for authentication (for
  /// example, no KDC could be found or the principal is unknown.
  /// <c>NET_ERROR(MISCONFIGURED_AUTH_ENVIRONMENT, -343)</c>
  /// </summary>
  MisconfiguredAuthEnvironment = -343,

  /// <summary>
  /// An undocumented SSPI or GSSAPI status code was returned.
  /// <c>NET_ERROR(UNDOCUMENTED_SECURITY_LIBRARY_STATUS, -344)</c>
  /// </summary>
  UndocumentedSecurityLibraryStatus = -344,

  /// <summary>
  /// The HTTP response was too big to drain.
  /// <c>NET_ERROR(RESPONSE_BODY_TOO_BIG_TO_DRAIN, -345)</c>
  /// </summary>
  ResponseBodyTooBigToDrain = -345,

  /// <summary>
  /// The HTTP response contained multiple distinct Content-Length headers.
  /// <c>NET_ERROR(RESPONSE_HEADERS_MULTIPLE_CONTENT_LENGTH, -346)</c>
  /// </summary>
  ResponseHeadersMultipleContentLength = -346,

  /// <summary>
  /// HTTP/2 headers have been received, but not all of them - status or version
  /// headers are missing, so we're expecting additional frames to complete them.
  /// <c>NET_ERROR(INCOMPLETE_HTTP2_HEADERS, -347)</c>
  /// </summary>
  IncompleteHttp2Headers = -347,

  /// <summary>
  /// No PAC URL configuration could be retrieved from DHCP. This can indicate
  /// either a failure to retrieve the DHCP configuration, or that there was no
  /// PAC URL configured in DHCP.
  /// <c>NET_ERROR(PAC_NOT_IN_DHCP, -348)</c>
  /// </summary>
  PacNotInDhcp = -348,

  /// <summary>
  /// The HTTP response contained multiple Content-Disposition headers.
  /// <c>NET_ERROR(RESPONSE_HEADERS_MULTIPLE_CONTENT_DISPOSITION, -349)</c>
  /// </summary>
  ResponseHeadersMultipleContentDisposition = -349,

  /// <summary>
  /// The HTTP response contained multiple Location headers.
  /// <c>NET_ERROR(RESPONSE_HEADERS_MULTIPLE_LOCATION, -350)</c>
  /// </summary>
  ResponseHeadersMultipleLocation = -350,

  /// <summary>
  /// HTTP/2 server refused the request without processing, and sent either a
  /// GOAWAY frame with error code NO_ERROR and Last-Stream-ID lower than the
  /// stream id corresponding to the request indicating that this request has not
  /// been processed yet, or a RST_STREAM frame with error code REFUSED_STREAM.
  /// Client MAY retry (on a different connection).  See RFC7540 Section 8.1.4.
  /// <c>NET_ERROR(HTTP2_SERVER_REFUSED_STREAM, -351)</c>
  /// </summary>
  Http2ServerRefusedStream = -351,

  /// <summary>
  /// HTTP/2 server didn't respond to the PING message.
  /// <c>NET_ERROR(HTTP2_PING_FAILED, -352)</c>
  /// </summary>
  Http2PingFailed = -352,

  /// <summary>
  /// Obsolete.  Kept here to avoid reuse, as the old error can still appear on
  /// histograms.
  ///
  /// <c>NET_ERROR(PIPELINE_EVICTION, -353)</c>
  /// </summary>
  PipelineEviction = -353,

  /// <summary>
  /// The HTTP response body transferred fewer bytes than were advertised by the
  /// Content-Length header when the connection is closed.
  /// <c>NET_ERROR(CONTENT_LENGTH_MISMATCH, -354)</c>
  /// </summary>
  ContentLengthMismatch = -354,

  /// <summary>
  /// The HTTP response body is transferred with Chunked-Encoding, but the
  /// terminating zero-length chunk was never sent when the connection is closed.
  /// <c>NET_ERROR(INCOMPLETE_CHUNKED_ENCODING, -355)</c>
  /// </summary>
  IncompleteChunkedEncoding = -355,

  /// <summary>
  /// There is a QUIC protocol error.
  /// <c>NET_ERROR(QUIC_PROTOCOL_ERROR, -356)</c>
  /// </summary>
  QuicProtocolError = -356,

  /// <summary>
  /// The HTTP headers were truncated by an EOF.
  /// <c>NET_ERROR(RESPONSE_HEADERS_TRUNCATED, -357)</c>
  /// </summary>
  ResponseHeadersTruncated = -357,

  /// <summary>
  /// The QUIC crypto handshake failed.  This means that the server was unable
  /// to read any requests sent, so they may be resent.
  /// <c>NET_ERROR(QUIC_HANDSHAKE_FAILED, -358)</c>
  /// </summary>
  QuicHandshakeFailed = -358,

  /// <summary>
  /// Obsolete.  Kept here to avoid reuse, as the old error can still appear on
  /// histograms.
  ///
  /// <c>NET_ERROR(REQUEST_FOR_SECURE_RESOURCE_OVER_INSECURE_QUIC, -359)</c>
  /// </summary>
  RequestForSecureResourceOverInsecureQuic = -359,

  /// <summary>
  /// Transport security is inadequate for the HTTP/2 version.
  /// <c>NET_ERROR(HTTP2_INADEQUATE_TRANSPORT_SECURITY, -360)</c>
  /// </summary>
  Http2InadequateTransportSecurity = -360,

  /// <summary>
  /// The peer violated HTTP/2 flow control.
  /// <c>NET_ERROR(HTTP2_FLOW_CONTROL_ERROR, -361)</c>
  /// </summary>
  Http2FlowControlError = -361,

  /// <summary>
  /// The peer sent an improperly sized HTTP/2 frame.
  /// <c>NET_ERROR(HTTP2_FRAME_SIZE_ERROR, -362)</c>
  /// </summary>
  Http2FrameSizeError = -362,

  /// <summary>
  /// Decoding or encoding of compressed HTTP/2 headers failed.
  /// <c>NET_ERROR(HTTP2_COMPRESSION_ERROR, -363)</c>
  /// </summary>
  Http2CompressionError = -363,

  /// <summary>
  /// Proxy Auth Requested without a valid Client Socket Handle.
  /// <c>NET_ERROR(PROXY_AUTH_REQUESTED_WITH_NO_CONNECTION, -364)</c>
  /// </summary>
  ProxyAuthRequestedWithNoConnection = -364,

  /// <summary>
  /// HTTP_1_1_REQUIRED error code received on HTTP/2 session.
  /// <c>NET_ERROR(HTTP_1_1_REQUIRED, -365)</c>
  /// </summary>
  Http11Required = -365,

  /// <summary>
  /// HTTP_1_1_REQUIRED error code received on HTTP/2 session to proxy.
  /// <c>NET_ERROR(PROXY_HTTP_1_1_REQUIRED, -366)</c>
  /// </summary>
  ProxyHttp11Required = -366,

  /// <summary>
  /// The PAC script terminated fatally and must be reloaded.
  /// <c>NET_ERROR(PAC_SCRIPT_TERMINATED, -367)</c>
  /// </summary>
  PacScriptTerminated = -367,

  /// <summary>
  /// Obsolete. Kept here to avoid reuse.
  /// Request is throttled because of a Backoff header.
  /// See: crbug.com/486891.
  ///
  /// <c>NET_ERROR(TEMPORARY_BACKOFF, -369)</c>
  /// </summary>
  TemporaryBackoff = -369,

  /// <summary>
  /// The server was expected to return an HTTP/1.x response, but did not. Rather
  /// than treat it as HTTP/0.9, this error is returned.
  /// <c>NET_ERROR(INVALID_HTTP_RESPONSE, -370)</c>
  /// </summary>
  InvalidHttpResponse = -370,

  /// <summary>
  /// Initializing content decoding failed.
  /// <c>NET_ERROR(CONTENT_DECODING_INIT_FAILED, -371)</c>
  /// </summary>
  ContentDecodingInitFailed = -371,

  /// <summary>
  /// Received HTTP/2 RST_STREAM frame with NO_ERROR error code.  This error should
  /// be handled internally by HTTP/2 code, and should not make it above the
  /// SpdyStream layer.
  /// <c>NET_ERROR(HTTP2_RST_STREAM_NO_ERROR_RECEIVED, -372)</c>
  /// </summary>
  Http2RstStreamNoErrorReceived = -372,

  /// <summary>
  /// The pushed stream claimed by the request is no longer available.
  /// <c>NET_ERROR(HTTP2_PUSHED_STREAM_NOT_AVAILABLE, -373)</c>
  /// </summary>
  Http2PushedStreamNotAvailable = -373,

  /// <summary>
  /// A pushed stream was claimed and later reset by the server. When this happens,
  /// the request should be retried.
  /// <c>NET_ERROR(HTTP2_CLAIMED_PUSHED_STREAM_RESET_BY_SERVER, -374)</c>
  /// </summary>
  Http2ClaimedPushedStreamResetByServer = -374,

  /// <summary>
  /// An HTTP transaction was retried too many times due for authentication or
  /// invalid certificates. This may be due to a bug in the net stack that would
  /// otherwise infinite loop, or if the server or proxy continually requests fresh
  /// credentials or presents a fresh invalid certificate.
  /// <c>NET_ERROR(TOO_MANY_RETRIES, -375)</c>
  /// </summary>
  TooManyRetries = -375,

  /// <summary>
  /// Received an HTTP/2 frame on a closed stream.
  /// <c>NET_ERROR(HTTP2_STREAM_CLOSED, -376)</c>
  /// </summary>
  Http2StreamClosed = -376,

  /// <summary>
  /// Client is refusing an HTTP/2 stream.
  /// <c>NET_ERROR(HTTP2_CLIENT_REFUSED_STREAM, -377)</c>
  /// </summary>
  Http2ClientRefusedStream = -377,

  /// <summary>
  /// A pushed HTTP/2 stream was claimed by a request based on matching URL and
  /// request headers, but the pushed response headers do not match the request.
  /// <c>NET_ERROR(HTTP2_PUSHED_RESPONSE_DOES_NOT_MATCH, -378)</c>
  /// </summary>
  Http2PushedResponseDoesNotMatch = -378,

  /// <summary>
  /// The server returned a non-2xx HTTP response code.
  ///
  /// Not that this error is only used by certain APIs that interpret the HTTP
  /// response itself. URLRequest for instance just passes most non-2xx
  /// response back as success.
  /// <c>NET_ERROR(HTTP_RESPONSE_CODE_FAILURE, -379)</c>
  /// </summary>
  HttpResponseCodeFailure = -379,

  /// <summary>
  /// The certificate presented on a QUIC connection does not chain to a known root
  /// and the origin connected to is not on a list of domains where unknown roots
  /// are allowed.
  /// <c>NET_ERROR(QUIC_CERT_ROOT_NOT_KNOWN, -380)</c>
  /// </summary>
  QuicCertRootNotKnown = -380,

  /// <summary>
  /// A GOAWAY frame has been received indicating that the request has not been
  /// processed and is therefore safe to retry on a different connection.
  /// <c>NET_ERROR(QUIC_GOAWAY_REQUEST_CAN_BE_RETRIED, -381)</c>
  /// </summary>
  QuicGoawayRequestCanBeRetried = -381,

  /// <summary>
  /// The ACCEPT_CH restart has been triggered too many times
  /// <c>NET_ERROR(TOO_MANY_ACCEPT_CH_RESTARTS, -382)</c>
  /// </summary>
  TooManyAcceptChRestarts = -382,

  /// <summary>
  /// The IP address space of the remote endpoint differed from the previous
  /// observed value during the same request. Any cache entry for the affected
  /// request should be invalidated.
  /// <c>NET_ERROR(INCONSISTENT_IP_ADDRESS_SPACE, -383)</c>
  /// </summary>
  InconsistentIpAddressSpace = -383,

  /// <summary>
  /// The IP address space of the cached remote endpoint is blocked by private
  /// network access check.
  /// <c>NET_ERROR(CACHED_IP_ADDRESS_SPACE_BLOCKED_BY_PRIVATE_NETWORK_ACCESS_POLICY,-384)</c>
  /// </summary>
  CachedIpAddressSpaceBlockedByPrivateNetworkAccessPolicy = -384,

  /// <summary>
  /// The cache does not have the requested entry.
  /// <c>NET_ERROR(CACHE_MISS, -400)</c>
  /// </summary>
  CacheMiss = -400,

  /// <summary>
  /// Unable to read from the disk cache.
  /// <c>NET_ERROR(CACHE_READ_FAILURE, -401)</c>
  /// </summary>
  CacheReadFailure = -401,

  /// <summary>
  /// Unable to write to the disk cache.
  /// <c>NET_ERROR(CACHE_WRITE_FAILURE, -402)</c>
  /// </summary>
  CacheWriteFailure = -402,

  /// <summary>
  /// The operation is not supported for this entry.
  /// <c>NET_ERROR(CACHE_OPERATION_NOT_SUPPORTED, -403)</c>
  /// </summary>
  CacheOperationNotSupported = -403,

  /// <summary>
  /// The disk cache is unable to open this entry.
  /// <c>NET_ERROR(CACHE_OPEN_FAILURE, -404)</c>
  /// </summary>
  CacheOpenFailure = -404,

  /// <summary>
  /// The disk cache is unable to create this entry.
  /// <c>NET_ERROR(CACHE_CREATE_FAILURE, -405)</c>
  /// </summary>
  CacheCreateFailure = -405,

  /// <summary>
  /// Multiple transactions are racing to create disk cache entries. This is an
  /// internal error returned from the HttpCache to the HttpCacheTransaction that
  /// tells the transaction to restart the entry-creation logic because the state
  /// of the cache has changed.
  /// <c>NET_ERROR(CACHE_RACE, -406)</c>
  /// </summary>
  CacheRace = -406,

  /// <summary>
  /// The cache was unable to read a checksum record on an entry. This can be
  /// returned from attempts to read from the cache. It is an internal error,
  /// returned by the SimpleCache backend, but not by any URLRequest methods
  /// or members.
  /// <c>NET_ERROR(CACHE_CHECKSUM_READ_FAILURE, -407)</c>
  /// </summary>
  CacheChecksumReadFailure = -407,

  /// <summary>
  /// The cache found an entry with an invalid checksum. This can be returned from
  /// attempts to read from the cache. It is an internal error, returned by the
  /// SimpleCache backend, but not by any URLRequest methods or members.
  /// <c>NET_ERROR(CACHE_CHECKSUM_MISMATCH, -408)</c>
  /// </summary>
  CacheChecksumMismatch = -408,

  /// <summary>
  /// Internal error code for the HTTP cache. The cache lock timeout has fired.
  /// <c>NET_ERROR(CACHE_LOCK_TIMEOUT, -409)</c>
  /// </summary>
  CacheLockTimeout = -409,

  /// <summary>
  /// Received a challenge after the transaction has read some data, and the
  /// credentials aren't available.  There isn't a way to get them at that point.
  /// <c>NET_ERROR(CACHE_AUTH_FAILURE_AFTER_READ, -410)</c>
  /// </summary>
  CacheAuthFailureAfterRead = -410,

  /// <summary>
  /// Internal not-quite error code for the HTTP cache. In-memory hints suggest
  /// that the cache entry would not have been usable with the transaction's
  /// current configuration (e.g. load flags, mode, etc.)
  /// <c>NET_ERROR(CACHE_ENTRY_NOT_SUITABLE, -411)</c>
  /// </summary>
  CacheEntryNotSuitable = -411,

  /// <summary>
  /// The disk cache is unable to doom this entry.
  /// <c>NET_ERROR(CACHE_DOOM_FAILURE, -412)</c>
  /// </summary>
  CacheDoomFailure = -412,

  /// <summary>
  /// The disk cache is unable to open or create this entry.
  /// <c>NET_ERROR(CACHE_OPEN_OR_CREATE_FAILURE, -413)</c>
  /// </summary>
  CacheOpenOrCreateFailure = -413,

  /// <summary>
  /// The server's response was insecure (e.g. there was a cert error).
  /// <c>NET_ERROR(INSECURE_RESPONSE, -501)</c>
  /// </summary>
  InsecureResponse = -501,

  /// <summary>
  /// An attempt to import a client certificate failed, as the user's key
  /// database lacked a corresponding private key.
  /// <c>NET_ERROR(NO_PRIVATE_KEY_FOR_CERT, -502)</c>
  /// </summary>
  NoPrivateKeyForCert = -502,

  /// <summary>
  /// An error adding a certificate to the OS certificate database.
  /// <c>NET_ERROR(ADD_USER_CERT_FAILED, -503)</c>
  /// </summary>
  AddUserCertFailed = -503,

  /// <summary>
  /// An error occurred while handling a signed exchange.
  /// <c>NET_ERROR(INVALID_SIGNED_EXCHANGE, -504)</c>
  /// </summary>
  InvalidSignedExchange = -504,

  /// <summary>
  /// An error occurred while handling a Web Bundle source.
  /// <c>NET_ERROR(INVALID_WEB_BUNDLE, -505)</c>
  /// </summary>
  InvalidWebBundle = -505,

  /// <summary>
  /// A Trust Tokens protocol operation-executing request failed for one of a
  /// number of reasons (precondition failure, internal error, bad response).
  /// <c>NET_ERROR(TRUST_TOKEN_OPERATION_FAILED, -506)</c>
  /// </summary>
  TrustTokenOperationFailed = -506,

  /// <summary>
  /// When handling a Trust Tokens protocol operation-executing request, the system
  /// was able to execute the request's Trust Tokens operation without sending the
  /// request to its destination: for instance, the results could have been present
  /// in a local cache (for redemption) or the operation could have been diverted
  /// to a local provider (for "platform-provided" issuance).
  /// <c>NET_ERROR(TRUST_TOKEN_OPERATION_SUCCESS_WITHOUT_SENDING_REQUEST, -507)</c>
  /// </summary>
  TrustTokenOperationSuccessWithoutSendingRequest = -507,

  /// <summary>
  /// *** Code -600 is reserved (was FTP_PASV_COMMAND_FAILED). ***
  /// A generic error for failed FTP control connection command.
  /// If possible, please use or add a more specific error code.
  /// <c>NET_ERROR(FTP_FAILED, -601)</c>
  /// </summary>
  FtpFailed = -601,

  /// <summary>
  /// The server cannot fulfill the request at this point. This is a temporary
  /// error.
  /// FTP response code 421.
  /// <c>NET_ERROR(FTP_SERVICE_UNAVAILABLE, -602)</c>
  /// </summary>
  FtpServiceUnavailable = -602,

  /// <summary>
  /// The server has aborted the transfer.
  /// FTP response code 426.
  /// <c>NET_ERROR(FTP_TRANSFER_ABORTED, -603)</c>
  /// </summary>
  FtpTransferAborted = -603,

  /// <summary>
  /// The file is busy, or some other temporary error condition on opening
  /// the file.
  /// FTP response code 450.
  /// <c>NET_ERROR(FTP_FILE_BUSY, -604)</c>
  /// </summary>
  FtpFileBusy = -604,

  /// <summary>
  /// Server rejected our command because of syntax errors.
  /// FTP response codes 500, 501.
  /// <c>NET_ERROR(FTP_SYNTAX_ERROR, -605)</c>
  /// </summary>
  FtpSyntaxError = -605,

  /// <summary>
  /// Server does not support the command we issued.
  /// FTP response codes 502, 504.
  /// <c>NET_ERROR(FTP_COMMAND_NOT_SUPPORTED, -606)</c>
  /// </summary>
  FtpCommandNotSupported = -606,

  /// <summary>
  /// Server rejected our command because we didn't issue the commands in right
  /// order.
  /// FTP response code 503.
  /// <c>NET_ERROR(FTP_BAD_COMMAND_SEQUENCE, -607)</c>
  /// </summary>
  FtpBadCommandSequence = -607,

  /// <summary>
  /// PKCS #12 import failed due to incorrect password.
  /// <c>NET_ERROR(PKCS12_IMPORT_BAD_PASSWORD, -701)</c>
  /// </summary>
  Pkcs12ImportBadPassword = -701,

  /// <summary>
  /// PKCS #12 import failed due to other error.
  /// <c>NET_ERROR(PKCS12_IMPORT_FAILED, -702)</c>
  /// </summary>
  Pkcs12ImportFailed = -702,

  /// <summary>
  /// CA import failed - not a CA cert.
  /// <c>NET_ERROR(IMPORT_CA_CERT_NOT_CA, -703)</c>
  /// </summary>
  ImportCaCertNotCa = -703,

  /// <summary>
  /// Import failed - certificate already exists in database.
  /// Note it's a little weird this is an error but reimporting a PKCS12 is ok
  /// (no-op).  That's how Mozilla does it, though.
  /// <c>NET_ERROR(IMPORT_CERT_ALREADY_EXISTS, -704)</c>
  /// </summary>
  ImportCertAlreadyExists = -704,

  /// <summary>
  /// CA import failed due to some other error.
  /// <c>NET_ERROR(IMPORT_CA_CERT_FAILED, -705)</c>
  /// </summary>
  ImportCaCertFailed = -705,

  /// <summary>
  /// Server certificate import failed due to some internal error.
  /// <c>NET_ERROR(IMPORT_SERVER_CERT_FAILED, -706)</c>
  /// </summary>
  ImportServerCertFailed = -706,

  /// <summary>
  /// PKCS #12 import failed due to invalid MAC.
  /// <c>NET_ERROR(PKCS12_IMPORT_INVALID_MAC, -707)</c>
  /// </summary>
  Pkcs12ImportInvalidMac = -707,

  /// <summary>
  /// PKCS #12 import failed due to invalid/corrupt file.
  /// <c>NET_ERROR(PKCS12_IMPORT_INVALID_FILE, -708)</c>
  /// </summary>
  Pkcs12ImportInvalidFile = -708,

  /// <summary>
  /// PKCS #12 import failed due to unsupported features.
  /// <c>NET_ERROR(PKCS12_IMPORT_UNSUPPORTED, -709)</c>
  /// </summary>
  Pkcs12ImportUnsupported = -709,

  /// <summary>
  /// Key generation failed.
  /// <c>NET_ERROR(KEY_GENERATION_FAILED, -710)</c>
  /// </summary>
  KeyGenerationFailed = -710,

  /// <summary>
  /// Error -711 was removed (ORIGIN_BOUND_CERT_GENERATION_FAILED)
  /// Failure to export private key.
  /// <c>NET_ERROR(PRIVATE_KEY_EXPORT_FAILED, -712)</c>
  /// </summary>
  PrivateKeyExportFailed = -712,

  /// <summary>
  /// Self-signed certificate generation failed.
  /// <c>NET_ERROR(SELF_SIGNED_CERT_GENERATION_FAILED, -713)</c>
  /// </summary>
  SelfSignedCertGenerationFailed = -713,

  /// <summary>
  /// The certificate database changed in some way.
  /// <c>NET_ERROR(CERT_DATABASE_CHANGED, -714)</c>
  /// </summary>
  CertDatabaseChanged = -714,

  /// <summary>
  /// The certificate verifier configuration changed in some way.
  /// <c>NET_ERROR(CERT_VERIFIER_CHANGED, -716)</c>
  /// </summary>
  CertVerifierChanged = -714,

  /// <summary>
  /// Error -715 was removed (CHANNEL_ID_IMPORT_FAILED)
  /// DNS error codes.
  /// DNS resolver received a malformed response.
  /// <c>NET_ERROR(DNS_MALFORMED_RESPONSE, -800)</c>
  /// </summary>
  DnsMalformedResponse = -800,

  /// <summary>
  /// DNS server requires TCP
  /// <c>NET_ERROR(DNS_SERVER_REQUIRES_TCP, -801)</c>
  /// </summary>
  DnsServerRequiresTcp = -801,

  /// <summary>
  /// DNS server failed.  This error is returned for all of the following
  /// error conditions:
  /// 1 - Format error - The name server was unable to interpret the query.
  /// 2 - Server failure - The name server was unable to process this query
  ///     due to a problem with the name server.
  /// 4 - Not Implemented - The name server does not support the requested
  ///     kind of query.
  /// 5 - Refused - The name server refuses to perform the specified
  ///     operation for policy reasons.
  /// <c>NET_ERROR(DNS_SERVER_FAILED, -802)</c>
  /// </summary>
  DnsServerFailed = -802,

  /// <summary>
  /// DNS transaction timed out.
  /// <c>NET_ERROR(DNS_TIMED_OUT, -803)</c>
  /// </summary>
  DnsTimedOut = -803,

  /// <summary>
  /// The entry was not found in cache or other local sources, for lookups where
  /// only local sources were queried.
  /// <c>NET_ERROR(DNS_CACHE_MISS, -804)</c>
  /// </summary>
  /// <remarks>
  /// TODO(ericorth): Consider renaming to DNS_LOCAL_MISS or something like that as the cache is not necessarily queried either.
  /// </remarks>
  DnsCacheMiss = -804,

  /// <summary>
  /// Suffix search list rules prevent resolution of the given host name.
  /// <c>NET_ERROR(DNS_SEARCH_EMPTY, -805)</c>
  /// </summary>
  DnsSearchEmpty = -805,

  /// <summary>
  /// Failed to sort addresses according to RFC3484.
  /// <c>NET_ERROR(DNS_SORT_ERROR, -806)</c>
  /// </summary>
  DnsSortError = -806,

  /// <summary>
  /// Error -807 was removed (DNS_HTTP_FAILED)
  /// Failed to resolve the hostname of a DNS-over-HTTPS server.
  /// <c>NET_ERROR(DNS_SECURE_RESOLVER_HOSTNAME_RESOLUTION_FAILED, -808)</c>
  /// </summary>
  DnsSecureResolverHostnameResolutionFailed = -808,

  /// <summary>
  /// DNS identified the request as disallowed for insecure connection (http/ws).
  /// Error should be handled as if an HTTP redirect was received to redirect to
  /// https or wss.
  /// <c>NET_ERROR(DNS_NAME_HTTPS_ONLY, -809)</c>
  /// </summary>
  DnsNameHttpsOnly = -809,

  /// <summary>
  /// All DNS requests associated with this job have been cancelled.
  /// <c>NET_ERROR(DNS_REQUEST_CANCELLED, -810)</c>
  /// </summary>
  DnsRequestCancelled = -810,

  /// <summary>
  /// The hostname resolution of HTTPS record was expected to be resolved with
  /// alpn values of supported protocols, but did not.
  /// <c>NET_ERROR(DNS_NO_MATCHING_SUPPORTED_ALPN, -811)</c>
  /// </summary>
  DnsNoMatchingSupportedAlpn = -811

}
