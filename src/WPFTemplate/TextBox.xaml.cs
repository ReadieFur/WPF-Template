using System;
using System.Windows;

namespace WPFTemplate
{
    public partial class TextBox : System.Windows.Controls.TextBox
    {
        #region Background
        public static readonly DependencyProperty BackgroundDP = Helpers.RegisterDependencyProperty<TextBox, string>(nameof(Background), "#FF000000");
        new public string Background { get => (string)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty BorderBrushDP = Helpers.RegisterDependencyProperty<TextBox, string>(nameof(BorderBrush), "#FFABAdB3");
        new public string BorderBrush { get => (string)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty HoverBorderBrushDP = Helpers.RegisterDependencyProperty<TextBox, string>(nameof(HoverBorderBrush), "#FF7EB4EA");
        public string HoverBorderBrush { get => (string)GetValue(HoverBorderBrushDP); set => SetValue(HoverBorderBrushDP, value); }

        public static readonly DependencyProperty FocusBorderBrushDP = Helpers.RegisterDependencyProperty<TextBox, string>(nameof(FocusBorderBrush), "#FF569DE5");
        public string FocusBorderBrush { get => (string)GetValue(FocusBorderBrushDP); set => SetValue(FocusBorderBrushDP, value); }
        #endregion

        #region Foreground
        public static readonly DependencyProperty ForegroundDP = Helpers.RegisterDependencyProperty<TextBox, string>(nameof(Foreground), "#FF000000");
        new public string Foreground { get => (string)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }
        #endregion

        #region Selection
        public static readonly DependencyProperty SelectionDP = Helpers.RegisterDependencyProperty<TextBox, string>(nameof(Selection), "#FF569DE5");
        public string Selection { get => (string)GetValue(SelectionDP); set => SetValue(SelectionDP, value); }
        #endregion

        [Obsolete("This property is not changeable.", true)]
        new public TextBox DataContext => (TextBox)base.DataContext;

        public TextBox()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
