using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class Button : System.Windows.Controls.Button
    {
        //See the comments left in "WPFTemplate.Tests.Testing.BindingProperty.cs" for more information on this.
        //TL;DR: The way WPF makes you work with this is VERY messy and EXTREMELY repetitive. I tried abstracting it but WPF said no.
        
        //This was causing issues on this element for some reason, I'm unsure as to why.
        /*public static readonly DependencyProperty BackgroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(Background), "#FFDDDDDD".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty BorderBrushDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(BorderBrush), "#FF707070".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty ForegroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }*/

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(MouseOverBackground), "#FFBEE6FD".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundDP); set => SetValue(MouseOverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(PressedBackground), "#FFC4E5F6".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(DisabledBackground), "#FFF4F4F4".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(MouseOverBorderBrush), "#FF3C7FB1".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushDP); set => SetValue(MouseOverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(PressedBorderBrush), "#FF2C628B".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(DisabledBorderBrush), "#FFADB2B5".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty MouseOverForegroundDP = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(MouseOverForeground), "#FF000000".ToBrush());
        public Brush MouseOverForeground { get => (Brush)GetValue(MouseOverForegroundDP); set => SetValue(MouseOverForegroundDP, value); }

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
            styleHasChanged = true;
            base.OnStyleChanged(oldStyle, newStyle);
        }
        #endregion
        
        static Button() => BASE_STYLE.Seal();

        public Button() => Loaded += OnLoaded;
        #endregion
    }
}
