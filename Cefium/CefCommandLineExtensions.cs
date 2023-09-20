namespace Cefium;

/// <inheritdoc cref="CefCommandLine"/>
[PublicAPI]
public static class CefCommandLineExtensions {

  /// <inheritdoc cref="CefCommandLine._IsValid"/>
  public static unsafe bool IsValid(ref this CefCommandLine self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefCommandLine self) => self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._Copy"/>
  public static unsafe CefCommandLine* Copy(ref this CefCommandLine self) => self._Copy(self.AsPointer());

  /// <inheritdoc cref="CefCommandLine._InitFromArgv"/>
  public static unsafe void InitFromArgv(ref this CefCommandLine self, int argc, char** argv) => self._InitFromArgv(self.AsPointer(), argc, argv);

  /// <inheritdoc cref="CefCommandLine._InitFromString"/>
  public static unsafe void InitFromString(ref this CefCommandLine self, ref CefString commandLine) => self._InitFromString(self.AsPointer(), commandLine.AsPointer());

  /// <inheritdoc cref="CefCommandLine._Reset"/>
  public static unsafe void Reset(ref this CefCommandLine self) => self._Reset(self.AsPointer());

  /// <inheritdoc cref="CefCommandLine._GetArgv"/>
  public static unsafe void GetArgv(ref this CefCommandLine self, ref CefStringList argv) => self._GetArgv(self.AsPointer(), argv.AsPointer());

  /// <inheritdoc cref="CefCommandLine._GetCommandLineString"/>
  public static unsafe CefStringUserFree* GetCommandLineString(ref this CefCommandLine self) => self._GetCommandLineString(self.AsPointer());

  /// <inheritdoc cref="CefCommandLine._GetProgram"/>
  public static unsafe CefStringUserFree* GetProgram(ref this CefCommandLine self) => self._GetProgram(self.AsPointer());

  /// <inheritdoc cref="CefCommandLine._SetProgram"/>
  public static unsafe void SetProgram(ref this CefCommandLine self, ref CefString program) => self._SetProgram(self.AsPointer(), program.AsPointer());

  /// <inheritdoc cref="CefCommandLine._HasSwitches"/>
  public static unsafe bool HasSwitches(ref this CefCommandLine self) => self._HasSwitches(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._HasSwitch"/>
  public static unsafe bool HasSwitch(ref this CefCommandLine self, ref CefString name) => self._HasSwitch(self.AsPointer(), name.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._GetSwitchValue"/>
  public static unsafe CefStringUserFree* GetSwitchValue(ref this CefCommandLine self, ref CefString name) => self._GetSwitchValue(self.AsPointer(), name.AsPointer());

  /// <inheritdoc cref="CefCommandLine._GetSwitches"/>
  public static unsafe void GetSwitches(ref this CefCommandLine self, CefStringMap* switches) => self._GetSwitches(self.AsPointer(), switches);

  /// <inheritdoc cref="CefCommandLine._AppendSwitch"/>
  public static unsafe void AppendSwitch(ref this CefCommandLine self, ref CefString name) => self._AppendSwitch(self.AsPointer(), name.AsPointer());

  /// <inheritdoc cref="CefCommandLine._AppendSwitchWithValue"/>
  public static unsafe void AppendSwitchWithValue(ref this CefCommandLine self, ref CefString name, ref CefString value) => self._AppendSwitchWithValue(self.AsPointer(), name.AsPointer(), value.AsPointer());

  /// <inheritdoc cref="CefCommandLine._HasArguments"/>
  public static unsafe bool HasArguments(ref this CefCommandLine self) => self._HasArguments(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._GetArguments"/>
  public static unsafe void GetArguments(ref this CefCommandLine self, CefStringList* arguments) => self._GetArguments(self.AsPointer(), arguments);

  /// <inheritdoc cref="CefCommandLine._AppendArgument"/>
  public static unsafe void AppendArgument(ref this CefCommandLine self, ref CefString argument) => self._AppendArgument(self.AsPointer(), argument.AsPointer());

  /// <inheritdoc cref="CefCommandLine._PrependWrapper"/>
  public static unsafe void PrependWrapper(ref this CefCommandLine self, ref CefString wrapper) => self._PrependWrapper(self.AsPointer(), wrapper.AsPointer());

}
