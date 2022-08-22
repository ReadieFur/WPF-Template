using System;
using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class CheckBox : System.Windows.Controls.CheckBox
    {
        public static readonly ResourceDictionary resources = ResourceDictionaryExt.LoadControlResourceDictionary<CheckBox>();

        #region Background
        public static readonly DependencyProperty HoverBackgroundDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(HoverBackground), "#FFF3F9FF".ToBrush());
        public Brush HoverBackground { get => (Brush)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedBackground), "#FFD9ECFF".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledBackground), "#FFE6E6E6".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty HoverBorderBrushDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(HoverBorderBrush), "#FF5593FF".ToBrush());
        public Brush HoverBorderBrush { get => (Brush)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedBorderBrush), "#FF3C77DD".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledBorderBrush), "#FFBCBCBC".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion

        #region Glyph
        public static readonly DependencyProperty GlyphDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(Glyph), "#FF212121".ToBrush());
        public Brush Glyph { get => (Brush)GetValue(GlyphDP); set => SetValue(GlyphDP, value); }

        public static readonly DependencyProperty HoverGlyphDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(HoverGlyph), "#FF212121".ToBrush());
        public Brush HoverGlyph { get => (Brush)GetValue(HoverGlyphDP); set => SetValue(HoverGlyphDP, value); }

        public static readonly DependencyProperty PressedGlyphDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedGlyph), "#FF212121".ToBrush());
        public Brush PressedGlyph { get => (Brush)GetValue(PressedGlyphDP); set => SetValue(PressedGlyphDP, value); }

        public static readonly DependencyProperty DisabledGlyphDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledGlyph), "#FF707070".ToBrush());
        public Brush DisabledGlyph { get => (Brush)GetValue(DisabledGlyphDP); set => SetValue(DisabledGlyphDP, value); }
        #endregion

        #region Hidden base properties
        [Obsolete("This property is not changeable.", true)]
        new public Style Style { get => base.Style; set => base.Style = value; }

        [Obsolete("This property is not changeable.", true)]
        new public object DataContext { get => base.DataContext; set => base.DataContext = value; }
        #endregion

        public CheckBox()
        {
            base.Style = resources.GetResource<Style>(nameof(CheckBox));
            base.DataContext = this;
        }
    }
}
