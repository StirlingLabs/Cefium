namespace Cefium;

/// <summary>
/// Resource type for a request. These constants match their equivalents in
/// Chromium's ResourceType and should not be renumbered.
/// </summary>
[PublicAPI]
public enum CefResourceType {

  /// <summary>
  /// Top level page.
  /// <c>RT_MAIN_FRAME</c>
  /// </summary>
  MainFrame = 0,

  /// <summary>
  /// Frame or iframe.
  /// <c>RT_SUB_FRAME</c>
  /// </summary>
  SubFrame,

  /// <summary>
  /// CSS stylesheet.
  /// <c>RT_STYLESHEET</c>
  /// </summary>
  StyleSheet,

  /// <summary>
  /// External script.
  /// <c>RT_SCRIPT</c>
  /// </summary>
  Script,

  /// <summary>
  /// Image (jpg/gif/png/etc).
  /// <c>RT_IMAGE</c>
  /// </summary>
  Image,

  /// <summary>
  /// Font.
  /// <c>RT_FONT_RESOURCE</c>
  /// </summary>
  Font,

  /// <summary>
  /// Some other subresource. This is the default type if the actual type is
  /// unknown.
  /// <c>RT_SUB_RESOURCE</c>
  /// </summary>
  SubResource,

  /// <summary>
  /// Object (or embed) tag for a plugin, or a resource that a plugin requested.
  /// <c>RT_OBJECT</c>
  /// </summary>
  Object,

  /// <summary>
  /// Media resource.
  /// <c>RT_MEDIA</c>
  /// </summary>
  Media,

  /// <summary>
  /// Main resource of a dedicated worker.
  /// <c>RT_WORKER</c>
  /// </summary>
  Worker,

  /// <summary>
  /// Main resource of a shared worker.
  /// <c>RT_SHARED_WORKER</c>
  /// </summary>
  SharedWorker,

  /// <summary>
  /// Explicitly requested prefetch.
  /// <c>RT_PREFETCH</c>
  /// </summary>
  Prefetch,

  /// <summary>
  /// Favicon.
  /// <c>RT_FAVICON</c>
  /// </summary>
  Favicon,

  /// <summary>
  /// XMLHttpRequest.
  /// <c>RT_XHR</c>
  /// </summary>
  Xhr,

  /// <summary>
  /// A request for a "&lt;ping&gt;".
  /// <c>RT_PING</c>
  /// </summary>
  Ping,

  /// <summary>
  /// Main resource of a service worker.
  /// <c>RT_SERVICE_WORKER</c>
  /// </summary>
  ServiceWorker,

  /// <summary>
  /// A report of Content Security Policy violations.
  /// <c>RT_CSP_REPORT</c>
  /// </summary>
  CspReport,

  /// <summary>
  /// A resource that a plugin requested.
  /// <c>RT_PLUGIN_RESOURCE</c>
  /// </summary>
  PluginResource,

  /// <summary>
  /// A main-frame service worker navigation preload request.
  /// <c>RT_NAVIGATION_PRELOAD_MAIN_FRAME</c>
  /// </summary>
  NavigationPreloadMainFrame = 19,

  /// <summary>
  /// A sub-frame service worker navigation preload request.
  /// <c>RT_NAVIGATION_PRELOAD_SUB_FRAME</c>
  /// </summary>
  NavigationPreloadSubFrame,

}
