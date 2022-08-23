using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class ListViewItem : System.Windows.Controls.ListViewItem
    {
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

        #region I wish multi-inheritance was a thing.
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<ListViewItem>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(ListViewItem));

        protected bool styleHasChanged = false;

        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!styleHasChanged) Style = BASE_STYLE;
        }

        protected override void OnStyleChanged(Style? oldStyle, Style? newStyle)
        {
            styleHasChanged = true;
            base.OnStyleChanged(oldStyle, newStyle);
        }
        #endregion

        static ListViewItem() => BASE_STYLE.Seal();

        public ListViewItem() => Loaded += OnLoaded;
        #endregion
    }
}
