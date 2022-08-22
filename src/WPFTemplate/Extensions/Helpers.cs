using System;
using System.Windows.Media;

namespace WPFTemplate.Extensions
{
    public static class Helpers
    {
        public static Color ToColor(this string self) => (Color)new ColorConverter().ConvertFrom(self)!;
        
        public static SolidColorBrush ToBrush(this string self) => (SolidColorBrush)new BrushConverter().ConvertFrom(self)!;

        public static Color ToColor(this Brush self)
        {
            if (!self.GetType().IsAssignableTo(typeof(SolidColorBrush)))
                throw new InvalidCastException($"The brush type '{self.GetType().Name}' is not assignable to '{typeof(SolidColorBrush)}'.");
            return ((SolidColorBrush)self).Color;
        }

        public static SolidColorBrush ToBrush(this Color self) => new SolidColorBrush(self);
    }
}
