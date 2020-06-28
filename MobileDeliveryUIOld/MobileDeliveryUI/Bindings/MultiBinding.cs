namespace MobileDeliveryMVVM.Bindings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty(nameof(Bindings))]
    public class MultiBinding : IMarkupExtension
    {
        //public IList Bindings { get; } = new List();

        public string StringFormat { get; set; }

        public Binding ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
