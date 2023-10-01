namespace Cefium;

/// <inheritdoc cref="CefCommandLine"/>
[PublicAPI]
public static class CefCommandLineExtensions {

  /// <inheritdoc cref="CefCommandLine._IsValid"/>
  public static unsafe bool IsValid(ref this CefCommandLine self)
    => self._IsValid is not null && self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefCommandLine self)
    => self._IsReadOnly is not null && self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._Copy"/>
  public static unsafe CefCommandLine* Copy(ref this CefCommandLine self)
    => self._Copy is not null ? self._Copy(self.AsPointer()) : default;

  /// <inheritdoc cref="CefCommandLine._InitFromArgv"/>
  public static unsafe bool InitFromArgv(ref this CefCommandLine self, int argc, char** argv) {
    if (self._InitFromArgv is null) return false;

    self._InitFromArgv(self.AsPointer(), argc, argv);
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._InitFromString"/>
  public static unsafe bool InitFromString(ref this CefCommandLine self, ref CefString commandLine) {
    if (self._InitFromString is null) return false;

    self._InitFromString(self.AsPointer(), commandLine.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._Reset"/>
  public static unsafe bool Reset(ref this CefCommandLine self) {
    if (self._Reset is null) return false;

    self._Reset(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._GetArgv"/>
  public static unsafe bool GetArgv(ref this CefCommandLine self, ref CefStringList argv) {
    if (self._GetArgv is null) return false;

    self._GetArgv(self.AsPointer(), argv.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._GetCommandLineString"/>
  public static unsafe CefStringUserFree* GetCommandLineString(ref this CefCommandLine self)
    => self._GetCommandLineString is not null ? self._GetCommandLineString(self.AsPointer()) : default;

  /// <inheritdoc cref="CefCommandLine._GetProgram"/>
  public static unsafe CefStringUserFree* GetProgram(ref this CefCommandLine self)
    => self._GetProgram is not null ? self._GetProgram(self.AsPointer()) : default;

  /// <inheritdoc cref="CefCommandLine._SetProgram"/>
  public static unsafe bool SetProgram(ref this CefCommandLine self, ref CefString program) {
    if (self._SetProgram is null) return false;

    self._SetProgram(self.AsPointer(), program.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._HasSwitches"/>
  public static unsafe bool HasSwitches(ref this CefCommandLine self)
    => self._HasSwitches is not null && self._HasSwitches(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._HasSwitch"/>
  public static unsafe bool HasSwitch(ref this CefCommandLine self, ref CefString name)
    => self._HasSwitch is not null && self._HasSwitch(self.AsPointer(), name.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._GetSwitchValue"/>
  public static unsafe CefStringUserFree* GetSwitchValue(ref this CefCommandLine self, ref CefString name)
    => self._GetSwitchValue is not null ? self._GetSwitchValue(self.AsPointer(), name.AsPointer()) : default;

  /// <inheritdoc cref="CefCommandLine._GetSwitches"/>
  public static unsafe bool GetSwitches(ref this CefCommandLine self, CefStringMap* switches) {
    if (self._GetSwitches is null) return false;

    self._GetSwitches(self.AsPointer(), switches);
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._AppendSwitch"/>
  public static unsafe bool AppendSwitch(ref this CefCommandLine self, in CefString name) {
    if (self._AppendSwitch is null) return false;

    self._AppendSwitch(self.AsPointer(), Unsafe.AsRef(name).AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._AppendSwitchWithValue"/>
  public static unsafe bool AppendSwitchWithValue(ref this CefCommandLine self, in CefString name, in CefString value) {
    if (self._AppendSwitchWithValue is null) return false;

    self._AppendSwitchWithValue(self.AsPointer(), Unsafe.AsRef(name).AsPointer(), Unsafe.AsRef(value).AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._HasArguments"/>
  public static unsafe bool HasArguments(ref this CefCommandLine self)
    => self._HasArguments is not null && self._HasArguments(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefCommandLine._GetArguments"/>
  public static unsafe bool GetArguments(ref this CefCommandLine self, CefStringList* arguments) {
    if (self._GetArguments is null) return false;

    self._GetArguments(self.AsPointer(), arguments);
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._AppendArgument"/>
  public static unsafe bool AppendArgument(ref this CefCommandLine self, ref CefString argument) {
    if (self._AppendArgument is null) return false;

    self._AppendArgument(self.AsPointer(), argument.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefCommandLine._PrependWrapper"/>
  public static unsafe bool PrependWrapper(ref this CefCommandLine self, ref CefString wrapper) {
    if (self._PrependWrapper is null) return false;

    self._PrependWrapper(self.AsPointer(), wrapper.AsPointer());
    return true;
  }

}
