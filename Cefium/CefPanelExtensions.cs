namespace Cefium;

/// <inheritdoc cref="CefPanel"/>
[PublicAPI]
public static class CefPanelExtensions {

  /// <inheritdoc cref="CefPanel._AsWindow"/>
  public static unsafe CefWindow* AsWindow(ref this CefPanel self)
    => self._AsWindow is not null ? self._AsWindow(self.AsPointer()) : default;

  /// <inheritdoc cref="CefPanel._SetToFillLayout"/>
  public static unsafe CefFillLayout* SetToFillLayout(ref this CefPanel self)
    => self._SetToFillLayout is not null ? self._SetToFillLayout(self.AsPointer()) : default;

  /// <inheritdoc cref="CefPanel._SetToBoxLayout"/>
  public static unsafe CefBoxLayout* SetToBoxLayout(ref this CefPanel self, CefBoxLayoutSettings* arg1)
    => self._SetToBoxLayout is not null ? self._SetToBoxLayout(self.AsPointer(), arg1) : default;

  /// <inheritdoc cref="CefPanel._GetLayout"/>
  public static unsafe CefLayout* GetLayout(ref this CefPanel self)
    => self._GetLayout is not null ? self._GetLayout(self.AsPointer()) : default;

  /// <inheritdoc cref="CefPanel._Layout"/>
  public static unsafe bool Layout(ref this CefPanel self) {
    if (self._Layout is null) return false;

    self._Layout(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefPanel._AddChildView"/>
  public static unsafe bool AddChildView(ref this CefPanel self, CefView* arg1) {
    if (self._AddChildView is null) return false;

    self._AddChildView(self.AsPointer(), arg1);
    return true;
  }

  /// <inheritdoc cref="CefPanel._AddChildViewAt"/>
  public static unsafe bool AddChildViewAt(ref this CefPanel self, CefView* arg1, int arg2) {
    if (self._AddChildViewAt is null) return false;

    self._AddChildViewAt(self.AsPointer(), arg1, arg2);
    return true;
  }

  /// <inheritdoc cref="CefPanel._ReorderChildView"/>
  public static unsafe bool ReorderChildView(ref this CefPanel self, CefView* arg1, int arg2) {
    if (self._ReorderChildView is null) return false;

    self._ReorderChildView(self.AsPointer(), arg1, arg2);
    return true;
  }

  /// <inheritdoc cref="CefPanel._RemoveChildView"/>
  public static unsafe bool RemoveChildView(ref this CefPanel self, CefView* arg1) {
    if (self._RemoveChildView is null) return false;

    self._RemoveChildView(self.AsPointer(), arg1);
    return true;
  }

  /// <inheritdoc cref="CefPanel._RemoveAllChildViews"/>
  public static unsafe bool RemoveAllChildViews(ref this CefPanel self) {
    if (self._RemoveAllChildViews is null) return false;

    self._RemoveAllChildViews(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefPanel._GetChildViewCount"/>
  public static unsafe uint GetChildViewCount(ref this CefPanel self)
    => self._GetChildViewCount is not null ? self._GetChildViewCount(self.AsPointer()) : default;

  /// <inheritdoc cref="CefPanel._GetChildViewAt"/>
  public static unsafe CefView* GetChildViewAt(ref this CefPanel self, int arg1)
    => self._GetChildViewAt is not null ? self._GetChildViewAt(self.AsPointer(), arg1) : default;

}
