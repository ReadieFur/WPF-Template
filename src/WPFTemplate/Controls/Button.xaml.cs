using System;
using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class Button : System.Windows.Controls.Button
    {
        public static readonly ResourceDictionary resources = ResourceDictionaryExt.LoadControlResourceDictionary<Button>();

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

        #region Hidden base properties
        [Obsolete("This property is not changeable.", true)]
        new public Style Style { get => base.Style; set => base.Style = value; }

        [Obsolete("This property is not changeable.", true)]
        new public object DataContext { get => base.DataContext; set => base.DataContext = value; }
        #endregion
        
        public Button()
        {
            base.Style = resources.GetResource<Style>(nameof(Button));
            base.DataContext = this;
        }
    }
}
