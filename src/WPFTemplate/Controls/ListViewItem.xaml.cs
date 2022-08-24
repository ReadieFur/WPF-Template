using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class ListViewItem : System.Windows.Controls.ListViewItem
    {
        public static readonly DependencyProperty BackgroundDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty BorderBrushDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(BorderBrush), "#FFABADB3".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty ForegroundDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(MouseOverBackground), "#1F26A0DA".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundDP); set => SetValue(MouseOverBackgroundDP, value); }

        public static readonly DependencyProperty ActiveBackgroundDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(ActiveBackground), "#3D26A0DA".ToBrush());
        public Brush ActiveBackground { get => (Brush)GetValue(ActiveBackgroundDP); set => SetValue(ActiveBackgroundDP, value); }

        public static readonly DependencyProperty InactiveBackgroundDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(InactiveBackground), "#3DDADADA".ToBrush());
        public Brush InactiveBackground { get => (Brush)GetValue(InactiveBackgroundDP); set => SetValue(InactiveBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushDP = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(MouseOverBorderBrush), "#A826A0DA".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushDP); set => SetValue(MouseOverBorderBrushDP, value); }

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
