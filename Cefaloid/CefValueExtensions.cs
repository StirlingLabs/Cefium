namespace Cefaloid;

/// <inheritdoc cref="CefValue"/>
[PublicAPI]
public static class CefValueExtensions {

  /// <inheritdoc cref="CefValue._IsValid"/>
  public static unsafe bool IsValid(ref this CefValue self) => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsUndefined"/>
  public static unsafe bool IsUndefined(ref this CefValue self) => self._IsUndefined(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsNull"/>
  public static unsafe bool IsNull(ref this CefValue self) => self._IsNull(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsBool"/>
  public static unsafe bool IsBool(ref this CefValue self) => self._IsBool(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsInt"/>
  public static unsafe bool IsInt(ref this CefValue self) => self._IsInt(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsUInt"/>
  public static unsafe bool IsUInt(ref this CefValue self) => self._IsUInt(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsDouble"/>
  public static unsafe bool IsDouble(ref this CefValue self) => self._IsDouble(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsDate"/>
  public static unsafe bool IsDate(ref this CefValue self) => self._IsDate(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsString"/>
  public static unsafe bool IsString(ref this CefValue self) => self._IsString(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsObject"/>
  public static unsafe bool IsObject(ref this CefValue self) => self._IsObject(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsArray"/>
  public static unsafe bool IsArray(ref this CefValue self) => self._IsArray(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsFunction"/>
  public static unsafe bool IsFunction(ref this CefValue self) => self._IsFunction(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsSame"/>
  public static unsafe bool IsSame(ref this CefValue self, ref CefValue that) => self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._GetBoolValue"/>
  public static unsafe bool GetBoolValue(ref this CefValue self) => self._GetBoolValue(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._GetIntValue"/>
  public static unsafe int GetIntValue(ref this CefValue self) => self._GetIntValue(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetUIntValue"/>
  public static unsafe uint GetUIntValue(ref this CefValue self) => self._GetUIntValue(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetDoubleValue"/>
  public static unsafe double GetDoubleValue(ref this CefValue self) => self._GetDoubleValue(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetDateValue"/>
  public static unsafe CefBaseTime GetDateValue(ref this CefValue self) => self._GetDateValue(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetStringValue"/>
  public static unsafe CefString* GetStringValue(ref this CefValue self) => self._GetStringValue(self.AsPointer());

  /// <inheritdoc cref="CefValue._IsUserCreated"/>
  public static unsafe bool IsUserCreated(ref this CefValue self) => self._IsUserCreated(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._HasException"/>
  public static unsafe bool HasException(ref this CefValue self) => self._HasException(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._GetException"/>
  public static unsafe CefV8Exception* GetException(ref this CefValue self) => self._GetException(self.AsPointer());

  /// <inheritdoc cref="CefValue._ClearException"/>
  public static unsafe void ClearException(ref this CefValue self) => self._ClearException(self.AsPointer());

  /// <inheritdoc cref="CefValue._WillRethrowExceptions"/>
  public static unsafe bool WillRethrowExceptions(ref this CefValue self) => self._WillRethrowExceptions(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._SetRethrowExceptions"/>
  public static unsafe void SetRethrowExceptions(ref this CefValue self, bool rethrow) => self._SetRethrowExceptions(self.AsPointer(), rethrow ? 1 : 0);

  /// <inheritdoc cref="CefValue._HasValueByKey"/>
  public static unsafe bool HasValueByKey(ref this CefValue self, ref CefString key) => self._HasValueByKey(self.AsPointer(), key.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._DeleteValueByKey"/>
  public static unsafe bool DeleteValueByKey(ref this CefValue self, ref CefString key) => self._DeleteValueByKey(self.AsPointer(), key.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._GetValueByKey"/>
  public static unsafe CefValue* GetValueByKey(ref this CefValue self, ref CefString key) => self._GetValueByKey(self.AsPointer(), key.AsPointer());

  /// <inheritdoc cref="CefValue._SetValueByKey"/>
  public static unsafe bool SetValueByKey(ref this CefValue self, ref CefString key, ref CefValue value, CefV8PropertyAttribute attribute)
    => self._SetValueByKey(self.AsPointer(), key.AsPointer(), value.AsPointer(), attribute) != 0;

  /// <inheritdoc cref="CefValue._GetValueByIndex"/>
  public static unsafe CefValue* GetValueByIndex(ref this CefValue self, int index) => self._GetValueByIndex(self.AsPointer(), index);

  /// <inheritdoc cref="CefValue._SetValueByIndex"/>
  public static unsafe bool SetValueByIndex(ref this CefValue self, int index, ref CefValue value)
    => self._SetValueByIndex(self.AsPointer(), index, value.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._SetValueByAccessor"/>
  public static unsafe bool SetValueByAccessor(ref this CefValue self, ref CefString key, CefV8AccessControl settings, CefV8PropertyAttribute attribute)
    => self._SetValueByAccessor(self.AsPointer(), key.AsPointer(), settings, attribute) != 0;

  /// <inheritdoc cref="CefValue._GetKeys"/>
  public static unsafe void GetKeys(ref this CefValue self, ref CefStringList keys) => self._GetKeys(self.AsPointer(), keys.AsPointer());

  /// <inheritdoc cref="CefValue._SetUserData"/>
  public static unsafe void SetUserData(ref this CefValue self, ref CefRefCountedBase data) => self._SetUserData(self.AsPointer(), data.AsPointer());

  /// <inheritdoc cref="CefValue._GetUserData"/>
  public static unsafe CefRefCountedBase* GetUserData(ref this CefValue self) => self._GetUserData(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetExternallyAllocatedMemory"/>
  public static unsafe int GetExternallyAllocatedMemory(ref this CefValue self) => self._GetExternallyAllocatedMemory(self.AsPointer());

  /// <inheritdoc cref="CefValue._AdjustExternallyAllocatedMemory"/>
  public static unsafe void AdjustExternallyAllocatedMemory(ref this CefValue self, int changeInBytes) => self._AdjustExternallyAllocatedMemory(self.AsPointer(), changeInBytes);

  /// <inheritdoc cref="CefValue._GetArrayLength"/>
  public static unsafe int GetArrayLength(ref this CefValue self) => self._GetArrayLength(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetFunctionName"/>
  public static unsafe CefStringUserFree* GetFunctionName(ref this CefValue self) => self._GetFunctionName(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetFunctionHandler"/>
  public static unsafe CefV8Handler* GetFunctionHandler(ref this CefValue self) => self._GetFunctionHandler(self.AsPointer());

  /// <inheritdoc cref="CefValue._ExecuteFunction"/>
  public static unsafe CefValue* ExecuteFunction(ref this CefValue self, ref CefValue @this, uint argumentsCount, ref CefValue arguments)
    => self._ExecuteFunction(self.AsPointer(), @this.AsPointer(), argumentsCount, arguments.AsPointer());

  /// <inheritdoc cref="CefValue._ExecuteFunctionWithContext"/>
  public static unsafe CefValue* ExecuteFunctionWithContext(ref this CefValue self, ref CefV8Context context, ref CefValue @this, uint argumentsCount, ref CefValue arguments)
    => self._ExecuteFunctionWithContext(self.AsPointer(), context.AsPointer(), @this.AsPointer(), argumentsCount, arguments.AsPointer());

  /// <inheritdoc cref="CefValue._ResolvePromise"/>
  public static unsafe void ResolvePromise(ref this CefValue self, ref CefValue value)
    => self._ResolvePromise(self.AsPointer(), value.AsPointer());

  /// <inheritdoc cref="CefValue._RejectPromise"/>
  public static unsafe void RejectPromise(ref this CefValue self, ref CefString errorMsg)
    => self._RejectPromise(self.AsPointer(), errorMsg.AsPointer());

}
