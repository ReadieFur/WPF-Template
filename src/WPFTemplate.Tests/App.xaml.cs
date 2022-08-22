using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;
using WPFTemplate.Extensions;

namespace WPFTemplate.Tests
{
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
#if DEBUG
            #region Testing
            //new DataBinding().ShowDialog();
            //new TypeConversion().ShowDialog();
            //SystemParametersExt.GetSystemParametersInfo();
            //SystemFontsExt.GetSystemParametersInfo();
            //new Window1().ShowDialog();
            #endregion
#endif
            await Task.WhenAny(
                new ElementsDemo().ShowAsync(),
                new WindowChromeDemo().ShowAsync()
            );

            Environment.Exit(0);
        }
    }
}
