namespace Cefaloid;

/// <summary>
/// Return values for CefResponseFilter::Filter().
/// <c>cef_response_filter_status_t</c>
/// </summary>
public enum CefResponseFilterStatus {

  /// <summary>
  /// Some or all of the pre-filter data was read successfully but more data is
  /// needed in order to continue filtering (filtered output is pending).
  /// <c>RESPONSE_FILTER_NEED_MORE_DATA</c>
  /// </summary>
  NeedMoreData,

  /// <summary>
  /// Some or all of the pre-filter data was read successfully and all available
  /// filtered output has been written.
  /// <c>RESPONSE_FILTER_DONE</c>
  /// </summary>
  Done,

  /// <summary>
  /// An error occurred during filtering.
  /// <c>RESPONSE_FILTER_ERROR</c>
  /// </summary>
  Error

}