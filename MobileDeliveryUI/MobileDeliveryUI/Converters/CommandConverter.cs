namespace MobileDeliveryUniversal.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class CommandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return new CommandWrapper((MobileDeliveryMVVM.Command.ICommand)value);
            else
                return "No Connection yet...";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}

