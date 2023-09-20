namespace Cefium;

[PublicAPI, StructLayout(LayoutKind.Sequential, Size=48)]
public struct CefBoxLayoutSettings { // cef_box_layout_settings_t
  public int Horizontal; // horizontal @ 0, 4 bytes
  public int InsideBorderHorizontalSpacing; // inside_border_horizontal_spacing @ 4, 4 bytes
  public int InsideBorderVerticalSpacing; // inside_border_vertical_spacing @ 8, 4 bytes
  public CefInsets InsideBorderInsets; // inside_border_insets @ 12, 16 bytes
  public int BetweenChildSpacing; // between_child_spacing @ 28, 4 bytes
  public CefMainAxisAlignment MainAxisAlignment; // main_axis_alignment @ 32, 4 bytes
  public CefCrossAxisAlignment CrossAxisAlignment; // cross_axis_alignment @ 36, 4 bytes
  public int MinimumCrossAxisSize; // minimum_cross_axis_size @ 40, 4 bytes
  public int DefaultFlex; // default_flex @ 44, 4 bytes
}
