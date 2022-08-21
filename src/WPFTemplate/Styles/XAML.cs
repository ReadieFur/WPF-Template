using System.Windows;

namespace WPFTemplate.Styles
{
    public class XAML : DependencyObject
    {
        public static readonly DependencyProperty foregroundDP = Helpers.RegisterDependencyProperty<XAML, string>(nameof(foreground), Styles.foreground.ToString());
        public string foreground { get => (string)GetValue(foregroundDP); set => SetValue(foregroundDP, value); }

        public static readonly DependencyProperty backgroundDP = Helpers.RegisterDependencyProperty<XAML, string>(nameof(background), Styles.background.ToString());
        public string background { get => (string)GetValue(backgroundDP); set => SetValue(backgroundDP, value); }

        public static readonly DependencyProperty backgroundAltDP = Helpers.RegisterDependencyProperty<XAML, string>(nameof(backgroundAlt), Styles.backgroundAlt.ToString());
        public string backgroundAlt { get => (string)GetValue(backgroundAltDP); set => SetValue(backgroundAltDP, value); }

        public static readonly DependencyProperty accentDP = Helpers.RegisterDependencyProperty<XAML, string>(nameof(accent), Styles.accent.ToString());
        public string accent { get => (string)GetValue(accentDP); set => SetValue(accentDP, value); }

        public XAML()
        {
            Styles.onChange += () => Helpers.InvokeDispatcher(Styles_onChange);
        }

        protected virtual void Styles_onChange()
        {
            foreground = Styles.foreground.ToString();
            background = Styles.background.ToString();
            backgroundAlt = Styles.backgroundAlt.ToString();
            accent = Styles.accent.ToString();
        }
    }
}
