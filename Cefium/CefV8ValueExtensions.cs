namespace Cefium;

/// <inheritdoc cref="CefV8Value"/>
[PublicAPI]
public static class CefV8ValueExtensions {

  /// <inheritdoc cref="CefV8Value._IsValid"/>
  public static unsafe bool IsValid(ref this CefV8Value self)
    => self._IsValid is not null && self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsUndefined"/>
  public static unsafe bool IsUndefined(ref this CefV8Value self)
    => self._IsUndefined is not null && self._IsUndefined(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsNull"/>
  public static unsafe bool IsNull(ref this CefV8Value self)
    => self._IsNull is not null && self._IsNull(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsBool"/>
  public static unsafe bool IsBool(ref this CefV8Value self)
    => self._IsBool is not null && self._IsBool(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsInt"/>
  public static unsafe bool IsInt(ref this CefV8Value self)
    => self._IsInt is not null && self._IsInt(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsUInt"/>
  public static unsafe bool IsUInt(ref this CefV8Value self)
    => self._IsUInt is not null && self._IsUInt(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsDouble"/>
  public static unsafe bool IsDouble(ref this CefV8Value self)
    => self._IsDouble is not null && self._IsDouble(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsDate"/>
  public static unsafe bool IsDate(ref this CefV8Value self)
    => self._IsDate is not null && self._IsDate(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsString"/>
  public static unsafe bool IsString(ref this CefV8Value self)
    => self._IsString is not null && self._IsString(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsObject"/>
  public static unsafe bool IsObject(ref this CefV8Value self)
    => self._IsObject is not null && self._IsObject(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsArray"/>
  public static unsafe bool IsArray(ref this CefV8Value self)
    => self._IsArray is not null && self._IsArray(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsFunction"/>
  public static unsafe bool IsFunction(ref this CefV8Value self)
    => self._IsFunction is not null && self._IsFunction(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsSame"/>
  public static unsafe bool IsSame(ref this CefV8Value self, ref CefV8Value that)
    => self._IsSame is not null && self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._GetBoolValue"/>
  public static unsafe bool GetBoolValue(ref this CefV8Value self)
    => self._GetBoolValue is not null && self._GetBoolValue(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._GetIntValue"/>
  public static unsafe int GetIntValue(ref this CefV8Value self)
    => self._GetIntValue is not null ? self._GetIntValue(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._GetUIntValue"/>
  public static unsafe uint GetUIntValue(ref this CefV8Value self)
    => self._GetUIntValue is not null ? self._GetUIntValue(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._GetDoubleValue"/>
  public static unsafe double GetDoubleValue(ref this CefV8Value self)
    => self._GetDoubleValue is not null ? self._GetDoubleValue(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._GetDateValue"/>
  public static unsafe CefBaseTime GetDateValue(ref this CefV8Value self)
    => self._GetDateValue is not null ? self._GetDateValue(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._GetStringValue"/>
  public static unsafe CefString* GetStringValue(ref this CefV8Value self)
    => self._GetStringValue is not null ? self._GetStringValue(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._IsUserCreated"/>
  public static unsafe bool IsUserCreated(ref this CefV8Value self)
    => self._IsUserCreated is not null && self._IsUserCreated(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._HasException"/>
  public static unsafe bool HasException(ref this CefV8Value self)
    => self._HasException is not null && self._HasException(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._GetException"/>
  public static unsafe CefV8Exception* GetException(ref this CefV8Value self)
    => self._GetException is not null ? self._GetException(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._ClearException"/>
  public static unsafe bool ClearException(ref this CefV8Value self) {
    if (self._ClearException is null) return false;

    self._ClearException(self.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefV8Value._WillRethrowExceptions"/>
  public static unsafe bool WillRethrowExceptions(ref this CefV8Value self)
    => self._WillRethrowExceptions is not null && self._WillRethrowExceptions(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._SetRethrowExceptions"/>
  public static unsafe bool SetRethrowExceptions(ref this CefV8Value self, bool rethrow) {
    if (self._SetRethrowExceptions is null) return false;

    self._SetRethrowExceptions(self.AsPointer(), rethrow ? 1 : 0);
    return true;
  }

  /// <inheritdoc cref="CefV8Value._HasValueByKey"/>
  public static unsafe bool HasValueByKey(ref this CefV8Value self, ref CefString key)
    => self._HasValueByKey is not null && self._HasValueByKey(self.AsPointer(), key.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._DeleteValueByKey"/>
  public static unsafe bool DeleteValueByKey(ref this CefV8Value self, ref CefString key)
    => self._DeleteValueByKey is not null && self._DeleteValueByKey(self.AsPointer(), key.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._GetValueByKey"/>
  public static unsafe CefV8Value* GetValueByKey(ref this CefV8Value self, ref CefString key)
    => self._GetValueByKey is not null ? self._GetValueByKey(self.AsPointer(), key.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._SetValueByKey"/>
  public static unsafe bool SetValueByKey(ref this CefV8Value self, ref CefString key, ref CefV8Value value, CefV8PropertyAttribute attribute)
    => self._SetValueByKey is not null && self._SetValueByKey(self.AsPointer(), key.AsPointer(), value.AsPointer(), attribute) != 0;

  /// <inheritdoc cref="CefV8Value._SetValueByKey"/>
  public static unsafe bool SetValueByKey(ref this CefV8Value self, ref CefString key, CefV8Value* value, CefV8PropertyAttribute attribute)
    => self._SetValueByKey is not null && self._SetValueByKey(self.AsPointer(), key.AsPointer(), value, attribute) != 0;

  /// <inheritdoc cref="CefV8Value._GetValueByIndex"/>
  public static unsafe CefV8Value* GetValueByIndex(ref this CefV8Value self, int index)
    => self._GetValueByIndex is not null ? self._GetValueByIndex(self.AsPointer(), index) : default;

  /// <inheritdoc cref="CefV8Value._SetValueByIndex"/>
  public static unsafe bool SetValueByIndex(ref this CefV8Value self, int index, ref CefV8Value value)
    => self._SetValueByIndex is not null && self._SetValueByIndex(self.AsPointer(), index, value.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._SetValueByAccessor"/>
  public static unsafe bool SetValueByAccessor(ref this CefV8Value self, ref CefString key, CefV8AccessControl settings, CefV8PropertyAttribute attribute)
    => self._SetValueByAccessor is not null && self._SetValueByAccessor(self.AsPointer(), key.AsPointer(), settings, attribute) != 0;

  /// <inheritdoc cref="CefV8Value._GetKeys"/>
  public static unsafe bool GetKeys(ref this CefV8Value self, ref CefStringList keys) {
    if (self._GetKeys is null) return false;

    self._GetKeys(self.AsPointer(), keys.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefV8Value._SetUserData"/>
  public static unsafe bool SetUserData(ref this CefV8Value self, ref CefRefCountedBase data) {
    if (self._SetUserData is null) return false;

    self._SetUserData(self.AsPointer(), data.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefV8Value._GetUserData"/>
  public static unsafe CefRefCountedBase* GetUserData(ref this CefV8Value self)
    => self._GetUserData is not null ? self._GetUserData(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._GetExternallyAllocatedMemory"/>
  public static unsafe int GetExternallyAllocatedMemory(ref this CefV8Value self)
    => self._GetExternallyAllocatedMemory is not null ? self._GetExternallyAllocatedMemory(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._AdjustExternallyAllocatedMemory"/>
  public static unsafe bool AdjustExternallyAllocatedMemory(ref this CefV8Value self, int changeInBytes) {
    if (self._AdjustExternallyAllocatedMemory is null) return false;

    self._AdjustExternallyAllocatedMemory(self.AsPointer(), changeInBytes);
    return true;
  }

  /// <inheritdoc cref="CefV8Value._GetArrayLength"/>
  public static unsafe int GetArrayLength(ref this CefV8Value self)
    => self._GetArrayLength is not null ? self._GetArrayLength(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._GetFunctionName"/>
  public static unsafe CefStringUserFree* GetFunctionName(ref this CefV8Value self)
    => self._GetFunctionName is not null ? self._GetFunctionName(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._GetFunctionHandler"/>
  public static unsafe CefV8Handler* GetFunctionHandler(ref this CefV8Value self)
    => self._GetFunctionHandler is not null ? self._GetFunctionHandler(self.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._ExecuteFunction"/>
  public static unsafe CefV8Value* ExecuteFunction(ref this CefV8Value self, ref CefV8Value @this, uint argumentsCount, ref CefV8Value arguments)
    => self._ExecuteFunction is not null ? self._ExecuteFunction(self.AsPointer(), @this.AsPointer(), argumentsCount, arguments.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._ExecuteFunction"/>
  public static unsafe CefV8Value* ExecuteFunction(ref this CefV8Value self, ref CefV8Value @this, uint argumentsCount, CefV8Value* arguments)
    => self._ExecuteFunction is not null ? self._ExecuteFunction(self.AsPointer(), @this.AsPointer(), argumentsCount, arguments) : default;

  /// <inheritdoc cref="CefV8Value._ExecuteFunction"/>
  public static unsafe CefV8Value* ExecuteFunction(ref this CefV8Value self, CefV8Value* @this, uint argumentsCount, ref CefV8Value arguments)
    => self._ExecuteFunction is not null ? self._ExecuteFunction(self.AsPointer(), @this, argumentsCount, arguments.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._ExecuteFunction"/>
  public static unsafe CefV8Value* ExecuteFunction(ref this CefV8Value self, CefV8Value* @this, uint argumentsCount, CefV8Value* arguments)
    => self._ExecuteFunction is not null ? self._ExecuteFunction(self.AsPointer(), @this, argumentsCount, arguments) : default;

  /// <inheritdoc cref="CefV8Value._ExecuteFunctionWithContext"/>
  public static unsafe CefV8Value* ExecuteFunctionWithContext(ref this CefV8Value self, ref CefV8Context context, ref CefV8Value @this, uint argumentsCount, ref CefV8Value arguments)
    => self._ExecuteFunctionWithContext is not null ? self._ExecuteFunctionWithContext(self.AsPointer(), context.AsPointer(), @this.AsPointer(), argumentsCount, arguments.AsPointer()) : default;

  /// <inheritdoc cref="CefV8Value._ResolvePromise"/>
  public static unsafe bool ResolvePromise(ref this CefV8Value self, ref CefV8Value value) {
    if (self._ResolvePromise is null) return false;

    self._ResolvePromise(self.AsPointer(), value.AsPointer());
    return true;
  }

  /// <inheritdoc cref="CefV8Value._RejectPromise"/>
  public static unsafe bool RejectPromise(ref this CefV8Value self, ref CefString errorMsg) {
    if (self._RejectPromise is null) return false;

    self._RejectPromise(self.AsPointer(), errorMsg.AsPointer());
    return true;
  }

}
