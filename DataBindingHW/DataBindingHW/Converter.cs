using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            bool dayParse = int.TryParse(values[0].ToString(), out day);
            bool monthParse = int.TryParse(values[1].ToString(), out month);
            bool yearParse = int.TryParse(values[2].ToString(), out year);

            if (dayParse && monthParse && yearParse)
            {
                int yearNumberLength = year.ToString().Length;
                if (day == 29 && month == 2 && year % 4 != 0 && yearNumberLength == 4)
                {
                    MessageBox.Show("Feburary does not have a 29 day in the year " + year);
                    return null;
                }
                else if (day == 30 && month == 2)
                {
                    MessageBox.Show("Feburary does not have a 30 day");
                    return null;
                }
                else if (day == 31 && month == 2)
                {
                    MessageBox.Show("Feburary does not have a 31 day");
                    return null;
                }
                else if (day == 31 && month == 4)
                {
                    MessageBox.Show("April does not have a 31 day");
                    return null;
                }
                else if (day == 31 && month == 6)
                {
                    MessageBox.Show("June does not have a 31 day");
                    return null;
                }
                else if (day == 31 && month == 9)
                {
                    MessageBox.Show("September does not have a 31 day");
                    return null;
                }
                else if (day == 31 && month == 11)
                {
                    MessageBox.Show("November does not have a 31 day");
                    return null;
                }
                else if (day < 1 || day > 31)
                {
                    MessageBox.Show("A month cant have less than 1 or over 31 days");
                    return null;
                }
                else if (month < 1 || month > 12)
                {
                    MessageBox.Show("A year cant have less than 1 or over 12 months");
                    return null;
                }
                try
                {
                    return new DateTime(year, month, day).ToString();
                }
                catch(ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (Regex.IsMatch(values[0].ToString(), @"^[a-zA-Z-_)(*&^%$#@~{},.]+$") || Regex.IsMatch(values[1].ToString(), @"^[a-zA-Z-_)(*&^%$#@~{},.]+$") || Regex.IsMatch(values[2].ToString(), @"^[a-zA-Z-_)(*&^%$#@~{},.]+$"))
            {
                MessageBox.Show("Only numbers");
                return null;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            DateTime dateTime;
            if (DateTime.TryParse(value.ToString(), out dateTime))
            {
                String.Format("{0:d/MM/yyyy}", dateTime);
            }
            else
            {
                MessageBox.Show("123");
            }
            return new object[] { dateTime.Day,dateTime.Month,dateTime.Year};
        }
    }
}
