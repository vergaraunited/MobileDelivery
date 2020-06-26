using System;
using UMDGeneral.Interfaces.DataInterfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUniversal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManifestMaster : ContentPage
	{
        //call back to ManifestMasterVM with 
		public ManifestMaster ()
		{
			InitializeComponent ();
		}

        private void MenuLoadManifest_Clicked(object sender, EventArgs e)
        {
            var man = new ManifestDetails();
            Navigation.PushAsync(man);
            NavigationPage.SetBackButtonTitle(man, "Main Manifest");
        }


        private void RouteSelected(object sender, ItemTappedEventArgs e)
        {
            var man = new ManifestDetails((IMDMMessage)((ListView)sender).SelectedItem);
            Navigation.PushAsync(man);
            NavigationPage.SetBackButtonTitle(man, "Manifest Details");
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));

        }
        
    }
}