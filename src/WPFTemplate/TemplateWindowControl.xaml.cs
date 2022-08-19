using System.Windows.Controls;

namespace WPFTemplate
{
    public partial class TemplateWindowControl : UserControl
    {
        public TemplateWindowControl()
        {
            InitializeComponent();

            Styles.Styles.onChange += () => Helpers.InvokeDispatcher(() => DataContext = new Styles.XAML());
        }
    }
}
