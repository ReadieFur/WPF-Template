using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTemplate
{
    public static class Helpers
    {
        #region Monitor properties.
        //Winforms is not accessable so I am using this instead.
        #region https://stackoverflow.com/questions/254197/how-can-i-get-the-active-screen-dimensions
        public const int MONITOR_DEFAULTTOPRIMERTY = 0x00000001;
        public const int MONITOR_DEFAULTTONEAREST = 0x00000002;

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, NativeMonitorInfo lpmi);

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct NativeRectangle
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public NativeRectangle(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public sealed class NativeMonitorInfo
        {
            public int Size = Marshal.SizeOf(typeof(NativeMonitorInfo));
            public NativeRectangle Monitor;
            public NativeRectangle Work;
            public int Flags;
        }
        #endregion

        #region https://stackoverflow.com/questions/29330440/get-precise-location-and-size-of-taskbar
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out NativeRectangle lpRect);
        #endregion

        public static Rect? GetWorkingAreaForWindow(IntPtr handle)
        {
            IntPtr monitor = MonitorFromWindow(handle, MONITOR_DEFAULTTONEAREST);
            if (monitor == IntPtr.Zero) return null;

            NativeMonitorInfo monitorInfo = new NativeMonitorInfo();
            GetMonitorInfo(monitor, monitorInfo);

            Rect monitorRect = new Rect(
                monitorInfo.Monitor.Left,
                monitorInfo.Monitor.Top,
                monitorInfo.Monitor.Right - monitorInfo.Monitor.Left,
                monitorInfo.Monitor.Bottom - monitorInfo.Monitor.Top);

            //Get the handle of the task bar.
            IntPtr TaskBarHandle;
            TaskBarHandle = FindWindow("Shell_traywnd", "");

            //Get the taskbar window rect in screen coordinates
            GetWindowRect(TaskBarHandle, out NativeRectangle taskbarRectangle);

            Rect taskbarRect = new Rect(
                taskbarRectangle.Left,
                taskbarRectangle.Top,
                taskbarRectangle.Right - taskbarRectangle.Left,
                taskbarRectangle.Bottom - taskbarRectangle.Top);

            Rect workingArea;
            if (monitorRect.IntersectsWith(taskbarRect))
            {
                //Crop the working area to remove the taskbar.
                Rect intersection = Rect.Intersect(monitorRect, taskbarRect);

                double left;
                double top;
                double width;
                double height;

                //Check if the taskbar is on the current screen.
                if (intersection.Left + intersection.Width > monitorRect.Left
                    && intersection.Left + intersection.Width < monitorRect.Left + monitorRect.Width)
                {
                    //Check if the taskbar is on the left or right side of the screen.
                    if (intersection.Left + intersection.Width < monitorRect.Left + monitorRect.Width * 0.5)
                    {
                        left = intersection.Left + intersection.Width;
                        width = monitorRect.Left + monitorRect.Width - left;
                    }
                    else
                    {
                        left = intersection.Left;
                        width = intersection.Left + intersection.Width - monitorRect.Left;
                    }
                }
                else
                {
                    left = monitorRect.Left;
                    width = monitorRect.Width;
                }

                if (intersection.Top + intersection.Height > monitorRect.Top
                    && intersection.Top + intersection.Height < monitorRect.Top + monitorRect.Height)
                {
                    //Check if the taskbar is on the top or bottom side of the screen.
                    if (intersection.Top + intersection.Height < monitorRect.Top + monitorRect.Height * 0.5)
                    {
                        top = intersection.Top + intersection.Height;
                        height = monitorRect.Top + monitorRect.Height - top;
                    }
                    else
                    {
                        top = intersection.Top;
                        height = intersection.Top + intersection.Height - monitorRect.Top;
                    }
                }
                else
                {
                    top = monitorRect.Top;
                    height = monitorRect.Height;
                }

                workingArea = new Rect(left, top, width, height);
            }
            else
            {
                //Use the whole monitor.
                workingArea = monitorRect;
            }

            return workingArea;
        }
        #endregion

        public static void InvokeDispatcher(Delegate method, params object?[] args) => Application.Current.Dispatcher.Invoke(method, args);
    }
}
