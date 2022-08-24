using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class ListViewItem : System.Windows.Controls.ListViewItem
    {
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(BorderBrush), "#FFABADB3".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

        #region Background
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(MouseOverBackground), "#1F26A0DA".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundProperty); set => SetValue(MouseOverBackgroundProperty, value); }

        public static readonly DependencyProperty ActiveBackgroundProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(ActiveBackground), "#3D26A0DA".ToBrush());
        public Brush ActiveBackground { get => (Brush)GetValue(ActiveBackgroundProperty); set => SetValue(ActiveBackgroundProperty, value); }

        public static readonly DependencyProperty InactiveBackgroundProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(InactiveBackground), "#3DDADADA".ToBrush());
        public Brush InactiveBackground { get => (Brush)GetValue(InactiveBackgroundProperty); set => SetValue(InactiveBackgroundProperty, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(MouseOverBorderBrush), "#A826A0DA".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushProperty); set => SetValue(MouseOverBorderBrushProperty, value); }

        public static readonly DependencyProperty ActiveBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(ActiveBorderBrush), "#FF26A0DA".ToBrush());
        public Brush ActiveBorderBrush { get => (Brush)GetValue(ActiveBorderBrushProperty); set => SetValue(ActiveBorderBrushProperty, value); }

        public static readonly DependencyProperty InactiveBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListViewItem, Brush>(nameof(InactiveBorderBrush), "#FFDADADA".ToBrush());
        public Brush InactiveBorderBrush { get => (Brush)GetValue(InactiveBorderBrushProperty); set => SetValue(InactiveBorderBrushProperty, value); }
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
