using System;
using MobileDeliveryGeneral.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderOptions : ContentPage
	{
        OrderMasterData order;
        float OrdNo;
        public DateTime dteShipDate;
        public OrderOptions()
		{
			InitializeComponent ();
		}
        public OrderOptions(OrderMasterData od)
        {
            InitializeComponent();
            order = od;
            OrdNo = od.ORD_NO;
        }
        protected override void OnAppearing()
        {
            lblManId.Text = order.ManId.ToString();
            lblOrdNo.Text = order.ORD_NO.ToString();
            //lblStopNo.Text = order.DSP_SEQ.ToString();
            lblDlrNo.Text = order.DLR_NO.ToString();
            lblShipDate.Text = dteShipDate.ToString("dddd, MMMM dd, yyyy");

            base.OnAppearing();
        }

        private void OrderOptionSelected(object sender, ItemTappedEventArgs e)
        {
            //var ord = new Orders((IMDMMessage)((ListView)sender).SelectedItem);
            //Navigation.PushAsync(ord);

            //NavigationPage.SetBackButtonTitle(ord, $"Orders for Stop {ord.StopNumber} Truck Code: {ord.TruckCode}");
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));

        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync(true);
            return true;
        }
    }    
}