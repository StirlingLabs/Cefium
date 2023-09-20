namespace Cefium.Tests;

public static class Customizations {

  public static readonly string[] DisabledBlinkFeatures = {
    "AdInterestGroupAPI", "AdTagging", "AddIdentityInCanMakePaymentEvent", "BarcodeDetector", "DeviceAttributes",
    "DeviceOrientationRequestPermission", "DevicePosture", "DigitalGoods", "DigitalGoodsV2_1", "DirectSockets",
    "DocumentCookie", "DocumentDomain", "DocumentPolicy", "DocumentWrite", "FaceDetector", "FeaturePolicyReporting",
    "FedCm", "FileSystem", "FileSystemAccessAPIExperimental", "FileSystemAccessAccessHandle", "FileSystemAccessLocal",
    "FileSystemAccessOriginPrivate", "HandwritingRecognition", "IdleDetection", "IncomingCallNotifications",
    "MachineLearningCommon", "MachineLearningModelLoader", "MachineLearningNeuralNetwork", "MediaCapture",
    "MediaCaptureBackgroundBlur", "MediaCaptureConfigurationChange", "NotificationContentImage", "NotificationTriggers",
    "Notifications", "OnDeviceChange", "OrientationEvent", "PNaCl", "PagePopup", "Parakeet", "PaymentApp",
    "PaymentRequest", "PaymentRequestMerchantValidationEvent", "PeriodicBackgroundSync", "PointerLockOptions",
    "PrivacySandboxAdsAPIs", "PushMessaging", "PushMessagingSubscriptionChange",
    "QuickIntensiveWakeUpThrottlingAfterLoading", "RTCEncodedVideoFrameAdditionalMetadata", "RTCEncodedVideoFrameClone",
    "RTCIceTransportExtension", "RTCInsertableStreams", "RTCQuicTransport", "RTCRtpHeaderExtensionControl",
    "RTCStatsRelativePacketArrivalDelay", "RTCSvcScalabilityMode", "RegionCapture", "RestrictGamepadAccess",
    "RtcAudioJitterBufferMaxPackets", "SecurePaymentConfirmation", "SecurePaymentConfirmationDebug",
    "SensorExtraClasses", "SmartCard", "StylusHandwriting", "SystemWakeLock", "TimerThrottlingForBackgroundTabs",
    "TopicsAPI", "TopicsXHR", "TouchEventFeatureDetection", "VideoRotateToFullscreen", "WakeLock", "WarnSandboxIneffective",
    "WebAuth", "WebAuthAuthenticatorAttachment", "WebAuthenticationConditionalUI", "WebAuthenticationDevicePublicKey",
    "WebAuthenticationLargeBlobExtension", "WebAuthenticationPRF", "WebAuthenticationRemoteDesktopSupport", "WebBluetooth",
    "WebBluetoothGetDevices", "WebBluetoothScanning", "WebBluetoothWatchAdvertisements", "WebNFC", "WebOTP", "WebShare",
    "WebUSB", "WebXR"
  };

  public static readonly string[] EnabledBlinkFeatures = {
    "AbortSignalAny", "Accelerated2dCanvas", "AcceleratedSmallCanvases", "AnimationWorklet", "CLSScrollAnchoring",
    "CSSAnchorPositioning", "CSSAnimationComposition", "CSSCalcSimplificationAndSerialization", "CSSColor4",
    "CSSColorContrast", "CSSColorContrast", "CSSColorTypedOM", "CSSDisplayAnimation", "CSSEnumeratedCustomProperties",
    "CSSFocusVisible", "CSSFoldables", "CSSFontFaceAutoVariableRange", "CSSFontFaceSrcTechParsing", "CSSFontSizeAdjust",
    "CSSGridTemplatePropertyInterpolation", "CSSHexAlphaColor", "CSSHyphenateLimitChars", "CSSIcUnit", "CSSImageSet",
    "CSSIndependentTransformProperties", "CSSInitialLetter", "CSSLastBaseline", "CSSLayoutAPI", "CSSLhUnit", "CSSLogical",
    "CSSLogicalOverflow", "CSSMarkerNestedPseudoElement", "CSSMixBlendModePlusLighter", "CSSNesting", "CSSObjectViewBox",
    "CSSOffsetPathRay", "CSSOffsetPathRayContain", "CSSOffsetPositionAnchor", "CSSOverflowForReplacedElements",
    "CSSPaintAPIArguments", "CSSPictureInPicture", "CSSPseudoPlayingPaused", "CSSScope", "CSSScrollbars",
    "CSSSelectorNthChildComplexSelector", "CSSToggles", "CSSTrigonometricFunctions", "CSSVariables2ImageValues",
    "CSSVariables2TransformValues", "CSSVideoDynamicRangeMediaQueries", "CSSViewportUnits4", "Canvas2dImageChromium",
    "Canvas2dLayers", "Canvas2dScrollPathIntoView", "CanvasFloatingPoint", "CanvasHDR", "CanvasImageSmoothing",
    "ClipboardCustomFormats", "ClipboardSvg", "ClipboardSvg", "CoepReflection", "CompositeBGColorAnimation",
    "CompositeBGColorAnimation", "CompositeBoxShadowAnimation", "CompositeClipPathAnimation", "CompositedSelectionUpdate",
    "ComputePressure", "ContextMenu", "ContextMenu", "CooperativeScheduling", "DisplaySurfaceConstraint",
    "DocumentPictureInPictureAPI", "EditContext", "ExtendedTextMetrics", "ExtraWebGLVideoTextureMetadata",
    "FencedFramesAPIChanges", "FontAccess", "FontVariantPosition", "HTMLPopoverAttribute", "HTMLSelectMenuElement",
    "InnerHTMLParserFastpath", "MediaCapabilitiesDynamicRange", "MediaCapabilitiesEncodingInfo",
    "MediaCapabilitiesSpatialAudio", "PageFreezeOptOut", "SanitizerAPI", "ScrollEndEvents", "ScrollOverlapOptimization",
    "ScrollbarWidth", "SecurePaymentConfirmationOptOut", "SendMouseEventsDisabledFormControls", "SharedArrayBuffer",
    "SharedArrayBufferOnDesktop", "SharedArrayBufferUnrestrictedAccessAllowed", "TextFragmentAPI",
    "UnrestrictedSharedArrayBuffer", "WebAnimationsSVG", "WebCodecs", "WebCryptoCurve25519",
    "WebFontResizeLCP", "WebGLDraftExtensions", "WebGLDraftExtensions", "WebGPU", "WebGPUDeveloperFeatures",
    "WebGPUImportTexture", "WebHID", "WebHIDOnServiceWorkers", "WebKitScrollbarStyling", "WebSocketStream",
    "WindowDefaultStatus", "ZeroCopyTabCapture", // getDisplayMedia() -> NV12
  };

  public static readonly string[] BlinkSettings = {
    "hideScrollbars=true", "spellCheckEnabledByDefault=false", "hideDownloadUI=true", "mediaControlsEnabled=false",
    "preferredColorScheme=mojom::blink::PreferredColorScheme::kDark", "prefersReducedMotion=false",
    "acceleratedCompositingEnabled=true", "shouldClearDocumentBackground=false", "supportsMultipleWindows=false"
  };

  public static readonly string[] EnabledFeatures = {
    "UnexpireFlagsM114",
    "JavaScriptExperimentalSharedMemory",
    "ChromeLabs", "FontAccess", "VariableCOLRV1", // very handy
    "PrintWithReducedRasterization", // fast pdf production?
    "V8VmFuture", // javascript features
    "RawDraw", "GpuRasterization", // useful
    "ExperimentalWebPlatformFeatures", "EnableZeroCopyTabCapture",
    "DXGIWaitableSwapChain:DXGIWaitableSwapChainMaxQueuedFrames/3",
    "UseDMSAAForTiles",
    "WebAssemblyBaseline",
    "WebAssemblyExperimentalJSPI",
    "WebAssemblyGarbageCollection",
    "WebAssemblyLazyCompilation",
    "WebAssemblyStringref",
    "WebAssemblyTiering",
    //"Vulkan" // not supported in single proc mode
  };

  public static readonly string[] CommandLineArguments = {
    "allow-no-sandbox-job",
    "no-sandbox",
    "single-process",
    "in-process-gpu",
    "in-process-broker",
    "ppapi-in-process",
    //"force-app-mode",
    "enable-quic",
    "allow-pre-commit-input",
    "no-first-run",
    "no-proxy-server",
    "no-crash-upload",
    "no-default-browser-check",
    "no-pings",
    "no-startup-window",
    "no-service-autorun",
    "no-vr-runtime",
    "noerrdialogs",
    "disable-crash-reporter",
    "disable-component-update",
    "no-report-upload",
    "disable-notifications",
    "enable-experimental-web-platform-features",
    "enable-gpu-rasterization",
    "enable-zero-copy",
    "enable-unsafe-webgpu",
    "disable-appcontainer",
    "disable-background-networking",
    "disable-boot-animation",
    "disable-breakpad",
    "disable-cloud-import",
    "disable-component-cloud-policy",
    "disable-default-apps",
    "disable-infobars",
    //"disable-logging",
    //"enable-logging",
    "blink-platform-log-channels",
    "ignore-gpu-blacklist",
    "enable-viewport",
    "bwsi",
    "autoplay-policy=no-user-gesture-required",
  };

  public static readonly (string, string)[] CommandLineArgumentsWithValues = {
    ("enable-features", $"{string.Join(',', EnabledFeatures)}"),
    ("enable-blink-features", $"{string.Join(',', EnabledBlinkFeatures)}"),
    ("disable-blink-features", $"{string.Join(',', DisabledBlinkFeatures)}"),
    ("blink-settings", $"{string.Join(',', BlinkSettings)}"),
    ("use-gl", "angle"),
    //("use-angle", "gl"), // see also, Vulkan in EnableFeatures
    ("use-angle", "d3d11"),
    ("default-background-color", "00000000"),
    ("enable-logging", "stderr"),
    //("log-file",""),
    ("log-level","0"),
    ("v", "1")
  };

}
