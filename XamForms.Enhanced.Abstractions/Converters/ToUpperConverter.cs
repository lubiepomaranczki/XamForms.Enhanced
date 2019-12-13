using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamForms.Enhanced.Converters
{
    public class ToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string text))
            {
                return string.Empty;
            }

            return text.ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
