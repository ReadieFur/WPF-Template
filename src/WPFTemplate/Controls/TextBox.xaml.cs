using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class TextBox : System.Windows.Controls.TextBox
    {
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(BorderBrush), "#FFABAdB3".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(Foreground), "#00000000".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

        #region Border
        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(MouseOverBorderBrush), "#FF7EB4EA".ToBrush());
        public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushProperty); set => SetValue(MouseOverBorderBrushProperty, value); }

        public static readonly DependencyProperty FocusBorderBrushProperty = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(FocusBorderBrush), "#FF569DE5".ToBrush());
        public Brush FocusBorderBrush { get => (Brush)GetValue(FocusBorderBrushProperty); set => SetValue(FocusBorderBrushProperty, value); }
        #endregion

        #region Selection
        public static readonly DependencyProperty SelectionProperty = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(Selection), "#FF569DE5".ToBrush());
        public Brush Selection { get => (Brush)GetValue(SelectionProperty); set => SetValue(SelectionProperty, value); }
        #endregion

        #region I wish multi-inheritance was a thing.
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<TextBox>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(TextBox));

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

        static TextBox() => BASE_STYLE.Seal();

        public TextBox() => Loaded += OnLoaded;
        #endregion
    }
}
