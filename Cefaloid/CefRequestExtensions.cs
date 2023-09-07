namespace Cefaloid;

/// <inheritdoc cref="CefRequest"/>
[PublicAPI]
public static class CefRequestExtensions {

  /// <inheritdoc cref="CefRequest._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefRequest self)
    => self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefRequest._GetUrl"/>
  public static unsafe CefStringUserFree* GetUrl(ref this CefRequest self)
    => self._GetUrl(self.AsPointer());

  /// <inheritdoc cref="CefRequest._SetUrl"/>
  public static unsafe void SetUrl(ref this CefRequest self, ref CefString url)
    => self._SetUrl(self.AsPointer(), url.AsPointer());

  /// <inheritdoc cref="CefRequest._GetMethod"/>
  public static unsafe CefStringUserFree* GetMethod(ref this CefRequest self)
    => self._GetMethod(self.AsPointer());

  /// <inheritdoc cref="CefRequest._SetMethod"/>
  public static unsafe void SetMethod(ref this CefRequest self, ref CefString method)
    => self._SetMethod(self.AsPointer(), method.AsPointer());

  /// <inheritdoc cref="CefRequest._GetPostData"/>
  public static unsafe CefPostData* GetPostData(ref this CefRequest self)
    => self._GetPostData(self.AsPointer());

  /// <inheritdoc cref="CefRequest._SetPostData"/>
  public static unsafe void SetPostData(ref this CefRequest self, ref CefPostData postData)
    => self._SetPostData(self.AsPointer(), postData.AsPointer());

  /// <inheritdoc cref="CefRequest._GetHeaderMap"/>
  public static unsafe void GetHeaderMap(ref this CefRequest self, ref CefStringMultimap headerMap)
    => self._GetHeaderMap(self.AsPointer(), headerMap.AsPointer());

  /// <inheritdoc cref="CefRequest._SetHeaderMap"/>
  public static unsafe void SetHeaderMap(ref this CefRequest self, ref CefStringMultimap headerMap)
    => self._SetHeaderMap(self.AsPointer(), headerMap.AsPointer());

  /// <inheritdoc cref="CefRequest._GetHeaderByName"/>
  public static unsafe CefStringUserFree* GetHeaderByName(ref this CefRequest self, ref CefString name)
    => self._GetHeaderByName(self.AsPointer(), name.AsPointer());

  /// <inheritdoc cref="CefRequest._SetHeaderByName"/>
  public static unsafe void SetHeaderByName(ref this CefRequest self, ref CefString name, ref CefString value, int overwrite)
    => self._SetHeaderByName(self.AsPointer(), name.AsPointer(), value.AsPointer(), overwrite);

  /// <inheritdoc cref="CefRequest._Set"/>
  public static unsafe void Set(ref this CefRequest self, ref CefString url, ref CefString method, ref CefPostData postData, ref CefStringMultimap headerMap)
    => self._Set(self.AsPointer(), url.AsPointer(), method.AsPointer(), postData.AsPointer(), headerMap.AsPointer());

  /// <inheritdoc cref="CefRequest._GetFlags"/>
  public static unsafe int GetFlags(ref this CefRequest self)
    => self._GetFlags(self.AsPointer());

  /// <inheritdoc cref="CefRequest._SetFlags"/>
  public static unsafe void SetFlags(ref this CefRequest self, int flags)
    => self._SetFlags(self.AsPointer(), flags);

  /// <inheritdoc cref="CefRequest._GetFirstPartyForCookies"/>
  public static unsafe CefStringUserFree* GetFirstPartyForCookies(ref this CefRequest self)
    => self._GetFirstPartyForCookies(self.AsPointer());

  /// <inheritdoc cref="CefRequest._SetFirstPartyForCookies"/>
  public static unsafe void SetFirstPartyForCookies(ref this CefRequest self, ref CefString url)
    => self._SetFirstPartyForCookies(self.AsPointer(), url.AsPointer());

  /// <inheritdoc cref="CefRequest._GetResourceType"/>
  public static unsafe CefResourceType GetResourceType(ref this CefRequest self)
    => self._GetResourceType(self.AsPointer());

  /// <inheritdoc cref="CefRequest._GetTransitionType"/>
  public static unsafe CefTransitionType GetTransitionType(ref this CefRequest self)
    => self._GetTransitionType(self.AsPointer());

  /// <inheritdoc cref="CefRequest._GetIdentifier"/>
  public static unsafe ulong GetIdentifier(ref this CefRequest self)
    => self._GetIdentifier(self.AsPointer());

}
