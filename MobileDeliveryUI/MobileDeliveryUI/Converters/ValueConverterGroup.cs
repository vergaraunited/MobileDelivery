using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MobileDeliveryUniversal.Converters
{
    public class ValueConverterGroup : List<IValueConverter>, IValueConverter
    {
        private string[] _parameters;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null)
                _parameters = Regex.Split(parameter.ToString(), @"(?<!\\),");

            return (this).Aggregate(value, (current, converter) => converter.Convert(current, targetType, GetParameter(converter), culture));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetParameter(IValueConverter converter)
        {
            if (_parameters == null)
                return null;

            var index = IndexOf(converter as IValueConverter);
            string parameter;

            try
            {
                parameter = _parameters[index];
            }

            catch (IndexOutOfRangeException ex)
            {
                parameter = null;
            }

            if (parameter != null)
                parameter = Regex.Unescape(parameter);

            return parameter;
        }
    }

}
