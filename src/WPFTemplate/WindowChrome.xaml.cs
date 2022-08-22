using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using Shell = System.Windows.Shell;

namespace WPFTemplate
{
    public class WindowChrome : WindowBase
    {
        #region Resource setup
        public static readonly ResourceDictionary resources = Helpers.LoadControlResourceDictionary<WindowChrome>();

        static WindowChrome()
        {
            //Didn't seem to be working unfortunately. I'd just end up rendering a black screen.
            //[assembly: ThemeInfo(ResourceDictionaryLocation.SourceAssembly, ResourceDictionaryLocation.SourceAssembly)]
            //Application.Current.Resources.MergedDictionaries.Add(resources);
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowChrome), new FrameworkPropertyMetadata(typeof(WindowChrome)));
        }
        #endregion

        #region Obsolete properties
        [Obsolete($"The property '{nameof(AllowsTransparency)}' cannot be changed.", true)]
        new public bool AllowsTransparency { get; set; } = false;

        [Obsolete($"The property '{nameof(WindowStyle)}' cannot be changed.", true)]
        new public WindowStyle WindowStyle { get; set; } = WindowStyle.SingleBorderWindow;
        #endregion

        #region Template properties
        private const string TEMPLATE_PROPERTY_KEY = "templateProperty";

        [InfoAttribute(TEMPLATE_PROPERTY_KEY)] protected Grid headerBar { get; private set; }
        [InfoAttribute(TEMPLATE_PROPERTY_KEY)] protected StackPanel headerLeft { get; private set; }
        [InfoAttribute(TEMPLATE_PROPERTY_KEY)] protected StackPanel headerRight { get; private set; }
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
            VerifyTemplate();
        }

        protected virtual void VerifyTemplate()
        {
            //Wait for the initial render to complete before checking template updates.
            if (!IsLoaded) return;

            if (Template == null) throw new NullReferenceException("A template must be set on this control.");

            //Find the properties required by this class on the new template.
            IEnumerable<PropertyInfo> properties = typeof(WindowChrome)
                .GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttributes<InfoAttribute>()
                    .Any(i => i.data == TEMPLATE_PROPERTY_KEY));
            foreach (PropertyInfo propertyInfo in properties)
            {
                object element = Template.FindName(propertyInfo.Name, this);

                //I am allowing this to throw so that errors are detected in development.
                if (element == null)
                    throw new NullReferenceException($"The new template is missing the property '{propertyInfo.Name}'");
                if (!element.GetType().IsAssignableTo(propertyInfo.PropertyType))
                    throw new Exception($"The element for the property '{propertyInfo.Name}' must derrive from '{propertyInfo.PropertyType}'");

                propertyInfo.SetValue(this, element);
            }
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
