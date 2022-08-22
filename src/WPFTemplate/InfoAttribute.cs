using System;

namespace WPFTemplate
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class InfoAttribute : Attribute
    {
        public string data { get; private init; }

        public InfoAttribute(string data) => this.data = data;
    }
}
