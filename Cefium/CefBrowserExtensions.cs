using System.Buffers;

namespace Cefium;

/// <inheritdoc cref="CefBrowser"/>
[PublicAPI]
public static class CefBrowserExtensions {

  /// <inheritdoc cref="CefBrowser._IsValid"/>
  public static unsafe bool IsValid(ref this CefBrowser self) {
    if (self._IsValid is null) return false;

    return self._IsValid(self.AsPointer()) != 0;
  }

  /// <inheritdoc cref="CefBrowser._GetHost"/>
  public static unsafe CefBrowserHost* GetHost(ref this CefBrowser self)
    => self._GetHost is not null ? self._GetHost(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowser._CanGoBack"/>
  public static unsafe bool CanGoBack(ref this CefBrowser self)
    => self._CanGoBack is not null && self._CanGoBack(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._GoBack"/>
  public static unsafe bool GoBack(ref this CefBrowser self) {
    if (self._GoBack is null) return false;

    self._GoBack(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowser._CanGoForward"/>
  public static unsafe bool CanGoForward(ref this CefBrowser self)
    => self._CanGoForward is not null && self._CanGoForward(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._GoForward"/>
  public static unsafe bool GoForward(ref this CefBrowser self) {
    if (self._GoForward is null) return false;

    self._GoForward(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowser._IsLoading"/>
  public static unsafe bool IsLoading(ref this CefBrowser self)
    => self._IsLoading is not null && self._IsLoading(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._Reload"/>
  public static unsafe bool Reload(ref this CefBrowser self) {
    if (self._Reload is null) return false;

    self._Reload(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowser._ReloadIgnoreCache"/>
  public static unsafe bool ReloadIgnoreCache(ref this CefBrowser self) {
    if (self._ReloadIgnoreCache is null) return false;

    self._ReloadIgnoreCache(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowser._StopLoad"/>
  public static unsafe bool StopLoad(ref this CefBrowser self) {
    if (self._StopLoad is null) return false;

    self._StopLoad(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefBrowser._GetIdentifier"/>
  public static unsafe int GetIdentifier(ref this CefBrowser self)
    => self._GetIdentifier is not null ? self._GetIdentifier(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowser._IsSame"/>
  public static unsafe bool IsSame(ref this CefBrowser self, CefBrowser that)
    => self._IsSame is not null && self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._IsPopup"/>
  public static unsafe bool IsPopup(ref this CefBrowser self)
    => self._IsPopup is not null && self._IsPopup(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._HasDocument"/>
  public static unsafe bool HasDocument(ref this CefBrowser self)
    => self._HasDocument is not null && self._HasDocument(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._GetMainFrame"/>
  public static unsafe CefFrame* GetMainFrame(ref this CefBrowser self)
    => self._GetMainFrame is not null ? self._GetMainFrame(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowser._GetFocusedFrame"/>
  public static unsafe CefFrame* GetFocusedFrame(ref this CefBrowser self)
    => self._GetFocusedFrame is not null ? self._GetFocusedFrame(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowser._GetFrameByIdent"/>
  public static unsafe CefFrame* GetFrameByIdent(ref this CefBrowser self, long identifier)
    => self._GetFrameByIdent is not null ? self._GetFrameByIdent(self.AsPointer(), identifier) : default;

  /// <inheritdoc cref="CefBrowser._GetFrame"/>
  public static unsafe CefFrame* GetFrame(ref this CefBrowser self, ref CefString name)
    => self._GetFrame is not null ? self._GetFrame(self.AsPointer(), name.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowser._GetFrameCount"/>
  public static unsafe nuint GetFrameCount(ref this CefBrowser self)
    => self._GetFrameCount is not null ? self._GetFrameCount(self.AsPointer()) : default;

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe bool GetFrameIdentifiers(ref this CefBrowser self, ref nuint identifiersCount, long* identifiers) {
    if (self._GetFrameIdentifiers is null) return false;

    self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiers);
    return true;
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe bool GetFrameIdentifiers(ref this CefBrowser self, Span<long> identifiers) {
    if (self._GetFrameIdentifiers is null) return false;

    var identifiersCount = (nuint) identifiers.Length;
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    return true;
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe long[]? GetFrameIdentifiersArray(ref this CefBrowser self) {
    if (self._GetFrameIdentifiers is null) return null;

    var identifiersCount = self.GetFrameCount();
    var identifiers = new long[identifiersCount];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    return identifiers;
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe bool WithFrameIdentifiers<TArg>(ref this CefBrowser self, ReadOnlySpanAction<long, TArg> action, TArg actionArg) {
    if (self._GetFrameIdentifiers is null) return false;

    var identifiersCount = self.GetFrameCount();
    Span<long> identifiers = stackalloc long[checked((int) identifiersCount)];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    action(identifiers, actionArg);
    return true;
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe bool WithFrameIdentifiers<TArg>(ref this CefBrowser self, delegate *<ReadOnlySpan<long>, TArg, void> action, TArg actionArg) {
    if (self._GetFrameIdentifiers is null) return false;

    var identifiersCount = self.GetFrameCount();
    Span<long> identifiers = stackalloc long[checked((int) identifiersCount)];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    action(identifiers, actionArg);
    return true;
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe TResult WithFrameIdentifiers<TResult>(ref this CefBrowser self, delegate *<ReadOnlySpan<long>, TResult> action) {
    if (self._GetFrameIdentifiers is null) return default!;

    var identifiersCount = self.GetFrameCount();
    Span<long> identifiers = stackalloc long[checked((int) identifiersCount)];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    return action(identifiers);
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe TResult WithFrameIdentifiers<TArg, TResult>(ref this CefBrowser self, delegate *<ReadOnlySpan<long>, TArg, TResult> action, TArg actionArg) {
    if (self._GetFrameIdentifiers is null) return default!;

    var identifiersCount = self.GetFrameCount();
    Span<long> identifiers = stackalloc long[checked((int) identifiersCount)];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    return action(identifiers, actionArg);
  }

  /// <inheritdoc cref="CefBrowser._GetFrameNames"/>
  public static unsafe bool GetFrameNames(ref this CefBrowser self, ref CefStringList names) {
    if (self._GetFrameNames is null) return false;

    self._GetFrameNames(self.AsPointer(), names.AsPointer());
    return true;
  }

}
