using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTemplate.Tests.Testing
{
    //Unfortunatly this won't work for binding because when the xaml tries to update this property on the base class.
    //It will fail as it can't find the DependencyProperty.
    //I am leaving this code in here however to see if I can get something to work at some point.
    //Perhaps using attributes, but I'm not sure if that will work unfortunately.

    /*public class BindingPropertyConverter<T> : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) => destinationType == typeof(T);

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(BindingProperty<T>);

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (value == null) return null;
            return ((BindingProperty<T>)value!).Value;
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
            new BindingProperty<T>((T)value);
    }

    public class BindingProperty<T> : DependencyObject
    {
        public readonly DependencyProperty ValueProperty;
        public T Value
        {
            get => (T)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public BindingProperty(T defaultValue)
        {
            ValueProperty = DependencyProperty.Register(
                name: nameof(Value),
                propertyType: typeof(T),
                ownerType: typeof(BindingProperty<T>),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue));
        }
    }*/

    /*[AttributeUsage(AttributeTargets.Property)]
    public class BindingProperty : Attribute
    {
        public string propertyName { get; private init; }
        public string dependencyPropertyName { get; private init; }
        public Type owner { get; private set; }

        public BindingProperty(string propertyName, string dependencyPropertyName)
        {
            this.propertyName = propertyName;
            this.dependencyPropertyName = dependencyPropertyName;
        }
    }*/

    /*public static class DP
    {
        private static Dictionary<Type, Dictionary<string, DependencyProperty>> dependencyProperties = new();

        public static void SetValue<TValue>(this DependencyObject self, string name, TValue value)
        {
            Type selfType = self.GetType();

            if (!dependencyProperties.ContainsKey(selfType)) dependencyProperties[selfType] = new Dictionary<string, DependencyProperty>();
            Dictionary<string, DependencyProperty> objectDependencyProperties = dependencyProperties[selfType];

            if (!dependencyProperties[selfType].ContainsKey(name)) dependencyProperties[selfType][name] =
                    DependencyProperty.Register(name, typeof(TValue), selfType);

            self.SetValue(objectDependencyProperties[name], value);
        }

        public static TValue GetValue<TValue>(this DependencyObject self, string name)
        {
            Type selfType = self.GetType();

            if (!dependencyProperties.ContainsKey(selfType)) dependencyProperties[selfType] = new Dictionary<string, DependencyProperty>();
            Dictionary<string, DependencyProperty> objectDependencyProperties = dependencyProperties[selfType];

            if (!dependencyProperties[selfType].ContainsKey(name)) dependencyProperties[selfType][name] =
                    DependencyProperty.Register(name, typeof(TValue), selfType);
            
            return (TValue)self.GetValue(dependencyProperties[selfType][name]);
        }
    }*/
}
