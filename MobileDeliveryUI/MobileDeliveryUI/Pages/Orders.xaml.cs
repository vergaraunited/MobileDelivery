using MobileDeliveryGeneral.Data;
using MobileDeliveryMVVM.ViewModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Orders : ContentPage
	{
        #region locals
        StopData stop;
        public DateTime dteShipDate;
        #endregion

        public Orders(StopData sd)
        {
            InitializeComponent();
            stop = sd;
        }

        protected override void OnAppearing()
        {
            lblManId.Text = stop.ManifestId.ToString();
            lblStopNo.Text = stop.DisplaySeq.ToString();
            // lblOrdNum.Text = stop.ORD
            lblShpName.Text = stop.DealerName;
            lblShpAddr.Text = stop.Address.ToString();
            lblShpTel.Text = stop.PhoneNumber.ToString();
            lblShipDate.Text = dteShipDate.ToString("dddd, MMMM dd, yyyy");
            lblShpTel.Text = stop.PhoneNumber.ToString();
            lblDlrName.Text = stop.DealerName.ToString();
            lblDlrAddr.Text = stop.Address;
            lblDlrCSZ.Text = stop.Description;
            lblDlrTel.Text = stop.PhoneNumber.ToString();
            lblDlrNo.Text = stop.DealerNo.ToString();
            lblCmt1.Text = stop.Description;

            base.OnAppearing();
        }
        public Orders ()
		{
			InitializeComponent ();
            stop = new StopData() { ManifestId = 0 };
		}
        private void OrderSelected(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as OrderVM;
            var ordData = (OrderModelData)((ListView)sender).SelectedItem;
            vm.OrderSelectionChanged(ordData);

           // if (((ListView)sender).SelectedItem == null)
           //     return;
           // var ordData = (OrderModelData)((ListView)sender).SelectedItem;
           //// var orderOptionsPage = new OrderOptions(ordData);
           // ((ListView)sender).SelectedItem = null;
            //Navigation.PushAsync(orderOptionsPage);
            //NavigationPage.SetBackButtonTitle(orderOptionsPage, "Order Options for Order Number " + ordData.ORD_NO);
        }

        private void OrderViewed(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as OrderVM;
            var ordData = (OrderModelData)((ListView)sender).SelectedItem;
            vm.OrderSelectionChanged(ordData);
           
           // ordData.IsVisible = true;
        }
        private void OnCompleteOrder(object sender, EventArgs e)
        {
            var vm = this.BindingContext as OrderVM;
            var lstOD = new List<OrderDetailsModelData>(vm.CompletedOrders);
          //  var lstBOD = new List<OrderDetailsModelData>(vm.Orders);

            //var closeStopPage = new CloseStopPage(stop, lstOD, lstBOD);

           // Navigation.PushModalAsync(closeStopPage);

           // Navigation.PopAsync(true);
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync(true);
            return true;
        }

        private void OrderList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}