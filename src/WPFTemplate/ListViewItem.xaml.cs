using System;
using System.Windows;

namespace WPFTemplate
{
    public partial class ListViewItem : System.Windows.Controls.ListViewItem
    {
        #region Background
        public static readonly DependencyProperty HoverBackgroundDP = Helpers.RegisterDependencyProperty<ListViewItem, string>(nameof(HoverBackground), "#1F26A0DA");
        public string HoverBackground { get => (string)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty ActiveBackgroundDP = Helpers.RegisterDependencyProperty<ListViewItem, string>(nameof(ActiveBackground), "#3D26A0DA");
        public string ActiveBackground { get => (string)GetValue(ActiveBackgroundDP); set => SetValue(ActiveBackgroundDP, value); }

        public static readonly DependencyProperty InactiveBackgroundDP = Helpers.RegisterDependencyProperty<ListViewItem, string>(nameof(InactiveBackground), "#3DDADADA");
        public string InactiveBackground { get => (string)GetValue(InactiveBackgroundDP); set => SetValue(InactiveBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty HoverBorderBrushDP = Helpers.RegisterDependencyProperty<ListViewItem, string>(nameof(HoverBorderBrush), "#A826A0DA");
        public string HoverBorderBrush { get => (string)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty ActiveBorderBrushDP = Helpers.RegisterDependencyProperty<ListViewItem, string>(nameof(ActiveBorderBrush), "#FF26A0DA");
        public string ActiveBorderBrush { get => (string)GetValue(ActiveBorderBrushDP); set => SetValue(ActiveBorderBrushDP, value); }

        public static readonly DependencyProperty InactiveBorderBrushDP = Helpers.RegisterDependencyProperty<ListViewItem, string>(nameof(InactiveBorderBrush), "#FFDADADA");
        public string InactiveBorderBrush { get => (string)GetValue(InactiveBorderBrushDP); set => SetValue(InactiveBorderBrushDP, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty ForegroundDP = Helpers.RegisterDependencyProperty<ListViewItem, string>(nameof(Foreground), "#FF000000");
        new public string Foreground { get => (string)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }
        #endregion

        [Obsolete("This property is not changeable.", true)]
        new public ListViewItem DataContext => (ListViewItem)base.DataContext;

        public ListViewItem()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
