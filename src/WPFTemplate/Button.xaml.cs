using System;
using System.Windows;

namespace WPFTemplate
{
    public partial class Button : System.Windows.Controls.Button
    {
        //See the comments left in BindingProperty.cs for more information on this.
        //TL;DR: The way WPF makes you work with this is VERY messy and EXTREMELY repetitive. I tried abstracting it but WPF said no.
        #region Background
        public static readonly DependencyProperty BackgroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(Background), "#FFDDDDDD");
        new public string Background { get => (string)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty HoverBackgroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(HoverBackground), "#FFBEE6FD");
        public string HoverBackground { get => (string)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(PressedBackground), "#FFC4E5F6");
        public string PressedBackground { get => (string)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(DisabledBackground), "#FFF4F4F4");
        public string DisabledBackground { get => (string)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty BorderBrushDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(BorderBrush), "#FF707070");
        new public string BorderBrush { get => (string)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty HoverBorderBrushDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(HoverBorderBrush), "#FF3C7FB1");
        public string HoverBorderBrush { get => (string)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty PressedBorderBrushDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(PressedBorderBrush), "#FF2C628B");
        public string PressedBorderBrush { get => (string)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(DisabledBorderBrush), "#FFADB2B5");
        public string DisabledBorderBrush { get => (string)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty ForegroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(Foreground), "#FF000000");
        new public string Foreground { get => (string)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }

        public static readonly DependencyProperty HoverForegroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(HoverForeground), "#FF000000");
        public string HoverForeground { get => (string)GetValue(HoverForegroundDP); set => SetValue(HoverForegroundDP, value); }

        public static readonly DependencyProperty PressedForegroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(PressedForeground), "#FF000000");
        public string PressedForeground { get => (string)GetValue(PressedForegroundDP); set => SetValue(PressedForegroundDP, value); }

        public static readonly DependencyProperty DisabledForegroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(DisabledForeground), "#FF838383");
        public string DisabledForeground { get => (string)GetValue(DisabledForegroundDP); set => SetValue(DisabledForegroundDP, value); }
        #endregion

        [Obsolete("This property is not changeable.", true)]
        new public Button DataContext => (Button)base.DataContext;

        public Button()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
