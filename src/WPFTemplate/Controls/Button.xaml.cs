using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class Button : System.Windows.Controls.Button
    {
        //See the comments left in "WPFTemplate.Tests.Testing.BindingProperty.cs" for more information on this.
        //TL;DR: The way WPF makes you work with this is VERY messy and EXTREMELY repetitive. I tried abstracting it but WPF said no.
        #region Background
        public static readonly DependencyProperty HoverBackgroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(HoverBackground), "#FFBEE6FD".ToBrush());
        public Brush HoverBackground { get => (Brush)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(PressedBackground), "#FFC4E5F6".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(DisabledBackground), "#FFF4F4F4".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty HoverBorderBrushDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(HoverBorderBrush), "#FF3C7FB1".ToBrush());
        public Brush HoverBorderBrush { get => (Brush)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(PressedBorderBrush), "#FF2C628B".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(DisabledBorderBrush), "#FFADB2B5".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty HoverForegroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(HoverForeground), "#FF000000".ToBrush());
        public Brush HoverForeground { get => (Brush)GetValue(HoverForegroundDP); set => SetValue(HoverForegroundDP, value); }

        public static readonly DependencyProperty PressedForegroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(PressedForeground), "#FF000000".ToBrush());
        public Brush PressedForeground { get => (Brush)GetValue(PressedForegroundDP); set => SetValue(PressedForegroundDP, value); }

        public static readonly DependencyProperty DisabledForegroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(DisabledForeground), "#FF838383".ToBrush());
        public Brush DisabledForeground { get => (Brush)GetValue(DisabledForegroundDP); set => SetValue(DisabledForegroundDP, value); }
        #endregion

        #region I wish multi-inheritance was a thing.
        //...And no I don't mean interfaces.
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<Button>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(Button));

        protected bool styleHasChanged = false;

        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!styleHasChanged) Style = BASE_STYLE;
        }

        protected override void OnStyleChanged(Style? oldStyle, Style? newStyle)
        {
            if (newStyle == null) newStyle = BASE_STYLE;
            else
            {
                newStyle = newStyle.Unseal();
                newStyle.SetRootStyle(BASE_STYLE);
            }

            base.OnStyleChanged(oldStyle, newStyle);
        }
        #endregion
        
        static Button() => BASE_STYLE.Seal();

        public Button()
        {
            DataContext = this;
            Loaded += OnLoaded;
        }
        #endregion
    }
}
