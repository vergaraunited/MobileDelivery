using MobileDeliveryGeneral.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUniversal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Orders : ContentPage
	{
        #region locals
        StopData stop;
        #endregion

        public Orders(StopData sd)
        {
            InitializeComponent();
            stop = sd;
        }

        protected override void OnAppearing()
        {
            lblManId.Text = ((StopData)stop).ManifestId.ToString();
            lblStopNo.Text = ((StopData)stop).DisplaySeq.ToString();
            lblDlrNo.Text = ((StopData)stop).DealerNo.ToString();
            lblLineCnt.Text = ((StopData)stop).DealerNo.ToString();

            base.OnAppearing();
        }
        public Orders ()
		{
			InitializeComponent ();
            stop = new StopData() { ManifestId = 0 };
		}
        private void OrderSelected(object sender, ItemTappedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;
            var ordData = new OrderData((OrderData)((ListView)sender).SelectedItem);
            var orderDetailsPage = new OrderDetails(ordData);
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(orderDetailsPage);
            NavigationPage.SetBackButtonTitle(orderDetailsPage, "Order Details for Order Number " + ordData.ORD_NO);


            //var ord = new Orders((IMDMMessage)((ListView)sender).SelectedItem);
            //Navigation.PushAsync(ord);

            //NavigationPage.SetBackButtonTitle(ord, $"Orders for Stop {ord.StopNumber} Truck Code: {ord.TruckCode}");
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));

        }
    }
}