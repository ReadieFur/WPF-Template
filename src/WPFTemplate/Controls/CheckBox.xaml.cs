using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class CheckBox : System.Windows.Controls.CheckBox
    {
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(BorderBrush), "#FF707070".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(MouseOverBackground), "#FFF3F9FF".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundProperty); set => SetValue(MouseOverBackgroundProperty, value); }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedBackground), "#FFD9ECFF".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundProperty); set => SetValue(PressedBackgroundProperty, value); }

        public static readonly DependencyProperty DisabledBackgroundProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledBackground), "#FFE6E6E6".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundProperty); set => SetValue(DisabledBackgroundProperty, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(MouseOverBorderBrush), "#FF5593FF".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushProperty); set => SetValue(MouseOverBorderBrushProperty, value); }

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedBorderBrush), "#FF3C77DD".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushProperty); set => SetValue(PressedBorderBrushProperty, value); }

        public static readonly DependencyProperty DisabledBorderBrushProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledBorderBrush), "#FFBCBCBC".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushProperty); set => SetValue(DisabledBorderBrushProperty, value); }
        #endregion

        #region Glyph
        public static readonly DependencyProperty GlyphProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(Glyph), "#FF212121".ToBrush());
        public Brush Glyph { get => (Brush)GetValue(GlyphProperty); set => SetValue(GlyphProperty, value); }

        public static readonly DependencyProperty MouseOverGlyphProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(MouseOverGlyph), "#FF212121".ToBrush());
        public Brush MouseOverGlyph { get => (Brush)GetValue(MouseOverGlyphProperty); set => SetValue(MouseOverGlyphProperty, value); }

        public static readonly DependencyProperty PressedGlyphProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedGlyph), "#FF212121".ToBrush());
        public Brush PressedGlyph { get => (Brush)GetValue(PressedGlyphProperty); set => SetValue(PressedGlyphProperty, value); }

        public static readonly DependencyProperty DisabledGlyphProperty = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledGlyph), "#FF707070".ToBrush());
        public Brush DisabledGlyph { get => (Brush)GetValue(DisabledGlyphProperty); set => SetValue(DisabledGlyphProperty, value); }
        #endregion

        #region I wish multi-inheritance was a thing.
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<CheckBox>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(CheckBox));

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

        static CheckBox() => BASE_STYLE.Seal();

        public CheckBox() => Loaded += OnLoaded;
        #endregion
    }
}
