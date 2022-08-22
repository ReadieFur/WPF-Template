using System.Windows.Media;

namespace WPFTemplate.Extensions
{
    public static class BrushExt
    {
        public static Brush ToBrush(this string self) => (Brush)new BrushConverter().ConvertFrom(self)!;
    }
}
