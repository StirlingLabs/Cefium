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
using static Cefium.Cef;
using Point = System.Windows.Point;

namespace Cefium.Tests;

public partial class Tests {

  [StructLayout(LayoutKind.Sequential)]
  private struct CefTestApp : ICefRefCountedBase<CefTestApp> {

    public CefApp Base;

    public ulong Cookie;

    static void ICefRefCountedBase<CefTestApp>.Initialize(ref CefTestApp self)
      => self.Cookie = 0x123456789ABCDEF;

  }

  private struct CefTestBrowserViewDelegate : ICefRefCountedBase<CefTestBrowserViewDelegate> {

    public CefBrowserViewDelegate Base;

    private int _ExecutedInit;

    public unsafe CefBrowser* Browser;

    public unsafe CefWindow* Window;

    static unsafe void ICefRefCountedBase<CefTestBrowserViewDelegate>.Initialize(ref CefTestBrowserViewDelegate self) {
      //self.ViewDelegate._GetMinimumSize
      self._ExecutedInit = 0;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
      static void OnWindowChanged(CefViewDelegate* _self, CefView* view, int added) {
        var self = (CefTestBrowserViewDelegate*) _self;
        if (added != 0) {
          self->Window = view->GetWindow();

          if (view->_SetBackgroundColor is not null)
            view->_SetBackgroundColor(view, 0x00000000);

          [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
          static uint GetBackgroundColor(CefView* _) => 0;
          view->_GetBackgroundColor = &GetBackgroundColor;
          self->Window->Base.Base._GetBackgroundColor = &GetBackgroundColor;
        }
        else
          self->Window = null;
      }

      self.Base.Base._OnWindowChanged = &OnWindowChanged;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
      static void OnBrowserCreated(CefBrowserViewDelegate* _self, CefBrowserView* view, CefBrowser* browser) {
        var self = (CefTestBrowserViewDelegate*) _self;

        if (view->Base._SetBackgroundColor is not null)
          view->Base._SetBackgroundColor(&view->Base, 0x00000000);
        self->Browser = browser;
        if (browser is null)
          return;

        var frame = browser->GetMainFrame();
        if (frame is null)
          return;

        var jsAlert = "alert(\"CefTestBrowserViewDelegate\" + (invokeCSharp() ? example : \"Fail!\"))".CreateCefString();
        var dlgLoc = "CefTestBrowserViewDelegate".CreateCefString();
        frame->ExecuteJavaScript(ref jsAlert, ref dlgLoc, 0);
      }

      self.Base._OnBrowserCreated = &OnBrowserCreated;
    }

  }

  private struct CefTestWindowDelegate : ICefRefCountedBase<CefTestWindowDelegate> {

    public CefWindowDelegate Base;

    public unsafe CefBrowserView* BrowserView;

    static unsafe void ICefRefCountedBase<CefTestWindowDelegate>.Initialize(ref CefTestWindowDelegate self) {
      /*[UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
      static int IsFrameless(CefWindowDelegate* self, CefWindow* window) {
        return 1;
      }

      self.WindowDelegate._IsFrameless = &IsFrameless;*/

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
      static void OnWindowCreated(CefWindowDelegate* self, CefWindow* window) {
        if (window->Base.Base._SetBackgroundColor is not null)
          window->Base.Base._SetBackgroundColor(&window->Base.Base, 0x00000000);
        [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
        static uint GetBackgroundColor(CefView* _) => 0;
        window->Base.Base._GetBackgroundColor = &GetBackgroundColor;

        var v8Context = CefV8Context.GetCurrentContext();
        if (v8Context is not null) {
          v8Context->Enter();
          try {
          }
          finally {
            v8Context->Exit();
          }
        }

        //v8Context->Release();
      }

      self.Base._OnWindowCreated = &OnWindowCreated;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
      static void OnWindowDestroyed(CefWindowDelegate* self, CefWindow* window) {
        var view = ((CefTestWindowDelegate*) self)->BrowserView;
        view->Base.Base.Size.Should().Be((uint) Unsafe.SizeOf<CefBrowserView>());
        view->Release();
      }

      self.Base._OnWindowDestroyed = &OnWindowDestroyed;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
      static void OnWindowClosing(CefWindowDelegate* self, CefWindow* window) {
      }

      self.Base._OnWindowClosing = &OnWindowClosing;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
      static int WithStandardWindowButtons(CefWindowDelegate* self, CefWindow* window) {
        return 1;
      }

      self.Base._WithStandardWindowButtons = &WithStandardWindowButtons;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvCdecl)})]
      static int CanClose(CefWindowDelegate* self, CefWindow* window) {
        return 1;
      }

      self.Base._CanClose = &CanClose;
    }

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
  public unsafe void CefBrowserWindowTest() {
    //Environment.SetEnvironmentVariable("DXVK_LOG_PATH", @".");
    //Environment.SetEnvironmentVariable("DXVK_LOG_LEVEL", "debug");
    Environment.SetEnvironmentVariable("CHROME_HEADLESS", "0");
    Environment.SetEnvironmentVariable("CHROME_IPC_LOGGING", "1");
    Environment.SetEnvironmentVariable("CHROME_LOG_FILE", @"\\.\CON");

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

    static void EnableDpiAwareness() {
      [DllImport("user32", EntryPoint = "SetProcessDpiAwarenessContext", SetLastError = true)]
      [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
      static extern bool SetProcessDpiAwarenessContext(int value);

      SetProcessDpiAwarenessContext(-4); // DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2
    }

    EnableDpiAwareness();

    Cefium.Initialize();

    var lastProgress = 0f;
    while (Cefium.IsDownloading) {
      if (Cefium.DownloadProgress > lastProgress) {
        lastProgress = Cefium.DownloadProgress;
        Trace.WriteLine($"Download progress: {lastProgress:P}");
      }

      if (lastProgress >= 1f)
        break;

      Thread.Sleep(1);
    }

    if (!Cefium.IsReady)
      Trace.WriteLine("Extracting...");
    lastProgress = 0;

    while (!Cefium.IsReady) {
      if (Cefium.ExtractProgress > lastProgress) {
        lastProgress = Cefium.ExtractProgress;
        Trace.WriteLine($"Extraction progress: {lastProgress:P}");
      }

      if (lastProgress >= 1f)
        break;

      Thread.Sleep(1);
    }

    while (!Cefium.IsReady)
      Thread.Sleep(1);

    Trace.WriteLine("Ready!");

    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

    var settings = new CefSettings {
      ChromeRuntime = false,
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

    var cachePath = Path.Combine(Path.GetTempPath(), "Cefium", "Cache");
    cachePath.CreateCefString(out settings.CachePath);
    cachePath.CreateCefString(out settings.RootCachePath);

    //var userPath = Path.Combine(Cefium.LocalAppDataPathBase, "DefaultUser");
    //userPath.CreateCefString(out settings.UserDataPath);
    Cefium.LocalAppDataPath
      .CreateCefString(out settings.ResourcesDirPath);

    //var subProcPath = Path.Combine(Cefium.LocalAppDataPath, "subproc", "Cefium.Subprocess.exe");
    //subProcPath.CreateCefString(out settings.BrowserSubprocessPath);

    /* Mac only
    var fwPath = Cefium.FrameworkPath;
    fwPath.CreateCefString(out settings.FrameworkDirPath);
    */

    var cefApp = New<CefTestApp>();
    //cefApp.Ref.InitializeBase();
    cefApp.Target.Base.Base.Size.Should().NotBe(0);
    cefApp.Target.Cookie.Should().Be(0x123456789ABCDEFuL);

    unsafe {
      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnBeforeCommandLineProcessing(CefApp* self, CefString* processType, CefCommandLine* commandLine) {
        var app = (CefTestApp*) self;
        //var v8Ctx = CefV8Context.GetCurrentContext();

        commandLine->Reset();

        commandLine->ApplyCustomizations();

        //var logFileArg = "log-file".CreateCefString();
        /*
         var pipePath = $@"\\.\pipe\cefaloid-unit-tests-logging-{Environment.ProcessId}".CreateCefString();
        commandLine->AppendSwitchWithValue(ref logFileArg, ref pipePath);
        */
        //var logFilePath = $@"CONERR$".CreateCefString();
        //commandLine->AppendSwitchWithValue(ref logFileArg, ref logFilePath);

        /*
        var subprocessPathParam = CefString.CreateViaPin("browser-subprocess-path");
        var subprocessPathArg = CefString.CreateViaPin(Path.Combine(Cefium.LocalAppDataPath, "subproc", "Cefium.Subprocess.exe"));
        commandLine->AppendSwitchWithValue(ref subprocessPathParam, ref subprocessPathArg);
        */

        var result = commandLine->GetCommandLineString();

        var outStream = TestContext.Progress;
        outStream.WriteLine("Command line: ");
        outStream.WriteLine(result->AsCharSpan());
        outStream.Flush();
        result->Free();
      }

      cefApp.Target.Base.OnBeforeCommandLineProcessing = &OnBeforeCommandLineProcessing;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnRegisterCustomSchemes(CefApp* self, CefSchemeRegistrar* registrar) {
      }

      cefApp.Target.Base.OnRegisterCustomSchemes = &OnRegisterCustomSchemes;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefResourceBundleHandler* GetResourceBundleHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.Base.GetResourceBundleHandler = &GetResourceBundleHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefBrowserProcessHandler* GetBrowserProcessHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.Base.GetBrowserProcessHandler = &GetBrowserProcessHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefRenderProcessHandler* GetRenderProcessHandler(CefApp* self) {
        var v8Ctx = CefV8Context.GetCurrentContext();
        if (v8Ctx != null) {
          v8Ctx->Enter();
          try {
            var g = v8Ctx->GetGlobal();
            if (g is null) return null;

            var exampleKey = "example".CreateCefString();
            var exampleValue = "Success!".CreateCefString();
            //var exampleKeyV8 = CefV8Value.CreateString(ref exampleKey);
            var exampleValueV8 = CefV8Value.CreateString(ref exampleValue);
            g->SetValueByKey(ref exampleKey, exampleValueV8, CefV8PropertyAttribute.ReadOnly | CefV8PropertyAttribute.DontDelete);
            var cefHandler = New<CefDelegateV8Handler>();
            cefHandler.Target.SetHandler(static (name, o, count, arguments, retval, exception) => {
              var @true = CefV8Value.CreateBool(true);
              *retval = @true;

              return true;
            });
            var invokeCSharpStr = "invokeCSharp".CreateCefString();
            var invokeCSharpFunc = CefV8Value.CreateFunction(ref invokeCSharpStr, ref cefHandler.Target.V8Handler);
            g->SetValueByKey(ref invokeCSharpStr, invokeCSharpFunc, CefV8PropertyAttribute.ReadOnly | CefV8PropertyAttribute.DontDelete);
          }
          finally {
            v8Ctx->Exit();
          }
        }

        return null;
      }

      cefApp.Target.Base.GetRenderProcessHandler = &GetRenderProcessHandler;
    }

    var mainArgs = new CefMainArgs();
    mainArgs.ForWindows.InstanceHandle = default; //Marshal.GetHINSTANCE(typeof(Tests).Assembly.ManifestModule);

    /*
    var result = cefApp.Target.App.ExecuteProcess(ref mainArgs, null);

    result.Should().BeLessThan(0);
    */

    var success = cefApp.Target.Base.Initialize(ref mainArgs, ref settings);

    success.Should().BeTrue();

    Thread.Sleep(125);

    CefWindowInfo windowInfo = new() {
      WindowlessRenderingEnabled = false,
      //SharedTextureEnabled = true,
      //WindowName = "",
      Bounds = ((0, 0), (640, 480)),
      ForWindows = {
        Style = WindowStyle.PopupWindow,
        ExStyle = WindowStyleEx.Transparent | WindowStyleEx.Layered | WindowStyleEx.Composited
      }
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
      EnableWebGL = CefState.Enabled,
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

      var initUrl = "data:text/plain,Loaded"
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
      cts.CancelAfter(100);
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
        cts = new(100);
      else
        cts.CancelAfter(100);

      /*do CefApp.DoMessageLoopWork();
      while (!taskCompleted.Wait(0) && !cts.IsCancellationRequested);

      taskSuccess.Value.Should().BeTrue();*/

      var jsAlert = "alert(invokeCSharp() ? example : \"Fail!\")".CreateCefString();
      frame->ExecuteJavaScript(ref jsAlert, ref initUrl, 0);

      if (!cts.TryReset())
        cts = new(100);
      else
        cts.CancelAfter(100);

      do CefApp.DoMessageLoopWork();
      while (!cts.IsCancellationRequested);

      //CefApp.Shutdown();

      //testFinished.Cancel();

      //pipeThread.Join();

      //var host = browser->GetHost();
      //var maybeClient = host->GetClient();
      Thread.Sleep(100);

      if (Debugger.IsAttached) {
        bool shutdown = false;
        new Thread(() => {
          MessageBox.Show("Click OK to terminate the test.");
          shutdown = true;
        }).UnsafeStart();

        while (!shutdown)
          CefApp.DoMessageLoopWork();
        /*CefApp.Shutdown();
        var t = Stopwatch.StartNew();
        do
          CefApp.DoMessageLoopWork();
        while (t.ElapsedMilliseconds < 100);*/
      }
    }
  }

  [Test]
  public unsafe void CefChromeBrowserWindowTest() {
    //Environment.SetEnvironmentVariable("DXVK_LOG_PATH", @".");
    //Environment.SetEnvironmentVariable("DXVK_LOG_LEVEL", "debug");
    Environment.SetEnvironmentVariable("CHROME_HEADLESS", "0");
    Environment.SetEnvironmentVariable("CHROME_IPC_LOGGING", "1");
    Environment.SetEnvironmentVariable("CHROME_LOG_FILE", @"\\.\CON");

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

    static void EnableDpiAwareness() {
      [DllImport("user32", EntryPoint = "SetProcessDpiAwarenessContext", SetLastError = true)]
      [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
      static extern bool SetProcessDpiAwarenessContext(int value);

      SetProcessDpiAwarenessContext(-4); // DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2
    }

    EnableDpiAwareness();

    Cefium.Initialize();

    var lastProgress = 0f;
    while (Cefium.IsDownloading) {
      if (Cefium.DownloadProgress > lastProgress) {
        lastProgress = Cefium.DownloadProgress;
        Trace.WriteLine($"Download progress: {lastProgress:P}");
      }

      if (lastProgress >= 1f)
        break;

      Thread.Sleep(1);
    }

    if (!Cefium.IsReady)
      Trace.WriteLine("Extracting...");
    lastProgress = 0;

    while (!Cefium.IsReady) {
      if (Cefium.ExtractProgress > lastProgress) {
        lastProgress = Cefium.ExtractProgress;
        Trace.WriteLine($"Extraction progress: {lastProgress:P}");
      }

      if (lastProgress >= 1f)
        break;

      Thread.Sleep(1);
    }

    while (!Cefium.IsReady)
      Thread.Sleep(1);

    Trace.WriteLine("Ready!");

    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

    var settings = new CefSettings {
      ChromeRuntime = true,
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

    var cachePath = Path.Combine(Path.GetTempPath(), "Cefium", "Cache");
    cachePath.CreateCefString(out settings.CachePath);
    cachePath.CreateCefString(out settings.RootCachePath);

    //var userPath = Path.Combine(Cefium.LocalAppDataPathBase, "DefaultUser");
    //userPath.CreateCefString(out settings.UserDataPath);
    Cefium.LocalAppDataPath
      .CreateCefString(out settings.ResourcesDirPath);

    //var subProcPath = Path.Combine(Cefium.LocalAppDataPath, "subproc", "Cefium.Subprocess.exe");
    //subProcPath.CreateCefString(out settings.BrowserSubprocessPath);

    /* Mac only
    var fwPath = Cefium.FrameworkPath;
    fwPath.CreateCefString(out settings.FrameworkDirPath);
    */

    var cefApp = New<CefTestApp>();
    //cefApp.Ref.InitializeBase();
    cefApp.Target.Base.Base.Size.Should().NotBe(0);
    cefApp.Target.Cookie.Should().Be(0x123456789ABCDEFuL);

    unsafe {
      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnBeforeCommandLineProcessing(CefApp* self, CefString* processType, CefCommandLine* commandLine) {
        var app = (CefTestApp*) self;
        //var v8Ctx = CefV8Context.GetCurrentContext();

        commandLine->Reset();

        commandLine->ApplyCustomizations();

        //var logFileArg = "log-file".CreateCefString();
        /*
         var pipePath = $@"\\.\pipe\cefaloid-unit-tests-logging-{Environment.ProcessId}".CreateCefString();
        commandLine->AppendSwitchWithValue(ref logFileArg, ref pipePath);
        */
        //var logFilePath = $@"CONERR$".CreateCefString();
        //commandLine->AppendSwitchWithValue(ref logFileArg, ref logFilePath);

        /*
        var subprocessPathParam = CefString.CreateViaPin("browser-subprocess-path");
        var subprocessPathArg = CefString.CreateViaPin(Path.Combine(Cefium.LocalAppDataPath, "subproc", "Cefium.Subprocess.exe"));
        commandLine->AppendSwitchWithValue(ref subprocessPathParam, ref subprocessPathArg);
        */

        var result = commandLine->GetCommandLineString();

        var outStream = TestContext.Progress;
        outStream.WriteLine("Command line: ");
        outStream.WriteLine(result->AsCharSpan());
        outStream.Flush();
        result->Free();
      }

      cefApp.Target.Base.OnBeforeCommandLineProcessing = &OnBeforeCommandLineProcessing;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnRegisterCustomSchemes(CefApp* self, CefSchemeRegistrar* registrar) {
      }

      cefApp.Target.Base.OnRegisterCustomSchemes = &OnRegisterCustomSchemes;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefResourceBundleHandler* GetResourceBundleHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.Base.GetResourceBundleHandler = &GetResourceBundleHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefBrowserProcessHandler* GetBrowserProcessHandler(CefApp* self) {
        return null;
      }

      cefApp.Target.Base.GetBrowserProcessHandler = &GetBrowserProcessHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefRenderProcessHandler* GetRenderProcessHandler(CefApp* self) {
        var v8Ctx = CefV8Context.GetCurrentContext();
        if (v8Ctx != null) {
          v8Ctx->Enter();
          try {
            var g = v8Ctx->GetGlobal();
            if (g is null) return null;

            var exampleKey = "example".CreateCefString();
            var exampleValue = "Success!".CreateCefString();
            //var exampleKeyV8 = CefV8Value.CreateString(ref exampleKey);
            var exampleValueV8 = CefV8Value.CreateString(ref exampleValue);
            g->SetValueByKey(ref exampleKey, exampleValueV8, CefV8PropertyAttribute.ReadOnly | CefV8PropertyAttribute.DontDelete);
            var cefHandler = New<CefDelegateV8Handler>();
            cefHandler.Target.SetHandler(static (name, o, count, arguments, retval, exception) => {
              var @true = CefV8Value.CreateBool(true);
              *retval = @true;

              return true;
            });
            var invokeCSharpStr = "invokeCSharp".CreateCefString();
            var invokeCSharpFunc = CefV8Value.CreateFunction(ref invokeCSharpStr, ref cefHandler.Target.V8Handler);
            g->SetValueByKey(ref invokeCSharpStr, invokeCSharpFunc, CefV8PropertyAttribute.ReadOnly | CefV8PropertyAttribute.DontDelete);
          }
          finally {
            v8Ctx->Exit();
          }
        }

        return null;
      }

      cefApp.Target.Base.GetRenderProcessHandler = &GetRenderProcessHandler;
    }

    var mainArgs = new CefMainArgs();
    mainArgs.ForWindows.InstanceHandle = default; //Marshal.GetHINSTANCE(typeof(Tests).Assembly.ManifestModule);

    /*
    var result = cefApp.Target.App.ExecuteProcess(ref mainArgs, null);

    result.Should().BeLessThan(0);
    */

    var success = cefApp.Target.Base.Initialize(ref mainArgs, ref settings);

    success.Should().BeTrue();

    Thread.Sleep(125);

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

      var initUrl = "data:text/plain,Loaded"
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
      cts.CancelAfter(100);
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
        cts = new(100);
      else
        cts.CancelAfter(100);

      /*do CefApp.DoMessageLoopWork();
      while (!taskCompleted.Wait(0) && !cts.IsCancellationRequested);

      taskSuccess.Value.Should().BeTrue();*/

      var jsAlert = "alert(invokeCSharp() ? example : \"Fail!\")".CreateCefString();
      frame->ExecuteJavaScript(ref jsAlert, ref initUrl, 0);

      if (!cts.TryReset())
        cts = new(100);
      else
        cts.CancelAfter(100);

      do CefApp.DoMessageLoopWork();
      while (!cts.IsCancellationRequested);

      //CefApp.Shutdown();

      //testFinished.Cancel();

      //pipeThread.Join();

      //var host = browser->GetHost();
      //var maybeClient = host->GetClient();
      Thread.Sleep(100);

      if (Debugger.IsAttached) {
        bool shutdown = false;
        new Thread(() => {
          MessageBox.Show("Click OK to terminate the test.");
          shutdown = true;
        }).UnsafeStart();

        while (!shutdown)
          CefApp.DoMessageLoopWork();
        /*CefApp.Shutdown();
        var t = Stopwatch.StartNew();
        do
          CefApp.DoMessageLoopWork();
        while (t.ElapsedMilliseconds < 100);*/
      }
    }
  }

  [Test]
  public unsafe void CefChromeViewTest() {
    //Environment.SetEnvironmentVariable("DXVK_LOG_PATH", @".");
    //Environment.SetEnvironmentVariable("DXVK_LOG_LEVEL", "debug");
    Environment.SetEnvironmentVariable("CHROME_HEADLESS", "0");
    Environment.SetEnvironmentVariable("CHROME_IPC_LOGGING", "1");
    Environment.SetEnvironmentVariable("CHROME_LOG_FILE", @"\\.\CON");

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

    static void EnableDpiAwareness() {
      [DllImport("user32", EntryPoint = "SetProcessDpiAwarenessContext", SetLastError = true)]
      [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
      static extern bool SetProcessDpiAwarenessContext(int value);

      SetProcessDpiAwarenessContext(-4); // DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2
    }

    EnableDpiAwareness();

    Cefium.Initialize();

    var lastProgress = 0f;
    while (Cefium.IsDownloading) {
      if (Cefium.DownloadProgress > lastProgress) {
        lastProgress = Cefium.DownloadProgress;
        Trace.WriteLine($"Download progress: {lastProgress:P}");
      }

      if (lastProgress >= 1f)
        break;

      Thread.Sleep(1);
    }

    if (!Cefium.IsReady)
      Trace.WriteLine("Extracting...");
    lastProgress = 0;

    while (!Cefium.IsReady) {
      if (Cefium.ExtractProgress > lastProgress) {
        lastProgress = Cefium.ExtractProgress;
        Trace.WriteLine($"Extraction progress: {lastProgress:P}");
      }

      if (lastProgress >= 1f)
        break;

      Thread.Sleep(1);
    }

    while (!Cefium.IsReady)
      Thread.Sleep(1);

    Trace.WriteLine("Ready!");

    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

    var settings = new CefSettings {
      ChromeRuntime = true,
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

    var cachePath = Path.Combine(Path.GetTempPath(), "Cefium", "Cache");
    cachePath.CreateCefString(out settings.CachePath);
    cachePath.CreateCefString(out settings.RootCachePath);

    //var userPath = Path.Combine(Cefium.LocalAppDataPathBase, "DefaultUser");
    //userPath.CreateCefString(out settings.UserDataPath);
    Cefium.LocalAppDataPath
      .CreateCefString(out settings.ResourcesDirPath);

    //var subProcPath = Path.Combine(Cefium.LocalAppDataPath, "subproc", "Cefium.Subprocess.exe");
    //subProcPath.CreateCefString(out settings.BrowserSubprocessPath);

    /* Mac only
    var fwPath = Cefium.FrameworkPath;
    fwPath.CreateCefString(out settings.FrameworkDirPath);
    */

    var cefApp = New<CefTestApp>();
    //cefApp.Ref.InitializeBase();
    cefApp.Target.Base.Base.Size.Should().NotBe(0);
    cefApp.Target.Cookie.Should().Be(0x123456789ABCDEFuL);

    unsafe {
      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnBeforeCommandLineProcessing(CefApp* self, CefString* processType, CefCommandLine* commandLine) {
        var app = (CefTestApp*) self;
        //var v8Ctx = CefV8Context.GetCurrentContext();

        commandLine->Reset();

        commandLine->ApplyCustomizations();

        //var logFileArg = "log-file".CreateCefString();
        /*
         var pipePath = $@"\\.\pipe\cefaloid-unit-tests-logging-{Environment.ProcessId}".CreateCefString();
        commandLine->AppendSwitchWithValue(ref logFileArg, ref pipePath);
        */
        //var logFilePath = $@"CONERR$".CreateCefString();
        //commandLine->AppendSwitchWithValue(ref logFileArg, ref logFilePath);

        /*
        var subprocessPathParam = CefString.CreateViaPin("browser-subprocess-path");
        var subprocessPathArg = CefString.CreateViaPin(Path.Combine(Cefium.LocalAppDataPath, "subproc", "Cefium.Subprocess.exe"));
        commandLine->AppendSwitchWithValue(ref subprocessPathParam, ref subprocessPathArg);
        */

        var result = commandLine->GetCommandLineString();

        var outStream = TestContext.Progress;
        outStream.WriteLine("Command line: ");
        outStream.WriteLine(result->AsCharSpan());
        outStream.Flush();
        result->Free();
      }

      cefApp.Target.Base.OnBeforeCommandLineProcessing = &OnBeforeCommandLineProcessing;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static void OnRegisterCustomSchemes(CefApp* self, CefSchemeRegistrar* registrar) {
      }

      cefApp.Target.Base.OnRegisterCustomSchemes = &OnRegisterCustomSchemes;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefResourceBundleHandler* GetResourceBundleHandler(CefApp* self) {
        var v8Ctx = CefV8Context.GetCurrentContext();
        if (v8Ctx != null) {
          v8Ctx->Enter();
          v8Ctx->Exit();
          return null;
        }

        return null;
      }

      cefApp.Target.Base.GetResourceBundleHandler = &GetResourceBundleHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefBrowserProcessHandler* GetBrowserProcessHandler(CefApp* self) {
        var v8Ctx = CefV8Context.GetCurrentContext();
        if (v8Ctx != null) {
          v8Ctx->Enter();
          v8Ctx->Exit();
          return null;
        }

        return null;
      }

      cefApp.Target.Base.GetBrowserProcessHandler = &GetBrowserProcessHandler;

      [UnmanagedCallersOnly(CallConvs = new[] {typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)})]
      static CefRenderProcessHandler* GetRenderProcessHandler(CefApp* self) {
        var v8Ctx = CefV8Context.GetCurrentContext();
        if (v8Ctx != null) {
          v8Ctx->Enter();
          try {
            var g = v8Ctx->GetGlobal();
            if (g is null)
              return null;

            var locationKey = "location".CreateCefString();
            var hrefKey = "href".CreateCefString();
            //var toStringKey = "toString".CreateCefString();
            var location = g->GetValueByKey(ref locationKey);
            if (location is null)
              return null;

            var locationHref = location->GetValueByKey(ref hrefKey);
            if (locationHref is null)
              return null;

            var locationHrefStr = locationHref->GetStringValue();

            if (locationHrefStr is null)
              return null;

            var locationHrefStrSpan = locationHrefStr->AsCharSpan();
            if (locationHrefStrSpan.IsEmpty)
              return null;

            var locationHrefResult = new string(locationHrefStrSpan);
            if (locationHrefResult != "data:text/plain,Loaded")
              // don't inject if we're not at the right location
              return null;

            var exampleKey = "example".CreateCefString();
            var exampleValue = "Success!".CreateCefString();
            //var exampleKeyV8 = CefV8Value.CreateString(ref exampleKey);
            var exampleValueV8 = CefV8Value.CreateString(ref exampleValue);
            g->SetValueByKey(ref exampleKey, exampleValueV8, CefV8PropertyAttribute.ReadOnly | CefV8PropertyAttribute.DontDelete);
            var cefHandler = New<CefDelegateV8Handler>();
            cefHandler.Target.SetHandler(static (name, o, count, arguments, retval, exception) => {
              var @true = CefV8Value.CreateBool(true);
              *retval = @true;

              return true;
            });
            var invokeCSharpStr = "invokeCSharp".CreateCefString();
            var invokeCSharpFunc = CefV8Value.CreateFunction(ref invokeCSharpStr, ref cefHandler.Target.V8Handler);
            g->SetValueByKey(ref invokeCSharpStr, invokeCSharpFunc, CefV8PropertyAttribute.ReadOnly | CefV8PropertyAttribute.DontDelete);

            /*var jsAlert = "requestIdleCallback(() => alert(invokeCSharp() ? example : \"Fail!\"))"
              .CreateCefString();
            CefV8Exception* exception = null;
            CefV8Value* retVal = null;
            v8Ctx->Eval(ref jsAlert, locationHrefStr, 0, ref retVal, ref exception);
            if (exception is not null) {
              var msg = exception->GetMessage();
              var msgStr = new string(msg->AsCharSpan());
              if (Debugger.IsAttached)
                Debugger.Log(5, "Error", msgStr);
              msg->Free();
              exception->Release();
            }

            if (retVal is not null)
              retVal->Release();*/
          }
          finally {
            v8Ctx->Exit();
          }
        }

        return null;
      }

      cefApp.Target.Base.GetRenderProcessHandler = &GetRenderProcessHandler;
    }

    var mainArgs = new CefMainArgs();
    mainArgs.ForWindows.InstanceHandle = default; //Marshal.GetHINSTANCE(typeof(Tests).Assembly.ManifestModule);

    /*
    var result = cefApp.Target.App.ExecuteProcess(ref mainArgs, null);

    result.Should().BeLessThan(0);
    */

    var success = cefApp.Target.Base.Initialize(ref mainArgs, ref settings);

    success.Should().BeTrue();

    Thread.Sleep(125);

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
      EnableWebGL = CefState.Enabled,
      BackgroundColor = 0x00000000,
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

      var initUrl = "data:text/plain,Loaded"
        .CreateCefString();

      /*var created = CefBrowserHost.CreateBrowser(
        ref windowInfo,
        client,
        ref initUrl,
        ref browserSettings,
        extraInfo
      );

      created.Should().BeTrue();*/

      var dlgView = New<CefTestBrowserViewDelegate>();
      var view = CefBrowserView.Create(
        client,
        ref initUrl,
        ref browserSettings,
        extraInfo,
        @delegate: &dlgView.Pointer->Base
      );
      view->Base.Base.Size.Should().Be((nuint) Unsafe.SizeOf<CefBrowserView>());

      (view == null).Should().BeFalse();

      var dlgWnd = New<CefTestWindowDelegate>();
      view->Base.AddRef();
      view->Base.Base.Size.Should().Be((nuint) Unsafe.SizeOf<CefBrowserView>());
      dlgWnd.Target.BrowserView = view;
      dlgWnd.Target.BrowserView->Base.Base.Size.Should().Be((nuint) Unsafe.SizeOf<CefBrowserView>());
      var window = CefWindow.CreateTopLevel(&dlgWnd.Pointer->Base);
      window->Base.AddChildView(&view->Base);
      window->Show();

      var hWnd = window->GetWindowHandle();

      /*
      var blurBehind = new DwmBlurBehind {
        Flags = DwmBlurBehindFlags.Enable,
        Enable = true,
        HRgnBlur = null
      };
      DwmEnableBlurBehindWindow(hWnd, &blurBehind);

      var margins = new WindowMargins {Left = -1, Right = -1, Top = -1, Bottom = -1};
      DwmExtendFrameIntoClientArea(hWnd, &margins);
      */

      //view->Base._RequestFocus(&view->Base);

      var cts = new CancellationTokenSource();
      cts.CancelAfter(100);
      do CefApp.DoMessageLoopWork();
      while (!cts.IsCancellationRequested);

      var browser = view->GetBrowser();

      (browser == null).Should().BeFalse();

      var toolbar = view->GetChromeToolbar();

      (toolbar == null).Should().BeTrue();

      if (!cts.TryReset())
        cts = new(100);
      else
        cts.CancelAfter(100);

      //var jsAlert = "alert(invokeCSharp() ? example : \"Fail!\")".CreateCefString();
      //frame->ExecuteJavaScript(ref jsAlert, ref initUrl, 0);

      /*
      var jsAlert = "alert(invokeCSharp() ? example : \"Fail!\")".CreateCefString();
      frame->ExecuteJavaScript(ref jsAlert, ref initUrl, 0);

      if (!cts.TryReset())
        cts = new(100);
      else
        cts.CancelAfter(100);*/

      do CefApp.DoMessageLoopWork();
      while (!cts.IsCancellationRequested);

      //CefApp.Shutdown();

      //testFinished.Cancel();

      //pipeThread.Join();

      //var host = browser->GetHost();
      //var maybeClient = host->GetClient();
      Thread.Sleep(100);

      if (Debugger.IsAttached) {
        var shutdown = false;
        new Thread(() => {
          MessageBox.Show("Click OK to terminate the test.");
          shutdown = true;
        }).UnsafeStart();

        while (!shutdown)
          CefApp.DoMessageLoopWork();
        /*CefApp.Shutdown();
        var t = Stopwatch.StartNew();
        do
          CefApp.DoMessageLoopWork();
        while (t.ElapsedMilliseconds < 100);*/
      }
    }
  }

}
