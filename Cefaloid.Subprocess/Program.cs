#if DEBUG
var appDom = AppDomain.CurrentDomain;
appDom.FirstChanceException += (sender, args) => {
  Console.WriteLine($"First chance exception in subprocess: {args.Exception}");
};
appDom.UnhandledException += (sender, args) => {
  Console.WriteLine($"Unhandled exception in subprocess: {args.ExceptionObject}");
};
appDom.ProcessExit += (sender, args) => {
  Console.WriteLine($"Subprocess exiting with code: {Environment.ExitCode}");
};
TaskScheduler.UnobservedTaskException += (sender, args) => {
  Console.WriteLine($"Unobserved task exception in subprocess: {args.Exception}");
};
#endif

if (OperatingSystem.IsWindows()) {
  static void EnableDpiAwareness() {
    [DllImport("user32", EntryPoint = "SetProcessDpiAwarenessContext", SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    static extern bool SetProcessDpiAwarenessContext(int value);

    SetProcessDpiAwarenessContext(-4); // DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2
  }

  EnableDpiAwareness();
  Cef.EnableHighDpiSupportForWindows();
}

var cefMainArgs = new CefMainArgs();
if (OperatingSystem.IsWindows()) {
  static void SetupWindowsArgs(ref CefMainArgs cefArgs) {
    using var proc = Process.GetCurrentProcess();
    cefArgs.ForWindows.InstanceHandle = proc.Handle;
  }

  SetupWindowsArgs(ref cefMainArgs);
}

#if DEBUG
Console.WriteLine("Starting subprocess...");
#endif

var exitCode = CefApp.ExecuteProcess(ref cefMainArgs);

Console.WriteLine($"CefApp ExecuteProcess exited with: {(uint) exitCode}");

if (exitCode > 0)
  return exitCode;

// TODO: ???

return 0;
