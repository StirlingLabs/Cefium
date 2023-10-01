namespace Cefium;

/// <inheritdoc cref="CefView"/>
[PublicAPI]
public static unsafe class CefViewExtensions {

  /// <inheritdoc cref="CefView._AsBrowserView"/>
  public static CefBrowserView* AsBrowserView(ref this CefView self)
    => self._AsBrowserView is not null ? self._AsBrowserView(self.AsPointer()) : null;

  /// <inheritdoc cref="CefView._AsButton"/>
  public static CefButton* AsButton(ref this CefView self)
    => self._AsButton is not null ? self._AsButton(self.AsPointer()) : null;

  /// <inheritdoc cref="CefView._AsPanel"/>
  public static CefPanel* AsPanel(ref this CefView self)
    => self._AsPanel is not null ? self._AsPanel(self.AsPointer()) : null;

  /// <inheritdoc cref="CefView._AsScrollView"/>
  public static CefScrollView* AsScrollView(ref this CefView self)
    => self._AsScrollView is not null ? self._AsScrollView(self.AsPointer()) : null;

  /// <inheritdoc cref="CefView._AsTextfield"/>
  public static CefTextField* AsTextfield(ref this CefView self)
    => self._AsTextfield is not null ? self._AsTextfield(self.AsPointer()) : null;

  /// <inheritdoc cref="CefView._GetTypeString"/>
  public static CefString* GetTypeString(ref this CefView self)
    => self._GetTypeString is not null ? self._GetTypeString(self.AsPointer()) : null;

  /// <inheritdoc cref="CefView._ToString"/>
  public static CefString* ToString(ref this CefView self, bool includeChildren)
    => self._ToString is not null ? self._ToString(self.AsPointer(), includeChildren ? 1 : 0) : null;

  /// <inheritdoc cref="CefView._IsValid"/>
  public static bool IsValid(ref this CefView self)
    => self._IsValid is not null && self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefView._IsAttached"/>
  public static bool IsAttached(ref this CefView self)
    => self._IsAttached is not null && self._IsAttached(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefView._IsSame"/>
  public static bool IsSame(ref this CefView self, CefView* that)
    => self._IsSame is not null && self._IsSame(self.AsPointer(), that) != 0;

  /// <inheritdoc cref="CefView._GetDelegate"/>
  public static CefViewDelegate* GetDelegate(ref this CefView self)
    => self._GetDelegate is not null ? self._GetDelegate(self.AsPointer()) : null;

  /// <inheritdoc cref="CefView._GetWindow"/>
  public static CefWindow* GetWindow(ref this CefView self)
    => self._GetWindow is not null ? self._GetWindow(self.AsPointer()) : null;

}
