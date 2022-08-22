using System;
using System.Collections.Generic;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;

namespace WPFTemplate
{
    public static class Helpers
    {
        #region InvokeDispatcher
        public static void InvokeDispatcher(Delegate method, params object?[] args)
        {
            if (Application.Current == null) return; //Occurs when the application is shutting down.
            Application.Current.Dispatcher.Invoke(method, args);
        }

        /// <summary>
        /// Async method.
        /// </summary>
        /// <param name="method"></param>
        public static async void InvokeDispatcher(Action method)
        {
            if (Application.Current == null) return;
            await Application.Current.Dispatcher.InvokeAsync(method);
        }
        #endregion

        #region Binding
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
        #endregion

        #region ResourceDictionary
        public static ResourceDictionary LoadResourceDictionary(string assembly, string path) =>
            new() { Source = new Uri($"pack://application:,,,/{assembly};component/{path}") };

        public static ResourceDictionary LoadControlResourceDictionary<TControl>(string pathPrefix = "") where TControl : Control
        {
            string? assemblyName = typeof(TControl).Assembly.GetName().Name;
            if (string.IsNullOrEmpty(assemblyName))
                throw new NullReferenceException($"Couldn't get the assembly name for {typeof(TControl).FullName}.");
            return LoadResourceDictionary(assemblyName, $"{pathPrefix}{typeof(TControl).Name}.xaml");
        }

        public static T GetResource<T>(this ResourceDictionary self, string key)
        {
            if (!self.Contains(key))
                throw new KeyNotFoundException($"The resource '{key}' was not found in the resource dictionary '{nameof(self)}'.");
            if (!self[key].GetType().IsAssignableTo(typeof(T)))
                throw new InvalidCastException($"The resource '{key}' in the resource dictionary '{nameof(self)}' is not of type '{typeof(T).Name}'.");
            return (T)self[key];
        }
        #endregion
    }
}
