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

namespace WPFTemplate.Tests.Testing
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : System.Windows.Window
    {
        public MyString stringobj { get; set; }

        public DataBinding()
        {
            InitializeComponent();

            stringobj = new MyString { Value = "#FFFF0000" };

            this.DataContext = stringobj;
        }
    }
}
