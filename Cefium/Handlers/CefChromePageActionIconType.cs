namespace Cefium;

/// <summary>
/// Chrome page action icon types. Should be kept in sync with Chromium's
/// PageActionIconType type.
/// <c>cef_chrome_page_action_icon_type_t</c>
/// </summary>
[PublicAPI]
public enum CefChromePageActionIconType {

  BookmarkStar = 0,

  ClickToCall,

  CookieControls,

  FileSystemAccess,

  Find,

  HighEfficiency,

  IntentPicker,

  LocalCardMigration,

  ManagePasswords,

  PaymentsOfferNotification,

  PriceTracking,

  PwaInstall,

  QrCodeGenerator,

  ReaderMode,

  SaveAutofillAddress,

  SaveCard,

  SendTabToSelf,

  SharingHub,

  SideSearch,

  SmsRemoteFetcher,

  Translate,

  VirtualCardEnroll,

  VirtualCardManualFallback,

  Zoom,

  SaveIban,

  MandatoryReauth,

  PriceInsights,

  MaxValue = PriceInsights,

}
