namespace Cefium;

/// <inheritdoc cref="CefV8Value"/>
[PublicAPI]
public static class CefV8ValueExtensions {

  /// <inheritdoc cref="CefV8Value._IsValid"/>
  public static unsafe bool IsValid(ref this CefV8Value self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsUndefined"/>
  public static unsafe bool IsUndefined(ref this CefV8Value self) => self._IsUndefined(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsNull"/>
  public static unsafe bool IsNull(ref this CefV8Value self) => self._IsNull(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsBool"/>
  public static unsafe bool IsBool(ref this CefV8Value self) => self._IsBool(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsInt"/>
  public static unsafe bool IsInt(ref this CefV8Value self) => self._IsInt(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsUInt"/>
  public static unsafe bool IsUInt(ref this CefV8Value self) => self._IsUInt(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsDouble"/>
  public static unsafe bool IsDouble(ref this CefV8Value self) => self._IsDouble(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsDate"/>
  public static unsafe bool IsDate(ref this CefV8Value self) => self._IsDate(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsString"/>
  public static unsafe bool IsString(ref this CefV8Value self) => self._IsString(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsObject"/>
  public static unsafe bool IsObject(ref this CefV8Value self) => self._IsObject(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsArray"/>
  public static unsafe bool IsArray(ref this CefV8Value self) => self._IsArray(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsFunction"/>
  public static unsafe bool IsFunction(ref this CefV8Value self) => self._IsFunction(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._IsSame"/>
  public static unsafe bool IsSame(ref this CefV8Value self, ref CefV8Value that) => self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._GetBoolValue"/>
  public static unsafe bool GetBoolValue(ref this CefV8Value self) => self._GetBoolValue(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._GetIntValue"/>
  public static unsafe int GetIntValue(ref this CefV8Value self) => self._GetIntValue(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._GetUIntValue"/>
  public static unsafe uint GetUIntValue(ref this CefV8Value self) => self._GetUIntValue(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._GetDoubleValue"/>
  public static unsafe double GetDoubleValue(ref this CefV8Value self) => self._GetDoubleValue(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._GetDateValue"/>
  public static unsafe CefBaseTime GetDateValue(ref this CefV8Value self) => self._GetDateValue(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._GetStringValue"/>
  public static unsafe CefString* GetStringValue(ref this CefV8Value self) => self._GetStringValue(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._IsUserCreated"/>
  public static unsafe bool IsUserCreated(ref this CefV8Value self) => self._IsUserCreated(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._HasException"/>
  public static unsafe bool HasException(ref this CefV8Value self) => self._HasException(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._GetException"/>
  public static unsafe CefV8Exception* GetException(ref this CefV8Value self) => self._GetException(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._ClearException"/>
  public static unsafe void ClearException(ref this CefV8Value self) => self._ClearException(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._WillRethrowExceptions"/>
  public static unsafe bool WillRethrowExceptions(ref this CefV8Value self) => self._WillRethrowExceptions(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._SetRethrowExceptions"/>
  public static unsafe void SetRethrowExceptions(ref this CefV8Value self, bool rethrow) => self._SetRethrowExceptions(self.AsPointer(), rethrow ? 1 : 0);

  /// <inheritdoc cref="CefV8Value._HasValueByKey"/>
  public static unsafe bool HasValueByKey(ref this CefV8Value self, ref CefString key) => self._HasValueByKey(self.AsPointer(), key.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._DeleteValueByKey"/>
  public static unsafe bool DeleteValueByKey(ref this CefV8Value self, ref CefString key) => self._DeleteValueByKey(self.AsPointer(), key.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._GetValueByKey"/>
  public static unsafe CefV8Value* GetValueByKey(ref this CefV8Value self, ref CefString key) => self._GetValueByKey(self.AsPointer(), key.AsPointer());

  /// <inheritdoc cref="CefV8Value._SetValueByKey"/>
  public static unsafe bool SetValueByKey(ref this CefV8Value self, ref CefString key, ref CefV8Value value, CefV8PropertyAttribute attribute)
    => self._SetValueByKey(self.AsPointer(), key.AsPointer(), value.AsPointer(), attribute) != 0;

  /// <inheritdoc cref="CefV8Value._SetValueByKey"/>
  public static unsafe bool SetValueByKey(ref this CefV8Value self, ref CefString key, CefV8Value* value, CefV8PropertyAttribute attribute)
    => self._SetValueByKey(self.AsPointer(), key.AsPointer(), value, attribute) != 0;

  /// <inheritdoc cref="CefV8Value._GetValueByIndex"/>
  public static unsafe CefV8Value* GetValueByIndex(ref this CefV8Value self, int index) => self._GetValueByIndex(self.AsPointer(), index);

  /// <inheritdoc cref="CefV8Value._SetValueByIndex"/>
  public static unsafe bool SetValueByIndex(ref this CefV8Value self, int index, ref CefV8Value value)
    => self._SetValueByIndex(self.AsPointer(), index, value.AsPointer()) != 0;

  /// <inheritdoc cref="CefV8Value._SetValueByAccessor"/>
  public static unsafe bool SetValueByAccessor(ref this CefV8Value self, ref CefString key, CefV8AccessControl settings, CefV8PropertyAttribute attribute)
    => self._SetValueByAccessor(self.AsPointer(), key.AsPointer(), settings, attribute) != 0;

  /// <inheritdoc cref="CefV8Value._GetKeys"/>
  public static unsafe void GetKeys(ref this CefV8Value self, ref CefStringList keys) => self._GetKeys(self.AsPointer(), keys.AsPointer());

  /// <inheritdoc cref="CefV8Value._SetUserData"/>
  public static unsafe void SetUserData(ref this CefV8Value self, ref CefRefCountedBase data) => self._SetUserData(self.AsPointer(), data.AsPointer());

  /// <inheritdoc cref="CefV8Value._GetUserData"/>
  public static unsafe CefRefCountedBase* GetUserData(ref this CefV8Value self) => self._GetUserData(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._GetExternallyAllocatedMemory"/>
  public static unsafe int GetExternallyAllocatedMemory(ref this CefV8Value self) => self._GetExternallyAllocatedMemory(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._AdjustExternallyAllocatedMemory"/>
  public static unsafe void AdjustExternallyAllocatedMemory(ref this CefV8Value self, int changeInBytes) => self._AdjustExternallyAllocatedMemory(self.AsPointer(), changeInBytes);

  /// <inheritdoc cref="CefV8Value._GetArrayLength"/>
  public static unsafe int GetArrayLength(ref this CefV8Value self) => self._GetArrayLength(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._GetFunctionName"/>
  public static unsafe CefStringUserFree* GetFunctionName(ref this CefV8Value self) => self._GetFunctionName(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._GetFunctionHandler"/>
  public static unsafe CefV8Handler* GetFunctionHandler(ref this CefV8Value self) => self._GetFunctionHandler(self.AsPointer());

  /// <inheritdoc cref="CefV8Value._ExecuteFunction"/>
  public static unsafe CefV8Value* ExecuteFunction(ref this CefV8Value self, ref CefV8Value @this, uint argumentsCount, ref CefV8Value arguments)
    => self._ExecuteFunction(self.AsPointer(), @this.AsPointer(), argumentsCount, arguments.AsPointer());

  /// <inheritdoc cref="CefV8Value._ExecuteFunctionWithContext"/>
  public static unsafe CefV8Value* ExecuteFunctionWithContext(ref this CefV8Value self, ref CefV8Context context, ref CefV8Value @this, uint argumentsCount, ref CefV8Value arguments)
    => self._ExecuteFunctionWithContext(self.AsPointer(), context.AsPointer(), @this.AsPointer(), argumentsCount, arguments.AsPointer());

  /// <inheritdoc cref="CefV8Value._ResolvePromise"/>
  public static unsafe void ResolvePromise(ref this CefV8Value self, ref CefV8Value value)
    => self._ResolvePromise(self.AsPointer(), value.AsPointer());

  /// <inheritdoc cref="CefV8Value._RejectPromise"/>
  public static unsafe void RejectPromise(ref this CefV8Value self, ref CefString errorMsg)
    => self._RejectPromise(self.AsPointer(), errorMsg.AsPointer());

}
