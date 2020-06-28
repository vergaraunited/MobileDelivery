using MobileDeliveryLogger;
using MobileDeliveryGeneral.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Trucks : ContentPage
	{
		public Trucks()
		{
			InitializeComponent();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
       
        private void TruckSelected(object sender, ItemTappedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;
            var trkData = new TruckData((TruckData)((ListView)sender).SelectedItem);
            var StopPage = new Stops(trkData);
            Logger.Info($"Truck selected {trkData.TRK_CDE} {trkData.Desc}.");
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(StopPage);
            NavigationPage.SetBackButtonTitle(StopPage, "Stop Details for Truck Number " + trkData.TRK_CDE);
            
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));


            //var item = e.SelectedItem as MasterPageItem;
            //if (item != null)
            //{
            //    if ("Stops".CompareTo(item.Title) == 0)
            //    {
            //        if (ManifestMaster == null)
            //            ManifestMaster = (Page)Activator.CreateInstance(item.TargetType);
            //        else
            //            Detail = ManifestMaster;
            //    }
            //    else
            //    {
            //        ManifestMaster = (Page)Activator.CreateInstance(item.TargetType);
            //        masterPage.listView.SelectedItem = null;
            //    }
            //}
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync(true);
            return true;
        }
    }
}