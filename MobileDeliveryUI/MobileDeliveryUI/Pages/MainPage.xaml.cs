using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUniversal.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            masterPage.listView.ItemSelected += OnItemSelected;
            
            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
            
        }
        
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
        /*
          Page ManifestMaster;
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if ("Manifest Master".CompareTo(item.Title) == 0)
                {
                    if (ManifestMaster == null)
                        ManifestMaster = (Page)Activator.CreateInstance(item.TargetType);
                    else
                        Detail = ManifestMaster;
                }
                else
                {
                    ManifestMaster = (Page)Activator.CreateInstance(item.TargetType);
                    masterPage.listView.SelectedItem = null;
                }
            }
            */

    }
}
