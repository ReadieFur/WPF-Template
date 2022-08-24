using System;
using System.Threading.Tasks;
using System.Windows;
using WPFTemplate.Extensions;
using WPFTemplate.Tests.Testing;

namespace WPFTemplate.Tests
{
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
#if DEBUG && false
            #region Testing
            //new DataBinding().ShowDialog();
            //new TypeConversion().ShowDialog();
            //SystemParametersExt.GetSystemParametersInfo();
            //SystemFontsExt.GetSystemParametersInfo();
            //new Window1().ShowDialog();
            //new ElementsBase().ShowDialog();

            await Task.WhenAny(
                new ElementsBase().ShowAsync(),
                new ElementsDemo().ShowAsync()
            );
            #endregion
#endif
#if RELEASE || true
            await Task.WhenAny(
                new ElementsDemo().ShowAsync(),
                new WindowChromeDemo().ShowAsync()
            );
#endif
            Environment.Exit(0);
        }
    }
}
