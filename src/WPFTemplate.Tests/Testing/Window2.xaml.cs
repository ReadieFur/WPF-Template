using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFTemplate.Extensions;

namespace WPFTemplate.Tests.Testing
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            Loaded += Window2_Loaded;
        }

        private void Window2_Loaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement? lbiParent = exp.FindParent<ListBox>();
            if (lbiParent == null) throw new NullReferenceException();
            lbiParent.SizeChanged += LbiParent_SizeChanged;
            LbiParent_SizeChanged(lbiParent, null);
        }

        private void LbiParent_SizeChanged(object sender, SizeChangedEventArgs? e)
        {
            ListBox lb = (ListBox)sender;
            exp.Width = lb.ActualWidth - 14;
        }
    }
}
