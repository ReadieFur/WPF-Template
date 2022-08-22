using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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

        /// <summary>
        /// Shows the window and returns a task that completes when the window is closed.
        /// </summary>
        public static async Task ShowAsync(this Window self)
        {
            ManualResetEventSlim manualResetEvent = new(false);
            self.Show();
            self.Closed += (_, _) => manualResetEvent.Set();
            await Task.Run(() => manualResetEvent.Wait());
        }
    }
}
