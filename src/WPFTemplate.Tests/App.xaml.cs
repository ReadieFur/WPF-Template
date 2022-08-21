using System.Windows;

namespace WPFTemplate.Tests
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            #region Testing
            //new DataBinding().ShowDialog();
            //new TypeConversion().ShowDialog();
            #endregion

            new ElementsWindow().ShowDialog();
        }
    }
}
