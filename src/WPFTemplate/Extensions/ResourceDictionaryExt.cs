using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFTemplate.Extensions
{
    public static class ResourceDictionaryExt
    {
        public static ResourceDictionary LoadResourceDictionary(string assembly, string path) =>
            new() { Source = new Uri($"pack://application:,,,/{assembly};component/{path}") };

        public static ResourceDictionary LoadControlResourceDictionary<TControl>() where TControl : Control
        {
            string? assemblyName = typeof(TControl).Assembly.GetName().Name;
            string? fullName = typeof(TControl).FullName;

            if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(fullName))
                throw new NullReferenceException($"Failed to get the assembly/namespace for {typeof(TControl).Name}.");

            string path = fullName.Substring(fullName.IndexOf('.') + 1).Replace('.', '/') + ".xaml";
            
            return LoadResourceDictionary(assemblyName, path);
        }

        public static T GetResource<T>(this ResourceDictionary self, string key)
        {
            if (!self.Contains(key))
                throw new KeyNotFoundException($"The resource '{key}' was not found in the resource dictionary '{self}'.");
            if (!self[key].GetType().IsAssignableTo(typeof(T)))
                throw new InvalidCastException($"The resource '{key}' in the resource dictionary '{self}' is not of type '{typeof(T).Name}'.");
            return (T)self[key];
        }
    }
}
