﻿using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using WPFTemplate.Attributes;
using WPFTemplate.Extensions;
using WPFTemplate.Interfaces;
using Shell = System.Windows.Shell;

namespace WPFTemplate.Controls
{
    public class WindowChrome : WindowBase, IVerifyControlTemplate
    {
        #region Resources (static)
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<WindowChrome>();
        public static readonly ControlTemplate BASE_TEMPLATE = RESOURCES.GetResource<ControlTemplate>(nameof(WindowChrome));

        static WindowChrome()
        {
            //Didn't seem to be working unfortunately. I'd just end up rendering a black screen.
            //[assembly: ThemeInfo(ResourceDictionaryLocation.SourceAssembly, ResourceDictionaryLocation.SourceAssembly)]
            //Application.Current.Resources.MergedDictionaries.Add(resources);
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowChrome), new FrameworkPropertyMetadata(typeof(WindowChrome)));
        }
        #endregion

        #region Binding
        //Initial values are set in the constructor.
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<WindowChrome, Brush>(nameof(Background), "Transparent".ToBrush());
        new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<WindowChrome, Brush>(nameof(BorderBrush), "Transparent".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<WindowChrome, Brush>(nameof(Foreground), "Transparent".ToBrush());
        new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

        public static readonly DependencyProperty BackgroundAltProperty = DependencyExt.RegisterDependencyProperty<WindowChrome, Brush>(nameof(BackgroundAlt), "Transparent".ToBrush());
        public Brush BackgroundAlt { get => (Brush)GetValue(BackgroundAltProperty); set => SetValue(BackgroundAltProperty, value); }

        public static readonly DependencyProperty AccentProperty = DependencyExt.RegisterDependencyProperty<WindowChrome, Brush>(nameof(Accent), "Transparent".ToBrush());
        public Brush Accent { get => (Brush)GetValue(AccentProperty); set => SetValue(AccentProperty, value); }
        #endregion

        #region Template properties
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected Grid root { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected Border windowBorder { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected Grid headerBar { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected StackPanel headerLeft { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected StackPanel headerRight { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected System.Windows.Controls.Button minimiseButton { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected System.Windows.Controls.Button resizeButton { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected System.Windows.Controls.Button closeButton { get; private set; }
        #endregion

        #region Obsolete properties
        [Obsolete($"The property '{nameof(AllowsTransparency)}' cannot be changed.", true)]
        new public bool AllowsTransparency { get; set; } = false;

        [Obsolete($"The property '{nameof(WindowStyle)}' cannot be changed.", true)]
        new public WindowStyle WindowStyle { get; set; } = WindowStyle.SingleBorderWindow;
        #endregion

        #region New base properties
        public static readonly DependencyProperty TemplateProperty = DependencyExt.RegisterDependencyProperty<WindowChrome, ControlTemplate>(nameof(Template), BASE_TEMPLATE);
        new public ControlTemplate Template { get => (ControlTemplate)GetValue(TemplateProperty); set => SetValue(TemplateProperty, value); }

        new public ResizeMode ResizeMode
        {
            get => base.ResizeMode;
            set
            {
                base.ResizeMode = value;
                if (resizeButton == null) return;

                switch (value)
                {
                    case ResizeMode.NoResize:
                        if (minimiseButton != null) minimiseButton.Visibility = Visibility.Collapsed;
                        if (resizeButton != null) resizeButton.Visibility = Visibility.Collapsed;
                        break;
                    case ResizeMode.CanMinimize:
                        if (minimiseButton != null) minimiseButton.Visibility = Visibility.Visible;
                        if (resizeButton != null) resizeButton.Visibility = Visibility.Collapsed;
                        break;
                    case ResizeMode.CanResize | ResizeMode.CanResizeWithGrip:
                        if (minimiseButton != null) minimiseButton.Visibility = Visibility.Visible;
                        if (resizeButton != null) resizeButton.Visibility = Visibility.Visible;
                        break;
                }
            }
        }
        #endregion

        protected WindowState previousWindowState;
        protected Shell.WindowChrome windowChrome { get; private init; } = new();

        public WindowChrome()
        {
            Foreground = "#000000".ToBrush();
            Background = "#ffffff".ToBrush();
            BackgroundAlt = "#e1e1e1".ToBrush();
            Accent = "#00adef".ToBrush();
            
            previousWindowState = WindowState;

            Shell.WindowChrome.SetWindowChrome(this, windowChrome);
            HwndSource.FromHwnd(handle).AddHook(HwndSourceHookCallback);
        }

        #region Style managment
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            bool templateIsValid = ((IVerifyControlTemplate)this).VerifyTemplate(this);
            if (!IsLoaded || !templateIsValid) return;
            OnValidTemplateApplied();
        }

        protected virtual void OnValidTemplateApplied()
        {
            //Clear the old events if the new properties happen to be the same as the previous ones.
            minimiseButton.Click -= MinimiseButton_Click;
            resizeButton.Click -= ResizeButton_Click;
            closeButton.Click -= CloseButton_Click;

            minimiseButton.Click += MinimiseButton_Click;
            resizeButton.Click += ResizeButton_Click;
            closeButton.Click += CloseButton_Click;

            //Trigger the resize mode to update the buttons visibility.
            ResizeMode = ResizeMode;
        }
        #endregion

        #region Window state events
        protected override void OnBoundsChanged(EventArgs e)
        {
            base.OnBoundsChanged(e);
            if (previousWindowState != WindowState)
            {
                previousWindowState = WindowState;
                OnWindowStateChanged();
            }
        }

        protected virtual void OnWindowStateChanged()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    root.Margin = new(0);
                    windowBorder.Visibility = Visibility.Visible;
                    break;
                case WindowState.Maximized:
                    root.Margin = new(0, SystemParametersExt.instance.ResizeFrameVerticalBorderWidth + 1, 0, 0);
                    windowBorder.Visibility = Visibility.Hidden;
                    break;
            }
        }
        #endregion

        #region Title bar (right)
        private void MinimiseButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void ResizeButton_Click(object sender, RoutedEventArgs e) =>
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;

        protected virtual void CloseButton_Click(object sender, RoutedEventArgs e) => Close();
        #endregion

        protected virtual IntPtr HwndSourceHookCallback(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                //https://github.com/ghost1372/HandyControls/commit/41fce1df04b45ab9a7a8ebad33f3810a89a1ad13
                case 0x0084: //WM_NCHITTEST
                    //https://stackoverflow.com/questions/69038560/detect-windows-11-with-net-framework-or-windows-api
                    /*if (Environment.OSVersion.Version.Build >= 22000 && resizeButton != null)
                    {
                        Point cursorPosition = new(lParam.ToInt32() & 0xffff, lParam.ToInt32() >> 16);
                        Rect resizeButtonPosition = new(
                            resizeButton.PointToScreen(new Point()),
                            new Size(resizeButton.ActualWidth, resizeButton.ActualHeight));
                        if (resizeButtonPosition.Contains(cursorPosition))
                        {
                            //Find a way to make the underlying event to be triggered.
                            handled = true;
                            return new IntPtr(9); //HTMAXBUTTON
                        }
                    }*/
                    break;
                default:
                    handled = false;
                    break;
            }
            return IntPtr.Zero;
        }

        protected override void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            base.WindowBase_Loaded(sender, e);

            //Trigger the OnTemplateChanged method to be run in order to setup the template property variables.
            base.Template = Template;
        }
    }
}
