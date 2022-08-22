using System;
using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class TextBox : System.Windows.Controls.TextBox
    {
        public static readonly ResourceDictionary resources = ResourceDictionaryExt.LoadControlResourceDictionary<TextBox>();

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
        
        #region Hidden base properties
        [Obsolete("This property is not changeable.", true)]
        new public Style Style { get => base.Style; set => base.Style = value; }

        [Obsolete("This property is not changeable.", true)]
        new public object DataContext { get => base.DataContext; set => base.DataContext = value; }
        #endregion

        public TextBox()
        {
            base.Style = resources.GetResource<Style>(nameof(TextBox));
            base.DataContext = this;
        }
    }
}
