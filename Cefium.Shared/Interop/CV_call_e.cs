namespace Cefium.Shared;

// CV_call_e
internal enum CallingConvention {

  NearC = 0x00,

  NearFast = 0x04,

  NearStd = 0x07,

  NearSys = 0x09,

  ThisCall = 0x0b,

  ClrCall = 0x16

}
