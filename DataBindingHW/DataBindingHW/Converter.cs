using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBindingHW
{
    public class Converter : IMultiValueConverter
    {
        DateTime DataTime;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)values[0] < 1 || (int)values[0] > 31)
            {
                values[0] = 1;
            }
            if ((int)values[1] < 1 || (int)values[1] > 12)
            {
                values[1] = 1;
            }
            if ((int)values[2] < 1900 || (int)values[2] > 2100)
            {
                values[2] = 1900;
            }
            return new DateTime((int)values[0], (int)values[1], (int)values[2]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            DataTime = (DateTime)value;
            return new object[] { DataTime.Day, DataTime.Month, DataTime.Year };
        }
    }
}
