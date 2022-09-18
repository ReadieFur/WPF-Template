using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace WPFTemplate.Extensions
{
    public static class WindowsExt
    {
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

        public static T? FindParent<T>(this FrameworkElement self) where T : FrameworkElement
        {
            FrameworkElement parent = self;
            while (true)
            {
                if (parent.Parent == null || !parent.Parent.GetType().IsAssignableTo(typeof(FrameworkElement))) return null;
                if (parent.Parent.GetType().IsAssignableTo(typeof(T))) return (T)parent.Parent;
                parent = (FrameworkElement)parent.Parent;
            }
        }
    }
}
