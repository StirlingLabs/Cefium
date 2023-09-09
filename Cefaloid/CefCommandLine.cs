namespace Cefaloid;

/// <summary>
/// Structure used to create and/or parse command line arguments. Arguments with
/// "--", "-" and, on Windows, "/" prefixes are considered switches. Switches
/// will always precede any arguments without switch prefixes. Switches can
/// optionally have a value specified using the "=" delimiter (e.g.
/// "-switch=value"). An argument of "--" will terminate switch parsing with all
/// subsequent tokens, regardless of prefix, being interpreted as non-switch
/// arguments. Switch names should be lowercase ASCII and will be converted to
/// such if necessary. Switch values will retain the original case and UTF8
/// encoding. This structure can be used before cef_initialize() is called.
/// <c>cef_command_line_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefCommandLine : ICefRefCountedBase<CefCommandLine> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefCommandLine() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Create a new cef_command_line_t instance.
  /// <c>CEF_EXPORT cef_command_line_t* cef_command_line_create(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_command_line_create", CallingConvention = CallingConvention.Cdecl)]
  private static extern unsafe CefCommandLine* _Create();

  /// <inheritdoc cref="_Create"/>
  public static unsafe CefCommandLine* CreateUndefined()
    => _Create();

  /// <summary>
  /// Returns the singleton global cef_command_line_t object. The returned object
  /// will be read-only.
  /// <c>CEF_EXPORT cef_command_line_t* cef_command_line_get_global(void);</c>
  /// </summary>
  [DllImport("cef", EntryPoint = "cef_command_line_get_global", CallingConvention = CallingConvention.Cdecl)]
  public static extern unsafe CefCommandLine* GetGlobal();

  /// <summary>
  /// Returns true (1) if this object is valid. Do not call any other functions
  /// if this function returns false (0).
  /// <c>int(CEF_CALLBACK* is_valid)(struct _cef_command_line_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, int> _IsValid;

  /// <summary>
  /// Returns true (1) if the values of this object are read-only. Some APIs may
  /// expose read-only objects.
  /// <c>int(CEF_CALLBACK* is_read_only)(struct _cef_command_line_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, int> _IsReadOnly;

  /// <summary>
  /// Returns a writable copy of this object.
  /// <c>struct _cef_command_line_t*(CEF_CALLBACK* copy)(struct _cef_command_line_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefCommandLine*> _Copy;

  /// <summary>
  /// Initialize the command line with the specified |argc| and |argv| values.
  /// The first argument must be the name of the program. This function is only
  /// supported on non-Windows platforms.
  /// <c>void(CEF_CALLBACK* init_from_argv)(struct _cef_command_line_t* self, int argc, const char* const* argv);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, int, char**, void> _InitFromArgv;

  /// <summary>
  /// Initialize the command line with the string returned by calling
  /// GetCommandLineW(). This function is only supported on Windows.
  /// <c>void(CEF_CALLBACK* init_from_string)(struct _cef_command_line_t* self, const cef_string_t* command_line);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefString*, void> _InitFromString;

  /// <summary>
  /// Reset the command-line switches and arguments but leave the program
  /// component unchanged.
  /// <c>void(CEF_CALLBACK* reset)(struct _cef_command_line_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, void> _Reset;

  /// <summary>
  /// Retrieve the original command line string as a vector of strings. The argv
  /// array: `{ program, [(--|-|/)switch[=value]]*, [--], [argument]* }`
  /// <c>void(CEF_CALLBACK* get_argv)(struct _cef_command_line_t* self, cef_string_list_t argv);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefStringList*, void> _GetArgv;

  /// <summary>
  /// Constructs and returns the represented command line string. Use this
  /// function cautiously because quoting behavior is unclear.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_command_line_string)(struct _cef_command_line_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefStringUserFree*> _GetCommandLineString;

  /// <summary>
  /// Get the program part of the command line string (the first item).
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_program)(struct _cef_command_line_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefStringUserFree*> _GetProgram;

  /// <summary>
  /// Set the program part of the command line string (the first item).
  /// <c>void(CEF_CALLBACK* set_program)(struct _cef_command_line_t* self, const cef_string_t* program);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefString*, void> _SetProgram;

  /// <summary>
  /// Returns true (1) if the command line has switches.
  /// <c>int(CEF_CALLBACK* has_switches)(struct _cef_command_line_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, int> _HasSwitches;

  /// <summary>
  /// Returns true (1) if the command line contains the given switch.
  /// <c>int(CEF_CALLBACK* has_switch)(struct _cef_command_line_t* self, const cef_string_t* name);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefString*, int> _HasSwitch;

  /// <summary>
  /// Returns the value associated with the given switch. If the switch has no
  /// value or isn't present this function returns the NULL string.
  ///
  /// The resulting string must be freed by calling cef_string_userfree_free().
  /// <c>cef_string_userfree_t(CEF_CALLBACK* get_switch_value)(struct _cef_command_line_t* self, const cef_string_t* name);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefString*, CefStringUserFree*> _GetSwitchValue;

  /// <summary>
  /// Returns the map of switch names and values. If a switch has no value an
  /// NULL string is returned.
  /// <c>void(CEF_CALLBACK* get_switches)(struct _cef_command_line_t* self, cef_string_map_t switches);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefStringMap*, void> _GetSwitches;

  /// <summary>
  /// Add a switch to the end of the command line.
  /// <c>void(CEF_CALLBACK* append_switch)(struct _cef_command_line_t* self, const cef_string_t* name);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefString*, void> _AppendSwitch;

  /// <summary>
  /// Add a switch with the specified value to the end of the command line. If
  /// the switch has no value pass an NULL value string.
  /// <c>void(CEF_CALLBACK* append_switch_with_value)(struct _cef_command_line_t* self, const cef_string_t* name, const cef_string_t* value);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefString*, CefString*, void> _AppendSwitchWithValue;

  /// <summary>
  /// True if there are remaining command line arguments.
  /// <c>int(CEF_CALLBACK* has_arguments)(struct _cef_command_line_t* self);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, int> _HasArguments;

  /// <summary>
  /// Get the remaining command line arguments.
  /// <c>void(CEF_CALLBACK* get_arguments)(struct _cef_command_line_t* self, cef_string_list_t arguments);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefStringList*, void> _GetArguments;

  /// <summary>
  /// Add an argument to the end of the command line.
  /// <c>void(CEF_CALLBACK* append_argument)(struct _cef_command_line_t* self, const cef_string_t* argument);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefString*, void> _AppendArgument;

  /// <summary>
  /// Insert a command before the current command. Common for debuggers, like
  /// "valgrind" or "gdb --args".
  /// <c>void(CEF_CALLBACK* prepend_wrapper)(struct _cef_command_line_t* self, const cef_string_t* wrapper);</c>
  /// </summary>
  internal unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefCommandLine*, CefString*, void> _PrependWrapper;

}
