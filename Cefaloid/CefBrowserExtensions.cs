using System.Buffers;

namespace Cefaloid;

/// <inheritdoc cref="CefBrowser"/>
[PublicAPI]
public static class CefBrowserExtensions {

  /// <inheritdoc cref="CefBrowser._IsValid"/>
  public static unsafe bool IsValid(ref this CefBrowser self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._GetHost"/>
  public static unsafe CefBrowserHost* GetHost(ref this CefBrowser self) => self._GetHost(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._CanGoBack"/>
  public static unsafe bool CanGoBack(ref this CefBrowser self) => self._CanGoBack(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._GoBack"/>
  public static unsafe void GoBack(ref this CefBrowser self) => self._GoBack(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._CanGoForward"/>
  public static unsafe bool CanGoForward(ref this CefBrowser self) => self._CanGoForward(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._GoForward"/>
  public static unsafe void GoForward(ref this CefBrowser self) => self._GoForward(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._IsLoading"/>
  public static unsafe bool IsLoading(ref this CefBrowser self) => self._IsLoading(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._Reload"/>
  public static unsafe void Reload(ref this CefBrowser self) => self._Reload(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._ReloadIgnoreCache"/>
  public static unsafe void ReloadIgnoreCache(ref this CefBrowser self) => self._ReloadIgnoreCache(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._StopLoad"/>
  public static unsafe void StopLoad(ref this CefBrowser self) => self._StopLoad(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._GetIdentifier"/>
  public static unsafe int GetIdentifier(ref this CefBrowser self) => self._GetIdentifier(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._IsSame"/>
  public static unsafe bool IsSame(ref this CefBrowser self, CefBrowser that) => self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._IsPopup"/>
  public static unsafe bool IsPopup(ref this CefBrowser self) => self._IsPopup(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._HasDocument"/>
  public static unsafe bool HasDocument(ref this CefBrowser self) => self._HasDocument(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefBrowser._GetMainFrame"/>
  public static unsafe CefFrame* GetMainFrame(ref this CefBrowser self) => self._GetMainFrame(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._GetFocusedFrame"/>
  public static unsafe CefFrame* GetFocusedFrame(ref this CefBrowser self) => self._GetFocusedFrame(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._GetFrameByIdent"/>
  public static unsafe CefFrame* GetFrameByIdent(ref this CefBrowser self, long identifier) => self._GetFrameByIdent(self.AsPointer(), identifier);

  /// <inheritdoc cref="CefBrowser._GetFrame"/>
  public static unsafe CefFrame* GetFrame(ref this CefBrowser self, ref CefString name) => self._GetFrame(self.AsPointer(), name.AsPointer());

  /// <inheritdoc cref="CefBrowser._GetFrameCount"/>
  public static unsafe nuint GetFrameCount(ref this CefBrowser self) => self._GetFrameCount(self.AsPointer());

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe void GetFrameIdentifiers(ref this CefBrowser self, ref nuint identifiersCount, long* identifiers)
    => self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiers);

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe void GetFrameIdentifiers(ref this CefBrowser self, Span<long> identifiers) {
    var identifiersCount = (nuint) identifiers.Length;
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe long[] GetFrameIdentifiersArray(ref this CefBrowser self) {
    var identifiersCount = self.GetFrameCount();
    var identifiers = new long[identifiersCount];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    return identifiers;
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe void WithFrameIdentifiers<TArg>(ref this CefBrowser self, ReadOnlySpanAction<long, TArg> action, TArg actionArg) {
    var identifiersCount = self.GetFrameCount();
    Span<long> identifiers = stackalloc long[checked((int) identifiersCount)];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    action(identifiers, actionArg);
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe void WithFrameIdentifiers<TArg>(ref this CefBrowser self, delegate *<ReadOnlySpan<long>, TArg, void> action, TArg actionArg) {
    var identifiersCount = self.GetFrameCount();
    Span<long> identifiers = stackalloc long[checked((int) identifiersCount)];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    action(identifiers, actionArg);
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe TResult WithFrameIdentifiers<TResult>(ref this CefBrowser self, delegate *<ReadOnlySpan<long>, TResult> action) {
    var identifiersCount = self.GetFrameCount();
    Span<long> identifiers = stackalloc long[checked((int) identifiersCount)];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    return action(identifiers);
  }

  /// <inheritdoc cref="CefBrowser._GetFrameIdentifiers"/>
  public static unsafe TResult WithFrameIdentifiers<TArg, TResult>(ref this CefBrowser self, delegate *<ReadOnlySpan<long>, TArg, TResult> action, TArg actionArg) {
    var identifiersCount = self.GetFrameCount();
    Span<long> identifiers = stackalloc long[checked((int) identifiersCount)];
    fixed (long* identifiersPtr = identifiers)
      self._GetFrameIdentifiers(self.AsPointer(), identifiersCount.AsPointer(), identifiersPtr);
    return action(identifiers, actionArg);
  }

  /// <inheritdoc cref="CefBrowser._GetFrameNames"/>
  public static unsafe void GetFrameNames(ref this CefBrowser self, ref CefStringList names) => self._GetFrameNames(self.AsPointer(), names.AsPointer());

}
