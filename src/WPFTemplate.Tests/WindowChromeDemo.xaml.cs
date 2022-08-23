using WPFTemplate.Controls;
using WPFTemplate.Styles;

namespace WPFTemplate.Tests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowChromeDemo : WindowChrome
    {
        public WindowChromeDemo()
        {
            InitializeComponent();

            StylesManager.onChange += StylesManager_onChange;
            //Trigger the styles to be updated here to override the default values.
            StylesManager_onChange();
        }

        private void StylesManager_onChange()
        {
            Dispatcher.Invoke(() =>
            {
                Foreground = StylesManager.foreground;
                Background = StylesManager.background;
                BackgroundAlt = StylesManager.backgroundAlt;
                Accent = StylesManager.accent;
            });
        }
    }
}
