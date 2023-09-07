namespace Cefaloid;

/// <summary>
/// Policy for how the Referrer HTTP header value will be sent during
/// navigation. If the `--no-referrers` command-line flag is specified then the
/// policy value will be ignored and the Referrer value will never be sent. Must
/// be kept synchronized with net::URLRequest::ReferrerPolicy from Chromium.
/// <c>cef_referrer_policy_t</c>
/// </summary>
[PublicAPI]
public enum CefReferrerPolicy {

  /// <summary>
  /// Clear the referrer header if the header value is HTTPS but the request
  /// destination is HTTP. This is the default behavior.
  /// <c>REFERRER_POLICY_CLEAR_REFERRER_ON_TRANSITION_FROM_SECURE_TO_INSECURE</c>
  /// </summary>
  TransitionFromSecureToInsecure,

  /// <summary>
  /// The default is <see cref="TransitionFromSecureToInsecure"/>.
  /// <c>REFERRER_POLICY_DEFAULT</c>
  /// </summary>
  Default = TransitionFromSecureToInsecure,

  /// <summary>
  /// A slight variant on CLEAR_REFERRER_ON_TRANSITION_FROM_SECURE_TO_INSECURE:
  /// If the request destination is HTTP, an HTTPS referrer will be cleared. If
  /// the request's destination is cross-origin with the referrer (but does not
  /// downgrade), the referrer's granularity will be stripped down to an origin
  /// rather than a full URL. Same-origin requests will send the full referrer.
  /// <c>REFERRER_POLICY_REDUCE_REFERRER_GRANULARITY_ON_TRANSITION_CROSS_ORIGIN</c>
  /// </summary>
  ReduceReferrerGranularityOnTransitionCrossOrigin,

  /// <summary>
  /// Strip the referrer down to an origin when the origin of the referrer is
  /// different from the destination's origin.
  /// <c>REFERRER_POLICY_ORIGIN_ONLY_ON_TRANSITION_CROSS_ORIGIN</c>
  /// </summary>
  OriginOnlyOnTransitionCrossOrigin,

  /// <summary>
  /// Never change the referrer.
  /// <c>REFERRER_POLICY_NEVER_CLEAR_REFERRER</c>
  /// </summary>
  NeverClearReferrer,

  /// <summary>
  /// Strip the referrer down to the origin regardless of the redirect location.
  /// <c>REFERRER_POLICY_ORIGIN</c>
  /// </summary>
  Origin,

  /// <summary>
  /// Clear the referrer when the request's referrer is cross-origin with the
  /// request's destination.
  /// <c>REFERRER_POLICY_CLEAR_REFERRER_ON_TRANSITION_CROSS_ORIGIN</c>
  /// </summary>
  ClearReferrerOnTransitionCrossOrigin,

  /// <summary>
  /// Strip the referrer down to the origin, but clear it entirely if the
  /// referrer value is HTTPS and the destination is HTTP.
  /// <c>REFERRER_POLICY_ORIGIN_CLEAR_ON_TRANSITION_FROM_SECURE_TO_INSECURE</c>
  /// </summary>
  ClearOnTransitionFromSecureToInsecure,

  /// <summary>
  /// Always clear the referrer regardless of the request destination.
  /// <c>REFERRER_POLICY_NO_REFERRER</c>
  /// </summary>
  NoReferrer,

  /// <summary>
  /// Always the last value in this enumeration.
  /// <c>REFERRER_POLICY_LAST_VALUE</c>
  /// </summary>
  LastValue = NoReferrer,

}
