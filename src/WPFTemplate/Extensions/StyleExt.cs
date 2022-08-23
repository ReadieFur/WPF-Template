using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTemplate.Extensions
{
    public static class StyleExt
    {
        public static Style Unseal(this Style self)
        {
            Style unsealedStyle = new();
            unsealedStyle.Merge(self);
            return unsealedStyle;
        }

        public static void SetRootStyle(this Style self, Style baseStyle)
        {
            Style? rootStyle = self;
            while (rootStyle.BasedOn != null) rootStyle = rootStyle.BasedOn;
            rootStyle.BasedOn = baseStyle;
        }

        //https://stackoverflow.com/questions/5745001/xaml-combine-styles-going-beyond-basedon
        public static void Merge(this Style self, Style style)
        {
            //Ensure that the target types are compatible with eachother.
            if (self.TargetType.IsAssignableFrom(style.TargetType))
                self.TargetType = style.TargetType;
            //else throw InvalidCastException($"'{style2.TargetType}' is not assignable to '{style1.TargetType}'.");
            
            //Check if we need to merge the base style.
            if (style.BasedOn != null)
                self.Merge(style.BasedOn);
            
            //Copy setters.
            foreach (SetterBase currentSetter in style.Setters)
                self.Setters.Add(currentSetter);
            
            //Copy triggers.
            foreach (TriggerBase currentTrigger in style.Triggers)
                self.Triggers.Add(currentTrigger);
            
            //This code is only needed when using DynamicResources.
            foreach (object key in style.Resources.Keys)
                self.Resources[key] = style.Resources[key];
        }
    }
}
