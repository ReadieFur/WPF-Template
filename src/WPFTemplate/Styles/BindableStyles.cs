using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Styles
{
    public class BindableStyles : DependencyObject
    {
        public static readonly DependencyProperty foregroundDP = DependencyExt.RegisterDependencyProperty<BindableStyles, Brush>(nameof(foreground), Styles.foreground);
        public Brush foreground { get => (Brush)GetValue(foregroundDP); set => SetValue(foregroundDP, value); }

        public static readonly DependencyProperty backgroundDP = DependencyExt.RegisterDependencyProperty<BindableStyles, Brush>(nameof(background), Styles.background);
        public Brush background { get => (Brush)GetValue(backgroundDP); set => SetValue(backgroundDP, value); }

        public static readonly DependencyProperty backgroundAltDP = DependencyExt.RegisterDependencyProperty<BindableStyles, Brush>(nameof(backgroundAlt), Styles.backgroundAlt);
        public Brush backgroundAlt { get => (Brush)GetValue(backgroundAltDP); set => SetValue(backgroundAltDP, value); }

        public static readonly DependencyProperty accentDP = DependencyExt.RegisterDependencyProperty<BindableStyles, Brush>(nameof(accent), Styles.accent);
        public Brush accent { get => (Brush)GetValue(accentDP); set => SetValue(accentDP, value); }

        public BindableStyles()
        {
            Styles.onChange += () => DispatcherExt.InvokeDispatcher(Styles_onChange);
        }

        protected virtual void Styles_onChange()
        {
            foreground = Styles.foreground;
            background = Styles.background;
            backgroundAlt = Styles.backgroundAlt;
            accent = Styles.accent;
        }
    }
}
