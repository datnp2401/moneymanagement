using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MoneyManagement
{
    /// <summary>
    /// Converter for using in Entry fields for masked input of currency.
    /// <para>The binded property must be of type decimal, and must invoke the PropertyChangedEventArgs event whenever the value is changed, so that the desired mask behavior is kept.</para>
    /// </summary>
    public class ConverterNumber : IValueConverter
    {
        //from number to string
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal val = 0;

            if (!decimal.TryParse(value.ToString(), out val))
            {
            }

            return val.ToString("#,###");
        }

        //from string to number
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var formattedString = value.ToString();
            if (!formattedString.Contains("$"))
            {
                //not in correct format
                return value;
            }

            var isNegative = formattedString.Contains("(") && formattedString.Contains(")");

            var charsToRemove = new[] { "$", ",", "(", ")", "đ" };

            foreach (var c in charsToRemove)
            {
                formattedString = formattedString.Replace(c, String.Empty);
            }

            if (string.IsNullOrEmpty(formattedString))
            {
                return 0;
            }

            var currency = System.Convert.ToDecimal(formattedString);

            return isNegative ? (-1 * currency) : currency;
        }
        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    NumberFormatInfo nfi = new CultureInfo("vi-VN").NumberFormat;
        //    return Decimal.Parse(value.ToString()).ToString("C", nfi);
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    string valueFromString = Regex.Replace(value.ToString(), @"\D", "");
        //    //string valueFromString = value.ToString();

        //    if (valueFromString.Length <= 0)
        //        return 0m;

        //    long valueLong;
        //    if (!long.TryParse(valueFromString, out valueLong))
        //        return 0m;

        //    if (valueLong <= 0)
        //        return 0m;

        //    return valueLong / 100m;
        //}


    }
}
