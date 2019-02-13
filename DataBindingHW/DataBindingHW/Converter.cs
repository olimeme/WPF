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
            int day = 0;
            int month = 0;
            int year = 0;
            
            if ((int.TryParse(values[0].ToString(), out day)) && 
                (int.TryParse(values[1].ToString(), out month)) && 
                (int.TryParse(values[2].ToString(), out year)) &&
                (values[0].ToString() == "") &&
                (values[1].ToString() == "") &&
                (values[2].ToString() == "") 
               )
            {
                int yearNumberLength = year.ToString().Length;
                if (values[1].ToString() == "2" && values[0].ToString() == "29" && year % 4 != 0 && yearNumberLength == 4)
                {
                    MessageBox.Show("Feburary does not have a 29 day in the year " + year);
                    return null;
                }
            }
            else
                MessageBox.Show("sosat");

            return String.Concat(values[0], ".", values[1],".", values[2]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            DataTime = (DateTime)value;
            return new object[] { DataTime.Day, DataTime.Month, DataTime.Year };
        }
    }
}
