using System;
using System.Windows;
using System.Windows.Controls;
using WPFTemplate.Attributes;
using WPFTemplate.Extensions;
using WPFTemplate.Interfaces;
using WPFTemplate.Styles;
using Shell = System.Windows.Shell;

namespace WPFTemplate.Controls
{
    public class WindowChrome : WindowBase, IVerifyControlTemplate
    {
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<WindowChrome>();
        public static readonly ControlTemplate BASE_TEMPLATE = RESOURCES.GetResource<ControlTemplate>(nameof(WindowChrome));
        #endregion

        #region Template properties
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
        public static readonly DependencyProperty TemplateDP = DependencyExt.RegisterDependencyProperty<WindowChrome, ControlTemplate>(nameof(Template), BASE_TEMPLATE);
        new public ControlTemplate Template { get => (ControlTemplate)GetValue(TemplateDP); set => SetValue(TemplateDP, value); }
        #endregion

        static WindowChrome()
        {
            //Didn't seem to be working unfortunately. I'd just end up rendering a black screen.
            //[assembly: ThemeInfo(ResourceDictionaryLocation.SourceAssembly, ResourceDictionaryLocation.SourceAssembly)]
            //Application.Current.Resources.MergedDictionaries.Add(resources);
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowChrome), new FrameworkPropertyMetadata(typeof(WindowChrome)));
        }

        public WindowChrome()
        {
            Shell.WindowChrome.SetWindowChrome(this, new());
            DataContext = new BindableStyles();
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
