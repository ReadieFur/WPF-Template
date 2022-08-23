using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Styles
{
    public class BindableStyles : DependencyObject
    {
        public static readonly DependencyProperty foregroundDP = DependencyExt.RegisterDependencyProperty<BindableStyles, SolidColorBrush>(nameof(foreground), StylesManager.foreground);
        public SolidColorBrush foreground { get => (SolidColorBrush)GetValue(foregroundDP); set => SetValue(foregroundDP, value); }

        public static readonly DependencyProperty backgroundDP = DependencyExt.RegisterDependencyProperty<BindableStyles, SolidColorBrush>(nameof(background), StylesManager.background);
        public SolidColorBrush background { get => (SolidColorBrush)GetValue(backgroundDP); set => SetValue(backgroundDP, value); }

        public static readonly DependencyProperty backgroundAltDP = DependencyExt.RegisterDependencyProperty<BindableStyles, SolidColorBrush>(nameof(backgroundAlt), StylesManager.backgroundAlt);
        public SolidColorBrush backgroundAlt { get => (SolidColorBrush)GetValue(backgroundAltDP); set => SetValue(backgroundAltDP, value); }

        public static readonly DependencyProperty accentDP = DependencyExt.RegisterDependencyProperty<BindableStyles, Brush>(nameof(accent), StylesManager.accent);
        public Brush accent { get => (Brush)GetValue(accentDP); set => SetValue(accentDP, value); }

        public BindableStyles() => StylesManager.onChange += Styles_onChange;

        protected virtual void Styles_onChange()
        {
            DispatcherExt.InvokeDispatcher(() =>
            {
                foreground = StylesManager.foreground;
                background = StylesManager.background;
                backgroundAlt = StylesManager.backgroundAlt;
                accent = StylesManager.accent;
            });
        }
    }
}
