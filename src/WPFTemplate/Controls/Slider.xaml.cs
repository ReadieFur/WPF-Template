using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class Slider : System.Windows.Controls.Slider
    {
        public static readonly DependencyProperty BackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(Background), "#FFF0F0F0".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty BorderBrushDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(BorderBrush), "#FFACACAC".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty ForegroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(Foreground), "#FFE5E5E5".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(MouseOverBackground), "#FFDCECFC".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundDP); set => SetValue(MouseOverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(PressedBackground), "#FFDAECFC".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(DisabledBackground), "#FFF0F0F0".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }

        public static readonly DependencyProperty TrackBackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(TrackBackground), "#FFE7EAEA".ToBrush());
        public Brush TrackBackground { get => (Brush)GetValue(TrackBackgroundDP); set => SetValue(TrackBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(MouseOverBorderBrush), "#FF7Eb4EA".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushDP); set => SetValue(MouseOverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(PressedBorderBrush), "#FF569DE5".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(DisabledBorderBrush), "#FFD9D9D9".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }

        public static readonly DependencyProperty TrackBorderBrushDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(TrackBorderBrush), "#FFD6D6D6".ToBrush());
        public Brush TrackBorderBrush { get => (Brush)GetValue(TrackBorderBrushDP); set => SetValue(TrackBorderBrushDP, value); }
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
