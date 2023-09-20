namespace Cefium;

/// <summary>
/// Supported certificate status code values. See net\cert\cert_status_flags.h
/// for more information. CERT_STATUS_NONE is new in CEF because we use an
/// enum while cert_status_flags.h uses a typedef and static const variables.
/// <c>cef_cert_status_t</c>
/// </summary>
/// <seealso cref="CefCertStatusExtensions"/>
[PublicAPI, Flags]
public enum CefCertStatus {

  /// <summary>
  /// <c>CERT_STATUS_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// <c>CERT_STATUS_COMMON_NAME_INVALID</c>
  /// </summary>
  CommonNameInvalid = 1 << 0,

  /// <summary>
  /// <c>CERT_STATUS_DATE_INVALID</c>
  /// </summary>
  DateInvalid = 1 << 1,

  /// <summary>
  /// <c>CERT_STATUS_AUTHORITY_INVALID</c>
  /// </summary>
  AuthorityInvalid = 1 << 2,

  /// <summary>
  /// 1 &lt;&lt; 3 is reserved for ERR_CERT_CONTAINS_ERRORS (not useful with WinHTTP).
  /// </summary>
  [Obsolete("Use CefCertStatusExtensions.IsError instead.", true)]
  StatusContainsErrors = 1 << 3,

  /// <summary>
  /// <c>CERT_STATUS_NO_REVOCATION_MECHANISM</c>
  /// </summary>
  NoRevocationMechanism = 1 << 4,

  /// <summary>
  /// <c>CERT_STATUS_UNABLE_TO_CHECK_REVOCATION</c>
  /// </summary>
  UnableToCheckRevocation = 1 << 5,

  /// <summary>
  /// <c>CERT_STATUS_REVOKED</c>
  /// </summary>
  Revoked = 1 << 6,

  /// <summary>
  /// <c>CERT_STATUS_INVALID</c>
  /// </summary>
  Invalid = 1 << 7,

  /// <summary>
  /// <c>CERT_STATUS_WEAK_SIGNATURE_ALGORITHM</c>
  /// </summary>
  WeakSignatureAlgorithm = 1 << 8,

  /// <summary>
  /// 1 &lt;&lt; 9 was used for CERT_STATUS_NOT_IN_DNS
  /// </summary>
  [Obsolete("Use CefCertStatusExtensions.IsError instead.", true)]
  StatusNotInDns = 1 << 9,

  /// <summary>
  /// <c>CERT_STATUS_NON_UNIQUE_NAME</c>
  /// </summary>
  NonUniqueName = 1 << 10,

  /// <summary>
  /// <c>CERT_STATUS_WEAK_KEY</c>
  /// </summary>
  WeakKey = 1 << 11,

  /// <summary>
  /// 1 &lt;&lt; 12 was used for CERT_STATUS_WEAK_DH_KEY
  /// </summary>
  [Obsolete("Use CefCertStatusExtensions.IsError instead.", true)]
  StatusWeakDhKey = 1 << 12,

  /// <summary>
  /// <c>CERT_STATUS_PINNED_KEY_MISSING</c>
  /// </summary>
  PinnedKeyMissing = 1 << 13,

  /// <summary>
  /// <c>CERT_STATUS_NAME_CONSTRAINT_VIOLATION</c>
  /// </summary>
  NameConstraintViolation = 1 << 14,

  /// <summary>
  /// <c>CERT_STATUS_VALIDITY_TOO_LONG</c>
  /// </summary>
  ValidityTooLong = 1 << 15,

// Bits 16 to 31 are for non-error statuses.

  /// <summary>
  /// <c>CERT_STATUS_IS_EV</c>
  /// </summary>
  IsEv = 1 << 16,

  /// <summary>
  /// <c>CERT_STATUS_REV_CHECKING_ENABLED</c>
  /// </summary>
  RevCheckingEnabled = 1 << 17,

  /// <summary>
  /// Bit 18 was CERT_STATUS_IS_DNSSEC
  /// </summary>
  [Obsolete("Use CefCertStatusExtensions.IsError instead.", true)]
  StatusIsDnssec = 1 << 18,

  /// <summary>
  /// <c>CERT_STATUS_SHA1_SIGNATURE_PRESENT</c>
  /// </summary>
  Sha1SignaturePresent = 1 << 19,

  /// <summary>
  /// <c>CERT_STATUS_CT_COMPLIANCE_FAILED</c>
  /// </summary>
  CtComplianceFailed = 1 << 20,

}
