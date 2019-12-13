using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamForms.Enhanced.Converters
{
    public class StringIsNullOrEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is string text))
            {
                throw new ArgumentException($"Object in {nameof(StringIsNullOrEmptyConverter)} must be string");
            }

            return string.IsNullOrEmpty(text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
