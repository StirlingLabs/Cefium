namespace Cefium;

/// <inheritdoc cref="CefWindow"/>
[PublicAPI]
public static class CefWindowExtensions {

  /// <inheritdoc cref="CefWindow._Show"/>
  public static unsafe bool Show(ref this CefWindow self) {
    if (self._Show is null)
      return false;

    self._Show(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._ShowAsBrowserModalDialog"/>
  public static unsafe bool ShowAsBrowserModalDialog(ref this CefWindow self, CefBrowserView* browserView) {
    if (self._ShowAsBrowserModalDialog is null)
      return false;

    self._ShowAsBrowserModalDialog(self.AsPointer(), browserView);
    return true;
  }

  /// <inheritdoc cref="CefWindow._Hide"/>
  public static unsafe bool Hide(ref this CefWindow self) {
    if (self._Hide is null)
      return false;

    self._Hide(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._CenterWindow"/>
  public static unsafe bool CenterWindow(ref this CefWindow self, CefSize* size) {
    if (self._CenterWindow is null)
      return false;

    self._CenterWindow(self.AsPointer(), size);
    return true;
  }

  /// <inheritdoc cref="CefWindow._Close"/>
  public static unsafe bool Close(ref this CefWindow self) {
    if (self._Close is null)
      return false;

    self._Close(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._IsClosed"/>
  public static unsafe bool IsClosed(ref this CefWindow self)
    => self._IsClosed is not null && self._IsClosed(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefWindow._Activate"/>
  public static unsafe bool Activate(ref this CefWindow self) {
    if (self._Activate is null)
      return false;

    self._Activate(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._Deactivate"/>
  public static unsafe bool Deactivate(ref this CefWindow self) {
    if (self._Deactivate is null)
      return false;

    self._Deactivate(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._IsActive"/>
  public static unsafe bool IsActive(ref this CefWindow self)
    => self._IsActive is not null && self._IsActive(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefWindow._BringToTop"/>
  public static unsafe bool BringToTop(ref this CefWindow self) {
    if (self._BringToTop is null)
      return false;

    self._BringToTop(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._SetAlwaysOnTop"/>
  public static unsafe bool SetAlwaysOnTop(ref this CefWindow self, bool onTop) {
    if (self._SetAlwaysOnTop is null)
      return false;

    self._SetAlwaysOnTop(self.AsPointer(), onTop ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefWindow._IsAlwaysOnTop"/>
  public static unsafe bool IsAlwaysOnTop(ref this CefWindow self)
    => self._IsAlwaysOnTop is not null && self._IsAlwaysOnTop(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefWindow._Maximize"/>
  public static unsafe bool Maximize(ref this CefWindow self) {
    if (self._Maximize is null)
      return false;

    self._Maximize(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._Minimize"/>
  public static unsafe bool Minimize(ref this CefWindow self) {
    if (self._Minimize is null)
      return false;

    self._Minimize(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._Restore"/>
  public static unsafe bool Restore(ref this CefWindow self) {
    if (self._Restore is null)
      return false;

    self._Restore(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._SetFullscreen"/>
  public static unsafe bool SetFullscreen(ref this CefWindow self, bool fullscreen) {
    if (self._SetFullscreen is null)
      return false;

    self._SetFullscreen(self.AsPointer(), fullscreen ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefWindow._IsMaximized"/>
  public static unsafe bool IsMaximized(ref this CefWindow self)
    => self._IsMaximized is not null && self._IsMaximized(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefWindow._IsMinimized"/>
  public static unsafe bool IsMinimized(ref this CefWindow self)
    => self._IsMinimized is not null && self._IsMinimized(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefWindow._IsFullscreen"/>
  public static unsafe bool IsFullscreen(ref this CefWindow self)
    => self._IsFullscreen is not null && self._IsFullscreen(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefWindow._SetTitle"/>
  public static unsafe bool SetTitle(ref this CefWindow self, ref CefString title) {
    if (self._SetTitle is null)
      return false;

    self._SetTitle(self.AsPointer(), title.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._GetTitle"/>
  public static unsafe CefString* GetTitle(ref this CefWindow self)
    => self._GetTitle is not null ? self._GetTitle(self.AsPointer()) : null;

  /// <inheritdoc cref="CefWindow._SetWindowIcon"/>
  public static unsafe bool SetWindowIcon(ref this CefWindow self, CefImage* image) {
    if (self._SetWindowIcon is null)
      return false;

    self._SetWindowIcon(self.AsPointer(), image);
    return true;
  }

  /// <inheritdoc cref="CefWindow._GetWindowIcon"/>
  public static unsafe CefImage* GetWindowIcon(ref this CefWindow self)
    => self._GetWindowIcon is not null ? self._GetWindowIcon(self.AsPointer()) : default;

  /// <inheritdoc cref="CefWindow._SetWindowAppIcon"/>
  public static unsafe bool SetWindowAppIcon(ref this CefWindow self, CefImage* image) {
    if (self._SetWindowAppIcon is null)
      return false;

    self._SetWindowAppIcon(self.AsPointer(), image);
    return true;
  }

  /// <inheritdoc cref="CefWindow._GetWindowAppIcon"/>
  public static unsafe CefImage* GetWindowAppIcon(ref this CefWindow self)
    => self._GetWindowAppIcon is not null ? self._GetWindowAppIcon(self.AsPointer()) : default;

  /// <inheritdoc cref="CefWindow._AddOverlayView"/>
  public static unsafe CefOverlayController* AddOverlayView(ref this CefWindow self, CefView* view, CefDockingMode dockingMode)
    => self._AddOverlayView is not null ? self._AddOverlayView(self.AsPointer(), view, dockingMode) : default;

  /// <inheritdoc cref="CefWindow._ShowMenu"/>
  public static unsafe bool ShowMenu(ref this CefWindow self, CefMenuModel* menuModel, CefPoint* screenPoint, CefMenuAnchorPosition anchorPosition) {
    if (self._ShowMenu is null)
      return false;

    self._ShowMenu(self.AsPointer(), menuModel, screenPoint, anchorPosition);
    return true;
  }

  /// <inheritdoc cref="CefWindow._CancelMenu"/>
  public static unsafe bool CancelMenu(ref this CefWindow self) {
    if (self._CancelMenu is null)
      return false;

    self._CancelMenu(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefWindow._GetDisplay"/>
  public static unsafe CefDisplay* GetDisplay(ref this CefWindow self)
    => self._GetDisplay is not null ? self._GetDisplay(self.AsPointer()) : default;

  /// <inheritdoc cref="CefWindow._GetClientAreaBoundsInScreen"/>
  public static unsafe CefRect GetClientAreaBoundsInScreen(ref this CefWindow self)
    => self._GetClientAreaBoundsInScreen is not null ? self._GetClientAreaBoundsInScreen(self.AsPointer()) : default;

  /// <inheritdoc cref="CefWindow._SetDraggableRegions"/>
  public static unsafe bool SetDraggableRegions(ref this CefWindow self, uint regionsCount, CefDraggableRegion* regions) {
    if (self._SetDraggableRegions is null)
      return false;

    self._SetDraggableRegions(self.AsPointer(), regionsCount, regions);
    return true;
  }

  /// <inheritdoc cref="CefWindow._GetWindowHandle"/>
  public static unsafe void* GetWindowHandle(ref this CefWindow self)
    => self._GetWindowHandle is not null ? self._GetWindowHandle(self.AsPointer()) : default;

  /// <inheritdoc cref="CefWindow._SendKeyPress"/>
  public static unsafe bool SendKeyPress(ref this CefWindow self, int windowsKeyCode, uint modifiers) {
    if (self._SendKeyPress is null)
      return false;

    self._SendKeyPress(self.AsPointer(), windowsKeyCode, modifiers);
    return true;
  }

  /// <inheritdoc cref="CefWindow._SendMouseMove"/>
  public static unsafe bool SendMouseMove(ref this CefWindow self, int x, int y) {
    if (self._SendMouseMove is null)
      return false;

    self._SendMouseMove(self.AsPointer(), x, y);
    return true;
  }

  /// <inheritdoc cref="CefWindow._SendMouseEvents"/>
  public static unsafe bool SendMouseEvents(ref this CefWindow self, CefMouseButtonType type, bool mouseDown, bool mouseUp) {
    if (self._SendMouseEvents is null)
      return false;

    self._SendMouseEvents(self.AsPointer(), type, mouseDown ? 1 : 0, mouseUp ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefWindow._SetAccelerator"/>
  public static unsafe bool SetAccelerator(ref this CefWindow self, int commandId, int keyCode, bool shiftPressed, bool ctrlPressed, bool altPressed) {
    if (self._SetAccelerator is null)
      return false;

    self._SetAccelerator(self.AsPointer(), commandId, keyCode, shiftPressed ? 1 : 0, ctrlPressed ? 1 : 0, altPressed ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefWindow._RemoveAccelerator"/>
  public static unsafe bool RemoveAccelerator(ref this CefWindow self, int commandId) {
    if (self._RemoveAccelerator is null)
      return false;

    self._RemoveAccelerator(self.AsPointer(), commandId);
    return true;
  }

  /// <inheritdoc cref="CefWindow._RemoveAllAccelerators"/>
  public static unsafe bool RemoveAllAccelerators(ref this CefWindow self) {
    if (self._RemoveAllAccelerators is null)
      return false;

    self._RemoveAllAccelerators(self.AsPointer());
    return true;
  }

}
