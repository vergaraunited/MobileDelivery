using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMDGeneral.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUniversal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderDetails : ContentPage
	{
        OrderData order;
		public OrderDetails ()
		{
			InitializeComponent ();
		}
        public OrderDetails(OrderData od)
        {
            InitializeComponent();
            order = od;
        }
        protected override void OnAppearing()
        {
            //Load the Stop Data for user? Date?  Today?
            lblManId.Text = order.ManifestId.ToString();
            base.OnAppearing();

        }
        private void OrderDetailSelected(object sender, ItemTappedEventArgs e)
        {
            //var ord = new Orders((IMDMMessage)((ListView)sender).SelectedItem);
            //Navigation.PushAsync(ord);

            //NavigationPage.SetBackButtonTitle(ord, $"Orders for Stop {ord.StopNumber} Truck Code: {ord.TruckCode}");
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));

        }
    }    
}