using System.Windows;
using WPFTemplate.Controls;

namespace WPFTemplate.Tests
{
    public partial class ElementsWindow : WindowBase
    {
        public ElementsWindow()
        {
            InitializeComponent();
            foreach (FrameworkElement child in stackPanel.Children)
                child.Margin = new Thickness(0, 0, 0, 5);
        }
    }
}
