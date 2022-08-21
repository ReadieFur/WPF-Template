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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTemplate
{
    /// <summary>
    /// Interaction logic for GridViewColumn.xaml
    /// </summary>
    public partial class GridViewColumn : System.Windows.Controls.GridViewColumn
    {
        #region Background
        public static readonly DependencyProperty BackgroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(Background), "#FFDDDDDD");
        public string Background { get => (string)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty HoverBackgroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(HoverBackground), "#FFBEE6FD");
        public string HoverBackground { get => (string)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty PressedBackgroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(PressedBackground), "#FFC4E5F6");
        public string PressedBackground { get => (string)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty BorderBrushDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(BorderBrush), "#FF707070");
        public string BorderBrush { get => (string)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty ForegroundDP = Helpers.RegisterDependencyProperty<Button, string>(nameof(Foreground), "#FF000000");
        public string Foreground { get => (string)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }
        #endregion

        public GridViewColumn()
        {
            InitializeComponent();
        }
    }
}
