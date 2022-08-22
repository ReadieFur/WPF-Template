using System;
using System.Reflection;
using System.Windows;

namespace WPFTemplate.Extensions
{
    public static class DependencyExt
    {
        public static DependencyProperty RegisterDependencyProperty<TOwner, TValue>(string name, TValue defaultValue) where TOwner : DependencyObject
        {
            //Verify that the target property exists on the owner and has the specified type.
            PropertyInfo? target = typeof(TOwner).GetProperty(name, BindingFlags.Instance | BindingFlags.DeclaredOnly
                | BindingFlags.Public | BindingFlags.NonPublic);

            if (target == null)
                throw new NullReferenceException($"The property {name} does not exist on {typeof(TOwner).Name}.");
            else if (target.PropertyType != typeof(TValue))
                throw new ArgumentException($"The type of property {name} does not match the specified type {typeof(TValue).Name}.");

            return DependencyProperty.Register(name, typeof(TValue), typeof(TOwner), new PropertyMetadata(defaultValue));
        }

        public static void SetDependencyPropertyValue<T>(this DependencyObject self, DependencyProperty dependencyProperty, T value) =>
            self.SetValue(dependencyProperty, value);

        public static T GetDependencyPropertyValue<T>(this DependencyObject self, DependencyProperty dependencyProperty) =>
            (T)self.GetValue(dependencyProperty);
    }
}
