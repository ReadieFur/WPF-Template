using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class CheckBox : System.Windows.Controls.CheckBox
    {
        public static readonly DependencyProperty BackgroundDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty BorderBrushDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(BorderBrush), "#FF707070".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty ForegroundDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(MouseOverBackground), "#FFF3F9FF".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundDP); set => SetValue(MouseOverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedBackground), "#FFD9ECFF".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledBackground), "#FFE6E6E6".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(MouseOverBorderBrush), "#FF5593FF".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushDP); set => SetValue(MouseOverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedBorderBrush), "#FF3C77DD".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledBorderBrush), "#FFBCBCBC".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion

        #region Glyph
        public static readonly DependencyProperty GlyphDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(Glyph), "#FF212121".ToBrush());
        public Brush Glyph { get => (Brush)GetValue(GlyphDP); set => SetValue(GlyphDP, value); }

        public static readonly DependencyProperty MouseOverGlyphDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(MouseOverGlyph), "#FF212121".ToBrush());
        public Brush MouseOverGlyph { get => (Brush)GetValue(MouseOverGlyphDP); set => SetValue(MouseOverGlyphDP, value); }

        public static readonly DependencyProperty PressedGlyphDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(PressedGlyph), "#FF212121".ToBrush());
        public Brush PressedGlyph { get => (Brush)GetValue(PressedGlyphDP); set => SetValue(PressedGlyphDP, value); }

        public static readonly DependencyProperty DisabledGlyphDP = DependencyExt.RegisterDependencyProperty<CheckBox, Brush>(nameof(DisabledGlyph), "#FF707070".ToBrush());
        public Brush DisabledGlyph { get => (Brush)GetValue(DisabledGlyphDP); set => SetValue(DisabledGlyphDP, value); }
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
