using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace WPFTemplate
{
    public abstract class TemplateWindow : Window
    {
        protected Rect _restoreBounds = new Rect(0, 0, 800, 450);
        protected bool _useWinAeroTimer = true;
        protected Timer winAeroTimer = new();

        public abstract TemplateWindowControl templateWindowControl { get; }

        public IntPtr handle { get; private init; }
        public Rect restoreBounds
        {
            get => base.RestoreBounds;
            set
            {
                if (value.Width < MinWidth
                    || value.Width > MaxWidth
                    || value.Height < MinHeight
                    || value.Height > MaxHeight)
                    return;
                _restoreBounds = value;
            }
        }
        public bool useWinAeroTimer
        {
            get => _useWinAeroTimer;
            set
            {
                if (value == _useWinAeroTimer) return;
                _useWinAeroTimer = value;

                if (value) winAeroTimer.Start();
                else winAeroTimer.Stop();
            }
        }

        new public double MinWidth
        {
            get => base.MinWidth;
            set
            {
                if (value < 0) base.MinWidth = 0;
                else if (value > MaxHeight) base.MinWidth = MaxHeight;
                else base.MinWidth = value;
            }
        }
        new public double MinHeight
        {
            get => base.MinHeight;
            set
            {
                if (value < 0) base.MinHeight = 0;
                else if (value > MaxHeight) base.MinHeight = MaxHeight;
                else base.MaxHeight = value;
            }
        }
        /// <summary>
        /// 0 = Unlimited. Value cannot be less than MaxHeight.
        /// </summary>
        new public double MaxWidth
        {
            get => base.MaxWidth;
            set
            {
                if (value < MinWidth) return;
                base.MaxWidth = value;
            }
        }
        /// <summary>
        /// 0 = Unlimited. Value cannot be less than MinHeight.
        /// </summary>
        new public double MaxHeight
        {
            get => base.MaxHeight;
            set
            {
                if (value < MinHeight) return;
                base.MaxHeight = value;
            }
        }
        new public double Width
        {
            get => base.Width;
            set
            {
                if (value < MinWidth || value > MaxWidth) return;
                base.Width = value;
            }
        }
        new public double Height
        {
            get => base.Height;
            set
            {
                if (value < MinHeight || value > MaxHeight) return;
                base.Height = value;
            }
        }
        new public ResizeMode ResizeMode
        {
            get => base.ResizeMode;
            set
            {
                //if (value == ResizeMode.NoResize) templateWindowControl.resizeButton.Visibility = Visibility.Collapsed;
                //else templateWindowControl.resizeButton.Visibility = Visibility.Visible;
                base.ResizeMode = value;
            }
        }
        [Obsolete("Use 'restoreBounds' instead", true)]
        new public Rect RestoreBounds => base.RestoreBounds;

        public TemplateWindow()
        {
            handle = new WindowInteropHelper(this).Handle;

            winAeroTimer.Interval = 10;
            winAeroTimer.Elapsed += (s, e) => Helpers.InvokeDispatcher(WinAeroTimer_Elapsed, s, e);

            Loaded += Window_Loaded;
        }

        protected virtual void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Helpers.InvokeDispatcher(() =>
            {
                templateWindowControl.windowBorder.Visibility = Visibility.Visible;
                //DataContext = GetNewDataContext();
            });

            if (useWinAeroTimer && !winAeroTimer.Enabled) winAeroTimer.Start();

            Styles.Styles.onChange += Styles_onChange;
        }

        /// <summary>
        /// This is invoked on the main thread.
        /// </summary>
        protected virtual void WinAeroTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (ResizeMode != ResizeMode.NoResize)
            {
                Rect? workingArea = Helpers.GetWorkingAreaForWindow(handle);
                if (workingArea == null) return;

                if (WindowState == WindowState.Maximized)
                {
                    //Can resize, set to windowed fullscreen.
                    WindowState = WindowState.Normal;

                    Top = workingArea.Value.Top;
                    Left = workingArea.Value.Left;
                    Width = workingArea.Value.Width;
                    Height = workingArea.Value.Height;

                    //templateWindowControl.resizeButton.Content = "\uE923";
                    templateWindowControl.windowBorder.Visibility = Visibility.Hidden;
                }
                else if (Width != workingArea.Value.Width || Height != workingArea.Value.Height)
                {
                    //Can resize, set to windowed.
                    //templateWindowControl.resizeButton.Content = "\uE922";
                    templateWindowControl.windowBorder.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    //Can't resize, set to fixed size.
                    WindowState = WindowState.Normal;
                    Top = restoreBounds.Top;
                    Left = restoreBounds.Left;
                    Width = restoreBounds.Width;
                    Height = restoreBounds.Height;
                    //templateWindowControl.resizeButton.Content = "\uE923";
                    templateWindowControl.windowBorder.Visibility = Visibility.Visible;
                }
            }
        }

        protected virtual void Styles_onChange() => Helpers.InvokeDispatcher(() => DataContext = GetNewDataContext());

        protected virtual object GetNewDataContext() => new Styles.XAML();
    }
}
