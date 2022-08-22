using System;
using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class ListView : System.Windows.Controls.ListView
    {
        public static readonly ResourceDictionary resources = ResourceDictionaryExt.LoadControlResourceDictionary<ListView>();

        #region Background
        public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<ListView, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
        public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }
        #endregion

        #region Border
        public static readonly DependencyProperty DisabledBorderBrushDP = DependencyExt.RegisterDependencyProperty<ListView, Brush>(nameof(DisabledBorderBrush), "#FFD9D9D9".ToBrush());
        public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }
        #endregion

        #region Hidden base properties
        [Obsolete("This property is not changeable.", true)]
        new public Style Style { get => base.Style; set => base.Style = value; }

        [Obsolete("This property is not changeable.", true)]
        new public object DataContext { get => base.DataContext; set => base.DataContext = value; }
        #endregion

        public ListView()
        {
            base.Style = resources.GetResource<Style>(nameof(ListView));
            base.DataContext = this;
        }
    }
}
