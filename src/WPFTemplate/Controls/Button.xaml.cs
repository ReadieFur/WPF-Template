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
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(Background), "#FFDDDDDD".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(BorderBrush), "#FF707070".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(MouseOverBackground), "#FFBEE6FD".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundProperty); set => SetValue(MouseOverBackgroundProperty, value); }

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(PressedBackground), "#FFC4E5F6".ToBrush());
        public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundProperty); set => SetValue(PressedBackgroundProperty, value); }

        public static readonly DependencyProperty DisabledBackgroundProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(DisabledBackground), "#FFF4F4F4".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundProperty); set => SetValue(DisabledBackgroundProperty, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(MouseOverBorderBrush), "#FF3C7FB1".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushProperty); set => SetValue(MouseOverBorderBrushProperty, value); }

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(PressedBorderBrush), "#FF2C628B".ToBrush());
        public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushProperty); set => SetValue(PressedBorderBrushProperty, value); }

        public static readonly DependencyProperty DisabledBorderBrushProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(DisabledBorderBrush), "#FFADB2B5".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushProperty); set => SetValue(DisabledBorderBrushProperty, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(MouseOverForeground), "#FF000000".ToBrush());
        public Brush MouseOverForeground { get => (Brush)GetValue(MouseOverForegroundProperty); set => SetValue(MouseOverForegroundProperty, value); }

        public static readonly DependencyProperty PressedForegroundProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(PressedForeground), "#FF000000".ToBrush());
        public Brush PressedForeground { get => (Brush)GetValue(PressedForegroundProperty); set => SetValue(PressedForegroundProperty, value); }

        public static readonly DependencyProperty DisabledForegroundProperty = DependencyExt.RegisterDependencyProperty<Button, Brush>(nameof(DisabledForeground), "#FF838383".ToBrush());
        public Brush DisabledForeground { get => (Brush)GetValue(DisabledForegroundProperty); set => SetValue(DisabledForegroundProperty, value); }
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
