using Xamarin.Forms;

namespace MobileDeliveryUI.Behaviors
{
    public class GroupingDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GreenDataTemplate { get; set; }
        public DataTemplate YellowDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item.GetType().IsConstructedGenericType && item.GetType().GetGenericTypeDefinition() == typeof(InheritedGrouping<,>))
            {
                return GreenDataTemplate;
            }
            else
            {
                return YellowDataTemplate;
            }
        }
    }
}
