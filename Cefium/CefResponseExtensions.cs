namespace Cefium;

/// <inheritdoc cref="CefResponse"/>
[PublicAPI]
public static class CefResponseExtensions {

  /// <inheritdoc cref="CefResponse._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefResponse self)
    => self._GetHeaderByName is not null && self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefResponse._GetError"/>
  public static unsafe CefErrorCode GetError(ref this CefResponse self)
    => self._GetError is null ? default : self._GetError(self.AsPointer());

  /// <inheritdoc cref="CefResponse._SetError"/>
  public static unsafe bool SetError(ref this CefResponse self, CefErrorCode error) {
    if (self._SetError is not null)
      return false;

    self._SetError(self.AsPointer(), error);
    return true;
  }

  /// <inheritdoc cref="CefResponse._GetStatus"/>
  public static unsafe int GetStatus(ref this CefResponse self)
    => self._GetStatus is not null ? self._GetStatus(self.AsPointer()) : default;

  /// <inheritdoc cref="CefResponse._SetStatus"/>
  public static unsafe bool SetStatus(ref this CefResponse self, int status) {
    if (self._SetStatus is null)
      return false;

    self._SetStatus(self.AsPointer(), status);
    return true;
  }

  /// <inheritdoc cref="CefResponse._GetStatusText"/>
  public static unsafe CefStringUserFree* GetStatusText(ref this CefResponse self)
    => self._GetStatusText is not null ? self._GetStatusText(self.AsPointer()) : default;

  /// <inheritdoc cref="CefResponse._SetStatusText"/>
  public static unsafe bool SetStatusText(ref this CefResponse self, CefString* statusText) {
    if (self._SetStatusText is null)
      return false;

    self._SetStatusText(self.AsPointer(), statusText);
    return true;
  }

  /// <inheritdoc cref="CefResponse._GetMimeType"/>
  public static unsafe CefStringUserFree* GetMimeType(ref this CefResponse self)
    => self._GetMimeType is not null ? self._GetMimeType(self.AsPointer()) : default;

  /// <inheritdoc cref="CefResponse._SetMimeType"/>
  public static unsafe bool SetMimeType(ref this CefResponse self, CefString* mimeType) {
    if (self._SetMimeType is null)
      return false;

    self._SetMimeType(self.AsPointer(), mimeType);
    return true;
  }

  /// <inheritdoc cref="CefResponse._GetCharset"/>
  public static unsafe CefStringUserFree* GetCharset(ref this CefResponse self)
    => self._GetHeaderByName is not null ? self._GetCharset(self.AsPointer()) : default;

  /// <inheritdoc cref="CefResponse._SetCharset"/>
  public static unsafe bool SetCharset(ref this CefResponse self, CefString* charset) {
    if (self._SetCharset is null)
      return false;

    self._SetCharset(self.AsPointer(), charset);
    return true;
  }

  /// <inheritdoc cref="CefResponse._GetHeaderByName"/>
  public static unsafe CefStringUserFree* GetHeaderByName(ref this CefResponse self, CefString* name)
    => self._GetHeaderByName is not null ? self._GetHeaderByName(self.AsPointer(), name) : default;

  /// <inheritdoc cref="CefResponse._SetHeaderByName"/>
  public static unsafe bool SetHeaderByName(ref this CefResponse self, CefString* name, CefString* value, bool overwrite) {
    if (self._SetHeaderByName is null)
      return false;

    self._SetHeaderByName(self.AsPointer(), name, value, overwrite ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefResponse._GetHeaderMap"/>
  public static unsafe bool GetHeaderMap(ref this CefResponse self, CefStringMultimap* headerMap) {
    if (self._GetHeaderMap is null)
      return false;

    self._GetHeaderMap(self.AsPointer(), headerMap);
    return true;
  }

  /// <inheritdoc cref="CefResponse._SetHeaderMap"/>
  public static unsafe bool SetHeaderMap(ref this CefResponse self, CefStringMultimap* headerMap) {
    if (self._SetHeaderMap is null)
      return false;

    self._SetHeaderMap(self.AsPointer(), headerMap);
    return true;
  }

  /// <inheritdoc cref="CefResponse._GetUrl"/>
  public static unsafe CefStringUserFree* GetUrl(ref this CefResponse self)
    => self._GetHeaderByName is not null ? self._GetUrl(self.AsPointer()) : default;

  /// <inheritdoc cref="CefResponse._SetUrl"/>
  public static unsafe bool SetUrl(ref this CefResponse self, CefString* url) {
    if (self._SetUrl is null)
      return false;

    self._SetUrl(self.AsPointer(), url);
    return true;
  }

}
