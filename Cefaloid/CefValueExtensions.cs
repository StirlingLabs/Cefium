namespace Cefaloid;

/// <inheritdoc cref="CefValue"/>
[PublicAPI]
public static class CefValueExtensions {

  /// <inheritdoc cref="CefValue._IsValid"/>
  public static unsafe bool IsValid(ref this CefValue self)
    => self._IsValid(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsOwned"/>
  public static unsafe bool IsOwned(ref this CefValue self)
    => self._IsOwned(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsReadOnly"/>
  public static unsafe bool IsReadOnly(ref this CefValue self)
    => self._IsReadOnly(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsSame"/>
  public static unsafe bool IsSame(ref this CefValue self, ref CefValue that)
    => self._IsSame(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._IsEqual"/>
  public static unsafe bool IsEqual(ref this CefValue self, ref CefValue that)
    => self._IsEqual(self.AsPointer(), that.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._Copy"/>
  public static unsafe CefValue* Copy(ref this CefValue self)
    => self._Copy(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetType"/>
  public static unsafe CefValueType GetType(ref this CefValue self)
    => self._GetType(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetBool"/>
  public static unsafe bool GetBool(ref this CefValue self)
    => self._GetBool(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._GetInt"/>
  public static unsafe int GetInt(ref this CefValue self)
    => self._GetInt(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetDouble"/>
  public static unsafe double GetDouble(ref this CefValue self)
    => self._GetDouble(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetString"/>
  public static unsafe CefString GetString(ref this CefValue self)
    => self._GetString(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetBinary"/>
  public static unsafe CefBinaryValue* GetBinary(ref this CefValue self)
    => self._GetBinary(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetDictionary"/>
  public static unsafe CefDictionaryValue* GetDictionary(ref this CefValue self)
    => self._GetDictionary(self.AsPointer());

  /// <inheritdoc cref="CefValue._GetList"/>
  public static unsafe CefListValue* GetList(ref this CefValue self)
    => self._GetList(self.AsPointer());

  /// <inheritdoc cref="CefValue._SetNull"/>
  public static unsafe bool SetNull(ref this CefValue self)
    => self._SetNull(self.AsPointer()) != 0;

  /// <inheritdoc cref="CefValue._SetBool"/>
  public static unsafe bool SetBool(ref this CefValue self, bool value)
    => self._SetBool(self.AsPointer(), value ? 1 : 0) != 0;

  /// <inheritdoc cref="CefValue._SetInt"/>
  public static unsafe bool SetInt(ref this CefValue self, int value)
    => self._SetInt(self.AsPointer(), value) != 0;

  /// <inheritdoc cref="CefValue._SetDouble"/>
  public static unsafe bool SetDouble(ref this CefValue self, double value)
    => self._SetDouble(self.AsPointer(), value) != 0;

  /// <inheritdoc cref="CefValue._SetString"/>
  public static unsafe bool SetString(ref this CefValue self, ref CefString value)
    => self._SetString(self.AsPointer(), ref value) != 0;

  /// <inheritdoc cref="CefValue._SetBinary"/>
  public static unsafe bool SetBinary(ref this CefValue self, CefBinaryValue* value)
    => self._SetBinary(self.AsPointer(), value) != 0;

  /// <inheritdoc cref="CefValue._SetDictionary"/>
  public static unsafe bool SetDictionary(ref this CefValue self, CefDictionaryValue* value)
    => self._SetDictionary(self.AsPointer(), value) != 0;

  /// <inheritdoc cref="CefValue._SetList"/>
  public static unsafe bool SetList(ref this CefValue self, CefListValue* value)
    => self._SetList(self.AsPointer(), value) != 0;

}
