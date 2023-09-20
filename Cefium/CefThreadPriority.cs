namespace Cefium;

public enum CefThreadPriority : int { // cef_thread_priority_t
  TpBackground = 0, // TP_BACKGROUND
  TpNormal = 1, // TP_NORMAL
  TpDisplay = 2, // TP_DISPLAY
  TpRealtimeAudio = 3, // TP_REALTIME_AUDIO
}
