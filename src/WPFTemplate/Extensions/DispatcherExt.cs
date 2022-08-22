using System;
using System.Windows;

namespace WPFTemplate.Extensions
{
    public static class DispatcherExt
    {
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
    }
}
