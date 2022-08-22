using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Styles
{
    public class BindableStyles : DependencyObject
    {
        public static readonly DependencyProperty foregroundDP = DependencyExt.RegisterDependencyProperty<BindableStyles, SolidColorBrush>(nameof(foreground), Styles.foreground);
        public SolidColorBrush foreground { get => (SolidColorBrush)GetValue(foregroundDP); set => SetValue(foregroundDP, value); }

        public static readonly DependencyProperty backgroundDP = DependencyExt.RegisterDependencyProperty<BindableStyles, SolidColorBrush>(nameof(background), Styles.background);
        public SolidColorBrush background { get => (SolidColorBrush)GetValue(backgroundDP); set => SetValue(backgroundDP, value); }

        public static readonly DependencyProperty backgroundAltDP = DependencyExt.RegisterDependencyProperty<BindableStyles, SolidColorBrush>(nameof(backgroundAlt), Styles.backgroundAlt);
        public SolidColorBrush backgroundAlt { get => (SolidColorBrush)GetValue(backgroundAltDP); set => SetValue(backgroundAltDP, value); }

        public static readonly DependencyProperty accentDP = DependencyExt.RegisterDependencyProperty<BindableStyles, Brush>(nameof(accent), Styles.accent);
        public Brush accent { get => (Brush)GetValue(accentDP); set => SetValue(accentDP, value); }

        public BindableStyles()
        {
            Styles.onChange += Styles_onChange;
        }

        protected virtual void Styles_onChange()
        {
            DispatcherExt.InvokeDispatcher(() =>
            {
                foreground = Styles.foreground;
                background = Styles.background;
                backgroundAlt = Styles.backgroundAlt;
                accent = Styles.accent;
            });
        }
    }
}
