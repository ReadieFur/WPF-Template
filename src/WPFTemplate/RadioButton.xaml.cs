using System;
using System.Windows;

namespace WPFTemplate
{
    public partial class RadioButton : System.Windows.Controls.RadioButton
    {
        #region Background
        public static readonly DependencyProperty BackgroundDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(Background), "#FFFFFFFF");
        new public string Background { get => (string)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty HoverBackgroundDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(HoverBackground), "#FFF3F9FF");
        public string HoverBackground { get => (string)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(PressedBackground), "#FFD9ECFF");
        public string PressedBackground { get => (string)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(DisabledBackground), "#FFE6E6E6");
        public string DisabledBackground { get => (string)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty BorderBrushDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(BorderBrush), "#FF707070");
        new public string BorderBrush { get => (string)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty HoverBorderBrushDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(HoverBorderBrush), "#FF5593FF");
        public string HoverBorderBrush { get => (string)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(PressedBorderBrush), "#FF3C77DD");
        public string PressedBorderBrush { get => (string)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(DisabledBorderBrush), "#FFBCBCBC");
        public string DisabledBorderBrush { get => (string)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion

        #region Glyph
        public static readonly DependencyProperty GlyphDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(Glyph), "#FF212121");
        public string Glyph { get => (string)GetValue(GlyphDP); set => SetValue(GlyphDP, value); }

        public static readonly DependencyProperty HoverGlyphDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(HoverGlyph), "#FF212121");
        public string HoverGlyph { get => (string)GetValue(HoverGlyphDP); set => SetValue(HoverGlyphDP, value); }

        public static readonly DependencyProperty PressedGlyphDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(PressedGlyph), "#FF212121");
        public string PressedGlyph { get => (string)GetValue(PressedGlyphDP); set => SetValue(PressedGlyphDP, value); }

        public static readonly DependencyProperty DisabledGlyphDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(DisabledGlyph), "#FF707070");
        public string DisabledGlyph { get => (string)GetValue(DisabledGlyphDP); set => SetValue(DisabledGlyphDP, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty ForegroundDP = Helpers.RegisterDependencyProperty<RadioButton, string>(nameof(Foreground), "#FF000000");
        new public string Foreground { get => (string)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }
        #endregion

        [Obsolete("This property is not changeable.", true)]
        new public RadioButton DataContext => (RadioButton)base.DataContext;

        public RadioButton()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
