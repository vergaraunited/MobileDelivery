using MobileDeliveryMVVM.ViewModel;
using System;
using MobileDeliveryGeneral.Data;
using MobileDeliveryGeneral.Interfaces.DataInterfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManifestDetails : ContentPage
    {
        public ManifestDetails(IMDMMessage mmd)
        {
            string TRK_CDE = ((ManifestMasterData)mmd).TRK_CDE;
            DateTime SHIP_DTE = ((ManifestMasterData)mmd).SHIP_DTE;
            InitializeComponent();
      

            //var mvm = new ManifestVM();
            //BindingContext = mvm;
        }
        public ManifestDetails()
        {
            InitializeComponent();
            //var mvm = new ManifestVM();
            //BindingContext = mvm;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync();
        }

        private void Trucks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StopList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}