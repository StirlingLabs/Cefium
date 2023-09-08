using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using FluentAssertions;
using static Cefaloid.Cef;

namespace Cefaloid.Tests;

public class Tests {

  [Test]
  public unsafe void InitializeCefTest() {
    //Environment.SetEnvironmentVariable("DXVK_LOG_PATH", @".");
    //Environment.SetEnvironmentVariable("DXVK_LOG_LEVEL", "debug");
    Environment.SetEnvironmentVariable("CHROME_HEADLESS", "0");
    Environment.SetEnvironmentVariable("CHROME_IPC_LOGGING", "1");

    var output = TestContext.Out;
    var pipeName = $"cefaloid-unit-tests-logging-{Environment.ProcessId}";
    var pipeReady = new ManualResetEventSlim();
    new Thread(() => {
      using var pipeStream = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte);
      using var streamReader = new StreamReader(pipeStream, Encoding.UTF8);
      pipeReady.Set();
      pipeStream.WaitForConnection();
      for (;;) {
        var line = streamReader.ReadLine();
        if (line == null)
          break;

        output.WriteLine(line);
        output.Flush();
      }
    }) {
      IsBackground = true,
      Name = "Cefaloid Unit Tests Logging Pipe Worker"
    }.Start();

    var pipePath = $@"\\.\pipe\{pipeName}";

    pipeReady.Wait();
    File.WriteAllText(pipePath, "TEST");

    Environment.SetEnvironmentVariable("CHROME_LOG_FILE", pipePath);

    Cefaloid.Initialize();

    var lastProgress = 0f;
    while (Cefaloid.IsDownloading) {
      if (Cefaloid.DownloadProgress > lastProgress) {
        lastProgress = Cefaloid.DownloadProgress;
        Trace.WriteLine($"Download progress: {lastProgress:P}");
      }

      if (lastProgress >= 1f)
        break;

      Thread.Sleep(1);
    }

    if (!Cefaloid.IsReady)
      Trace.WriteLine("Extracting...");
    lastProgress = 0;

    while (!Cefaloid.IsReady) {
      if (Cefaloid.ExtractProgress > lastProgress) {
        lastProgress = Cefaloid.ExtractProgress;
        Trace.WriteLine($"Extraction progress: {lastProgress:P}");
      }

      if (lastProgress >= 1f)
        break;

      Thread.Sleep(1);
    }

    while (!Cefaloid.IsReady)
      Thread.Sleep(1);



    Trace.WriteLine("Ready!");

    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

    var settings = new CefSettings {
      CommandLineArgsDisabled = true,
      RemoteDebuggingPort = 9222,
      LogSeverity = CefLogSeverity.Verbose,
      //LogSeverity = CefLogSeverity.Disable,
      WindowlessRenderingEnabled = false,
      MultiThreadedMessageLoop = true,
      CookieableSchemesExcludeDefaults = true,
      NoSandbox = true
    };

    pipePath.CreateCefString(out settings.LogFile);

    //settings.InitializeBase();
    settings.Size.Should().NotBe(0);

    "--wasm-dynamic-tiering --suppress-asm-messages --wasm-staging --flush-baseline-code"
      .CreateCefString(out settings.JavascriptFlags);

    var cachePath = Path.Combine(Path.GetTempPath(), "Cefaloid", "Cache");
    cachePath.CreateCefString(out settings.CachePath);
    cachePath.CreateCefString(out settings.RootCachePath);

    var userPath = Path.Combine(Cefaloid.LocalAppDataPathBase, "DefaultUser");
    userPath.CreateCefString(out settings.UserDataPath);
    Cefaloid.LocalAppDataPath
      .CreateCefString(out settings.ResourcesDirPath);

    //var subProcPath = Path.Combine(Cefaloid.LocalAppDataPath, "subproc", "Cefaloid.Subprocess.exe");
    //subProcPath.CreateCefString(out settings.BrowserSubprocessPath);

    /* Mac only
    var fwPath = Cefaloid.FrameworkPath;
    fwPath.CreateCefString(out settings.FrameworkDirPath);
    */

    var cefApp = New<CefApp>();
    //cefApp.Ref.InitializeBase();
    cefApp.Target.Base.Size.Should().NotBe(0);

    unsafe {
      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnBeforeCommandLineProcessing(CefApp* self, CefString* processType, CefCommandLine* commandLine) {
        commandLine->Reset();

        foreach (var arg in Customizations.CommandLineArguments) {
          var str = CefString.CreateViaPin(arg);
          commandLine->AppendSwitch(ref str);
        }

        foreach (var (arg, val) in Customizations.CommandLineArgumentsWithValues) {
          var argStr = CefString.CreateViaPin(arg);
          var valStr = CefString.CreateViaPin(val);
          commandLine->AppendSwitchWithValue(ref argStr, ref valStr);
        }

        /*
        var subprocessPathParam = CefString.CreateViaPin("browser-subprocess-path");
        var subprocessPathArg = CefString.CreateViaPin(Path.Combine(Cefaloid.LocalAppDataPath, "subproc", "Cefaloid.Subprocess.exe"));
        commandLine->AppendSwitchWithValue(ref subprocessPathParam, ref subprocessPathArg);
        */

        var result = commandLine->GetCommandLineString();

        var outStream = Console.Out;
        outStream.WriteLine("Command line: ");
        outStream.WriteLine(result->AsCharSpan());
        outStream.Flush();
        result->Free();
      }

      cefApp.Target.OnBeforeCommandLineProcessing = &OnBeforeCommandLineProcessing;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnRegisterCustomSchemes(CefApp* self, CefSchemeRegistrar* registrar) {
      }

      cefApp.Target.OnRegisterCustomSchemes = &OnRegisterCustomSchemes;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefResourceBundleHandler* GetResourceBundleHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.GetResourceBundleHandler = &GetResourceBundleHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefBrowserProcessHandler* GetBrowserProcessHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.GetBrowserProcessHandler = &GetBrowserProcessHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefRenderProcessHandler* GetRenderProcessHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.GetRenderProcessHandler = &GetRenderProcessHandler;
    }

    var mainArgs = new CefMainArgs();
    mainArgs.ForWindows.InstanceHandle = default; //Marshal.GetHINSTANCE(typeof(Tests).Assembly.ManifestModule);

    /*
    var result = cefApp.Target.ExecuteProcess(ref mainArgs, null);

    result.Should().BeLessThan(0);
    */

    var success = cefApp.Target.Initialize(ref mainArgs, ref settings);

    success.Should().BeTrue();

    CefWindowInfo windowInfo = new() {
      WindowlessRenderingEnabled = true,
      Bounds = ((0, 0), (320, 240)),
    };

    var browserSettings = new CefBrowserSettings {
      EnableDatabases = CefState.Disabled,
      EnableLocalStorage = CefState.Disabled,
      EnableRemoteFonts = CefState.Enabled,
      EnableTextAreaResize = CefState.Disabled,
      EnableTabToLinks = CefState.Disabled,
      WindowlessFrameRate = 60,
      EnableJavascriptAccessClipboard = CefState.Enabled,
      EnableJavascriptCloseWindows = CefState.Enabled,
      EnableJavascriptDomPaste = CefState.Enabled,
      EnableJavascript = CefState.Enabled,
      EnableImageLoading = CefState.Enabled,
      EnableWebGL = CefState.Enabled
    };
    //browserSettings.InitializeBase();
    browserSettings.Size.Should().NotBe(0);

    var client = New<CefClient>();

    unsafe {
      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefAudioHandler* GetAudioHandler(CefClient* self) {
        return null;
      }

      client.Target._GetAudioHandler = &GetAudioHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefCommandHandler* GetCommandHandler(CefClient* self) {
        return null;
      }

      client.Target._GetCommandHandler = &GetCommandHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefContextMenuHandler* GetContextMenuHandler(CefClient* self) {
        return null;
      }

      client.Target._GetContextMenuHandler = &GetContextMenuHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefDialogHandler* GetDialogHandler(CefClient* self) {
        return null;
      }

      client.Target._GetDialogHandler = &GetDialogHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefDisplayHandler* GetDisplayHandler(CefClient* self) {
        return null;
      }

      client.Target._GetDisplayHandler = &GetDisplayHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefDownloadHandler* GetDownloadHandler(CefClient* self) {
        return null;
      }

      client.Target._GetDownloadHandler = &GetDownloadHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefDragHandler* GetDragHandler(CefClient* self) {
        return null;
      }

      client.Target._GetDragHandler = &GetDragHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefFindHandler* GetFindHandler(CefClient* self) {
        return null;
      }

      client.Target._GetFindHandler = &GetFindHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefFocusHandler* GetFocusHandler(CefClient* self) {
        return null;
      }

      client.Target._GetFocusHandler = &GetFocusHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefFrameHandler* GetFrameHandler(CefClient* self) {
        return null;
      }

      client.Target._GetFrameHandler = &GetFrameHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefJsDialogHandler* GetJsDialogHandler(CefClient* self) {
        return null;
      }

      client.Target._GetJsDialogHandler = &GetJsDialogHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefPermissionHandler* GetPermissionHandler(CefClient* self) {
        return null;
      }

      client.Target._GetPermissionHandler = &GetPermissionHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefKeyboardHandler* GetKeyboardHandler(CefClient* self) {
        return null;
      }

      client.Target._GetKeyboardHandler = &GetKeyboardHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefLifeSpanHandler* GetLifeSpanHandler(CefClient* self) {
        return null;
      }

      client.Target._GetLifeSpanHandler = &GetLifeSpanHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefLoadHandler* GetLoadHandler(CefClient* self) {
        return null;
      }

      client.Target._GetLoadHandler = &GetLoadHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefPrintHandler* GetPrintHandler(CefClient* self) {
        return null;
      }

      client.Target._GetPrintHandler = &GetPrintHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefRenderHandler* GetRenderHandler(CefClient* self) {
        return null;
      }

      client.Target._GetRenderHandler = &GetRenderHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefRequestHandler* GetRequestHandler(CefClient* self) {
        return null;
      }

      client.Target._GetRequestHandler = &GetRequestHandler;

      var extraInfo = New<CefDictionaryValue>();

      var initUrl = "about:blank"
        .CreateCefString();

      /*
      var created = CefBrowserHost.CreateBrowser(
        ref windowInfo,
        client,
        ref initUrl,
        ref browserSettings,
        extraInfo
      );

      created.Should().BeTrue();
      */

      /*
      var browser = CefBrowserHost.CreateBrowserSync(
        ref windowInfo,
        client,
        ref initUrl,
        ref browserSettings,
        extraInfo
      );

      (browser == null).Should().BeFalse();
      */
      CefApp.RunMessageLoop();

      /*

      CefApp.Shutdown();*/
    }
  }

}
