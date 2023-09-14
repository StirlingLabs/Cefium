namespace Cefaloid;

public enum CefMessageLoopType : int { // cef_message_loop_type_t
  MlTypeDefault = 0, // ML_TYPE_DEFAULT
  MlTypeUi = 1, // ML_TYPE_UI
  MlTypeIo = 2, // ML_TYPE_IO
}