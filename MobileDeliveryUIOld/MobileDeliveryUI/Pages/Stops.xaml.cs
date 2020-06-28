using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileDeliveryGeneral.Data;
using MobileDeliveryGeneral.ExtMethods;

namespace MobileDeliveryUI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stops : ContentPage
	{
        #region locals
        public string TRK_CDE;
        public long SHIP_DTE;
        TruckData truck;

        #endregion
        public Stops(TruckData td)
        {
            InitializeComponent();
            truck=td;
            SHIP_DTE = td.SHIP_DTE;
            lblShipDate.Text = td.SHIP_DTE.ToString("dddd, MMMM dd, yyyy");
            lblDesc.Text = td.Desc;
            lblNotes.Text = td.NOTES;
            lblTruck.Text = td.TRK_CDE;
        }
        public Stops()
		{
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if(truck != null )
                lblManId.Text = truck.ManifestId.ToString();
            base.OnAppearing();

        }
        private void StopSelected(object sender, ItemTappedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;
            var stpData = (StopData)((ListView)sender).SelectedItem;

            var ord = new Orders(stpData);

            //run a query to get back the OrderModelData (Order Header Data for the Order Details Load).

            
            // ord.dteShipDate = SHIP_DTE;
            ord.dteShipDate =  ExtensionMethods.FromJulianToGregorianDT(SHIP_DTE, "yyyy-MM-dd").Date;
            //ord.
            // var orderPage = new Orders(ord)
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(ord);

            NavigationPage.SetBackButtonTitle(ord, $"Orders for Stop {stpData.DisplaySeq} Truck Code: {stpData.TruckCode} ManifestId: {stpData.ManifestId}");
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));

        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync(true);
            return true;
        }
    }
}