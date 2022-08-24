using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class RadioButton : System.Windows.Controls.RadioButton
    {
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(BorderBrush), "#FF707070".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(MouseOverBackground), "#FFF3F9FF".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundProperty); set => SetValue(MouseOverBackgroundProperty, value); }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(PressedBackground), "#FFD9ECFF".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundProperty); set => SetValue(PressedBackgroundProperty, value); }

        public static readonly DependencyProperty DisabledBackgroundProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(DisabledBackground), "#FFE6E6E6".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundProperty); set => SetValue(DisabledBackgroundProperty, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(MouseOverBorderBrush), "#FF5593FF".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushProperty); set => SetValue(MouseOverBorderBrushProperty, value); }

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(PressedBorderBrush), "#FF3C77DD".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushProperty); set => SetValue(PressedBorderBrushProperty, value); }

        public static readonly DependencyProperty DisabledBorderBrushProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(DisabledBorderBrush), "#FFBCBCBC".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushProperty); set => SetValue(DisabledBorderBrushProperty, value); }
        #endregion

        #region Glyph
        public static readonly DependencyProperty GlyphProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(Glyph), "#FF212121".ToBrush());
        public Brush Glyph { get => (Brush)GetValue(GlyphProperty); set => SetValue(GlyphProperty, value); }

        public static readonly DependencyProperty MouseOverGlyphProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(MouseOverGlyph), "#FF212121".ToBrush());
        public Brush MouseOverGlyph { get => (Brush)GetValue(MouseOverGlyphProperty); set => SetValue(MouseOverGlyphProperty, value); }

        public static readonly DependencyProperty PressedGlyphProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(PressedGlyph), "#FF212121".ToBrush());
        public Brush PressedGlyph { get => (Brush)GetValue(PressedGlyphProperty); set => SetValue(PressedGlyphProperty, value); }

        public static readonly DependencyProperty DisabledGlyphProperty = DependencyExt.RegisterDependencyProperty<RadioButton, Brush>(nameof(DisabledGlyph), "#FF707070".ToBrush());
        public Brush DisabledGlyph { get => (Brush)GetValue(DisabledGlyphProperty); set => SetValue(DisabledGlyphProperty, value); }
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

        public RadioButton() => Loaded += OnLoaded;
        #endregion
    }
}
