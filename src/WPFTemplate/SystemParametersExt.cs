using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WPFTemplate
{
    public class SystemParametersExt
    {
        #region Static setup (for XAML binding)
        public static SystemParametersExt instance { get; private set; }

        static SystemParametersExt() => instance = new();
        #endregion

        #region Extensions
        public Thickness WindowNonClientFrameThicknessTopOnly => new(0, SystemParameters.WindowNonClientFrameThickness.Top, 0, 0);

        public double BorderWidthLarger => SystemParameters.BorderWidth * 2; //This value is set to 1 in my testing and that is too small to be seen.

        public Thickness WindowResizeBorderThicknessLarger => new(
            SystemParameters.WindowResizeBorderThickness.Left * 2, //Left
            SystemParameters.WindowResizeBorderThickness.Top * 2, //Top
            SystemParameters.WindowResizeBorderThickness.Right * 2, //Right
            SystemParameters.WindowResizeBorderThickness.Bottom * 2); //Bottom

        public Thickness WindowResizeBorderThicknessLargerSides => new(WindowResizeBorderThicknessLarger.Left, 0,
            WindowResizeBorderThicknessLarger.Right, 0);

        public double WindowCaptionButtonWidthLarger => SystemParameters.WindowCaptionButtonWidth
            + (SystemParameters.ResizeFrameVerticalBorderWidth * 2);

        public Thickness FocusBorderThicknessSides => new(SystemParameters.FocusBorderWidth, 0, SystemParameters.FocusBorderWidth, 0);
        #endregion

        #region Base properties
        public CornerRadius WindowCornerRadius => SystemParameters.WindowCornerRadius;
        public double WindowCaptionHeight => SystemParameters.WindowCaptionHeight;
        public Thickness WindowResizeBorderThickness => SystemParameters.WindowResizeBorderThickness;
        public Thickness WindowNonClientFrameThickness => SystemParameters.WindowNonClientFrameThickness;
        public double FocusBorderWidth => SystemParameters.FocusBorderWidth;
        public double FocusBorderHeight => SystemParameters.FocusBorderHeight;
        public bool HighContrast => SystemParameters.HighContrast;
        public bool DropShadow => SystemParameters.DropShadow;
        public bool FlatMenu => SystemParameters.FlatMenu;
        public Rect WorkArea => SystemParameters.WorkArea;
        public double IconHorizontalSpacing => SystemParameters.IconHorizontalSpacing;
        public double IconVerticalSpacing => SystemParameters.IconVerticalSpacing;
        public bool IconTitleWrap => SystemParameters.IconTitleWrap;
        public bool KeyboardCues => SystemParameters.KeyboardCues;
        public int KeyboardDelay => SystemParameters.KeyboardDelay;
        public bool KeyboardPreference => SystemParameters.KeyboardPreference;
        public int KeyboardSpeed => SystemParameters.KeyboardSpeed;
        public bool SnapToDefaultButton => SystemParameters.SnapToDefaultButton;
        public int WheelScrollLines => SystemParameters.WheelScrollLines;
        public TimeSpan MouseHoverTime => SystemParameters.MouseHoverTime;
        public double MouseHoverHeight => SystemParameters.MouseHoverHeight;
        public double MouseHoverWidth => SystemParameters.MouseHoverWidth;
        public bool MenuDropAlignment => SystemParameters.MenuDropAlignment;
        public bool MenuFade => SystemParameters.MenuFade;
        public int MenuShowDelay => SystemParameters.MenuShowDelay;
        public PopupAnimation ComboBoxPopupAnimation => SystemParameters.ComboBoxPopupAnimation;
        public bool ComboBoxAnimation => SystemParameters.ComboBoxAnimation;
        public bool ClientAreaAnimation => SystemParameters.ClientAreaAnimation;
        public bool CursorShadow => SystemParameters.CursorShadow;
        public bool GradientCaptions => SystemParameters.GradientCaptions;
        public bool HotTracking => SystemParameters.HotTracking;
        public bool ListBoxSmoothScrolling => SystemParameters.ListBoxSmoothScrolling;
        public PopupAnimation MenuPopupAnimation => SystemParameters.MenuPopupAnimation;
        public bool MenuAnimation => SystemParameters.MenuAnimation;
        public bool SelectionFade => SystemParameters.SelectionFade;
        public bool StylusHotTracking => SystemParameters.StylusHotTracking;
        public PopupAnimation ToolTipPopupAnimation => SystemParameters.ToolTipPopupAnimation;
        public bool ToolTipAnimation => SystemParameters.ToolTipAnimation;
        public bool ToolTipFade => SystemParameters.ToolTipFade;
        public bool UIEffects => SystemParameters.UIEffects;
        public bool MinimizeAnimation => SystemParameters.MinimizeAnimation;
        public int Border => SystemParameters.Border;
        public double CaretWidth => SystemParameters.CaretWidth;
        public bool DragFullWindows => SystemParameters.DragFullWindows;
        public int ForegroundFlashCount => SystemParameters.ForegroundFlashCount;
        public double BorderWidth => SystemParameters.BorderWidth;
        public double ScrollWidth => SystemParameters.ScrollWidth;
        public double ScrollHeight => SystemParameters.ScrollHeight;
        public double CaptionWidth => SystemParameters.CaptionWidth;
        public double CaptionHeight => SystemParameters.CaptionHeight;
        public double SmallCaptionWidth => SystemParameters.SmallCaptionWidth;
        public double SmallCaptionHeight => SystemParameters.SmallCaptionHeight;
        public double MenuWidth => SystemParameters.MenuWidth;
        public double MenuHeight => SystemParameters.MenuHeight;
        public double ThinHorizontalBorderHeight => SystemParameters.ThinHorizontalBorderHeight;
        public double ThinVerticalBorderWidth => SystemParameters.ThinVerticalBorderWidth;
        public double CursorWidth => SystemParameters.CursorWidth;
        public double CursorHeight => SystemParameters.CursorHeight;
        public double ThickHorizontalBorderHeight => SystemParameters.ThickHorizontalBorderHeight;
        public double ThickVerticalBorderWidth => SystemParameters.ThickVerticalBorderWidth;
        public double MinimumHorizontalDragDistance => SystemParameters.MinimumHorizontalDragDistance;
        public double MinimumVerticalDragDistance => SystemParameters.MinimumVerticalDragDistance;
        public double FixedFrameHorizontalBorderHeight => SystemParameters.FixedFrameHorizontalBorderHeight;
        public double FixedFrameVerticalBorderWidth => SystemParameters.FixedFrameVerticalBorderWidth;
        public double FocusHorizontalBorderHeight => SystemParameters.FocusHorizontalBorderHeight;
        public double FocusVerticalBorderWidth => SystemParameters.FocusVerticalBorderWidth;
        public double FullPrimaryScreenWidth => SystemParameters.FullPrimaryScreenWidth;
        public double FullPrimaryScreenHeight => SystemParameters.FullPrimaryScreenHeight;
        public double HorizontalScrollBarButtonWidth => SystemParameters.HorizontalScrollBarButtonWidth;
        public double HorizontalScrollBarHeight => SystemParameters.HorizontalScrollBarHeight;
        public double HorizontalScrollBarThumbWidth => SystemParameters.HorizontalScrollBarThumbWidth;
        public double IconWidth => SystemParameters.IconWidth;
        public double IconHeight => SystemParameters.IconHeight;
        public double IconGridWidth => SystemParameters.IconGridWidth;
        public double IconGridHeight => SystemParameters.IconGridHeight;
        public double MaximizedPrimaryScreenWidth => SystemParameters.MaximizedPrimaryScreenWidth;
        public double MaximizedPrimaryScreenHeight => SystemParameters.MaximizedPrimaryScreenHeight;
        public double MaximumWindowTrackWidth => SystemParameters.MaximumWindowTrackWidth;
        public double MaximumWindowTrackHeight => SystemParameters.MaximumWindowTrackHeight;
        public double MenuCheckmarkWidth => SystemParameters.MenuCheckmarkWidth;
        public double MenuCheckmarkHeight => SystemParameters.MenuCheckmarkHeight;
        public double MenuButtonWidth => SystemParameters.MenuButtonWidth;
        public double MenuButtonHeight => SystemParameters.MenuButtonHeight;
        public double MinimumWindowWidth => SystemParameters.MinimumWindowWidth;
        public double MinimumWindowHeight => SystemParameters.MinimumWindowHeight;
        public double MinimizedWindowWidth => SystemParameters.MinimizedWindowWidth;
        public double MinimizedWindowHeight => SystemParameters.MinimizedWindowHeight;
        public double MinimizedGridWidth => SystemParameters.MinimizedGridWidth;
        public double MinimizedGridHeight => SystemParameters.MinimizedGridHeight;
        public double MinimumWindowTrackWidth => SystemParameters.MinimumWindowTrackWidth;
        public double MinimumWindowTrackHeight => SystemParameters.MinimumWindowTrackHeight;
        public double PrimaryScreenWidth => SystemParameters.PrimaryScreenWidth;
        public double PrimaryScreenHeight => SystemParameters.PrimaryScreenHeight;
        public double WindowCaptionButtonWidth => SystemParameters.WindowCaptionButtonWidth;
        public double WindowCaptionButtonHeight => SystemParameters.WindowCaptionButtonHeight;
        public double ResizeFrameHorizontalBorderHeight => SystemParameters.ResizeFrameHorizontalBorderHeight;
        public double ResizeFrameVerticalBorderWidth => SystemParameters.ResizeFrameVerticalBorderWidth;
        public double SmallIconWidth => SystemParameters.SmallIconWidth;
        public double SmallIconHeight => SystemParameters.SmallIconHeight;
        public double SmallWindowCaptionButtonWidth => SystemParameters.SmallWindowCaptionButtonWidth;
        public double SmallWindowCaptionButtonHeight => SystemParameters.SmallWindowCaptionButtonHeight;
        public double VirtualScreenWidth => SystemParameters.VirtualScreenWidth;
        public double VirtualScreenHeight => SystemParameters.VirtualScreenHeight;
        public double VerticalScrollBarWidth => SystemParameters.VerticalScrollBarWidth;
        public double VerticalScrollBarButtonHeight => SystemParameters.VerticalScrollBarButtonHeight;
        public double KanjiWindowHeight => SystemParameters.KanjiWindowHeight;
        public double MenuBarHeight => SystemParameters.MenuBarHeight;
        public double VerticalScrollBarThumbHeight => SystemParameters.VerticalScrollBarThumbHeight;
        public bool IsImmEnabled => SystemParameters.IsImmEnabled;
        public bool IsMediaCenter => SystemParameters.IsMediaCenter;
        public bool IsMenuDropRightAligned => SystemParameters.IsMenuDropRightAligned;
        public bool IsMiddleEastEnabled => SystemParameters.IsMiddleEastEnabled;
        public bool IsMousePresent => SystemParameters.IsMousePresent;
        public bool IsMouseWheelPresent => SystemParameters.IsMouseWheelPresent;
        public bool IsPenWindows => SystemParameters.IsPenWindows;
        public bool IsRemotelyControlled => SystemParameters.IsRemotelyControlled;
        public bool IsRemoteSession => SystemParameters.IsRemoteSession;
        public bool ShowSounds => SystemParameters.ShowSounds;
        public bool IsSlowMachine => SystemParameters.IsSlowMachine;
        public bool SwapButtons => SystemParameters.SwapButtons;
        public bool IsTabletPC => SystemParameters.IsTabletPC;
        public double VirtualScreenLeft => SystemParameters.VirtualScreenLeft;
        public double VirtualScreenTop => SystemParameters.VirtualScreenTop;
        public PowerLineStatus PowerLineStatus => SystemParameters.PowerLineStatus;
        public bool IsGlassEnabled => SystemParameters.IsGlassEnabled;
        public string UxThemeName => SystemParameters.UxThemeName;
        public string UxThemeColor => SystemParameters.UxThemeColor;
        public Color WindowGlassColor => SystemParameters.WindowGlassColor;
        public Brush WindowGlassBrush => SystemParameters.WindowGlassBrush;
        #endregion

        #region Debug
#if DEBUG
        public static void GetSystemParametersInfo()
        {
            //Used to export values for inspection, add a breakpoint and export to csv.
            string classString = "";
            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in typeof(SystemParameters).GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (propertyInfo.Name.EndsWith("Key")) continue;
                classString += $"public {propertyInfo.PropertyType.Name} {propertyInfo.Name} => {nameof(SystemParameters)}.{propertyInfo.Name};\n";
                properties.Add(propertyInfo.Name, propertyInfo.GetValue(null));
            }
            ;
        }
#endif
        #endregion
    }
}
