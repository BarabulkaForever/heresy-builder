using HeresyBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace HeresyBuilder.Converter
{
    public class ContainsAptitudesToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ContainsAptitudes && value != null)
            {
                ContainsAptitudes aptitudes = (ContainsAptitudes)value;

                if (aptitudes == ContainsAptitudes.None)
                {
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#990000"));
                }
                else if (aptitudes == ContainsAptitudes.One)
                {
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#b37400"));
                }
                else
                {
                    return Brushes.Green;
                }
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
