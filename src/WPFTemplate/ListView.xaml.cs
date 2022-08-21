using System;
using System.Windows;

namespace WPFTemplate
{
    public partial class ListView : System.Windows.Controls.ListView
    {
        #region Background
        public static readonly DependencyProperty BackgroundDP = Helpers.RegisterDependencyProperty<ListView, string>(nameof(Background), "#FFFFFFFF");
        new public string Background { get => (string)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty DisabledBackgroundDP = Helpers.RegisterDependencyProperty<ListView, string>(nameof(DisabledBackground), "#FFFFFFFF");
        public string DisabledBackground { get => (string)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty BorderBrushDP = Helpers.RegisterDependencyProperty<ListView, string>(nameof(BorderBrush), "#FFABADB3");
        new public string BorderBrush { get => (string)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty DisabledBorderBrushDP = Helpers.RegisterDependencyProperty<ListView, string>(nameof(DisabledBorderBrush), "#FFD9D9D9");
        public string DisabledBorderBrush { get => (string)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion
        
        #region Foreground
        public static readonly DependencyProperty ForegroundDP = Helpers.RegisterDependencyProperty<ListView, string>(nameof(Foreground), "#FFABADB3");
        new public string Foreground { get => (string)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }
        #endregion

        [Obsolete("This property is not changeable.", true)]
        new public ListView DataContext => (ListView)base.DataContext;

        public ListView()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
