using System;
using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class ListViewItem : System.Windows.Controls.ListViewItem
    {
        public static readonly ResourceDictionary resources = ResourceDictionaryExt.LoadControlResourceDictionary<ListViewItem>();

        #region Background
        public static readonly DependencyProperty HoverBackgroundDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(HoverBackground), "#1F26A0DA".ToBrush());
        public Brush HoverBackground { get => (Brush)GetValue(HoverBackgroundDP); set => SetValue(HoverBackgroundDP, value); }

        public static readonly DependencyProperty ActiveBackgroundDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(ActiveBackground), "#3D26A0DA".ToBrush());
        public Brush ActiveBackground { get => (Brush)GetValue(ActiveBackgroundDP); set => SetValue(ActiveBackgroundDP, value); }

        public static readonly DependencyProperty InactiveBackgroundDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(InactiveBackground), "#3DDADADA".ToBrush());
        public Brush InactiveBackground { get => (Brush)GetValue(InactiveBackgroundDP); set => SetValue(InactiveBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty HoverBorderBrushDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(HoverBorderBrush), "#A826A0DA".ToBrush());
        public Brush HoverBorderBrush { get => (Brush)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty ActiveBorderBrushDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(ActiveBorderBrush), "#FF26A0DA".ToBrush());
        public Brush ActiveBorderBrush { get => (Brush)GetValue(ActiveBorderBrushDP); set => SetValue(ActiveBorderBrushDP, value); }

        public static readonly DependencyProperty InactiveBorderBrushDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(InactiveBorderBrush), "#FFDADADA".ToBrush());
        public Brush InactiveBorderBrush { get => (Brush)GetValue(InactiveBorderBrushDP); set => SetValue(InactiveBorderBrushDP, value); }
        #endregion

        #region Hidden base properties
        [Obsolete("This property is not changeable.", true)]
        new public Style Style { get => base.Style; set => base.Style = value; }

        [Obsolete("This property is not changeable.", true)]
        new public object DataContext { get => base.DataContext; set => base.DataContext = value; }
        #endregion

        public ListViewItem()
        {
            base.Style = resources.GetResource<Style>(nameof(ListViewItem));
            base.DataContext = this;
        }
    }
}
