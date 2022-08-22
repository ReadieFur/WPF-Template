using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WPFTemplate
{
    public class SystemFontsExt
    {
        #region Static setup
        public static SystemFontsExt instance { get; private set; }

        static SystemFontsExt() => instance = new();
        #endregion

        #region Base properties
        public double IconFontSize => SystemFonts.IconFontSize;
        public FontFamily IconFontFamily => SystemFonts.IconFontFamily;
        public FontStyle IconFontStyle => SystemFonts.IconFontStyle;
        public FontWeight IconFontWeight => SystemFonts.IconFontWeight;
        public TextDecorationCollection IconFontTextDecorations => SystemFonts.IconFontTextDecorations;
        public double CaptionFontSize => SystemFonts.CaptionFontSize;
        public FontFamily CaptionFontFamily => SystemFonts.CaptionFontFamily;
        public FontStyle CaptionFontStyle => SystemFonts.CaptionFontStyle;
        public FontWeight CaptionFontWeight => SystemFonts.CaptionFontWeight;
        public TextDecorationCollection CaptionFontTextDecorations => SystemFonts.CaptionFontTextDecorations;
        public double SmallCaptionFontSize => SystemFonts.SmallCaptionFontSize;
        public FontFamily SmallCaptionFontFamily => SystemFonts.SmallCaptionFontFamily;
        public FontStyle SmallCaptionFontStyle => SystemFonts.SmallCaptionFontStyle;
        public FontWeight SmallCaptionFontWeight => SystemFonts.SmallCaptionFontWeight;
        public TextDecorationCollection SmallCaptionFontTextDecorations => SystemFonts.SmallCaptionFontTextDecorations;
        public double MenuFontSize => SystemFonts.MenuFontSize;
        public FontFamily MenuFontFamily => SystemFonts.MenuFontFamily;
        public FontStyle MenuFontStyle => SystemFonts.MenuFontStyle;
        public FontWeight MenuFontWeight => SystemFonts.MenuFontWeight;
        public TextDecorationCollection MenuFontTextDecorations => SystemFonts.MenuFontTextDecorations;
        public double StatusFontSize => SystemFonts.StatusFontSize;
        public FontFamily StatusFontFamily => SystemFonts.StatusFontFamily;
        public FontStyle StatusFontStyle => SystemFonts.StatusFontStyle;
        public FontWeight StatusFontWeight => SystemFonts.StatusFontWeight;
        public TextDecorationCollection StatusFontTextDecorations => SystemFonts.StatusFontTextDecorations;
        public double MessageFontSize => SystemFonts.MessageFontSize;
        public FontFamily MessageFontFamily => SystemFonts.MessageFontFamily;
        public FontStyle MessageFontStyle => SystemFonts.MessageFontStyle;
        public FontWeight MessageFontWeight => SystemFonts.MessageFontWeight;
        public TextDecorationCollection MessageFontTextDecorations => SystemFonts.MessageFontTextDecorations;
        #endregion

        #region Debug
#if DEBUG
        public static void GetSystemParametersInfo()
        {
            //Used to export values for inspection, add a breakpoint and export to csv.
            string classString = "";
            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in typeof(SystemFonts).GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (propertyInfo.Name.EndsWith("Key")) continue;
                classString += $"public {propertyInfo.PropertyType.Name} {propertyInfo.Name} => {nameof(SystemFonts)}.{propertyInfo.Name};\n";
                properties.Add(propertyInfo.Name, propertyInfo.GetValue(null));
            }
            ;
        }
#endif
        #endregion
    }
}
