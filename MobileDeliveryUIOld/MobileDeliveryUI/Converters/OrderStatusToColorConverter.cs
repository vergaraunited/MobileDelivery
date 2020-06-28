using System;
using System.Globalization;
using Xamarin.Forms;
using static MobileDeliveryGeneral.Definitions.MsgTypes;

namespace MobileDeliveryUI.Converters
{
    public class OrderStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return Color.Default;

                OrderStatus ordState = (OrderStatus)value;

                switch (ordState)
                {
                    case OrderStatus.New:
                        return Color.AliceBlue;
                    case OrderStatus.Shipped:
                        return Color.Bisque;
                    case OrderStatus.Delivered:
                        return Color.Honeydew;
                    case OrderStatus.BackOrderd:
                        return Color.WhiteSmoke;
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
