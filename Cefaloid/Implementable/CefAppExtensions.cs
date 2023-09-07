namespace Cefaloid;

/// <inheritdoc cref="CefApp"/>
[PublicAPI]
public static class CefAppExtensions {

  /// <inheritdoc cref="CefApp.ExecuteProcess"/>
  public static unsafe int ExecuteProcess(ref this CefApp self, ref CefMainArgs args)
    => CefApp.ExecuteProcess(ref args, ref self, null);

  /// <inheritdoc cref="CefApp.ExecuteProcess"/>
  public static unsafe int ExecuteProcess(ref this CefApp self, ref CefMainArgs args, void* windowsSandboxInfo)
    => CefApp.ExecuteProcess(ref args, ref self, windowsSandboxInfo);

  /// <inheritdoc cref="CefApp._Initialize"/>
  public static unsafe bool Initialize(ref this CefApp self, ref CefMainArgs args, ref CefSettings settings)
    => CefApp._Initialize(args.AsPointer(), settings.AsPointer(), self.AsPointer(), null) != 0;

  /// <inheritdoc cref="CefApp._Initialize"/>
  public static unsafe bool Initialize(ref this CefApp self, ref CefMainArgs args, ref CefSettings settings, void* windowsSandboxInfo)
    => CefApp._Initialize(args.AsPointer(), settings.AsPointer(), self.AsPointer(), windowsSandboxInfo) != 0;

}
