using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class ListBoxItem : System.Windows.Controls.ListBoxItem
    {
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyExt.RegisterDependencyProperty<ListBoxItem, Brush>(nameof(MouseOverBackground), "#1F26A0DA".ToBrush());
        public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundProperty); set => SetValue(MouseOverBackgroundProperty, value); }

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListBoxItem, Brush>(nameof(MouseOverBorderBrush), "#a826A0Da".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushProperty); set => SetValue(MouseOverBorderBrushProperty, value); }

        public static readonly DependencyProperty SelectedActiveBackgroundProperty = DependencyExt.RegisterDependencyProperty<ListBoxItem, Brush>(nameof(SelectedActiveBackground), "#3D26A0DA".ToBrush());
        public Brush SelectedActiveBackground { get => (Brush)GetValue(SelectedActiveBackgroundProperty); set => SetValue(SelectedActiveBackgroundProperty, value); }

        public static readonly DependencyProperty SelectedActiveBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListBoxItem, Brush>(nameof(SelectedActiveBorderBrush), "#FF26A0DA".ToBrush());
        public Brush SelectedActiveBorderBrush { get => (Brush)GetValue(SelectedActiveBorderBrushProperty); set => SetValue(SelectedActiveBorderBrushProperty, value); }

        public static readonly DependencyProperty SelectedInactiveBackgroundProperty = DependencyExt.RegisterDependencyProperty<ListBoxItem, Brush>(nameof(SelectedInactiveBackground), "#3DDADADA".ToBrush());
        public Brush SelectedInactiveBackground { get => (Brush)GetValue(SelectedInactiveBackgroundProperty); set => SetValue(SelectedInactiveBackgroundProperty, value); }

        public static readonly DependencyProperty SelectedInactiveBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListBoxItem, Brush>(nameof(SelectedInactiveBorderBrush), "#FFDADADA".ToBrush());
        public Brush SelectedInactiveBorderBrush { get => (Brush)GetValue(SelectedInactiveBorderBrushProperty); set => SetValue(SelectedInactiveBorderBrushProperty, value); }

        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<ListBoxItem>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(ListBoxItem));

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

        static ListBoxItem() => BASE_STYLE.Seal();

        public ListBoxItem() => Loaded += OnLoaded;
    }
}
