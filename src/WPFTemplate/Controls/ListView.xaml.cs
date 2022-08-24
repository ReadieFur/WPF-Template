using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class ListView : System.Windows.Controls.ListView
    {
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<ListView, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListView, Brush>(nameof(BorderBrush), "#FFABADB3".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<ListView, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

        #region Background
        public static readonly DependencyProperty DisabledBackgroundProperty = DependencyExt.RegisterDependencyProperty<ListView, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundProperty); set => SetValue(DisabledBackgroundProperty, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty DisabledBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ListView, Brush>(nameof(DisabledBorderBrush), "#FFD9D9D9".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushProperty); set => SetValue(DisabledBorderBrushProperty, value); }
        #endregion

        #region I wish multi-inheritance was a thing.
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<ListView>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(ListView));

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

        static ListView() => BASE_STYLE.Seal();

        public ListView() => Loaded += OnLoaded;
        #endregion
    }
}
