﻿namespace Cefaloid;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=64)]
public struct CefFillLayout { // cef_fill_layout_t
  public CefLayout Base; // base @ 0, 64 bytes
}