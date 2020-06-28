using MobileDeliveryGeneral.Data;
using Xamarin.Forms;

namespace MobileDeliveryUI.Behaviors
{
    public class OrderMasterDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BlueDataTemplate { get; set; }
        public DataTemplate RedDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {   
            if ((item as OrderMasterData) != null && (item as OrderMasterData).IsSelected)
            {
                return BlueDataTemplate;
            }
            else
            {
                return RedDataTemplate;
            }
        }

    }
}