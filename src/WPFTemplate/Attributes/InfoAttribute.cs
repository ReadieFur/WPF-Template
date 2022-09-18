﻿using System;

namespace WPFTemplate.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class InfoAttribute : Attribute
    {
        public string data
        {
            get;
#if NET6_0
            private init;
#elif NET48
            private set;
#endif
        }

        public InfoAttribute(string data) => this.data = data;
    }
}
