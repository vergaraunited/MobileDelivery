using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileDeliveryGeneral.Data;

namespace MobileDeliveryUniversal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stops : ContentPage
	{
        #region locals
        string TRK_CDE;
        DateTime SHIP_DTE;
        TruckData truck;

        #endregion
        public Stops(TruckData td)
        {
            InitializeComponent();
            truck=td;
            //lblManId.Text = ManId.ToString();
        }
        public Stops()
		{
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            //Load the Stop Data for user? Date?  Today?
            lblManId.Text = truck.ManifestId.ToString();
            base.OnAppearing();

        }
        private void StopSelected(object sender, ItemTappedEventArgs e)
        {
            //var ord = new Orders((StopData)((ListView)sender).SelectedItem);
            //var stp = (StopData)((ListView)sender).SelectedItem;
            //Navigation.PushAsync(ord);

            NavigationPage.SetBackButtonTitle(ord, $"Orders for Stop {stp.DisplaySeq} Truck Code: {stp.TruckCode} ManifestId: {stp.ManifestId}");
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));

        }
    }
}