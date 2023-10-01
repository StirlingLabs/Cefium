namespace Cefium;

/// <summary>
/// Callback structure for cef_browser_host_t::AddDevToolsMessageObserver. The
/// functions of this structure will be called on the browser process UI thread.
/// <c>cef_dev_tools_message_observer_t</c>
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefDevToolsMessageObserver : ICefRefCountedBase<CefDevToolsMessageObserver> {

  /// <inheritdoc cref="CefDevToolsMessageObserver"/>
  [Obsolete(DoNotConstructDirectly, true)]
  public CefDevToolsMessageObserver() {
  }

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

  /// <summary>
  /// Method that will be called on receipt of a DevTools protocol message.
  /// |browser| is the originating browser instance. |message| is a UTF8-encoded
  /// JSON dictionary representing either a function result or an event.
  /// |message| is only valid for the scope of this callback and should be
  /// copied if necessary. Return true (1) if the message was handled or false
  /// (0) if the message should be further processed and passed to the
  /// OnDevToolsMethodResult or OnDevToolsEvent functions as appropriate.
  ///
  /// Method result dictionaries include an "id" (int) value that identifies the
  /// orginating function call sent from
  /// cef_browser_host_t::SendDevToolsMessage, and optionally either a "result"
  /// (dictionary) or "error" (dictionary) value. The "error" dictionary will
  /// contain "code" (int) and "message" (string) values. Event dictionaries
  /// include a "function" (string) value and optionally a "params" (dictionary)
  /// value. See the DevTools protocol documentation at
  /// https://chromedevtools.github.io/devtools-protocol/ for details of
  /// supported function calls and the expected "result" or "params" dictionary
  /// contents. JSON dictionaries can be parsed using the CefParseJSON function
  /// if desired, however be aware of performance considerations when parsing
  /// large messages (some of which may exceed 1MB in size).
  /// <c>int(CEF_CALLBACK* on_dev_tools_message)(struct _cef_dev_tools_message_observer_t* self, struct _cef_browser_t* browser, const void* message, size_t message_size)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDevToolsMessageObserver*, CefBrowser*, void*, nuint, int> _OnDevToolsMessage;

  /// <summary>
  /// Method that will be called after attempted execution of a DevTools
  /// protocol function. |browser| is the originating browser instance.
  /// |message_id| is the "id" value that identifies the originating function
  /// call message. If the function succeeded |success| will be true (1) and
  /// |result| will be the UTF8-encoded JSON "result" dictionary value (which
  /// may be NULL). If the function failed |success| will be false (0) and
  /// |result| will be the UTF8-encoded JSON "error" dictionary value. |result|
  /// is only valid for the scope of this callback and should be copied if
  /// necessary. See the OnDevToolsMessage documentation for additional details
  /// on |result| contents.
  /// <c>void(CEF_CALLBACK* on_dev_tools_method_result)(struct _cef_dev_tools_message_observer_t* self, struct _cef_browser_t* browser, int message_id, int success, const void* result, size_t result_size)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDevToolsMessageObserver*, CefBrowser*, int, int, void*, nuint, void> _OnDevToolsMethodResult;

  /// <summary>
  /// Method that will be called on receipt of a DevTools protocol event.
  /// |browser| is the originating browser instance. |function| is the
  /// "function" value. |params| is the UTF8-encoded JSON "params" dictionary
  /// value (which may be NULL). |params| is only valid for the scope of this
  /// callback and should be copied if necessary. See the OnDevToolsMessage
  /// documentation for additional details on |params| contents.
  /// <c>void(CEF_CALLBACK* on_dev_tools_event)(struct _cef_dev_tools_message_observer_t* self, struct _cef_browser_t* browser, const cef_string_t* method, const void* params, size_t params_size)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDevToolsMessageObserver*, CefBrowser*, CefString*, void*, nuint, void> _OnDevToolsEvent;

  /// <summary>
  /// Method that will be called when the DevTools agent has attached. |browser|
  /// is the originating browser instance. This will generally occur in response
  /// to the first message sent while the agent is detached.
  /// <c>void(CEF_CALLBACK* on_dev_tools_agent_attached)(struct _cef_dev_tools_message_observer_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDevToolsMessageObserver*, CefBrowser*, void> _OnDevToolsAgentAttached;

  /// <summary>
  /// Method that will be called when the DevTools agent has detached. |browser|
  /// is the originating browser instance. Any function results that were
  /// pending before the agent became detached will not be delivered, and any
  /// active event subscriptions will be canceled.
  /// <c>void(CEF_CALLBACK* on_dev_tools_agent_detached)(struct _cef_dev_tools_message_observer_t* self, struct _cef_browser_t* browser)</c>
  /// </summary>
  public unsafe delegate * unmanaged[Stdcall, SuppressGCTransition]<CefDevToolsMessageObserver*, CefBrowser*, void> _OnDevToolsAgentDetached;

}
