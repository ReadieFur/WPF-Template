using System;
using System.Windows;

namespace WPFTemplate
{
    public partial class Slider : System.Windows.Controls.Slider
    {
        #region Background
        public static readonly DependencyProperty BackgroundDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(Background), "#FFF0F0F0");
        new public string Background { get => (string)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty HoverBackgroundDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(HoverBackground), "#FFDCECFC");
        public string HoverBackground { get => (string)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(PressedBackground), "#FFDAECFC");
        public string PressedBackground { get => (string)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(DisabledBackground), "#FFF0F0F0");
        public string DisabledBackground { get => (string)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }

        public static readonly DependencyProperty TrackBackgroundDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(TrackBackground), "#FFE7EAEA");
        public string TrackBackground { get => (string)GetValue(TrackBackgroundDP); set => SetValue(TrackBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty BorderBrushDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(BorderBrush), "#FFACACAC");
        new public string BorderBrush { get => (string)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty HoverBorderBrushDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(HoverBorderBrush), "#FF7Eb4EA");
        public string HoverBorderBrush { get => (string)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(PressedBorderBrush), "#FF569DE5");
        public string PressedBorderBrush { get => (string)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(DisabledBorderBrush), "#FFD9D9D9");
        public string DisabledBorderBrush { get => (string)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }

        public static readonly DependencyProperty TrackBorderBrushDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(TrackBorderBrush), "#FFD6D6D6");
        public string TrackBorderBrush { get => (string)GetValue(TrackBorderBrushDP); set => SetValue(TrackBorderBrushDP, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty ForegroundDP = Helpers.RegisterDependencyProperty<Slider, string>(nameof(Foreground), "#FFE5E5E5");
        new public string Foreground { get => (string)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }
        #endregion

        [Obsolete("This property is not changeable.", true)]
        new public Slider DataContext => (Slider)base.DataContext;

        public Slider()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
