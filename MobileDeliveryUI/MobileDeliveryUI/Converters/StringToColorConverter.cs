using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using static MobileDeliveryMVVM.Models.ConnectivityModel;

namespace MobileDeliveryUniversal.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                ConnectState connState = (ConnectState)value;

                switch (connState)
                {
                    case ConnectState.Connected:
                        return Color.Green;
                    case ConnectState.Disconnected:
                        return Color.Red;
                    default:
                        return Color.FromHex(value.ToString());
                }
            }
            catch (Exception x) { }
            return Color.Default;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
