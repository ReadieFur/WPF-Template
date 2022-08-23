using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class RadioButton : System.Windows.Controls.RadioButton
    {
        #region Background
        public static readonly DependencyProperty HoverBackgroundDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(HoverBackground), "#FFF3F9FF".ToBrush());
        public Brush HoverBackground { get => (Brush)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(PressedBackground), "#FFD9ECFF".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(DisabledBackground), "#FFE6E6E6".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty HoverBorderBrushDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(HoverBorderBrush), "#FF5593FF".ToBrush());
        public Brush HoverBorderBrush { get => (Brush)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(PressedBorderBrush), "#FF3C77DD".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(DisabledBorderBrush), "#FFBCBCBC".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion

        #region Glyph
        public static readonly DependencyProperty GlyphDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(Glyph), "#FF212121".ToBrush());
        public Brush Glyph { get => (Brush)GetValue(GlyphDP); set => SetValue(GlyphDP, value); }

        public static readonly DependencyProperty HoverGlyphDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(HoverGlyph), "#FF212121".ToBrush());
        public Brush HoverGlyph { get => (Brush)GetValue(HoverGlyphDP); set => SetValue(HoverGlyphDP, value); }

        public static readonly DependencyProperty PressedGlyphDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(PressedGlyph), "#FF212121".ToBrush());
        public Brush PressedGlyph { get => (Brush)GetValue(PressedGlyphDP); set => SetValue(PressedGlyphDP, value); }

        public static readonly DependencyProperty DisabledGlyphDP = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(DisabledGlyph), "#FF707070".ToBrush());
        public Brush DisabledGlyph { get => (Brush)GetValue(DisabledGlyphDP); set => SetValue(DisabledGlyphDP, value); }
        #endregion

        #region I wish multi-inheritance was a thing.
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<RadioButton>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(RadioButton));

        protected bool styleHasChanged = false;

        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!styleHasChanged) Style = BASE_STYLE;
        }

        protected override void OnStyleChanged(Style? oldStyle, Style? newStyle)
        {
            styleHasChanged = true;
            base.OnStyleChanged(oldStyle, newStyle);
        }
        #endregion

        static RadioButton() => BASE_STYLE.Seal();

        public RadioButton()
        {
            DataContext = this;
            Loaded += OnLoaded;
        }
        #endregion
    }
}
