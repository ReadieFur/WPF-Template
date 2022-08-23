using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class Slider : System.Windows.Controls.Slider
    {
        #region Background
        public static readonly DependencyProperty HoverBackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(HoverBackground), "#FFDCECFC".ToBrush());
        public Brush HoverBackground { get => (Brush)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(PressedBackground), "#FFDAECFC".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(DisabledBackground), "#FFF0F0F0".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }

        public static readonly DependencyProperty TrackBackgroundDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(TrackBackground), "#FFE7EAEA".ToBrush());
        public Brush TrackBackground { get => (Brush)GetValue(TrackBackgroundDP); set => SetValue(TrackBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty HoverBorderBrushDP = DependencyExt.RegisterDependencyProperty<Slider, Brush>(nameof(HoverBorderBrush), "#FF7Eb4EA".ToBrush());
        public Brush HoverBorderBrush { get => (Brush)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

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

        public Slider()
        {
            DataContext = this;
            Loaded += OnLoaded;
        }
        #endregion
    }
}
