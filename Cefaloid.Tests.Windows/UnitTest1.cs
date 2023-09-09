using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using System.Text.Unicode;
using Cysharp.Text;
using FluentAssertions;
using static Cefaloid.Cef;

namespace Cefaloid.Tests;

public class Tests {


  [StructLayout(LayoutKind.Sequential)]
  private struct CefTestApp : ICefRefCountedBase<CefTestApp> {

    public CefApp App;

    public ulong Cookie;

    public static void Initialize(ref CefTestApp self)
      => self.Cookie = 0x123456789ABCDEF;

  }

  private static ThreadStart CreateLoggingPipeWorker(string pipeName, ManualResetEventSlim pipeReady, CancellationToken testFinished, TextWriter output)
    => () => {
      try {
        using var pipeStream = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte);
        Trace.WriteLine("Logging pipe created.");
        Trace.Flush();
        pipeReady.Set();
        do {
          try {
            pipeStream.WaitForConnection();
          }
          catch (IOException) {
            Trace.WriteLine("Logging pipe broken.");
            pipeStream.Disconnect();
            continue;
          }

          Trace.WriteLine("Logging pipe connected.");
          var sb = ZString.CreateUtf8StringBuilder();
          for (;;) {
            var v = pipeStream.ReadByte();
            if (v == -1) break;

            var b = (byte) v;
            switch (b) {
              case (byte) '\r':
                break; // ignore
              case (byte) '\n': {
                var line = sb.ToString();
                //Trace.WriteLine("Logging pipe:" + line);
                //Trace.Flush();
                output.WriteLine(line);
                output.Flush();
                sb.Clear();
                break;
              }
              default:
                //Trace.WriteLine("Logging pipe read byte:" + (char)b);
                sb.AppendLiteral(new(in b));
                break;
            }
          }

          if (sb.Length > 0) {
            var line = sb.ToString();
            //Trace.WriteLine("Logging pipe final line:" + line);
            //Trace.Flush();
            output.WriteLine(line);
            output.Flush();
          }

          Trace.WriteLine("Logging pipe closed.");
          pipeStream.Disconnect();
        } while (!testFinished.IsCancellationRequested);

        Trace.WriteLine("Logging pipe task exiting.");
      }
      catch (Exception ex) {
        Trace.WriteLine($"Logging pipe task terminating with exception:\n{ex}");
      }
    };

  [Test]
  public unsafe void InitializeCefTest() {
    //Environment.SetEnvironmentVariable("DXVK_LOG_PATH", @".");
    //Environment.SetEnvironmentVariable("DXVK_LOG_LEVEL", "debug");
    Environment.SetEnvironmentVariable("CHROME_HEADLESS", "0");
    Environment.SetEnvironmentVariable("CHROME_IPC_LOGGING", "1");

    /*
    var output = TestContext.Progress;
    var pipeName = $"cefaloid-unit-tests-logging-{Environment.ProcessId}";
    var pipeReady = new ManualResetEventSlim();
    var testFinished = new CancellationTokenSource();
    var pipeThread = new Thread(CreateLoggingPipeWorker(pipeName, pipeReady, testFinished.Token, output))
      {Priority = ThreadPriority.Highest, IsBackground = true};
    pipeThread.UnsafeStart();

    var pipePath = $@"\\.\pipe\{pipeName}";

    pipeReady.Wait();
    File.WriteAllText(pipePath, "<<< LOGGING PIPE TEST LINE >>>\n");
    Thread.Sleep(125);

    Environment.SetEnvironmentVariable("CHROME_LOG_FILE", pipePath);
    */

    EnableHighDpiSupportForWindows();

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
      //MultiThreadedMessageLoop = true,
      MultiThreadedMessageLoop = false,
      CookieableSchemesExcludeDefaults = true,
      NoSandbox = true
    };

    /*
    pipePath.CreateCefString(out settings.LogFile);
    */

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

    var cefApp = New<CefTestApp>();
    //cefApp.Ref.InitializeBase();
    cefApp.Target.App.Base.Size.Should().NotBe(0);
    cefApp.Target.Cookie.Should().Be(0x123456789ABCDEFuL);

    unsafe {
      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnBeforeCommandLineProcessing(CefApp* self, CefString* processType, CefCommandLine* commandLine) {
        var app = (CefTestApp*) self;
        //var v8Ctx = CefV8Context.GetCurrentContext();

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

        //var logFileArg = "log-file".CreateCefString();
        /*
         var pipePath = $@"\\.\pipe\cefaloid-unit-tests-logging-{Environment.ProcessId}".CreateCefString();
        commandLine->AppendSwitchWithValue(ref logFileArg, ref pipePath);
        */
        //var logFilePath = $@"CONERR$".CreateCefString();
        //commandLine->AppendSwitchWithValue(ref logFileArg, ref logFilePath);

        /*
        var subprocessPathParam = CefString.CreateViaPin("browser-subprocess-path");
        var subprocessPathArg = CefString.CreateViaPin(Path.Combine(Cefaloid.LocalAppDataPath, "subproc", "Cefaloid.Subprocess.exe"));
        commandLine->AppendSwitchWithValue(ref subprocessPathParam, ref subprocessPathArg);
        */

        var result = commandLine->GetCommandLineString();

        var outStream = TestContext.Progress;
        outStream.WriteLine("Command line: ");
        outStream.WriteLine(result->AsCharSpan());
        outStream.Flush();
        result->Free();
      }

      cefApp.Target.App.OnBeforeCommandLineProcessing = &OnBeforeCommandLineProcessing;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnRegisterCustomSchemes(CefApp* self, CefSchemeRegistrar* registrar) {
      }

      cefApp.Target.App.OnRegisterCustomSchemes = &OnRegisterCustomSchemes;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefResourceBundleHandler* GetResourceBundleHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.App.GetResourceBundleHandler = &GetResourceBundleHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefBrowserProcessHandler* GetBrowserProcessHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.App.GetBrowserProcessHandler = &GetBrowserProcessHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefRenderProcessHandler* GetRenderProcessHandler(CefApp* self) {
        var v8Ctx = CefV8Context.GetCurrentContext();
        if (v8Ctx != null) {
          v8Ctx->Enter();
          try {
            var g = v8Ctx->GetGlobal();
            var exampleKey = "example".CreateCefString();
            var exampleValue = "Hello World!".CreateCefString();
            //var exampleKeyV8 = CefV8Value.CreateString(ref exampleKey);
            var exampleValueV8 = CefV8Value.CreateString(ref exampleValue);
            g->SetValueByKey(ref exampleKey, exampleValueV8, CefV8PropertyAttribute.ReadOnly | CefV8PropertyAttribute.DontDelete);
            var cefHandler = New<CefTestV8Handler>();
            cefHandler.Target.SetAction(() => {

            });
            CefV8Value.CreateFunction()
            g->SetValueByKey()
          }
          finally {
            v8Ctx->Exit();
          }
        }
        return null;
      }

      cefApp.Target.App.GetRenderProcessHandler = &GetRenderProcessHandler;
    }

    var mainArgs = new CefMainArgs();
    mainArgs.ForWindows.InstanceHandle = default; //Marshal.GetHINSTANCE(typeof(Tests).Assembly.ManifestModule);

    /*
    var result = cefApp.Target.App.ExecuteProcess(ref mainArgs, null);

    result.Should().BeLessThan(0);
    */

    var success = cefApp.Target.App.Initialize(ref mainArgs, ref settings);
    Thread.Sleep(125);

    success.Should().BeTrue();

    CefWindowInfo windowInfo = new() {
      WindowlessRenderingEnabled = false,
      //SharedTextureEnabled = true,
      //WindowName = "",
      Bounds = ((0, 0), (640, 480)),
    };

    var browserSettings = new CefBrowserSettings {
      EnableDatabases = CefState.Disabled,
      EnableLocalStorage = CefState.Disabled,
      EnableRemoteFonts = CefState.Enabled,
      EnableTextAreaResize = CefState.Disabled,
      EnableTabToLinks = CefState.Disabled,
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

      /*var created = CefBrowserHost.CreateBrowser(
        ref windowInfo,
        client,
        ref initUrl,
        ref browserSettings,
        extraInfo
      );

      created.Should().BeTrue();*/

      var browser = CefBrowserHost.CreateBrowserSync(
        ref windowInfo,
        client,
        ref initUrl,
        ref browserSettings,
        extraInfo
      );

      (browser == null).Should().BeFalse();

      //CefApp.RunMessageLoop();

      var cts = new CancellationTokenSource();
      cts.CancelAfter(2000);
      do CefApp.DoMessageLoopWork();
      while (!cts.IsCancellationRequested);

      var frame = browser->GetMainFrame();

      (frame == null).Should().BeFalse();

      var host = browser->GetHost();

      (host == null).Should().BeFalse();

      /*
      var runner = CefTaskRunner.GetForThread(CefThreadId.Renderer);

      (runner == null).Should().BeFalse();

      runner->BelongsToThread(CefThreadId.Renderer).Should().BeTrue();

      runner->BelongsToCurrentThread().Should().BeFalse();
      */

      //var cefV8Handler = New<CefTestV8Handler>();
      //((ulong) cefV8Handler.Target.V8Handler._Execute).Should().NotBe(0uL);

      //var cefTask = New<CefActionTask>();
      //((ulong) cefTask.Target.Task._Execute).Should().NotBe(0uL);

      //var taskSuccess = new StrongBox<bool>(false);
      //var taskCompleted = new ManualResetEventSlim();
      //var output = TestContext.Progress;

      /*
      cefTask.Target.SetAction(() => {
        output.WriteLine("Hello from V8!");
        var v8Ctx = CefV8Context.GetCurrentContext();
        if (v8Ctx == null)
          v8Ctx = CefV8Context.GetEnteredContext();
        if (v8Ctx == null)
          v8Ctx = frame->GetV8Context();

        if (v8Ctx == null) {
          output.WriteLine("No V8 context!");
          taskCompleted.Set();
          return;
        }

        v8Ctx->Enter();
        try {
          var v8Global = v8Ctx->GetGlobal();
          var exampleKey = "example".CreateCefString();
          var exampleValue = "Hello World!".CreateCefString();
          //var exampleKeyV8 = CefV8Value.CreateString(ref exampleKey);
          var exampleValueV8 = CefV8Value.CreateString(ref exampleValue);
          v8Global->SetValueByKey(ref exampleKey, exampleValueV8, CefV8PropertyAttribute.ReadOnly | CefV8PropertyAttribute.DontDelete);
        }
        finally {
          v8Ctx->Exit();
          taskSuccess.Value = true;
          taskCompleted.Set();
        }
      });
      */

      //runner->PostTask(ref cefTask.Target.Task);

      //CefTask.PostTask(CefThreadId.Renderer, ref cefTask.Target.Task);

      /*var cefExtName = "v8/test-extension".CreateCefString();
      var cefExtCode =
        // language=javascript
        "native function v8_extension_test(); v8_extension_test();"
        .CreateCefString();

      RegisterExtension(ref cefExtName, ref cefExtCode, ref cefV8Handler.Target.V8Handler);*/

      if (!cts.TryReset())
        cts = new(2000);
      else
        cts.CancelAfter(2000);

      /*do CefApp.DoMessageLoopWork();
      while (!taskCompleted.Wait(0) && !cts.IsCancellationRequested);

      taskSuccess.Value.Should().BeTrue();*/

      var jsAlert = "alert(example)".CreateCefString();
      frame->ExecuteJavaScript(ref jsAlert, ref initUrl, 0);

      if (!cts.TryReset())
        cts = new(2000);
      else
        cts.CancelAfter(2000);

      do CefApp.DoMessageLoopWork();
      while (!cts.IsCancellationRequested);

      //CefApp.Shutdown();

      //testFinished.Cancel();

      //pipeThread.Join();

      //var host = browser->GetHost();
      //var maybeClient = host->GetClient();

      Thread.Sleep(1000);
    }
  }

}
