using System;
using System.Windows;
using System.Windows.Resources;

namespace WPFTemplate.Tests
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
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

            new ElementsWindow().ShowDialog();
            //new MainWindow().ShowDialog();
        }
    }
}
