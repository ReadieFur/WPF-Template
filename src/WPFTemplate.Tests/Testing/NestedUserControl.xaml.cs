using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WPFTemplate.Tests.Testing
{
    public class NestedStringConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) => destinationType == typeof(string);

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(NestedString);

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (value == null) return null;
            return ((NestedString)value).Value;
        }

        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value == null) return new NestedString();
            return new NestedString { Value = (string)value };
        }
    }

    [TypeConverter(typeof(NestedStringConverter))]
    public class NestedString
    {
        public string Value { get; set; }
    }

    public partial class NestedUserControl : UserControl
    {
        public string RootString { get; set; } = "Root";
        public NestedString NestedString { get; set; } = new NestedString { Value = "Nested" };

        public NestedUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
