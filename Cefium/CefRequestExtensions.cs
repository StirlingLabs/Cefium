namespace Cefium;

/// <inheritdoc cref="CefRequest"/>
[PublicAPI]
public static class CefRequestExtensions {

  /// <inheritdoc cref="CefRequest._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefRequest self)
    => self._IsReadOnly is not null && self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefRequest._GetUrl"/>
  public static unsafe CefStringUserFree* GetUrl(ref this CefRequest self)
    => self._GetUrl is not null ? self._GetUrl(self.AsPointer()) : default;

  /// <inheritdoc cref="CefRequest._SetUrl"/>
  public static unsafe bool SetUrl(ref this CefRequest self, ref CefString url) {
    if (self._SetUrl is null) return false;

    self._SetUrl(self.AsPointer(), url.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefRequest._GetMethod"/>
  public static unsafe CefStringUserFree* GetMethod(ref this CefRequest self)
    => self._GetMethod is not null ? self._GetMethod(self.AsPointer()) : default;

  /// <inheritdoc cref="CefRequest._SetMethod"/>
  public static unsafe bool SetMethod(ref this CefRequest self, ref CefString method) {
    if (self._SetMethod is null) return false;

    self._SetMethod(self.AsPointer(), method.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefRequest._GetPostData"/>
  public static unsafe CefPostData* GetPostData(ref this CefRequest self)
    => self._GetPostData is not null ? self._GetPostData(self.AsPointer()) : default;

  /// <inheritdoc cref="CefRequest._SetPostData"/>
  public static unsafe bool SetPostData(ref this CefRequest self, ref CefPostData postData) {
    if (self._SetPostData is null) return false;

    self._SetPostData(self.AsPointer(), postData.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefRequest._GetHeaderMap"/>
  public static unsafe bool GetHeaderMap(ref this CefRequest self, ref CefStringMultimap headerMap) {
    if (self._GetHeaderMap is null) return false;

    self._GetHeaderMap(self.AsPointer(), headerMap.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefRequest._SetHeaderMap"/>
  public static unsafe bool SetHeaderMap(ref this CefRequest self, ref CefStringMultimap headerMap) {
    if (self._SetHeaderMap is null) return false;

    self._SetHeaderMap(self.AsPointer(), headerMap.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefRequest._GetHeaderByName"/>
  public static unsafe CefStringUserFree* GetHeaderByName(ref this CefRequest self, ref CefString name)
    => self._GetHeaderByName is not null ? self._GetHeaderByName(self.AsPointer(), name.AsPointer()) : default;

  /// <inheritdoc cref="CefRequest._SetHeaderByName"/>
  public static unsafe bool SetHeaderByName(ref this CefRequest self, ref CefString name, ref CefString value, int overwrite) {
    if (self._SetHeaderByName is null) return false;

    self._SetHeaderByName(self.AsPointer(), name.AsPointer(), value.AsPointer(), overwrite);
    return true;
  }

  /// <inheritdoc cref="CefRequest._Set"/>
  public static unsafe bool Set(ref this CefRequest self, ref CefString url, ref CefString method, ref CefPostData postData, ref CefStringMultimap headerMap) {
    if (self._Set is null) return false;

    self._Set(self.AsPointer(), url.AsPointer(), method.AsPointer(), postData.AsPointer(), headerMap.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefRequest._GetFlags"/>
  public static unsafe CefUrlRequestFlags GetFlags(ref this CefRequest self)
    => self._GetFlags is not null ? (CefUrlRequestFlags)self._GetFlags(self.AsPointer()) : default;

  /// <inheritdoc cref="CefRequest._SetFlags"/>
  public static unsafe bool SetFlags(ref this CefRequest self, CefUrlRequestFlags flags) {
    if (self._SetFlags is null) return false;

    self._SetFlags(self.AsPointer(), (int)flags);
    return true;
  }

  /// <inheritdoc cref="CefRequest._GetFirstPartyForCookies"/>
  public static unsafe CefStringUserFree* GetFirstPartyForCookies(ref this CefRequest self)
    => self._GetFirstPartyForCookies is not null ? self._GetFirstPartyForCookies(self.AsPointer()) : default;

  /// <inheritdoc cref="CefRequest._SetFirstPartyForCookies"/>
  public static unsafe bool SetFirstPartyForCookies(ref this CefRequest self, ref CefString url) {
    if (self._SetFirstPartyForCookies is null) return false;

    self._SetFirstPartyForCookies(self.AsPointer(), url.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefRequest._GetResourceType"/>
  public static unsafe CefResourceType GetResourceType(ref this CefRequest self)
    => self._GetResourceType is not null ? self._GetResourceType(self.AsPointer()) : default;

  /// <inheritdoc cref="CefRequest._GetTransitionType"/>
  public static unsafe CefTransitionType GetTransitionType(ref this CefRequest self)
    => self._GetTransitionType is not null ? self._GetTransitionType(self.AsPointer()) : default;

  /// <inheritdoc cref="CefRequest._GetIdentifier"/>
  public static unsafe ulong GetIdentifier(ref this CefRequest self)
    => self._GetIdentifier is not null ? self._GetIdentifier(self.AsPointer()) : default;

}
