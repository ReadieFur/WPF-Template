using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class Slider : System.Windows.Controls.Slider
    {
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(Background), "#FFF0F0F0".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(BorderBrush), "#FFACACAC".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(Foreground), "#FFE5E5E5".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(MouseOverBackground), "#FFDCECFC".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundProperty); set => SetValue(MouseOverBackgroundProperty, value); }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(PressedBackground), "#FFDAECFC".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundProperty); set => SetValue(PressedBackgroundProperty, value); }

        public static readonly DependencyProperty DisabledBackgroundProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(DisabledBackground), "#FFF0F0F0".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundProperty); set => SetValue(DisabledBackgroundProperty, value); }

        public static readonly DependencyProperty TrackBackgroundProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(TrackBackground), "#FFE7EAEA".ToBrush());
        public Brush TrackBackground { get => (Brush)GetValue(TrackBackgroundProperty); set => SetValue(TrackBackgroundProperty, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(MouseOverBorderBrush), "#FF7Eb4EA".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushProperty); set => SetValue(MouseOverBorderBrushProperty, value); }

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(PressedBorderBrush), "#FF569DE5".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushProperty); set => SetValue(PressedBorderBrushProperty, value); }

        public static readonly DependencyProperty DisabledBorderBrushProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(DisabledBorderBrush), "#FFD9D9D9".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushProperty); set => SetValue(DisabledBorderBrushProperty, value); }

        public static readonly DependencyProperty TrackBorderBrushProperty = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(TrackBorderBrush), "#FFD6D6D6".ToBrush());
        public Brush TrackBorderBrush { get => (Brush)GetValue(TrackBorderBrushProperty); set => SetValue(TrackBorderBrushProperty, value); }
        #endregion

        #region I wish multi-inheritance was a thing.
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<Slider>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(Slider));

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

        static Slider() => BASE_STYLE.Seal();

        public Slider() => Loaded += OnLoaded;
        #endregion
    }
}
