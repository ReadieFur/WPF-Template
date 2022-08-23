using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class TextBox : System.Windows.Controls.TextBox
    {
        #region Border
        public static readonly DependencyProperty HoverBorderBrushDP = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(HoverBorderBrush), "#FF7EB4EA".ToBrush());
        public Brush HoverBorderBrush { get => (Brush)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty FocusBorderBrushDP = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(FocusBorderBrush), "#FF569DE5".ToBrush());
        public Brush FocusBorderBrush { get => (Brush)GetValue(FocusBorderBrushDP); set => SetValue(FocusBorderBrushDP, value); }
        #endregion

        #region Selection
        public static readonly DependencyProperty SelectionDP = DependencyExt.RegisterDependencyProperty<TextBox, Brush>(nameof(Selection), "#FF569DE5".ToBrush());
        public Brush Selection { get => (Brush)GetValue(SelectionDP); set => SetValue(SelectionDP, value); }
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
            if (newStyle == null) newStyle = BASE_STYLE;
            else
            {
                newStyle = newStyle.Unseal();
                newStyle.SetRootStyle(BASE_STYLE);
            }

            base.OnStyleChanged(oldStyle, newStyle);
        }
        #endregion

        static TextBox() => BASE_STYLE.Seal();

        public TextBox()
        {
            DataContext = this;
            Loaded += OnLoaded;
        }
        #endregion
    }
}
