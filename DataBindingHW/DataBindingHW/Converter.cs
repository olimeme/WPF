using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DataBindingHW
{
    public class Converter : IMultiValueConverter
    {
        DateTime DataTime;

        public object Convert(object[] values)
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
            return String.Concat(values[0], " ", values[1],' ',values[2]);
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int x = 0;

            if (Int32.TryParse(values[2].ToString(), out x))
            {
                int year = x.ToString().Length;
                if (values[1].ToString() == "2" && values[0].ToString() == "29" && x % 4 != 0 && year == 4)
                {
                    MessageBox.Show("Feburary does not have a 29 day in the year " + x);
                    return null;
                }
            }

            return String.Concat(values[0], ".", values[1],".", values[2]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            DataTime = (DateTime)value;
            return new object[] { DataTime.Day, DataTime.Month, DataTime.Year };
        }
    }
}
