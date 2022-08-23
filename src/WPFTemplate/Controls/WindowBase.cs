using System;
using System.Windows;
using System.Windows.Interop;

namespace WPFTemplate.Controls
{
    public class WindowBase : Window
    {
        private Rect _restoreBounds = new(0, 0, 800, 450);

        public IntPtr handle { get; private init; }

        new public bool IsLoaded { get; protected set; } = false;
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
        new public Rect RestoreBounds
        {
            get => _restoreBounds;
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

        public WindowBase()
        {
            handle = new WindowInteropHelper(this).EnsureHandle();

            Loaded += WindowBase_Loaded;
            LocationChanged += (_, e) => OnBoundsChanged(e);
            SizeChanged += (_, e) => OnBoundsChanged(e);
        }

        protected virtual void WindowBase_Loaded(object sender, RoutedEventArgs e) => IsLoaded = true;

        /// <summary>
        /// Called when the position or size of the window has changed.
        /// </summary>
        protected virtual void OnBoundsChanged(EventArgs e)
        {
            if (WindowState != WindowState.Maximized) RestoreBounds = new(Top, Left, Width, Height);
        }
    }
}
