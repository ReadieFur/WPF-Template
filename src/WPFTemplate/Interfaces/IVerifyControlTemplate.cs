using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using WPFTemplate.Attributes;
using WPFTemplate.Controls;

namespace WPFTemplate.Interfaces
{
    public interface IVerifyControlTemplate
    {
        public const string TEMPLATE_ATTRIBUTE = "templateProperty";
        /// <summary>
        /// Properties to update on the class must be decorated with 'InfoAttribute("templateProperty")' and defined on the template.
        /// </summary>
        public virtual bool VerifyTemplate(ContentControl self, bool throwIfInvalid = true)
        {
            //Wait for the initial render to complete before checking template updates.
            if (!self.IsLoaded) return true;

            if (self.Template == null) throw new NullReferenceException("A template must be set on this control.");

            //Find the properties required by this class on the new template.
            IEnumerable<PropertyInfo> properties = typeof(WindowChrome)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttributes<InfoAttribute>()
                    .Any(i => i.data == TEMPLATE_ATTRIBUTE));
            foreach (PropertyInfo propertyInfo in properties)
            {
                object element = self.Template.FindName(propertyInfo.Name, self);

                //I am allowing this to throw so that errors are detected in development.
                if (element == null)
                {
                    if (throwIfInvalid) throw new NullReferenceException(
                        $"The new template is missing the property '{propertyInfo.Name}'");
                    else return false;
                }
                if (!element.GetType().IsAssignableTo(propertyInfo.PropertyType))
                {
                    if (throwIfInvalid) throw new Exception(
                        $"The element for the property '{propertyInfo.Name}' must derrive from '{propertyInfo.PropertyType}'");
                    else return false;
                }

                propertyInfo.SetValue(self, element);
            }

            return true;
        }
    }
}
