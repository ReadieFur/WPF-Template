﻿using System;
using System.Windows;
using System.Windows.Controls;
using Shell = System.Windows.Shell;

namespace WPFTemplate
{
    public class WindowChrome : WindowBase, IVerifyControlTemplate
    {
        #region Resource setup
        public static readonly ResourceDictionary resources = Helpers.LoadControlResourceDictionary<WindowChrome>();

        /*static WindowChrome()
        {
            //Didn't seem to be working unfortunately. I'd just end up rendering a black screen.
            //[assembly: ThemeInfo(ResourceDictionaryLocation.SourceAssembly, ResourceDictionaryLocation.SourceAssembly)]
            Application.Current.Resources.MergedDictionaries.Add(resources);
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowChrome), new FrameworkPropertyMetadata(typeof(WindowChrome)));
        }*/
        #endregion

        #region Obsolete properties
        [Obsolete($"The property '{nameof(AllowsTransparency)}' cannot be changed.", true)]
        new public bool AllowsTransparency { get; set; } = false;

        [Obsolete($"The property '{nameof(WindowStyle)}' cannot be changed.", true)]
        new public WindowStyle WindowStyle { get; set; } = WindowStyle.SingleBorderWindow;
        #endregion

        #region Template properties
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected Grid headerBar { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected StackPanel headerLeft { get; private set; }
        [InfoAttribute(IVerifyControlTemplate.TEMPLATE_ATTRIBUTE)] protected StackPanel headerRight { get; private set; }
        //[Info(TEMPLATE_PROPERTY_KEY)] protected Button minimiseButton { get; private set; }
        //[Info(TEMPLATE_PROPERTY_KEY)] protected Button resizeButton { get; private set; }
        //[Info(TEMPLATE_PROPERTY_KEY)] protected Button closeButton { get; private set; }
        #endregion

        #region Template override
        public static readonly DependencyProperty TemplateDP = Helpers.RegisterDependencyProperty<WindowChrome, ControlTemplate>(
            nameof(Template), resources.GetResource<ControlTemplate>(nameof(WindowChrome)));
        new public ControlTemplate Template { get => (ControlTemplate)GetValue(TemplateDP); set => SetValue(TemplateDP, value); }
        #endregion

        public WindowChrome()
        {
            Shell.WindowChrome.SetWindowChrome(this, new());
            DataContext = new Styles.XAML();
        }

        #region Style managment
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ((IVerifyControlTemplate)this).VerifyTemplate(this);
        }
        #endregion

        protected override void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            base.WindowBase_Loaded(sender, e);

            //Trigger the OnTemplateChanged method to be run in order to setup the template property variables.
            base.Template = Template;
        }
    }
}
