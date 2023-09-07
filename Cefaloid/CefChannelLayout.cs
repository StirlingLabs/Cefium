namespace Cefaloid;

/// <summary>
/// Enumerates the various representations of the ordering of audio channels.
/// Must be kept synchronized with media::ChannelLayout from Chromium.
/// See media\base\channel_layout.h
/// <c>cef_channel_layout_t</c>
/// </summary>
[PublicAPI]
public enum CefChannelLayout {

  /// <summary>
  /// <c>CEF_CHANNEL_LAYOUT_NONE</c>
  /// </summary>
  None = 0,

  /// <summary>
  /// <c>CEF_CHANNEL_LAYOUT_UNSUPPORTED</c>
  /// </summary>
  Unsupported = 1,

  /// <summary>
  /// Front C
  /// <c>CEF_CHANNEL_LAYOUT_MONO</c>
  /// </summary>
  Mono = 2,

  /// <summary>
  /// Front L, Front R
  /// <c>CEF_CHANNEL_LAYOUT_STEREO</c>
  /// </summary>
  Stereo = 3,

  /// <summary>
  /// Front L, Front R, Back C
  /// <c>CEF_CHANNEL_LAYOUT_2_1</c>
  /// </summary>
  _2_1 = 4,

  /// <summary>
  /// Front L, Front R, Front C
  /// <c>CEF_CHANNEL_LAYOUT_SURROUND</c>
  /// </summary>
  Surround = 5,

  /// <summary>
  /// Front L, Front R, Front C, Back C
  /// <c>CEF_CHANNEL_LAYOUT_4_0</c>
  /// </summary>
  _4_0 = 6,

  /// <summary>
  /// Front L, Front R, Side L, Side R
  /// <c>CEF_CHANNEL_LAYOUT_2_2</c>
  /// </summary>
  _2_2 = 7,

  /// <summary>
  /// Front L, Front R, Back L, Back R
  /// <c>CEF_CHANNEL_LAYOUT_QUAD</c>
  /// </summary>
  Quad = 8,

  /// <summary>
  /// Front L, Front R, Front C, Side L, Side R
  /// <c>CEF_CHANNEL_LAYOUT_5_0</c>
  /// </summary>
  _5_0 = 9,

  /// <summary>
  /// Front L, Front R, Front C, LFE, Side L, Side R
  /// <c>CEF_CHANNEL_LAYOUT_5_1</c>
  /// </summary>
  _5_1 = 10,

  /// <summary>
  /// Front L, Front R, Front C, Back L, Back R
  /// <c>CEF_CHANNEL_LAYOUT_5_0_BACK</c>
  /// </summary>
  _5_0_Back = 11,

  /// <summary>
  /// Front L, Front R, Front C, LFE, Back L, Back R
  /// <c>CEF_CHANNEL_LAYOUT_5_1_BACK</c>
  /// </summary>
  _5_1_Back = 12,

  /// <summary>
  /// Front L, Front R, Front C, Side L, Side R, Back L, Back R
  /// <c>CEF_CHANNEL_LAYOUT_7_0</c>
  /// </summary>
  _7_0 = 13,

  /// <summary>
  /// Front L, Front R, Front C, LFE, Side L, Side R, Back L, Back R
  /// <c>CEF_CHANNEL_LAYOUT_7_1</c>
  /// </summary>
  _7_1 = 14,

  /// <summary>
  /// Front L, Front R, Front C, LFE, Side L, Side R, Front LofC, Front RofC
  /// <c>CEF_CHANNEL_LAYOUT_7_1_WIDE</c>
  /// </summary>
  _7_1_Wide = 15,

  /// <summary>
  /// Stereo L, Stereo R
  /// <c>CEF_CHANNEL_LAYOUT_STEREO_DOWNMIX</c>
  /// </summary>
  StereoDownMix = 16,

  /// <summary>
  /// Stereo L, Stereo R, LFE
  /// <c>CEF_CHANNEL_LAYOUT_2POINT1</c>
  /// </summary>
  _2_1_LFE = 17,

  /// <summary>
  /// Stereo L, Stereo R, Front C, LFE
  /// <c>CEF_CHANNEL_LAYOUT_3_1</c>
  /// </summary>
  _3_1 = 18,

  /// <summary>
  /// Stereo L, Stereo R, Front C, Rear C, LFE
  /// <c>CEF_CHANNEL_LAYOUT_4_1</c>
  /// </summary>
  _4_1 = 19,

  /// <summary>
  /// Stereo L, Stereo R, Front C, Side L, Side R, Back C
  /// <c>CEF_CHANNEL_LAYOUT_6_0</c>
  /// </summary>
  _6_0 = 20,

  /// <summary>
  /// Stereo L, Stereo R, Side L, Side R, Front LofC, Front RofC
  /// <c>CEF_CHANNEL_LAYOUT_6_0_FRONT</c>
  /// </summary>
  _6_0_Front = 21,

  /// <summary>
  /// Stereo L, Stereo R, Front C, Rear L, Rear R, Rear C
  /// <c>CEF_CHANNEL_LAYOUT_HEXAGONAL</c>
  /// </summary>
  Hexagonal = 22,

  /// <summary>
  /// Stereo L, Stereo R, Front C, LFE, Side L, Side R, Rear Center
  /// <c>CEF_CHANNEL_LAYOUT_6_1</c>
  /// </summary>
  _6_1 = 23,

  /// <summary>
  /// Stereo L, Stereo R, Front C, LFE, Back L, Back R, Rear Center
  /// <c>CEF_CHANNEL_LAYOUT_6_1_BACK</c>
  /// </summary>
  _6_1_Back = 24,

  /// <summary>
  /// Stereo L, Stereo R, Side L, Side R, Front LofC, Front RofC, LFE
  /// <c>CEF_CHANNEL_LAYOUT_6_1_FRONT</c>
  /// </summary>
  _6_1_Front = 25,

  /// <summary>
  /// Front L, Front R, Front C, Side L, Side R, Front LofC, Front RofC
  /// <c>CEF_CHANNEL_LAYOUT_7_0_FRONT</c>
  /// </summary>
  _7_0_Front = 26,

  /// <summary>
  /// Front L, Front R, Front C, LFE, Back L, Back R, Front LofC, Front RofC
  /// <c>CEF_CHANNEL_LAYOUT_7_1_WIDE_BACK</c>
  /// </summary>
  _7_1_Wide_Back = 27,

  /// <summary>
  /// Front L, Front R, Front C, Side L, Side R, Rear L, Back R, Back C.
  /// <c>CEF_CHANNEL_LAYOUT_OCTAGONAL</c>
  /// </summary>
  Octagonal = 28,

  /// <summary>
  /// Channels are not explicitly mapped to speakers.
  /// <c>CEF_CHANNEL_LAYOUT_DISCRETE</c>
  /// </summary>
  Discrete = 29,

  /// <summary>
  /// Front L, Front R, Front C. Front C contains the keyboard mic audio. This
  /// layout is only intended for input for WebRTC. The Front C channel
  /// is stripped away in the WebRTC audio input pipeline and never seen outside
  /// of that.
  /// <c>CEF_CHANNEL_LAYOUT_STEREO_AND_KEYBOARD_MIC</c>
  /// </summary>
  StereoAndKeyboardMic = 30,

  /// <summary>
  /// Front L, Front R, Side L, Side R, LFE
  /// <c>CEF_CHANNEL_LAYOUT_4_1_QUAD_SIDE</c>
  /// </summary>
  _4_1_Quad_Side = 31,

  /// <summary>
  /// Actual channel layout is specified in the bitstream and the actual channel
  /// count is unknown at Chromium media pipeline level (useful for audio
  /// pass-through mode).
  /// <c>CEF_CHANNEL_LAYOUT_BITSTREAM</c>
  /// </summary>
  BitStream = 32,

  /// <summary>
  /// Front L, Front R, Front C, LFE, Side L, Side R,
  /// Front Height L, Front Height R, Rear Height L, Rear Height R
  /// Will be represented as six channels (5.1) due to eight channel limit
  /// kMaxConcurrentChannels
  /// <c>CEF_CHANNEL_LAYOUT_5_1_4_DOWNMIX</c>
  /// </summary>
  _5_1_4_DownMix = 33,

  /// <summary>
  /// Max value, must always equal the largest entry ever logged.
  /// <c>CEF_CHANNEL_LAYOUT_MAX = CEF_CHANNEL_LAYOUT_5_1_4_DOWNMIX</c>
  /// </summary>
  Max = _5_1_4_DownMix

}
